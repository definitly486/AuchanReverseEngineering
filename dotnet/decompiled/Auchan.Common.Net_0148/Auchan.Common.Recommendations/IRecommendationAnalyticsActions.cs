using Auchan.Common.Ecom.ProducModels.ViewModels;

namespace Auchan.Common.Recommendations;

public interface IRecommendationAnalyticsActions
{
	void BlockViewed(string blockId)
	{
	}

	void OnNavigateToProductDetails(ProductItemViewModel pwa)
	{
	}

	void OnAddedToCart(ProductItemViewModel pwa)
	{
	}

	void OnAddedToFavorites(ProductItemViewModel pwa)
	{
	}

	void OnQtyChangePopupShown(ProductItemViewModel pwa)
	{
	}

	void OnProductCardShown(ProductItemViewModel pwa)
	{
	}
}
