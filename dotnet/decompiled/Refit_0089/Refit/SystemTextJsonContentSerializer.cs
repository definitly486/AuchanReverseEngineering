using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Refit;

public sealed class SystemTextJsonContentSerializer : IHttpContentSerializer
{
	private readonly JsonSerializerOptions jsonSerializerOptions;

	public SystemTextJsonContentSerializer()
		: this(GetDefaultJsonSerializerOptions())
	{
	}

	public SystemTextJsonContentSerializer(JsonSerializerOptions jsonSerializerOptions)
	{
		this.jsonSerializerOptions = jsonSerializerOptions;
	}

	public HttpContent ToHttpContent<T>(T item)
	{
		return JsonContent.Create(item, null, jsonSerializerOptions);
	}

	public async Task<T?> FromHttpContentAsync<T>(HttpContent content, CancellationToken cancellationToken = default(CancellationToken))
	{
		return await content.ReadFromJsonAsync<T>(jsonSerializerOptions, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}

	public string? GetFieldNameForProperty(PropertyInfo propertyInfo)
	{
		if ((object)propertyInfo == null)
		{
			throw new ArgumentNullException("propertyInfo");
		}
		return (from a in propertyInfo.GetCustomAttributes<JsonPropertyNameAttribute>(inherit: true)
			select a.Name).FirstOrDefault();
	}

	public static JsonSerializerOptions GetDefaultJsonSerializerOptions()
	{
		return new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true,
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			Converters = 
			{
				(JsonConverter)new ObjectToInferredTypesConverter(),
				(JsonConverter)new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
			}
		};
	}
}
