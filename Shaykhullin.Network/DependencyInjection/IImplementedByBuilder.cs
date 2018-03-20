namespace Shaykhullin.Network
{
	public interface IImplementedByBuilder
	{
		void As<TLifetime>()
			where TLifetime : ILifetime;
	}
}