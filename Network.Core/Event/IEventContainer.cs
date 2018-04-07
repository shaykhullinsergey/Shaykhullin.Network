using System;
using System.Collections.Generic;

namespace Network.Core
{
	public interface IEventContainer
	{
		Type GetEvent(int id);
		int GetEvent(Type @event);
		IEnumerable<Type> GetHandlers(Type @event);
	}
}
