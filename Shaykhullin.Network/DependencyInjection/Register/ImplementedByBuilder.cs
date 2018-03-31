using System;

namespace Shaykhullin.Network.Core
{
	internal class ImplementedByBuilder : IImplementedByBuilder
	{
		private readonly Dependency dependency;

		public ImplementedByBuilder(Dependency dependency)
		{
			this.dependency = dependency;
		}

		public void As<TLifecycle>() 
			where TLifecycle : ILifecycle
		{
			dependency.Lifecycle = typeof(TLifecycle);
		}
	}
}
