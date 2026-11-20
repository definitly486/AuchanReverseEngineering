using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Auchan.Common.Ecom.Badges;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.PriceChecker;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.Filters;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.Reviews.Model;

namespace Auchan.Common.Ecom.Products;

public static class Mapper
{
	public static ProductResult Map(this ProductResultDto dto)
	{
		bool isAdult = false;
		List<Product> list = new List<Product>(dto.Items.Count);
		foreach (ProductDto item in dto.Items)
		{
			if (item.IsAdult == true)
			{
				isAdult = true;
			}
			list.Add(item.Map());
		}
		return new ProductResult
		{
			Items = list,
			TotalCount = dto.Range,
			IsAdult = isAdult
		};
	}

	public static Product Map(this ProductDto dto, PriceCheckerChannel forChannel = PriceCheckerChannel.None)
	{
		Price price = null;
		Price price2 = null;
		Discount discount = null;
		if (forChannel == PriceCheckerChannel.Offline)
		{
			if (dto.OfflineDiscount != null)
			{
				price2 = dto.OfflinePrice?.Map() ?? new Price();
				price = new Price
				{
					Value = dto.OfflineDiscount.Value.Value,
					Currency = "RUB",
					UnitType = price2.UnitType
				};
				if (DateTime.TryParse(dto.OfflineDiscount.EndDate, out var result))
				{
					discount = new Discount
					{
						Value = price2.Value - price.Value,
						EndDate = result,
						ValueInPercent = dto.OfflineDiscount.ValueInPercent.GetValueOrDefault(),
						IsLoyaltyProgramDiscount = false
					};
				}
			}
			else
			{
				price = dto.OfflinePrice?.Map();
			}
		}
		else
		{
			price = dto.Price?.Map();
			price2 = dto.OldPrice?.Map();
			discount = dto.Discount?.Map();
		}
		Product obj = new Product
		{
			Id = (dto.Id ?? (-1)),
			ProductId = dto.ProductId,
			Code = dto.Code,
			Title = dto.Title,
			ShareUrl = dto.ShareUrl,
			CategoryCodes = dto.CategoryCodes,
			VendorCode = (dto.VendorCode ?? ""),
			Price = (price ?? new Price()),
			Stock = (dto.Stock?.Map() ?? new Stock()),
			IsActive = dto.IsActive,
			IsAdult = (dto.IsAdult == true),
			IsNew = dto.IsNew
		};
		int isSaleActive;
		if (dto.IsSaleActive == true)
		{
			if ((object)price2 == null)
			{
				isSaleActive = 0;
			}
			else
			{
				_ = price2.Value;
				isSaleActive = 1;
			}
		}
		else
		{
			isSaleActive = 0;
		}
		obj.IsSaleActive = (byte)isSaleActive != 0;
		obj.OldPrice = price2 ?? new Price();
		obj.MediaUrls = dto.MediaUrls ?? Array.Empty<string>();
		obj.Description = new Description
		{
			Content = (dto.Description?.Content ?? "")
		};
		obj.Characteristics = dto.Characteristics?.Select((CharacteristicDto item) => item.Map()).ToList() ?? new List<Characteristic>();
		obj.Brand = new BrandDto
		{
			Code = dto.Brand?.Code,
			Name = dto.Brand?.Name
		};
		obj.GimaId = dto.GimaId ?? "";
		obj.BasketStep = dto.BasketStep;
		obj.Discount = discount;
		obj.Collectible = dto.Collectible.Map();
		obj.Cashback = dto.Cashback?.Map();
		obj.EnergyValue = dto.EnergyValue?.Map();
		obj.Modifications = dto.Modifications.Map();
		obj.RegionalCategory = dto.RegionalCategory;
		obj.PlusOnePromotion = dto.PlusOnePromotion?.Map();
		obj.Gluings = dto.Gluings.Map();
		obj.Badges = dto.Badges.Map();
		obj.Rate = dto.Rate?.Map();
		obj.ReviewingIsAllowed = dto.ReviewingIsAllowed;
		obj.ReviewRewardSticker = dto.ReviewRewardSticker?.Map();
		obj.InWaitList = dto.InWaitList == true;
		obj.PackageDisplay = dto.PackageDisplay;
		obj.InCombo = dto.InCombo;
		obj.ProductsCertificate = (from url in dto.ProductsCertificate?.Where((string url) => !string.IsNullOrWhiteSpace(url))
			select new ProductCertificate(url)).ToList() ?? new List<ProductCertificate>();
		return obj;
	}

