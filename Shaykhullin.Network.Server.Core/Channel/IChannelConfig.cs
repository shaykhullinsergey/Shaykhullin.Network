namespace Shaykhullin.Network.Core
{
	public interface IChannelConfig : ICompressionBuilder
	{
		ICompressionBuilder UseSerializer<TSerializer>()
			where TSerializer : ISerializer;

		IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class;
	}
}