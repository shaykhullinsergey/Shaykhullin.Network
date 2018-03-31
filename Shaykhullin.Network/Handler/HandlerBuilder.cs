namespace Shaykhullin.Network.Core
{
	internal class HandlerBuilder<TEvent> : IHandlerBuilder<TEvent>
		where TEvent : IEvent<object>
	{
		private readonly HandlerDto dto;

		public HandlerBuilder(HandlerDto dto)
		{
			this.dto = dto;
		}

		public void Call<THandler>() 
			where THandler : IHandler<TEvent>
		{
			dto.Handlers.Add(typeof(THandler));
		}
	}
}
