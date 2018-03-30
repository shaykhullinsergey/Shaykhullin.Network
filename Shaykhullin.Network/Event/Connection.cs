using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
{
	public class Connect : IHandlerEvent<IConnectionConfig>
	{
		public Connect(IConnectionConfig context)
		{
			Context = context;
		}

		public IConnectionConfig Context { get; }
	}
}