namespace Shaykhullin.Network
{
	public interface ISerializerBuilder : ICompressionBuilder 
	{
		ICompressionBuilder UseCompression<TCompression>()
			where TCompression : ICompression;
	}
	
	public interface ICompressionBuilder : IEncryptionBuilder
	{
		IEncryptionBuilder UseEncryption<TEncryption>()
			where TEncryption : IEncryption;
	}
	
	public interface IEncryptionBuilder
	{
		void UseDependencyContainer<TContainer>()
			where TContainer : IDependencyContainer;
	}
	
	public interface ISerializer
	{
	}

	public interface ICompression
	{
	}

	public interface IEncryption
	{
	}

	public interface IDependencyContainer
	{
	}
}