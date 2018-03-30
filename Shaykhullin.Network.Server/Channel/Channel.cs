using Shaykhullin.Network.Core;

namespace Shaykhullin.Network
{
	public class Channel : IChannel
	{
		public ISendBuilder<TData> Send<TData>(TData data)
		{
			return new SendBuilder<TData>();
		}
	}
}