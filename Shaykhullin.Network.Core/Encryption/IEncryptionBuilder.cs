namespace Shaykhullin.Network.Core
{
	public interface IEncryptionBuilder
	{
		void UseDependencyContainer<TContainer>()
			where TContainer : IContainerBuilder;
	}
}