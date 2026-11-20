using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using CSharpFunctionalExtensions;

namespace C2i.Common.C2iCSharpFunctionalExtensions.FunctionalApiResult;

internal class ResultOfTEJsonConverterFactory : JsonConverterFactory
{
	public override bool CanConvert(Type typeToConvert)
	{
		if (!typeToConvert.IsGenericType)
		{
			return false;
		}
		return typeToConvert.GetGenericTypeDefinition() == typeof(Result<, >);
	}

	public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
	{
		Type type = typeToConvert.GetGenericArguments()[0];
		Type type2 = typeToConvert.GetGenericArguments()[1];
		return Activator.CreateInstance(typeof(ResultOfTEJsonConverterConverterOfT<, >).MakeGenericType(type, type2)) as JsonConverter;
	}
}
