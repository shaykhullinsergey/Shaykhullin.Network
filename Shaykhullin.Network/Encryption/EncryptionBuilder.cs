namespace Shaykhullin.Network.Core
{
	internal class EncryptionBuilder : IEncryptionBuilder
	{
		public ICommunicatorBuilder UseEncryption<TEncryption>()
			where TEncryption : IEncryption
		{
			return new CommunicatorBuilder();
		}

		public IDependencyContainerBuilder UseCommunicator<TProtocol>() 
			where TProtocol : ICommunicator
		{
			return new CommunicatorBuilder()
				.UseCommunicator<TProtocol>();
		}

		public void UseContainer<TContainer>() 
			where TContainer : IContainerBuilder
		{
			new CommunicatorBuilder()
				.UseContainer<TContainer>();
		}
	}
}
