namespace System.Text.Json.Serialization;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class JsonSerializableAttribute : JsonAttribute
{
	public JsonSerializableAttribute(Type type)
	{
	}
}
