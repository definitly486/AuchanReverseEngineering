using System;
using Newtonsoft.Json;

namespace Akavache;

internal class JsonDateTimeTickConverter(DateTimeKind? forceDateTimeKindOverride = null) : JsonConverter()
{
	private readonly DateTimeKind? _forceDateTimeKindOverride = forceDateTimeKindOverride;

	public static JsonDateTimeTickConverter Default { get; } = new JsonDateTimeTickConverter();

	public static JsonDateTimeTickConverter LocalDateTimeKindDefault { get; } = new JsonDateTimeTickConverter(DateTimeKind.Local);

	public override bool CanConvert(Type objectType)
	{
		if (!(objectType == typeof(DateTime)))
		{
			return objectType == typeof(DateTime?);
		}
		return true;
	}

	public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		JsonToken tokenType = reader.TokenType;
		if (tokenType != JsonToken.Integer && tokenType != JsonToken.Date)
		{
			return null;
		}
		if (reader.TokenType == JsonToken.Date && reader.Value != null)
		{
			return (DateTime)reader.Value;
		}
		if ((objectType == typeof(DateTime) || objectType == typeof(DateTime?)) && reader.Value != null)
		{
			return new DateTime((long)reader.Value, forceDateTimeKindOverride ?? DateTimeKind.Utc);
		}
		return null;
	}

	public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
	{
		if (value is DateTime dateTime)
		{
			DateTimeKind? forceDateTimeKindOverride = forceDateTimeKindOverride;
			if (forceDateTimeKindOverride.HasValue && forceDateTimeKindOverride == DateTimeKind.Local)
			{
				serializer.Serialize(writer, dateTime.Ticks);
			}
			else
			{
				serializer.Serialize(writer, dateTime.ToUniversalTime().Ticks);
			}
		}
	}
}
