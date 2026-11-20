using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Auchan.Common.AdminTool;
using Auchan.Common.Common;
using Auchan.Common.Ecom;
using Auchan.Common.Networking;

namespace Auchan.Common.Recommendations.API;

internal sealed class ProductRequestInterceptor : DelegatingHandler
{
	private readonly IAdminContext _adminContext;

	private readonly IDeviceService _deviceService;

	private readonly IEcomContext _ecomContext;

	public ProductRequestInterceptor(IAdminContext adminContext, IDeviceService deviceService, IEcomContext ecomContext, CoreHttpMessageHandler innerHandler)
		: base(innerHandler)
	{
		_adminContext = adminContext;
		_deviceService = deviceService;
		_ecomContext = ecomContext;
	}

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		if (request.RequestUri == null)
		{
			throw new InvalidOperationException("request uri is not set");
		}
		UriBuilder uriBuilder = new UriBuilder(request.RequestUri);
		NameValueCollection query = HttpUtility.ParseQueryString(uriBuilder.Query);
		query.Add("apiKey", _adminContext.AppConfig?.RocketRetail.ApiKey ?? string.Empty);
		query.Add("partnerId", _adminContext.AppConfig?.RocketRetail.PartnerId ?? string.Empty);
		query.Add("link.name", "sessionExternalId");
		query.Add("link.value", _deviceService.Udid);
		NameValueCollection nameValueCollection = query;
		nameValueCollection.Add("stockId", (await _ecomContext.GetActiveStoreAsync()).Id.ToString());
		uriBuilder.Query = query.ToString();
		request.RequestUri = uriBuilder.Uri;
		return await base.SendAsync(request, cancellationToken);
	}
}
