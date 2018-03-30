using System;

namespace Shaykhullin.Network.Core
{
	internal class DependencyContainerBuilder : IDependencyContainerBuilder
	{
		public void UseDependencyContainer<TContainer>() 
			where TContainer : IContainerBuilder
		{
			throw new NotImplementedException();
		}
	}
}
