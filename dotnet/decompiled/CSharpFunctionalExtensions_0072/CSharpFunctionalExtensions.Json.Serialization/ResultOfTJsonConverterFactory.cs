using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpFunctionalExtensions.Json.Serialization;

internal class ResultOfTJsonConverterFactory : JsonConverterFactory
{
	public override bool CanConvert(Type typeToConvert)
	{
		if (!typeToConvert.IsGenericType)
		{
			return false;
		}
		return typeToConvert.GetGenericTypeDefinition() == typeof(Result<>);
	}

	public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
	{
		Type type = typeToConvert.GetGenericArguments()[0];
		return Activator.CreateInstance(typeof(ResultOfTJsonConverter<>).MakeGenericType(type)) as JsonConverter;
	}
}
