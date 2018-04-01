using System.Threading.Tasks;

namespace Network
{
	public interface IHandler<in TEvent>
		where TEvent : IEvent<object>
	{
		Task Handle(TEvent @event);
	}
}