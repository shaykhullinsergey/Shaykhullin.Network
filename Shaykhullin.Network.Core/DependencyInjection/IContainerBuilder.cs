using System;

namespace Network.Core
{
	public interface IContainerBuilder
	{
		void Register(Type register, Type implemented, ILifecycle lifecycle);
		IContainer Build();
	}
}