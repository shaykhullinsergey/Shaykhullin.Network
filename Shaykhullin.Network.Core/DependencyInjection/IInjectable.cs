namespace Network.Core
{
	public interface IInjectable
	{
		IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class;
	}
}
