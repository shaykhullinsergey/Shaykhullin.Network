namespace Shaykhullin.Network
{
	public interface IConnectionConfig
	{
		IConnectionHandlerConfig<TEvent> When<TEvent>()
			where TEvent : IConnectionEvent<object>;
	}
}