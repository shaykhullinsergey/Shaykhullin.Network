using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
{
	public class Disconnect : IEvent<IConnection>
	{
		public Disconnect(IConnection context)
		{
			Context = context;
		}

		public IConnection Context { get; }
	}
}