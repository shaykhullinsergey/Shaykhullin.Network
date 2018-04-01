namespace Network
{
	public interface IEvent<out TData>
	{
		IConnection Connection { get; }
		TData Data { get; }
	}
}