namespace Shaykhullin.Network.Core
{
	public interface IConnectionConfig
	{
		IConnectionHandlerConfig<TEvent> When<TEvent>()
			where TEvent : IConnectionEvent<object>;
	}
}