using System;

namespace Shaykhullin.Network.Core
{
	internal class ConfigBuilder<TEvent> : IConfigBuilder<TEvent>
		where TEvent : IHandlerEvent<object>
	{
		public void Call<TConfig>() where TConfig : IConfig<TEvent>
		{
			throw new NotImplementedException();
		}
	}
}
