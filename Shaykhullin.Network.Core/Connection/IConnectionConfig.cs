namespace Network.Core
{
	public interface IConnectionConfig
	{
		IHandlerBuilder<TEvent> When<TEvent>()
			where TEvent : IEvent<object>;
	}
}