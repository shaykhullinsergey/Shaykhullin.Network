using System;

namespace Shaykhullin.Network.Core
{
	internal class ContainerBuilder : IContainerBuilderBuilder
	{
		public void UseContainer<TContainer>() 
			where TContainer : IContainerBuilder
		{
			throw new NotImplementedException();
		}
	}
}
