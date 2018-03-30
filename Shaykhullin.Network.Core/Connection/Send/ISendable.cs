namespace Shaykhullin.Network
{
	public interface ISendable
	{
		ISendBuilder<TData> Send<TData>(TData data);
	}
}