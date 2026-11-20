using System;
using System.Collections.Generic;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Badges;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Extensions;

namespace Auchan.Common.Profile.Orders.Models;

public sealed class RepeatOrderProductModel(Product product)
{
	public decimal QtyInOrder { get; init; }

	public decimal QtyInStock => CartHelper.ComputeStock(product.Stock?.Qty ?? 0m, BasketStep, UnitType);

	public decimal Price => product.Price?.Value ?? 0m;

	public bool IsAvailable => QtyInStock != 0m;

	public string ImagePath { get; init; } = string.Empty;

	public string Title { get; init; } = string.Empty;

	public ProductUnitType UnitType => product.Price?.UnitType ?? ProductUnitType.Unit;

	public decimal BasketStep => product.BasketStep;

	public IReadOnlyList<ListItemModificationValueViewModel> SelectedModifications { get; init; } = Array.Empty<ListItemModificationValueViewModel>();

	public IReadOnlyList<SelectedModification> OriginalSelectedModifications { get; init; } = Array.Empty<SelectedModification>();

	public ProductOffer GetProductOffer(decimal qtyValue)
	{
		return new ProductOffer
		{
			Id = product.Id,
			ProductId = Convert.ToInt64(product.ProductId),
			Qty = qtyValue,
			Name = Title,
			PricePerOne = Price,
			Price = 0m,
			OldPrice = null,
			IsSaleActive = false,
			Discount = null,
			Weight = 0m,
			ImageUrl = null,
			RealStock = QtyInStock,
			CategoryCodes = new ReadOnlyEquatableList<CategoryCodeDto>(),
			UnitType = UnitType,
			BasketStep = BasketStep,
			Code = string.Empty,
			GimaId = (product.GimaId ?? ""),
			IsAdult = false,
			IsNew = false,
			SelectedModifications = OriginalSelectedModifications.ToReadOnlyEquatable(),
			Cashback = null,
			Collectible = null,
			PlusOnePromotion = null,
			Badges = new ReadOnlyEquatableList<BadgeModel>(),
			Comment = null,
			Tags = new ReadOnlyEquatableList<Tag>(),
			IsSelected = true,
			IsMarkedProduct = false,
			InCombo = product.InCombo,
			TotalDiscount = null
		};
	}

	public Product GetProduct()
	{
		return product;
	}
}
