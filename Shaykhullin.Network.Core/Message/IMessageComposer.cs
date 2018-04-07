using System.Threading.Tasks;

namespace Network.Core
{
	public interface IMessageComposer
	{
		ValueTask<IMessage> GetMessage(IPayload payload);
		ValueTask<IPayload> GetPayload(IMessage message);
	}
}