namespace Shaykhullin.Network.Core
{
	public interface IProtocolBuilder
	{
		void UseDependencyContainer<TContainer>()
			where TContainer : IContainerBuilder;
	}
}