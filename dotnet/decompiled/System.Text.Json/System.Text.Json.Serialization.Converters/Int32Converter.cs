namespace System.Text.Json.Serialization.Converters;

internal sealed class Int32Converter : JsonPrimitiveConverter<int>
{
	public Int32Converter()
	{
		base.IsInternalConverterForNumberType = true;
	}

	public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return reader.GetInt32();
	}

	public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
	{
		writer.WriteNumberValue(value);
	}

	internal override int ReadNumberWithCustomHandling(ref Utf8JsonReader reader, JsonNumberHandling handling, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.String && (JsonNumberHandling.AllowReadingFromString & handling) != JsonNumberHandling.Strict)
		{
			return reader.GetInt32WithQuotes();
		}
		return reader.GetInt32();
	}

	internal override void WriteNumberWithCustomHandling(Utf8JsonWriter writer, int value, JsonNumberHandling handling)
	{
		if ((JsonNumberHandling.WriteAsString & handling) != JsonNumberHandling.Strict)
		{
			writer.WriteNumberValueAsString(value);
		}
		else
		{
			writer.WriteNumberValue(value);
		}
	}
}
