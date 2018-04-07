namespace Network.Core
{
	public interface IEventContainerBuilder
	{
		IUseBuilder<TEvent> When<TEvent>()
			where TEvent : IEvent<object>;
	}
}
