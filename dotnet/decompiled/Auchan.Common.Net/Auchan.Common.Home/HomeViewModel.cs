using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.Loymax;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Controls.AutoLayout;
using Auchan.Common.Deeplinks;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.Banners;
using Auchan.Common.Ecom.Banners.Models;
using Auchan.Common.Ecom.Banners.ViewModels;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Ecom.CtmShelves;
using Auchan.Common.Ecom.CtmShelves.Models;
using Auchan.Common.Ecom.CtmShelves.ViewModels;
using Auchan.Common.Ecom.Onboardings;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.HardUpdate;
using Auchan.Common.Helpers;
using Auchan.Common.Home.MainMyOffers;
using Auchan.Common.Logs;
using Auchan.Common.LoyaltyProgram;
using Auchan.Common.LoyaltyProgram.Coupons;
using Auchan.Common.LoyaltyProgram.Coupons.Infrastructure;
using Auchan.Common.LoyaltyProgram.Coupons.Models;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.Services;
using Auchan.Common.LoyaltyProgram.ViewModels;
using Auchan.Common.Maintenance;
using Auchan.Common.Navigation;
using Auchan.Common.NewYearGame;
using Auchan.Common.Notifications;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.Profile.Orders;
using Auchan.Common.Profile.Orders.Models;
using Auchan.Common.Profile.Orders.Services;
using Auchan.Common.Profile.WaitList;
using Auchan.Common.Promotions.ExtraPromotions;
using Auchan.Common.Recommendations;
using Auchan.Common.Recommendations.API.DTO;
using Auchan.Common.Recommendations.Models;
using Auchan.Common.Recommendations.ViewModels;
using Auchan.Common.Reviews.Api.Ecom;
using Auchan.Common.Tooltips;
using Auchan.Common.UniversalLinks;
using CSharpFunctionalExtensions;
using EBind;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Home;

public class HomeViewModel : AutoLayoutScreenViewModel, IYandexMetricaScreenViewModel, IScreenViewModel, IProductCellSupport
{
	private enum BlockOrder
	{
		ReceiveMethods,
		LoyaltyCard,
		Search,
		UserNotification,
		GameBanner,
		MyOffersBlock,
		CtmShelfOffers,
		OrdersHeader,
		OrderItem,
		SeasonBanners,
		HomeCardsBlock,
		RepeatOrders,
		DigitalCatalogBanner,
		CtmShelfHotPrice,
		TopRecommendations,
		FirstSlider,
		SecondSlider,
		Title,
		ThirdSlider,
		BottomRecommendations
	}

	public const float BannerRatio = 2.1612904f;

	private readonly IEcomContext _ecomContext;

	private readonly Lazy<IHomeScreenTracker> _homeScreenTracker;

	private readonly Lazy<IUserContext> _userContext;

	private readonly Lazy<IAdminContext> _adminContext;

	private readonly Lazy<ILogService> _logService;

	private readonly Lazy<IDataBroker> _dataBroker;

	private readonly Func<RecommendationBuilder> _recommendationBuilderFactory;

	private readonly Lazy<ILoyaltyPersonalizedGreetingsManager> _loyaltyPersonalizedGreetingsManager;

	private readonly Lazy<IInfoMessageService> _infoMessageService;

	private readonly Lazy<ITooltipsManager> _tooltipsManager;

	private readonly Lazy<IExtraPromotionService> _extraPromotionService;

	private readonly Lazy<PaymentUrlHelper> _paymentUrlHelper;

	private readonly Lazy<IOrdersRepository> _ordersRepository;

	private readonly Lazy<IUniversalLinksService> _universalLinksService;

	private readonly Lazy<IOnboardingsManager> _onboardingsManager;

	private readonly Lazy<AppMetrica> _appMetrica;

	private readonly Lazy<ReviewsEcomRepository> _reviewsEcomRepository;

	private readonly Lazy<LoymaxPushTokenService> _loymaxPushTokenService;

	private readonly Lazy<WaitListProducts> _waitListProducts;

	private readonly Lazy<IMaintenanceManager> _maintenanceManager;

	private readonly Lazy<IRecommendationsGimaIdCache> _recommendationsGimaIdCache;

	private readonly Lazy<IUpdateService> _updateService;

	private readonly Lazy<FavoriteCategoriesRepository> _favoriteCategoriesRepository;

	private readonly IBannersRepository _bannersRepository;

	private readonly Lazy<CouponsRepository> _couponsRepository;

	private readonly Lazy<INavigationContext> _navigationContext;

	private readonly ICtmShelvesService _ctmShelvesService;

	private readonly Func<Shelf, IProductCellSupport, ShelfItemViewModel> _ctmShelfItemViewModelFactory;

	private readonly NotAuthReopenScreenService _notAuthReopenScreenService;

	private readonly NotificationsCounterService _notificationsCounterService;

	private readonly Subject<Unit> _navigateToNotifications = new Subject<Unit>();

	private bool? _locationPermissionGranted;

	private bool _firstStart = true;

	private bool _onboardingWasAddedToQueue;

	private bool _repeatCompletedOrderTracked;

	private bool _seasonOffersTracked;

	private int _lastTrackedBannerId = -1;

	private readonly CompositeDisposable _shelvesDisposabe = new CompositeDisposable();

	private volatile int _loadCtmShelvesSpinRequestId;

	[CompilerGenerated]
	private UICommand _003COpenSalesAndNewsCommand_003Ek__BackingField;

	private readonly Subject<Unit> _openCatalogInput = new Subject<Unit>();

	private readonly Subject<Unit> _openCatalogOutput = new Subject<Unit>();

	private readonly Subject<Unit> _openFavorites = new Subject<Unit>();

	private readonly Subject<Unit> _openShopList = new Subject<Unit>();

	private readonly Subject<Unit> _retry = new Subject<Unit>();

	private readonly Subject<ProductsViewModel.Parameter> _openProductsInput = new Subject<ProductsViewModel.Parameter>();

	private readonly Subject<ProductsViewModel.Parameter> _openProductsOutput = new Subject<ProductsViewModel.Parameter>();

	private readonly Subject<Unit> _navigateOrders = new Subject<Unit>();

	private readonly Subject<Deeplink> _openDeeplink = new Subject<Deeplink>();

	private readonly Subject<Unit> _showPersonalizedGreetingTrigger = new Subject<Unit>();

	private readonly Subject<Unit> _openNewYearGamePopup = new Subject<Unit>();

	private readonly Subject<SantaPopupDialogViewModel.Parameter> _openNewYearSantaPopup = new Subject<SantaPopupDialogViewModel.Parameter>();

	private readonly Subject<TooltipViewModel.Parameter> _openTooltips = new Subject<TooltipViewModel.Parameter>();

	private readonly Subject<ExtraPromotionViewModel.Parameter> _openExtraPromotion = new Subject<ExtraPromotionViewModel.Parameter>();

	private bool _isCurrentScreen;

	private Lazy<bool> _lazyIsPriceCheckerEnabled;

	private bool _recommendationsViewed;

	private bool _loadingMyOffers;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CMyOffersIndicatorText_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CNotificationsCount_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<OnboardingsViewModel.Parameter> _003COpenOnboardingsCommand_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CShowOffersAllButton_003Ek__BackingField;

	private readonly CompositeDisposable _topSectionsDisposable = new CompositeDisposable();

	private readonly CompositeDisposable _bottomSectionsDisposable = new CompositeDisposable();

