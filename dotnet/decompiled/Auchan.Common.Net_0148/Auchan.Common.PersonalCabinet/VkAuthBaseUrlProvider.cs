using Auchan.Common.Networking;

namespace Auchan.Common.PersonalCabinet;

internal sealed class VkAuthBaseUrlProvider : IEnvironmentBaseUrlProvider, IEnvironmentBaseUrlProvider<IVkAuthApi>
{
	public string BaseUrlForEnvironment(Environment env)
	{
		return IEnvironmentBaseUrlProvider.BaseUrlForEnvironment(env, "https://mobile.auchan.ru/ecom/social/vk/clientauth", "https://mobile-preprod.ecom.auchan.ru/ecom/social/vk/clientauth", "https://mobile-stage-{0}.ecom.auchan.ru/ecom/social/vk/clientauth");
	}
}
