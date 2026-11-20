using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.PersonalCabinet;

namespace Auchan.Common.Networking;

internal sealed class AuthTokenHeaderMessageHandler : DelegatingHandler
{
	private const string TOKEN_HEADER_NAME = "X-Token-CMD";

	private readonly Lazy<ITokenService> _tokenService;

	public AuthTokenHeaderMessageHandler(CoreHttpMessageHandler innerHandler, Lazy<ITokenService> tokenService)
		: base(innerHandler)
	{
		_tokenService = tokenService;
	}

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		if (!request.Headers.Contains("X-Token-CMD"))
		{
			if (!(await _tokenService.Value.SavedToken80()).TryGetValue(out var value))
			{
				return new HttpResponseMessage(HttpStatusCode.Forbidden);
			}
			request.Headers.Add("X-Token-CMD", value.Token);
		}
		return await base.SendAsync(request, cancellationToken);
	}
}
