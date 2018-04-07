namespace Network.Core
{
	public interface IMessageComposer
	{
		IMessage GetMessage(IPayload payload);
		IPayload GetPayload(IMessage message);
	}
}