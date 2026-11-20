namespace Newtonsoft.Json.Bson;

internal class BsonString : Newtonsoft.Json.Bson.BsonValue
{
	public int ByteCount { get; set; }

	public bool IncludeLength { get; }

	public BsonString(object value, bool includeLength)
		: base(value, Newtonsoft.Json.Bson.BsonType.String)
	{
		IncludeLength = includeLength;
	}
}
