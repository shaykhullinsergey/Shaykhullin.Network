using System;
using System.Collections.Generic;

namespace Network.Core
{
	public class Container
	{
		public Type GetEvent(int id)
		{
			return null;
		}

		public int GetEvent(Type @event)
		{
			return 0;
		}

		public IEnumerable<Type> GetHandlers(Type @event)
		{
			return null;
		}
	}
}