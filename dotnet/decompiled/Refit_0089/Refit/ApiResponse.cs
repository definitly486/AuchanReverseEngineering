using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Refit;

internal static class ApiResponse
{
	internal static T Create<T, TBody>(HttpResponseMessage resp, object? content, RefitSettings settings, ApiException? error = null)
	{
		return (T)Activator.CreateInstance(typeof(ApiResponse<TBody>), resp, content, settings, error);
	}
}
public sealed class ApiResponse<T> : IApiResponse<T>, IApiResponse, IDisposable
{
	private readonly HttpResponseMessage response = response ?? throw new ArgumentNullException("response");

	private bool disposed;

	public T? Content { get; }

	public RefitSettings Settings { get; }

	public HttpResponseHeaders Headers => response.Headers;

	public HttpContentHeaders? ContentHeaders => response.Content?.Headers;

	[MemberNotNullWhen(true, "ContentHeaders")]
	[MemberNotNullWhen(false, "Error")]
	public bool IsSuccessStatusCode
	{
		[MemberNotNullWhen(true, "ContentHeaders")]
		[MemberNotNullWhen(false, "Error")]
		get
		{
			return response.IsSuccessStatusCode;
		}
	}

	[MemberNotNullWhen(true, "Content")]
	[MemberNotNullWhen(true, "ContentHeaders")]
	[MemberNotNullWhen(false, "Error")]
	public bool IsSuccessful
	{
		[MemberNotNullWhen(true, "Content")]
		[MemberNotNullWhen(true, "ContentHeaders")]
		[MemberNotNullWhen(false, "Error")]
		get
		{
			if (IsSuccessStatusCode)
			{
				return Error == null;
			}
			return false;
		}
	}

	public string? ReasonPhrase => response.ReasonPhrase;

	public HttpRequestMessage? RequestMessage => response.RequestMessage;

	public HttpStatusCode StatusCode => response.StatusCode;

	public Version Version => response.Version;

	public ApiException? Error { get; private set; }

	public ApiResponse(HttpResponseMessage response, T? content, RefitSettings settings, ApiException? error = null)
	{
		Content = content;
		Settings = settings;
		Error = error;
		base._002Ector();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	public async Task<ApiResponse<T>> EnsureSuccessStatusCodeAsync()
	{
		if (!IsSuccessStatusCode)
		{
			await ThrowsApiExceptionAsync().ConfigureAwait(continueOnCapturedContext: false);
		}
		return this;
	}

	public async Task<ApiResponse<T>> EnsureSuccessfulAsync()
	{
		if (!IsSuccessful)
		{
			await ThrowsApiExceptionAsync().ConfigureAwait(continueOnCapturedContext: false);
		}
		return this;
	}

	private void Dispose(bool disposing)
	{
		if (disposing && !disposed)
		{
			disposed = true;
			response.Dispose();
		}
	}

	private async Task<ApiException> ThrowsApiExceptionAsync()
	{
		ApiException ex = Error;
		if (ex == null)
		{
			ex = await ApiException.Create(response.RequestMessage, response.RequestMessage.Method, response, Settings).ConfigureAwait(continueOnCapturedContext: false);
		}
		ApiException ex2 = ex;
		Dispose();
		throw ex2;
	}
}
