using DependencyInjection;

namespace Network.Core
{
	internal class EventBuilder : IEventBuilder
	{
		private readonly IContainerConfig config;

		public EventBuilder(IContainerConfig config)
		{
			config.Register<EventCollection>()
				.ImplementedBy<EventCollection>()
				.As<Singleton>();
			
			config.Register<HandlerCollection>()
				.ImplementedBy<HandlerCollection>()
				.As<Singleton>();
			
			config.Register<IEventHolder>()
				.ImplementedBy<EventHolder>()
				.As<Singleton>();
			
			this.config = config;
		}
		
		public IHandlerBuilder<TEvent> When<TEvent>()
			where TEvent : class, IEvent<object>
		{
			return new HandlerBuilder<TEvent>(config);
		}
	}
}
