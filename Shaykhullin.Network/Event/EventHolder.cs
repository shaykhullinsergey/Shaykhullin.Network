using System;
using System.Collections.Generic;
using DependencyInjection;

namespace Network.Core
{
	internal class EventHolder : IEventHolder
	{
		private readonly IContainer container;

		public EventHolder(IContainer container)
		{
			this.container = container;
		}

		public Type GetEvent(int id)
		{
			return container
				.Resolve<EventCollection>()
				.GetEvent(id);
		}

		public int GetEvent(Type @event)
		{
			return container
				.Resolve<EventCollection>()
				.GetEvent(@event);
		}

		public IList<Type> GetHandlers(IPayload payload)
		{
			return container.Resolve<HandlerCollection>()
				.GetHandlers(payload.Event);
		}
	}
}