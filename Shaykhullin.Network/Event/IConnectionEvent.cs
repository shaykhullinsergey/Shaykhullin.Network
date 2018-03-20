namespace Shaykhullin.Network
{
	public interface IConnectionEvent<out TData>
	{
		IConnection Connection { get; }
		TData Data { get; }
	}
}