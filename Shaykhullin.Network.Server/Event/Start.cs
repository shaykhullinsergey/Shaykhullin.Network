using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
{
	public class Start : IConfigEvent<object>
	{
		public Start(object context)
		{
			Context = context;
		}

		public object Context { get; }
	}
}