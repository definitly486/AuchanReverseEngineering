using Auchan.Common.Networking;

namespace Auchan.Common.Ecom.Address;

public sealed class YandexMapUrlProvider : IEnvironmentBaseUrlProvider
{
	public string BaseUrlForEnvironment(Environment env)
	{
		return IEnvironmentBaseUrlProvider.BaseUrlForEnvironment(env, "https://www.auchan.ru", "https://front-preprod.ecom.auchan.ru", "https://front-stage-{0}.ecom.auchan.ru");
	}
}
