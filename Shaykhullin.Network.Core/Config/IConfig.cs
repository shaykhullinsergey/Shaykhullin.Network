namespace Shaykhullin.Network
{
	public interface IConfig<in TEvent>
	{
		void Configure(TEvent @event);
	}
}