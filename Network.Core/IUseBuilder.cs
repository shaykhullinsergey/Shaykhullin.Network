namespace Network.Core
{
	public interface IUseBuilder<TEvent>
		where TEvent : IEvent<object>
	{
		void Use<THandler>()
			where THandler : IHandler<TEvent>;
	}
}
