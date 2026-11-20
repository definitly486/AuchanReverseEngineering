using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Refit;

public class RefitSettings
{
	public Func<HttpRequestMessage, CancellationToken, Task<string>>? AuthorizationHeaderValueGetter { get; set; }

	public Func<HttpMessageHandler>? HttpMessageHandlerFactory { get; set; }

	public Func<HttpResponseMessage, Task<Exception?>> ExceptionFactory { get; set; }

	public Func<HttpResponseMessage, Exception, Task<Exception?>>? DeserializationExceptionFactory { get; set; }

	public IHttpContentSerializer ContentSerializer { get; set; }

	public IUrlParameterKeyFormatter UrlParameterKeyFormatter { get; set; }

	public IUrlParameterFormatter UrlParameterFormatter { get; set; }

	public IFormUrlEncodedParameterFormatter FormUrlEncodedParameterFormatter { get; set; }

	public CollectionFormat CollectionFormat { get; set; }

	public bool Buffered { get; set; }

	public Dictionary<string, object>? HttpRequestMessageOptions { get; set; }

	public Version Version { get; set; } = HttpVersion.Version11;

	public HttpVersionPolicy VersionPolicy { get; set; }

	public RefitSettings()
	{
		ContentSerializer = new SystemTextJsonContentSerializer();
		UrlParameterKeyFormatter = new DefaultUrlParameterKeyFormatter();
		UrlParameterFormatter = new DefaultUrlParameterFormatter();
		FormUrlEncodedParameterFormatter = new DefaultFormUrlEncodedParameterFormatter();
		ExceptionFactory = new DefaultApiExceptionFactory(this).CreateAsync;
	}

	public RefitSettings(IHttpContentSerializer contentSerializer, IUrlParameterFormatter? urlParameterFormatter, IFormUrlEncodedParameterFormatter? formUrlEncodedParameterFormatter)
		: this(contentSerializer, urlParameterFormatter, formUrlEncodedParameterFormatter, null)
	{
	}

	public RefitSettings(IHttpContentSerializer contentSerializer, IUrlParameterFormatter? urlParameterFormatter = null, IFormUrlEncodedParameterFormatter? formUrlEncodedParameterFormatter = null, IUrlParameterKeyFormatter? urlParameterKeyFormatter = null)
	{
		ContentSerializer = contentSerializer ?? throw new ArgumentNullException("contentSerializer", "The content serializer can't be null");
		UrlParameterFormatter = urlParameterFormatter ?? new DefaultUrlParameterFormatter();
		FormUrlEncodedParameterFormatter = formUrlEncodedParameterFormatter ?? new DefaultFormUrlEncodedParameterFormatter();
		UrlParameterKeyFormatter = urlParameterKeyFormatter ?? new DefaultUrlParameterKeyFormatter();
		ExceptionFactory = new DefaultApiExceptionFactory(this).CreateAsync;
	}
}
