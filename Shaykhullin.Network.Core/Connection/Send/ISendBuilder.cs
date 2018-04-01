using System.Threading.Tasks;

namespace Network.Core
{
	public interface ISendBuilder<in TData>
	{
		Task To<TEvent>()
			where TEvent : IEvent<TData>;
	}
}