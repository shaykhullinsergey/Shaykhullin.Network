namespace Shaykhullin.Network.Core
{
	public interface IEvent<out TContext>
	{
		TContext Context { get; }
	}
}