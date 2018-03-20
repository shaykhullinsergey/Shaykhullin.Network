namespace Shaykhullin.Network
{
	public interface ISerializerBuilder : ICompressionBuilder 
	{
		ICompressionBuilder UseCompression<TCompression>()
			where TCompression : ICompression;
	}
}