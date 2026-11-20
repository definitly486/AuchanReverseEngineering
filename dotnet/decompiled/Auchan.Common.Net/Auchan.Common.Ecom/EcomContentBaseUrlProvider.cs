using Auchan.Common.AdminTool;
using Auchan.Common.Ecom.Banners;
using Auchan.Common.Ecom.Onboardings.Infrastructure;
using Auchan.Common.Networking;

namespace Auchan.Common.Ecom;

public class EcomContentBaseUrlProvider : IEnvironmentBaseUrlProvider, IEnvironmentBaseUrlProvider<IStampsApi>, IEnvironmentBaseUrlProvider<IBannersApi>, IEnvironmentBaseUrlProvider<IOnbardingsApi>
{
	public string BaseUrlForEnvironment(Environment env)
	{
		return IEnvironmentBaseUrlProvider.BaseUrlForEnvironment(env, "https://mobile.auchan.ru/ecom/content", "https://mobile-preprod.ecom.auchan.ru/ecom/content", "https://mobile-stage-{0}.ecom.auchan.ru/ecom/content");
	}
}
