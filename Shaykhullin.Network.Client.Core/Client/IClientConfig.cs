namespace Shaykhullin.Network.Core
{
	public interface IClientConfig
	{
		ISerializerBuilder UseSerializer<TSerializer>()
			where TSerializer : ISerializer;

		IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class;
		
		IHandlerConfig<TEvent> When<TEvent>()
			where TEvent : IEvent<object>;
		
		IClient Create(string host, int port);
	}
}