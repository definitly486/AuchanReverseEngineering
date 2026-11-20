using Auchan.Common.Analytics.RocketRetail;
using Auchan.Common.Ecom.ProducModels.ViewModels;

namespace Auchan.Common.Recommendations;

public sealed class HorizontalAnalyticsActions : IRecommendationAnalyticsActions
{
	private readonly IRocketRetailAnalytics _rocketRetailAnalytics;

	private readonly RecommendationsTrackingRepository _trackingRepository;

	public HorizontalAnalyticsActions(IRocketRetailAnalytics rocketRetailAnalytics, RecommendationsTrackingRepository trackingRepository)
	{
		_rocketRetailAnalytics = rocketRetailAnalytics;
		_trackingRepository = trackingRepository;
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
		_trackingRepository.AddedToCart(pwa);
	}
}
