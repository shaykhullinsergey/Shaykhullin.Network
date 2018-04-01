using System;
using System.Collections.Generic;

namespace Network.Core
{
	public class ConfigDto
	{
		public Type Event { get; }
		public IList<Type> Configs { get; set; }

		public ConfigDto(Type @event)
		{
			Event = @event;
			Configs = new List<Type>();
		}
	}
}
