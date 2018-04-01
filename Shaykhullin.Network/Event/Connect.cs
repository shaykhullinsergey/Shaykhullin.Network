using Network.Core;

namespace Network
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