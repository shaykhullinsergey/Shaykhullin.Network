namespace Shaykhullin.Network.Core
{
	public interface IServerConfig : ICompressionBuilder
	{
		ICompressionBuilder UseSerializer<TSerializer>()
			where TSerializer : ISerializer;

		IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class;

		IChannelConfig Channel<TChannel>()
			where TChannel : IChannel;

		IConfigBuilder<TEvent> When<TEvent>()
			where TEvent : IHandlerEvent<object>;

		IServer Create(string host, int port);
	}
}