	public static ProductSortTypes? Map(this ProductSortTypesDto dto)
	{
		if (dto.Items != null)
		{
			return new ProductSortTypes
			{
				Items = (from sortTypeDto in dto.Items
					select new ProductSortType
					{
						SerialNumber = sortTypeDto.Serial,
						Name = sortTypeDto.Name,
						Field = sortTypeDto.Field,
						Direction = sortTypeDto.Direction
					} into i
					orderby i.SerialNumber
					select i).ToImmutableList()
			};
		}
		return null;
	}

	public static IReadOnlyList<Product> Map(this IEnumerable<ProductDto> dtos)
	{
		return dtos.Select((ProductDto p) => p.Map()).ToImmutableList();
	}

	public static CollectibleInfo? Map(this CollectibleInfoDto? dto)
	{
		if (dto == null)
		{
			return null;
		}
		return new CollectibleInfo
		{
			Stamps = dto.Stamps
		};
	}

	public static Characteristic Map(this CharacteristicDto dto)
	{
		if (dto == null)
		{
			return new Characteristic();
		}
		return new Characteristic
		{
			Id = dto.Id,
			Title = dto.Title,
			Value = dto.Value
		};
	}

	public static Auchan.Common.Ecom.ProducModels.Cashback? Map(this CashbackDto dto)
	{
		if (dto.Percent > 0)
		{
			return new Auchan.Common.Ecom.ProducModels.Cashback
			{
				Amount = dto.Percent.Value,
				CalculationType = CashbackCalculationType.Percent,
				Limit = (dto.Limit ?? 999m),
				LimitType = dto.LimitType.GetValueOrDefault(),
				Type = dto.GetCashbackType()
			};
		}
		if (dto.Point > 0)
		{
			return new Auchan.Common.Ecom.ProducModels.Cashback
			{
				Amount = dto.Point.Value,
				CalculationType = CashbackCalculationType.Points,
				Limit = (dto.Limit ?? 999m),
				LimitType = dto.LimitType.GetValueOrDefault(),
				Type = dto.GetCashbackType()
			};
		}
		return null;
	}

	private static CashbackType GetCashbackType(this CashbackDto @this)
	{
		if (@this.IsDelayed == true)
		{
			return CashbackType.Delayed;
		}
		if (@this.PointsType == CashbackDto.PointsTypeDto.Express)
		{
			return CashbackType.Express;
		}
		return CashbackType.Basic;
	}

	public static EnergyValue? Map(this EnergyValueDto? dto)
	{
		if (dto == null || (!dto.Calories.HasValue && !dto.Fats.HasValue && !dto.Carbs.HasValue && !dto.Proteins.HasValue))
		{
			return null;
		}
		return new EnergyValue
		{
			Proteins = dto.Proteins,
			Fats = dto.Fats,
			Carbs = dto.Carbs,
			Calories = dto.Calories
		};
	}

	public static IReadOnlyList<GluingProperty> Map(this IReadOnlyList<GluingDto> gluings)
	{
		return gluings.SelectMany((GluingDto g) => g.Properties.Select((GluingPropDto p) => new GluingProperty(g.Code, p.Name, p.Code, p.Value, p.SortOrder))).ToList();
	}