	public UICommand OpenSalesAndNewsCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenSalesAndNewsCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COpenSalesAndNewsCommand_003Ek__BackingField, value))
			{
				_003COpenSalesAndNewsCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenSalesAndNewsCommand");
			}
		}
	} = new UICommand();

	private bool IsPopupShouldBeAutoFirstShown
	{
		get
		{
			if (_adminContext.Value.AppConfig?.AppVersion != null && _adminContext.Value.AppConfig.AppVersion.IsPopupAutoFirstShown && !string.Equals(_adminContext.Value.AppConfig.AppVersion.New, _adminContext.Value.LastNewAppVersion, StringComparison.Ordinal) && !_navigationContext.Value.IsNavigatedFromStart)
			{
				return !_navigationContext.Value.IsNavigating;
			}
			return false;
		}
	}

	public WaitListNotificationBanner WaitListNotificationBanner { get; }

	public NearestOrderInfoViewModel NearestOrderInfoViewModel { get; }

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.InProgress;

	public string ErrorTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorTitle");
			}
		}
	} = string.Empty;

	public string ErrorMessage
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorMessage_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorMessage_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorMessage");
			}
		}
	} = string.Empty;

	public string ProgressTitle => "Обновляем персональные предложения…";

	public string ShopsCardTitle => "Магазины\nрядом";

	public string ForBusinessCardTitle => "Для\nбизнеса";

	public string SalesAndNewsCardTitle => "Акции\nи новости";

	public string CharityTitle => "Благотворительный фонд АШАН";

	public string SeasonOffersTitle => "Популярно сейчас";

	public string SearchPlaceholder => "Найти в АШАН";

	public string NewYearGamePlayButtonText => _adminContext.Value.AppConfig?.GameConfig?.ButtonText ?? "Играть";

	public string MyOffersTitle { get; } = "Мои предложения";

	public string MyOffersAllText { get; } = "Все";

	public bool MyOffersIndicatorVisible => !string.IsNullOrWhiteSpace(MyOffersIndicatorText);

	public string MyOffersIndicatorText
	{
		[CompilerGenerated]
		get
		{
			return _003CMyOffersIndicatorText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CMyOffersIndicatorText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CMyOffersIndicatorText_003Ek__BackingField = value;
				RaisePropertyChanged("MyOffersIndicatorVisible");
				RaisePropertyChanged("MyOffersIndicatorText");
			}
		}
	} = "2 новых";

	public UICommand<AppIconType> ChangeAppIconCommand { get; } = new UICommand<AppIconType>();

	public UICommand RegisterRemoteNotifications { get; } = new UICommand();

	public TimeSpan BannerAutoscrollDelay => TimeSpan.FromSeconds(_adminContext.Value.AppConfig.BannerAutoscrollDelay);

	public UICommand OpenPriceChecker { get; } = new UICommand();

	public UICommand OpenSoftUpdatePopupCommand { get; } = new UICommand();

	public IObservable<ProductsViewModel.Parameter> OpenProductsCommand => _openProductsOutput;

	public IObservable<Unit> OpenCatalogCommand => _openCatalogOutput;

	public IObservable<Unit> OpenFavoritesCommand => _openFavorites.Debounce();

	public IObservable<Unit> OpenNotificationsCommand => _navigateToNotifications.Debounce();

	public UICommand OpenWaitListCommand { get; } = new UICommand();

	public int NotificationsCount
	{
		[CompilerGenerated]
		get
		{
			return _003CNotificationsCount_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CNotificationsCount_003Ek__BackingField != value)
			{
				_003CNotificationsCount_003Ek__BackingField = value;
				RaisePropertyChanged("HasNotifications");
				RaisePropertyChanged("NotificationsCount");
			}
		}
	}

	public bool HasNotifications => NotificationsCount > 0;

	public IObservable<Unit> OpenShopListCommand => _openShopList.Debounce();

	public IObservable<Deeplink> OpenDeeplinkCommand => _openDeeplink.Debounce();

	public IObservable<Unit> OnNavigateOrders => _navigateOrders.Debounce();

	public IObservable<Unit> ShowPersonalizedTriggerCommand => _showPersonalizedGreetingTrigger.Debounce();

	public UICommand OpenMyOffersCommand { get; } = new UICommand();

	public IObservable<Unit> OpenNewYearGamePopupCommand => _openNewYearGamePopup.Debounce();

	public IObservable<SantaPopupDialogViewModel.Parameter> OpenNewYearSantaPopupCommand => _openNewYearSantaPopup.Debounce();

	public UICommand<AddressViewModel.Parameter> OpenAddressCheckCommand { get; } = new UICommand<AddressViewModel.Parameter>();

	public UICommand<OnboardingsViewModel.Parameter> OpenOnboardingsCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenOnboardingsCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003COpenOnboardingsCommand_003Ek__BackingField, value))
			{
				_003COpenOnboardingsCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenOnboardingsCommand");
			}
		}
	} = new UICommand<OnboardingsViewModel.Parameter>();

	public IObservable<TooltipViewModel.Parameter> OpenTooltipsCommand => _openTooltips;

	public IObservable<ExtraPromotionViewModel.Parameter> OpenExtraPromotion => _openExtraPromotion;

	public UICommand<CheckoutWebViewModel.Parameter> OpenPaymentCommand { get; } = new UICommand<CheckoutWebViewModel.Parameter>();

	public UICommand SeasonOffersScrollCommand { get; } = new UICommand();

	public UICommand<BannerItemViewModel> SeasonOfferClickCommand { get; } = new UICommand<BannerItemViewModel>();

	public UICommand RefreshCommand { get; } = new UICommand();

	public UICommand RefreshDoneCommand { get; } = new UICommand();

	public UICommand ShowWaitingForReviewPopupCommand { get; } = new UICommand();

	public OrdersHomeViewModel OrdersHomeViewModel { get; }

	public EndlessRecommendationsViewModel Recommendations { get; }

	public RecommendationsViewModel TopRecommendations { get; }

	public RecommendationsViewModel BottomRecommendations { get; }

	public ReceiveMethodSelectElementViewModel ReceiveMethodViewModel { get; }

	public LoyaltyCardElementViewModel LoyaltyCardViewModel { get; }

	public ObservableRangeCollection<HomeMyOfferItemViewModel> MyOffersViewModels { get; } = new ObservableRangeCollection<HomeMyOfferItemViewModel>();

	public UICommand ForBusinessCommand { get; } = new UICommand();

	public UICommand<BrokerToken> OpenCouponDetailsCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<ProductDetailsViewModel.Parameter> OpenProductDetailsCommand { get; } = new UICommand<ProductDetailsViewModel.Parameter>();

	public UICommand<ProductItemViewModel> ShowQtyDialogCommand { get; } = new UICommand<ProductItemViewModel>();

	public UICommand<BrokerToken> OpenAIOfferDetailsCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<BrokerToken> OpenOfferDetailsCommand { get; } = new UICommand<BrokerToken>();

	public UICommand OpenLoyaltyTabCommand { get; } = new UICommand();

	protected override string ScreenName => "Main";

	public UICommand<MyFavoriteCategoriesViewModel.Parameter> NavigateToMyFavoriteCategoriesCommand { get; } = new UICommand<MyFavoriteCategoriesViewModel.Parameter>();

	public UICommand<FavoriteCategoriesPopupViewModel.Parameter> ShowMyFavoriteCategoriesPopupCommand { get; } = new UICommand<FavoriteCategoriesPopupViewModel.Parameter>();

	public BannerNavigationSupport BannerNavigationSupport { get; } = new BannerNavigationSupport();

	public bool IsPriceCheckerEnabled => _lazyIsPriceCheckerEnabled.Value;

	string IYandexMetricaScreenViewModel.ScreenNameForBaseEvents => "Main";

	string IYandexMetricaScreenViewModel.ScreenName => "Main";

	public bool ShowOffersAllButton
	{
		[CompilerGenerated]
		get
		{
			return _003CShowOffersAllButton_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CShowOffersAllButton_003Ek__BackingField != value)
			{
				_003CShowOffersAllButton_003Ek__BackingField = value;
				RaisePropertyChanged("ShowOffersAllButton");
			}
		}
	}

	public HomeViewModel(IEcomContext ecomContext, Lazy<IHomeScreenTracker> homeScreenTracker, Lazy<IUserContext> userContext, Lazy<IAdminContext> adminContext, Lazy<ILogService> logService, Lazy<IProductsRepository> productsRepository, Func<ICollection<IDisposable>, Func<List<OrderItemViewModel>, Task>, OrdersHomeViewModel> orderViewModelFactory, Func<RecommendationBuilder> recommendationBuilderFactory, Lazy<ILoyaltyPersonalizedGreetingsManager> loyaltyPersonalizedGreetingsManager, Lazy<IInfoMessageService> infoMessageService, Lazy<ITooltipsManager> tooltipsManager, Lazy<IExtraPromotionService> extraPromotionService, Lazy<PaymentUrlHelper> paymentUrlHelper, Lazy<IOrdersRepository> ordersRepository, Lazy<IUniversalLinksService> universalLinksService, Lazy<IOnboardingsManager> onboardingsManager, Lazy<ReviewsEcomRepository> reviewsEcomRepository, Lazy<AppMetrica> appMetrica, Func<ScreenViewModel, ReceiveMethodSelectElementViewModel> receiveMethodVMFactory, Func<LoyaltyCardScreen, ScreenViewModel, LoyaltyCardElementViewModel> loyaltyCardVMFactory, Lazy<LoymaxPushTokenService> loymaxPushTokenService, Lazy<WaitListProducts> waitListProducts, Lazy<IMaintenanceManager> maintenanceManager, Lazy<IRecommendationsGimaIdCache> recommendationsPopularCache, Lazy<IUpdateService> updateService, RecommendationsViewModel topRecommendations, RecommendationsViewModel bottomRecommendations, EndlessRecommendationsViewModel recommendations, NearestOrderInfoViewModel nearestOrderInfoViewModel, Lazy<CouponsRepository> couponsRepository, Lazy<IDataBroker> dataBroker, Lazy<FavoriteCategoriesRepository> favoriteCategoriesRepository, Lazy<INavigationContext> navigationContext, ICtmShelvesService ctmShelvesService, Func<Shelf, IProductCellSupport, ShelfItemViewModel> ctmShelfItemViewModelFactory, IBannersRepository bannersRepository, NotAuthReopenScreenService notAuthReopenScreenService, NotificationsCounterService notificationsCounterService)
	{
		_ecomContext = ecomContext;
		_homeScreenTracker = homeScreenTracker;
		_infoMessageService = infoMessageService;
		_userContext = userContext;
		_adminContext = adminContext;
		_logService = logService;
		_recommendationBuilderFactory = recommendationBuilderFactory;
		_loyaltyPersonalizedGreetingsManager = loyaltyPersonalizedGreetingsManager;
		_tooltipsManager = tooltipsManager;
		_extraPromotionService = extraPromotionService;
		_paymentUrlHelper = paymentUrlHelper;
		_ordersRepository = ordersRepository;
		_universalLinksService = universalLinksService;
		_onboardingsManager = onboardingsManager;
		_reviewsEcomRepository = reviewsEcomRepository;
		_appMetrica = appMetrica;
		_loymaxPushTokenService = loymaxPushTokenService;
		_waitListProducts = waitListProducts;
		_maintenanceManager = maintenanceManager;
		_recommendationsGimaIdCache = recommendationsPopularCache;
		_updateService = updateService;
		_couponsRepository = couponsRepository;
		_dataBroker = dataBroker;
		_navigationContext = navigationContext;
		_ctmShelvesService = ctmShelvesService;
		_ctmShelfItemViewModelFactory = ctmShelfItemViewModelFactory;
		WaitListNotificationBanner = new WaitListNotificationBanner(OnWaitListNotificationClicked);
		NearestOrderInfoViewModel = nearestOrderInfoViewModel;
		_favoriteCategoriesRepository = favoriteCategoriesRepository;
		_bannersRepository = bannersRepository;
		_notAuthReopenScreenService = notAuthReopenScreenService;
		_notificationsCounterService = notificationsCounterService;
		_notificationsCounterService.Count.Subscribe(delegate(int c)
		{
			Microsoft.Maui.ApplicationModel.MainThread.BeginInvokeOnMainThread(delegate
			{
				NotificationsCount = c;
				RaisePropertyChanged("NotificationsCount");
				RaisePropertyChanged("HasNotifications");
			});
		}).AddTo(base.CloseDisposable);
		OrdersHomeViewModel = orderViewModelFactory(base.CloseDisposable, OpenPayment);
		Recommendations = recommendations.Setup(base.CloseDisposable, this, base.AutoLayout);
		TopRecommendations = topRecommendations.Setup(base.CloseDisposable, this);
		BottomRecommendations = bottomRecommendations.Setup(base.CloseDisposable, this);
		base.ElementViewModels.Add(ReceiveMethodViewModel = receiveMethodVMFactory(this));
		base.ElementViewModels.Add(LoyaltyCardViewModel = loyaltyCardVMFactory(LoyaltyCardScreen.Home, this));
		_lazyIsPriceCheckerEnabled = new Lazy<bool>(() => GetIsPriceCheckerEnabled(_adminContext.Value, _userContext.Value));
		base.AutoLayout.Insert(AutoLayoutViewModel.AutoLayoutElement.New("HomeCardBlock", new object(), BlockOrder.HomeCardsBlock));
		if (false)
		{
		}
		_openCatalogInput.Debounce(1000).Subscribe(delegate
		{
			_openCatalogOutput.OnNext(Unit.Default);
		}).AddTo(base.CloseDisposable);
		_openProductsInput.Debounce(1000).Subscribe(delegate(ProductsViewModel.Parameter param)
		{
			_openProductsOutput.OnNext(param);
		}).AddTo(base.CloseDisposable);
		_retry.PerformDebouncingTask(Start).Subscribe().AddTo(base.CloseDisposable);
		OrdersHomeViewModel.RepeatOrderService.OnStateChanged += new DisposableDelegate<Action<VisualState>>(delegate(VisualState state)
		{
			State = state;
		}, delegate(Action<VisualState> h)
		{
			OrdersHomeViewModel.RepeatOrderService.OnStateChanged -= h;
		}).AddTo(base.CloseDisposable);
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.ActiveStore).PerformTask(OnStoreChange).Subscribe()
			.AddTo(base.CloseDisposable);
		_ecomContext.OnPropertyChanges((IEcomContext x) => x.ActiveStore).PerformTask(UpdateWaitListInfo).Subscribe()
			.AddTo(base.CloseDisposable);
		ReceiveMethodViewModel.OpenAddressSelectionCommand.PerformDebouncingTask(delegate(AddressViewModel.Parameter p)
		{
			OpenAddressCheckCommand.Trigger(p);
			return Task.CompletedTask;
		}).Subscribe().AddTo(base.CloseDisposable);
		RefreshCommand.ObserveOn(Auchan.Common.Helpers.MainThread.Scheduler).PerformDebouncingTask(OnRefresh).Subscribe()
			.AddTo(base.CloseDisposable);
		SeasonOfferClickCommand.Subscribe(OnSeasonOfferClicked).AddTo(base.CloseDisposable);
		TopRecommendations.Sections.SubscribeToCollectionChanged(OnTopRecommendationsSectionsChanged, base.CloseDisposable);
		BottomRecommendations.Sections.SubscribeToCollectionChanged(OnBottomRecommendationsSectionsChanged, base.CloseDisposable);
		ForBusinessCommand.PerformDebouncingTask(OnForBusinessCommand).Subscribe().AddTo(base.CloseDisposable);
		OrdersHomeViewModel.OnOrdersUpdated.Subscribe(delegate
		{
			UpdateOrdersBlock();
		}).AddTo(base.CloseDisposable);
		_couponsRepository.Value.CouponSeen += new DisposableDelegate<EventHandler<long>>(delegate
		{
			LoadMyOffers().SafeFireAndForget((Action<Exception>)null, true);
		}, delegate(EventHandler<long> d)
		{
			_couponsRepository.Value.CouponSeen -= d;
		}).AddTo(base.CloseDisposable);
		_favoriteCategoriesRepository.Value.FavoriteCategoriesChanged += new DisposableDelegate<EventHandler<EventArgs>>(delegate
		{
			LoadMyOffers().SafeFireAndForget((Action<Exception>)null, true);
		}, delegate(EventHandler<EventArgs?> d)
		{
			_favoriteCategoriesRepository.Value.FavoriteCategoriesChanged -= d;
		}).AddTo(base.CloseDisposable);
		_shelvesDisposabe.AddTo(base.CloseDisposable);
	}

	public void OnNotificationsClick()
	{
		AppAnalytics.AppMetrica.TrackEvent("tap_notifications");
		_navigateToNotifications.OnNext(Unit.Default);
	}

	public void OpenCouponDetails(Coupon coupon)
	{
		AppAnalytics.AppMetrica.TrackSaleCoupon(coupon);
		OpenCouponDetailsCommand.Trigger(_dataBroker.Value.Push(new CouponDetailsViewModel.Parameter(coupon)));
	}

	public void OpenLoyaltyTap()
	{
		AppAnalytics.AppMetrica.TrackEvent("TapMainOnMyOffers");
		OpenLoyaltyTabCommand.Trigger();
	}

	protected override async Task Start()
	{
		AppMetrica.MainScreenLoadWatch.Start();
		State = VisualState.InProgress;
		await base.Start();
		Task.Run(delegate
		{
			try
			{
				AppAnalytics.YandexMetricaSdk.InitMetrica();
			}
			catch (Exception)
			{
			}
		}).SafeFireAndForget((Action<Exception>)null, false);
		Task.Run(() => _loymaxPushTokenService.Value.SetPushToken()).SafeFireAndForget((Action<Exception>)null, false);
		LoadRecommendations().SafeFireAndForget((Action<Exception>)null, false);
		LoadCtmShelves().SafeFireAndForget((Action<Exception>)null, false);
		_bannersRepository.OnBannersUpdate(delegate(object? o, BannersUpdatedEventArgs e)
		{
			LoadBanners(e.Banners).SafeFireAndForget((Action<Exception>)null, false);
		}).AddTo(base.CloseDisposable);
		LoadBanners().SafeFireAndForget((Action<Exception>)null, false);
		Task task = LoadPersonalGreeting();
		Task<Result<Tooltip[], DomainError>> tooltipsTask = Task.Run(() => _tooltipsManager.Value.GetTooltips());
		Task<bool> onboardingsTask = Task.Run(() => _onboardingsManager.Value.ShouldShowOnboardings(ShowAt.HomePage));
		Task task2 = OrdersHomeViewModel.Load();
		Task task3 = NearestOrderInfoViewModel.Load();
		await Task.WhenAll(task, tooltipsTask, task2, task3, onboardingsTask);
		UserNotificationBanner userNotificationBanner = UserNotificationBanner.CreateOrNull(_adminContext.Value.AppConfig, OnSoftUpdateClicked);
		if (userNotificationBanner != null)
		{
			base.AutoLayout.Insert(AutoLayoutViewModel.AutoLayoutElement.New("HomeUserNotificationBanner", userNotificationBanner, BlockOrder.UserNotification));
		}
		LoadMyOffers().SafeFireAndForget((Action<Exception>)null, true);
		State = VisualState.Default;
		AppAnalytics.AppMetrica.MainScreenLoadEnd();
		_notAuthReopenScreenService.NavigateIfNeeded();
		await _maintenanceManager.Value.WaitWhileInMaintenanceAsync();
		if (_loyaltyPersonalizedGreetingsManager.Value.GreetingShouldBeShown)
		{
			_showPersonalizedGreetingTrigger.OnNext(Unit.Default);
		}
		ShowSoftUpdatePopupIfNeed();
		if (!_navigationContext.Value.IsNavigatedFromStart && !_navigationContext.Value.IsNavigating && onboardingsTask.IsCompleted && onboardingsTask.Result && !_onboardingWasAddedToQueue)
		{
			OpenOnboardingsCommand.Trigger(new OnboardingsViewModel.Parameter(ShowAt.HomePage));
			_onboardingWasAddedToQueue = true;
		}
		if (tooltipsTask.IsCompleted)
		{
			Result<Tooltip[], DomainError> result = tooltipsTask.Result;
			if (result.IsSuccess && result.Value != null && result.Value.Length != 0 && _adminContext.Value.ShouldShowTooltipPopup(result.Value[0].ShowCount))
			{
				Tooltip[] array = result.Value;
				if (!(_adminContext.Value.AppConfig.LoyaltyConfig?.EPointsBalanceEnabled ?? true))
				{
					array = array.Where((Tooltip t) => t.Target != TooltipTargetType.ExpressPoints).ToArray();
				}
				if (array.Length != 0)
				{
					_openTooltips.OnNext(new TooltipViewModel.Parameter(array));
					await Task.Delay(200);
				}
			}
		}
		ExtraPromotion extraPromotion = await _extraPromotionService.Value.GetPromotionsFor(this);
		if (!_navigationContext.Value.IsNavigatedFromStart && !_navigationContext.Value.IsNavigating && extraPromotion != null)
		{
			_openExtraPromotion.OnNext(new ExtraPromotionViewModel.Parameter(extraPromotion));
		}
		if (!_navigationContext.Value.IsNavigatedFromStart && !_navigationContext.Value.IsNavigating && _adminContext.Value.IsGameActive() && _adminContext.Value.AppConfig.GameConfig.Animations.Any())
		{
			GameAnimation nextGameAnimation = _adminContext.Value.GetNextGameAnimation();
			if (nextGameAnimation != null)
			{
				_openNewYearSantaPopup.OnNext(new SantaPopupDialogViewModel.Parameter(nextGameAnimation, NewYearGamePlayPosition.Home));
			}
		}
		ShowWaitingForReviewAndExpressPopupIfNeeded().SafeFireAndForget((Action<Exception>)null, false);
		UpdateWaitListNotificationBanner().SafeFireAndForget((Action<Exception>)null, false);
		TrackRepeatCompletedOrder();
		_homeScreenTracker.Value.Shown = true;
	}

	private Func<AutoLayoutViewModel.AutoLayoutElement, bool> GetHeaderBlockPredicate()
	{
		return (AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "HomeOrdersHeader" || e.Type == "HomeOrderItem" || e.Type == "HomeRepeatOrdersBlock";
	}

	private void UpdateOrdersBlock()
	{
		ImmutableArray<AutoLayoutViewModel.AutoLayoutElement> immutableArray = base.AutoLayout.Elements.Where(GetHeaderBlockPredicate()).ToImmutableArray();
		List<AutoLayoutViewModel.AutoLayoutElement> list = new List<AutoLayoutViewModel.AutoLayoutElement>();
		if (OrdersHomeViewModel.IsOrdersListLoaded)
		{
			list.Add(immutableArray.FirstOrDefault((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "HomeOrdersHeader") ?? AutoLayoutViewModel.AutoLayoutElement.New("HomeOrdersHeader", OrdersHomeViewModel, BlockOrder.OrdersHeader));
			list.AddRange(OrdersHomeViewModel.Orders.Select((HomeOrderItemViewModel i) => AutoLayoutViewModel.AutoLayoutElement.New("HomeOrderItem", i, BlockOrder.OrderItem)));
		}
		if (OrdersHomeViewModel.HasLastCompletedOrder)
		{
			list.Add(AutoLayoutViewModel.AutoLayoutElement.New("HomeRepeatOrdersBlock", OrdersHomeViewModel, BlockOrder.RepeatOrders));
		}
		if (immutableArray.SequenceEqual(list))
		{
			return;
		}
		if (immutableArray.Any() && (!list.Any() || immutableArray.First().Order == list.First().Order))
		{
			base.AutoLayout.Elements.ReplaceRange(base.AutoLayout.Elements.IndexOf(immutableArray.First()), immutableArray.Count(), list.ToImmutableArray());
			return;
		}
		if (immutableArray.Any())
		{
			base.AutoLayout.Elements.RemoveRange(base.AutoLayout.Elements.IndexOf(immutableArray.First()), immutableArray.Count());
		}
		base.AutoLayout.InsertRange(list.ToImmutableArray());
	}

	public async Task ShowWaitingForReviewPopupIfNeeded()
	{
		if (!_navigationContext.Value.IsNavigatedFromStart && !_navigationContext.Value.IsNavigating)
		{
			Result<bool, DomainError> result = await _reviewsEcomRepository.Value.CheckIfPopupNeeded();
			if (result.IsSuccess && result.Value)
			{
				ShowWaitingForReviewPopupCommand.Trigger();
			}
		}
	}

	private async Task ShowWaitingForReviewAndExpressPopupIfNeeded()
	{
		try
		{
			await ShowWaitingForReviewPopupIfNeeded();
		}
		finally
		{
			ReceiveMethodViewModel.ShowExpressDeliveryHighlightIfNeeded();
		}
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		_isCurrentScreen = true;
		await _maintenanceManager.Value.WaitWhileInMaintenanceAsync();
		SeasonOffersScrollCommand.Trigger();
		_logService.Value.LogInfo("HomeViewModel", "Открыт Главный экран", LogType.UserAction, SystemType.MobileApp);
		Task.Run(delegate
		{
			AppAnalytics.Digenetica.ViewHome();
		}).SafeFireAndForget((Action<Exception>)null, false);
		if (!_navigationContext.Value.IsNavigatedFromStart && !_navigationContext.Value.IsNavigating && _locationPermissionGranted == false)
		{
			_locationPermissionGranted = await PermissionExtensions.CheckAsyncSafe<Permissions.LocationWhenInUse>() == PermissionStatus.Granted;
		}
		if (!_firstStart)
		{
			TrackRepeatCompletedOrder();
		}
		LoadCtmShelves().SafeFireAndForget((Action<Exception>)null, false);
		if (!_firstStart && _userContext.Value.Authorized)
		{
			await DoShortRefresh(forceUpdate: false);
		}
		bool flag = !_firstStart;
		if (flag)
		{
			flag = await _onboardingsManager.Value.ShouldShowOnboardings(ShowAt.HomePage);
		}
		if (flag && !_onboardingWasAddedToQueue)
		{
			OpenOnboardingsCommand.Trigger(new OnboardingsViewModel.Parameter(ShowAt.HomePage));
			_onboardingWasAddedToQueue = true;
		}
		if (!_firstStart)
		{
			UpdateWaitListNotificationBanner().SafeFireAndForget((Action<Exception>)null, false);
		}
		if (!_firstStart)
		{
			ReceiveMethodViewModel.ShowExpressDeliveryHighlightIfNeeded();
		}
		_firstStart = false;
		ReloadMyOffersOnResume().SafeFireAndForget((Action<Exception>)null, false);
		async Task ReloadMyOffersOnResume()
		{
			await _adminContext.Value.SyncAppConfig();
			AppIconType appIconType = PreferencesEx.GetEnum("AppIconType", AppIconType.Unknown);
			if (appIconType == AppIconType.Unknown)
			{
				appIconType = AppIconType.Default;
			}
			AppIconType newAppIcon = _adminContext.Value.AppConfig.AppIcon;
			if (newAppIcon == AppIconType.Unknown)
			{
				newAppIcon = AppIconType.Default;
			}
			PreferencesEx.SetEnum("AppIconType", newAppIcon);
			if (appIconType != newAppIcon)
			{
				_logService.Value.LogInfo("HomeViewModel", "Меняю иконку", LogType.UserAction, SystemType.MobileApp);
				await Task.Delay(50);
				ChangeAppIconCommand.Trigger(newAppIcon);
			}
			else
			{
				RegisterRemoteNotifications.Trigger();
			}
			await LoadMyOffers();
		}
	}

	private async Task UpdateWaitListNotificationBanner()
	{
		(Product, bool, int) data = await Task.Run((Func<Task<(Product, bool, int)>?>)_waitListProducts.Value.GetNotificationData);
		WaitListNotificationBanner.ShowOrNot(data);
	}

	protected override Task OnPaused()
	{
		_isCurrentScreen = false;
		WaitListNotificationBanner.Hide();
		return base.OnPaused();
	}

	public async Task OnPriceCheckerClicked()
	{
		if (IsPriceCheckerEnabled)
		{
			AppAnalytics.AppMetrica.TrackEvent("TapMainOnPriceChecker");
			OpenPriceChecker.Trigger();
		}
	}

	public void CouponTapped(Coupon coupon)
	{
		AppAnalytics.AppMetrica.TrackCoupon(coupon);
		OpenCouponDetailsCommand.Trigger(_dataBroker.Value.Push(new CouponDetailsViewModel.Parameter(coupon)));
	}

	public void OnSearchClick()
	{
		AppAnalytics.AppMetrica.TrackEvent("TapMainOnSearch");
	}

	public void OnRecommendationsViewed()
	{
		if (!_recommendationsViewed)
		{
			_recommendationsViewed = true;
			Recommendations.Viewed();
		}
	}

	private async Task DoShortRefresh(bool forceUpdate)
	{
		await _ecomContext.SyncReceiveMethodQueued();
		await Task.WhenAll(LoyaltyCardViewModel.Load(forceUpdate), ReceiveMethodViewModel.LoadReceiveMethods(), OrdersHomeViewModel.Load(), NearestOrderInfoViewModel.Load());
	}

	private async Task OnRefresh()
	{
		_recommendationsGimaIdCache.Value.Clear();
		await DoShortRefresh(forceUpdate: true);
		LoadCtmShelves().SafeFireAndForget((Action<Exception>)null, false);
		SeasonOffersScrollCommand.Trigger();
		RefreshDoneCommand.Trigger();
		TopRecommendations.Reload().SafeFireAndForget((Action<Exception>)null, false);
		Recommendations.ReloadCommand.Trigger();
	}

	public Task OnIAmHereWithAuto()
	{
		OrdersHomeViewModel.ReloadCommand.Trigger();
		NearestOrderInfoViewModel.Load().SafeFireAndForget((Action<Exception>)null, false);
		return Task.CompletedTask;
	}

	public void OnSoftUpdateClicked()
	{
		TryToLaunchSoftUpdateAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task TryToLaunchSoftUpdateAsync()
	{
		if (!(await _updateService.Value.TryToLaunchSystemBackgroundUpdateAsync()))
		{
			OpenSoftUpdatePopupCommand.Trigger();
		}
	}

	public void OnWaitListNotificationClicked()
	{
		OpenWaitListCommand.Trigger();
	}

	public void OnOpenSalesAndNewsClicked()
	{
		AppAnalytics.AppMetrica.TrackEvent("TapMainOnNews");
		OpenSalesAndNewsCommand.Trigger();
	}

	public void MyOffersClicked()
	{
		AppAnalytics.AppMetrica.TapMainOnMyOffers();
		OpenMyOffersCommand.Trigger();
	}

	public void OnOpenShopListClicked()
	{
		AppAnalytics.AppMetrica.TrackEvent("TapMainOnStores");
		_openShopList.OnNext(Unit.Default);
	}

	public void OnRetry()
	{
		_retry.OnNext(Unit.Default);
	}

	public void OnBannerShown(BannerItemViewModel viewModel)
	{
		if (viewModel.Banner.Id != _lastTrackedBannerId)
		{
			_appMetrica.Value.SendFakeAdRevenue("promoView", ("promoId", viewModel.Banner.Id.ToString()), ("promoName", viewModel.Banner.Name));
			_lastTrackedBannerId = viewModel.Banner.Id;
		}
	}

	private void TrackSeasonOffers(IReadOnlyCollection<Banner> banners)
	{
		if (_seasonOffersTracked)
		{
			return;
		}
		if (banners.Any())
		{
			_seasonOffersTracked = true;
		}
		foreach (Banner banner in banners)
		{
			_appMetrica.Value.SendFakeAdRevenue("promoView", ("promoId", banner.Id.ToString()), ("promoName", banner.Name), ("promoFormat", "seasonal"));
		}
	}

	public void OnBannerClicked(BannerItemViewModel? vm)
	{
		if (vm != null)
		{
			TrackBannerClick(vm);
			vm.Banner.NavigateTo.Activate(BannerNavigationSupport);
		}
	}

	private void OnSeasonOfferClicked(BannerItemViewModel seasonOfferViewModel)
	{
		_appMetrica.Value.SeasonOfferClick(seasonOfferViewModel.Banner);
		seasonOfferViewModel.Banner.NavigateTo.Activate(BannerNavigationSupport);
	}

	public void RunTask(Task task)
	{
		RunTaskAsync(task).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void OpenOrders()
	{
		_navigateOrders.OnNext(Unit.Default);
	}

	private void ShowSoftUpdatePopupIfNeed()
	{
		if (IsPopupShouldBeAutoFirstShown)
		{
			_adminContext.Value.LastNewAppVersion = _adminContext.Value.AppConfig.AppVersion.New;
			TryToLaunchSoftUpdateAsync().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private async Task RunTaskAsync(Task task)
	{
		State = VisualState.InProgress;
		await task;
		State = VisualState.Default;
	}

	private void TrackRepeatCompletedOrder()
	{
		if (!_repeatCompletedOrderTracked && OrdersHomeViewModel.HasLastCompletedOrder)
		{
			_repeatCompletedOrderTracked = true;
			Task.Run(delegate
			{
				AppAnalytics.AppMetrica.RepeatLastCompletedOrderShown();
			});
		}
	}

	private async Task LoadBanners(IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>? banners = null)
	{
		if (!Microsoft.Maui.ApplicationModel.MainThread.IsMainThread)
		{
			throw new InvalidOperationException("can't operate @ background thread");
		}
		Result<IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>, DomainError> result = ((banners == null) ? (await _bannersRepository.GetBannersAsync()) : Result.Success<IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>, DomainError>(banners));
		Result<IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>, DomainError> result2 = result;
		banners = (IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>>?)((!result2.IsFailure) ? ((IEnumerable)result2.Value) : ((IEnumerable)_bannersRepository.NoBanners));
		List<AutoLayoutViewModel.AutoLayoutElement> list = new List<AutoLayoutViewModel.AutoLayoutElement>();
		ImmutableList<AutoLayoutViewModel.AutoLayoutElement> toRemove = base.AutoLayout.Elements.Where((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "HomeSeasonBanners").ToImmutableList();
		if (banners.TryGetValue(BannerType.SeasonOffers, out IReadOnlyList<Banner> value) && value.Any())
		{
			list.Add(AutoLayoutViewModel.AutoLayoutElement.New("HomeSeasonBanners", value.Select((Banner b, int i) => new BannerItemViewModel(b, i)).ToImmutableList(), BlockOrder.SeasonBanners));
			TrackSeasonOffers(value);
		}
		base.AutoLayout.ReplaceOrInsertRange(toRemove, list);
		list.Clear();
		toRemove = base.AutoLayout.Elements.Where((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "GameBanner").ToImmutableList();
		IReadOnlyList<BannerItemViewModel> homeBannerItems = AdditionalBannerCarouselProvider.GetHomeBannerItems(banners);
		if (homeBannerItems.Any())
		{
			list.Add(AutoLayoutViewModel.AutoLayoutElement.New("GameBanner", homeBannerItems, BlockOrder.GameBanner));
		}
		base.AutoLayout.ReplaceOrInsertRange(toRemove, list);
		list.Clear();
		toRemove = base.AutoLayout.Elements.Where((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "SliderBlock" || e.Type == "TitleBlock").ToImmutableList();
		if (banners.TryGetValue(BannerType.FirstSlider, out IReadOnlyList<Banner> value2))
		{
			list.Add(AutoLayoutViewModel.AutoLayoutElement.New("SliderBlock", value2.Select((Banner b, int i) => new BannerItemViewModel(b, i)).ToImmutableList(), BlockOrder.FirstSlider));
		}
		if (banners.TryGetValue(BannerType.SecondSlider, out IReadOnlyList<Banner> value3))
		{
			list.Add(AutoLayoutViewModel.AutoLayoutElement.New("SliderBlock", value3.Select((Banner b, int i) => new BannerItemViewModel(b, i)).ToImmutableList(), BlockOrder.SecondSlider));
		}
		if (banners.TryGetValue(BannerType.ThirdSlider, out IReadOnlyList<Banner> value4))
		{
			list.Add(AutoLayoutViewModel.AutoLayoutElement.New("TitleBlock", CharityTitle, BlockOrder.Title));
			list.Add(AutoLayoutViewModel.AutoLayoutElement.New("SliderBlock", value4.Select((Banner b, int i) => new BannerItemViewModel(b, i)).ToImmutableList(), BlockOrder.ThirdSlider));
		}
		base.AutoLayout.ReplaceOrInsertRange(toRemove, list);
		list.Clear();
		toRemove = base.AutoLayout.Elements.Where((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "HomeDigitalCatalogBanner").ToImmutableList();
		if (banners.TryGetValue(BannerType.DigitalCatalog, out IReadOnlyList<Banner> value5))
		{
			Banner banner = value5.FirstOrDefault();
			if (banner != null)
			{
				list.Add(AutoLayoutViewModel.AutoLayoutElement.New("HomeDigitalCatalogBanner", new BannerItemViewModel(banner, 0), BlockOrder.DigitalCatalogBanner));
			}
		}
		base.AutoLayout.ReplaceOrInsertRange(toRemove, list);
	}

	private async Task LoadRecommendations()
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		LoadRequest loadRequest = _recommendationBuilderFactory().AddPopularInCategoryByPath("Новый Год", "new_year", new global::_003C_003Ez__ReadOnlySingleElementList<string>("Новый год")).AddPersonal("Рекомендуем для вас", "home_pr_recom").AddAnyProductPlacement("Стоит присмотреться", PlacementId.HomeScreen, "home_pp_take_look")
			.AddSaleByPopularInCategoryByPath("Выгодно", "popular_sale_rr", new global::_003C_003Ez__ReadOnlySingleElementList<string>(" "))
			.WithSkip(2)
			.AddNovelty("Новинки для вас")
			.Build();
		LoadRequest loadRequest2 = _recommendationBuilderFactory().AddPopularEndless("Популярные товары для вас", "main_screen_endless_shelf_personalized", "main_screen_endless_shelf").Build();
		base.AutoLayout.Elements.RemoveAll((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "RecommendationHorizontalBlock");
		await Task.WhenAll(TopRecommendations.Load(loadRequest), Recommendations.Load(loadRequest2));
	}

	private void TrackBannerClick(BannerItemViewModel vm)
	{
		_ = vm.Banner.Type;
		int position = vm.Position;
		_appMetrica.Value.SendFakeAdRevenue("promoClick", ("promoId", vm.Banner.Id.ToString()), ("promoName", vm.Banner.Name));
		AppAnalytics.AppMetrica.PersonalOfferTapped($"{vm.Banner.Id}", vm.Banner.Name, position, this);
	}

	private Task LoadPersonalGreeting()
	{
		_loyaltyPersonalizedGreetingsManager.Value.TrySetupGreetingForRetiredUsers();
		return Task.Run(() => _loyaltyPersonalizedGreetingsManager.Value.LoadGreetingsToCacheIfNeeded());
	}

	private Task OnStoreChange(Store _)
	{
		return Task.WhenAll(LoadRecommendations(), LoadCtmShelves());
	}

	private async Task OpenPayment(List<OrderItemViewModel> orders)
	{
		OrderItemViewModel order = orders?.FirstOrDefault((OrderItemViewModel o) => o.AwaitingPayment);
		if (order == null)
		{
			_infoMessageService.Value.ShowSnackbar("Произошла неизвестная ошибка");
			return;
		}
		State = VisualState.InProgress;
		Result<OrderModel, DomainError> result = await _ordersRepository.Value.GetOrderAsync(order.OrderId);
		if (result.IsFailure || !result.Value.AwaitingPayment || string.IsNullOrWhiteSpace(result.Value.PaymentUrl))
		{
			_infoMessageService.Value.ShowSnackbar("Срок оплаты истек", SnackbarStyle.Error, 5);
			OrdersHomeViewModel.ReloadCommand.Trigger();
			State = VisualState.Default;
		}
		else
		{
			State = VisualState.Default;
			OpenPaymentCommand.Trigger(_paymentUrlHelper.Value.GetParameter(result.Value.PaymentUrl, order.OrderId.ToString()));
		}
	}

	private async Task UpdateWaitListInfo(Store _)
	{
		await _waitListProducts.Value.UpdateBadge();
		if (_isCurrentScreen)
		{
			WaitListNotificationBanner waitListNotificationBanner = WaitListNotificationBanner;
			waitListNotificationBanner.ShowOrNot(await _waitListProducts.Value.GetNotificationData());
		}
	}

	private static bool GetIsPriceCheckerEnabled(IAdminContext _adminContext, IUserContext _userContext)
	{
		if (OperatingSystem.IsAndroidVersionAtLeast(28) ? true : false)
		{
			AppConfig appConfig = _adminContext.AppConfig;
			if (appConfig != null && appConfig.PriceCheckerEnabled)
			{
				switch (_adminContext.AppConfig?.PricecheckerAudience)
				{
				case AudienceType.Employees:
				case AudienceType.Clients:
					return _userContext.Profile?.Audience == _adminContext.AppConfig?.PricecheckerAudience;
				case AudienceType.All:
					return true;
				}
			}
		}
		return false;
	}

	private void OnTopRecommendationsSectionsChanged(NotifyCollectionChangedEventArgs args)
	{
		OnRecommendationSectionsChanged(TopRecommendations.Sections, BlockOrder.TopRecommendations, _topSectionsDisposable);
	}

	private void OnBottomRecommendationsSectionsChanged(NotifyCollectionChangedEventArgs args)
	{
		OnRecommendationSectionsChanged(BottomRecommendations.Sections, BlockOrder.BottomRecommendations, _bottomSectionsDisposable);
	}

	private void OnRecommendationSectionsChanged(IReadOnlyCollection<SectionItemViewModel> sections, BlockOrder order, ICollection<IDisposable> disposables)
	{
		disposables.ForEach(delegate(IDisposable d)
		{
			d.Dispose();
		});
		disposables.Clear();
		if (sections.Count > 0)
		{
			HandleCollectionChange();
			return;
		}
		base.AutoLayout.Elements.RemoveAll((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "RecommendationHorizontalBlock" && e.Order == (int)order && sections.Select((SectionItemViewModel s) => s.Id).Contains(e.Tag));
		void HandleCollectionChange()
		{
			ImmutableArray<AutoLayoutViewModel.AutoLayoutElement> immutableArray = base.AutoLayout.Elements.Where((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "RecommendationHorizontalBlock" && e.Order == (int)order && sections.Select((SectionItemViewModel s) => s.Id).Contains(e.Tag)).ToImmutableArray();
			IEnumerable<AutoLayoutViewModel.AutoLayoutElement> enumerable = from s in sections
				where s.Preview.Count > 0
				select AutoLayoutViewModel.AutoLayoutElement.New("RecommendationHorizontalBlock", s, order, s.Id);
			if (enumerable.Any())
			{
				if (!immutableArray.Any())
				{
					base.AutoLayout.InsertRange(enumerable);
				}
				else
				{
					base.AutoLayout.Elements.ReplaceRange(base.AutoLayout.Elements.IndexOf(immutableArray.First()), immutableArray.Count(), enumerable);
				}
			}
			else if (immutableArray.Any())
			{
				base.AutoLayout.Elements.RemoveRange(immutableArray);
			}
		}
	}

	private Task OnForBusinessCommand(Unit unit)
	{
		AppAnalytics.AppMetrica.TapMainOnForBusiness();
		_universalLinksService.Value.HandleLink("auchan://infopages?types=for_business");
		return Task.CompletedTask;
	}

	public void OnPersOfferTapped(PersOfferItemViewModel offerViewModel)
	{
		AppAnalytics.AppMetrica.TrackCashbackPersOffer(offerViewModel);
		DoAsync().SafeFireAndForget((Action<Exception>)null, false);
		async Task DoAsync()
		{
			ProductDetailsViewModel.Parameter productParam = null;
			bool hasChanges;
			if (offerViewModel.IsAiOffer)
			{
				AIOfferDetailsViewModel.Parameter parameter = new AIOfferDetailsViewModel.Parameter(offerViewModel.Code);
				OpenAIOfferDetailsCommand.Trigger(_dataBroker.Value.Push(parameter));
				AIOfferDetailsViewModel.OfferDetailsResult offerDetailsResult = await parameter.WaitForResultAsync();
				hasChanges = offerDetailsResult.HasChanges;
				productParam = offerDetailsResult.ProductDetailsParameter;
			}
			else
			{
				OfferDetailsViewModel.Parameter parameter2 = new OfferDetailsViewModel.Parameter(offerViewModel.Code);
				OpenOfferDetailsCommand.Trigger(_dataBroker.Value.Push(parameter2));
				hasChanges = (await parameter2.WaitForResultAsync()).HasChanges;
			}
			if (productParam != null)
			{
				OpenProductDetailsCommand.Trigger(productParam);
			}
			else if (hasChanges)
			{
				await LoadMyOffers();
			}
		}
	}

	public void OnPersOfferActivated(HomeMyOfferItemViewModel offerViewModel)
	{
		object data = offerViewModel.Data;
		PersOfferItemViewModel po = data as PersOfferItemViewModel;
		if (po != null && !string.IsNullOrWhiteSpace(po.LoymaxId))
		{
			State = VisualState.InProgress;
			DoAsync().SafeFireAndForget((Action<Exception>)null, false);
		}
		async Task DoAsync()
		{
			AppAnalytics.AppMetrica.TrackEvent("Tap_MainPersonal_offer_activate");
			if ((await _adminContext.Value.ActivatePersonalOffer(po.LoymaxId)).IsSuccess)
			{
				po.SetAccepted();
				offerViewModel.SetAccepted();
				_adminContext.Value.InvalidatePersOffersCache();
			}
			else
			{
				_infoMessageService.Value.ShowSnackbar("К сожалению, сейчас активация невозможна. Попробуйте позднее.");
			}
			State = VisualState.Default;
		}
	}

	private async Task LoadMyOffers()
	{
		if (!Microsoft.Maui.ApplicationModel.MainThread.IsMainThread)
		{
			throw new InvalidOperationException("should be called from main thread");
		}
		if (_loadingMyOffers)
		{
			return;
		}
		_loadingMyOffers = true;
		ImmutableArray<AutoLayoutViewModel.AutoLayoutElement> toRemove = base.AutoLayout.Elements.Where((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "HomeMyOffersBlock").ToImmutableArray();
		if (!_adminContext.Value.AppConfig.MainMyOffersConfig.Any())
		{
			if (toRemove.Any())
			{
				base.AutoLayout.Elements.RemoveRange(toRemove);
				MyOffersViewModels.Clear();
				MyOffersIndicatorText = string.Empty;
			}
			_loadingMyOffers = false;
			return;
		}
		List<HomeMyOfferItemViewModel> myOffers = new List<HomeMyOfferItemViewModel>();
		int newMyOffersCount = 0;
		await _adminContext.Value.AppConfig.MainMyOffersConfig.ForEachAsync(async delegate(AppConfigMyOffer c)
		{
			switch (c.Code)
			{
			case MainMyOfferType.FavoriteCategories:
			{
				Result<FavoriteCategoriesItemViewModel, DomainError> result2 = await _favoriteCategoriesRepository.Value.GetFavoriteCategories();
				if (result2.IsSuccess && result2.Value != null)
				{
					myOffers.Add(HomeMyOfferItemViewModel.CreateFavoriteCategories(result2.Value));
				}
				break;
			}
			case MainMyOfferType.Coupon:
			{
				Result<List<Coupon>, DomainError> result3 = await _couponsRepository.Value.GetCoupons();
				if (result3.IsSuccess && result3.Value.Any())
				{
					newMyOffersCount += result3.Value.Count((Coupon coupon) => coupon.IsNew);
					myOffers.AddRange(result3.Value.TakeSafe(c.Limit).Select(HomeMyOfferItemViewModel.CreateCoupon).ToArray());
					ShowOffersAllButton = true;
				}
				break;
			}
			case MainMyOfferType.PersonalOffer:
			{
				Result<List<PersOfferItemViewModel>, DomainError> result = await _adminContext.Value.GetPersonalOffers();
				if (result.IsSuccess && result.Value.Any())
				{
					newMyOffersCount += result.Value.Count((PersOfferItemViewModel persOfferItemViewModel) => !persOfferItemViewModel.IsViewed);
					myOffers.AddRange(result.Value.TakeSafe(c.Limit).Select(HomeMyOfferItemViewModel.CreatePersonalOffer).ToArray());
					Microsoft.Maui.ApplicationModel.MainThread.BeginInvokeOnMainThread(delegate
					{
						ShowOffersAllButton = true;
					});
				}
				break;
			}
			}
		});
		if (!myOffers.Any())
		{
			if (toRemove.Any())
			{
				base.AutoLayout.Elements.RemoveRange(toRemove);
				MyOffersViewModels.Clear();
				MyOffersIndicatorText = string.Empty;
			}
			_loadingMyOffers = false;
			return;
		}
		MyOffersIndicatorText = ((newMyOffersCount > 0) ? $"{newMyOffersCount} {GrammarHelper.DeclineNoun(newMyOffersCount, new string[3] { "новое", "новых", "новых" })}" : string.Empty);
		if (toRemove.Any())
		{
			base.AutoLayout.Elements.ReplaceRange(base.AutoLayout.Elements.IndexOf(toRemove.First()), toRemove.Count(), new global::_003C_003Ez__ReadOnlySingleElementList<AutoLayoutViewModel.AutoLayoutElement>(AutoLayoutViewModel.AutoLayoutElement.New("HomeMyOffersBlock", this, BlockOrder.MyOffersBlock)));
		}
		else
		{
			base.AutoLayout.Insert(AutoLayoutViewModel.AutoLayoutElement.New("HomeMyOffersBlock", this, BlockOrder.MyOffersBlock));
		}
		MyOffersViewModels.ReplaceRange(myOffers);
		_loadingMyOffers = false;
	}

	public void OpenFavoriteCategories(FavoriteCategoriesItemViewModel item)
	{
		AppAnalytics.AppMetrica.TrackEvent("TapMainOnMyCategory");
		NavigateToMyFavoriteCategoriesCommand.Trigger(new MyFavoriteCategoriesViewModel.Parameter(item.Data));
	}

	private async Task LoadCtmShelves()
	{
		int rid = Interlocked.Increment(ref _loadCtmShelvesSpinRequestId);
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		Result<IReadOnlyList<Shelf>, DomainError> result = await _ctmShelvesService.GetShelves(ShelfPlacement.Home);
		if (rid != _loadCtmShelvesSpinRequestId)
		{
			return;
		}
		ImmutableList<AutoLayoutViewModel.AutoLayoutElement> toRemove = base.AutoLayout.Elements.Where((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "CtmShelf" && e.Order == 13).ToImmutableList();
		ImmutableList<AutoLayoutViewModel.AutoLayoutElement> toRemove2 = base.AutoLayout.Elements.Where((AutoLayoutViewModel.AutoLayoutElement e) => e.Type == "CtmShelf" && e.Order == 6).ToImmutableList();
		IReadOnlyList<AutoLayoutViewModel.AutoLayoutElement> toAdd = Array.Empty<AutoLayoutViewModel.AutoLayoutElement>();
		IReadOnlyList<AutoLayoutViewModel.AutoLayoutElement> toAdd2 = Array.Empty<AutoLayoutViewModel.AutoLayoutElement>();
		_shelvesDisposabe.Clear();
		if (result.TryGetValue(out var value) && value.Any())
		{
			List<AutoLayoutViewModel.AutoLayoutElement> list = new List<AutoLayoutViewModel.AutoLayoutElement>();
			list.AddRange(from i in value
				where i.Container == Container.HotPrice
				select AutoLayoutViewModel.AutoLayoutElement.New("CtmShelf", _ctmShelfItemViewModelFactory(i, this).AddTo(_shelvesDisposabe), BlockOrder.CtmShelfHotPrice));
			toAdd = new _003C_003Ez__ReadOnlyList<AutoLayoutViewModel.AutoLayoutElement>(list);
			List<AutoLayoutViewModel.AutoLayoutElement> list2 = new List<AutoLayoutViewModel.AutoLayoutElement>();
			list2.AddRange(from i in value
				where i.Container == Container.Offers
				select AutoLayoutViewModel.AutoLayoutElement.New("CtmShelf", _ctmShelfItemViewModelFactory(i, this).AddTo(_shelvesDisposabe), BlockOrder.CtmShelfOffers));
			toAdd2 = new _003C_003Ez__ReadOnlyList<AutoLayoutViewModel.AutoLayoutElement>(list2);
		}
		base.AutoLayout.ReplaceOrInsertRange(toRemove, toAdd);
		base.AutoLayout.ReplaceOrInsertRange(toRemove2, toAdd2);
	}

	public string GetImage(ProductModel product)
	{
		return product.ImageUrl ?? string.Empty;
	}
}
