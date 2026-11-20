using System;
using System.Net.Http;

namespace Auchan.Common.Networking;

internal class EnvironmentHttpClient : HttpClient
{
	public EnvironmentHttpClient(IEnvironmentBaseUrlProvider environmentBaseUrlProvider, IEnvironmentManager environmentManager, HttpMessageHandler handler)
		: base(new EnvironmentBaseUrlHandler(environmentBaseUrlProvider, environmentManager, handler))
	{
		base.BaseAddress = new Uri("https://base_url_placeholder");
	}
}
