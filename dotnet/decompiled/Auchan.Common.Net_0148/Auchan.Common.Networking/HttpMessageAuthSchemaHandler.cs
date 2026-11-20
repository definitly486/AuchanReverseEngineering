using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Auchan.Common.Networking;

internal class HttpMessageAuthSchemaHandler : DelegatingHandler
{
	private readonly string _schema;

	public HttpMessageAuthSchemaHandler(string schema, HttpMessageHandler innerHandler)
		: base(innerHandler)
	{
		_schema = schema;
	}

	protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		AuthenticationHeaderValue authorization = request.Headers.Authorization;
		if (authorization != null && string.IsNullOrEmpty(authorization.Parameter) && !string.IsNullOrEmpty(authorization.Scheme))
		{
			request.Headers.Authorization = new AuthenticationHeaderValue(_schema, authorization.Scheme);
		}
		return base.SendAsync(request, cancellationToken);
	}
}
