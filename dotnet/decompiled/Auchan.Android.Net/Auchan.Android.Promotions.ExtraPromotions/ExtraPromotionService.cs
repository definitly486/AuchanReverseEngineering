using System;
using AndroidX.AppCompat.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.AdminTool;
using Auchan.Common.Ecom;
using Auchan.Common.Navigation;
using Auchan.Common.Promotions.ExtraPromotions;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Promotions.ExtraPromotions;

public class ExtraPromotionService : BaseExtraPromotionService
{
	public ExtraPromotionService(Lazy<IAdminContext> adminContext, Lazy<IEcomContext> ecomContext, Lazy<INavigationContext> navigationContext)
		: base(adminContext, ecomContext, navigationContext)
	{
	}

	protected override void OpenPopup(ExtraPromotion extraPromotion)
	{
		if (Platform.CurrentActivity is AppCompatActivity appCompatActivity)
		{
			ExtraPromotionFragment extraPromotionFragment = appCompatActivity.SupportFragmentManager.FragmentFactory.Instantiate<ExtraPromotionFragment>();
			extraPromotionFragment.Arguments = new ExtraPromotionViewModel.Parameter(extraPromotion).ToNavBundle();
			extraPromotionFragment.Show(appCompatActivity.SupportFragmentManager, extraPromotionFragment.Tag);
		}
	}
}
