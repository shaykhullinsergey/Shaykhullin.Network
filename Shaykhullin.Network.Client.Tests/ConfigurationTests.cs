using Shaykhullin.Network.Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;

namespace Shaykhullin.Network.Client.Tests
{
	public class ConfigurationTests
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

		private TField GetField<TField>(string name, ClientConfig config)
			where TField : class
		{
			return config.GetType()
				.GetField(name, BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(config) as TField;
		}
	}
}
