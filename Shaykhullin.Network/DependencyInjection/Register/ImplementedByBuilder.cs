using System;

namespace Shaykhullin.Network.Core
{
	internal class ImplementedByBuilder : IImplementedByBuilder
	{
		public void As<TLifetime>() 
			where TLifetime : ILifecycle
		{
			throw new NotImplementedException();
		}
	}
}
