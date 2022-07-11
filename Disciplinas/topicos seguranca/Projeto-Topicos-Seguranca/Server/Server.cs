using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {

        // O ip do server e a porta
        private static IPAddress serverIP = IPAddress.Parse("127.0.0.1");
        private static int serverPort = 2323;

        public static ServerController serverController = new ServerController(serverIP, serverPort);

        static void Main(string[] args)
        {
            // Inicia o servidor
            serverController.Start();
        }
    }
}
