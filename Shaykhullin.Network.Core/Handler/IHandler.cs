using System.Threading.Tasks;

namespace Shaykhullin.Network
{
	public interface IHandler<in TEvent>
		where TEvent : IEvent<object>
	{
		Task Handle(TEvent @event);
	}
}