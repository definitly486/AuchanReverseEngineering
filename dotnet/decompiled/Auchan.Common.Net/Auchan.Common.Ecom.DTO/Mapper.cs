using System;
using System.Collections.Generic;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Profile;
using Auchan.Common.Reviews.Model;

namespace Auchan.Common.Ecom.DTO;

public static class Mapper
{
	public static CategoryWithProduct Map(this CategoryWithProductDto dto)
	{
		bool isAdult = false;
		List<Product> list = new List<Product>((dto?.Products?.Count).GetValueOrDefault());
		if (dto?.Products != null)
		{
			foreach (ProductSearchDto product in dto.Products)
			{
				if (product.IsAdult == true)
				{
					isAdult = true;
				}
				list.Add(product.Map());
			}
		}
		return new CategoryWithProduct
		{
			Name = (dto?.Name ?? string.Empty),
			ParentCategoryCode = (dto?.ParentCategoryCode ?? string.Empty),
			ParentCategoryName = (dto?.ParentCategoryName ?? string.Empty),
			Products = list,
			IsAdult = isAdult
		};
	}

	public static Product Map(this FavoriteProductDto dto)
	{
		return new Product
		{
			CategoryCodes = dto.CategoryCodes,
			Code = dto.Code,
			Id = Convert.ToInt32(dto.Id ?? (-1)),
			GimaId = (dto.GimaId ?? (-1)).ToString(),
			IsAdult = (dto.IsAdult == true),
			IsNew = dto.IsNew,
			IsSaleActive = (dto.SaleActive == true),
			Name = dto.Title,
			Title = dto.Title,
			ProductId = dto.ProductId,
			MediaUrls = (dto.MediaUrls ?? Array.Empty<string>()),
			BasketStep = (dto.BasketStep ?? (-1m)),
			ImageUrl = dto.CatalogImageUrl,
			Price = dto.Price?.Map(),
			OldPrice = dto.OldPrice?.Map(),
			Stock = dto.Stock?.Map(),
			Discount = dto.Discount?.Map(),
			Cashback = dto.Cashback?.Map(),
			Collectible = dto.Collectible?.Map(),
			PlusOnePromotion = dto.PlusOnePromotion?.Map(),
			Rate = dto.Rate?.Map(),
			InWaitList = (dto.InWaitList == true),
			Badges = dto.Badges.Map(),
			PackageDisplay = dto.PackageDisplay,
			InCombo = dto.InCombo
		};
	}

	public static Product Map(this ProductSearchDto dto)
	{
		return new Product
		{
			BrandName = dto.BrandName,
			CategoryName = dto.CategoryName,
			Code = dto.Code,
			Icon = dto.Icon,
			Id = dto.Id,
			GimaId = dto.GimaId,
			IsActive = dto.IsActive,
			IsAdult = (dto.IsAdult == true),
			IsNew = dto.IsNew,
			IsSaleActive = dto.IsSaleActive,
			Name = dto.Name,
			Title = dto.Name,
			ProductId = dto.ProductId,
			Rating = dto.Rating,
			Tags = dto.Tags,
			Type = dto.Type,
			MediaUrls = (dto.MediaUrls ?? Array.Empty<string>()),
			Weight = dto.Weight,
			BasketStep = dto.BasketStep,
			ImageUrl = dto.ImageUrl,
			Price = dto.Price?.Map(),
			OldPrice = dto.OldPrice?.Map(),
			Stock = dto.Stock?.Map(),
			Discount = dto.Discount?.Map(),
			Cashback = dto.Cashback?.Map(),
			Modifications = dto.Modifications.Map(),
			Rate = dto.Rate?.Map(),
			Collectible = dto.Collectible?.Map(),
			PlusOnePromotion = dto.PlusOnePromotion?.Map(),
			Badges = dto.Badges.Map(),
			PackageDisplay = dto.PackageDisplay,
			InCombo = dto.InCombo
		};
	}

	public static AvailableShop Map(this AvailableShopsDto dto)
	{
		AvailableShop obj = new AvailableShop
		{
			Name = dto.Name,
			Id = dto.Id,
			AddressString = dto.AddressString,
			Applied = dto.Applied,
			Qty = dto.Qty,
			Working = dto.Working
		};
		decimal? qty = dto.Qty;
		decimal num = 2;
		obj.IsLessOrEqualTwo = (qty.GetValueOrDefault() <= num) & qty.HasValue;
		qty = dto.Qty;
		num = 2;
		obj.QtyText = (((qty.GetValueOrDefault() <= num) & qty.HasValue) ? $"Осталось {dto.Qty} шт" : $"В наличии: {dto.Qty} шт");
		return obj;
	}

	public static Product Map(this ProductOffer dto)
	{
		return new Product
		{
			CategoryCodes = dto.CategoryCodes,
			Code = dto.Code,
			GimaId = dto.GimaId,
			IsAdult = dto.IsAdult,
			IsSaleActive = dto.IsSaleActive,
			Name = dto.Name,
			Title = dto.Name,
			Weight = dto.Weight,
			BasketStep = dto.BasketStep,
			ImageUrl = dto.ImageUrl,
			Badges = dto.Badges,
			InCombo = dto.InCombo
		};
	}

	public static Price Map(this PriceDto dto)
	{
		if (dto == null)
		{
			return new Price();
		}
		return new Price
		{
			Value = dto.Value.Value,
			Currency = dto.Currency,
			UnitType = dto.UnitType.Value
		};
	}

	public static Price Map(this FavoritePriceDto dto)
	{
		if (dto == null)
		{
			return new Price();
		}
		return new Price
		{
			Value = (dto.Value ?? (-1m)),
			Currency = dto.Currency,
			UnitType = dto.UnitType.GetValueOrDefault()
		};
	}

	public static Stock Map(this StockDto dto)
	{
		if (dto == null)
		{
			return new Stock();
		}
		List<AvailableShop> list = new List<AvailableShop>();
		if (dto?.Shops != null)
		{
			foreach (AvailableShopsDto shop in dto.Shops)
			{
				list.Add(shop.Map());
			}
		}
		return new Stock
		{
			Qty = dto.Qty.Value,
			StoreId = dto.StoreId.Value,
			PriceFrom = dto.PriceFrom,
			NotAvailable = dto.NotAvailable,
			Shops = list
		};
	}

	public static Discount? Map(this DiscountDto? dto)
	{
		if (dto == null)
		{
			return null;
		}
		if (DateTime.TryParse(dto.EndDate, out var result))
		{
			return new Discount
			{
				Value = dto.Value.Value,
				ValueInPercent = dto.ValueInPercent.Value,
				EndDate = result,
				IsLoyaltyProgramDiscount = dto.IsLoyaltyProgramDiscount
			};
		}
		return null;
	}
}
