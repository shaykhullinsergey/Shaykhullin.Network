namespace Shaykhullin.Network
{
	public interface IHandlerConfig<out TEvent>
		where TEvent : IEvent<object>
	{
		void Call<THandler>()
			where THandler : IHandler<TEvent>;
	}
}