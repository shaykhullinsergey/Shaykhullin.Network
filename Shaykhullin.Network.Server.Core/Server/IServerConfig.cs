namespace Shaykhullin.Network.Core
{
	public interface IServerConfig  : INodeConfig
	{
		IChannelConfig Channel<TChannel>()
			where TChannel : IChannel;

		IServer Create(string host, int port);
	}
}