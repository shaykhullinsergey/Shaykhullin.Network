using Shaykhullin.Network.Core;

namespace Shaykhullin.Network.Core
{
	public class Channel : IChannel
	{
		public ISendBuilder<TData> Send<TData>(TData data)
		{
			return new SendBuilder<TData>();
		}
	}
}