namespace Shaykhullin.Network.Core
{
	public interface IChannelConfig
	{
		ISerializerBuilder UseSerializer<TSerializer>()
			where TSerializer : ISerializer;

		IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class;
	}
}