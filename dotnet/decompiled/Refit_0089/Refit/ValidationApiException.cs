using System;
using System.Text.Json;

namespace Refit;

[Serializable]
public class ValidationApiException : ApiException
{
	private static readonly JsonSerializerOptions SerializerOptions;

	public new ProblemDetails? Content { get; private set; }

	static ValidationApiException()
	{
		SerializerOptions = new JsonSerializerOptions();
		SerializerOptions.PropertyNameCaseInsensitive = true;
		SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
		SerializerOptions.Converters.Add(new ObjectToInferredTypesConverter());
	}

	private ValidationApiException(ApiException apiException)
		: base(apiException.RequestMessage, apiException.HttpMethod, apiException.Content, apiException.StatusCode, apiException.ReasonPhrase, apiException.Headers, apiException.RefitSettings)
	{
	}

	public static ValidationApiException Create(ApiException exception)
	{
		if (exception == null)
		{
			throw new ArgumentNullException("exception");
		}
		if (string.IsNullOrWhiteSpace(exception.Content))
		{
			throw new ArgumentException("Content must be an 'application/problem+json' compliant json string.");
		}
		ValidationApiException ex = new ValidationApiException(exception);
		if (!string.IsNullOrWhiteSpace(exception.Content))
		{
			ex.Content = JsonSerializer.Deserialize<ProblemDetails>(exception.Content, SerializerOptions);
		}
		return ex;
	}
}
