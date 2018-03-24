using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
{
	public class Connection : IConfigEvent<IConnectionConfig>
	{
		public Connection(IConnectionConfig context)
		{
			Context = context;
		}

		public IConnectionConfig Context { get; }
	}
}