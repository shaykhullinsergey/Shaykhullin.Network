namespace Shaykhullin.Network.Core
{
	internal class EncryptionBuilder : IEncryptionBuilder
	{
		public IProtocolBuilder UseEncryption<TEncryption>()
			where TEncryption : IEncryption
		{
			return new ProtocolBuilder();
		}

		public IDependencyContainerBuilder UseProtocol<TProtocol>() 
			where TProtocol : IProtocol
		{
			return new ProtocolBuilder()
				.UseProtocol<TProtocol>();
		}

		public void UseContainer<TContainer>() 
			where TContainer : IContainerBuilder
		{
			new ProtocolBuilder()
				.UseContainer<TContainer>();
		}
	}
}
