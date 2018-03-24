namespace Shaykhullin.Network.Core
{
	public interface IConfigBuilder<out TEvent>
		where TEvent : IConfigEvent<object>
	{
		void Call<TConfig>()
			where TConfig : IConfig<TEvent>;
	}
}