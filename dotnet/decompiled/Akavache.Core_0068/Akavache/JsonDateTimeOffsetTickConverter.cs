using System;
using Newtonsoft.Json;

namespace Akavache;

internal class JsonDateTimeOffsetTickConverter : JsonConverter
{
	internal class DateTimeOffsetData
	{
		public long Ticks { get; set; } = offset.Ticks;

		public long OffsetTicks { get; set; } = offset.Offset.Ticks;

		public DateTimeOffsetData(DateTimeOffset offset)
		{
		}

		public static explicit operator DateTimeOffset(DateTimeOffsetData value)
		{
			return new DateTimeOffset(value.Ticks, new TimeSpan(value.OffsetTicks));
		}
	}

	public static JsonDateTimeOffsetTickConverter Default { get; } = new JsonDateTimeOffsetTickConverter();

	public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
	{
		if (value is DateTimeOffset offset)
		{
			serializer.Serialize(writer, new DateTimeOffsetData(offset));
		}
	}

	public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
	{
		if (reader.TokenType == JsonToken.Date && reader.Value != null)
		{
			return (DateTimeOffset)reader.Value;
		}
		DateTimeOffsetData dateTimeOffsetData = serializer.Deserialize<DateTimeOffsetData>(reader);
		if (dateTimeOffsetData != null)
		{
			return (DateTimeOffset)dateTimeOffsetData;
		}
		return null;
	}

	public override bool CanConvert(Type objectType)
	{
		if (!(objectType == typeof(DateTimeOffset)))
		{
			return objectType == typeof(DateTimeOffset?);
		}
		return true;
	}
}
