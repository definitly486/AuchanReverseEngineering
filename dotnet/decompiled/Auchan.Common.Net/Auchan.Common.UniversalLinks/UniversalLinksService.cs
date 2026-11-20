using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Drive;
using Auchan.Common.DynamicFeedback;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Ecom.Search;
using Auchan.Common.Extensions;
using Auchan.Common.Home;
using Auchan.Common.InfoPages;
using Auchan.Common.InfoPages.Models;
using Auchan.Common.Logs;
using Auchan.Common.LoyaltyProgram;
using Auchan.Common.LoyaltyProgram.Coupons;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.ViewModels;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsExpiration;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Points;
using Auchan.Common.Managers.UniversalLink;
using Auchan.Common.Navigation;
using Auchan.Common.Networking;
using Auchan.Common.NewYearGame;
using Auchan.Common.Notifications;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Authorization;
using Auchan.Common.Profile;
using Auchan.Common.Profile.GiftCards;
using Auchan.Common.Profile.Orders;
using Auchan.Common.Profile.Orders.Services;
using Auchan.Common.Profile.SalesAndNews;
using Auchan.Common.Profile.SocialStatus;
using Auchan.Common.Profile.Stores;
using Auchan.Common.Profile.UserCards;
using Auchan.Common.Profile.WaitList;
using Auchan.Common.Promotions;
using Auchan.Common.Reviews;
using Auchan.Common.SupportChat;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.UniversalLinks;

public class UniversalLinksService : IUniversalLinksService
{
	private const string ORDER_DETAIL = "personal-settings/my-orders/";

	private const string INFO_PAGES_DOCUMENTS = "help/company/legal-information";

	private const string SITE_FILTERS_PATH_PART = "/f/";

	private const string AI_PERS_OFFER_DETAIL_PATH = "personal_promotions_offer";

	private const string MY_COUPONS_LIST_PATH = "my_coupons";

	private IReadOnlyList<string> _supportedHosts = new global::_003C_003Ez__ReadOnlyArray<string>(new string[4] { "mlink.auchan.ru", "auchan.ru", "www.auchan.ru", "4431094.redirect.appmetrica.yandex.com" });

	private readonly WeakEventManager<UniversalLinkServiceLinkEvent> _universalLinkServiceEvents = new WeakEventManager<UniversalLinkServiceLinkEvent>();

	private readonly Lazy<INavigationService> _navigationService;

	private readonly Lazy<INavigationContext> _navigationContext;

	private readonly Lazy<IEnvironmentManager> _environmentManager;

	private readonly Lazy<IVkAuthService> _vkAuthService;

	private readonly Lazy<IProductsManager> _productsManager;

	private readonly Lazy<IAdminContext> _adminContext;

	private readonly Lazy<IOrdersRepository> _ordersRepository;

	private readonly Lazy<IOrderDetailsParameterFactory> _orderDetailsParameterFactory;

	private readonly Lazy<IBrowserActivator> _browserActivator;

	private readonly Lazy<IEcomContext> _ecomContext;

	private readonly Lazy<IUserContext> _userContext;

	private readonly Lazy<IInfoPagesRepository> _infoPagesRepository;

	private readonly Lazy<ILoyaltyManager> _loyaltyManager;

	private readonly Lazy<IDataBroker> _dataBroker;

	private readonly Lazy<UniversalLinkLoader> _universalLinkLoader;

	private readonly Lazy<ICheckoutService> _checkoutService;

	private readonly Lazy<ILogService> _logService;

	private readonly Lazy<IProductsRepository> _productsRepository;

	private static readonly Dictionary<string, string> _infoPageLocalPathToParameterMap = new Dictionary<string, string>
	{
		{ "help/service/dostavka", "delivery" },
		{ "help/service/opt", "for_business" },
		{ "help/service/sposoby-oplaty", "payment" },
		{ "help/service/vozvrat", "refund" },
		{ "personal-data", "personal_data_policy" },
		{ "privacy-policy", "privacy_policy" },
		{ "publichnaya-oferta", "offerta" },
		{ "regionalnye-ogranicheniya-vremeni-prodazhi-alkogolya", "alkogol" },
		{ "karta-auchan/pravila-programmy", "loyalty_rules" },
		{ "job", "auchan_job" },
		{ "karta-auchan/kollection-pravila", "kollection_pravila" },
		{ "ispolzovanie-promokodov", "promocode_rules" },
		{ "soglasie-na-napravlenie-reklamnyh-soobshcheniy", "reklama" },
		{ "rekomendatelnye-algoritmy", "rekomendatelnye_algoritmy" }
	};

	private static readonly Dictionary<string, FAQType> _faqLocalPathToParameterMap = new Dictionary<string, FAQType>
	{
		{
			"karta-auchan/faq-pl",
			FAQType.Loyalty
		},
		{
			"help/service/help",
			FAQType.Default
		}
	};

	public bool IsNavigating => NavigationTaskSource != null;

