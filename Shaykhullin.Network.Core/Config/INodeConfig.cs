namespace Shaykhullin.Network.Core
{
	public interface INodeConfig : ICompressionBuilder
	{
		IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class;

		ICompressionBuilder UseSerializer<TSerializer>()
			where TSerializer : ISerializer;
	}
}
