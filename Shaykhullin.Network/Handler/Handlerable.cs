using System.Collections.Generic;

namespace Shaykhullin.Network.Core
{
	public class Handlerable : IHandlerable
	{
		public IList<EventHandler> Handlers { get; } = new List<EventHandler>();

		public IConfigBuilder<TEvent> When<TEvent>()
			where TEvent : IHandlerEvent<object>
		{
			var eventHandler = new EventHandler(typeof(TEvent));
			Handlers.Add(eventHandler);

			return new ConfigBuilder<TEvent>(eventHandler);
		}
	}
}
