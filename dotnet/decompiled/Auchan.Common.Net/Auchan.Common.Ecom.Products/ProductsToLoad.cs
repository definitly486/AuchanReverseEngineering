using System.Runtime.Serialization;

namespace Auchan.Common.Ecom.Products;

public enum ProductsToLoad
{
	[EnumMember(Value = "by_category")]
	ByCategory,
	[EnumMember(Value = "by_brand")]
	ByBrand,
	[EnumMember(Value = "promo_only")]
	ByPromoOnly,
	[EnumMember(Value = "cashback_available")]
	ByCashbackAvailable
}
