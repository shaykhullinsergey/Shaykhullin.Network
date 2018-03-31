namespace Shaykhullin.Network.Core
{
	public interface IChannelConfig 
	{
		IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class;
	}
}