	public TaskCompletionSource? NavigationTaskSource { get; private set; }

	public bool IsPreloadingSharedCart { get; set; }

	public event EventHandler<UniversalLinkServiceLinkEvent> WeakOnLinkReceived
	{
		add
		{
			_universalLinkServiceEvents.AddEventHandler(value, "WeakOnLinkReceived");
		}
		remove
		{
			_universalLinkServiceEvents.RemoveEventHandler(value, "WeakOnLinkReceived");
		}
	}

	public UniversalLinksService(Lazy<INavigationService> navigationService, Lazy<IProductsManager> productsManager, Lazy<IEcomContext> ecomContext, Lazy<IUserContext> userContext, Lazy<IInfoPagesRepository> infoPagesRepository, Lazy<ILoyaltyManager> loyaltyManager, Lazy<IDataBroker> dataBroker, Lazy<UniversalLinkLoader> universalLinkLoader, Lazy<ICheckoutService> checkoutService, Lazy<ILogService> logService, Lazy<IProductsRepository> productsRepository, Lazy<IAdminContext> adminContext, Lazy<IOrdersRepository> ordersRepository, Lazy<IOrderDetailsParameterFactory> orderDetailsParameterFactory, Lazy<IBrowserActivator> browserActivator, Lazy<INavigationContext> navigationContext, Lazy<IEnvironmentManager> environmentManager, Lazy<IVkAuthService> vkAuthService)
	{
		_navigationService = navigationService;
		_productsManager = productsManager;
		_ecomContext = ecomContext;
		_userContext = userContext;
		_infoPagesRepository = infoPagesRepository;
		_loyaltyManager = loyaltyManager;
		_dataBroker = dataBroker;
		_universalLinkLoader = universalLinkLoader;
		_checkoutService = checkoutService;
		_logService = logService;
		_productsRepository = productsRepository;
		_adminContext = adminContext;
		_ordersRepository = ordersRepository;
		_orderDetailsParameterFactory = orderDetailsParameterFactory;
		_browserActivator = browserActivator;
		_navigationContext = navigationContext;
		_environmentManager = environmentManager;
		_vkAuthService = vkAuthService;
	}

	public bool ShouldHandleLink(string link)
	{
		_logService.Value.LogInfo("UniversalLinksService", "Requested to open url " + link, LogType.Notification, SystemType.MobileApp);
		if (!_ecomContext.Value.Initialized)
		{
			return false;
		}
		if (string.IsNullOrWhiteSpace(link))
		{
			return false;
		}
		if (link.EndsWith(".pdf"))
		{
			return true;
		}
		try
		{
			Uri uri = new UriBuilder(link).Uri;
			if (uri.Scheme == "auchan" || uri.Scheme == "vk54269263" || _supportedHosts.Contains(uri.Host))
			{
				return true;
			}
		}
		catch (Exception)
		{
		}
		return false;
	}

	public bool ShouldHandlePromoLink(string link)
	{
		_logService.Value.LogInfo("UniversalLinksService", "Requested to open promo url " + link, LogType.Notification, SystemType.MobileApp);
		if (!_ecomContext.Value.Initialized)
		{
			return false;
		}
		if (string.IsNullOrWhiteSpace(link))
		{
			return false;
		}
		if (link.EndsWith(".pdf"))
		{
			return true;
		}
		Uri uri = new UriBuilder(link).Uri;
		HttpUtility.ParseQueryString(uri.Query);
		if (uri.ShouldOpenInWebView())
		{
			return false;
		}
		if (uri.Scheme == "auchan" || uri.Scheme == "vk54269263" || _supportedHosts.Contains(uri.Host))
		{
			return true;
		}
		return false;
	}

	public Task HandleLinkOnStart(string link, UniversalLinkSource source = UniversalLinkSource.Unknown)
	{
		_navigationContext.Value.IsNavigatedFromStart = true;
		return HandleLinkImpl(link, source);
	}

	public Task HandleLink(string link)
	{
		return HandleLinkImpl(link, UniversalLinkSource.Unknown);
	}

