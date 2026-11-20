using Auchan.Common.Analytics.RocketRetail;
using Auchan.Common.Ecom.ProducModels.ViewModels;

namespace Auchan.Common.Recommendations;

public sealed class ProductPlacementsAnalyticsActions : IRecommendationAnalyticsActions
{
	private readonly IRocketRetailAnalytics _rocketRetailAnalytics;

	public ProductPlacementsAnalyticsActions(IRocketRetailAnalytics rocketRetailAnalytics)
	{
		_rocketRetailAnalytics = rocketRetailAnalytics;
	}

	public void OnProductCardShown(ProductItemViewModel pwa)
	{
		_rocketRetailAnalytics.ProductPlacementViewed(pwa);
	}

	public void OnAddedToCart(ProductItemViewModel pwa)
	{
		_rocketRetailAnalytics.ProductPlacementClicked(pwa);
	}

	public void OnNavigateToProductDetails(ProductItemViewModel pwa)
	{
		_rocketRetailAnalytics.ProductPlacementClicked(pwa);
	}

	public void OnAddedToFavorites(ProductItemViewModel pwa)
	{
		_rocketRetailAnalytics.ProductPlacementClicked(pwa);
	}

	public void OnQtyChangePopupShown(ProductItemViewModel pwa)
	{
		_rocketRetailAnalytics.ProductPlacementClicked(pwa);
	}
}
