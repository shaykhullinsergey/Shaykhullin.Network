using System;

namespace Network.Core
{
	internal class ConfigBuilder<TEvent> : IConfigBuilder<TEvent>
		where TEvent : IHandlerEvent<object>
	{
		private readonly ConfigDto eventHandler;

		public ConfigBuilder(ConfigDto eventHandler)
		{
			this.eventHandler = eventHandler;
		}

		public void Call<TConfig>() 
			where TConfig : IConfig<TEvent>
		{
			eventHandler.Configs.Add(typeof(TConfig));
		}
	}
}
