using System;
using System.Collections.Generic;
using DependencyInjection;

namespace Network.Core
{
	internal class HandlerBuilder<TEvent> : IHandlerBuilder<TEvent>
		where TEvent : class, IEvent<object>
	{
		private readonly IContainerConfig config;

		public HandlerBuilder(IContainerConfig config)
		{
			this.config = config;
		}

		public void Use<THandler>() where THandler 
			: class, IHandler<TEvent>
		{
			config.Register<TEvent>();
			config.Register<THandler>();

			var container = config.Container;
			
			container.Resolve<EventCollection>()
				.Add<TEvent>();
			
			container.Resolve<HandlerCollection>()
				.Add<TEvent, THandler>();
		}
	}
}
