using System.Net;
using System.Net.Sockets;

namespace Network.Core
{
	internal class Client : IClient
  {
    public IConnection Connect()
    {
			string host = "127.0.0.1";
			int port = 4000;

			var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
			socket.Connect(new IPEndPoint(IPAddress.Parse(host), port));

			return new Connection(socket);
    }
  }
}
