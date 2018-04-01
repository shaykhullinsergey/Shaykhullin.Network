using Network.Core;

namespace Network
{
	public class Start : IHandlerEvent<object>
	{
		public Start(object context)
		{
			Context = context;
		}

		public object Context { get; }
	}
}