namespace Shaykhullin.Network
{
	public interface IServerConfig : ISerializerBuilder
	{
		ISerializerBuilder UseSerializer<TSerializer>()
			where TSerializer : ISerializer;

		IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class;

		IChannelConfig Channel<TChannel>()
			where TChannel : IChannel;

		IServerHandlerConfig<TEvent> When<TEvent>()
			where TEvent : IServerEvent<object>;

		IServerNode Create(string host, int port);
	}
}