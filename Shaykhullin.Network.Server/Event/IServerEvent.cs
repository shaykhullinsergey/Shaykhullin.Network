namespace Shaykhullin.Network
{
	public interface IServerEvent<out TContext>
	{
		TContext Context { get; }
	}
}