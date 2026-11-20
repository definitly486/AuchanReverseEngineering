using System;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Ecom.Cart;
using Auchan.Common.Controls.AutoLayout;

namespace Auchan.Android.Controls.AutoLayout;

public class AutoLayoutViewMapper : AbstractAutoLayoutViewMapper
{
	public static RecyclerView.ViewHolder NewViewHolderByType(string type, View view)
	{
		return type switch
		{
			"Product" => new ProductItemViewHolder(view), 
			"RecommendationProduct" => new ProductItemViewHolder(view), 
			"CartItem" => new CartItemViewHolder(view), 
			"UnavailableCartItem" => new UnavailableCartItemViewHolder(view), 
			_ => new CachingViewHolder(view), 
		};
	}

	public static int GetLayoutIdByType(string type)
	{
		return type switch
		{
			"Product" => 2131493288, 
			"RecommendationTitle" => 2131492929, 
			"RecommendationProduct" => 2131493288, 
			"RecommendationProductStub" => 2131493304, 
			"RecommendationLoadMoreButton" => 2131492913, 
			"RecommendationHorizontalBlock" => 2131493315, 
			"SliderBlock" => 2131492930, 
			"TitleBlock" => 2131492932, 
			"GameBanner" => 2131492914, 
			"LoyaltyCardBlock" => 2131492923, 
			"ReceiveMethodsSelectBlock" => 2131492928, 
			"CtmShelf" => 2131492912, 
			"HomeUserNotificationBanner" => 2131492922, 
			"HomeMyOffersBlock" => 2131492917, 
			"HomeOrdersHeader" => 2131492918, 
			"HomeOrderItem" => 2131492919, 
			"HomeCardBlock" => 2131492915, 
			"HomeDigitalCatalogBanner" => 2131492916, 
			"HomeRepeatOrdersBlock" => 2131492920, 
			"HomeSeasonBanners" => 2131492921, 
			"LoyaltyTabButtonsBlock" => 2131492926, 
			"LoyaltyTabSocialStatusBlock" => 2131492931, 
			"LoyaltyTabPersOffers" => 2131492924, 
			"LoyaltyTabCoupons" => 2131492924, 
			"LoyaltyTabHelpBlock" => 2131492927, 
			"CartHeader" => 2131492909, 
			"CartItem" => 2131493218, 
			"CartEmptyContent" => 2131492908, 
			"CartReservedHeader" => 2131492910, 
			"CartUnavailableHeader" => 2131492911, 
			"UnavailableCartItem" => 2131493219, 
			"CartBottomContent" => 2131492907, 
			"SearchFormHistoryHeader" => 2131493330, 
			"SearchFormHistoryItem" => 2131493329, 
			"SearchFormPopularHeader" => 2131493332, 
			"SearchFormPopularItem" => 2131493331, 
			"SearchFormCategoryHeader" => 2131493328, 
			"SearchFormCategoryItem" => 2131493327, 
			_ => throw new NotImplementedException(), 
		};
	}
}
