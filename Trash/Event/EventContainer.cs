using System;
using System.Collections.Generic;

namespace Network.Core
{
	internal class EventContainer : IEventContainer
	{
		private Dictionary<int, Type> events;
		private Dictionary<Type, List<Type>> handlers;

		public EventContainer(Dictionary<int, Type> events, Dictionary<Type, List<Type>> handlers)
		{
			this.events = events;
			this.handlers = handlers;
		}

		public Type GetEvent(int id)
		{
			return events[id];
		}

		public int GetEvent(Type @event)
		{
			foreach (var item in events)
			{
				if(item.Value == @event)
				{
					return item.Key;
				}
			}

			throw new InvalidOperationException();
		}

		public IEnumerable<Type> GetHandlers(Type @event)
		{
			return handlers[@event];
		}
	}
}