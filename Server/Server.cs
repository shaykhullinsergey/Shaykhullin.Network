using Network.Core;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Network.Core
{
	public class Server
	{
		public void Run(string host, int port)
		{
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
