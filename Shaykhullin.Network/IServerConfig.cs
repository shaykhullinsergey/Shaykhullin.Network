namespace Shaykhullin.Network
{
	public interface IServer
	{
		void Run();
	}
	
	public interface IServerConfig : ISerializerBuilder
	{
		ISerializerBuilder UseSerializer<TSerializer>()
			where TSerializer : ISerializer;

		IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class;

		IChannelConfig Channel<TChannel>()
			where TChannel : IChannel;

		IHandlerConfig<TPayload> When<TEvent, TPayload>()
			where TEvent : IEvent<TPayload>;

		IServer Create(string host, int port);
	}
}