using System;
using System.Collections.Generic;

namespace Network.Core
{
	internal class ChannelConfig : IChannelConfig
	{
		protected readonly IDictionary<Type, DependencyDto> dependencies;

		public ChannelConfig(IDictionary<Type, DependencyDto> dependencies)
		{
			this.dependencies = dependencies;
		}

		public IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class
		{
			if (dependencies.TryGetValue(typeof(TRegister), out var dto))
			{
				throw new InvalidOperationException($"Type {typeof(TRegister)} already registered");
			}

			dto = new DependencyDto(typeof(TRegister));
			dependencies.Add(typeof(TRegister), dto);
			return new RegisterBuilder<TRegister>(dto);
		}
	}
}