	public static IReadOnlyList<ProductModification> Map(this IReadOnlyList<ProductModificationDto> dto)
	{
		if (dto == null || !dto.Any())
		{
			return Array.Empty<ProductModification>();
		}
		return dto.Select((ProductModificationDto m) => new ProductModification
		{
			Code = m.Code,
			Name = m.Name,
			ViewType = m.ViewType,
			Values = m.Values.Select((ProductModificationValueDto v) => new ProductModificationValue
			{
				Description = v.Description,
				PreviewImageUrl = v.PreviewImageUrl,
				Key = v.Value,
				ImageUrls = v.ImageUrls.ToReadOnlyEquatable()
			}).ToImmutableList()
		}).ToImmutableList();
	}

	public static ProductFilterResult Map(this ProductFilterResponseDto @this)
	{
		return new ProductFilterResult
		{
			Filters = (@this.Filters?.Select((ProductFilterDto f) => f.Map()).ToImmutableList() ?? ImmutableList<ProductFilter>.Empty),
			RequiredRedirects = (@this.RequiredRedirectFor?.Select((RequestRedirectDto f) => f.Map()).ToImmutableList() ?? ImmutableList<RequestRedirect>.Empty),
			ProductCount = @this.ProductCounter,
			SelectedFilters = (@this.SelectedFilters ?? ImmutableDictionary<string, object>.Empty)
		};
	}

	public static ProductFilter Map(this ProductFilterDto @this)
	{
		return new ProductFilter
		{
			Name = @this.Name,
			Code = @this.Code,
			Url = @this.Url,
			Type = @this.Type,
			IsFixed = @this.IsFixed,
			IsUrlContain = @this.IsUrlContain,
			PositionInUrl = (@this.PositionInUrl ?? (-1)),
			Sort = @this.Sort,
			Min = @this.Min,
			Max = @this.Max,
			Disabled = @this.Disabled,
			IsForActive = @this.IsForActive,
			Items = (@this.Items?.Select((ProductResultFilterMultiItemDTO f) => f.Map()).ToImmutableList() ?? ImmutableList.Create(default(ReadOnlySpan<ProductFilterMultiItem>))),
			Informer = @this.Informer
		};
	}

	public static ProductFilterMultiItem Map(this ProductResultFilterMultiItemDTO @this)
	{
		return new ProductFilterMultiItem
		{
			Name = @this.Name,
			Code = @this.Code,
			Disabled = (@this.Disabled == true),
			IsForActive = @this.IsForActive,
			Counter = @this.Counter
		};
	}

	public static RequestRedirect Map(this RequestRedirectDto @this)
	{
		return new RequestRedirect
		{
			RedirectFrom = @this.RedirectFrom,
			RedirectTo = @this.RedirectTo
		};
	}

	public static PlusOnePromotion? Map(this PlusOnePromotionDto dto)
	{
		if (dto.Value.GetValueOrDefault() == 0)
		{
			return null;
		}
		return new PlusOnePromotion
		{
			Value = dto.Value,
			DateStart = dto.DateStart,
			DateEnd = dto.DateEnd
		};
	}

	public static IReadOnlyList<BadgeModel> Map(this IReadOnlyList<BadgeDto>? badges)
	{
		if (badges != null)
		{
			return (from i in badges
				where i.BadgeCode != ProductBadge.Unknown || !string.IsNullOrEmpty(i.ImageUrl)
				orderby i.Rank
				let bm = i.Map()
				where bm != null
				select bm).ToImmutableList();
		}
		return ImmutableList.Create(default(ReadOnlySpan<BadgeModel>));
	}

