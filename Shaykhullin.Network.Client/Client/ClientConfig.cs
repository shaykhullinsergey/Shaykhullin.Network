using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
{
	public class ClientConfig : NodeConfig, IClientConfig
	{
		public IClient Create(string host, int port)
		{
			return new Client();
		}
	}
}