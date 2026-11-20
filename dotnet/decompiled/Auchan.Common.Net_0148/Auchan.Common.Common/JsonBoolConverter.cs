using System;
using Newtonsoft.Json;

namespace Auchan.Common.Common;

public class JsonBoolConverter : JsonConverter
{
	private const string YES_VALUE = "Y";

	public override bool CanWrite => false;

	public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
	{
		throw new NotImplementedException();
	}

	public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
	{
		object value = reader.Value;
		if (value == null)
		{
			return false;
		}
		if (value is bool flag)
		{
			return flag;
		}
		if (value is string text && "Y" == text)
		{
			return true;
		}
		return false;
	}

	public override bool CanConvert(Type objectType)
	{
		if (objectType == typeof(string) || objectType == typeof(bool))
		{
			return true;
		}
		return false;
	}
}
