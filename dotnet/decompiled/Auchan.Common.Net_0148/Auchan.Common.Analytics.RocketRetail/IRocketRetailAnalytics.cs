using System.Collections.Generic;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;

namespace Auchan.Common.Analytics.RocketRetail;

public interface IRocketRetailAnalytics
{
	void ViewProduct(Product product);

	void AddToCart(ProductOffer offer);

	void Order(IReadOnlyList<OrderDetailsDto> orderDetails);

	void ViewCategory(long categoryId);

	void ViewCategoryByPath(string categoryPath);

	void Search(string query);

	void RecommendationTap(ProductItemViewModel recomItem);

	void RecommendationAddedToBasket(ProductItemViewModel recomItem);

	void RecommendationBlockViewed(string blockId);

	void ProductPlacementViewed(ProductItemViewModel recomItem);

	void ProductPlacementClicked(ProductItemViewModel recomItem);
}
