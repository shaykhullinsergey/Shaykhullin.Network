using System;
using System.Collections.Generic;

namespace Network.Core
{
	internal class UseBuilder<TEvent> : IUseBuilder<TEvent>
		where TEvent : IEvent<object>
	{
		private Dictionary<int, Type> events;
		private Dictionary<Type, List<Type>> handlers;

		public UseBuilder(Dictionary<int, Type> events, Dictionary<Type, List<Type>> handlers)
		{
			this.events = events;
			this.handlers = handlers;
		}

		public void Use<THandler>() where THandler 
			: IHandler<TEvent>
		{
			Type @event = typeof(TEvent);
			Type handler = typeof(THandler);

			if (!events.ContainsValue(@event))
			{
				events.Add(GetHash(@event.Name), @event);
			}

			if (handlers.TryGetValue(@event, out var list))
			{
				list.Add(handler);
			}
			else
			{
				handlers.Add(@event, new List<Type> { handler });
			}
		}

		private unsafe int GetHash(string name)
		{
			fixed (char* str = name)
			{
				char* chPtr = str;
				int num = 352654597;
				int num2 = num;
				int* numPtr = (int*)chPtr;
				for (int i = name.Length; i > 0; i -= 4)
				{
					num = (((num << 5) + num) + (num >> 27)) ^ numPtr[0];
					if (i <= 2)
					{
						break;
					}
					num2 = (((num2 << 5) + num2) + (num2 >> 27)) ^ numPtr[1];
					numPtr += 2;
				}
				return (num + (num2 * 1566083941));
			}
		}
	}
}
