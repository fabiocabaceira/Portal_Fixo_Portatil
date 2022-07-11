using EI.SI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server.HelpingClasses
{
    // Notas:
    // As funções de SendACK e GetACK estão em comentário porque descobriu-se que se tivessemos este sistema,
    // iria causar problemas do lado do cliente, já que o cliente está à escuta de mensagens e pode enviar mensagens ao mesmo tempo,
    // logo as duas tasks teriam um getdata e isso iria roubar data dum do outro, assim resolveu-se dar um Thread.Sleep(3000) (i.e 3 segundos)  para dar tempo
    // aos dois lados para ler a data sem conflitos de outras mensagens que possam ser enviadas ao mesmo tempo
    internal class HandleClient
    {

        /// <summary>
        /// Configura as encriptações com os dados necessários entre o servidor e o cliente:
        /// 
        /// <para>- Receber a chave assimétrica pública do cliente</para>
        /// 
        /// <para>- Enviar a chave assimétrica pública do servidor para o cliente</para>
        /// 
        /// <para>- Receber a chave simétrica do cliente</para>
        /// 
        /// <para>- Enviar a chave simétrica do servidor para o cliente</para>
        /// 
        /// </summary>
        /// <param name="clientID">A referência do cliente ID para dar log na consola</param>
        /// <param name="socketStream">Socket stream do cliente</param>
        /// <param name="clientAsymmetricPublicKey">A referência da chave assimétrica publica do cliente para definila na propriedade do ClientThread</param>
        /// <param name="clientSymmetricKey">A chave simétrica do cliente para defini-la na propriedade do ClientThread</param>
        public static void SetupEncryptionsBetweenClient(ref string clientID,NetworkStream socketStream, ref string clientAsymmetricPublicKey, ref byte[] clientSymmetricKey)
        {
            try
            {
                // Receber a chave assimétrica pública do cliente:

                ProtocolSI clientAsymmetricPublicKeyInBytes = new ProtocolSI();

                // -    Recebe a data contendo a chave assimétrica pública do cliente
                GetDataFromClient(socketStream, clientAsymmetricPublicKeyInBytes, ProtocolSICmdType.PUBLIC_KEY);

                // -    Converte a chave assimétrica pública do cliente para string e define a propriedade do _clientSymmetricKey do Thread ClientThread
                clientAsymmetricPublicKey = Encoding.UTF8.GetString(clientAsymmetricPublicKeyInBytes.GetData());



                // Enviar a chave assimétrica pública do servidor para o cliente

                // -    Converte a chave assimétrica pública do servidor para bytes
                byte[] myAsymmetricPublicKeyInBytes = Encoding.UTF8.GetBytes(Server.serverController.MyAsymmetricPublicKey);



                // -    Envia a chave assimétrica pública do servidor para o cliente
                SendDataToClient(socketStream,myAsymmetricPublicKeyInBytes, ProtocolSICmdType.PUBLIC_KEY);


                // Receber a chave simétrica do cliente:

                ProtocolSI clientSymmetricKeyEncrypted = new ProtocolSI();

                // -    Recebe a data contendo a chave simétrica encriptada do cliente
                GetDataFromClient(socketStream, clientSymmetricKeyEncrypted, ProtocolSICmdType.ASSYM_CIPHER_DATA);

                byte[] clientSymmetricKeyDecrypted = null;

                // -    Desencripta a chave simétrica encriptada do cliente
                DesencryptDataUsingAsymmetricEncryption(clientSymmetricKeyEncrypted.GetData(), ref clientSymmetricKeyDecrypted);

                // -    Passa a chave simétrica do cliente para a propriedade _clientSymmetricKey do cliente no ClientThread
                clientSymmetricKey = new byte[clientSymmetricKeyDecrypted.Length];
                clientSymmetricKey = clientSymmetricKeyDecrypted;



                // Enviar a chave simétrica do servidor para o cliente
                byte[] mySymmetricKey = Server.serverController.MySymmetricEncryption.Key;
                byte[] mySymmetricKeyEncrypted = null;

                // -    Encripta a chave simétrica do servidor utilizando encriptação assimétrica utilizando a chave assimétrica pública do cliente
                EncryptDataWithAsymmetricEncryption(mySymmetricKey, ref mySymmetricKeyEncrypted, clientAsymmetricPublicKey);


                // -    Envia a chave simétrica encriptada do servidor para o cliente
                SendDataToClient(socketStream ,mySymmetricKeyEncrypted, ProtocolSICmdType.ASSYM_CIPHER_DATA);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Fica á escuta de mensagens na socket stream do cliente
        /// </summary>
        /// <param name="clientID">A referência do cliente ID para dar log na consola</param>
        /// <param name="socketStream">Socket stream do cliente</param>
        /// <param name="isActive">Trigger para saber se o cliente está ativo ou não</param>
        /// <param name="clientSymmetricKeyIV">A referência do vetor de inicialização da chave simétrica do cliente</param>
        /// <param name="clientSymmetricKey">A chave simétrica do cliente</param>
        /// <param name="clientAsymmetricPublicKey">A chave assimétrica pública do cliente</param>
        public static void ListenForMessages(ref string clientID,TcpClient tcpClient,NetworkStream socketStream, ref bool isActive, ref byte[] clientSymmetricKeyIV, byte[] clientSymmetricKey, string clientAsymmetricPublicKey)
        {

            // Enquanto o cliente está ativo
            while (isActive)
            {
                // Recebe o vetor de inicialização encriptado da chave simétrica do servidor
                ProtocolSI clientIVEncrypted = new ProtocolSI();
                GetDataFromClient(socketStream,clientIVEncrypted, ProtocolSICmdType.IV);

                byte[] clientIVDesencrypted = null;

                // Desencripta o vetor de inicialização encriptado utilizando a encriptação assimétrica e define a propriedade _clientSymmetriKeyIV do ClientThread
                DesencryptDataUsingAsymmetricEncryption(clientIVEncrypted.GetData(), ref clientIVDesencrypted);
                clientSymmetricKeyIV = clientIVDesencrypted;

                // Recebe a data encriptada da socket stream
                ProtocolSI newDataEncrypted = new ProtocolSI();
                GetDataFromClient(socketStream, newDataEncrypted);


                switch (newDataEncrypted.GetCmdType())
                {
                    case ProtocolSICmdType.SYM_CIPHER_DATA:

                        byte[] dataDesencrypted = null;

                        // Desincripta a data utilizando a encriptação simétrica com a chave simétrica do cliente e o vetor de inicialização
                        DesencryptDataUsingSymmetricEncryption(newDataEncrypted.GetData(), ref dataDesencrypted, clientSymmetricKey, clientSymmetricKeyIV);

                        string messageDesencrypted = Encoding.UTF8.GetString(dataDesencrypted);

                        // Escolhe a ação a fazer dependendo da mensagem recebida
                        ChooseActionDependingOnMessage(messageDesencrypted, ref clientID, socketStream, clientAsymmetricPublicKey);

                        break;

                    case ProtocolSICmdType.EOT:

                        // Fecha a socket stream e o tcp client do cliente
                        socketStream.Close();
                        tcpClient.Close();

                        // Remove o cliente da lista dos clientes
                        AllClients.RemoveClient(clientID);
                        
                        // Atualiza o estado do cliente para falso
                        isActive = false;
                        break;
                }

                
            }
        }


        /// <summary>
        /// Escolhe o que fazer dependendo da mensagem recebida.
        /// </summary>
        /// <param name="messageReceived">Mensagem recebida</param>
        /// <param name="clientID">O id do cliente</param>
        /// <param name="socketStream">A socket stream do cliente</param>
        /// <param name="clientAsymmetricPublicKey">A chave asimétrica pública do cliente</param>
        private static void ChooseActionDependingOnMessage(string messageReceived, ref string clientID, NetworkStream socketStream, string clientAsymmetricPublicKey)
        {
            try
            {
                Console.WriteLine($"Cliente({clientID}): {messageReceived}");

                // Divide a string pelo ;
                string[] parsedMessage = messageReceived.Split(';');

                // Remove o espaços do lado esquerdo e direito de todas as strings
                for (int i = 0; i < parsedMessage.Length; i++)
                {
                    parsedMessage[i] = parsedMessage[i].Trim('\0');
                }

                // Formata para uppercase no caso de se ter esquecido de enviar a mensagem corretamente
                parsedMessage[0] = parsedMessage[0].ToUpper();


                // Faz uma ação dependendo do primeiro elemento da parsedMessage, i.e, a ACTION
                switch (parsedMessage[0])
                {
                    // Caso a ACTION == ALLMESSAGES
                    // O formato da mensagem recebida será ALLMESSAGES
                    case "ALLMESSAGES":

                        // Obtém a lista com todas as mensagem guardadas no servidor
                        List<string[]> allSavedMessages = ServerController.GetAllSavedMessages();

                        string formatedMessages = "";

                        // Verifica se a lista de mensagens é null
                        if (allSavedMessages != null)
                            // Formata a lista para uma string que possa ser enviada para a socket stream do cliente
                            formatedMessages = ServerController.FormartSavedMessage(allSavedMessages);

                        // Envia a mensagem formatada com todas as mensagens para o cliente
                        HandleClient.SendMessageToClient(socketStream, $"ALLMESSAGES;{formatedMessages}", clientAsymmetricPublicKey);
                        
                        // Verifica se existiu mensagens antigas ou não
                        if(formatedMessages == "")
                            Console.WriteLine($"Cliente({clientID}) ----- Não têm mensagens por receber !");
                        else
                            Console.WriteLine($"Cliente({clientID}) ----- Irá receber todas as mensagens !");

                        break;


                    // Caso a ACTION == LOGIN
                    // O formato da mensagem recebida será LOGIN;username;password
                    case "LOGIN":

                        // Obtém os valores de username e password
                        string usernameLogin = parsedMessage[1];
                        string passwordLogin = parsedMessage[2];


                        // Verifica se o login é válido
                        bool isValid = ServerController.VerifyLogin(usernameLogin, passwordLogin, clientID, socketStream, clientAsymmetricPublicKey);

                        // Verifica se o login foi válido
                        if (isValid)
                        {
                            // Atualiza o id do cliente na lista de clientes com o username recebido
                            AllClients.UpdateClientID(clientID, usernameLogin);

                            // Atualiza o clientID do thread ClientThread com o username recebido
                            clientID = usernameLogin;
                        }

                        break;


                    // Caso a ACTION == REGISTER
                    // O formato da mensagem recebida será REGISTER;username;password
                    case "REGISTER":

                        // Obtém os valores de username, password e profileIcon
                        string usernameRegister = parsedMessage[1];
                        string passwordRegister = parsedMessage[2];
                        string profileIcon = parsedMessage[3];

                        byte[] passwordInBytesRegister = Encoding.UTF8.GetBytes(passwordRegister);

                        // Gere o salt a ser utilizado no hash da password
                        byte[] salt = ServerController.GenerateSalt(ServerController.SALTSIZE);

                        // Gere a password salteada
                        byte[] passwordSalted = ServerController.GenerateSaltedHash(passwordInBytesRegister, salt);

                        // Regista o novo cliente
                        ServerController.Register(usernameRegister, passwordSalted, salt, profileIcon, clientID, socketStream, clientAsymmetricPublicKey);

                        break;

                    // Caso a ACTION == MESSAGE
                    // O formato da mensagem recebida será MESSAGE;username;mensagem
                    case "MESSAGE":

                        // Obtém os valores do username e a mensagem
                        string clientUsername = parsedMessage[1];
                        string clientMessage = parsedMessage[2];

                        // Salva a mensagem no servidor
                        ServerController.SaveMessageInServer(clientUsername, clientMessage);

                        // Obtém o profileIcon do cliente
                        string clientProfileIcon = ServerController.GetClientProfileIcon(clientUsername);

                        // Formata a mensagem a ser enviada para todos os clientes
                        string fullMessage = $"{clientUsername};{clientMessage};{clientProfileIcon}";

                        //Enviar a mensagem para todos
                        AllClients.SendMessagesToEveryone(fullMessage);

                        break;
                }

            }
            catch (Exception ex)
            {
                // Envia uma mensagem ao cliente com o erro
                HandleClient.SendMessageToClient(socketStream, "A mensagem enviada para o servidor está mal formada", clientAsymmetricPublicKey);
                
                Console.WriteLine($"Erro no cliente({clientID}): {ex.Message}");
            }


        }


        /// <summary>
        /// Envia uma mensagem para o cliente
        /// </summary>
        /// <param name="socketStream">Socket stream do cliente</param>
        /// <param name="message">Mensagem para enviar</param>
        /// <param name="clientAsymmetricPublicKey">A chave assimétrica pública do cliente</param>
        public static void SendMessageToClient(NetworkStream socketStream,string message, string clientAsymmetricPublicKey)
        {
            // Obtém os bytes da mensagem
            byte[] messageInBytes = Encoding.UTF8.GetBytes(message);
            byte[] messageEncrypted = null;

            // Gere um novo vetor de inicialização na encriptação simétrica do servidor
            Server.serverController.MySymmetricEncryption.GenerateIV();

            // Obtém o vetor de inicialização da chave simétrica do servidor
            byte[] mySymmetricKeyIV = Server.serverController.MySymmetricEncryption.IV;
            byte[] mySymmetricKeyIVEncrypted = null;

            // Encripta o vetor de inicialização utilizando a chave assimétrica pública do cliente
            EncryptDataWithAsymmetricEncryption(mySymmetricKeyIV, ref mySymmetricKeyIVEncrypted, clientAsymmetricPublicKey);

            // Envia o vetor de inicialização encriptado para o cliente
            SendDataToClient(socketStream,mySymmetricKeyIVEncrypted, ProtocolSICmdType.IV);

            // Encripta a data com encriptação simétrica
            EncryptDataWithSymmetricEncryption(messageInBytes, ref messageEncrypted);


            // Envia a data encriptada para o cliente
            SendDataToClient(socketStream,messageEncrypted, ProtocolSICmdType.SYM_CIPHER_DATA);
        }


        /// <summary>
        /// Envia data para o cliente
        /// </summary>
        /// <param name="socketStream">Socket stream do cliente</param>
        /// <param name="dataToSend">A string da data para enviar</param>
        /// <param name="typeOfPacket">O tipo de packet pretendido</param>
        private static void SendDataToClient(NetworkStream socketStream, byte[] dataToSend, ProtocolSICmdType typeOfPacket)
        {
            try
            {

                ProtocolSI protocolSI = new ProtocolSI();

                // Cria o pacote para enviar
                byte[] packet = protocolSI.Make(typeOfPacket, dataToSend);

                // Envia o pacote para a socket stream do cliente
                socketStream.Write(packet, 0, packet.Length);
                socketStream.Flush();

                //GetACK(socketStream);

                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }




        /// <summary>
        /// Obtém data do socket stream entre o cliente e o server
        /// </summary>
        /// <param name="socketStream">Socket stream do cliente</param>
        /// <param name="output">Output para onde copiar os bytes da data lida</param>
        /// <param name="expectedTypeOfPacket">O tipo de pacote esperado, se omitido então não verifica o tipo de pacote recebido</param>
        private static void GetDataFromClient(NetworkStream socketStream,ProtocolSI output, ProtocolSICmdType expectedTypeOfPacket = ProtocolSICmdType.DATA)
        {
            // Inicia o trigger para saber se recebeu a data
            bool gotData = false;

            try
            {
                // Inicia o loop que só acaba quando tiver data
                while (!gotData)
                {


                    // Lista dos bytes inteiros
                    List<byte[]> entireByte = new List<byte[]>();

                    // Verifica se existe data na socket stream
                    while (!socketStream.DataAvailable)
                    {
                        Thread.Sleep(Server.serverController.Cooldown);
                    }

                    // Lê até não haver mais data disponível
                    do
                    {
                        ProtocolSI protocolSI = new ProtocolSI();

                        // Lê a data da socket stream e guarda o número de bytes lidos
                        socketStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                        // Adiciona parte da data lida á lista dos bytes inteiros
                        entireByte.Add(protocolSI.GetBuffer());

                    } while (socketStream.DataAvailable);

                    // Muda o trigger para acabar o loop
                    gotData = true;

                    // Copiar a lista com os bytes inteiros para um single byte
                    // https://social.msdn.microsoft.com/Forums/vstudio/en-US/199dc57f-8c24-4e1f-8492-b1c5566dec09/convert-list-array-to-single-byte-array?forum=csharpgeneral
                    byte[] entireBytesInBytes = entireByte.SelectMany(el => el).ToArray();

                    // Copia o byte para o buffer do protocolSI Buffer
                    ProtocolSI protocolSIEntire = new ProtocolSI();
                    protocolSIEntire.SetBuffer(entireBytesInBytes);

                    // Verifica se a data esperada é correta com a data recebida e se a data esperada é diferente da data default
                    if ((protocolSIEntire.GetCmdType() != expectedTypeOfPacket) && (expectedTypeOfPacket != ProtocolSICmdType.DATA))
                        throw new Exception("O servidor recebeu data do client no entanto recebeu com o tipo de pacote não pretendido");


                    // Envia a data real para o output
                    output.SetBuffer(protocolSIEntire.GetBuffer());


                    //SendACK(socketStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }


        /*
        /// <summary>
        /// Envia o pacote de confirmação para o cliente
        /// </summary>
        /// <param name="socketStream">Socket stream do cliente</param>
        private static void SendACK(NetworkStream socketStream)
        {
            try
            {
                ProtocolSI ackProtocol = new ProtocolSI();

                // Faz o pacote de confirmação 
                byte[] ackPacket = ackProtocol.Make(ProtocolSICmdType.ACK);

                // Escreve o pacote de confirmação na socket stream
                socketStream.Write(ackPacket, 0, ackPacket.Length);
                socketStream.Flush();

                //Console.WriteLine("Sent ACK");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Recebe o pacote de confirmação do cliente
        /// </summary>
        /// <param name="socketStream">Socket stream do cliente</param>
        private static void GetACK(NetworkStream socketStream)
        {
            // Trigger para saber se já recebeu o pacote de confirmação
            bool gotACK = false;

            try
            {
                while (!gotACK)
                {
                    //Console.WriteLine("Waiting for ACK");

                    // Verifica se existe data na socket stream antes de ler
                    while (!socketStream.DataAvailable)
                    {
                        //Console.WriteLine("Waiting for ACK");
                        Thread.Sleep(Server.serverController.Cooldown);
                    }

                    ProtocolSI protocolReceived = new ProtocolSI();

                    // Obtém o tamanho de um pacote de confirmação
                    byte[] ackLength = protocolReceived.Make(ProtocolSICmdType.ACK);

                    // Le data na socket stream
                    socketStream.Read(protocolReceived.Buffer, 0, ackLength.Length);

                    // Verifica se o tipo é o correto
                    if (protocolReceived.GetCmdType() == ProtocolSICmdType.ACK)
                    {
                        // Muda o trigger para saber que recebeu o pacote de confirmação
                        gotACK = true;

                        //Console.WriteLine("Got ack!");
                    }
                    else
                    {
                        Console.WriteLine($"Recebi packet errado do tipo {protocolReceived.GetCmdType()}!");
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
        */


        /// <summary>
        /// Encripta a data utilizando a encriptação assimétrica, com a chave assimétrica pública do cliente
        /// </summary>
        /// <param name="dataToEncrypt">Data para encriptar</param>
        /// <param name="output">A referência do output para onde copiar os bytes da data encriptada</param>
        /// <param name="clientAsymmetricPublicKey">A chave assimétrica pública do cliente</param>
        private static void EncryptDataWithAsymmetricEncryption(byte[] dataToEncrypt, ref byte[] output, string clientAsymmetricPublicKey)
        {
            try
            {
                // Verifica se a chave assimétrica pública do cliente é nula ou empty
                if (String.IsNullOrEmpty(clientAsymmetricPublicKey)) throw new Exception("O servidor precisa da asymmetric public key do client!");

                // Inicia a encriptação assimétrica
                using (RSACryptoServiceProvider asymmetricEncryption = new RSACryptoServiceProvider())
                {
                    // Importa a chave assimétrica pública do cliente
                    asymmetricEncryption.FromXmlString(clientAsymmetricPublicKey);


                    // Encripta a data
                    byte[] encryptedData = asymmetricEncryption.Encrypt(dataToEncrypt, false);

                    // Define o tamanho do output com o correto
                    output = new byte[encryptedData.Length];

                    // Copia a data para o output pretendido
                    output = encryptedData;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {Environment.NewLine + ex.Message}");
            }
        }


        /// <summary>
        /// Encripta a data utilizando a encriptação simétrica, com a chave simétrica do servidor
        /// </summary>
        /// <param name="dataToEncrypt">Data para encriptar</param>
        /// <param name="output">A referência do output para onde copiar os bytes da data encriptada</param>
        private static void EncryptDataWithSymmetricEncryption(byte[] dataToEncrypt, ref byte[] output)
        {
            try
            {

                // Inicia a memory stream
                using (MemoryStream ms = new MemoryStream())
                {
                    // Inicia a crypto stream com a encriptação simétrica
                    using (CryptoStream cryptoStream = new CryptoStream(ms, Server.serverController.MySymmetricEncryption.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        // Escreve para a crypto stream a data
                        cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    }

                    // Define o tamanho do output com o correto
                    output = new byte[ms.ToArray().Length];

                    // Copia a data encriptada para o output
                    output = ms.ToArray();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {Environment.NewLine + ex.Message}");
            }
        }




        /// <summary>
        /// Desencripta a data utilizando a encriptação assimétrica, com a chave assimétrica privada do servidor
        /// </summary>
        /// <param name="dataToDecrypt">Data para desencriptar</param>
        /// <param name="output">A referência do output para onde copiar os bytes da data desencriptada</param>
        private static void DesencryptDataUsingAsymmetricEncryption(byte[] dataToDecrypt, ref byte[] output)
        {
            try
            {
                // Desencripta a data utilizando a encriptação assimétrica do servidor
                byte[] dataDecrypted = Server.serverController.MyAsymmetricEncryption.Decrypt(dataToDecrypt, false);

                // Define o tamanho do output com o correto
                output = new byte[dataDecrypted.Length];

                // Copia os bytes da data desencriptada para o output
                output = dataDecrypted;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {Environment.NewLine + ex.Message}");
            }
        }



        /// <summary>
        /// Desencripta a data utilizando a encriptação simétrica, com a chave simétrica do cliente
        /// </summary>
        /// <param name="dataToDecrypt">Data para desencriptar</param>
        /// <param name="output">A referência do output para onde copiar os bytes da data desencriptada</param>
        /// <param name="clientSymmetricKey">A chave simétrica do cliente</param>
        /// <param name="clientSymmetricKeyIV">O vetor de inicialização da chave simétrica do cliente</param>
        private static void DesencryptDataUsingSymmetricEncryption(byte[] dataToDecrypt, ref byte[] output, byte[] clientSymmetricKey, byte[] clientSymmetricKeyIV)
        {
            try
            {

                // Verifica se tenho a Key e o IV da chave simétrica do cliente não são nulos
                if (clientSymmetricKey is null || clientSymmetricKeyIV is null) throw new Exception("O cliente precisa da Key e o IV da chave simétrica do servidor");

                // Inicia o memory stream com a data para desencriptar
                using (MemoryStream ms = new MemoryStream(dataToDecrypt))
                {
                    // Inicia a encriptação simétrica
                    using (Aes clientSymmetricEncryption = Aes.Create())
                    {
                        // Importa a Key e o IV da chave simétrica do cliente para a encriptação simétrica
                        clientSymmetricEncryption.Key = clientSymmetricKey;
                        clientSymmetricEncryption.IV = clientSymmetricKeyIV;

                        // Inicia a crypto stream com a encriptação simétrica
                        using (CryptoStream cryptoStream = new CryptoStream(ms, clientSymmetricEncryption.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            // Define o tamanho do output com o correto
                            output = new byte[dataToDecrypt.Length];

                            // Le a data desencriptada da crypto stream para o output
                            cryptoStream.Read(output, 0, dataToDecrypt.Length);
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {Environment.NewLine + ex.Message}");
            }
        }


        
    } 
}
