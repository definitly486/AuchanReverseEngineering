using System;
using System.Collections.Generic;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Analytics;

public interface IEcomTracker
{
	void AddToCart(ProductOffer offer);

	void RemoveFromCart(ProductOffer offer);

	void ChangeQuantity(ProductOffer offer, decimal oldQty, decimal newQty);

	void ViewProductCellInListing(Product product, IYandexMetricaScreenViewModel screenViewModel);

	void ViewProduct(Product product, IReadOnlyList<string>? breadcrumbs);

	void ViewCategory(long categoryId);

	void ViewCategoryByPath(string categoryPath);

	void ViewCategoryListing(long categoryId, int page, string categoryName, IReadOnlyList<Product> products, IReadOnlyList<string> breadcrumbs);

	void Search(string query, params Product[] products);

	void OnResumedCartScreen(decimal total, decimal subtotal, Guid cartId, IReadOnlyList<ProductOffer> products);

	void OpenCheckoutScreen();

	void SuccessfulPurchase(Guid cartId, IReadOnlyList<OrderDetailsDto> orderDetails);

	void OpenEmptyCartScreenWithToCatalogueButton();

	void TrackEmptyCartFavoritesShown();

	void TrackEmptyCartRepeatLastOrderShown();

	void OnEmptyCartScreenToCatalogueClick();

	void OnEmptyCartScreenToFavoritesClick();

	void OnEmptyCartScreenRepeatLastOrderClick();

	void TrackPopUpCartUpdate();

	void TrackPopUpCartUpdateButtonChange();

	void TrackPopUpCartUpdateButtonCancel();

	void AddToFavorites(Product product);

	void AddToWaitList(Product product);
}
