using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Analytics.Loymax;

public interface ILoymaxAnalyticsService
{
	void AddToCart(ProductOffer offer);

	void AddToFavorites(Product product);

	void AddToWaitList(Product product);

	void MerchantSelection(Store store);

	void RemoveFromCart(ProductOffer offer);

	void UserLogin();

	void ViewCategory(long categoryId);

	void ViewProduct(Product product);

	void ViewUnavailableProduct(Product product);
}
