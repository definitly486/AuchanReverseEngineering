using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Auchan.Common.SupportChat.DTO;

internal class WSDataDTOJsonConverter : JsonConverter
{
	public override bool CanWrite => false;

	public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
	{
		throw new NotImplementedException();
	}

	public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
	{
		return ReadDataToken(JToken.Load(reader), serializer);
	}

	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(WSDataDTO);
	}

	private static WSDataDTO ReadDataToken(JToken token, JsonSerializer serializer)
	{
		if (token.Type == JTokenType.Null)
		{
			throw new JsonSerializationException("Support chat: Data is null");
		}
		if (token.Type == JTokenType.Object)
		{
			return token.ToObject<WSDataDTO>(serializer) ?? throw new JsonSerializationException("Support chat: Could not deserialize data");
		}
		if (token.Type == JTokenType.String)
		{
			return ReadDataString(token.Value<string>(), serializer);
		}
		throw new JsonSerializationException($"Support chat: Unsupported data token type: {token.Type}");
	}

	private static WSDataDTO ReadDataString(string? data, JsonSerializer serializer)
	{
		if (string.IsNullOrWhiteSpace(data))
		{
			throw new JsonSerializationException("Support chat: Data is empty");
		}
		string text = data;
		for (int i = 0; i < 3; i++)
		{
			try
			{
				JToken jToken = JToken.Parse(text);
				if (jToken.Type == JTokenType.Object)
				{
					return jToken.ToObject<WSDataDTO>(serializer) ?? throw new JsonSerializationException("Support chat: Could not deserialize data");
				}
				if (jToken.Type == JTokenType.String)
				{
					text = jToken.Value<string>();
					if (string.IsNullOrWhiteSpace(text))
					{
						throw new JsonSerializationException("Support chat: Data is empty");
					}
					continue;
				}
				throw new JsonSerializationException($"Support chat: Unsupported data token type: {jToken.Type}");
			}
			catch (JsonReaderException)
			{
				string text2 = TryReadJsonString(text);
				if (string.IsNullOrWhiteSpace(text2) || text2 == text)
				{
					throw;
				}
				text = text2;
			}
		}
		throw new JsonSerializationException("Support chat: Could not deserialize data");
	}

	private static string? TryReadJsonString(string data)
	{
		try
		{
			return JsonConvert.DeserializeObject<string>("\"" + data + "\"");
		}
		catch (JsonReaderException)
		{
			return null;
		}
	}
}
