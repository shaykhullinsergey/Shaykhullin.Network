namespace Network.Core
{
	public interface IConfigurable : ICompressionBuilder
	{
		ICompressionBuilder UseSerializer<TSerializer>()
			where TSerializer : ISerializer;
	}
}
