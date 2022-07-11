using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class EachClient
    {
        // O id de um cliente
        private string _id;

        // A socket stream de um cliente
        private NetworkStream _socketStream;

        // A chave assimétrica pública de um cliente
        private string _clientAsymmetricPublicKey;

        public NetworkStream SocketStream { get { return _socketStream; } }
        public string Id { get { return _id; } set { _id = value; } }
        public string ClientAsymmetricPublicKey { get { return _clientAsymmetricPublicKey; } set { _clientAsymmetricPublicKey = value; } }

        public EachClient(NetworkStream socketStream)
        {
            // Configura a socket stream com a recebida no argumento
            _socketStream = socketStream;
        }
    }
}
