using Network.Core;

namespace Network.Core
{
	public class Channel : IChannel
	{
		public ISendBuilder<TData> Send<TData>(TData data)
		{
			return new SendBuilder<TData>();
		}
	}
}