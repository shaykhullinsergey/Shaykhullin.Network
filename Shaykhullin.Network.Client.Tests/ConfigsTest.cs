using Xunit;
using System;
using System.Linq;
using System.Collections.Generic;

using Network;
using Network.Core;

namespace Network.Tests
{
	public class ConfigsTest : ClientTests
	{
		[Fact]
		public void ConfigExists()
		{
			var config = new ClientConfig();

			config.When<Connect>()
				.Call<ConnectConfig>();

			var configs = GetField<IDictionary<Type, ConfigDto>>("configs", config);

			Assert.Equal(1, configs.Count);
			Assert.Equal(typeof(Connect), configs.Values.Single().Event);
			Assert.Equal(1, configs.Values.Single().Configs.Count);
			Assert.Equal(typeof(ConnectConfig), configs.Values.Single().Configs.Single());
		}

		[Fact]
		public void AllConfigsExists()
		{
			var config = new ClientConfig();

			config.When<Connect>()
				.Call<ConnectConfig>();

			config.When<Connect>()
				.Call<ConnectConfig>();

			config.When<Connect>()
				.Call<ConnectConfig>();

			var configs = GetField<IDictionary<Type, ConfigDto>>("configs", config);

			Assert.Equal(1, configs.Count);
			Assert.Equal(typeof(Connect), configs.Values.Single().Event);
			Assert.Equal(3, configs.Values.Single().Configs.Count);

			foreach (var c in configs.Values.First().Configs)
			{
				Assert.Equal(typeof(ConnectConfig), c);
			}
		}

		[Fact]
		public void AllConfigDifferentExists()
		{
			var config = new ClientConfig();

			config.When<Connect>()
				.Call<ConnectConfig>();

			config.When<Connect>()
				.Call<ConnectConfig2>();

			config.When<Connect>()
				.Call<ConnectConfig>();

			var configs = GetField<IDictionary<Type, ConfigDto>>("configs", config);

			Assert.Equal(1, configs.Count);
			Assert.Equal(typeof(Connect), configs.Values.Single().Event);
			Assert.Equal(3, configs.Values.Single().Configs.Count);

			var c = configs.Values.First().Configs;
			Assert.Equal(typeof(ConnectConfig), c[0]);
			Assert.Equal(typeof(ConnectConfig2), c[1]);
			Assert.Equal(typeof(ConnectConfig), c[2]);
		}

		class ConnectConfig : IConfig<Connect>
		{
			public void Configure(Connect @event)
			{
				throw new NotImplementedException();
			}
		}

		class ConnectConfig2 : IConfig<Connect>
		{
			public void Configure(Connect @event)
			{
				throw new NotImplementedException();
			}
		}
	}
}
