using Auchan.Common.Analytics.RocketRetail;
using Auchan.Common.Ecom.ProducModels.ViewModels;

namespace Auchan.Common.Recommendations;

public sealed class GenericRecommendationAnalyticsActions : IRecommendationAnalyticsActions
{
	private readonly IRocketRetailAnalytics _rocketRetailAnalytics;

	public GenericRecommendationAnalyticsActions(IRocketRetailAnalytics rocketRetailAnalytics)
	{
		_rocketRetailAnalytics = rocketRetailAnalytics;
	}

	public void BlockViewed(string blockId)
	{
		_rocketRetailAnalytics.RecommendationBlockViewed(blockId);
	}

	public void OnNavigateToProductDetails(ProductItemViewModel pwa)
	{
		_rocketRetailAnalytics.RecommendationTap(pwa);
	}

	public void OnAddedToCart(ProductItemViewModel pwa)
	{
		_rocketRetailAnalytics.RecommendationAddedToBasket(pwa);
	}
}
