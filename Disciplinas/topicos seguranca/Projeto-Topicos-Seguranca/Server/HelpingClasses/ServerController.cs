using EI.SI;
using Server.HelpingClasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class ServerController
    {
        // O ip do servidor, a porta do servidor e o EndPoint do servidor
        private static IPAddress _serverIP;
        private static int _serverPort;
        private static IPEndPoint _serverEP;

        // O listener do servidor
        private static TcpListener _serverListener;

        // A encriptação simétrica do servidor
        private static Aes _mySymmetricEncryption;

        // A encriptação assimétrica do servidor e a chave assimétrica pública
        private static RSACryptoServiceProvider _myAsymmetricEncryption;
        private static string _myAsymmetricPublicKey;

        // A class que controla todos os clientes
        internal static AllClients handleAllClients;

        // O tamanho do salt para quando for dar hash das passwords
        public const int SALTSIZE = 8;

        // O número de iterações para quando for dar hash das passwords
        private const int NUMBER_OF_ITERATIONS = 1000;

        // O cooldown a esperar quando não existe data para ler
        private const int COOLDOWN_TO_WAIT_READ_DATA = 1000;

        // A data source da base de dados
        private static string DB_DATASOURCE = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\ServerDB\serverDB.mdf;Integrated Security=True";

        // O nome do ficheiro que guarda as mensagens todas, a directoria desse ficheiro e o path completo desse ficheiro
        private const string MESSAGES_FILE = "allMessagesFromClients.txt";
        private const string MESSAGES_DIRECTORY = @"C:\ServerDB\";
        private static readonly string MESSAGES_PATH = Path.Combine(MESSAGES_DIRECTORY, MESSAGES_FILE);


        public IPEndPoint MyEP { get { return _serverEP; } }
        public Aes MySymmetricEncryption { get { return _mySymmetricEncryption; } }

        public RSACryptoServiceProvider MyAsymmetricEncryption { get { return _myAsymmetricEncryption;  } }

        public string MyAsymmetricPublicKey { get { return _myAsymmetricPublicKey; } }

        public int Cooldown { get { return COOLDOWN_TO_WAIT_READ_DATA; } }

        public ServerController(IPAddress serverIP, int serverPort)
        {
            //Configura o servidor e o endpoint
            _serverIP = serverIP;
            _serverPort = serverPort;
            _serverEP = new IPEndPoint(_serverIP, _serverPort);

            //Inicia o listener
            _serverListener = new TcpListener(_serverEP);

            //Inicia a symmmetric encryption
            _mySymmetricEncryption = Aes.Create();

            //Inicia a asymmetric encryption
            _myAsymmetricEncryption = new RSACryptoServiceProvider();

            //Export a asymmetric public key para a variável
            _myAsymmetricPublicKey = _myAsymmetricEncryption.ToXmlString(false);

            handleAllClients = new AllClients();

            Console.WriteLine($"----- Server IP -----{Environment.NewLine}");
            Console.WriteLine($"{_serverIP}{Environment.NewLine}");

            Console.WriteLine($"----- Server Port ----- {Environment.NewLine}");
            Console.WriteLine($"{_serverPort}{Environment.NewLine}");

            Console.WriteLine($"----- Server Asymmetric Public Key -----{Environment.NewLine}");
            Console.WriteLine($"{_myAsymmetricPublicKey}{Environment.NewLine}");

            Console.WriteLine($"----- Server Symmetric Key -----{Environment.NewLine}");
            Console.WriteLine($"{Convert.ToBase64String(_mySymmetricEncryption.Key)}{Environment.NewLine}");

            Console.WriteLine($"----- Servidor configurado com sucesso! -----{Environment.NewLine}");

            // Cria o ficheiro das mensagens se já não tiver criado
            CreateAllMessagesTxt();

            
        }

        /// <summary>
        /// Inicia o servidor
        /// </summary>
        public void Start()
        {

            try
            {
                //Inicia o servidor
                _serverListener.Start();

                Console.WriteLine($"----- Servidor iniciado com sucesso! -----{Environment.NewLine}");


                //Fica à escuta de clientes
                ListenForClients();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

        }
        /// <summary>
        /// Ficar à escuta de clientes
        /// </summary>
        private void ListenForClients()
        {
            try
            {
                // Irá estar sempre à escuta de clientes
                while (true)
                {

                    // Aceita o cliente
                    TcpClient tcpClient = _serverListener.AcceptTcpClient();
                    NetworkStream clientSocketStream = tcpClient.GetStream();

                    // Instancia um novo thread do cliente
                    Thread clientThread = new Thread(() => ClientThread(tcpClient,clientSocketStream));

                    // Inicia o thread
                    clientThread.Start();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Um thread onde controla o cliente
        /// </summary>
        /// <param name="_tcpClient">O tcp do cliente</param>
        /// <param name="clientSocketStream">A network stream do cliente</param>
        private static void ClientThread(TcpClient tcpClient,NetworkStream clientSocketStream)
        {
            // Guarda o id, a chave assimétrica pública, a chave simétrica, o vetor de inicialização da chave simétrica do cliente
            string _id = null;
            string _clientAsymmetricPublicKey = null;
            byte[] _clientSymmetricKey = null;
            byte[] _clientSymmetricKeyIV = null;

            // Guarda a socket stream do cliente
            NetworkStream _socketStream = clientSocketStream;

            // Guarda o estado do cliente
            bool _isActive = true;

            // Instancia uma nova class do cliente
            EachClient newFreshClient = new EachClient(_socketStream);

            // Adiciona o novo cliente à lista de clientes
            handleAllClients.AddClient(newFreshClient);

            // Atualiza o id do cliente com o default que é a quantidade de clientes no servidor
            _id = handleAllClients.ClientsCounter.ToString();

            // Atualiza o id da instancia da classe cliente com o novo
            newFreshClient.Id = _id;

            Console.WriteLine($"Cliente({_id}) ----- Conectou-se ao servidor !");
            Console.WriteLine($"Quantidade de clientes no servidor: {handleAllClients.ClientsCounter}");
            
            // COnfigura as configurações de encriptação entre o cliente e o servidor
            HandleClient.SetupEncryptionsBetweenClient(ref _id, _socketStream, ref _clientAsymmetricPublicKey, ref _clientSymmetricKey);

            // Atualiza a chave assimétrica públic da instancia da classe cliente com a nova
            newFreshClient.ClientAsymmetricPublicKey = _clientAsymmetricPublicKey;

            Console.WriteLine($"Cliente({_id}) ----- Configurações de encriptação estabelecidas com sucesso !");

            // Começa à escuta de mensagens enviadas pelo cliente
            HandleClient.ListenForMessages(ref _id, tcpClient, _socketStream, ref _isActive, ref _clientSymmetricKeyIV, _clientSymmetricKey, _clientAsymmetricPublicKey);
        
            Console.WriteLine($"Cliente({_id}) ----- Desconectou-se do servidor!");

            Console.WriteLine($"Quantidade de clientes no servidor: {handleAllClients.ClientsCounter}");
        }


        /// <summary>
        /// Gera um salt para ser utilizado na hash da password
        /// </summary>
        /// <param name="size">Tamanho do salt</param>
        /// <returns></returns>
        public static byte[] GenerateSalt(int size)
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return buff;
        }

        /// <summary>
        /// Gera o hash salteado
        /// </summary>
        /// <param name="plainText">Text para dar hash</param>
        /// <param name="salt">A salt a ser utilizada na hash</param>
        /// <returns></returns>
        public static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(plainText, salt, NUMBER_OF_ITERATIONS);
            return rfc2898.GetBytes(32);
        }

        /// <summary>
        /// Verifica o login do cliente
        /// </summary>
        /// <param name="username">O username para verificar</param>
        /// <param name="password">A password para verificar</param>
        /// <param name="clientID">O id do cliente</param>
        /// <param name="socketStream">A socket stream do cliente</param>
        /// <param name="clientAsymmetricPublicKey">A chave assimétrica pública do cliente</param>
        /// <returns></returns>
        internal static bool VerifyLogin(string username, string password, string clientID, NetworkStream socketStream, string clientAsymmetricPublicKey)
        {
            SqlConnection conn = null;
            try
            {
                // Configurar ligação à Base de Dados
                conn = new SqlConnection();
                conn.ConnectionString = String.Format(DB_DATASOURCE);

                // Abrir ligação à Base de Dados
                conn.Open();

                // Declaração do comando SQL
                String sql = "SELECT * FROM Users WHERE Username = @username";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;

                // Declaração dos parâmetros do comando SQL
                SqlParameter param = new SqlParameter("@username", username);

                // Introduzir valor ao parâmentro registado no comando SQL
                cmd.Parameters.Add(param);

                // Associar ligação à Base de Dados ao comando a ser executado
                cmd.Connection = conn;

                // Executar comando SQL
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    throw new Exception("O utilizador inserido não existe!");
                }

                // Ler resultado da pesquisa
                reader.Read();

                // Obter Hash (password + salt)
                byte[] saltedPasswordHashStored = (byte[])reader["SaltedPasswordHash"];

                // Obter salt
                byte[] saltStored = (byte[])reader["Salt"];

                // Obter o profileIcon
                string iconColor = (string)reader["ProfileIcon"];

                conn.Close();

                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = GenerateSaltedHash(passwordBytes, saltStored);

                if (saltedPasswordHashStored.SequenceEqual(hash))
                {
                    // Obtém o cliente com o username na lista de clientes
                    int foundClient = AllClients.GetClient(username);

                    // Se foundClient != -1 então encontrou uma conexão ativa com o id dado
                    if (foundClient != -1)
                    {
                        Console.WriteLine($"Cliente({clientID}) ----- Tentou dar login numa conexão já feita!");
                        throw new Exception("Alguém já está logado nesta conta!");

                    }

                    Console.WriteLine($"Cliente({clientID}) ----- Inseriu password correta!");
                    Console.WriteLine($"Cliente({clientID}) ----> Deu login como Cliente({username})");

                    // Envia uma mensagem ao cliente a dizer que o login foi válido
                    HandleClient.SendMessageToClient(socketStream, $"LOGINVALID;{username};{iconColor}" , clientAsymmetricPublicKey);

                    return true;
                } else
                {
                    throw new Exception("Inseriu password errada!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro no cliente({clientID}) : {ex.Message}");

                // Envia uma mensagem ao cliente com o erro
                HandleClient.SendMessageToClient(socketStream, $"LOGININVALID;{ex.Message}", clientAsymmetricPublicKey); 
                return false;
            }
        }


        /// <summary>
        /// Regista um cliente na base de dados
        /// </summary>
        /// <param name="username">O username a guardar</param>
        /// <param name="saltedPasswordHash">A password salteada</param>
        /// <param name="salt">A salt</param>
        /// <param name="profileIcon">O profileIcon</param>
        /// <param name="clientID">O id do cliente</param>
        /// <param name="socketStream">A socket stream do cliente</param>
        /// <param name="clientAsymmetricPublicKey">A chave assimétrica pública do cliente</param>
        internal static void Register(string username, byte[] saltedPasswordHash, byte[] salt, string profileIcon, string clientID, NetworkStream socketStream, string clientAsymmetricPublicKey)
        {
            SqlConnection conn = null;
            try
            {
                // Procura o profileIcon do cliente na base de dados, para aproveitar a função e não ter de fazer outra a procurar pelo username
                string isRegistered = GetClientProfileIcon(username);

                // Se for verdade então já existe um cliente
                if (isRegistered != "")
                    throw new Exception("Já existe este cliente!");

                // Configurar ligação à Base de Dados
                conn = new SqlConnection();
                conn.ConnectionString = String.Format(DB_DATASOURCE);

                // Abrir ligação à Base de Dados
                conn.Open();

                // Declaração dos parâmetros do comando SQL
                SqlParameter paramUsername = new SqlParameter("@username", username);
                SqlParameter paramPassHash = new SqlParameter("@saltedPasswordHash", saltedPasswordHash);
                SqlParameter paramSalt = new SqlParameter("@salt", salt);
                SqlParameter paramProfileIcon = new SqlParameter("@profileIcon", profileIcon);

                // Declaração do comando SQL
                String sql = "INSERT INTO Users (Username, SaltedPasswordHash, Salt, ProfileIcon) VALUES (@username,@saltedPasswordHash,@salt,@profileIcon)";

                // Prepara comando SQL para ser executado na Base de Dados
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Introduzir valores aos parâmentros registados no comando SQL
                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramPassHash);
                cmd.Parameters.Add(paramSalt);
                cmd.Parameters.Add(paramProfileIcon);

                // Executar comando SQL
                int lines = cmd.ExecuteNonQuery();

                // Fechar ligação
                conn.Close();
                if (lines == 0)
                {
                    // Se forem devolvidas 0 linhas alteradas então não foi executado com sucesso
                    throw new Exception("Não foi possível registar este utilizador!");
                }

                Console.WriteLine($"Cliente({clientID}) ----- Registou uma conta, username:{username} password:{Convert.ToBase64String(saltedPasswordHash)} !");

                // Envia uma mensagem de sucesso ao cliente
                HandleClient.SendMessageToClient(socketStream, "REGISTER;Utilizador registado com sucesso!", clientAsymmetricPublicKey);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no cliente({clientID}): {ex.Message}");

                // Envia uma mensagem ao cliente com o erro
                HandleClient.SendMessageToClient(socketStream, $"REGISTER;{ex.Message}", clientAsymmetricPublicKey);
            }
        }


        /// <summary>
        /// Obtém o profileIcon do utilizar na base de dados
        /// </summary>
        /// <param name="username">O utilizador a ser pesquisado</param>
        /// <returns></returns>
        internal static string GetClientProfileIcon(string username)
        {
            SqlConnection conn = null;
            try
            {
                // Configurar ligação à Base de Dados
                conn = new SqlConnection();
                conn.ConnectionString = String.Format(DB_DATASOURCE);

                // Abrir ligação à Base de Dados
                conn.Open();

                // Declaração do comando SQL
                String sql = "SELECT * FROM Users WHERE Username = @username";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;

                // Declaração dos parâmetros do comando SQL
                SqlParameter param = new SqlParameter("@username", username);

                // Introduzir valor ao parâmentro registado no comando SQL
                cmd.Parameters.Add(param);

                // Associar ligação à Base de Dados ao comando a ser executado
                cmd.Connection = conn;

                // Executar comando SQL
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    throw new Exception($"Conflicto o cliente({username}) tem uma mensagem guardada no entanto este cliente não existe na base de dados!");
                }

                // Ler resultado da pesquisa
                reader.Read();

                // Obter o profileIcon
                string iconColor = (string)reader["ProfileIcon"];

                conn.Close();

                // Retorna o iconColor
                return iconColor;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return "";
            }
        }


        /// <summary>
        /// Salva uma mensagem no servidor a partir de um ficheiro predefinido
        /// </summary>
        /// <param name="clientID">O id do cliente</param>
        /// <param name="message">A mensagem a guardar</param>
        internal static void SaveMessageInServer(string clientID, string message)
        {
            try
            {
                // Define a stream do ficheiro
                FileStream serverMessagesFile = new FileStream(MESSAGES_PATH, FileMode.Append, FileAccess.Write);

                // Inicia um fluxo de escrita no ficheiro
                StreamWriter sw = new StreamWriter(serverMessagesFile);

                // Escreve o id e a mensagem no ficheiro 
                sw.WriteLine($"{clientID};{message}");
                sw.Flush();

                // Fecha os fluxos do ficheiro
                sw.Close();
                serverMessagesFile.Close();

                Console.WriteLine($"Cliente({clientID}) ----- Servidor guardou a mensagem recebida !");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao guardar mensagem: {Environment.NewLine}\t{ex.Message}");
            }
        }


        /// <summary>
        /// Obtém todas as mensagens guardadas
        /// </summary>
        /// <returns>Uma lista com todas as mensagens guardadas</returns>
        /// 
        /// As mensagens guardadas tem o formato de username;mensagem
        internal static List<string[]> GetAllSavedMessages()
        {
            try
            {
                // Instancia uma nova lista
                List<string[]> allMessages = new List<string[]>();

                // Define a stream do ficheiro
                FileStream serverMessagesFile = new FileStream(MESSAGES_PATH, FileMode.Open, FileAccess.Read);

                // Inicia um fluxo de leitura no ficheiro
                StreamReader sr = new StreamReader(serverMessagesFile);

                // O counter da última mensagem
                int lastMessage = -1;

                // Enquanto não chegar ao fim do fluxo
                while (sr.Peek() != -1)
                {
                    // Lê uma linha do fluxo
                    string line = sr.ReadLine();

                    // Separa a linha com o delimitador ;
                    string[] parsedLine = line.Split(';');

                    // Significa que tem um cliente e uma mensagem associada
                    if (parsedLine.Length > 1)
                    {
                        string[] messageFromClient = new string[2];

                        // Obtém o username da mensagem
                        messageFromClient[0] = parsedLine[0];

                        // Obtém a mensagem
                        messageFromClient[1] = parsedLine[1];

                        // Adiciona a mensagem à lista
                        allMessages.Add(messageFromClient);

                        // Incrementa o index da última mensagem
                        lastMessage++;
                    } 
                    // Significa que só tem uma mensagem, nos casos em que existe quebras de linha na mensagem, i.e, '\n'
                    else
                    {
                        // Obtém a mensagem dessa linha
                        string messageFromClient = parsedLine[0];

                        // Atualiza a mensagem antiga da lista com esta outra parte da mensagem
                        allMessages[lastMessage][1] += Environment.NewLine + messageFromClient;

                        // Inicia um trigger para ver se já chegou à última parte da mensagem
                        bool hasFinalMessage = false;

                        while(!hasFinalMessage)
                        {
                            // Se chegou ao fim do fluxo então dá break deste while
                            if (sr.Peek() == -1)
                                break;

                            // Le a linha
                            string nextLine = sr.ReadLine();

                            // Separa a linha com o delimitador ;
                            string[] nextLineParsed = nextLine.Split(';');
                            
                            // Signifa que já chegou a uma mensagem de outra pessoa, porque se o length é > 1 então a linha está escrita com o formato username;mensagem
                            if(nextLineParsed.Length > 1)
                            {
                                // Atualiza o trigger com true, significa que chegou já obteve a última parte da mensagem antiga
                                hasFinalMessage = true;

                                string[] nextMessageFromClient = new string[2];

                                // Obtém o username da mensagem
                                nextMessageFromClient[0] = nextLineParsed[0];

                                // Obtém a mensagem
                                nextMessageFromClient[1] = nextLineParsed[1];

                                // Adiciona a mensagem à lista
                                allMessages.Add(nextMessageFromClient);

                                // Incrementa o index da última mensagem
                                lastMessage++;
                                

                            } 
                            // Senão adiciona esta parte da mensagem à última mensagem
                            else
                            {
                                allMessages[lastMessage][1] += Environment.NewLine + nextLineParsed[0];
                            }
                        }

                    }

                    
                    
                }

                // Fecha os fluxos dos ficheiros
                sr.Close();
                serverMessagesFile.Close();

                // Retorna a lista com todas as mensagens
                return allMessages;
            }
            catch(Exception ex)
            {
                
                Console.WriteLine($"Erro: {ex.Message}");
                return null;

            }
        }


        /// <summary>
        /// Formata a lista com todas as mensagens em um string
        /// </summary>
        /// <param name="allSavedMessages">Lista com todas as mensagens</param>
        /// <returns>Uma string formatada pronta para ser enviada para o cliente</returns>
        internal static string FormartSavedMessage(List<string[]> allSavedMessages)
        {
            try
            {
                string formatedSavedMessages = "";
                int formatedMessageCounter = 0;

                // Dá um loop em todas as mensagens
                foreach (string[] messageFromClient in allSavedMessages)
                {
                    // Obtém o profileIcon do cliente que enviou a mensagem
                    string clientProfileIcon = GetClientProfileIcon(messageFromClient[0]);

                    // Se o profileIcon for empty então significa que a mensagem foi guardada com um cliente invalido
                    if (clientProfileIcon == "")
                        // Continua para a próxima iteração do loop
                        continue;

                    // Adiciona a string formatada com o username, mensagem e profileIcon do cliente à string formatada inteira
                    formatedSavedMessages += messageFromClient[0] + ";" + messageFromClient[1] + ";" + clientProfileIcon;

                    // Incrementa a quantidade de mensagens já formatadas
                    formatedMessageCounter++;

                    // Se o contador de mensagens formatadas for diferente da quantidade total de mensagens inicias para formatar então pode adicionar o ; á frente da última mensagem
                    // senão quer dizer que chegou à última mensagem então não precisa de adicionar o ; no fim
                    if (formatedMessageCounter != allSavedMessages.Count)
                    {
                        formatedSavedMessages += ";";
                    }

                }

                // Retorna a string inteira formatada com as mensagens todas
                return formatedSavedMessages;


            } catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return "";
            }
            

            
        }

        /// <summary>
        /// Cria o ficheiro onde as mensagens são guardadas caso este já não exista
        /// </summary>
        private static void CreateAllMessagesTxt()
        {
            // Abre o fileStream com o mode OpenOrCreate que se não existir ele criar caso contrário ele só abre o ficheiro
            FileStream fileStream = new FileStream(MESSAGES_PATH, FileMode.OpenOrCreate);

            // Fecha o fluxo da stream com o ficheiro
            fileStream.Close();

        }

    }
}
