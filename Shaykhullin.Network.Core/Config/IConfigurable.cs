namespace Shaykhullin.Network.Core
{
	public interface IConfigurable : ICompressionBuilder
	{
		IConfigBuilder<TEvent> When<TEvent>()
			where TEvent : IHandlerEvent<object>;

		ICompressionBuilder UseSerializer<TSerializer>()
			where TSerializer : ISerializer;
	}
}
