namespace Network.Core
{
	public interface IHandlerBuilder<out TEvent>
		where TEvent : IEvent<object>
	{
		void Call<THandler>()
			where THandler : IHandler<TEvent>;
	}
}