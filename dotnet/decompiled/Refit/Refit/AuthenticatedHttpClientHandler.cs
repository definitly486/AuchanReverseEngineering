using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Refit;

internal class AuthenticatedHttpClientHandler : DelegatingHandler
{
	private readonly Func<HttpRequestMessage, CancellationToken, Task<string>> getToken;

	public AuthenticatedHttpClientHandler(Func<HttpRequestMessage, CancellationToken, Task<string>> getToken, HttpMessageHandler? innerHandler = null)
		: base(innerHandler ?? new HttpClientHandler())
	{
		this.getToken = getToken ?? throw new ArgumentNullException("getToken");
	}

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		AuthenticationHeaderValue auth = request.Headers.Authorization;
		if (auth != null)
		{
			string parameter = await getToken(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, parameter);
		}
		return await base.SendAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
	}
}