	private async Task HandleLinkImpl(string link, UniversalLinkSource source)
	{
		_logService.Value.LogInfo("UniversalLinksService", "Trying to handle url " + link, LogType.Notification, SystemType.MobileApp);
		link = ClearLinkFromAdvertisementParamters(link);
		UniversalLinkServiceLinkEvent universalLinkServiceLinkEvent = new UniversalLinkServiceLinkEvent
		{
			Link = link
		};
		_universalLinkServiceEvents.RaiseEvent((object?)this, universalLinkServiceLinkEvent, "WeakOnLinkReceived");
		if (universalLinkServiceLinkEvent.Handled)
		{
			return;
		}
		NavigationTaskSource = new TaskCompletionSource();
		Uri uri = CreateUri(link);
		NameValueCollection query = HttpUtility.ParseQueryString(uri.Query);
		if (query.AllKeys.Contains<string>("ref"))
		{
			uri = await _universalLinkLoader.Value.TryGetFullLink(uri);
		}
		Type destination = GetLinkDestination(uri, query);
		if (destination == null)
		{
			if (!(uri != null))
			{
				return;
			}
			if (uri.LocalPath.ContainsIgnoreCase("feedback"))
			{
				if (uri.LocalPath.ContainsIgnoreCase("call"))
				{
					_navigationService.Value.CallToAuchanSupport();
				}
				else if (uri.LocalPath.ContainsIgnoreCase("write"))
				{
					_navigationService.Value.WriteFeedback();
				}
			}
			else
			{
				_vkAuthService.Value.SetIntermediateState(uri);
				_navigationContext.Value.IsNavigatedFromStart = false;
				SetNavigationTaskCompleted();
			}
			return;
		}
		if (destination == typeof(UnconfirmedSocialStatusViewModel) && (_userContext.Value.Profile?.IsConfirmedSocialStatus ?? false))
		{
			destination = typeof(ConfirmedSocialStatusViewModel);
		}
		object parameter = await GetLinkParameter(destination, uri, source);
		if (destination == typeof(BrowserActivatorViewModel) && parameter is BrowserActivatorViewModel.Parameter parameter2)
		{
			await _browserActivator.Value.LaunchBrowserAsync(parameter2.Uri, parameter2.LaunchMode);
			return;
		}
		if (parameter is InfoPageViewModel.Parameter)
		{
			destination = typeof(InfoPageViewModel);
		}
		if (parameter is TabActivatorViewModel.Parameter parameter3)
		{
			parameter3.ActualDestination = destination;
			destination = typeof(TabActivatorViewModel);
		}
		if (destination == typeof(NewYearGameViewModel))
		{
			AppConfig appConfig = await _adminContext.Value.WaitForAppConfig();
			if (appConfig.GameConfigs?.IsNullOrEmpty() ?? true)
			{
				return;
			}
			if (parameter == null)
			{
				parameter = new NewYearGameViewModel.Parameter(appConfig.GameConfigs.First().Id);
			}
			else
			{
				NewYearGameViewModel.Parameter ngPar = parameter as NewYearGameViewModel.Parameter;
				if (ngPar != null && appConfig.GameConfigs.All((GameConfig gc) => gc.Id != ngPar.Id))
				{
					return;
				}
			}
			parameter = _dataBroker.Value.Push(parameter as NewYearGameViewModel.Parameter);
		}
		if (parameter != null || !(destination.GetNestedType("Parameter") != null))
		{
			if (parameter is CatalogProductsViewModel.Parameter data)
			{
				parameter = _dataBroker.Value.Push(data);
			}
			_navigationService.Value.NavigateTo(destination, parameter, delegate
			{
				SetNavigationTaskCompleted();
			});
		}
		void SetNavigationTaskCompleted()
		{
			TaskCompletionSource? navigationTaskSource = NavigationTaskSource;
			NavigationTaskSource = null;
			navigationTaskSource?.TrySetResult();
		}
	}

	public static string ClearLinkFromAdvertisementParamters(string link)
	{
		try
		{
			UriBuilder uriBuilder = new UriBuilder(link);
			NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(uriBuilder.Query);
			foreach (string item in GetUtmKeys(nameValueCollection.Keys).ToImmutableList())
			{
				nameValueCollection.Remove(item);
			}
			uriBuilder.Query = nameValueCollection.ToString();
			return uriBuilder.Uri.ToString();
		}
		catch
		{
			return link;
		}
		static IEnumerable<string> GetUtmKeys(NameObjectCollectionBase.KeysCollection keys)
		{
			for (int i = 0; i < keys.Count; i++)
			{
				string text = keys[i];
				if ((text != null && text.StartsWith("utm_", StringComparison.InvariantCultureIgnoreCase)) || (text != null && text.Equals("referrer", StringComparison.InvariantCultureIgnoreCase)))
				{
					yield return text;
				}
			}
		}
	}

	private Uri CreateUri(string url)
	{
		url = url.Split("/f/").First();
		if (url.StartsWith("auchan"))
		{
			url = url.Replace("auchan://", "https://www.auchan.ru/");
		}
		return new Uri(url);
	}

	private static Type? GetLinkDestination(Uri uri, NameValueCollection query)
	{
		if (ShouldOpenInBrowser(uri, query))
		{
			return typeof(BrowserActivatorViewModel);
		}
		string text = uri.CleanupLocalPath();
		if (!(text == "cart"))
		{
			if (text != null)
			{
				if (text == "category" && !string.IsNullOrEmpty(query["type"]))
				{
					return typeof(ProductsViewModel);
				}
				if (text == "category" && !string.IsNullOrEmpty(query["id"]))
				{
					return typeof(CollectionProductsPreloaderViewModel);
				}
				if (text == "category" && !string.IsNullOrEmpty(query["code"]))
				{
					return typeof(CollectionProductsPreloaderViewModel);
				}
			}
			return GetLinkDestination(uri);
		}
		return string.IsNullOrEmpty(query?["share"]) ? typeof(CartScreenViewModel) : typeof(SharedCartPreloaderViewModel);
	}

