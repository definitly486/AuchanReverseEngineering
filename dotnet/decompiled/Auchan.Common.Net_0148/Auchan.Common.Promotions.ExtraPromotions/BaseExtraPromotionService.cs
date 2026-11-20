using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.AdminTool.Enums;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Home;
using Auchan.Common.LoyaltyProgram;
using Auchan.Common.Navigation;
using Auchan.Common.Profile.Stores;

namespace Auchan.Common.Promotions.ExtraPromotions;

public abstract class BaseExtraPromotionService : IViewModelStateObserver, IExtraPromotionService
{
	private readonly Lazy<IAdminContext> _adminContext;

	private readonly Lazy<IEcomContext> _ecomContext;

	private readonly Lazy<INavigationContext> _navigationContext;

	protected BaseExtraPromotionService(Lazy<IAdminContext> adminContext, Lazy<IEcomContext> ecomContext, Lazy<INavigationContext> navigationContext)
	{
		_adminContext = adminContext;
		_ecomContext = ecomContext;
		_navigationContext = navigationContext;
	}

	protected abstract void OpenPopup(ExtraPromotion extraPromotion);

	public Task OpenPromotionDirectly(ScreenViewModel vm)
	{
		return OpenNeededPromotion(vm);
	}

	public void OnViewModelStarted(ScreenViewModel vm)
	{
		if (!(vm is HomeViewModel))
		{
			OpenNeededPromotion(vm).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public async Task<ExtraPromotion?> GetPromotionsFor(ScreenViewModel vm)
	{
		var (from, locationId) = GetViewModelLocation(vm);
		if (from.HasValue)
		{
			ImmutableList<ExtraPromotion> immutableList = await _adminContext.Value.GetExtraPromotionsAsync();
			if (!immutableList.IsNullOrEmpty())
			{
				ExtraPromotion extraPromotion = GetExtraPromotion(immutableList, from.Value, locationId);
				if (extraPromotion != null)
				{
					return extraPromotion;
				}
			}
		}
		return null;
	}

	private async Task OpenNeededPromotion(ScreenViewModel vm)
	{
		ExtraPromotion extraPromotion = await GetPromotionsFor(vm);
		if (extraPromotion != null)
		{
			OpenPopup(extraPromotion);
		}
	}

	private (ExtraPromotionLocation?, object?) GetViewModelLocation(ScreenViewModel vm)
	{
		if (vm is HomeViewModel && !_navigationContext.Value.IsStartForExtraOnboardingsShowed)
		{
			_navigationContext.Value.IsStartForExtraOnboardingsShowed = true;
			return (ExtraPromotionLocation.OnStart, null);
		}
		if (vm is CartScreenViewModel)
		{
			return (ExtraPromotionLocation.OnCart, null);
		}
		if (vm is CategoryViewModel categoryViewModel)
		{
			return GetCategoryLocation(categoryViewModel);
		}
		if (vm is LoyaltyTabViewModel)
		{
			return (ExtraPromotionLocation.OnCashback, null);
		}
		if (vm is StoresViewModel)
		{
			return (ExtraPromotionLocation.OnStores, null);
		}
		return default((ExtraPromotionLocation?, object));
	}

	private (ExtraPromotionLocation?, object?) GetCategoryLocation(CategoryViewModel categoryViewModel)
	{
		if (categoryViewModel.IsAdult && _ecomContext.Value.AgeGateAgreement != AgreeState.Yes)
		{
			return default((ExtraPromotionLocation?, object));
		}
		return (ExtraPromotionLocation.OnCategory, categoryViewModel.CategoryId);
	}

	private ExtraPromotion? GetExtraPromotion(ImmutableList<ExtraPromotion> extraPromotions, ExtraPromotionLocation from, object? locationId)
	{
		IEnumerable<ExtraPromotion> source = extraPromotions.Where((ExtraPromotion c) => c.Location == from && DateTime.UtcNow.IsDateIntersected(c.BeginsOn, c.EndsOn) && !_adminContext.Value.IsShowedExtraPromotion(c.Id));
		if (locationId != null)
		{
			if (long.TryParse(locationId.ToString(), out var id))
			{
				return source.FirstOrDefault((ExtraPromotion c) => c.LocationId == id);
			}
			return null;
		}
		return source.FirstOrDefault();
	}
}
