using System;
using System.Collections.Generic;

namespace Network.Core
{
	public class EventCollection
	{
		private readonly Dictionary<int, Type> events = new Dictionary<int, Type>();

		public void Add(Type @event)
		{
			if (!events.ContainsValue(@event))
			{
				events.Add(GetHash(@event.Name), @event);
			}
		}
		
		public Type GetEvent(int id)
		{
			return events[id];
		}

		public int GetEvent(Type @event)
		{
			foreach (var item in events)
			{
				if (item.Value == @event)
				{
					return item.Key;
				}
			}

			throw new InvalidOperationException();
		}
		
		private static unsafe int GetHash(string name)
		{
			fixed (char* str = name)
			{
				var chPtr = str;
				var num = 352654597;
				var num2 = num;
				var numPtr = (int*)chPtr;
				for (var i = name.Length; i > 0; i -= 4)
				{
					num = (num << 5) + num + (num >> 27) ^ numPtr[0];
					if (i <= 2)
					{
						break;
					}
					num2 = (num2 << 5) + num2 + (num2 >> 27) ^ numPtr[1];
					numPtr += 2;
				}
				return num + num2 * 1566083941;
			}
		}
	}
}