namespace Shaykhullin.Network.Core
{
	public class Configurable : IConfigurable
	{
		public Configuration Configuration { get; } = new Configuration();

		public ICompressionBuilder UseSerializer<TSerializer>()
			where TSerializer : ISerializer
		{
			Configuration.Serializer = typeof(TSerializer);
			return new CompressionBuilder(Configuration);
		}

		public IEncryptionBuilder UseCompression<TCompression>()
			where TCompression : ICompression
		{
			return new CompressionBuilder(Configuration)
				.UseCompression<TCompression>();
		}

		public ICommunicatorBuilder UseEncryption<TEncryption>()
			where TEncryption : IEncryption
		{
			return new CompressionBuilder(Configuration)
				.UseEncryption<TEncryption>();
		}

		public IContainerBuilderBuilder UseCommunicator<TProtocol>()
			where TProtocol : ICommunicator
		{
			return new CompressionBuilder(Configuration)
				.UseCommunicator<TProtocol>();
		}

		public void UseContainer<TContainer>()
			where TContainer : IContainerBuilder
		{
			new CompressionBuilder(Configuration)
				.UseContainer<TContainer>();
		}
	}
}
