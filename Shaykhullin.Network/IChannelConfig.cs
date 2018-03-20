namespace Shaykhullin.Network
{
	public interface IChannelConfig
	{
		ISerializerBuilder UseSerializer<TSerializer>()
			where TSerializer : ISerializer;

		IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class;
	}
	
	public interface IChannel
	{
	}
}