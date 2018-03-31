namespace Shaykhullin.Network.Core
{
	public interface IServerConfig 
		: IConfigurable, 
			IInjectable
	{
		IChannelConfig Channel<TChannel>()
			where TChannel : IChannel;

		IServer Create(string host, int port);
	}
}