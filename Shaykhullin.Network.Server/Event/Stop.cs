using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
{
	public class Stop : IConfigEvent<object>
	{
		public Stop(object context)
		{
			Context = context;
		}

		public object Context { get; }
	}
}