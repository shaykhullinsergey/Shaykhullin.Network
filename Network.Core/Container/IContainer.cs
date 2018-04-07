using System;

namespace Network.Core
{
	public interface IContainer
	{
		object Resolve(Type handler);
		object ResolveEvent(Type eventType, object data);
	}
}