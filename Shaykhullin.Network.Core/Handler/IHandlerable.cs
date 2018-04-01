namespace Network.Core
{
	public interface IHandlerable
	{
		IConfigBuilder<TEvent> When<TEvent>()
			where TEvent : IHandlerEvent<object>;
	}
}
