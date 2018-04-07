using System;
using System.Collections.Generic;

namespace Network.Core
{
	public class HandlerCollection
	{
		private readonly Dictionary<Type, List<Type>> handlers = new Dictionary<Type, List<Type>>();
		
		public void Add(Type @event, Type handler)
		{
			if (handlers.TryGetValue(@event, out var list))
			{
				list.Add(handler);
			}
			else
			{
				handlers.Add(@event, new List<Type> { handler });
			}
		}

		public IList<Type> GetHandlers(Type @event)
		{
			return handlers[@event];
		}
	}
}