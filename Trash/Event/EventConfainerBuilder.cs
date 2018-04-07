using System;
using System.Collections.Generic;

namespace Network.Core
{
	internal class EventConfainerBuilder : IEventContainerBuilder
	{
		private Dictionary<int, Type> events = new Dictionary<int, Type>();
		private Dictionary<Type, List<Type>> handlers = new Dictionary<Type, List<Type>>();

		public IUseBuilder<TEvent> When<TEvent>()
			where TEvent : IEvent<object>
		{
			return new UseBuilder<TEvent>(events, handlers);
		}

		public IEventContainer Build()
		{
			return new EventContainer(events, handlers);
		}
	}
}
