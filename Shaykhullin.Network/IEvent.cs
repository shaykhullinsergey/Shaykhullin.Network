namespace Shaykhullin.Network
{
	public interface IEvent<out TPayload>
	{
		TPayload Payload { get; }
	}
	
	public class Start : IEvent<object>
	{
		public object Payload { get; }
	}
	
	public class Connection : IEvent<IConnectionConfig>
	{
		public Connection(IConnectionConfig payload)
		{
			Payload = payload;
		}

		public IConnectionConfig Payload { get; }
	}
}