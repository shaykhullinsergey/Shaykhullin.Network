namespace Shaykhullin.Network.Core
{
	public interface IServerConfig  : IConfigurable, IInjectable, IHandlerable
	{
		IChannelConfig Channel<TChannel>()
			where TChannel : IChannel;

		IServer Create(string host, int port);
	}
}