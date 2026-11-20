using System;
using System.Collections.Generic;
using System.Linq;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;

namespace Auchan.Common.Analytics.YandexAppMetrica;

public interface IMetricaPlatformSdk
{
	void InitMetrica();

	void ReportError(Exception error, string? message = null, IReadOnlyDictionary<string, string>? environment = null);

	void ReportShowScreen(string screenName, string? storeAfilNumber = null, string? searchQuery = null);

	void ReportProductCardEvent(Product product, string screenName, string? storeAfilNumber = null, string? searchQuery = null);

	void ReportProductDetails(Product product, string screenName, string? storeAfilNumber = null, string? searchQuery = null);

	void ReportAddCartItem(ProductOffer product, decimal diff, string screenName, string? storeAfilNumber = null, string? searchQuery = null);

	void ReportRemoveCartItem(ProductOffer product, decimal diff, string screenName, string? storeAfilNumber = null, string? searchQuery = null);

	void ReportBeginCheckout(string orderNumber, IReadOnlyList<ProductOffer> products, string screenName, string storeAfilNumber, string receiveMethodId);

	void ReportPurchase(string orderNumber, IReadOnlyList<ProductOffer> products, string screenName, string storeAfilNumber, string receiveMethodId, string? coupon = null);

	void ReportAdRevenue(AdRevenue adRevenue);

	protected static string[] GetCategoryPath(ProductOffer product)
	{
		return (from i in product.CategoryCodes ?? new ReadOnlyEquatableList<CategoryCodeDto>()
			where !string.IsNullOrEmpty(i.Name)
			select i.Name).ToArray();
	}

	protected static string[] GetCategoryPath(Product product)
	{
		return (from i in product.CategoryCodes ?? Array.Empty<CategoryCodeDto>()
			where !string.IsNullOrEmpty(i.Name)
			select i.Name).ToArray();
	}
}
