using System.Threading.Tasks;

namespace Shaykhullin.Network
{
	public interface IConnectionHandler<in TEvent>
		where TEvent : IConnectionEvent<object>
	{
		Task Execute(TEvent @event);
	}
}