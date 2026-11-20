using Auchan.Common.AdminTool.DTO;

namespace Auchan.Common.AdminTool;

public static class PromotionPositionConverter
{
	public static Position FromDTOToModel(PromotionPosition? dto)
	{
		return dto switch
		{
			PromotionPosition.Slider => Position.FirstSlider, 
			PromotionPosition.Body => Position.Body, 
			PromotionPosition.SecondSlider => Position.SecondSlider, 
			PromotionPosition.ThirdSlider => Position.ThirdSlider, 
			PromotionPosition.Loyalty => Position.Loyalty, 
			PromotionPosition.MyOffers => Position.MyOffers, 
			PromotionPosition.DigitalCatalog => Position.DigitalCatalog, 
			PromotionPosition.PromotionsNews => Position.PromotionsNews, 
			PromotionPosition.SeasonOffers => Position.SeasonOffers, 
			PromotionPosition.CategorySubcategory => Position.CategorySubcategory, 
			PromotionPosition.Brands => Position.Brands, 
			PromotionPosition.HomeAdditionalBanner => Position.HomeAdditionalBanner, 
			PromotionPosition.LoyaltyAdditionalBanner => Position.LoyaltyAdditionalBanner, 
			_ => Position.Unknown, 
		};
	}
}
