using Network.Core;

namespace Network
{
	public class ServerConfig : IServerConfig
	{
		public IServer Create(string host, int port)
		{
			return new Server();
		}
	}
}