	public static BadgeModel? Map(this BadgeDto dto)
	{
		BadgeModel badgeModel = new BadgeModel
		{
			BadgeType = dto.BadgeCode.Map(),
			Rank = dto.Rank,
			ImageUrl = dto.ImageUrl,
			Description = dto.Description
		};
		switch (dto.BadgeCode)
		{
		default:
			return badgeModel;
		case ProductBadge.Cashback:
		{
			Auchan.Common.Ecom.ProducModels.Cashback cashback = dto.ParseMetadata<CashbackDto>()?.Map();
			if (cashback == null)
			{
				return null;
			}
			BadgeModel badgeModel2 = badgeModel._003CClone_003E_0024();
			BadgeModel badgeModel3 = badgeModel2;
			badgeModel3.BadgeType = cashback?.Type switch
			{
				CashbackType.Express => BadgeType.ExpressPoints, 
				CashbackType.Delayed => BadgeType.DelayedCashback, 
				_ => BadgeType.Cashback, 
			};
			badgeModel2.DisplayValue = $"{cashback?.Amount}%";
			return badgeModel2;
		}
		case ProductBadge.Discount:
		{
			Discount discount = dto.ParseMetadata<DiscountDto>()?.Map();
			return badgeModel with
			{
				DisplayValue = ((discount != null) ? $"-{discount.ValueInPercent}" : null)
			};
		}
		case ProductBadge.Stamps:
		{
			int num = (dto.ParseMetadata<CollectibleInfoDto>()?.Map())?.Stamps ?? 0;
			return badgeModel with
			{
				DisplayValue = $"+{num} {GrammarHelper.DeclineNoun(num, new string[3] { "марка", "марки", "марок" })} ",
				ShortDisplayValue = $"+{num}"
			};
		}
		case ProductBadge.NPlusOne:
		{
			PlusOnePromotion plusOnePromotion = dto.ParseMetadata<PlusOnePromotionDto>()?.Map();
			return badgeModel with
			{
				DisplayValue = $"{(((object)plusOnePromotion == null) ? ((int?)null) : (plusOnePromotion.Value + 1))} по цене {plusOnePromotion?.Value}",
				ShortDisplayValue = $"{(((object)plusOnePromotion == null) ? ((int?)null) : (plusOnePromotion.Value + 1))} за {plusOnePromotion?.Value}"
			};
		}
		case ProductBadge.PriceDown:
			return badgeModel with
			{
				DisplayValue = "цены\nвниз!"
			};
		case ProductBadge.NewProduct:
			return badgeModel with
			{
				DisplayValue = "новинка"
			};
		case ProductBadge.Combo:
			return badgeModel with
			{
				DisplayValue = "комбо"
			};
		case ProductBadge.ProgressiveDiscount1:
		case ProductBadge.ProgressiveDiscount2:
		{
			ProgressDiscountDto progressDiscountDto = dto.ParseMetadata<ProgressDiscountDto>();
			if (!(progressDiscountDto == null))
			{
				return badgeModel with
				{
					DisplayValue = $"-{progressDiscountDto.Value:F0}%",
					SecondLine = $"от {progressDiscountDto.Quantity:F0} шт"
				};
			}
			return null;
		}
		}
	}

	private static BadgeType Map(this ProductBadge @this)
	{
		return @this switch
		{
			ProductBadge.Cashback => BadgeType.Cashback, 
			ProductBadge.DelayedCashback => BadgeType.DelayedCashback, 
			ProductBadge.NPlusOne => BadgeType.NPlusOne, 
			ProductBadge.Discount => BadgeType.Discount, 
			ProductBadge.PriceDown => BadgeType.PriceDown, 
			ProductBadge.Stamps => BadgeType.Stamps, 
			ProductBadge.NewProduct => BadgeType.NewProduct, 
			ProductBadge.PrivateLabel => BadgeType.PrivateLabel, 
			ProductBadge.Combo => BadgeType.Combo, 
			ProductBadge.ProgressiveDiscount1 => BadgeType.ProgressiveDiscount, 
			ProductBadge.ProgressiveDiscount2 => BadgeType.ProgressiveDiscount, 
			_ => BadgeType.Unknown, 
		};
	}
}
