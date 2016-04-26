using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Communication.IP
{
    public class Server
    {
        private EndPoint _remote;
        private Socket _winSocket;

        private bool _listening;

        /// <summary>
        /// ctor
        /// </summary>
        public Server()
        {
            var serverEndPoint = new IPEndPoint(IPAddress.Any, 7055);
            _winSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _winSocket.Bind(serverEndPoint);

            Console.Write("Waiting for client");
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            _remote = sender;
        }


        /// <summary>
        /// is called every time the RemoteSocket awaits a message
        /// </summary>
        public void Receive()
        {
            _listening = true;
            while (_listening)
            {
                Byte[] data = new byte[128];
                int recv = _winSocket.ReceiveFrom(data, ref _remote);
                if (recv > -12)
                {
                    Console.WriteLine("Message received from {0}:", _remote.ToString());
                    Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
                    ProceedMessage(Int16.Parse(Encoding.ASCII.GetString(data, 0, recv)));
                    _listening = false;
                }
                Thread.Sleep(100);
                Console.WriteLine("Another round nothing");
            }
        }

        private void ProceedMessage(int message)
        {
            switch ((Messages)message)
            {
                case Messages.Shutdown:
                        Actions.Shutdown();
                    break;
                case Messages.LogOff:
                    Actions.LogOff();
                    break;
                default:
                    Console.WriteLine("Message '{0}' not recognized",message);
                    break;
            }
        }
    }
}
