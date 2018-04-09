using System;
using System.Collections.Generic;

namespace Network.Core
{
	public class HandlerCollection
	{
		private readonly Dictionary<Type, List<Type>> handlers = new Dictionary<Type, List<Type>>();
		
		public void Add<TEvent, THandler>()
			where TEvent : IEvent<object>
			where THandler : IHandler<TEvent>
		{
			var @event = typeof(TEvent);
			var handler = typeof(THandler);
			
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
			if(!handlers.TryGetValue(@event, out var list))
			{
				list = new List<Type>();
				handlers.Add(@event, list);
			}

			return list;
		}
	}
}