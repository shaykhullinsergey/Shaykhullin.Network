namespace Shaykhullin.Network.Core
{
	public interface IConnectionHandlerConfig<out TEvent>
		where TEvent : IConnectionEvent<object>
	{
		void Call<THandler>()
			where THandler : IConnectionHandler<TEvent>;
	}
}