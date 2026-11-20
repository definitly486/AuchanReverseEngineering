namespace Auchan.Common.Recommendations;

public interface IRecommendationAnalyticsActionsFactory
{
	IRecommendationAnalyticsActions Get(RecomendationAnalyticActionsTag tag);

	GenericRecommendationAnalyticsActions GetGenericRecommendationAnalyticsActions();

	HorizontalAnalyticsActions GetHorizontalAnalyticsActions();

	PopularAnalyticsActions GetPopularAnalyticsActions();

	ProductPlacementsAnalyticsActions GetProductPlacementsAnalyticsActions();
}
