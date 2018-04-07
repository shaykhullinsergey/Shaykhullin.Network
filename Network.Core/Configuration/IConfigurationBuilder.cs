using System;

namespace Network.Core
{
	public interface IConfigurationBuilder : ICompressionBuilder
	{
		ICompressionBuilder UseSerializer<TSerializer>()
			where TSerializer : ISerializer;
	}
}
