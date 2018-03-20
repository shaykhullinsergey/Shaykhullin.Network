namespace Shaykhullin.Network.Core
{
	public interface ISerializerBuilder : ICompressionBuilder 
	{
		ICompressionBuilder UseCompression<TCompression>()
			where TCompression : ICompression;
	}
}