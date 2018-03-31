using System.Collections.Generic;

namespace Shaykhullin.Network.Core
{
	internal class ChannelConfig : IChannelConfig
	{
		private readonly IList<Dependency> dependencies;

		public ChannelConfig(IList<Dependency> dependencies)
		{
			this.dependencies = dependencies;
		}

		public IRegisterBuilder<TRegister> Register<TRegister>()
			where TRegister : class
		{
			var dependency = new Dependency(typeof(TRegister));
			dependencies.Add(dependency);

			return new RegisterBuilder<TRegister>(dependency);
		}
	}
}