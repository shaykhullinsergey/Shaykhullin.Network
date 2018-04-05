using System.Threading.Tasks;

namespace Network.Core
{
	public interface IConnection
	{
		Task Send(IPayload payload);
	}
}
