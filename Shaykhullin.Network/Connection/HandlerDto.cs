using System;
using System.Collections.Generic;

namespace Network.Core
{
	public class HandlerDto
	{
		public Type Event { get; }
		public IList<Type> Handlers { get; set; }

		public HandlerDto(Type @event)
		{
			Event = @event;
			Handlers = new List<Type>();
		}
	}
}
