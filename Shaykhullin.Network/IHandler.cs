namespace Shaykhullin.Network
{
	public interface IHandler<in TEvent>
	{
		void Execute(TEvent @event);
	}

	public class StartHandler : IHandler<Start>
	{
		public void Execute(Start @event)
		{
		}
	}

	public class ConnectionHandler : IHandler<Connection>
	{
		public void Execute(Connection @event)
		{
		}
	}
}