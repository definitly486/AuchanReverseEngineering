using System;
using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API.Requests;

public class BatchRequestConverter : JsonConverter
{
	public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
	{
		if (!(value is BatchItemRequest batchItemRequest))
		{
			throw new ArgumentException("value");
		}
		writer.WriteStartObject();
		writer.WritePropertyName(batchItemRequest.EventName);
		serializer.Serialize(writer, batchItemRequest.Request);
		writer.WriteEndObject();
	}

	public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
	{
		throw new NotImplementedException("ReadJson");
	}

	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(BatchItemRequest);
	}
}
