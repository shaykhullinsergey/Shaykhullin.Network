namespace Shaykhullin.Network.Core
{
	public interface IDependencyContainerBuilder
	{
		void UseContainer<TContainer>()
			where TContainer : IContainerBuilder;
	}
}