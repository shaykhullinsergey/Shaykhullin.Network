namespace Shaykhullin.Network.Core
{
	public interface IImplementedByBuilder
	{
		void As<TLifecycle>()
			where TLifecycle : ILifecycle;
	}
}