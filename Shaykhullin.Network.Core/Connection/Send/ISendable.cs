namespace Shaykhullin.Network.Core
{
	public interface ISendable
	{
		ISendBuilder<TData> Send<TData>(TData data);
	}
}