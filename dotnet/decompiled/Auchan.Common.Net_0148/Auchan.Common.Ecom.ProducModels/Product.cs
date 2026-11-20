using System;
using System.Collections.Generic;
using Auchan.Common.Ecom.Badges;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Reviews.Model;

namespace Auchan.Common.Ecom.ProducModels;

public class Product
{
	private decimal _basketStep;

	public string? ProductId { get; set; }

	public int Id { get; set; }

	public string? Name { get; set; }

	public string? Title { get; set; }

	public string? ShareUrl { get; set; }

	public string? Code { get; set; }

	public string? Icon { get; set; }

	public string? BrandName { get; set; }

	public string? CategoryName { get; set; }

	public IReadOnlyList<CategoryCodeDto>? CategoryCodes { get; set; }

	public string? Type { get; set; }

	public string? Rating { get; set; }

	public IReadOnlyList<object>? Tags { get; set; }

	public decimal Weight { get; set; }

	public bool IsNew { get; set; }

	public bool IsActive { get; set; }

	public bool IsAdult { get; set; }

	public bool IsSaleActive { get; set; }

	public Stock? Stock { get; set; }

	public Price? Price { get; set; }

	public Cashback? Cashback { get; set; }

	public CollectibleInfo? Collectible { get; set; }

	public Price? OldPrice { get; set; }

	public string? ImageUrl { get; set; }

	public string? VendorCode { get; set; }

	public IReadOnlyList<string> MediaUrls { get; set; } = Array.Empty<string>();

	public Description? Description { get; set; }

	public IReadOnlyList<Characteristic>? Characteristics { get; set; }

	public BrandDto? Brand { get; set; }

	public string? GimaId { get; set; }

	public int? GimaIdInt
	{
		get
		{
			int result;
			return int.TryParse(GimaId, out result) ? result : 0;
		}
	}

	public bool InStock
	{
		get
		{
			Stock? stock = Stock;
			if ((object)stock == null)
			{
				return false;
			}
			return stock.Qty > default(decimal);
		}
	}

	public decimal BasketStep
	{
		get
		{
			return _basketStep;
		}
		set
		{
			_basketStep = ((value == 0m) ? 1m : value);
		}
	}

	public Discount? Discount { get; set; }

	public EnergyValue? EnergyValue { get; set; }

	public IReadOnlyList<ProductModification> Modifications { get; set; } = Array.Empty<ProductModification>();

	public bool? RegionalCategory { get; set; }

	public Rate? Rate { get; set; }

	public bool ReviewingIsAllowed { get; set; }

	public ReviewRewardSticker? ReviewRewardSticker { get; set; }

	public IReadOnlyList<GluingProperty> Gluings { get; set; } = Array.Empty<GluingProperty>();

	public IReadOnlyList<BadgeModel> Badges { get; set; } = Array.Empty<BadgeModel>();

	public PlusOnePromotion? PlusOnePromotion { get; set; }

	public bool InWaitList { get; set; }

	public string? PackageDisplay { get; set; }

	public bool InCombo { get; init; }

	public decimal LastKnownStock => CartHelper.ComputeStock(Stock?.Qty ?? 0m, BasketStep, Price?.UnitType ?? ProductUnitType.Unit);

	public IReadOnlyList<ProductCertificate> ProductsCertificate { get; init; } = Array.Empty<ProductCertificate>();
}
