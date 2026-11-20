using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Recommendations;

namespace Auchan.Common.Ecom.CtmShelves;

internal sealed class CtmShelfAnalyticsActions : IRecommendationAnalyticsActions
{
	private readonly AppMetrica _appMetrica;

	public CtmShelfAnalyticsActions(AppMetrica appMetrica)
	{
		_appMetrica = appMetrica;
	}

	public void OnAddedToCart(ProductItemViewModel pwa)
	{
		_appMetrica.TrackCtmShelfMonetization("addToCart", pwa);
	}

	public void OnNavigateToProductDetails(ProductItemViewModel pwa)
	{
		_appMetrica.TrackCtmShelfMonetization("clickOnCard", pwa);
	}
}
