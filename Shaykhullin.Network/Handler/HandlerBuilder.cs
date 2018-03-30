using System;

namespace Shaykhullin.Network.Core
{
	internal class HandlerBuilder<TEvent> : IHandlerBuilder<TEvent>
		where TEvent : IEvent<object>
	{
		public void Call<THandler>() 
			where THandler : IHandler<TEvent>
		{
			throw new NotImplementedException();
		}
	}
}
