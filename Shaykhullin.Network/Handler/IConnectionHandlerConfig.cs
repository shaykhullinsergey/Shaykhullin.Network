namespace Shaykhullin.Network
{
	public interface IConnectionHandlerConfig<out TEvent>
		where TEvent : IConnectionEvent<object>
	{
		void Call<THandler>()
			where THandler : IConnectionHandler<TEvent>;
	}
}