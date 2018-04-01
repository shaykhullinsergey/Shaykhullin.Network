namespace Network.Core
{
	public interface IRegisterBuilder<in TRegister> : IImplementedByBuilder
		where TRegister : class
	{
		IImplementedByBuilder ImplementedBy<TImplemented>()
			where TImplemented : class, TRegister;
	}
}