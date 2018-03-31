using System;
using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
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