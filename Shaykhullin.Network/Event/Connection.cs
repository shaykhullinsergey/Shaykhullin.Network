using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
{
	public class Connection : IHandlerEvent<IConnectionConfig>
	{
		public Connection(IConnectionConfig context)
		{
			Context = context;
		}

		public IConnectionConfig Context { get; }
	}
}