using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Refit;

public sealed class NewtonsoftJsonContentSerializer : IHttpContentSerializer
{
	private readonly Lazy<JsonSerializerSettings> jsonSerializerSettings = new Lazy<JsonSerializerSettings>(() => jsonSerializerSettings ?? JsonConvert.DefaultSettings?.Invoke() ?? new JsonSerializerSettings());

	public NewtonsoftJsonContentSerializer(JsonSerializerSettings? jsonSerializerSettings)
	{
	}

	public HttpContent ToHttpContent<T>(T item)
	{
		return new StringContent(JsonConvert.SerializeObject(item, jsonSerializerSettings.Value), Encoding.UTF8, "application/json");
	}

	public async Task<T?> FromHttpContentAsync<T>(HttpContent content, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (content == null)
		{
			return default(T);
		}
		JsonSerializer serializer = JsonSerializer.Create(jsonSerializerSettings.Value);
		using Stream stream = await content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		using StreamReader reader = new StreamReader(stream);
		using JsonTextReader reader2 = new JsonTextReader(reader);
		return serializer.Deserialize<T>(reader2);
	}

	public string? GetFieldNameForProperty(PropertyInfo propertyInfo)
	{
		if ((object)propertyInfo == null)
		{
			throw new ArgumentNullException("propertyInfo");
		}
		return (from a in propertyInfo.GetCustomAttributes<JsonPropertyAttribute>(inherit: true)
			select a.PropertyName).FirstOrDefault();
	}
}
