using System;
using Newtonsoft.Json;

namespace Auchan.Common.DynamicFeedback.Responses;

internal class NameFosConverter : JsonConverter
{
	public static readonly NameFosConverter Singleton = new NameFosConverter();

	public override bool CanConvert(Type objectType)
	{
		return true;
	}

	public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
	{
		if (reader.TokenType == JsonToken.Null)
		{
			return null;
		}
		return serializer.Deserialize<string>(reader);
	}

	public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
	{
	}
}
