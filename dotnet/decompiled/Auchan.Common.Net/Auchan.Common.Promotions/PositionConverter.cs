using Auchan.Common.AdminTool.DTO;

namespace Auchan.Common.Promotions;

public static class PositionConverter
{
	public static PromotionPosition FromStringToPromotionPosition(string? position)
	{
		return position switch
		{
			"slider" => PromotionPosition.Slider, 
			"second_slider" => PromotionPosition.SecondSlider, 
			"third_slider" => PromotionPosition.ThirdSlider, 
			"footer" => PromotionPosition.Body, 
			"loyalty" => PromotionPosition.Loyalty, 
			"my_offers" => PromotionPosition.MyOffers, 
			"digital_catalog" => PromotionPosition.DigitalCatalog, 
			"promotions_news" => PromotionPosition.PromotionsNews, 
			"season_offers" => PromotionPosition.SeasonOffers, 
			"category_subcategory" => PromotionPosition.CategorySubcategory, 
			"brands" => PromotionPosition.CategorySubcategory, 
			"additional_banner" => PromotionPosition.HomeAdditionalBanner, 
			"loyalty_additional_banner" => PromotionPosition.LoyaltyAdditionalBanner, 
			_ => PromotionPosition.Unknown, 
		};
	}
}
