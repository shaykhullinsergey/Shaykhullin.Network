namespace Shaykhullin.Network.Core
{
	public interface IDependencyContainerBuilder
	{
		void UseDependencyContainer<TContainer>()
			where TContainer : IContainerBuilder;
	}
}