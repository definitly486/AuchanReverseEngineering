using Auchan.Common.Recommendations.Models;

namespace Auchan.Common.Recommendations;

internal static class IRecommendationAnalyticsActionsFactoryExtensions
{
	public static IRecommendationAnalyticsActions Get(this IRecommendationAnalyticsActionsFactory factory, ProductWithAnalyticsInfo pwa)
	{
		return factory.Get(pwa.Analytics.ActionsTag);
	}
}
