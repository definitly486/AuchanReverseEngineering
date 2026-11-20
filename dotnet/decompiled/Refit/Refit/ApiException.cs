using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Refit;

[Serializable]
public class ApiException : Exception
{
	public HttpStatusCode StatusCode { get; }

	public string? ReasonPhrase { get; }

	public HttpResponseHeaders Headers { get; }

	public HttpMethod HttpMethod { get; }

	public Uri? Uri => RequestMessage.RequestUri;

	public HttpRequestMessage RequestMessage { get; }

	public HttpContentHeaders? ContentHeaders { get; private set; }

	public string? Content { get; private set; }

	[MemberNotNullWhen(true, "Content")]
	public bool HasContent
	{
		[MemberNotNullWhen(true, "Content")]
		get
		{
			return !string.IsNullOrWhiteSpace(Content);
		}
	}

	public RefitSettings RefitSettings { get; }

	protected ApiException(HttpRequestMessage message, HttpMethod httpMethod, string? content, HttpStatusCode statusCode, string? reasonPhrase, HttpResponseHeaders headers, RefitSettings refitSettings, Exception? innerException = null)
		: this(CreateMessage(statusCode, reasonPhrase), message, httpMethod, content, statusCode, reasonPhrase, headers, refitSettings, innerException)
	{
	}

	protected ApiException(string exceptionMessage, HttpRequestMessage message, HttpMethod httpMethod, string? content, HttpStatusCode statusCode, string? reasonPhrase, HttpResponseHeaders headers, RefitSettings refitSettings, Exception? innerException = null)
		: base(exceptionMessage, innerException)
	{
		RequestMessage = message;
		HttpMethod = httpMethod;
		StatusCode = statusCode;
		ReasonPhrase = reasonPhrase;
		Headers = headers;
		RefitSettings = refitSettings;
		Content = content;
	}

	public async Task<T?> GetContentAsAsync<T>()
	{
		return (!HasContent) ? default(T) : (await RefitSettings.ContentSerializer.FromHttpContentAsync<T>(new StringContent(Content)).ConfigureAwait(continueOnCapturedContext: false));
	}

	public static Task<ApiException> Create(HttpRequestMessage message, HttpMethod httpMethod, HttpResponseMessage response, RefitSettings refitSettings, Exception? innerException = null)
	{
		if (response != null && response.IsSuccessStatusCode)
		{
			throw new ArgumentException("Response is successful, cannot create an ApiException.", "response");
		}
		return Create(CreateMessage(response.StatusCode, response.ReasonPhrase), message, httpMethod, response, refitSettings, innerException);
	}

	public static async Task<ApiException> Create(string exceptionMessage, HttpRequestMessage message, HttpMethod httpMethod, HttpResponseMessage response, RefitSettings refitSettings, Exception? innerException = null)
	{
		ApiException exception = new ApiException(exceptionMessage, message, httpMethod, null, response.StatusCode, response.ReasonPhrase, response.Headers, refitSettings, innerException);
		if (response.Content == null)
		{
			return exception;
		}
		try
		{
			exception.ContentHeaders = response.Content.Headers;
			exception.Content = await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
			if (response.Content.Headers?.ContentType?.MediaType?.Equals("application/problem+json") == true)
			{
				exception = ValidationApiException.Create(exception);
			}
			response.Content.Dispose();
		}
		catch
		{
		}
		return exception;
	}

	private static string CreateMessage(HttpStatusCode statusCode, string? reasonPhrase)
	{
		return $"Response status code does not indicate success: {statusCode} ({reasonPhrase}).";
	}
}
