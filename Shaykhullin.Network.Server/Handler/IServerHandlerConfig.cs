namespace Shaykhullin.Network
{
	public interface IServerHandlerConfig<out TEvent>
		where TEvent : IServerEvent<object>
	{
		void Call<THandler>()
			where THandler : IServerHandler<TEvent>;
	}
}