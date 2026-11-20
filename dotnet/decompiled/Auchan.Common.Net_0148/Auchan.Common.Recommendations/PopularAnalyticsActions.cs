using Auchan.Common.Ecom.ProducModels.ViewModels;

namespace Auchan.Common.Recommendations;

public sealed class PopularAnalyticsActions : IRecommendationAnalyticsActions
{
	private readonly RecommendationsTrackingRepository _trackingRepository;

	public PopularAnalyticsActions(RecommendationsTrackingRepository trackingRepository)
	{
		_trackingRepository = trackingRepository;
	}

	public void BlockViewed(string blockId)
	{
		_trackingRepository.RecommendationBlockViewed(blockId);
	}

	public void OnNavigateToProductDetails(ProductItemViewModel pwa)
	{
		_trackingRepository.RecommendationTap(pwa);
	}

	public void OnAddedToCart(ProductItemViewModel pwa)
	{
		_trackingRepository.AddedToCart(pwa);
	}
}
