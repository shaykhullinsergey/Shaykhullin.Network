namespace Shaykhullin.Network.Core
{
	public interface IClientConfig
	{
		ISerializerBuilder UseSerializer<TSerializer>()
			where TSerializer : ISerializer;

		IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class;
		
		IConfigBuilder<TEvent> When<TEvent>()
			where TEvent : IHandlerEvent<object>;
		
		IClient Create(string host, int port);
	}
}