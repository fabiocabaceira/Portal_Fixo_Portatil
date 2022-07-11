using EI.SI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace App
{
    // Notas:
    // As funções de SendACK e GetACK estão em comentário porque descobriu-se que se tivessemos este sistema,
    // iria causar problemas do lado do cliente, já que o cliente está à escuta de mensagens e pode enviar mensagens ao mesmo tempo,
    // logo as duas tasks teriam um getdata e isso iria roubar data dum do outro, assim resolveu-se dar um Thread.Sleep(3000) (i.e 3 segundos) para dar tempo
    // aos dois lados para ler a data sem conflitos de outras mensagens que possam ser enviadas ao mesmo tempo
    public class Client
    {
        // O endpoint do server
        private static IPEndPoint _serverEP;

        // O tcpcliente para fazer a conexao com a stream
        private static TcpClient _client;

        // A socket stream do cliente
        private static NetworkStream _socketStream;

        // Encriptação simétrica do cliente
        private static Aes _mySymmetricEncryption;

        // Encriptação assimétrica do cliente
        private static RSACryptoServiceProvider _myAsymmetricEncryption;

        // Chave assimétrica pública do cliente
        private static string _myAsymmetricPublicKey;

        // Chave assimétrica pública do servidor
        private static string _serverAsymmetricPublicKey;

        // Chave simétrica do servidor
        private static byte[] _serverSymmetricKey;

        // Vetor de inicialização da chave simétrica do servidor
        private static byte[] _serverSymmetricKeyIV;

        // Tempo de espera, se não houver data para lêr
        private const int COOLDOWN_TO_WAIT_READING_DATA = 3000;

        // O estado do cliente
        private bool _isActive;

        // Necessário para o loader
        public static App _app;

        // O estado do loader
        private static string _loadingState;

        // Quando é para fechar o loader
        private static bool _closeLoader;

        // O estado de trabalho do cliente
        private static bool _isWorking;

        // Quando é para fechar a notificação
        private static bool _notificationOpen;

        // O username do cliente
        private static string _username;

        // A cor do perfil do cliente
        private static string _profileIcon;

        private const int COOLDOWN_TO_WAIT_WHEN_LOADER_FINISH = 750 + 1000;
        private const int COOLDOWN_TO_WAIT_BETWEEN_LOADER_MESSAGES = 2000;

        public string Username { get { return _username; } } 
        public string ProfileIcon { get { return _profileIcon; } }

        public bool IsWorking { get { return _isWorking; } set { _isWorking = value; } }

        public string LoadingState { get { return _loadingState; } }

        public bool CloseLoader { get { return _closeLoader; } set { _closeLoader = value; } }

        public bool NotificationOpen { get { return _notificationOpen; } set { _notificationOpen = value; } }

        public Client(IPEndPoint serverEP, App app)
        { 
            // Configura o endpoint do servidor e inicia um novo cliente
            _serverEP = serverEP;

            // Inicia a encriptação simétrica
            _mySymmetricEncryption = Aes.Create();

            // Inicia a encriptação assimétrica
            _myAsymmetricEncryption = new RSACryptoServiceProvider();

            // Exporta a chave assimétrica pública do cliente
            _myAsymmetricPublicKey = _myAsymmetricEncryption.ToXmlString(false);


            _app = app;


            // Os defaults states

            _isWorking = false;

            _closeLoader = false;

            _notificationOpen = false;
            
        }



        /// <summary>
        /// Conecta-se ao servidor usando o endpoint guardado, assincronamente
        /// </summary>
        /// <param name="loaderContinuous">Quer o loader continuamente ou separado em relação às próximas mensagens</param>
        /// <returns></returns>
        public async Task Connect(bool loaderContinuous)
        {
           
            try
            {
                // Inicia o cliente
                _client = new TcpClient();

                // Conecta-se ao servidor
                _client.Connect(_serverEP);

                // Configura a socket stream com a stream do cliente
                _socketStream = _client.GetStream();

                // Mudar o estado do cliente para ativo
                _isActive = true;


                // Espera que as configurações de encriptação com o servidor sejam estabelecidas, assincronamente
                await Task.Run(() => SetupEncryptionsBetweenServer(loaderContinuous));


                // Fica à escuta de mensagens assincronamente
                Task.Run(() => ListenForMessages());
        
            } 
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Desconecta-se do servidor, assincronamente.
        /// </summary>
        /// <returns></returns>
        public async Task Disconnect()
        {
            // Verifica se o cliente está connectado ao servidor
            if (_client.Connected)
            {
                // Espera que o cliente envia a mensagem de end of transmission para o servidor
                await Task.Run(() => SendMessageToServer("", ProtocolSICmdType.EOT, false));

                // Fecha a socket stream
                _socketStream.Close();

                // Fecha o tcp client
                _client.Close();

                // Reseta o username e o profile icon
                _username = "";
                _profileIcon = "";

                // Reseta o estado de trabalho do cliente
                _isWorking = false;
            }
        }

        /// <summary>
        /// Verifica se o servidor está disponivel
        /// </summary>
        /// <returns>se está disponível</returns>
        public bool IsAvailable()
        {
                // Devolve true se o tcp cliente for diferente de null, se a socket stream for diferent de null, se a socket stream consegue ler, se a socket stream consegue escrever e se o estado de ativo do cliente é true
                if (_client != null &&  _socketStream != null && _socketStream.CanRead && _socketStream.CanWrite && _isActive) return true;
                return false;
            
        }


        /// <summary>
        /// Configura as encriptações com os dados necessários entre o cliente e o servidor, assincronamente
        /// </summary>
        /// <param name="loaderContinuous">Quer o loader continuamente ou separado em relação às próximas mensagens</param>
        /// 
        /// Passos:
        /// 
        /// - Enviar a chave assimétrica pública do cliente para o servidor
        /// 
        /// - Receber a chave assimétrica pública do servidor
        /// 
        /// - Enviar a chave simétrica do cliente para o servidor
        /// 
        /// - Receber a chave simétrica do servidor
        /// 
        private async Task SetupEncryptionsBetweenServer(bool loaderContinuous)
        {
            try
            {
                // Atualiza o loading state
                _loadingState = "A conectar ao servidor ...";

                // Reseta o closeLoader já que este método será sempre o primeiro em comparação com as mensagens para enviar
                _closeLoader = false;

                // Amostra o loader, assincronamente
                Task.Run(() => ShowLoading(_app));
                

                await Task.Delay(COOLDOWN_TO_WAIT_BETWEEN_LOADER_MESSAGES);

                // Atualiza o loading state
                _loadingState = "A configurar encriptações com o servidor ...";



                // Enviar a chave assimétrica pública do cliente para o servidor:

                // -    Obter os bytes da chave assimétrica pública do cliente
                byte[] myAsymmetricPublicKeyInBytes = Encoding.UTF8.GetBytes(_myAsymmetricPublicKey);

                // -    Enviar a chave assimétrica pública do cliente para o servidor
                SendDataToServer(myAsymmetricPublicKeyInBytes, ProtocolSICmdType.PUBLIC_KEY);
                
                

                // Receber a chave assimétrica pública do servidor:

                ProtocolSI serverAsymmetricPublicKeyInBytes = new ProtocolSI();

                // -    Recebe a data contendo a chave assimétrica pública do servidor
                GetDataFromServer(ref serverAsymmetricPublicKeyInBytes, ProtocolSICmdType.PUBLIC_KEY);

                // -    Configura a variável com a string da chave assimétrica pública do server
                _serverAsymmetricPublicKey = Encoding.UTF8.GetString(serverAsymmetricPublicKeyInBytes.GetData());


                // Enviar a chave simétrica do cliente para o servidor:

                byte[] mySymmetricKeyEncrypted = null;

                // -    Encripta a chave simétrica do cliente utilizando encriptação assimétrica
                EncryptDataWithAsymmetricEncryption(_mySymmetricEncryption.Key, ref mySymmetricKeyEncrypted);

                
                // -    Envia a chave simétrica do cliente encriptada para o servidor
                SendDataToServer(mySymmetricKeyEncrypted, ProtocolSICmdType.ASSYM_CIPHER_DATA);



                // Receber a chave simétrica do servidor:

                ProtocolSI serverSymmetricKeyEncrypted = new ProtocolSI();

                // -    Receber os dados contendo a chave simétrica encriptada do servidor
                GetDataFromServer(ref serverSymmetricKeyEncrypted, ProtocolSICmdType.ASSYM_CIPHER_DATA);

                byte[] serverSymmetricKeyDecrypted = null;

                // -    Desencripta a chave simétrica encriptada do servidor
                DesencryptDataUsingAsymmetricEncryption(serverSymmetricKeyEncrypted.GetData(), ref serverSymmetricKeyDecrypted);

                // -    Atualiza a variável com a chave simétrica desencriptada do servidor
                _serverSymmetricKey = serverSymmetricKeyDecrypted;

                // Verifica se o loader é continuo ou não
                if(!loaderContinuous)
                {
                    // Atualiza o loading state
                    _loadingState = "Concluido !";

                    await Task.Delay(COOLDOWN_TO_WAIT_WHEN_LOADER_FINISH);

                    // Muda o closeLoader para o loader saber
                    _closeLoader = true;
                    

                } else
                {
                    await Task.Delay(COOLDOWN_TO_WAIT_BETWEEN_LOADER_MESSAGES);
                }
                    

                

            } catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Fica á escuta de mensagens, assincronamente.
        /// </summary>
        private async void ListenForMessages()
        {

            try
            {
                // Enquanto o cliente está ativo
                while (_isActive)
                {
                    // Como a função é assincrona o estado pode mudar a qualquer momento por outros processos por isso é preciso verificar sempre o estado
                    if (!_isActive) return;

                    // Recebe o vetor de inicialização encriptado da chave simétrica do servidor
                    ProtocolSI serverIVEncrypted = new ProtocolSI();
                    GetDataFromServer(ref serverIVEncrypted, ProtocolSICmdType.IV);

                    // Como a função é assincrona o estado pode mudar a qualquer momento por outros processos por isso é preciso verificar sempre o estado
                    if (!_isActive) return;

                    // Desencripta o vetor de inicialização encriptado utilizando a encriptação assimétrica
                    DesencryptDataUsingAsymmetricEncryption(serverIVEncrypted.GetData(), ref _serverSymmetricKeyIV);

                    //Como a função é assincrona o estado pode mudar a qualquer momento por outros processos por isso é preciso verificar sempre o estado
                    if (!_isActive) return;

                    // Recebe a data encriptada da socket stream
                    ProtocolSI newDataEncrypted = new ProtocolSI();
                    GetDataFromServer(ref newDataEncrypted, ProtocolSICmdType.SYM_CIPHER_DATA);

                    //Como a função é assincrona o estado pode mudar a qualquer momento por outros processos por isso é preciso verificar sempre o estado
                    if (!_isActive) return;

                    // Desencripta a data encriptada recebida
                    byte[] dataDesencrypted = null;
                    DesencryptDataUsingSymmetricEncryption(newDataEncrypted.GetData(), ref dataDesencrypted);

                    // Converte a messagem recebida em string
                    string messageReceived = Encoding.UTF8.GetString(dataDesencrypted);

                    //Como a função é assincrona o estado pode mudar a qualquer momento por outros processos por isso é preciso verificar sempre o estado
                    if (!_isActive) return;

                    // Espera, assincronamente, pela escolha a ser feita
                    await ChooseActionDependingOnMessage(messageReceived);

                }


            } catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Erro: {Environment.NewLine + ex.Message}");

            }

        }

        /// <summary>
        /// Escolhe o que fazer dependendo da mensagem recebida.
        /// </summary>
        /// <param name="messageReceived">Mensagem recebida</param>
        /// <returns></returns>
        /// 
        /// Nota:
        /// Assume-me que a mensagem tenha o formato de ACTION;something;something dependo do que se quer mas o ACTION tem de estar sempre lá

        private async Task ChooseActionDependingOnMessage(string messageReceived)
        {
            try
            {
                // Divide a string pelo ;
                string[] parsedMessage = messageReceived.Split(';');

                // Remove o espaços do lado esquerdo e direito de todas as strings
                for(int i = 0; i < parsedMessage.Length; i++)
                {
                    parsedMessage[i] = parsedMessage[i].Trim('\0');
                }

                // Formata para uppercase no caso de se ter esquecido de enviar a mensagem corretamente
                parsedMessage[0] = parsedMessage[0].ToUpper();

                
                // Faz uma ação dependendo do primeiro elemento da parsedMessage, i.e, a ACTION
                switch (parsedMessage[0])
                {
                    // Caso a ACTION == LOGINVALID
                    // O formato da mensagem recebida será LOGINVALID;username;profileIcon
                    case "LOGINVALID":

                        // Obtém os valores de username e profileIcon
                        _username = parsedMessage[1];
                        _profileIcon = parsedMessage[2];

                        // Muda a navegação do cliente para a navbar da página do chat e muda a página de login/register para o chat, Invoke é preciso porque estão em thread diferentes
                        _app.Invoke((MethodInvoker)(() => _app.AppNavigationController.SetComponentOnLoader(new NavigationLoggedIn(_username, _app, _profileIcon))));
                        _app.Invoke((MethodInvoker)(() => _app.AppFormController.SetComponentOnLoader(new ChatLayout(_app))));

                        // Envia mensagem ao servidor a pedir todas as mensagens antigas, assincronamente
                        Task.Run(() => SendMessageToServer("ALLMESSAGES", ProtocolSICmdType.SYM_CIPHER_DATA, false, "ALLMESSAGES"));

                        break;

                    // Caso a ACTION == LOGININVALID OU ACTION == REGISTER
                    // O formato da mensagem recebida será LOGINVALID ou REGISTER
                    case "LOGININVALID":
                    case "REGISTER":

                        // Amostra a notificação com o erro obtido forçosamente, assincronamente
                        Task.Run(() => ShowNotification(_app, parsedMessage[1], true));
                        await Task.Delay(500);

                        // Espera que o cliente disconecte-se do servidor
                        await Disconnect();
                        break;

                    // Caso a ACTION == ALLMESSAGES
                    // O formato da mensagem recebida será:
                    //
                    // (Se tiver mensagens antigas)
                    // - ALLMESSAGES;username;message;profileIcon;username... dependendo de quantas existem
                    // 
                    // (Se não existir mensagens antigas)
                    // - ALLMESSAGES
                    //
                    case "ALLMESSAGES":

                        string messageToNoTification = null;

                        // Se o tamanho da parsedMessage é maior que dois então significa que recebeu pelo menos uma mensagem antiga
                        if(parsedMessage.Length > 2)
                        {
                            messageToNoTification = "Mensagens Recebidas";
                        } else
                        {
                            messageToNoTification = "Nenhuma mensagem por receber";
                        }

                        // Amostra a notificação forcosamente, assincronamente
                        Task.Run(() => ShowNotification(_app, messageToNoTification, true));

                        await Task.Delay(1000);

                        // Se o tamanho da parsedMessage é maior que dois então significa que recebeu pelo menos uma mensagem antiga
                        if (parsedMessage.Length > 2)
                            // Espera, assincronamente, que as mensagens sejam carregadas no chat
                            await Task.Run(() => LoadAllMessagesToChat(parsedMessage));


                        
                        // Reseta o working para false, já que o working true foi mudado quando o cliente deu login e o login foi válido
                        _isWorking = false;

                        break;

                    // Caso o ACTION == MESSAGE
                    // O formato da mensagem será MESSAGE;username;message;profileIcon
                    case "MESSAGE":

                        // Obtém o username recebido
                        string usernameReceived = parsedMessage[1];

                        string messageToNotification = null;

                        // Se o username recebido for igual ao username do cliente então a mensagem foi feita por este
                        if (usernameReceived == _username)
                            messageToNotification = "Mensagem confirmada !";

                        // Senão significa que foi uma mensagem recebida por outros clientes
                        else
                            messageToNotification = "Nova mensagem recebida !";

                        // Amostra a notificação forçosamente, assincronamente
                        Task.Run(() => ShowNotification(_app, messageToNotification, true));


                        await Task.Delay(1000);

                        // Espera, assincronamente, que as mensagens sejam carregadas no chat
                        await Task.Run(() => LoadAllMessagesToChat(parsedMessage));


                        // Reseta o working para false, já que o working true foi mudado quando o cliente enviou a mensagem pelo chat
                        _isWorking = false;

                        break;

                    // Caso o ACTION não seja os valores acima então é porque não se formatou a mensagem corretamente
                    default:

                        // Amostra a notificação forçosamente, assincronamente
                        Task.Run(() => ShowNotification(_app,messageReceived, true));

                        await Task.Delay(1000);

                        break;
                }

                

            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show($"Erro: {Environment.NewLine + ex.Message}");
            }


        }

        /// <summary>
        /// Envia uma mensagem para o servidor, assincronamente
        /// </summary>
        /// <param name="msg">Mensagem a enviar</param>
        /// <param name="typeOfMessage">Tipo de mensagem a enviar</param>
        /// <param name="loaderContinuous">Quer o loader continuamente ou separado em relação às próximas mensagens</param>
        /// <param name="customLoader">Caso queira diferentes mensagens no loader já predefinidas</param>
        public async Task SendMessageToServer(string msg, ProtocolSICmdType typeOfMessage, bool loaderContinuous, string customLoader = "")
        {
            try
            {
                // Verifica se o tipo de mensagem é end of transmition
                if(typeOfMessage == ProtocolSICmdType.EOT)
                {
                    // Atualiza o estado do cliente
                    _isActive = false;

                    // Atualiza o loading state
                    _loadingState = "A desconectar do servidor ...";

                // Verifica se o customLoader é igual a um dos já predefinido
                } else if(customLoader == "ALLMESSAGES") {

                    // Atualiza o loading state
                    _loadingState = "A pedir todas as mensagens antigas ...";


                // Senão foi nenhuma das funções acima então é uma mensagem normal
                } else {

                    // Atualiza o loading state
                    _loadingState = "A preparar mensagem para enviar ao servidor ..."; 
                }


                // Se o closeLoader == true significa que não há um loader aberto então tem de abrir outro
                if (_closeLoader == true) {

                    // Atualiza o close loader para false
                    _closeLoader = false;

                    // Amostra o loader, assincronamente
                    Task.Run(() => ShowLoading(_app));
                }
                


                await Task.Delay(COOLDOWN_TO_WAIT_BETWEEN_LOADER_MESSAGES);

                // Obtém os bytes da mensagem
                byte[] messageInBytes = Encoding.UTF8.GetBytes(msg);
                byte[] messageEncrypted = null;

                // Cria um novo vetor de inicialização para a encriptação simétrica
                _mySymmetricEncryption.GenerateIV();
                byte[] mySymmetricKeyIV = _mySymmetricEncryption.IV;
                byte[] mySymmetricKeyIVEncrypted = null;

                // Encripta o vetor de inicialização da chame simétrica do cliente utilizando a encriptação assimétrica
                EncryptDataWithAsymmetricEncryption(mySymmetricKeyIV, ref mySymmetricKeyIVEncrypted);

                // Encripta a mensagem utilizando a encriptação simétrica
                EncryptDataWithSymmetricEncryption(messageInBytes, ref messageEncrypted);

                // Verifica o tipo de mensagem e o customLoader
                if(typeOfMessage != ProtocolSICmdType.EOT && customLoader == "")
                    _loadingState = "A enviar mensagem ao servidor ...";


                await Task.Delay(COOLDOWN_TO_WAIT_BETWEEN_LOADER_MESSAGES);




                // Envia o vetor de inicialização da chave simétrica do cliente para o servidor
                SendDataToServer(mySymmetricKeyIVEncrypted, ProtocolSICmdType.IV);

                // Envia a mensagem encriptada para o servidor
                SendDataToServer(messageEncrypted, typeOfMessage);

                // Verifica o tipo de mensagem e se o loaderContinuous é falso
                if (typeOfMessage != ProtocolSICmdType.EOT && !loaderContinuous)
                    _loadingState = "Concluido !";
                

                // Se o loaderContinous é falso então atualiza o trigger para o loader antigo fechar
                if (!loaderContinuous)
                {
                    await Task.Delay(COOLDOWN_TO_WAIT_WHEN_LOADER_FINISH);

                    // Atualiza o trigger para o loader fechar
                    _closeLoader = true;
                    
                } else
                {
                    await Task.Delay(COOLDOWN_TO_WAIT_BETWEEN_LOADER_MESSAGES);
                }

                


            } catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Erro: {Environment.NewLine + ex.Message}");


            }

            
        }

     
        /// <summary>
        /// Envia data para o servidor
        /// </summary>
        /// <param name="dataToSend">Os bytes da data para enviar</param>
        /// <param name="typeOfPacket">O tipo de packet pretendido</param>
        private void SendDataToServer(byte[] dataToSend, ProtocolSICmdType typeOfPacket) 
        {
            try
            {
                ProtocolSI protocolSI = new ProtocolSI();

                // Faz o packet contendo a data e o tipo
                byte[] packet = protocolSI.Make(typeOfPacket, dataToSend);

                // Envia a data para a socket stream do servidor e dá flush para ter a certeza que o servidor recebe
                _socketStream.Write(packet, 0, packet.Length);
                _socketStream.Flush();

                // Espera pelo pacote de confirmação
                //GetACK();

                Thread.Sleep(3000);

            } catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Erro: {Environment.NewLine + ex.Message}");
            }
        }


        /// <summary>
        /// Obtém data da socket stream
        /// </summary>
        /// <param name="output">Output para onde copiar os bytes da data lida</param>
        /// <param name="expectedTypeOfPacket">O tipo de pacote esperado, o default é ProtocolSICmdType.DATA logo não verifica se o tipo é o esperado</param>
        private void GetDataFromServer(ref ProtocolSI output, ProtocolSICmdType expectedTypeOfPacket = ProtocolSICmdType.DATA)
        {

            try
            {
                // Lista dos bytes inteiros recebidos
                List<byte[]> entireByte = new List<byte[]>();


                // Verifica se existe data na socket stream antes de ler
                while (!_socketStream.DataAvailable)
                {
                    // Verifica se o cliente ainda está ativo
                    if(!_isActive)
                    {
                        return;
                    }

                    Thread.Sleep(COOLDOWN_TO_WAIT_READING_DATA);
                }

                // Lê até não haver mais data disponível
                do
                {
                    ProtocolSI protocolSI = new ProtocolSI();

                    // Lê a data da socket stream
                    _socketStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                        
                    // Adiciona parte da data lida á lista dos bytes inteiros
                    entireByte.Add(protocolSI.GetBuffer());

                } while (_socketStream.DataAvailable);



                // Copiar a lista com os bytes inteiros para um single byte
                // https://social.msdn.microsoft.com/Forums/vstudio/en-US/199dc57f-8c24-4e1f-8492-b1c5566dec09/convert-list-array-to-single-byte-array?forum=csharpgeneral
                byte[] entireBytesInBytes = entireByte.SelectMany(el => el).ToArray();

                // Copia o byte para o buffer do protocolSI Buffer
                ProtocolSI protocolSIEntire = new ProtocolSI();
                protocolSIEntire.SetBuffer(entireBytesInBytes);

                // Verifica se a data esperada é correta com a data recebida e se a data esperada é diferente da data default
                if ((protocolSIEntire.GetCmdType() != expectedTypeOfPacket) && (expectedTypeOfPacket != ProtocolSICmdType.DATA))
                    throw new Exception("O cliente recebeu data do servidor no entanto recebeu com o tipo de pacote não pretendido");


                // Envia a data inteira para o output
                output.SetBuffer(protocolSIEntire.GetBuffer());

                //SendACK();

            } catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Erro: {Environment.NewLine + ex.Message}");
               
            }
        }

        /*
        /// <summary>
        /// Envia o pacote de confirmação para o servidor
        /// </summary>
        private void SendACK()
        {
            try
            {
                ProtocolSI ackProtocol = new ProtocolSI();

                // Faz o pacote de confirmação 
                byte[] ackPacket = ackProtocol.Make(ProtocolSICmdType.ACK);

                // Escreve o pacote de confirmação na socket stream
                _socketStream.Write(ackPacket, 0, ackPacket.Length);
                _socketStream.Flush();

                //MessageBox.Show("Sent ACK");

            } catch(Exception ex)
            {
                MessageBox.Show($"Erro: {Environment.NewLine + ex.Message}");
            }
        }

        /// <summary>
        /// Recebe o pacote de confirmação
        /// </summary>
        private void GetACK()
        {
            // Trigger para saber se já recebeu o pacote de confirmação
            bool gotACK = false;

            try
            {
         
                while(!gotACK)
                {
                    //MessageBox.Show("Waiting for ACK");

                    // Verifica se existe data na socket stream antes de ler
                    while (!_socketStream.DataAvailable)
                    {
                        //MessageBox.Show("Waiting for ACK");
                        Thread.Sleep(COOLDOWN_TO_WAIT_READING_DATA);
                    }

                    ProtocolSI protocolReceived = new ProtocolSI();

                    // Obtém o tamanho de um pacote de confirmação
                    byte[] ackLength = protocolReceived.Make(ProtocolSICmdType.ACK);

                    // Le data na socket stream
                    _socketStream.Read(protocolReceived.Buffer, 0, ackLength.Length);

                    // Verifica se o tipo é o correto
                    if(protocolReceived.GetCmdType() == ProtocolSICmdType.ACK)
                    {
                        // Muda o trigger para saber que recebeu o pacote de confirmação
                        gotACK = true;

                        //MessageBox.Show("Got ack!");

                    } else
                    {
                        MessageBox.Show($"Recebi packet errado do tipo {protocolReceived.GetCmdType()}");
                    }
                }

            } catch (Exception ex)
            {
                MessageBox.Show($"Erro: {Environment.NewLine + ex.Message}");
            }
        }
        */

        /// <summary>
        /// Encripta a data utilizando a encriptação assimétrica, com a chave assimétrica pública do servidor
        /// </summary>
        /// <param name="dataToEncrypt">Data para encriptar</param>
        /// <param name="output">Output para onde copiar os bytes da data encriptada</param>
        private void EncryptDataWithAsymmetricEncryption(byte[] dataToEncrypt, ref byte[] output)
        {
            try
            {

                // Verifica se existe a chave assimétrica pública do servidor
                if (String.IsNullOrEmpty(_serverAsymmetricPublicKey)) throw new Exception("O cliente precisa da asymmetric public key do servidor");
            
                // Inicia a encriptação assimétrica
                using(RSACryptoServiceProvider asymmetricEncryption = new RSACryptoServiceProvider())
                {
                    // Importa a chave assimétrica pública do servidor
                    asymmetricEncryption.FromXmlString(_serverAsymmetricPublicKey);

                    // Encripta a data
                    byte[] encryptedData = asymmetricEncryption.Encrypt(dataToEncrypt, false);

                    // Define o tamanho do output com o correto
                    output = new byte[encryptedData.Length];

                    // Copia a data para o output pretendido
                    output = encryptedData;
                }

            } catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Erro: {Environment.NewLine + ex.Message}");
            }
        }


        /// <summary>
        /// Encripta a data utilizando a encriptação simétrica, com a chave simétrica do cliente e o vetor de inicialização dele
        /// </summary>
        /// <param name="dataToEncrypt">Data para encriptar</param>
        /// <param name="output">Output para onde copiar os bytes da data encriptada</param>
        private void EncryptDataWithSymmetricEncryption(byte[] dataToEncrypt, ref byte[] output)
        {
            try
            { 
                // Inicia a memory stream
                using (MemoryStream ms = new MemoryStream())
                {
                    // Inicia a crypto stream com a encriptação simétrica
                    using (CryptoStream cryptoStream = new CryptoStream(ms, _mySymmetricEncryption.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        // Escreve para a crypto stream a data
                        cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    }

                    // Define o tamanho do output com o correto
                    output = new byte[ms.ToArray().Length];

                    // Copia a data encriptada para o output
                    output = ms.ToArray();
                }

            } catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Erro: {Environment.NewLine + ex.Message}");
            } 
        }



        /// <summary>
        /// Desencripta a data utilizando a encriptação assimétrica, com a chave assimétrica privada do cliente
        /// </summary>
        /// <param name="dataToDecrypt">Data para desencriptar</param>
        /// <param name="output">Output para onde copiar os bytes da data desencriptada</param>
        private void DesencryptDataUsingAsymmetricEncryption(byte[] dataToDecrypt, ref byte[] output)
        {
            try
            {

                // Descripta a data utilizando a encriptação assimétrica do cliente
                byte[] dataDecrypted = _myAsymmetricEncryption.Decrypt(dataToDecrypt, false);

                // Define o tamanho do output com o correto
                output = new byte[dataDecrypted.Length];

                // Copia os bytes da data desencriptada para o output
                output = dataDecrypted;

            } catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Erro: {Environment.NewLine + ex.Message}");
            }
        }



        /// <summary>
        /// Desencripta a data utilizando a encriptação simétrica, com a chave simétrica do servidor e o vetor de inicialização dele
        /// </summary>
        /// <param name="dataToDecrypt">Data para desencriptar</param>
        /// <param name="output">Output para onde copiar os bytes da data desencriptada</param>
        private void DesencryptDataUsingSymmetricEncryption(byte[] dataToDecrypt, ref byte[] output)
        {
            try {


                // Verifica se tenho a Key e o IV da chave simétrica do servidor
                if (_serverSymmetricKey is null | _serverSymmetricKeyIV is null) throw new Exception("O cliente precisa da Key e o IV da chave simétrica do servidor");

                // Inicia o memory stream com a data para desencriptar
                using(MemoryStream ms = new MemoryStream(dataToDecrypt))
                {
                    // Inicia a encriptação simétrica
                    using (Aes serverSymmetricEncryption = Aes.Create())
                    {
                        // Importa a Key e o IV da chave simétrica do server para a encriptação simétrica
                        serverSymmetricEncryption.Key = _serverSymmetricKey;
                        serverSymmetricEncryption.IV = _serverSymmetricKeyIV;

                        // Inicia a crypto stream com a encriptação simétrica
                        using (CryptoStream cryptoStream = new CryptoStream(ms, serverSymmetricEncryption.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            // Define o tamanho do output com o correto
                            output = new byte[dataToDecrypt.Length];

                            // Le a data desencriptada da crypto stream para o output
                            cryptoStream.Read(output, 0, dataToDecrypt.Length);
                        }
                    }
                    
                }


            } catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Erro: {Environment.NewLine + ex.Message}");
            }
        }

        /// <summary>
        /// Amostra o loader, assincronamente.
        /// </summary>
        /// <param name="app">A app</param>
        /// <returns></returns>
        private static async Task ShowLoading(App app)
        {
            // Cria um novo loader
            Loader loader = new Loader(app.Cliente);

            //https://stackoverflow.com/questions/998675/how-can-i-control-the-location-of-a-dialog-when-using-showdialog-to-display-it
            loader.StartPosition = FormStartPosition.Manual;

            int loaderWidth = loader.Width;
            int loaderHeight = loader.Height;


            int appWidth = app.Width;
            int appHeight = app.Height;

            double xOffset = appWidth * 0.01;
            double yOffset = appHeight * 0.01;

            // Canto inferior direito com offsets
            int loaderLocationX = appWidth - loaderWidth - (int)xOffset;
            int loaderLocationY = appHeight - loaderHeight - (int)yOffset;

            // Redefine a localização do loader para a desejada
            loader.Location = new Point(loaderLocationX, loaderLocationY);
            loader.TopLevel = true;
            loader.TopMost = true;

            // https://stackoverflow.com/questions/39384439/how-to-close-dialogbox-programmatically
            loader.CloseAfterDone();

            loader.ShowDialog();
        }

        /// <summary>
        /// Amostra a notificação, assincronamente.
        /// </summary>
        /// <param name="app">A app</param>
        /// <param name="text"></param>
        /// <param name="forceOpen"></param>
        /// <param name="delayToClose"></param>
        /// <returns></returns>
        internal static async Task ShowNotification(App app, string text, bool forceOpen = false, int delayToClose = Notification.DEFAULT_DELAY)
        {
            // Verifica se quer abrir forcosamente
            if(forceOpen)
            {
                // Assim força as notificações que estão abertas a serem fechadas
                app.Cliente.NotificationOpen = false;
                await Task.Delay(500);

                app.Cliente.NotificationOpen = true;
            }

            // Cria a nova notificação
            Notification newNotification = new Notification(text);

            newNotification.StartPosition = FormStartPosition.Manual;

            int newNotificationWidth = newNotification.Width;
            int newNotificationHeight = newNotification.Height;

            int appWidth = app.Width;
            int appHeight = app.Height;

            double xOffset = appWidth * 0.01;
            double yOffset = appHeight * 0.01;

            // Canto superior direito com offsets
            int notificationLocationX = appWidth - newNotificationWidth -  (int)xOffset;
            int notificationLocationY = newNotificationHeight + (int)yOffset;


            // Redefine a localização do loader para a desejada
            newNotification.Location = new Point(notificationLocationX, notificationLocationY);
            newNotification.TopLevel = true;
            newNotification.TopMost = true;

            Notification.ShowNotification(app,newNotification,delayToClose);

            newNotification.ShowDialog();

            // Só é executado quando a notificação acaba, pois é assim que o showDialog funciona
            // assim quando acaba reseta a notificationOpen para falso
            app.Cliente.NotificationOpen = false;
            
        }


        /// <summary>
        /// Dá load da mensagem formatada com todas as mensagens para o chat
        /// </summary>
        /// <param name="formatedMessage">A mensagem formatada</param>
        /// 
        /// Esta mensagem é formatada do lado do servidor e o cliente recebe-a pela stream
        private async void LoadAllMessagesToChat(string[] formatedMessage)
        {
            string usernameReceived = null;
            string messageReceived = null;
            string profileIconReceived = null;

            int counter = 0;

            // Como sei que a mensagem formata é do estilo ACTION;username;message;profileIcon... então começo no 1 para passar a ACTION à frente
            // depois como sei que são 3 dados faço iffs
            for(int i = 1; i < formatedMessage.Length; i++)
            {
                counter++;
                
                // Se counter == 1 então estou no username
                if(counter == 1) 
                    usernameReceived = formatedMessage[i];

                // Se counter == 2 então estou na mensagem
                if(counter == 2)
                    messageReceived = formatedMessage[i];

                // Se counter == 3 então estou no profileIcon
                if(counter == 3)
                {
                    profileIconReceived = formatedMessage[i];

                    // Verifica se a mensagem é minha ou de outra pessoa
                    if(usernameReceived == _username)
                    {
                        YourMessage myMessage = new YourMessage(usernameReceived,messageReceived, profileIconReceived);

                        // Adiciona a mensagem ao chat, Invoke porque estamos em threads diferentes
                        ((ChatLayout)_app.AppFormController.ActiveComponent).Invoke((MethodInvoker)(() => ((ChatLayout)_app.AppFormController.ActiveComponent).MessagesLoader.AddMessage(myMessage)));
                    
                    } else
                    {
                        //  Como nao conseguimos chegar ao resultado como queriamos no tipo de mensagem NotYourMessage, decidimos utilizar o mesmo tipo de mensagem para os dois, ou seja, usámos o YourMessage em vez do NotYourMessage
                        //  NotYourMessage otherMessage = new NotYourMessage(usernameReceived, messageReceived, profileIconReceived);

                        YourMessage otherMessage = new YourMessage(usernameReceived, messageReceived, profileIconReceived);

                        // Adiciona a mensagem ao chat, Invoke porque estamos em threads diferentes
                        ((ChatLayout)_app.AppFormController.ActiveComponent).Invoke((MethodInvoker)(() => ((ChatLayout)_app.AppFormController.ActiveComponent).MessagesLoader.AddMessage(otherMessage)));

                    }

                    // Reseta o counter para a próxima mensagem
                    counter = 0;
                }
                    

            }

        }

        
    }
}
