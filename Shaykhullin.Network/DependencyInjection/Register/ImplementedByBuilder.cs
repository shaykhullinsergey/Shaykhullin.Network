using System;

namespace Network.Core
{
	internal class ImplementedByBuilder : IImplementedByBuilder
	{
		private readonly DependencyDto dependency;

		public ImplementedByBuilder(DependencyDto dependency)
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
