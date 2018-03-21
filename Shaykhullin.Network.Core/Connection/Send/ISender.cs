namespace Shaykhullin.Network
{
	public interface ISender
	{
		ISendBuilder<TData> Send<TData>(TData data);
	}
}