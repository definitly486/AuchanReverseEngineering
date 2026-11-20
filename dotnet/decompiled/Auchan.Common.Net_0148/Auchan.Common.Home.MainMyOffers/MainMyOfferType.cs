using System.Runtime.Serialization;

namespace Auchan.Common.Home.MainMyOffers;

public enum MainMyOfferType
{
	[EnumMember(Value = "fav_category")]
	FavoriteCategories,
	[EnumMember(Value = "coupons")]
	Coupon,
	[EnumMember(Value = "offers")]
	PersonalOffer
}
