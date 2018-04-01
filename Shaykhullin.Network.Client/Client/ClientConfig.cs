using Network.Core;

namespace Network
{
	public sealed class ClientConfig : NodeConfig, IClientConfig
	{
		public IClient Create(string host, int port)
		{
			return new Client();
		}
	}
}