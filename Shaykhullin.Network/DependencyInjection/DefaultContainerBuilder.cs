using System;

namespace Shaykhullin.Network.Core
{
	public class DefaultContainerBuilder : IContainerBuilder
	{
		public void Register(Type register, Type implemented, ILifecycle lifecycle)
		{
			throw new NotImplementedException();
		}

		public IContainer Build()
		{
			return new DefaultContainer();
		}
	}
}