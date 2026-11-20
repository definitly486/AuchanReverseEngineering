using System.Collections.Generic;
using System.Linq;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Extensions;

namespace Auchan.Common.Ecom.Extensions;

internal static class ProductOfferExtensions
{
	public static ProductOffer CreateOffer(this Product product, decimal? qty = null, IReadOnlyList<SelectedModification>? modifications = null)
	{
		decimal num = qty ?? product.BasketStep;
		return new ProductOffer
		{
			Id = product.Id,
			ProductId = ProductIdHelper.TryGetProductId(product.ProductId),
			Qty = num,
			Name = (product.Title ?? product.Name ?? string.Empty),
			PricePerOne = (product.Price?.Value ?? 0m),
			Price = (product.Price?.Value ?? 0m),
			OldPrice = ((product.OldPrice == null) ? ((decimal?)null) : new decimal?(product.OldPrice.Value * num)),
			IsSaleActive = product.IsSaleActive,
			Discount = product.Discount,
			Weight = product.Weight,
			UnitType = (product.Price?.UnitType ?? ProductUnitType.Unit),
			BasketStep = product.BasketStep,
			ImageUrl = (product.MediaUrls?.FirstOrDefault() ?? product.ImageUrl),
			RealStock = (product.Stock?.Qty ?? 0m),
			CategoryCodes = (product.CategoryCodes?.ToReadOnlyEquatable() ?? new ReadOnlyEquatableList<CategoryCodeDto>()),
			Code = product.Code,
			GimaId = product.GimaId,
			IsAdult = product.IsAdult,
			IsNew = product.IsNew,
			Cashback = product.Cashback,
			Collectible = product.Collectible,
			PlusOnePromotion = product.PlusOnePromotion,
			Badges = product.Badges.ToReadOnlyEquatable(),
			SelectedModifications = (modifications?.ToReadOnlyEquatable() ?? new ReadOnlyEquatableList<SelectedModification>()),
			Comment = null,
			Tags = new ReadOnlyEquatableList<Tag>(),
			IsSelected = true,
			IsMarkedProduct = false,
			InCombo = product.InCombo,
			TotalDiscount = null
		};
	}
}
