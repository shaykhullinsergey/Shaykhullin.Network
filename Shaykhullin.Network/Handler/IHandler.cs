namespace Shaykhullin.Network
{
	public interface IHandler<in TEvent>
	{
		void Execute(TEvent @event);
	}
}