	private static Type? GetLinkDestination(Uri uri)
	{
		string text = uri.CleanupLocalPath();
		switch (text)
		{
		default:
			if (text != null)
			{
				if (text.StartsWith("brand/"))
				{
					return typeof(ProductsViewModel);
				}
				string key = text;
				if (_infoPageLocalPathToParameterMap.ContainsKey(key))
				{
					return typeof(InfoPageViewModel);
				}
				string key2 = text;
				if (_faqLocalPathToParameterMap.ContainsKey(key2))
				{
					return typeof(FAQViewModel);
				}
				if (text.StartsWith("personal-settings/my-orders/"))
				{
					return typeof(OrderDetailsViewModel);
				}
				if (text.StartsWith("product/"))
				{
					return typeof(ProductDetailsViewModel);
				}
				if (text.StartsWith("catalog/kollekcii/"))
				{
					return typeof(CollectionProductsPreloaderViewModel);
				}
				if (text.StartsWith("catalog/"))
				{
					return typeof(CollectionProductsPreloaderViewModel);
				}
				if (text.EndsWith(".pdf"))
				{
					return typeof(BrowserActivatorViewModel);
				}
				if (text.StartsWith("my_coupons/"))
				{
					return typeof(CouponsViewModel);
				}
			}
			return null;
		case "home":
			return typeof(HomeViewModel);
		case "mlink.auchan.ru/main":
			return typeof(HomeViewModel);
		case "mlink.auchan.ru/cart":
			return typeof(CartScreenViewModel);
		case "promotion":
			return typeof(PromotionViewModel);
		case "authorize":
			return typeof(AuthOrRegisterViewModel);
		case "categories":
			return typeof(CatalogViewModel);
		case "catalog":
			return typeof(CatalogViewModel);
		case "kollekcii/category":
			return typeof(CollectionProductsPreloaderViewModel);
		case "product":
			return typeof(ProductDetailsViewModel);
		case "pay":
			return typeof(LoyaltyTabViewModel);
		case "chat_bot":
			return typeof(SupportChatViewModel);
		case "personal-settings/loyalty":
			return typeof(LoyaltyTabViewModel);
		case "personal-settings/my-profile":
			return typeof(UserDataViewModel);
		case "cabinet":
			return typeof(ProfileViewModel);
		case "personal-settings":
			return typeof(ProfileViewModel);
		case "subscriptions":
			return typeof(UserDataViewModel);
		case "orders":
			return typeof(OrdersViewModel);
		case "personal-settings/my-orders":
			return typeof(OrdersViewModel);
		case "cards":
			return typeof(UserCardsViewModel);
		case "stores":
			return typeof(StoresViewModel);
		case "shops":
			return typeof(StoresViewModel);
		case "store":
			return typeof(StoreDetailsViewModel);
		case "infopages":
			return typeof(InfoPageIntermediateViewModel);
		case "help/company/legal-information":
			return typeof(InfoPageIntermediateViewModel);
		case "faq":
			return typeof(FAQViewModel);
		case "instructions":
			return typeof(TutorialsIntermediateViewModel);
		case "points_transfer":
			return typeof(LoyaltyPointsTransferOptionsViewModel);
		case "points_transfer_charity":
			return typeof(LoyaltyPointsTransferToCharityViewModel);
		case "personal_promotions":
			return typeof(MyOffersViewModel);
		case "personal_promotions_detail":
			return typeof(MyOffersViewModel);
		case "personal_promotions_offer":
			return typeof(MyOffersViewModel);
		case "my_coupons":
			return typeof(CouponsViewModel);
		case "personal-settings/favorite-categories":
			return typeof(MyFavoriteCategoriesPreloaderViewModel);
		case "purchases_history":
			return typeof(MyPurchasesViewModel);
		case "social_status":
			return typeof(UnconfirmedSocialStatusViewModel);
		case "user_data":
			return typeof(UserDataViewModel);
		case "game":
			return typeof(NewYearGameViewModel);
		case "history":
			return typeof(MyPurchasesViewModel);
		case "burnt-points":
			return typeof(LoyaltyCardPointsExpirationViewModel);
		case "gift_cards":
			return typeof(GiftCardsViewModel);
		case "personal-settings/gift-card":
			return typeof(GiftCardsViewModel);
		case "promotions":
			return typeof(SalesAndNewsViewModel);
		case "sales_and_news":
			return typeof(SalesAndNewsViewModel);
		case "favorites":
			return typeof(FavoritesViewModel);
		case "personal-settings/favorites":
			return typeof(FavoritesViewModel);
		case "search":
			return typeof(SearchProductsResultViewModel);
		case "spotlight":
			return typeof(CatalogProductsViewModel);
		case "superceny":
			return typeof(ProductsViewModel);
		case "cashback":
			return typeof(ProductsViewModel);
		case "personal-settings/waitlist":
			return typeof(WaitListViewModel);
		case "personal-settings/my-purchases":
			return typeof(MyPurchasesViewModel);
		case "feedback":
			return typeof(DynamicFeedbackViewModel);
		case "personal-settings/my-auto":
			return typeof(UserCarsViewModel);
		case "personal-settings/my-reviews":
			return typeof(UserReviewsViewModel);
		case "personal-settings/my-reviews/create":
			return typeof(AddReviewViewModel);
		case "notifications":
			return typeof(NotificationsViewModel);
		case "checkout-success":
			return typeof(CheckoutSuccessViewModel);
		case "checkout-failed":
			return typeof(CheckoutOrderNotPaidViewModel);
		}
	}

