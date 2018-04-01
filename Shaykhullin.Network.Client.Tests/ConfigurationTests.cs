using Xunit;

using Shaykhullin.Network;
using Shaykhullin.Network.Core;

namespace Network.Tests
{
	public class ConfigurationTests : ClientTests
	{
		[Fact]
		public void Configuration()
		{
			var config = new ClientConfig();

			config.UseSerializer<DefaultSerializer>()
				.UseCompression<DefaultCompression>()
				.UseEncryption<DefaultEncryption>()
				.UseCommunicator<DefaultCommunicator>()
				.UseContainer<DefaultContainerBuilder>();

			var c = GetField<Configuration>("configuration", config);

			Assert.Equal(typeof(DefaultSerializer), c.Serializer);
			Assert.Equal(typeof(DefaultCompression), c.Compression);
			Assert.Equal(typeof(DefaultEncryption), c.Encryption);
			Assert.Equal(typeof(DefaultCommunicator), c.Communicator);
			Assert.Equal(typeof(DefaultContainerBuilder), c.Container);
		}
	}
}
