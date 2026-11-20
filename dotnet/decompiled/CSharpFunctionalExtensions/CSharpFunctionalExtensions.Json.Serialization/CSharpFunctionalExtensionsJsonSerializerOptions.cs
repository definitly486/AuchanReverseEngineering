using System;
using System.Text.Json;

namespace CSharpFunctionalExtensions.Json.Serialization;

public static class CSharpFunctionalExtensionsJsonSerializerOptions
{
	private static readonly Lazy<JsonSerializerOptions> LazyOptions = new Lazy<JsonSerializerOptions>(delegate
	{
		JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
		jsonSerializerOptions.AddCSharpFunctionalExtensionsConverters();
		return jsonSerializerOptions;
	});

	public static JsonSerializerOptions Options => LazyOptions.Value;
}
