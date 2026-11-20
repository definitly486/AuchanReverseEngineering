using System;
using System.Collections.Generic;
using Auchan.Common.Analytics;
using Auchan.Common.Common;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Managers.Dialogs;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Authorization.Managers;
using Auchan.Common.Profile;
using Auchan.Common.Profile.WaitList;
using Auchan.Common.Recommendations.Models;

namespace Auchan.Common.Recommendations.ViewModels;

public class RecomProductItemViewModel : ProductItemViewModel
{
	private readonly ProductWithAnalyticsInfo _pwa;

	public override RecommendationAnalyticsInfo RecomAnalytics => _pwa.Analytics;

	public override IRecommendationAnalyticsActions RecomAnalyticActions { get; }

	public RecomProductItemViewModel(ProductWithAnalyticsInfo pwa, IRecommendationAnalyticsActionsFactory actionsFactory, Cart cart, ICollection<IDisposable> closeDisposable, CheckProductUseCase checkUseCase, IModificationsDialogService modificationsDialogService, IUserContext userContext, ILoginManager loginManager, Func<Product, FavoritesButtonViewModel> favoritesButtonViewModelFactory, SubscribeProductButtonViewModel waitListButtonViewModel, IEcomTracker ecomTracker, IEcomContext ecomContext, Lazy<IFullScreenDialogState> fullScreenDialogState, Lazy<IPromoDiscountUsecase> promoDiscountUsecase, Lazy<IAgeGateDialog> ageGateDialog, ProductItemType itemType = ProductItemType.Common)
		: base(pwa.Product, cart, closeDisposable, checkUseCase, modificationsDialogService, userContext, loginManager, favoritesButtonViewModelFactory, waitListButtonViewModel, ecomTracker, ecomContext, fullScreenDialogState, promoDiscountUsecase, ageGateDialog, itemType)
	{
		_pwa = pwa;
		RecomAnalyticActions = actionsFactory.Get(pwa);
	}

	protected override void ProcessRemoteChanges(ItemChangedEventArgs args)
	{
		base.ProcessRemoteChanges(args);
		if (args.EventType == ItemChangedEventType.Add)
		{
			RecomAnalyticActions.OnAddedToCart(this);
		}
	}
}
