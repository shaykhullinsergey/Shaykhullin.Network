using System.Threading.Tasks;

namespace Network.Core
{
	public interface ISendBuilder
	{
		Task In<TEvent>()
			where TEvent : IEvent<object>;
	}
}
