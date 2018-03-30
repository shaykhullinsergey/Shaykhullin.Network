namespace Shaykhullin.Network.Core
{
	internal class ConnectionConfig : IConnectionConfig
	{
		public IHandlerBuilder<TEvent> When<TEvent>() 
			where TEvent : IEvent<object>
		{
			return new HandlerBuilder<TEvent>();
		}
	}
}
