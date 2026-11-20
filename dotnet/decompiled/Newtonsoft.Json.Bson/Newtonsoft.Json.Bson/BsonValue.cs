namespace Newtonsoft.Json.Bson;

internal class BsonValue : Newtonsoft.Json.Bson.BsonToken
{
	private readonly object _value;

	private readonly Newtonsoft.Json.Bson.BsonType _type;

	public object Value => _value;

	public override Newtonsoft.Json.Bson.BsonType Type => _type;

	public BsonValue(object value, Newtonsoft.Json.Bson.BsonType type)
	{
		_value = value;
		_type = type;
	}
}
