using Network.Core;

namespace Network
{
	public class ClientConfig : IClientConfig
	{
		public IClient Create(string host, int port)
		{
			return new Client();
		}
	}
}
