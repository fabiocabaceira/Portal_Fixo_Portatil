using Server.HelpingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class AllClients
    {
        // Uma lista com todos os clientes
        private static List<EachClient> allClients;

        // Quantidade de clientes conectados ao servidor
        private static int clientsCounter;

        internal int ClientsCounter { get { return clientsCounter; } }

        public AllClients()
        {
            allClients = new List<EachClient>();
        }

        /// <summary>
        /// Adiciona um novo cliente à lista de clientes
        /// </summary>
        /// <param name="newClient">O cliente a adicionar</param>
        public void AddClient(EachClient newClient)
        {
            // Adicionar o cliente à lista
            allClients.Add(newClient);
            clientsCounter++;
        }

        /// <summary>
        /// Remove um cliente da lista de clientes
        /// </summary>
        /// <param name="clientID"></param>
        public static void RemoveClient(string clientID)
        {
            // Obtém o index do cliente
            int index = GetClient(clientID);

            // Remove o cliente da lista
            allClients.RemoveAt(index);
            clientsCounter--;
        }

        /// <summary>
        /// Atualiza o id do cliente na lista de clientes
        /// </summary>
        /// <param name="oldClientID">O id antigo do cliente</param>
        /// <param name="newClientID">O novo id do ciente</param>
        public static void UpdateClientID(string oldClientID, string newClientID)
        {
            // Obtém o index do cliente
            int index = GetClient(oldClientID);

            // Atualiza o id do cliente com o novo
            ((EachClient)allClients[index]).Id = newClientID;
        }

        /// <summary>
        /// Retorn o index do cliente
        /// </summary>
        /// <param name="clientID">O id do cliente a pesquisar</param>
        /// <returns></returns>
        internal static int GetClient(string clientID)
        {
            int foundClientIndex = -1;

            // Dá um loop por todos os clientes na lista
            foreach (EachClient client in allClients)
            {
                // Se o id do cliente guardado é igual ao o id a pesquisar então atualiza o foundClientIndex e dá break do loop
                if (client.Id == clientID)
                {
                    foundClientIndex = allClients.IndexOf(client);
                    break;
                }
            }

            return foundClientIndex;
        }

        /// <summary>
        /// Envia uma mensagem a todos os clientes na lista
        /// </summary>
        /// <param name="message">A mensagem a enviar</param>
        public static void SendMessagesToEveryone(string message)
        {
            try
            {
                // Dá um loop por todos os clientes na lista
                foreach(EachClient eachClient in allClients)
                {
                    Console.WriteLine($"Servidor enviou mensagem para o cliente({eachClient.Id}): {message}");

                    // Envia a mensagem ao cliente
                    HandleClient.SendMessageToClient(eachClient.SocketStream, $"MESSAGE;{message}", eachClient.ClientAsymmetricPublicKey);
                }

            } catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
