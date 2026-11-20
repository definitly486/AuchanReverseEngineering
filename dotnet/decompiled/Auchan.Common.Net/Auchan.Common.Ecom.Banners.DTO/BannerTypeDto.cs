using System.Runtime.Serialization;
using Auchan.Common.Common;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Banners.DTO;

[JsonConverter(typeof(EnumMemberJsonConverter<BannerTypeDto>))]
internal enum BannerTypeDto
{
	Unknown,
	[EnumMember(Value = "mob_app_first_slider")]
	FirstSlider,
	[EnumMember(Value = "mob_app_second_slider")]
	SecondSlider,
	[EnumMember(Value = "mob_app_third_slider")]
	ThirdSlider,
	[EnumMember(Value = "mob_app_loyalty")]
	Loyalty,
	[EnumMember(Value = "mob_app_my_offers")]
	MyOffers,
	[EnumMember(Value = "mob_app_digital_catalog")]
	DigitalCatalog,
	[EnumMember(Value = "mob_app_category_subcategory")]
	Category,
	[EnumMember(Value = "mob_app_brands")]
	Brands,
	[EnumMember(Value = "season_offers")]
	SeasonOffers,
	[EnumMember(Value = "mob_app_promotions_news")]
	PromotionNews,
	[EnumMember(Value = "additional_banner")]
	HomeAdditional,
	[EnumMember(Value = "loyalty_additional_banner")]
	LoyaltyAdditional,
	[EnumMember(Value = "mob_app_lk_reviews")]
	UserReviews
}
