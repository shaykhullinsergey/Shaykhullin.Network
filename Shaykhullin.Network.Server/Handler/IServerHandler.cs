namespace Shaykhullin.Network
{
	public interface IServerHandler<in TEvent>
	{
		void Execute(TEvent @event);
	}
}