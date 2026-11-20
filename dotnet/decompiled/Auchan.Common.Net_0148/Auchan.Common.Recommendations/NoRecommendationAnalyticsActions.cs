namespace Auchan.Common.Recommendations;

public sealed class NoRecommendationAnalyticsActions : IRecommendationAnalyticsActions
{
	public static NoRecommendationAnalyticsActions Instance { get; } = new NoRecommendationAnalyticsActions();
}
