using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Communication.IP
{
    class Client
    {
        private Socket RemoteSocket;

        public IPEndPoint RemoteEndPoint;

        public Client(IPAddress remoteEntpoint)
        {
            RemoteEndPoint = new IPEndPoint(remoteEntpoint, 7055);
            RemoteSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }
        
        public void Send(Messages message)
        {
            var data = Encoding.ASCII.GetBytes(message.ToString());
            RemoteSocket.SendTo(data, data.Length, SocketFlags.None, RemoteEndPoint);Console.WriteLine("Sending data to {0}", RemoteEndPoint.Address);
        }
    }
}
