using System.Text.Json;
using C2i.Common.C2iCSharpFunctionalExtensions.FunctionalApiResult;

namespace CSharpFunctionalExtensions.Json.Serialization;

public static class JsonSerializerOptionsExtensionMethods
{
	public static JsonSerializerOptions AddCSharpFunctionalExtensionsConverters(this JsonSerializerOptions options)
	{
		options.Converters.Add(new ResultJsonConverter());
		options.Converters.Add(new ResultOfTJsonConverterFactory());
		options.Converters.Add(new ResultOfTEJsonConverterFactory());
		options.Converters.Add(new UnitResultJsonConverterFactory());
		return options;
	}
}
