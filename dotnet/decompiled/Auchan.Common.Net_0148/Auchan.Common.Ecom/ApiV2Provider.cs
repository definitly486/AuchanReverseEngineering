using Auchan.Common.Ecom.Cart;
using Auchan.Common.Networking;

namespace Auchan.Common.Ecom;

public sealed class ApiV2Provider : IEnvironmentBaseUrlProvider, IEnvironmentBaseUrlProvider<ICheckoutApiV2>
{
	public string BaseUrlForEnvironment(Environment env)
	{
		return IEnvironmentBaseUrlProvider.BaseUrlForEnvironment(env, "https://api-prod.ecom.auchan.ru/api/v2", "https://api-preprod.ecom.auchan.ru/api/v2", "https://api-stage-{0}.ecom.auchan.ru/api/v2");
	}
}
