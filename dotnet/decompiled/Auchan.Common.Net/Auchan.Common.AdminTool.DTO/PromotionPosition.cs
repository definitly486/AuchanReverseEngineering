using System.Runtime.Serialization;

namespace Auchan.Common.AdminTool.DTO;

public enum PromotionPosition
{
	[EnumMember(Value = "slider")]
	Slider,
	[EnumMember(Value = "second_slider")]
	SecondSlider,
	[EnumMember(Value = "third_slider")]
	ThirdSlider,
	[EnumMember(Value = "footer")]
	Body,
	[EnumMember(Value = "loyalty")]
	Loyalty,
	[EnumMember(Value = "my_offers")]
	MyOffers,
	[EnumMember(Value = "digital_catalog")]
	DigitalCatalog,
	[EnumMember(Value = "promotions_news")]
	PromotionsNews,
	[EnumMember(Value = "season_offers")]
	SeasonOffers,
	[EnumMember(Value = "category_subcategory")]
	CategorySubcategory,
	[EnumMember(Value = "brands")]
	Brands,
	[EnumMember(Value = "additional_banner")]
	HomeAdditionalBanner,
	[EnumMember(Value = "loyalty_additional_banner")]
	LoyaltyAdditionalBanner,
	Unknown
}
