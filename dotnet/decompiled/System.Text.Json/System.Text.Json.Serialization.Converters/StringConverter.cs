namespace System.Text.Json.Serialization.Converters;

internal sealed class StringConverter : JsonPrimitiveConverter<string>
{
	public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return reader.GetString();
	}

	public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
	{
		if (value == null)
		{
			writer.WriteNullValue();
		}
		else
		{
			writer.WriteStringValue(value.AsSpan());
		}
	}
}
