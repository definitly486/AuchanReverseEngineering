using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Refit;

public interface IApiResponse<out T> : IApiResponse, IDisposable
{
	new ApiException? Error { get; }

	new HttpContentHeaders? ContentHeaders { get; }

	[MemberNotNullWhen(true, "ContentHeaders")]
	[MemberNotNullWhen(false, "Error")]
	new bool IsSuccessStatusCode
	{
		[MemberNotNullWhen(true, "ContentHeaders")]
		[MemberNotNullWhen(false, "Error")]
		get;
	}

	[MemberNotNullWhen(true, "Content")]
	[MemberNotNullWhen(true, "ContentHeaders")]
	[MemberNotNullWhen(false, "Error")]
	new bool IsSuccessful
	{
		[MemberNotNullWhen(true, "Content")]
		[MemberNotNullWhen(true, "ContentHeaders")]
		[MemberNotNullWhen(false, "Error")]
		get;
	}

	T? Content { get; }
}
public interface IApiResponse : IDisposable
{
	HttpResponseHeaders Headers { get; }

	HttpContentHeaders? ContentHeaders { get; }

	[MemberNotNullWhen(true, "ContentHeaders")]
	[MemberNotNullWhen(false, "Error")]
	bool IsSuccessStatusCode
	{
		[MemberNotNullWhen(true, "ContentHeaders")]
		[MemberNotNullWhen(false, "Error")]
		get;
	}

	[MemberNotNullWhen(true, "ContentHeaders")]
	[MemberNotNullWhen(false, "Error")]
	bool IsSuccessful
	{
		[MemberNotNullWhen(true, "ContentHeaders")]
		[MemberNotNullWhen(false, "Error")]
		get;
	}

	HttpStatusCode StatusCode { get; }

	string? ReasonPhrase { get; }

	HttpRequestMessage? RequestMessage { get; }

	Version Version { get; }

	ApiException? Error { get; }
}
