using System;
using Auchan.Common.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Auchan.Common.Common;

public class EnumMemberJsonConverter<T> : JsonConverter where T : Enum
{
	public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
	{
		JToken.FromObject(value).WriteTo(writer);
	}

	public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
	{
		if (reader.Value is string text && !string.IsNullOrWhiteSpace(text))
		{
			return text.ToEnum<T>();
		}
		T val = default(T);
		if (val == null)
		{
			throw new InvalidCastException();
		}
		return val;
	}

	public override bool CanConvert(Type objectType)
	{
		if (!(objectType == typeof(string)))
		{
			return objectType == typeof(T);
		}
		return true;
	}
}
