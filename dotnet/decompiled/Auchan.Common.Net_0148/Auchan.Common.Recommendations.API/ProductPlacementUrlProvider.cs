using System;
using Auchan.Common.AdminTool;
using Auchan.Common.Networking;

namespace Auchan.Common.Recommendations.API;

public class ProductPlacementUrlProvider : IEnvironmentBaseUrlProvider, IEnvironmentBaseUrlProvider<IProductPlacementsApi>
{
	private readonly Lazy<IAdminContext> _adminContext;

	public ProductPlacementUrlProvider(Lazy<IAdminContext> adminContext)
	{
		_adminContext = adminContext;
	}

	public string BaseUrlForEnvironment(Auchan.Common.Networking.Environment env)
	{
		return "https://visitors-sp.retailrocket.ru/v1/partners/" + _adminContext.Value.AppConfig.RocketRetail.PartnerId;
	}
}
