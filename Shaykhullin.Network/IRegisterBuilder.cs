namespace Shaykhullin.Network
{
	public interface IRegisterBuilder<in TRegister>
		where TRegister : class
	{
		IImplementedByBuilder ImplementedBy<TImplemented>()
			where TImplemented : class, TRegister;
	}
	
	public interface IImplementedByBuilder
	{
		void As<TLifetime>()
			where TLifetime : ILifetime;
	}
	
	public interface ILifetime
	{
	}
	
	public class Singleton : ILifetime
	{
	}
}