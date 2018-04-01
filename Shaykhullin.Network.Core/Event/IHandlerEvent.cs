namespace Network.Core
{
	public interface IHandlerEvent<out TContext>
	{
		TContext Context { get; }
	}
}