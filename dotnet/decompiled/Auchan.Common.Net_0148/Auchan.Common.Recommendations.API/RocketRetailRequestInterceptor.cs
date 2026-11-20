using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Auchan.Common.AdminTool;
using Auchan.Common.Networking;

namespace Auchan.Common.Recommendations.API;

internal class RocketRetailRequestInterceptor : DelegatingHandler
{
	private readonly IAdminContext _adminContext;

	public RocketRetailRequestInterceptor(IAdminContext adminContext, CoreHttpMessageHandler innerHandler)
		: base(innerHandler)
	{
		_adminContext = adminContext;
	}

	protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		UriBuilder uriBuilder = new UriBuilder(request.RequestUri);
		NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(uriBuilder.Query);
		nameValueCollection.Add("apiKey", _adminContext.AppConfig?.RocketRetail.ApiKey ?? string.Empty);
		nameValueCollection.Add("partnerId", _adminContext.AppConfig?.RocketRetail.PartnerId ?? string.Empty);
		uriBuilder.Query = nameValueCollection.ToString();
		request.RequestUri = uriBuilder.Uri;
		return base.SendAsync(request, cancellationToken);
	}
}
