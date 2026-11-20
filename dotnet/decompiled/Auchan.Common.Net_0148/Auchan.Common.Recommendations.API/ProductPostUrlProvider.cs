using Auchan.Common.Networking;

namespace Auchan.Common.Recommendations.API;

public class ProductPostUrlProvider : IEnvironmentBaseUrlProvider, IEnvironmentBaseUrlProvider<IProductPostApi>
{
	public string BaseUrlForEnvironment(Environment env)
	{
		return "https://cdn.retailrocket.ru/api/1.0/partner";
	}
}
