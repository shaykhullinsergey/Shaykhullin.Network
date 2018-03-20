namespace Shaykhullin.Network
{
	public interface IHandlerConfig<TPayload>
	{
		void Call<THandler>()
			where THandler : IHandler<TPayload>;
	}
}