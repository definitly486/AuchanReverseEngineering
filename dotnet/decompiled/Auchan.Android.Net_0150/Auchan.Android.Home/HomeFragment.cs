using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.CardView.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.CoordinatorLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AndroidX.RecyclerView.Widget;
using AndroidX.SwipeRefreshLayout.Widget;
using AndroidX.ViewPager2.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Catalog.Search;
using Auchan.Android.Common;
using Auchan.Android.Common.HighlightScreen;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.Controls.AutoLayout;
using Auchan.Android.Deeplinks;
using Auchan.Android.Drive;
using Auchan.Android.Ecom.AddressStoreSelection;
using Auchan.Android.Ecom.Banners;
using Auchan.Android.Ecom.Cart;
using Auchan.Android.Ecom.CtmShelves;
using Auchan.Android.Ecom.PriceChecker;
using Auchan.Android.Ecom.Product;
using Auchan.Android.Extensions;
using Auchan.Android.InfoPages;
using Auchan.Android.LoyaltyProgram;
using Auchan.Android.LoyaltyProgram.Coupons;
using Auchan.Android.NewYearGame;
using Auchan.Android.Notifications;
using Auchan.Android.Onboardings;
using Auchan.Android.Profile.Favorites;
using Auchan.Android.Profile.Orders;
using Auchan.Android.Profile.SalesAndNews;
using Auchan.Android.Profile.Stores;
using Auchan.Android.Profile.WaitList;
using Auchan.Android.Promotions.ExtraPromotions;
using Auchan.Android.Recommendations;
using Auchan.Android.Reviews;
using Auchan.Android.Tooltips;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Controls.AutoLayout;
using Auchan.Common.Deeplinks;
using Auchan.Common.Drive;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.Banners.ViewModels;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Ecom.CtmShelves.ViewModels;
using Auchan.Common.Ecom.Onboardings;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Home;
using Auchan.Common.Home.MainMyOffers;
using Auchan.Common.InfoPages;
using Auchan.Common.LoyaltyProgram;
using Auchan.Common.LoyaltyProgram.Coupons.Models;
using Auchan.Common.LoyaltyProgram.ViewModels;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsExpiration;
using Auchan.Common.NewYearGame;
using Auchan.Common.Profile.Orders;
using Auchan.Common.Profile.Orders.Models;
using Auchan.Common.Promotions.ExtraPromotions;
using Auchan.Common.Recommendations.ViewModels;
using Auchan.Common.Reviews;
using Auchan.Common.Tooltips;
using EBind;
using Google.Android.Material.AppBar;
using Google.Android.Material.BottomNavigation;
using Java.Interop;
using Microsoft.Maui.ApplicationModel;
using ViewSparsedRecycler;
using VisibilitySwitch;

namespace Auchan.Android.Home;

internal sealed class HomeFragment : AutoLayoutFragment<HomeViewModel>, SwipeRefreshLayout.IOnRefreshListener, IJavaObject, IDisposable, IJavaPeerable, AppBarLayout.IOnOffsetChangedListener, IBannerNavigationSupport, IFragmentNavigation
{
	private sealed class CardControls(View view)
	{
		public View View => view;

		public ImageView ImageView { get; } = view.RequireViewById<ImageView>(2131296657);

		public TextView TextView { get; } = view.RequireViewById<TextView>(2131296669);
	}

	private readonly Lazy<IDeeplinkManager> _deeplinkManager;

	private readonly Lazy<IAdminContext> _adminContext;

	private readonly Lazy<IAppActions> _appActions;

	private SwipeRefreshLayout _swipeRefreshLayout;

	private CoordinatorLayout _coordinatorLayout;

	private DroidPopupQueue _queueManager;

	private bool _expressDeliveryHighlightPending;

	private bool _canShowExpressDeliveryHighlightOnCurrentResume = true;

	private bool _expressDeliveryHighlightAvailabilityChecked;

	private bool _expressDeliveryHighlightRequestedOnCurrentResume;

	private bool _hidden;

	private EndlessScrollChangeListener _loadMoreScrollListener;

	private AppBarLayout _appBar;

	private ReceiveMethodSelectView _receiveMethodSelectView;

	private ViewPager2AutoScroller _autoScroller;

	private readonly List<TouchListenerViewGroup> _interceptors = new List<TouchListenerViewGroup>();

	private readonly HashSet<DialogFragment> _observedDialogs = new HashSet<DialogFragment>();

	private const int ScrollGestureThresholdPx = 8;

	protected override int LayoutId => 2131493031;

