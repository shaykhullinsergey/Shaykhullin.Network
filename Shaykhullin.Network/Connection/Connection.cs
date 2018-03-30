namespace Shaykhullin.Network.Core
{
	internal class Connection : IConnection
	{
		public IProtocol Procotol { get; }

		public ISendBuilder<TData> Send<TData>(TData data)
		{
			return new SendBuilder<TData>();
		}
	}
}
