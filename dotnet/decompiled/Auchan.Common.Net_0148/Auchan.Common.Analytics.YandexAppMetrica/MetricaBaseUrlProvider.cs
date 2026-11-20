using Auchan.Common.Networking;

namespace Auchan.Common.Analytics.YandexAppMetrica;

internal class MetricaBaseUrlProvider : IEnvironmentBaseUrlProvider
{
	public string BaseUrlForEnvironment(Environment env)
	{
		return "https://api.appmetrica.yandex.com";
	}
}
