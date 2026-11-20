using Auchan.Common.Networking;

namespace Auchan.Common.Streams;

public class StreamBaseUrlProvider : IEnvironmentBaseUrlProvider
{
	public string BaseUrlForEnvironment(Environment env)
	{
		return "https://api.shopstory.live";
	}
}
