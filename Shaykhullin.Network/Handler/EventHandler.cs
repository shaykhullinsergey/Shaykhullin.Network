using System;

namespace Shaykhullin.Network.Core
{
	public class EventHandler
	{
		public Type Event { get; }
		public Type Handler { get; set; }

		public EventHandler(Type @event)
		{
			Event = @event;
		}
	}
}
