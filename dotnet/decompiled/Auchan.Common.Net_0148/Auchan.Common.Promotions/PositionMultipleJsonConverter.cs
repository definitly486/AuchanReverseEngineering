using System;
using System.Linq;
using Newtonsoft.Json;

namespace Auchan.Common.Promotions;

public sealed class PositionMultipleJsonConverter : JsonConverter
{
	public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
	{
	}

	public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
	{
		return (reader.Value?.ToString()?.Split(',') ?? Array.Empty<string>()).Select((string x) => PositionConverter.FromStringToPromotionPosition(x)).ToList();
	}

	public override bool CanConvert(Type objectType)
	{
		return true;
	}
}
