using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
{
	public class DefaultContainerBuilder : IContainerBuilder
	{
		public IContainer Build()
		{
			return new DefaultContainer();
		}
	}
}