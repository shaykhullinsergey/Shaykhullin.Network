using Network.Core;

namespace Network
{
	public class Stop : IHandlerEvent<object>
	{
		public Stop(object context)
		{
			Context = context;
		}

		public object Context { get; }
	}
}