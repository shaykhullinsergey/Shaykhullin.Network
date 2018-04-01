using System;
using System.Linq;
using System.Collections.Generic;

using Xunit;
using Network;
using Network.Core;

namespace Network.Tests
{
	public class DependenciesTest : ClientTests
	{
		[Fact]
		public void DependenciesRegistered()
		{
			var config = new ClientConfig();

			config.Register<Base>()
				.ImplementedBy<Derived>()
				.As<Singleton>();

			var field = GetField<IDictionary<Type, DependencyDto>>("dependencies", config);

			Assert.Equal(1, field.Count);
			Assert.Equal(typeof(Base), field.Values.Single().Register);
			Assert.Equal(typeof(Derived), field.Values.Single().Implemented);
			Assert.Equal(typeof(Singleton), field.Values.Single().Lifecycle);
		}

		class Base
		{
		}

		class Derived : Base
		{
		}
	}
}