	public HomeFragment(Func<AndroidX.Fragment.App.Fragment, HomeViewModel> newViewModel, Lazy<IDeeplinkManager> deeplinkManager, Lazy<IAdminContext> adminContext, Lazy<IAppActions> appActions)
		: base(newViewModel)
	{
		_deeplinkManager = deeplinkManager;
		_adminContext = adminContext;
		_appActions = appActions;
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		_queueManager = DroidPopupQueue.CreateFor(this);
		_queueManager.OnCreate(base.ParentFragmentManager).AutoDisposeOnDestroy(this);
		base.ViewModel.OpenSoftUpdatePopupCommand.SafeSubscribe(delegate
		{
			OpenSoftUpdate();
		}, this);
		base.ViewModel.OpenAddressCheckCommand.SafeSubscribe(delegate(AddressViewModel.Parameter p)
		{
			Show<AddressFragment, AddressViewModel.Parameter>(p);
		}, this);
		base.ViewModel.OpenCatalogCommand.SafeSubscribe(delegate
		{
			NavigateTo<CatalogFragment>();
		}, this);
		base.ViewModel.OpenSalesAndNewsCommand.SafeSubscribe(delegate
		{
			NavigateTo<SalesAndNewsFragment>();
		}, this);
		base.ViewModel.OpenProductsCommand.SafeSubscribe(delegate(ProductsViewModel.Parameter p)
		{
			NavigateTo<ProductsFragment, ProductsViewModel.Parameter>(p);
		}, this);
		base.ViewModel.OpenFavoritesCommand.SafeSubscribe(delegate
		{
			NavigateTo<FavoritesFragment>();
		}, this);
		base.ViewModel.OpenNotificationsCommand.SafeSubscribe(delegate
		{
			NavigateTo<NotificationsFragment>();
		}, this);
		base.ViewModel.OpenWaitListCommand.SafeSubscribe(delegate
		{
			NavigateTo<WaitListFragment>();
		}, this);
		base.ViewModel.OpenDeeplinkCommand.SafeSubscribe(delegate(Deeplink link)
		{
			base.ViewModel.RunTask(_deeplinkManager.Value.ResolveDeeplink(this, link));
		}, this);
		base.ViewModel.OpenShopListCommand.SafeSubscribe(delegate
		{
			NavigateTo<StoresFragment>(null, add: true);
		}, this);
		base.ViewModel.ShowPersonalizedTriggerCommand.SafeSubscribe(OpenPersonalizedGreeting, this);
		base.ViewModel.OpenTooltipsCommand.SafeSubscribe(ShowTooltip, this);
		base.ViewModel.OpenExtraPromotion.SafeSubscribe(OpenExtraPromotion, this);
		base.ViewModel.OpenNewYearGamePopupCommand.SafeSubscribe(OpenNewYearGamePopup, this);
		base.ViewModel.ShowWaitingForReviewPopupCommand.SafeSubscribe(delegate
		{
			ShowWaitingForReviewPopup();
		}, this);
		base.ViewModel.ReceiveMethodViewModel.ShowExpressDeliveryHighlightCommand.SafeSubscribe(delegate
		{
			RequestExpressDeliveryHighlight();
		}, this);
		base.ViewModel.OpenNewYearSantaPopupCommand.SafeSubscribe(OpenNewYearSantaPopup, this);
		base.ViewModel.OrdersHomeViewModel.OpenIssuingZonePopupCommand.SafeSubscribe(delegate(IssuingAreaViewModel.Parameter parameter)
		{
			Show<IssuingAreaPopupFragment, IssuingAreaViewModel.Parameter>(parameter).NavigateToOrders = delegate
			{
				NavigateTo<OrdersFragment>();
			};
		}, this);
		base.ViewModel.OrdersHomeViewModel.OpenIsArrivedPopupCommand.SafeSubscribe(delegate(OrderItemViewModel order)
		{
			OpenIsArrivedDialog(order).SafeFireAndForget((Action<Exception>)null, false);
		}, this);
		base.ViewModel.OrdersHomeViewModel.RepeatOrderService.NavigateToRepeatPreviousOrderPopup.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<RepeatOrderPopupFragment, BrokerToken>(p);
		}, this);
		base.ViewModel.OrdersHomeViewModel.RepeatOrderService.ShowRepeatAdultProductWarningCommand.SafeSubscribe(delegate
		{
			ShowAdultWarning().SafeFireAndForget((Action<Exception>)null, false);
		}, this);
		base.ViewModel.OrdersHomeViewModel.RepeatOrderService.NavigateToStaticProductListCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			NavigateTo<StaticProductListFragment, BrokerToken>(p);
		}, this);
		base.ViewModel.OpenOnboardingsCommand.SafeSubscribe(OpenOnboardings, this);
		base.ViewModel.ReceiveMethodViewModel.OpenFavoritesCommand.SafeSubscribe(delegate
		{
			Auchan.Common.Analytics.AppAnalytics.AppMetrica.TrackEvent("TapMainOnFavorites");
			NavigateTo<FavoritesFragment>();
		}, this);
		base.ViewModel.LoyaltyCardViewModel.OpenPurchasesCommand.SafeSubscribe(delegate(MyPurchasesViewModel.Parameter p)
		{
			NavigateTo<MyPurchasesFragment, MyPurchasesViewModel.Parameter>(p);
		}, this);
		base.ViewModel.LoyaltyCardViewModel.OpenPointsBurningCommand.SafeSubscribe(delegate(LoyaltyCardPointsExpirationViewModel.Parameter p)
		{
			NavigateTo<LoyaltyCardPointsExpirationFragment, LoyaltyCardPointsExpirationViewModel.Parameter>(p);
		}, this);
		base.ViewModel.LoyaltyCardViewModel.OpenStampsBurningDocumentCommand.SafeSubscribe(delegate(InfoPageViewModel.Parameter doc)
		{
			NavigateTo<InfoPageFragment, InfoPageViewModel.Parameter>(doc);
		}, this);
		base.ViewModel.LoyaltyCardViewModel.OpenCodeCommand.SafeSubscribe(delegate
		{
			LoyaltyCardPdf417LandscapeFragment dialog = Show<LoyaltyCardPdf417LandscapeFragment, LoyaltyCardQrPreviewViewModel.Parameter>(new LoyaltyCardQrPreviewViewModel.Parameter(LoyaltyCardQrPreviewViewModel.OpenedFrom.HomeTab));
			RetryExpressDeliveryHighlightWhenClosed(dialog);
		}, this);
		base.ViewModel.ChangeAppIconCommand.SafeSubscribe(delegate(AppIconType p)
		{
			SwitchIconAsync(p).SafeFireAndForget((Action<Exception>)null, false);
		}, this);
		base.ViewModel.RegisterRemoteNotifications.SafeSubscribe(delegate
		{
			RequestNotificationPermission();
		}, this);
		base.ViewModel.OpenLoyaltyTabCommand.SafeSubscribe(delegate
		{
			NavigateToTab(2131297643);
		}, this);
		this.SetupBannersNavigation(base.ViewModel.BannerNavigationSupport, this);
	}

	private async Task SwitchIconAsync(AppIconType appIcon)
	{
		DroidRestartService.TryPushPreferencesToStorage();
		await MainThread.InvokeOnMainThreadAsync(() => _appActions.Value.SetAsync(Array.Empty<AppAction>()));
		string[] array = new string[5]
		{
			AppInfo.PackageName + ".LauncherIconDefault",
			AppInfo.PackageName + ".LauncherIconSale60",
			AppInfo.PackageName + ".LauncherIconSale70",
			AppInfo.PackageName + ".LauncherIconNewYear",
			AppInfo.PackageName + ".LauncherIconBirthday"
		};
		string aliasName = appIcon switch
		{
			AppIconType.Default => array[0], 
			AppIconType.Sale60 => array[1], 
			AppIconType.Sale70 => array[2], 
			AppIconType.NewYear => array[3], 
			AppIconType.Birthday => array[4], 
			_ => array[0], 
		};
		IEnumerable<(string Name, ComponentEnabledState State, ComponentEnableOption Flags)> first = from i in array
			where i != aliasName
			select (Name: i, State: ComponentEnabledState.Disabled, Flags: ComponentEnableOption.DontKillApp);
		IEnumerable<(string, ComponentEnabledState, ComponentEnableOption)> second = from i in array
			where i == aliasName
			select (Name: i, State: ComponentEnabledState.Enabled, Flags: ComponentEnableOption.None);
		IEnumerable<(string, ComponentEnabledState, ComponentEnableOption)> enumerable = first.Concat<(string, ComponentEnabledState, ComponentEnableOption)>(second);
		if (OperatingSystem.IsAndroidVersionAtLeast(33))
		{
			Application.Context.PackageManager?.SetComponentEnabledSettings(enumerable.Select<(string, ComponentEnabledState, ComponentEnableOption), PackageManager.ComponentEnabledSetting>(((string Name, ComponentEnabledState State, ComponentEnableOption Flags) i) => new PackageManager.ComponentEnabledSetting(new ComponentName(Application.Context, i.Name), (int)i.State, 0)).ToImmutableList());
			return;
		}
		foreach (var item in enumerable)
		{
			Application.Context.PackageManager?.SetComponentEnabledSetting(new ComponentName(Application.Context, item.Item1), item.Item2, item.Item3);
		}
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		GridLayoutManager gridLayoutManager = new GridLayoutManager(Context, 2);
		gridLayoutManager.SetSpanSizeLookup(new DelegateSpanSizeLookup(delegate(int pos)
		{
			AutoLayoutViewModel.AutoLayoutElement autoLayoutElement = base.ViewModel.AutoLayout.Elements.ElementAtOrDefault(pos);
			return (autoLayoutElement != null && (autoLayoutElement.Type == "RecommendationProduct" || autoLayoutElement.Type == "RecommendationProductStub")) ? 1 : 2;
		}));
		base.LayoutManager = gridLayoutManager;
		_autoScroller = new ViewPager2AutoScroller
		{
			Interval = base.ViewModel.BannerAutoscrollDelay,
			InterruptedDelay = TimeSpan.FromSeconds(3L),
			InitialPosition = (RecyclerView.Adapter adapter) => ((EndlessRecyclerAdapter<BannerItemViewModel>)adapter).FirstItemAdapterPosition
		};
		_autoScroller.AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.OnViewCreated(view, savedInstanceState);
		_swipeRefreshLayout = view.RequireViewById<SwipeRefreshLayout>(2131298581);
		_coordinatorLayout = _swipeRefreshLayout.RequireViewById<CoordinatorLayout>(2131297293);
		_appBar = _coordinatorLayout.RequireViewById<AppBarLayout>(2131296451);
		View view2 = view.RequireViewById<View>(2131298077);
		view2.RequireViewById<TextView>(2131298080);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297108);
		TextView errorTitle = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView errorMessage = constraintLayout.RequireViewById<TextView>(2131297563);
		Button button = constraintLayout.RequireViewById<Button>(2131296325);
		Button button2 = constraintLayout.RequireViewById<Button>(2131298371);
		TextView textView = _appBar.RequireViewById<TextView>(2131298307);
		FrameLayout priceCheckerButton = _appBar.RequireViewById<FrameLayout>(2131297985);
		_receiveMethodSelectView = _appBar.RequireViewById<ReceiveMethodSelectView>(2131298168);
		_receiveMethodSelectView.Bind(base.ViewModel.ReceiveMethodViewModel, ViewLifecycleOwner);
		_receiveMethodSelectView.SetNotificationsCount(base.ViewModel.NotificationsCount);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			_receiveMethodSelectView.SetNotificationsCount(base.ViewModel.NotificationsCount);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NotificationsCount")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		_receiveMethodSelectView.ConnectNotificationsClick(delegate
		{
			base.ViewModel.OnNotificationsClick();
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		LoyaltyCardView loyaltyCardView = _appBar.RequireViewById<LoyaltyCardView>(2131297489);
		loyaltyCardView.SetParentFragment(this);
		loyaltyCardView.Bind(base.ViewModel.LoyaltyCardViewModel, ViewLifecycleOwner);
		WaitListNotificationBannerView waitListNotificationBannerView = view.RequireViewById<WaitListNotificationBannerView>(2131298812);
		base.AutoLayoutRecycler.AddProductsAutoLayoutDecoration(base.ViewModel.AutoLayout);
		_appBar.AddOnOffsetChangedListener(this);
		Disposable.Create(delegate
		{
			_appBar.RemoveOnOffsetChangedListener(this);
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		_coordinatorLayout.AddGoToTopButton(base.AutoLayoutRecycler, base.ViewModel.AutoLayout, base.ScrollToTop, ViewLifecycleOwner, _appBar);
		_swipeRefreshLayout.SetColorSchemeResources(2131100555);
		_swipeRefreshLayout.SetOnRefreshListener(this);
		VisibilitySwitch<VisualState> viewSwitch = new VisibilitySwitch<VisualState>(base.ViewModel.State)
		{
			{
				VisualState.Default,
				_swipeRefreshLayout
			},
			{
				VisualState.InProgress,
				view2
			},
			{
				VisualState.Error,
				constraintLayout
			}
		};
		textView.SetOnClickListener(new ViewOnClickListener(OnOpenSearch));
		textView.SetOnLongClickListener(new ViewOnLongClickListener(OnOpenSearch));
		textView.Text = base.ViewModel.SearchPlaceholder;
		waitListNotificationBannerView.Bind(base.ViewModel.WaitListNotificationBanner, ViewLifecycleOwner);
		base.ViewModel.WaitListNotificationBanner.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			waitListNotificationBannerView.Visibility = base.ViewModel.WaitListNotificationBanner.Visible.ToVisibility();
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Visible")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[4]
		{
			(delegate
			{
				priceCheckerButton.Visibility = base.ViewModel.IsPriceCheckerEnabled.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsPriceCheckerEnabled")),
			(delegate
			{
				errorTitle.Text = base.ViewModel.ErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				errorMessage.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				viewSwitch.State = base.ViewModel.State;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.OnRetry), ((View)button2).OnClick((Action)delegate
		{
			LoyaltyCardPdf417PortraitFragment dialog = Show<LoyaltyCardPdf417PortraitFragment>();
			RetryExpressDeliveryHighlightWhenClosed(dialog);
		}), ((View)priceCheckerButton).OnClick((Action)delegate
		{
			base.ViewModel.OnPriceCheckerClicked().SafeFireAndForget((Action<Exception>)null, false);
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		new NearestOrderInfoControls(view.RequireViewById<View>(2131297417)).Bind(base.ViewModel.NearestOrderInfoViewModel, ViewLifecycleOwner);
		base.ViewModel.NearestOrderInfoViewModel.NavigateToOrderDetailsCommand.SafeSubscribe(delegate(OrderDetailsViewModel.Parameter p)
		{
			NavigateTo<OrderDetailsFragment, OrderDetailsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.NearestOrderInfoViewModel.OpenIssuingZonePopupCommand.SafeSubscribe(delegate(IssuingAreaViewModel.Parameter parameter)
		{
			Show<IssuingAreaPopupFragment, IssuingAreaViewModel.Parameter>(parameter).NavigateToOrders = delegate
			{
				NavigateTo<OrdersFragment>();
			};
		}, ViewLifecycleOwner);
		base.ViewModel.NearestOrderInfoViewModel.OpenIsArrivedPopupCommand.SafeSubscribe(delegate(OrderItemViewModel order)
		{
			OpenIsArrivedDialog(order).SafeFireAndForget((Action<Exception>)null, false);
		}, ViewLifecycleOwner);
		_queueManager.WillShowPopup += new DisposableDelegate<Action<AndroidX.Fragment.App.Fragment>>(WillShowPopup, delegate(Action<AndroidX.Fragment.App.Fragment> h)
		{
			_queueManager.WillShowPopup -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		_queueManager.QueueDrained += new DisposableDelegate<Action>(TryQueueExpressDeliveryHighlight, delegate(Action h)
		{
			_queueManager.QueueDrained -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		FragmentManager rootFragmentManager = RequireActivity().SupportFragmentManager;
		rootFragmentManager.BackStackChanged += new DisposableDelegate<EventHandler>(delegate
		{
			RetryExpressDeliveryHighlight();
		}, delegate(EventHandler h)
		{
			rootFragmentManager.BackStackChanged -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OpenPriceChecker.SafeSubscribe(delegate
		{
			NavigateTo<PriceCheckerFragment>();
		}, ViewLifecycleOwner);
		base.ViewModel.OnNavigateOrders.SafeSubscribe(delegate
		{
			NavigateTo<OrdersFragment>();
		}, ViewLifecycleOwner);
		base.ViewModel.OrdersHomeViewModel.NavigateToOrderDetailsCommand.SafeSubscribe(delegate(OrderDetailsViewModel.Parameter p)
		{
			NavigateTo<OrderDetailsFragment, OrderDetailsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.OrdersHomeViewModel.RepeatOrderService.NavigateToCartCommand.SafeSubscribe(delegate
		{
			NavigateToTab(2131297640);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenPaymentCommand.SafeSubscribe(delegate(CheckoutWebViewModel.Parameter p)
		{
			NavigateTo<CheckoutWebViewFragment, CheckoutWebViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.RefreshDoneCommand.SafeSubscribe(delegate
		{
			_swipeRefreshLayout.Refreshing = false;
		}, ViewLifecycleOwner);
		_loadMoreScrollListener = new EndlessScrollChangeListener(delegate
		{
			base.ViewModel.Recommendations.LoadMoreCommand.Trigger(subject: false);
		}, OnScrollChanged);
		base.AutoLayoutRecycler.AddOnScrollListener(_loadMoreScrollListener);
		base.ViewModel.Recommendations.ShowQtyDialogCommand.SafeSubscribe(delegate(ProductItemViewModel vm)
		{
			ProductItemViewHolder.ShowQtyInputDialog(vm, base.LayoutInflater, Context);
		}, ViewLifecycleOwner);
		base.ViewModel.Recommendations.NavigateToProductCommand.SafeSubscribe(delegate(ProductDetailsViewModel.Parameter p)
		{
			NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.Recommendations.OpenReviewsCommand.SafeSubscribe(delegate(ProductReviewsViewModel.Parameter p)
		{
			NavigateTo<ProductReviewsFragment, ProductReviewsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.TopRecommendations.ShowAllCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			NavigateTo<StaticProductListFragment, BrokerToken>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.TopRecommendations.NavigateToProductCommand.SafeSubscribe(delegate(ProductDetailsViewModel.Parameter p)
		{
			NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.TopRecommendations.OpenReviewsCommand.SafeSubscribe(delegate(ProductReviewsViewModel.Parameter p)
		{
			NavigateTo<ProductReviewsFragment, ProductReviewsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.TopRecommendations.ShowQtyDialogCommand.SafeSubscribe(delegate(ProductItemViewModel vm)
		{
			ProductItemViewHolder.ShowQtyInputDialog(vm, base.LayoutInflater, Context);
		}, ViewLifecycleOwner);
		base.ViewModel.BottomRecommendations.ShowAllCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			NavigateTo<StaticProductListFragment, BrokerToken>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.BottomRecommendations.NavigateToProductCommand.SafeSubscribe(delegate(ProductDetailsViewModel.Parameter p)
		{
			NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.BottomRecommendations.OpenReviewsCommand.SafeSubscribe(delegate(ProductReviewsViewModel.Parameter p)
		{
			NavigateTo<ProductReviewsFragment, ProductReviewsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.BottomRecommendations.ShowQtyDialogCommand.SafeSubscribe(delegate(ProductItemViewModel vm)
		{
			ProductItemViewHolder.ShowQtyInputDialog(vm, base.LayoutInflater, Context);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenMyOffersCommand.SafeSubscribe(delegate
		{
			NavigateTo<MyOffersFragment, MyOffersViewModel.Parameter>(new MyOffersViewModel.Parameter(null, isAi: false));
		}, this);
		base.ViewModel.NavigateToMyFavoriteCategoriesCommand.SafeSubscribe(NavigateToMyFavoriteCategories, ViewLifecycleOwner);
		base.ViewModel.OpenCouponDetailsCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<CouponDetailsFragment, BrokerToken>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenOfferDetailsCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			OfferDetailsFragment dialog = Show<OfferDetailsFragment, BrokerToken>(p);
			RetryExpressDeliveryHighlightWhenClosed(dialog);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenAIOfferDetailsCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			AIOfferDetailsFragment dialog = Show<AIOfferDetailsFragment, BrokerToken>(p);
			RetryExpressDeliveryHighlightWhenClosed(dialog);
		}, ViewLifecycleOwner);
		base.ViewModel.ShowQtyDialogCommand.SafeSubscribe(delegate(ProductItemViewModel vm)
		{
			ProductItemViewHolder.ShowQtyInputDialog(vm, base.LayoutInflater, Context);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenProductDetailsCommand.SafeSubscribe(delegate(ProductDetailsViewModel.Parameter p)
		{
			NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
	}

	protected override void BindAutoLayoutView(AutoLayoutViewModel.AutoLayoutElement vm, int position, CachingViewHolder vh, CompositeDisposable disposables)
	{
		string type = vm.Type;
		if (type == null)
		{
			return;
		}
		object data;
		RecomProductItemViewModel rpvm;
		switch (type.Length)
		{
		case 10:
			switch (type[0])
			{
			case 'G':
				if (type == "GameBanner")
				{
					SetupGameView(vh, vm.Data as IReadOnlyList<BannerItemViewModel>, disposables);
				}
				break;
			case 'T':
				if (type == "TitleBlock")
				{
					SetupTextView(vh, vm.Data as string, disposables);
				}
				break;
			}
			break;
		case 13:
			switch (type[4])
			{
			case 'C':
				if (type == "HomeCardBlock")
				{
					SetupCardsBlock(vh, disposables);
				}
				break;
			case 'O':
				if (type == "HomeOrderItem")
				{
					SetupOrderItem(vh, (HomeOrderItemViewModel)vm.Data, disposables);
				}
				break;
			}
			break;
		case 17:
			switch (type[4])
			{
			case 'M':
				if (type == "HomeMyOffersBlock")
				{
					SetupMyOffersBlock(vh, disposables);
				}
				break;
			case 'S':
				if (type == "HomeSeasonBanners")
				{
					SetupSeasonOffers(vh, vm.Data as IReadOnlyList<BannerItemViewModel>, disposables);
				}
				break;
			}
			break;
		case 21:
			switch (type[0])
			{
			default:
				return;
			case 'H':
				if (type == "HomeRepeatOrdersBlock")
				{
					SetupRepeatOrdersBlock(vh, disposables);
				}
				return;
			case 'R':
				break;
			}
			if (!(type == "RecommendationProduct"))
			{
				break;
			}
			goto IL_02e9;
		case 26:
			if (type == "HomeUserNotificationBanner")
			{
				vh.RequireCachedView<UserNotificationBannerView>(2131298791).Bind(vm.Data as UserNotificationBanner, disposables);
			}
			break;
		case 8:
			if (type == "CtmShelf")
			{
				SetupCtmShelf(vh, (ShelfItemViewModel)vm.Data, disposables);
			}
			break;
		case 16:
			if (type == "HomeOrdersHeader")
			{
				SetupOrdersHeaderBlock(vh, disposables);
			}
			break;
		case 24:
			if (type == "HomeDigitalCatalogBanner")
			{
				SetupDigitalCatalog(vh, vm.Data as BannerItemViewModel, disposables);
			}
			break;
		case 29:
			if (type == "RecommendationHorizontalBlock")
			{
				SetupHorizontalRecommendations(vh, vm.Data, disposables);
			}
			break;
		case 11:
			if (type == "SliderBlock")
			{
				SetupBannerSlider(vh, (IReadOnlyList<BannerItemViewModel>)vm.Data, disposables);
			}
			break;
		case 19:
			if (type == "RecommendationTitle")
			{
				SetupTextView(vh, vm.Data as string, disposables);
			}
			break;
		case 25:
			if (!(type == "RecommendationProductStub"))
			{
				break;
			}
			goto IL_02e9;
		case 28:
			if (type == "RecommendationLoadMoreButton")
			{
				vh.RequireCachedView<TextView>(2131298603).Text = base.ViewModel.Recommendations.LoadMoreText;
				vh.ItemView.SetOnClickListenerSafe(new ViewOnClickListener((Action<View>)delegate
				{
					base.ViewModel.Recommendations.LoadMoreCommand.Trigger(subject: true);
				})).AddTo(disposables);
			}
			break;
		case 9:
		case 12:
		case 14:
		case 15:
		case 18:
		case 20:
		case 22:
		case 23:
		case 27:
			break;
			IL_02e9:
			AdjustProductCardSize(vh);
			if (!(vh is ProductItemViewHolder productItemViewHolder))
			{
				break;
			}
			data = vm.Data;
			rpvm = data as RecomProductItemViewModel;
			if (rpvm != null)
			{
				base.ViewModel.OnRecommendationsViewed();
				productItemViewHolder.BindData(base.ViewModel, rpvm, disposables, base.ViewModel.Recommendations.ShowQtyDialogCommand, showPackageLabel: true);
				productItemViewHolder.ItemView.SetOnClickListenerSafe(new ViewOnClickListener((Action<View>)delegate
				{
					base.ViewModel.Recommendations.ProductClickCommand.Trigger(rpvm);
				})).AddTo(disposables);
			}
			break;
		}
	}

	private void AdjustProductCardSize(CachingViewHolder vh)
	{
		vh.ItemView.UpdateLayoutParams<ViewGroup.LayoutParams>((Action<ViewGroup.LayoutParams>)delegate(ViewGroup.LayoutParams lp)
		{
			lp.Width = (base.Resources.DisplayMetrics.WidthPixels - (Converter.DpToPx(40f) + Converter.DpToPx(10f))) / 2;
			lp.Height = Converter.DpToPx(286f);
		});
	}

	private void OnScrollChanged(int offset, int dx, int dy)
	{
		if (dy > 0 && offset > 5 && _appBar.Height == _appBar.Bottom)
		{
			_appBar.SetExpanded(expanded: false, animate: false);
		}
	}

	private void WillShowPopup(AndroidX.Fragment.App.Fragment popup)
	{
		if (popup is ExpressDeliveryHighlightScreenFragment)
		{
			_receiveMethodSelectView?.PrepareForHighlight();
		}
		if (popup is WaitingForReviewPopupFragment popup2)
		{
			WaitForWaitingForReviewPopupResult(popup2).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private async Task WaitForWaitingForReviewPopupResult(WaitingForReviewPopupFragment popup)
	{
		if (await popup.Execute())
		{
			NavigateTo<WaitingForReviewFragment>();
		}
	}

	public override void OnStart()
	{
		base.OnStart();
		if (!base.IsHidden)
		{
			ResumeQueueManager();
		}
		_autoScroller.Start();
	}

	public override void OnStop()
	{
		base.OnStop();
		ResetExpressDeliveryHighlightAvailability();
		_expressDeliveryHighlightRequestedOnCurrentResume = false;
		if (!base.IsHidden)
		{
			_queueManager.OnPause();
		}
		_autoScroller.Stop();
	}

	public override void OnResume()
	{
		base.OnResume();
		UpdateExpressDeliveryHighlightAvailability();
		RetryExpressDeliveryHighlight();
	}

	public override void OnHiddenChanged(bool hidden)
	{
		base.OnHiddenChanged(hidden);
		if (_hidden != hidden)
		{
			_hidden = hidden;
			if (hidden)
			{
				ResetExpressDeliveryHighlightAvailability();
				_expressDeliveryHighlightRequestedOnCurrentResume = false;
				_queueManager.OnPause();
				_autoScroller.Stop();
			}
			else
			{
				ResumeAsync().SafeFireAndForget((Action<Exception>)null, false);
			}
		}
		async Task ResumeAsync()
		{
			await Task.Delay(50);
			if (!_hidden)
			{
				UpdateExpressDeliveryHighlightAvailability();
				ResumeQueueManager();
				_autoScroller.Start();
			}
		}
	}

	public override void OnDestroyView()
	{
		base.OnDestroyView();
		base.AutoLayoutRecycler.RemoveOnScrollListener(_loadMoreScrollListener);
		_loadMoreScrollListener.Dispose();
		_loadMoreScrollListener = null;
		_receiveMethodSelectView = null;
	}

	private void ResumeQueueManager()
	{
		UpdateExpressDeliveryHighlightAvailability();
		if (_adminContext.Value.ShowedTooltipThisSession)
		{
			_queueManager.RemoveFromQueue<TooltipFragment>();
		}
		if (_adminContext.Value.ShowedGameAnimationPopup)
		{
			_queueManager.RemoveFromQueue<SantaPopupDialogFragment>();
		}
		_queueManager.OnResume();
	}

	private void SetupMyOffersBlock(CachingViewHolder vh, CompositeDisposable disposables)
	{
		TextView textView = vh.RequireCachedView<TextView>(2131298646);
		ChevronRightButtonControls allButton = new ChevronRightButtonControls(vh.RequireCachedView<View>(2131296423));
		LinearLayout indicator = vh.RequireCachedView<LinearLayout>(2131297338);
		TextView indicatorText = indicator.RequireViewById<TextView>(2131297342);
		RecyclerView recyclerView = vh.RequireCachedView<RecyclerView>(2131298188);
		textView.Text = base.ViewModel.MyOffersTitle;
		allButton.TextView.Text = base.ViewModel.MyOffersAllText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				indicatorText.Text = base.ViewModel.MyOffersIndicatorText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("MyOffersIndicatorText")),
			(delegate
			{
				indicator.Visibility = base.ViewModel.MyOffersIndicatorVisible.ToInvisibleVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("MyOffersIndicatorText")),
			(delegate
			{
				allButton.View.Visibility = base.ViewModel.ShowOffersAllButton.ToInvisibleVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ShowOffersAllButton"))
		})).AddTo(disposables);
		base.ViewModel.BindEvents(allButton.View.OnClick(base.ViewModel.OpenLoyaltyTap)).AddTo(disposables);
		recyclerView.SetLayoutManager(new LinearLayoutManager(Context, 0, reverseLayout: false).AddTo(disposables));
		if (recyclerView.ItemDecorationCount == 0)
		{
			recyclerView.AddItemDecoration(new HorizontalSpaceItemDecoration(8, 0, 0));
		}
		ObservableRecyclerAdapter<HomeMyOfferItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<HomeMyOfferItemViewModel, CachingViewHolder>
		{
			GetItemViewTypeDelegate = (int index) => (int)base.ViewModel.MyOffersViewModels[index].Type,
			CreateViewHolderDelegate = delegate(ViewGroup layout, int cellType)
			{
				int resource = ((cellType == 2) ? 2131493249 : 2131493248);
				return new CachingViewHolder(base.LayoutInflater.Inflate(resource, layout, attachToRoot: false));
			},
			BindViewHolderDelegate = delegate(CachingViewHolder holder, HomeMyOfferItemViewModel model, int position, CompositeDisposable disposable)
			{
				OnBindHomeMyOffer(recyclerView, holder, model, position, disposable);
			},
			DataSource = base.ViewModel.MyOffersViewModels
		};
		recyclerView.SetAdapter(adapter);
		recyclerView.ScrollToPosition(0);
	}

	private void SetupCtmShelf(CachingViewHolder vh, ShelfItemViewModel data, CompositeDisposable disposables)
	{
		int num = Converter.DpToPx(20f);
		new ShelfControls(vh, nestedScrollEnabled: false).Bind(base.ViewModel, data, 0, num, num, disposables);
	}

	private void SetupOrdersHeaderBlock(CachingViewHolder vh, CompositeDisposable disposables)
	{
		TextView textView = vh.RequireCachedView<TextView>(2131297292);
		ChevronRightButtonControls chevronRightButtonControls = new ChevronRightButtonControls(vh.RequireCachedView<View>(2131296423));
		textView.Text = base.ViewModel.OrdersHomeViewModel.OrdersBlockTitle;
		chevronRightButtonControls.TextView.Text = base.ViewModel.OrdersHomeViewModel.AllButtonText;
		chevronRightButtonControls.View.OnClick(base.ViewModel.OpenOrders).AddTo(disposables);
	}

	private void SetupOrderItem(CachingViewHolder vh, HomeOrderItemViewModel vm, CompositeDisposable disposables)
	{
		new MultiOrdersItemViewControls(vh).Bind(base.ViewModel, vm, disposables);
	}

	private void SetupSeasonOffers(CachingViewHolder viewHolder, IReadOnlyList<BannerItemViewModel> viewModels, CompositeDisposable disposables)
	{
		RecyclerView seasonOffersList = viewHolder.RequireCachedView<RecyclerView>(2131298325);
		TextView textView = viewHolder.RequireCachedView<TextView>(2131298326);
		seasonOffersList.SetLayoutManager(new LinearLayoutManager(Context, 0, reverseLayout: false).AddTo(disposables));
		ObservableRecyclerAdapter<BannerItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<BannerItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493520,
			BindViewHolderDelegate = delegate(CachingViewHolder h, BannerItemViewModel i, int p, CompositeDisposable d)
			{
				OnBindSeasonOffers(seasonOffersList, h, i, p, d);
			},
			DataSource = viewModels
		};
		seasonOffersList.SetAdapter(adapter);
		textView.Text = base.ViewModel.SeasonOffersTitle;
		base.ViewModel.SeasonOffersScrollCommand.SafeSubscribe(delegate
		{
			seasonOffersList.ScrollToPosition(0);
		}, disposables);
	}

	private void SetupRepeatOrdersBlock(CachingViewHolder viewHolder, CompositeDisposable disposables)
	{
		View view = viewHolder.RequireCachedView<View>(2131298204);
		TextView textView = viewHolder.RequireCachedView<TextView>(2131298203);
		RecyclerView recyclerView = viewHolder.RequireCachedView<RecyclerView>(2131296830);
		if (recyclerView.ItemDecorationCount == 0)
		{
			ObservableRecyclerAdapter<ProductModel, CachingViewHolder> observableRecyclerAdapter = new ObservableRecyclerAdapter<ProductModel, CachingViewHolder>
			{
				CellLayoutId = 2131493230,
				BindViewHolderDelegate = OnBindProduct,
				DataSource = base.ViewModel.OrdersHomeViewModel.LastCompletedOrder.Products
			};
			HorizontalSpaceItemDecoration decor = new HorizontalSpaceItemDecoration(0, 9, 9);
			CustomSizeLinearLayoutManager layoutManager = new CustomSizeLinearLayoutManager(Context, 0, reverseLayout: false)
			{
				CellSizeFunc = delegate
				{
					int num = (base.Resources.DisplayMetrics.WidthPixels - Converter.DpToPx(80f)) / 5;
					int width = num + Converter.DpToPx(4f);
					double num2 = (double)num / 1.2 + (double)Converter.DpToPx(12f);
					return new RecyclerView.LayoutParams(width, (int)num2);
				}
			};
			observableRecyclerAdapter.ClickCallback = delegate
			{
				base.ViewModel.OrdersHomeViewModel.RepeatLastCompletedOrderCommand.Trigger();
			};
			recyclerView.SetLayoutManager(layoutManager);
			recyclerView.AddItemDecoration(decor);
			recyclerView.SetAdapter(observableRecyclerAdapter);
		}
		textView.Text = base.ViewModel.OrdersHomeViewModel.RepeatCompletedOrderText;
		view.OnClick(base.ViewModel.OrdersHomeViewModel.RepeatLastCompletedOrderCommand.Trigger).AddTo(disposables);
		void OnBindProduct(CachingViewHolder holder, ProductModel model, int position, CompositeDisposable disposable)
		{
			ImageView imageView = holder.RequireCachedView<ImageView>(2131297809);
			holder.RequireCachedView<TextView>(2131296498).Text = $"{model.Qty}";
			string image = base.ViewModel.GetImage(model);
			if (!string.IsNullOrEmpty(image))
			{
				imageView.FromUrl(image);
			}
		}
	}

	private void SetupGameView(CachingViewHolder viewHolder, IReadOnlyList<BannerItemViewModel> banners, CompositeDisposable disposables)
	{
		RecyclerView recyclerView = viewHolder.RequireCachedView<RecyclerView>(2131296378);
		ViewGroup viewGroup = viewHolder.RequireCachedView<ViewGroup>(2131296383);
		ViewGroup viewGroup2 = viewHolder.RequireCachedView<ViewGroup>(2131296373);
		if (banners.Count == 1)
		{
			recyclerView.Visibility = ViewStates.Gone;
			viewGroup2.Visibility = ViewStates.Gone;
			viewGroup.Visibility = ViewStates.Visible;
			SetupGameBanner(viewGroup.RequireViewById<SkottieAnimationView>(2131296381), viewGroup.RequireViewById<ImageView>(2131296382), banners[0], disposables, isShort: false);
			return;
		}
		if (banners.Count == 2)
		{
			recyclerView.Visibility = ViewStates.Gone;
			viewGroup.Visibility = ViewStates.Gone;
			viewGroup2.Visibility = ViewStates.Visible;
			SetupGameBanner(viewGroup2.RequireViewById<SkottieAnimationView>(2131296374), viewGroup2.RequireViewById<ImageView>(2131296375), banners[0], disposables, isShort: true);
			SetupGameBanner(viewGroup2.RequireViewById<SkottieAnimationView>(2131296379), viewGroup2.RequireViewById<ImageView>(2131296380), banners[1], disposables, isShort: true);
			return;
		}
		viewGroup.Visibility = ViewStates.Gone;
		viewGroup2.Visibility = ViewStates.Gone;
		recyclerView.Visibility = ((banners.Count <= 2) ? ViewStates.Gone : ViewStates.Visible);
		if (banners.Count <= 2)
		{
			return;
		}
		if (recyclerView.ItemDecorationCount == 0)
		{
			recyclerView.SetLayoutManager(new CustomSizeLinearLayoutManager(Context, 0, reverseLayout: false)
			{
				CellSizeFunc = delegate
				{
					int num = (int)((float)(base.Resources.DisplayMetrics.WidthPixels - Converter.DpToPx(40f) - Converter.DpToPx(8f)) / 2.2f);
					int height = (int)((float)num / 1.8918918f);
					return new RecyclerView.LayoutParams(num, height);
				}
			});
			recyclerView.AddItemDecoration(new HorizontalSpaceItemDecoration(8, 20, 20));
		}
		ConfigureGameBannerRecyclerTouch(recyclerView);
		ObservableRecyclerAdapter<BannerItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<BannerItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493207,
			BindViewHolderDelegate = delegate(CachingViewHolder holder, BannerItemViewModel model, int _, CompositeDisposable d)
			{
				base.ViewModel.OnBannerShown(model);
				SkottieAnimationView skottieAnimationView = holder.RequireCachedView<SkottieAnimationView>(2131296376);
				ImageView imageView = holder.RequireCachedView<ImageView>(2131296377);
				if (string.IsNullOrWhiteSpace(model.Banner.Animation))
				{
					imageView.FromUrl(model.Banner.CarouselImage);
					skottieAnimationView.Visibility = ViewStates.Gone;
					imageView.Visibility = ViewStates.Visible;
				}
				else
				{
					skottieAnimationView.FromUrl(model.Banner.Animation, $"{model.Banner.Id}_lottie_animation");
					imageView.Visibility = ViewStates.Gone;
					skottieAnimationView.Visibility = ViewStates.Visible;
				}
				base.ViewModel.BindEvents(((View)skottieAnimationView).OnClick((Action)delegate
				{
					base.ViewModel.OnBannerClicked(model);
				}), ((View)imageView).OnClick((Action)delegate
				{
					base.ViewModel.OnBannerClicked(model);
				})).AddTo(d);
			},
			DataSource = banners
		};
		recyclerView.SetAdapter(adapter);
		recyclerView.ScrollToPosition(0);
	}

	private static void ConfigureGameBannerRecyclerTouch(RecyclerView recyclerView)
	{
		recyclerView.NestedScrollingEnabled = false;
		if (recyclerView.GetTag(2131296378) != null)
		{
			return;
		}
		float initialX = 0f;
		float initialY = 0f;
		recyclerView.SetOnTouchListener(new ViewOnTouchListener(delegate(View view, MotionEvent e)
		{
			switch (e.ActionMasked)
			{
			case MotionEventActions.Down:
				initialX = e.GetX();
				initialY = e.GetY();
				view.Parent?.RequestDisallowInterceptTouchEvent(disallowIntercept: true);
				break;
			case MotionEventActions.Move:
			{
				float num = Math.Abs(e.GetX() - initialX);
				float num2 = Math.Abs(e.GetY() - initialY);
				if (num2 > num && num2 > 8f)
				{
					view.Parent?.RequestDisallowInterceptTouchEvent(disallowIntercept: false);
				}
				else if (num > 8f)
				{
					view.Parent?.RequestDisallowInterceptTouchEvent(disallowIntercept: true);
				}
				break;
			}
			case MotionEventActions.Up:
			case MotionEventActions.Cancel:
				view.Parent?.RequestDisallowInterceptTouchEvent(disallowIntercept: false);
				break;
			}
			return false;
		}));
		recyclerView.SetTag(2131296378, true);
	}

	private void SetupGameBanner(SkottieAnimationView animation, ImageView image, BannerItemViewModel banner, CompositeDisposable disposables, bool isShort)
	{
		if (string.IsNullOrWhiteSpace(banner.Banner.Animation))
		{
			image.FromUrl(isShort ? banner.Banner.ShortImage : banner.Banner.Image);
			animation.Visibility = ViewStates.Gone;
			image.Visibility = ViewStates.Visible;
		}
		else
		{
			animation.FromUrl(banner.Banner.Animation, $"{banner.Banner.Id}_lottie_animation");
			image.Visibility = ViewStates.Gone;
			animation.Visibility = ViewStates.Visible;
		}
		base.ViewModel.OnBannerShown(banner);
		base.ViewModel.BindEvents(((View)animation).OnClick((Action)delegate
		{
			base.ViewModel.OnBannerClicked(banner);
		}), ((View)image).OnClick((Action)delegate
		{
			base.ViewModel.OnBannerClicked(banner);
		})).AddTo(disposables);
	}

	private void SetupCardsBlock(CachingViewHolder viewHolder, CompositeDisposable disposables)
	{
		CardControls cardControls = new CardControls(viewHolder.RequireCachedView<ViewGroup>(2131298362));
		CardControls cardControls2 = new CardControls(viewHolder.RequireCachedView<ViewGroup>(2131298281));
		CardControls cardControls3 = new CardControls(viewHolder.RequireCachedView<ViewGroup>(2131297214));
		View view = viewHolder.RequireCachedView<View>(2131296641);
		cardControls2.TextView.Text = base.ViewModel.SalesAndNewsCardTitle;
		cardControls2.ImageView.SetImageResource(2131231327);
		cardControls3.TextView.Text = base.ViewModel.ForBusinessCardTitle;
		cardControls3.ImageView.SetImageResource(2131231179);
		cardControls.TextView.Text = base.ViewModel.ShopsCardTitle;
		cardControls.ImageView.SetImageResource(2131231197);
		ViewGroup.MarginLayoutParams marginLayoutParams = (ViewGroup.MarginLayoutParams)cardControls3.View.LayoutParameters;
		int num = marginLayoutParams.Width + marginLayoutParams.MarginStart + marginLayoutParams.MarginEnd;
		int num2 = View.Width - view.PaddingStart;
		int num3 = num2 / num;
		if ((double)((View.Width - num3 * num) % num) * 1.0 / (double)num < 0.25)
		{
			double num4 = (double)num3 + 0.25;
			double scale = (double)num2 / num4 / (double)num;
			viewHolder.ItemView.ScaleLayoutDimensions(scale);
		}
		base.ViewModel.BindEvents(cardControls.View.OnClick(base.ViewModel.OnOpenShopListClicked), cardControls2.View.OnClick(base.ViewModel.OnOpenSalesAndNewsClicked), cardControls3.View.OnClick(base.ViewModel.ForBusinessCommand.Trigger)).AddTo(disposables);
	}

	private void SetupBannerSlider(CachingViewHolder viewHolder, IReadOnlyList<BannerItemViewModel> models, CompositeDisposable disposables)
	{
		SliderView sliderView = viewHolder.RequireCachedView<SliderView>(2131298379);
		float num = (float)(base.Resources.DisplayMetrics.WidthPixels - sliderView.ViewPager.PaddingStart - sliderView.ViewPager.PaddingEnd) / 2.1612904f;
		TouchListenerViewGroup pagerTouchIntercepter = sliderView.TouchListener;
		ViewPager2 pager = sliderView.ViewPager;
		sliderView.Indicator.Visibility = ViewStates.Gone;
		ViewGroup.LayoutParams layoutParameters = pagerTouchIntercepter.LayoutParameters;
		layoutParameters.Height = (int)num;
		pagerTouchIntercepter.LayoutParameters = layoutParameters;
		pagerTouchIntercepter.RequestLayout();
		EndlessRecyclerAdapter<BannerItemViewModel> endlessRecyclerAdapter = new EndlessRecyclerAdapter<BannerItemViewModel>
		{
			MinItemsForEndless = 2,
			CellLayoutId = 2131493246,
			BindViewHolderDelegate = delegate(CachingViewHolder h, BannerItemViewModel vm, int p, CompositeDisposable d)
			{
				OnBindBanner(h, vm, p, d, pagerTouchIntercepter);
			},
			DataSource = models
		};
		pager.OffscreenPageLimit = 2;
		pager.SetPageTransformer(new MarginPageTransformer(Converter.DpToPx(10f)));
		pager.Adapter = endlessRecyclerAdapter;
		pager.RegisterOnPageChangeCallback(new ViewPager2OnPageChangeCallback(null, delegate(int position, float offset, int _)
		{
			EndlessRecyclerAdapter<BannerItemViewModel> endlessRecyclerAdapter2 = (EndlessRecyclerAdapter<BannerItemViewModel>)(pager?.Adapter);
			int num2 = endlessRecyclerAdapter2.RealPosition(position);
			if (offset < 0.2f && endlessRecyclerAdapter2 != null && endlessRecyclerAdapter2.DataSource.Count > num2)
			{
				base.ViewModel.OnBannerShown(endlessRecyclerAdapter2.DataSource[num2]);
			}
		}));
		_autoScroller.AddPagerForSimultaneouslyScrolling(pager).AddTo(disposables);
		pagerTouchIntercepter.AddTouchListener(_autoScroller);
		BindRelatedInterceptors(pagerTouchIntercepter);
		Disposable.Create(delegate
		{
			pagerTouchIntercepter.RemoveTouchListener(_autoScroller);
			_interceptors.Remove(pagerTouchIntercepter);
		}).AddTo(disposables);
		if (models.Count > 0)
		{
			pager.SetCurrentItem(endlessRecyclerAdapter.FirstItemAdapterPosition, smoothScroll: false);
		}
	}

	private void BindRelatedInterceptors(TouchListenerViewGroup pagerTouchInterceptor)
	{
		_interceptors.Add(pagerTouchInterceptor);
		foreach (TouchListenerViewGroup interceptor in _interceptors)
		{
			interceptor.Callback = delegate(MotionEvent e)
			{
				_interceptors.Where((TouchListenerViewGroup x) => x != interceptor).ForEach(delegate(TouchListenerViewGroup x)
				{
					x.PassRelatedTouchEvent(e);
				});
			};
		}
	}

	private void OnBindBanner(CachingViewHolder holder, BannerItemViewModel model, int position, CompositeDisposable disposable, View pagerTouchInterceptor)
	{
		holder.RequireCachedView<ImageView>(2131297319).FromUrl(model.Banner.Image);
		holder.ItemView.OnClick((Action)delegate
		{
			if (pagerTouchInterceptor.Clickable)
			{
				base.ViewModel.OnBannerClicked(model);
			}
		}).AddTo(disposable);
	}

	private void SetupTextView(CachingViewHolder viewHolder, string text, CompositeDisposable disposables)
	{
		viewHolder.RequireCachedView<TextView>(2131298603).Text = text;
	}

	private void OpenSoftUpdate()
	{
		_queueManager.Show<SoftUpdateFragment>();
	}

	private async Task OpenIsArrivedDialog(OrderItemViewModel order)
	{
		if (await ShowAutoDialog(order) == AgreeState.Yes && Platform.CurrentActivity is AppCompatActivity)
		{
			base.ViewModel.OnIAmHereWithAuto().SafeFireAndForget((Action<Exception>)null, false);
			Show<AlreadyBringingPopupFragment>();
		}
	}

	private void OpenPersonalizedGreeting(Unit p)
	{
		_queueManager.Show<LoyaltyPersonalizedGreetingFragment>();
	}

	private void OpenNewYearGamePopup(Unit p)
	{
		_queueManager.Show<NewYearGamePopupDialogFragment>();
	}

	private void OpenNewYearSantaPopup(SantaPopupDialogViewModel.Parameter parameter)
	{
		_queueManager.Show<SantaPopupDialogFragment>(parameter);
	}

	private void OnOpenSearch(View obj)
	{
		SearchProductsResultFragment.OpenSearch(this);
		base.ViewModel.OnSearchClick();
	}

	private void NavigateToTab(int resourceId)
	{
		BottomNavigationView bottomNavigationView = base.Activity.RequireViewById<BottomNavigationView>(2131296565);
		if (bottomNavigationView != null)
		{
			bottomNavigationView.SelectedItemId = resourceId;
		}
	}

	private void OpenOnboardings(OnboardingsViewModel.Parameter parameter)
	{
		_queueManager.Show<OnboardingsFragment>(parameter);
	}

	private void ShowTooltip(TooltipViewModel.Parameter parameter)
	{
		new TooltipBuilder().AddView(2131297490, TooltipTargetType.LoyaltyCard).AddView(2131296800, TooltipTargetType.QrCodeButton, -8f).AddView(2131297940, TooltipTargetType.Points, -8f)
			.AddView(2131297104, TooltipTargetType.ExpressPoints, -8f)
			.AddView(2131297531, TooltipTargetType.Marks, -8f)
			.AddView(2131296657, TooltipTargetType.Details, -8f)
			.AddView(2131297985, TooltipTargetType.PriceChecker, 0f, Converter.DpToPx(8f))
			.AddView(2131297293, TooltipTargetType.FavoriteCategories)
			.SetScrollView(2131298187)
			.SetTargetView(2131297293)
			.ShowInQueue(_queueManager, parameter);
	}

	private void OpenExtraPromotion(ExtraPromotionViewModel.Parameter promotion)
	{
		_queueManager.Show<ExtraPromotionFragment>(promotion);
	}

	void SwipeRefreshLayout.IOnRefreshListener.OnRefresh()
	{
		base.ViewModel.RefreshCommand.Trigger();
	}

	private void ShowWaitingForReviewPopup()
	{
		_queueManager.Show<WaitingForReviewPopupFragment>();
	}

	private void RequestExpressDeliveryHighlight()
	{
		if (_canShowExpressDeliveryHighlightOnCurrentResume && !_expressDeliveryHighlightRequestedOnCurrentResume)
		{
			_expressDeliveryHighlightRequestedOnCurrentResume = true;
			_expressDeliveryHighlightPending = true;
			TryQueueExpressDeliveryHighlight();
			_receiveMethodSelectView?.Post(TryQueueExpressDeliveryHighlight);
		}
	}

	private void TryQueueExpressDeliveryHighlight()
	{
		if (!_expressDeliveryHighlightPending || View == null || _appBar == null || base.AutoLayoutRecycler == null)
		{
			return;
		}
		if (!_appBar.IsFullyExpanded() || !base.AutoLayoutRecycler.IsAtTop())
		{
			_expressDeliveryHighlightPending = false;
		}
		else if (_receiveMethodSelectView != null && _receiveMethodSelectView.ExpressCell != null && base.ViewModel.State == VisualState.Default && base.IsAdded && base.IsResumed && !base.IsHidden && IsLastInHomeStack())
		{
			_receiveMethodSelectView.PrepareForHighlight();
			BrokerToken brokerToken = base.ViewModel.ReceiveMethodViewModel.CreateExpressDeliveryHighlight();
			if (brokerToken == null)
			{
				_expressDeliveryHighlightPending = false;
				return;
			}
			_expressDeliveryHighlightPending = false;
			new HighlightBundleBuilder().AddView(_receiveMethodSelectView.ExpressCell.Id, 0f, Converter.DpToPx(8f)).SetSearchRoot(2131297293).SetTargetView(_receiveMethodSelectView.Id)
				.ShowInQueue<ExpressDeliveryHighlightScreenFragment>(_queueManager, brokerToken, CanShowExpressDeliveryHighlight);
		}
	}

	private bool CanShowExpressDeliveryHighlight()
	{
		if (_canShowExpressDeliveryHighlightOnCurrentResume && View != null && _appBar != null && base.AutoLayoutRecycler != null && _appBar.IsFullyExpanded() && base.AutoLayoutRecycler.IsAtTop() && _receiveMethodSelectView?.ExpressCell != null && base.ViewModel.State == VisualState.Default && base.IsAdded && base.IsResumed && !base.IsHidden)
		{
			return IsLastInHomeStack();
		}
		return false;
	}

	private void UpdateExpressDeliveryHighlightAvailability()
	{
		if (!_expressDeliveryHighlightAvailabilityChecked && _appBar != null && base.AutoLayoutRecycler != null)
		{
			_expressDeliveryHighlightAvailabilityChecked = true;
			_canShowExpressDeliveryHighlightOnCurrentResume = _appBar.IsFullyExpanded() && base.AutoLayoutRecycler.IsAtTop();
			if (!_canShowExpressDeliveryHighlightOnCurrentResume)
			{
				_expressDeliveryHighlightPending = false;
			}
		}
	}

	private void ResetExpressDeliveryHighlightAvailability()
	{
		_expressDeliveryHighlightAvailabilityChecked = false;
		_canShowExpressDeliveryHighlightOnCurrentResume = false;
	}

	private void RetryExpressDeliveryHighlight()
	{
		_queueManager.RaiseQueue();
		TryQueueExpressDeliveryHighlight();
	}

	private void RetryExpressDeliveryHighlightWhenClosed(DialogFragment dialog)
	{
		if (_observedDialogs.Add(dialog))
		{
			_expressDeliveryHighlightRequestedOnCurrentResume = false;
			dialog.LaunchWhen(delegate
			{
				_observedDialogs.Remove(dialog);
				ResetExpressDeliveryHighlightAvailability();
				UpdateExpressDeliveryHighlightAvailability();
				base.ViewModel.ReceiveMethodViewModel.ShowExpressDeliveryHighlightIfNeeded();
				RetryExpressDeliveryHighlight();
			}, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		}
	}

	private bool IsLastInHomeStack()
	{
		AndroidX.Fragment.App.Fragment fragment = base.Activity?.SupportFragmentManager.FindFragmentById(2131296564);
		if (!(fragment is BottomNavigationHostFragment) || !fragment.IsAdded || fragment.IsHidden)
		{
			return false;
		}
		bool num = base.ParentFragmentManager.ObserveActiveDialogs(_observedDialogs, RetryExpressDeliveryHighlight);
		bool flag = base.ChildFragmentManager.ObserveActiveDialogs(_observedDialogs, RetryExpressDeliveryHighlight);
		if (!num)
		{
			return !flag;
		}
		return false;
	}

	private Task<AgreeState> ShowAutoDialog(OrderItemViewModel order)
	{
		if (Platform.CurrentActivity is AppCompatActivity)
		{
			AskIsPersonArrivedViewModel.Parameter parameter = new AskIsPersonArrivedViewModel.Parameter(order.OrderId);
			return Show<AskIsPersonArrivedFragment, AskIsPersonArrivedViewModel.Parameter>(parameter).Execute();
		}
		return Task.FromResult(AgreeState.None);
	}

	private void SetupDigitalCatalog(CachingViewHolder viewHolder, BannerItemViewModel item, CompositeDisposable disposables)
	{
		viewHolder.RequireCachedView<ImageView>(2131296984).FromUrl(item.Banner.Image);
		base.ViewModel.OnBannerShown(item);
		viewHolder.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.OnBannerClicked(item);
		}).AddTo(disposables);
	}

	private void SetupHorizontalRecommendations(CachingViewHolder vh, object data, CompositeDisposable disposables)
	{
		if (!(data is SectionItemViewModel sectionItemViewModel))
		{
			throw new ArgumentException("data is not SectionItemViewModel");
		}
		int num = Converter.DpToPx(20f);
		new RecommendationSectionBindings(vh, sectionItemViewModel.Parent, nestedScrollEnabled: false).Bind(sectionItemViewModel, base.ViewModel, OperatingSystem.IsAndroidVersionAtLeast(23) ? new Func<View, IObservable<bool>>(base.AutoLayoutRecycler.BecameVisible) : null, 0, num, num, disposables);
	}

	private void RequestNotificationPermission()
	{
		if (OperatingSystem.IsAndroidVersionAtLeast(33) && ContextCompat.CheckSelfPermission(Context, "android.permission.POST_NOTIFICATIONS") != Permission.Granted && !ShouldShowRequestPermissionRationale("android.permission.POST_NOTIFICATIONS"))
		{
			RequestPermissions(new string[1] { "android.permission.POST_NOTIFICATIONS" }, 865);
		}
	}

	private void OnBindHomeMyOffer(RecyclerView parent, CachingViewHolder holder, HomeMyOfferItemViewModel model, int position, CompositeDisposable disposable)
	{
		CardView cardView = holder.RequireCachedView<CardView>(2131296491);
		TextView textView = holder.RequireCachedView<TextView>(2131298646);
		TextView textView2 = holder.RequireCachedView<TextView>(2131296958);
		Button button = holder.RequireCachedView<Button>(2131296587);
		TextView textView3 = holder.RequireCachedView<TextView>(2131298642);
		View newIndicator = holder.RequireCachedView<View>(2131297338);
		ViewGroup viewGroup = holder.RequireCachedView<ViewGroup>(2131296713);
		textView.Text = model.TitleText;
		textView2.Text = model.DescriptionText;
		textView3.Text = model.TimeText;
		button.Text = model.ButtonText;
		textView3.Visibility = (model.Type != MainMyOfferType.FavoriteCategories).ToInvisibleVisibility();
		viewGroup.Visibility = (model.Type == MainMyOfferType.FavoriteCategories).ToInvisibleVisibility();
		button.Visibility = textView3.Visibility;
		cardView.SetCardBackgroundColor(Color.Rgb(model.BackgroundColor.R, model.BackgroundColor.G, model.BackgroundColor.B));
		model.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				button.Text = model.ButtonText;
				button.Enabled = !model.IsActivated;
				button.SetBackgroundColor(new Color(ContextCompat.GetColor(RequireContext(), model.IsActivated ? 2131100615 : 2131100611)));
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "ButtonText", "IsActivated" })),
			(delegate
			{
				newIndicator.Visibility = model.IsNew.ToInvisibleVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsNew"))
		})).AddTo(disposable);
		switch (model.Type)
		{
		case MainMyOfferType.FavoriteCategories:
		{
			FavoriteCategoriesItemViewModel item = model.Data as FavoriteCategoriesItemViewModel;
			ImageView imageView3 = holder.RequireCachedView<ImageView>(2131296718);
			ImageView imageView4 = holder.RequireCachedView<ImageView>(2131296716);
			ImageView imageView5 = holder.RequireCachedView<ImageView>(2131296722);
			ImageView imageView6 = holder.RequireCachedView<ImageView>(2131296720);
			ImageView imageView7 = holder.RequireCachedView<ImageView>(2131296726);
			ImageView imageView8 = holder.RequireCachedView<ImageView>(2131296724);
			ViewGroup viewGroup3 = holder.RequireCachedView<ViewGroup>(2131297627);
			TextView textView4 = holder.RequireCachedView<TextView>(2131296858);
			imageView4.Visibility = item.Accepted.ToVisibility();
			imageView6.Visibility = item.Accepted.ToVisibility();
			imageView8.Visibility = item.Accepted.ToVisibility();
			if (item.Accepted)
			{
				if (item.Images.Length > 2)
				{
					imageView8.FromUrl(item.Images[2]);
				}
				if (item.Images.Length > 1)
				{
					imageView6.FromUrl(item.Images[1]);
				}
				if (item.Images.Length != 0)
				{
					imageView4.FromUrl(item.Images[0]);
				}
				viewGroup3.Visibility = item.CountVisible.ToVisibility();
				imageView3.Visibility = ViewStates.Gone;
				imageView5.Visibility = ViewStates.Gone;
				imageView7.Visibility = ViewStates.Gone;
			}
			textView4.Text = item.Count;
			textView4.SetRoundedCorners(18f);
			holder.ItemView.OnClick((Action)delegate
			{
				base.ViewModel.OpenFavoriteCategories(item);
			}).AddTo(disposable);
			break;
		}
		case MainMyOfferType.Coupon:
			model.BindEvents(holder.ItemView.OnClick((Action)delegate
			{
				base.ViewModel.CouponTapped(model.Data as Coupon);
			}), ((View)button).OnClick((Action)delegate
			{
				base.ViewModel.CouponTapped(model.Data as Coupon);
			})).AddTo(disposable);
			break;
		case MainMyOfferType.PersonalOffer:
		{
			ViewGroup viewGroup2 = holder.RequireCachedView<ViewGroup>(2131298650);
			ImageView imageView = holder.RequireCachedView<ImageView>(2131298653);
			ImageView imageView2 = holder.RequireCachedView<ImageView>(2131298657);
			model.BindEvents(holder.ItemView.OnClick((Action)delegate
			{
				base.ViewModel.OnPersOfferTapped(model.Data as PersOfferItemViewModel);
			}), ((View)button).OnClick((Action)delegate
			{
				base.ViewModel.OnPersOfferActivated(model);
			})).AddTo(disposable);
			ViewGroup.MarginLayoutParams marginLayoutParams = (ViewGroup.MarginLayoutParams)textView.LayoutParameters;
			int num = 4;
			switch ((model.Data as PersOfferItemViewModel).DisplayType)
			{
			case OfferDisplayType.Cashback:
			{
				viewGroup2.SetBackgroundColor(new Color(ContextCompat.GetColor(Context, 2131100541)));
				imageView.SetImageResource(2131231063);
				imageView2.SetImageResource(2131231435);
				ViewStates visibility = (imageView2.Visibility = ViewStates.Visible);
				imageView.Visibility = visibility;
				textView.SetTextColor(Context.GetColorStateList(2131099697));
				break;
			}
			case OfferDisplayType.Discount:
			{
				viewGroup2.SetBackgroundColor(new Color(ContextCompat.GetColor(Context, 2131100542)));
				imageView.SetImageResource(2131231330);
				imageView2.SetImageResource(2131231436);
				ViewStates visibility = (imageView2.Visibility = ViewStates.Visible);
				imageView.Visibility = visibility;
				textView.SetTextColor(Context.GetColorStateList(2131099697));
				break;
			}
			default:
			{
				viewGroup2.SetBackgroundColor(Color.Transparent);
				ViewStates visibility = (imageView2.Visibility = ViewStates.Gone);
				imageView.Visibility = visibility;
				num = 0;
				textView.SetTextColor(Context.GetColorStateList(2131099872));
				break;
			}
			}
			marginLayoutParams.SetMargins(Converter.DpToPx(num), 0, 0, 0);
			textView.LayoutParameters = marginLayoutParams;
			break;
		}
		}
	}

	private void OnBindSeasonOffers(RecyclerView parent, CachingViewHolder holder, BannerItemViewModel model, int position, CompositeDisposable disposable)
	{
		ViewGroup.MarginLayoutParams marginLayoutParams = (ViewGroup.MarginLayoutParams)holder.ItemView.LayoutParameters;
		int num = marginLayoutParams.Width + marginLayoutParams.MarginStart + marginLayoutParams.MarginEnd;
		int num2 = View.Width - parent.PaddingStart;
		int num3 = num2 / num;
		if ((double)((View.Width - num3 * num) % num) * 1.0 / (double)num < 0.25)
		{
			double num4 = (double)num3 + 0.25;
			double scale = (double)num2 / num4 / (double)num;
			holder.ItemView.ScaleLayoutDimensions(scale);
		}
		holder.RequireCachedView<ImageView>(2131298324).FromUrl(model.Banner.Image);
		holder.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.SeasonOfferClickCommand.Trigger(model);
		}).AddTo(disposable);
	}

	public void OnOffsetChanged(AppBarLayout appBarLayout, int verticalOffset)
	{
		_swipeRefreshLayout.Enabled = verticalOffset == 0;
	}

	private void ShowQtyRecommendationsInputDialog(ProductItemViewModel vm)
	{
		ProductItemViewHolder.ShowQtyInputDialog(vm, base.LayoutInflater, Context);
	}

	private void NavigateToMyFavoriteCategories(MyFavoriteCategoriesViewModel.Parameter p)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<MyFavoriteCategoriesFragment>(this, p.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	private async Task ShowAdultWarning()
	{
		FragmentManager supportFragmentManager = RequireActivity().SupportFragmentManager;
		RepeatAdultProductWarningPopupFragment repeatAdultProductWarningPopupFragment = supportFragmentManager.FragmentFactory.Instantiate<RepeatAdultProductWarningPopupFragment>();
		repeatAdultProductWarningPopupFragment.Show(supportFragmentManager, null);
		if (await repeatAdultProductWarningPopupFragment.Execute())
		{
			await base.ViewModel.OrdersHomeViewModel.RepeatOrderService.ShowAddressSelection();
		}
	}
}
