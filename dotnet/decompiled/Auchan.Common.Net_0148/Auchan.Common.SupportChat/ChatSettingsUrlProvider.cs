using Auchan.Common.Networking;

namespace Auchan.Common.SupportChat;

internal sealed class ChatSettingsUrlProvider : IEnvironmentBaseUrlProvider, IEnvironmentBaseUrlProvider<IChatSettingsApi>
{
	public string BaseUrlForEnvironment(Environment env)
	{
		return IEnvironmentBaseUrlProvider.BaseUrlForEnvironment(env, "https://mobile.auchan.ru/ecom", "https://api-preprod.ecom.auchan.ru/api/v2", "https://api-stage-{0}.ecom.auchan.ru/api/v2");
	}
}
