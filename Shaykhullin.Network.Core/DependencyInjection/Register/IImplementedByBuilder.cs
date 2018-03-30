namespace Shaykhullin.Network.Core
{
	public interface IImplementedByBuilder
	{
		void As<TLifetime>()
			where TLifetime : ILifecycle;
	}
}