	public bool ShouldOpenInBrowser(string link)
	{
		Uri uri = new Uri(link);
		NameValueCollection query = HttpUtility.ParseQueryString(uri.Query);
		return ShouldOpenInBrowser(uri, query);
	}

	private static bool ShouldOpenInBrowser(Uri uri, NameValueCollection query)
	{
		return GetBrowserLaunchMode(uri, query).HasValue;
	}

	private static BrowserLaunchMode? GetBrowserLaunchMode(Uri uri, NameValueCollection query)
	{
		string a = uri.CleanupLocalPath();
		StringComparison comparisonType = StringComparison.InvariantCultureIgnoreCase;
		if (uri.AbsoluteUri.EndsWith(".pdf"))
		{
			return BrowserLaunchMode.External;
		}
		if (string.Equals(a, "auth", comparisonType) && string.Equals(query["block"], "confirm_email", comparisonType))
		{
			return BrowserLaunchMode.External;
		}
		if (query.HasQueryParameter("openinbrowser"))
		{
			return BrowserLaunchMode.External;
		}
		if (query.HasQueryParameter("openinexternalwebview"))
		{
			return BrowserLaunchMode.SystemPreferred;
		}
		return null;
	}

	private async Task<object?> GetLinkParameter(Type destination, Uri uri, UniversalLinkSource source)
	{
		object parameter = await GetGenericParameter(destination);
		NameValueCollection query = HttpUtility.ParseQueryString(uri.Query);
		if (query != null)
		{
			parameter = (await GetQueryParameterByDestination(destination, uri, query, source)) ?? parameter;
			parameter = GetQueryParameterByQuery(destination, query, parameter);
		}
		return parameter;
	}

	private async Task<object?> GetGenericParameter(Type destination)
	{
		return ((object)destination == null || !(destination == typeof(LoyaltyPointsTransferToCharityViewModel))) ? null : (await GetLoyaltyTransferParameter());
	}

	private async Task<object?> GetLoyaltyTransferParameter()
	{
		Result<LoyaltyCardEntity, DomainError> result = await _loyaltyManager.Value.GetBalanceAsync();
		if (result.IsFailure)
		{
			return null;
		}
		int num = decimal.ToInt32(result.Value.PointsAmount);
		return new LoyaltyPointsTransferNavigationParameter(num, decimal.ToInt32((result.Value.PointsAmount - (decimal)num) * 100m), decimal.ToInt32(result.Value.StampsAmount), LoyaltyPointType.Points, replacePrevious: false);
	}

