namespace Shaykhullin.Network.Core
{
	public interface IServerConfig : ISerializerBuilder
	{
		ISerializerBuilder UseSerializer<TSerializer>()
			where TSerializer : ISerializer;

		IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class;

		IChannelConfig Channel<TChannel>()
			where TChannel : IChannel;

		IHandlerConfig<TEvent> When<TEvent>()
			where TEvent : IEvent<object>;

		IServer Create(string host, int port);
	}
}