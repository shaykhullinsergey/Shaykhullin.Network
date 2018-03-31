using System;

namespace Shaykhullin.Network.Core
{
	internal class ConfigBuilder<TEvent> : IConfigBuilder<TEvent>
		where TEvent : IHandlerEvent<object>
	{
		private readonly EventHandler eventHandler;

		public ConfigBuilder(EventHandler eventHandler)
		{
			this.eventHandler = eventHandler;
		}

		public void Call<TConfig>() 
			where TConfig : IConfig<TEvent>
		{
			eventHandler.Handler = typeof(TConfig);
		}
	}
}
