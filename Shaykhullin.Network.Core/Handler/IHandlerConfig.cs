namespace Shaykhullin.Network.Core
{
	public interface IHandlerConfig<out TEvent>
		where TEvent : IEvent<object>
	{
		void Call<THandler>()
			where THandler : IHandler<TEvent>;
	}
}