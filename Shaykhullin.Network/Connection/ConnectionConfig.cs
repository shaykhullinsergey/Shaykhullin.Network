using System;
using System.Collections.Generic;

namespace Shaykhullin.Network.Core
{
	internal class ConnectionConfig : IConnectionConfig
	{
		protected readonly IDictionary<Type, HandlerDto> handlers = new Dictionary<Type, HandlerDto>();

		public IHandlerBuilder<TEvent> When<TEvent>() 
			where TEvent : IEvent<object>
		{
			if (!handlers.TryGetValue(typeof(TEvent), out var dto))
			{
				dto = new HandlerDto(typeof(TEvent));
				handlers.Add(typeof(TEvent), dto);
			}

			return new HandlerBuilder<TEvent>(dto);
		}
	}
}
