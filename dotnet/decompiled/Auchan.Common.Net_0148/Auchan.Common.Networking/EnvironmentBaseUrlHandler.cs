using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Logs;
using DryIoc;

namespace Auchan.Common.Networking;

internal class EnvironmentBaseUrlHandler : DelegatingHandler
{
	public const string BaseUrlPlaceholder = "https://base_url_placeholder";

	private readonly IEnvironmentBaseUrlProvider _environmentBaseUrlProvider;

	private readonly IEnvironmentManager _environmentManager;

	public EnvironmentBaseUrlHandler(IEnvironmentBaseUrlProvider environmentBaseUrlProvider, IEnvironmentManager environmentManager, HttpMessageHandler innerHandler)
		: base(innerHandler)
	{
		_environmentBaseUrlProvider = environmentBaseUrlProvider;
		_environmentManager = environmentManager;
	}

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		Uri? requestUri = request.RequestUri;
		if ((object)requestUri != null && !requestUri.AbsoluteUri.Contains("https://base_url_placeholder"))
		{
			throw new ArgumentException("Request should have EnvironmentBaseUrlHandler.BaseUrlPlaceholder instead of its base url", "request");
		}
		string newValue = await _environmentBaseUrlProvider.BaseUrlForEnvironmentAsync(_environmentManager.CurrentEnvironment);
		request.RequestUri = new Uri(request.RequestUri?.AbsoluteUri.Replace("https://base_url_placeholder", newValue));
		ILogService logService = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<ILogService>();
		RequestLoggingProcessor processor = new RequestLoggingProcessor(logService);
		return await Task.Run(() => processor.SendRequestWithLogging((HttpRequestMessage req) => base.SendAsync(req, cancellationToken), request));
	}
}
