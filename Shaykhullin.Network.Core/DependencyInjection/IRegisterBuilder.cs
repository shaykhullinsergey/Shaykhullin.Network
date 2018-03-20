namespace Shaykhullin.Network.Core
{
	public interface IRegisterBuilder<in TRegister>
		where TRegister : class
	{
		IImplementedByBuilder ImplementedBy<TImplemented>()
			where TImplemented : class, TRegister;
	}
}