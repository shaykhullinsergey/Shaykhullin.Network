using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Network.Core
{
	internal class Server : IServer
	{
		public void Run()
		{
			const string host = "127.0.0.1";
			const int port = 4000;
			
			var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
			socket.Bind(new IPEndPoint(IPAddress.Parse(host), port));
			socket.Listen(10);

			while (true)
			{
				var client = socket.Accept();
				Task.Run(() => new Connection(client));
			}
		}
	}
}
