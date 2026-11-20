using Auchan.Common.Networking;

namespace Auchan.Common.Recommendations.API;

public class RecommendationsUrlProvider : IEnvironmentBaseUrlProvider, IEnvironmentBaseUrlProvider<IRecommendationApi>
{
	public string BaseUrlForEnvironment(Environment env)
	{
		return "https://externalapi.retailrocket.ru/api/3.0";
	}
}
