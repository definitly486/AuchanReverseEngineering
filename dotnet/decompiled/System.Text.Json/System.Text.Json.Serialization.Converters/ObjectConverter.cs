namespace System.Text.Json.Serialization.Converters;

internal abstract class ObjectConverter : JsonConverter<object>
{
	private protected override ConverterStrategy GetDefaultConverterStrategy()
	{
		return ConverterStrategy.Object;
	}

	public ObjectConverter()
	{
		base.CanBePolymorphic = true;
	}

	public sealed override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
	{
		if (value == null)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();
		writer.WriteEndObject();
	}
}