	private async Task<object?> GetQueryParameterByDestination(Type destination, Uri uri, NameValueCollection query, UniversalLinkSource source)
	{
		if ((object)destination == null)
		{
			goto IL_0659;
		}
		object result;
		if (destination == typeof(HomeViewModel))
		{
			result = GetTabActivationParameter(destination, query, BottomNavigationViewModel.TabbarItem.Home);
		}
		else if (destination == typeof(CheckoutSuccessViewModel))
		{
			result = await GetCheckoutSuccessParameterAsync(uri, query);
		}
		else if (destination == typeof(CheckoutOrderNotPaidViewModel))
		{
			result = GetCheckoutFailedParameter(uri, query);
		}
		else if (destination == typeof(CollectionProductsPreloaderViewModel))
		{
			result = await GetCollectionProductsPreloaderParameter(uri, query);
		}
		else if (destination == typeof(ProductDetailsViewModel))
		{
			result = await GetProductParameter(uri, query);
		}
		else if (destination == typeof(InfoPageViewModel))
		{
			result = await GetInfoPageParameter(uri, query);
		}
		else if (destination == typeof(InfoPageIntermediateViewModel))
		{
			result = await GetInfoPageIntermediateParameter(uri, query);
		}
		else if (destination == typeof(FAQViewModel))
		{
			result = GetFAQParameter(uri, query);
		}
		else if (destination == typeof(CartScreenViewModel))
		{
			result = GetTabActivationParameter(destination, query, BottomNavigationViewModel.TabbarItem.Cart);
		}
		else if (destination == typeof(SharedCartPreloaderViewModel))
		{
			result = GetSharedCartParameter(destination, query);
		}
		else if (destination == typeof(CatalogProductsViewModel))
		{
			result = GetCatalogProductsParameter(query);
		}
		else if (destination == typeof(MyOffersViewModel))
		{
			result = GetPersOfferDetailsParameter(uri, query, source);
		}
		else if (destination == typeof(CouponsViewModel))
		{
			result = GetCouponDetailsParameter(uri, query);
		}
		else if (destination == typeof(ProductsViewModel))
		{
			result = GetProductsViewModelParameter(uri, query);
		}
		else if (destination == typeof(MyPurchasesViewModel))
		{
			result = GetMyPurchasesViewModelParameter(uri, query);
		}
		else if (destination == typeof(DynamicFeedbackViewModel))
		{
			result = GetDynamicFeedbackViewModelParameter(uri, query);
		}
		else if (destination == typeof(OrderDetailsViewModel))
		{
			result = await GetOrderDetailsViewModelParameter(uri, query);
		}
		else if (destination == typeof(SearchProductsResultViewModel))
		{
			result = await GetSearchProductsResultViewModelParameter(uri, query);
		}
		else if (destination == typeof(AddReviewViewModel))
		{
			result = await GetAddReviewViewModelParameter(uri, query);
		}
		else
		{
			if (!(destination == typeof(BrowserActivatorViewModel)))
			{
				goto IL_0659;
			}
			result = GetBrowserActivatorViewModelParameter(uri, query);
		}
		goto IL_065c;
		IL_0659:
		result = null;
		goto IL_065c;
		IL_065c:
		return result;
	}

	private object? GetBrowserActivatorViewModelParameter(Uri uri, NameValueCollection query)
	{
		BrowserLaunchMode? browserLaunchMode = GetBrowserLaunchMode(uri, query);
		if (!browserLaunchMode.HasValue)
		{
			return null;
		}
		return new BrowserActivatorViewModel.Parameter
		{
			Uri = uri,
			LaunchMode = browserLaunchMode.Value
		};
	}

	private async Task<object?> GetAddReviewViewModelParameter(Uri uri, NameValueCollection query)
	{
		string text = query["gima_id"];
		if (text == null)
		{
			return null;
		}
		if ((await _productsRepository.Value.GetProductsByGimaIdAsync(_ecomContext.Value.ActiveStore.Id.ToString(), new global::_003C_003Ez__ReadOnlySingleElementList<string>(text))).TryGetValue(out var value) && value.Any())
		{
			AddReviewViewModel.Parameter data = new AddReviewViewModel.Parameter(value.First());
			return _dataBroker.Value.Push(data);
		}
		return null;
	}

	private async Task<object?> GetSearchProductsResultViewModelParameter(Uri uri, NameValueCollection query)
	{
		return new SearchProductsResultViewModel.Parameter
		{
			Query = query["query"]
		};
	}

	private async Task<object?> GetOrderDetailsViewModelParameter(Uri uri, NameValueCollection query)
	{
		if (int.TryParse(uri.CleanupLocalPath().Substring("personal-settings/my-orders/".Length), out var result) && (await _ordersRepository.Value.GetOrderAsync(result)).TryGetValue(out var value))
		{
			return await _orderDetailsParameterFactory.Value.CreateAsync(value);
		}
		return Task.FromResult<object>(null);
	}

	private object? GetDynamicFeedbackViewModelParameter(Uri uri, NameValueCollection query)
	{
		return new DynamicFeedbackViewModel.Parameter(FeedbackState.WithTopicAndCategory);
	}

	private object? GetMyPurchasesViewModelParameter(Uri uri, NameValueCollection query)
	{
		return new MyPurchasesViewModel.Parameter();
	}

	private object? GetProductsViewModelParameter(Uri uri, NameValueCollection query)
	{
		string text = query["type"];
		if (!string.IsNullOrEmpty(text))
		{
			ProductsToLoad productsToLoad = text.ToEnum<ProductsToLoad>();
			string text2 = ProductsConverter.FromProductsTypeToTitle(productsToLoad);
			return new ProductsViewModel.Parameter
			{
				Title = text2,
				Code = "",
				ProductsToLoadType = productsToLoad,
				Breadcrumbs = new global::_003C_003Ez__ReadOnlySingleElementList<string>(text2)
			};
		}
		if (uri.LocalPath.StartsWith("/cashback"))
		{
			string text3 = "Мой Кешбэк";
			return new ProductsViewModel.Parameter
			{
				Title = text3,
				Code = "",
				ProductsToLoadType = ProductsToLoad.ByCashbackAvailable,
				Id = null,
				DefaultSortSelection = new ProductSortSelection
				{
					Direction = "desc",
					Field = "cashbackValue"
				},
				Breadcrumbs = new global::_003C_003Ez__ReadOnlySingleElementList<string>(text3)
			};
		}
		if (uri.LocalPath.StartsWith("/superceny"))
		{
			string text4 = "Суперцены";
			return new ProductsViewModel.Parameter
			{
				Title = text4,
				Code = "",
				ProductsToLoadType = ProductsToLoad.ByPromoOnly,
				Id = null,
				DefaultSortSelection = new ProductSortSelection
				{
					Direction = "asc",
					Field = "rank"
				},
				Breadcrumbs = new global::_003C_003Ez__ReadOnlySingleElementList<string>(text4)
			};
		}
		string[] array = uri.LocalPath.Split("/brand/");
		if (array.Length > 1)
		{
			return new ProductsViewModel.Parameter
			{
				Title = "",
				Code = array[1],
				ProductsToLoadType = ProductsToLoad.ByBrand,
				DefaultSortSelection = new ProductSortSelection
				{
					Direction = "asc",
					Field = "rank"
				},
				Breadcrumbs = Array.Empty<string>()
			};
		}
		return null;
	}

