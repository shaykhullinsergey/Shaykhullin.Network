namespace Shaykhullin.Network.Core
{
	public interface IConfigBuilder<out TEvent>
		where TEvent : IHandlerEvent<object>
	{
		void Call<TConfig>()
			where TConfig : IConfig<TEvent>;
	}
}