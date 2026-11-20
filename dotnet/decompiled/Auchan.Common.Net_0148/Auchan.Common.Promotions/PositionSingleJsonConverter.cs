using System;
using Newtonsoft.Json;

namespace Auchan.Common.Promotions;

public sealed class PositionSingleJsonConverter : JsonConverter
{
	public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
	{
	}

	public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
	{
		return PositionConverter.FromStringToPromotionPosition(reader.Value?.ToString());
	}

	public override bool CanConvert(Type objectType)
	{
		return true;
	}
}
