namespace Shaykhullin.Network.Core
{
	public interface IConfigEvent<out TContext>
	{
		TContext Context { get; }
	}
}