using Auchan.Common.Networking;

namespace Auchan.Common.Recommendations.API;

public class TrackingUrlProvider : IEnvironmentBaseUrlProvider, IEnvironmentBaseUrlProvider<ITrackingApi>
{
	public string BaseUrlForEnvironment(Environment env)
	{
		return "https://apptracking.retailrocket.ru/2.0";
	}
}
