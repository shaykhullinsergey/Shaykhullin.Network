namespace Shaykhullin.Network
{
	public class Connection : IServerEvent<IConnectionConfig>
	{
		public Connection(IConnectionConfig context)
		{
			Context = context;
		}

		public IConnectionConfig Context { get; }
	}
}