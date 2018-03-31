using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
{
	public class ServerConfig : NodeConfig, IServerConfig
	{
		public IChannelConfig Channel<TChannel>() 
			where TChannel : IChannel
		{
			return new ChannelConfig();
		}

		public IServer Create(string host, int port)
		{
			return new Server();
		}
	}
}