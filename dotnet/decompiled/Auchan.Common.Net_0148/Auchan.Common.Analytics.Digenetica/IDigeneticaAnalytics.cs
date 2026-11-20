using System;
using System.Collections.Generic;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Analytics.Digenetica;

public interface IDigeneticaAnalytics
{
	void ViewHome();

	void ViewProduct(Product product, IReadOnlyList<string>? breadcrumbs);

	void ViewProductsListing(long categoryId, int page, string categoryName, IReadOnlyList<Product> products, IReadOnlyList<string> breadcrumbs);

	void Search(string query, int page, IReadOnlyList<Product> products);

	void ViewCart(decimal total, decimal subtotal, Guid cartId, IReadOnlyList<ProductOffer> products);

	void OrderSuccess(Guid cartId, IReadOnlyList<OrderDetailsDto> orderDetails);
}
