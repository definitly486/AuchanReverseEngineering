namespace Newtonsoft.Json.Bson;

internal class BsonBoolean : Newtonsoft.Json.Bson.BsonValue
{
	public BsonBoolean(bool value)
		: base(value, Newtonsoft.Json.Bson.BsonType.Boolean)
	{
	}
}
