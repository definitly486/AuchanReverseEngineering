namespace Newtonsoft.Json.Bson;

internal class BsonBinary : Newtonsoft.Json.Bson.BsonValue
{
	public Newtonsoft.Json.Bson.BsonBinaryType BinaryType { get; set; }

	public BsonBinary(byte[] value, Newtonsoft.Json.Bson.BsonBinaryType binaryType)
		: base(value, Newtonsoft.Json.Bson.BsonType.Binary)
	{
		BinaryType = binaryType;
	}
}
