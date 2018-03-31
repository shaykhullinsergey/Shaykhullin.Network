using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using Xunit;
using Shaykhullin.Network.Core;

namespace Shaykhullin.Network.Client.Tests
{
	public class DependenciesTest
	{
		[Fact]
		public void DependenciesRegistered()
		{
			var config = new ClientConfig();

			config.Register<A>()
				.ImplementedBy<B>()
				.As<Singleton>();

			var field = GetField<IDictionary<Type, DependencyDto>>("dependencies", config);

			Assert.Equal(1, field.Count);
			Assert.Equal(typeof(A), field.Values.Single().Register);
			Assert.Equal(typeof(B), field.Values.Single().Implemented);
			Assert.Equal(typeof(Singleton), field.Values.Single().Lifecycle);
		}

		private TField GetField<TField>(string name, ClientConfig config)
			where TField : class
		{
			return config.GetType()
				.GetField(name, BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(config) as TField;
		}

		class A
		{
		}

		class B : A
		{
		}
	}
}