	private object? GetCatalogProductsParameter(NameValueCollection query)
	{
		string text = query["title"];
		string text2 = query["code"];
		ProductsToLoad productsToLoadType = query["type"].ToEnum<ProductsToLoad>();
		if (text != null && text2 != null)
		{
			return new CatalogProductsViewModel.Parameter(string.Concat(text[0].ToString().ToUpper(), text.AsSpan(1)), text2, productsToLoadType, null, null, fromSpotlight: true);
		}
		return null;
	}

	private object? GetPersOfferDetailsParameter(Uri uri, NameValueCollection query, UniversalLinkSource source)
	{
		bool fromPush = source == UniversalLinkSource.Push;
		return new MyOffersViewModel.Parameter(query["code"], uri.AbsolutePath.ContainsIgnoreCase("personal_promotions_offer"), fromPush);
	}

	private object? GetCouponDetailsParameter(Uri uri, NameValueCollection query)
	{
		if (long.TryParse(query["id"], out var result))
		{
			return new CouponsViewModel.Parameter(result);
		}
		string text = uri.CleanupLocalPath().Split("/").LastOrDefault();
		if (text != "my_coupons" && long.TryParse(text, out result))
		{
			return new CouponsViewModel.Parameter(result);
		}
		return new CouponsViewModel.Parameter(null);
	}

	private object? GetQueryParameterByQuery(Type destination, NameValueCollection query, object? parameter)
	{
		if (query.AllKeys.Contains<string>("id") && long.TryParse(query["id"], out var result))
		{
			return GetIdParameter(destination, result, parameter);
		}
		if (query.AllKeys.Contains<string>("activate_tab"))
		{
			TabActivatorViewModel.Parameter parameter2 = new TabActivatorViewModel.Parameter
			{
				ActualParameter = parameter
			};
			if (Enum.TryParse<BottomNavigationViewModel.TabbarItem>(query.Get("activate_tab"), out var result2))
			{
				parameter2.Tab = result2;
			}
			return parameter2;
		}
		return parameter;
	}

	private object? GetIdParameter(Type destination, long id, object? parameter)
	{
		if ((object)destination != null)
		{
			if (destination == typeof(PromotionViewModel))
			{
				return new PromotionViewModel.Parameter((int)id);
			}
			if (destination == typeof(StoreDetailsViewModel))
			{
				return new StoreDetailsViewModel.Parameter((int)id);
			}
			if (destination == typeof(NewYearGameViewModel))
			{
				return new NewYearGameViewModel.Parameter((int)id);
			}
		}
		return parameter;
	}

	private async Task<object?> GetCheckoutSuccessParameterAsync(Uri uri, NameValueCollection query)
	{
		string orderId = query["orderId"];
		if (orderId == null)
		{
			_logService.Value.LogError("CheckoutWebViewModel", $"Пустой orderId в {uri}", LogType.ApiRequest, SystemType.ECom);
			return new TabActivatorViewModel.Parameter
			{
				Tab = BottomNavigationViewModel.TabbarItem.Cart
			};
		}
		Result<CheckoutOrderDetails, DomainError> result = await _checkoutService.Value.OrderData(orderId);
		CheckoutSuccessType value = CheckoutSuccessType.PaymentCompleted;
		_logService.Value.Log("CheckoutWebViewModel", $"Результат оплаты заказа: {value}", (!result.IsSuccess) ? LogLevel.Error : LogLevel.Info, LogType.ApiRequest, SystemType.ECom);
		return new CheckoutSuccessViewModel.Parameter(CheckoutSuccessType.PaymentCompleted, new global::_003C_003Ez__ReadOnlySingleElementList<string>(orderId), PaymentCode.Online);
	}

