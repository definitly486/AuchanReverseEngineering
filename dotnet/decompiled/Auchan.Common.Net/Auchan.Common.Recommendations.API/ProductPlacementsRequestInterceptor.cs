using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Auchan.Common.AdminTool;
using Auchan.Common.Common;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Networking;

namespace Auchan.Common.Recommendations.API;

internal class ProductPlacementsRequestInterceptor : DelegatingHandler
{
	private readonly Lazy<IAdminContext> _adminContext;

	private readonly Lazy<IDeviceService> _deviceService;

	private readonly Lazy<IEcomContext> _ecomContext;

	public ProductPlacementsRequestInterceptor(Lazy<IAdminContext> adminContext, Lazy<IDeviceService> deviceService, Lazy<IEcomContext> ecomContext, CoreHttpMessageHandler innerHandler)
		: base(innerHandler)
	{
		_adminContext = adminContext;
		_deviceService = deviceService;
		_ecomContext = ecomContext;
	}

	protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		Store store = await _ecomContext.Value.GetActiveStoreAsync();
		UriBuilder uriBuilder = new UriBuilder(request.RequestUri);
		NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(uriBuilder.Query);
		nameValueCollection.Add("apiKey", _adminContext.Value.AppConfig?.RocketRetail.ApiKey ?? string.Empty);
		nameValueCollection.Add("link.name", "sessionExternalId");
		nameValueCollection.Add("link.value", _deviceService.Value.Udid);
		nameValueCollection.Add("acceptContent", "sharedProductIds");
		nameValueCollection.Add("stockId", store.Id.ToString());
		nameValueCollection.Add("custom.geo", store.City.EcomId.ToString());
		uriBuilder.Query = nameValueCollection.ToString();
		request.RequestUri = uriBuilder.Uri;
		return await base.SendAsync(request, cancellationToken);
	}
}
