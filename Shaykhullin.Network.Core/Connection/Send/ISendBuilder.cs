using System.Threading.Tasks;

namespace Shaykhullin.Network
{
	public interface ISendBuilder<in TData>
	{
		Task To<TEvent>()
			where TEvent : IConnectionEvent<TData>;
	}
}