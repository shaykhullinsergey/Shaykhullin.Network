using System.Reflection;
using Network;

namespace Network.Tests
{
	public class ClientTests
	{
		protected TField GetField<TField>(string name, ClientConfig config)
			where TField : class
		{
			return config.GetType()
				.GetField(name, BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(config) as TField;
		}
	}
}