	private object? GetCheckoutFailedParameter(Uri uri, NameValueCollection query)
	{
		string text = query["orderId"];
		if (text == null)
		{
			_logService.Value.LogError("CheckoutWebViewModel", $"Пустой orderId в {uri}", LogType.ApiRequest, SystemType.ECom);
			return new TabActivatorViewModel.Parameter
			{
				Tab = BottomNavigationViewModel.TabbarItem.Cart
			};
		}
		return new CheckoutOrderNotPaidViewModel.Parameter
		{
			OrderIds = new global::_003C_003Ez__ReadOnlySingleElementList<string>(text)
		};
	}

	private async Task<CollectionProductsPreloaderViewModel.Parameter> GetCollectionProductsPreloaderParameter(Uri uri, NameValueCollection query)
	{
		return new CollectionProductsPreloaderViewModel.Parameter
		{
			Url = uri.ToString()
		};
	}

	private async Task<ProductDetailsViewModel.Parameter?> GetProductParameter(Uri uri, NameValueCollection query)
	{
		string text = query["code"];
		if (string.IsNullOrEmpty(text))
		{
			string[] array = uri.CleanupLocalPath().Split("/");
			if (array.Length == 2)
			{
				text = array.Last();
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		Result<Product, DomainError> result = await _productsManager.Value.GetProductDetailAsync(text);
		if (result.IsSuccess)
		{
			return new ProductDetailsViewModel.Parameter(result.Value);
		}
		return null;
	}

	private Task<InfoPageViewModel.Parameter?> GetInfoPageParameter(Uri uri, NameValueCollection query)
	{
		if (_infoPageLocalPathToParameterMap.TryGetValue(uri.CleanupLocalPath(), out string value))
		{
			return Task.FromResult(new InfoPageViewModel.Parameter(value));
		}
		return Task.FromResult<InfoPageViewModel.Parameter>(null);
	}

	private async Task<object?> GetInfoPageIntermediateParameter(Uri uri, NameValueCollection query)
	{
		if (uri.CleanupLocalPath() == "help/company/legal-information")
		{
			return await GetSlugsBy(InfoPagePosition.Documents);
		}
		if (query.AllKeys.Contains<string>("types"))
		{
			string text = query["types"];
			if (text != null && text.Contains(","))
			{
				return new InfoPageIntermediateViewModel.Parameter(text.Split(',').ToList(), string.Empty);
			}
			return new InfoPageViewModel.Parameter(text);
		}
		if (query.AllKeys.Contains<string>("category"))
		{
			InfoPagePosition? position = query["category"]?.ToEnum<InfoPagePosition>();
			return await GetSlugsBy(position);
		}
		return null;
		async Task<object?> GetSlugsBy(InfoPagePosition? infoPagePosition)
		{
			if (!infoPagePosition.HasValue)
			{
				return null;
			}
			Result<List<InfoPage>, DomainError> result = await _infoPagesRepository.Value.InfoPages();
			if (result.IsFailure || result.Value.Count((InfoPage x) => x.Position == infoPagePosition) == 0)
			{
				return null;
			}
			return new InfoPageIntermediateViewModel.Parameter((from x in result.Value
				where x.Position == infoPagePosition
				select x.Slug).ToList(), InfoPagesConverter.PositionToCategoryTitle(infoPagePosition.Value));
		}
	}

	private object? GetFAQParameter(Uri uri, NameValueCollection query)
	{
		if (_faqLocalPathToParameterMap.TryGetValue(uri.CleanupLocalPath(), out var value))
		{
			return new FAQViewModel.Parameter(value);
		}
		if (query.AllKeys.Contains<string>("slug"))
		{
			string text = query["slug"];
			if (!string.IsNullOrWhiteSpace(text))
			{
				return new FAQViewModel.Parameter(text.ToEnum<FAQType>());
			}
		}
		return new FAQViewModel.Parameter(FAQType.Default);
	}

	private object GetTabActivationParameter(Type destination, NameValueCollection query, BottomNavigationViewModel.TabbarItem tab)
	{
		return new TabActivatorViewModel.Parameter
		{
			ActualDestination = destination,
			Tab = tab
		};
	}

	private object GetSharedCartParameter(Type destination, NameValueCollection query)
	{
		return new SharedCartPreloaderViewModel.Parameter
		{
			Query = (query?["share"] ?? "")
		};
	}

	[return: NotNullIfNotNull("uri")]
	public string? ConvertToProductionLink(string? uri)
	{
		if (_environmentManager.Value.CurrentEnvironment == Auchan.Common.Networking.Environment.Production)
		{
			return uri;
		}
		if (uri != null && uri.StartsWith("https://front-preprod.ecom.auchan.ru"))
		{
			return uri.Replace("https://front-preprod.ecom.auchan.ru", "https://www.auchan.ru");
		}
		if (uri != null && uri.StartsWith("https://front-stage-"))
		{
			int value = (int)(_environmentManager.Value.CurrentEnvironment - 1);
			return uri.Replace($"https://front-stage-{value}.ecom.auchan.ru", "https://www.auchan.ru");
		}
		return uri;
	}
}
