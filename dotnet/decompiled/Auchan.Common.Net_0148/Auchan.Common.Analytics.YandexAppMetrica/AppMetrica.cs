using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics.YandexAppMetrica.DataStores;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Ecom.Banners.Models;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.CtmShelves.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Search;
using Auchan.Common.Ecom.Search.Infrastructure;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.Home;
using Auchan.Common.Logs;
using Auchan.Common.LoyaltyProgram.Coupons.Models;
using Auchan.Common.LoyaltyProgram.ViewModels;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.Profile.Orders;
using Auchan.Common.Profile.Orders.Models;
using Auchan.Common.Profile.Orders.Services;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Devices;
using Newtonsoft.Json;

namespace Auchan.Common.Analytics.YandexAppMetrica;

public class AppMetrica : IApplicationStateObserver
{
	private sealed class OrderEventBody
	{
		public required string OrderNumber { get; init; }

		public required IReadOnlyList<ProductOffer> CartItems { get; init; }

		public required string ScreenName { get; init; }

		public required string Afil { get; init; }

		public required string ReceiveMethodId { get; init; }
	}

	private string _csvString = string.Empty;

	private int _eventsCount;

	private const int EventsLimitPerCsv = 100;

	private readonly ScreenDataStore _screenDataStore;

	private readonly Lazy<SearchProductsRepository> _searchRepository;

	private readonly Lazy<IDeviceService> _deviceService;

	private readonly Lazy<IUserContext> _userContext;

	private readonly MetricaCsvRepository _metricaCsvRepository;

	private readonly Lazy<Cart> _cart;

	private readonly Lazy<IMetricaPlatformSdk> _metricaPlatformSdk;

	private readonly Lazy<ILogService> _logService;

	private readonly Lazy<IEcomContext> _ecomContext;

	private readonly Lazy<IOrdersRepository> _ordersRepository;

	private readonly Lazy<IAdminContext> _adminContext;

	private readonly Lazy<EventLimiter> _eventLimiter;

	private string _metricaDeviceID = string.Empty;

	private readonly ICollection<(string eventName, string eventJson)> _eventsQueue = new List<(string, string)>();

	private TaskCompletionSource<Dictionary<string, OrderEventBody>> _ordersAtCheckout = new TaskCompletionSource<Dictionary<string, OrderEventBody>>();

	public const string MetricaSdkApiKey = "29ce206c-cd70-4273-abb2-b43217df70a9";

	private string? StoreId
	{
		get
		{
			if (!_ecomContext.Value.Initialized)
			{
				return null;
			}
			return Convert.ToString(_ecomContext.Value.ActiveStore.Id);
		}
	}

	private bool IsCurrentScreenSearch => _screenDataStore.GetCurrentScreenViewModelType() is SearchProductsResultViewModel;

	private string? CurrentSearchQueryIfCurrentScreenIsSearch
	{
		get
		{
			if (!IsCurrentScreenSearch)
			{
				return null;
			}
			return _searchRepository.Value.CurrentSearchQuery;
		}
	}

	private bool IsPreviousScreenSearch => _screenDataStore.GetPreviousScreenViewModelType() is SearchProductsResultViewModel;

	private string? PreviousSearchQueryIfCurrentScreenIsSearch
	{
		get
		{
			if (!IsPreviousScreenSearch)
			{
				return null;
			}
			return _searchRepository.Value.CurrentSearchQuery;
		}
	}

	public static Stopwatch ColdStartWatch { get; } = new Stopwatch();

	public static Stopwatch WarmStartWatch { get; } = new Stopwatch();

	public static Stopwatch SpeedAuthorizationWatch { get; } = new Stopwatch();

	public static Stopwatch MainScreenLoadWatch { get; } = new Stopwatch();

	public AppMetrica(Lazy<IUserContext> userContext, ScreenDataStore screenDataStore, MetricaCsvRepository metricaCsvRepository, Lazy<Cart> cart, Lazy<IDeviceService> deviceService, Lazy<IMetricaPlatformSdk> metricaPlatformSdk, Lazy<ILogService> logService, Lazy<SearchProductsRepository> searchRepository, Lazy<IEcomContext> ecomContext, Lazy<ICheckoutService> checkoutService, Lazy<IOrdersRepository> ordersRepository, Lazy<IAdminContext> adminContext, Lazy<EventLimiter> eventLimiter)
	{
		_deviceService = deviceService;
		_metricaPlatformSdk = metricaPlatformSdk;
		_logService = logService;
		_searchRepository = searchRepository;
		_ecomContext = ecomContext;
		_ordersRepository = ordersRepository;
		_userContext = userContext;
		_screenDataStore = screenDataStore;
		_adminContext = adminContext;
		_eventLimiter = eventLimiter;
		_metricaCsvRepository = metricaCsvRepository;
		_cart = cart;
		_screenDataStore.OnScreenChanged = async delegate(IYandexMetricaScreenViewModel screenViewModel, string searchQuery)
		{
			await Task.Delay(100);
			string screenNameForBaseEvents = screenViewModel.ScreenNameForBaseEvents;
			if (!string.IsNullOrEmpty(screenNameForBaseEvents) && (!(screenViewModel is SearchProductsResultViewModel) || !string.IsNullOrWhiteSpace(searchQuery)))
			{
				_metricaPlatformSdk.Value.ReportShowScreen(screenNameForBaseEvents, StoreId, searchQuery);
				_logService.Value.LogInfo("baseEventSourceData: showScreenEvent", $"screen name: {screenNameForBaseEvents}, store id: {StoreId}, search query: \"{searchQuery}\"", LogType.UserAction, SystemType.YandexAppMetrica);
			}
		};
	}

	public Task OnPausedAsync()
	{
		return _metricaCsvRepository.SaveNotFullCsv(_csvString);
	}

	public void SetDeviceId(string deviceID)
	{
		_metricaDeviceID = deviceID;
		if (_eventsQueue.Any() && !string.IsNullOrWhiteSpace(_metricaDeviceID))
		{
			TrackQueuedEvents();
		}
	}

	public void ProductCardView(Product product, IYandexMetricaScreenViewModel screenViewModel)
	{
		string screenName = screenViewModel.ScreenName;
		string searchQuery = screenViewModel.SearchQuery;
		string value = JsonConvert.SerializeObject(product);
		_metricaPlatformSdk.Value.ReportProductCardEvent(product, screenName, StoreId, searchQuery);
		_logService.Value.LogInfo("baseEventSourceData: showProductCardEvent", $"screen name: {screenName}\nstore id:\n{StoreId}\nsearch query:\n{searchQuery}\nproduct:\n{value}", LogType.UserAction, SystemType.YandexAppMetrica);
	}

	public void ProductDetailScreenView(Product product)
	{
		string previousSearchQueryIfCurrentScreenIsSearch = PreviousSearchQueryIfCurrentScreenIsSearch;
		string previousScreenName = GetPreviousScreenName();
		string value = JsonConvert.SerializeObject(product);
		_metricaPlatformSdk.Value.ReportProductDetails(product, previousScreenName, StoreId, previousSearchQueryIfCurrentScreenIsSearch);
		_logService.Value.LogInfo("baseEventSourceData: showProductDetailsEvent", $"screen name: {previousScreenName}\nstore id:\n{StoreId}\nsearch query:\n{previousSearchQueryIfCurrentScreenIsSearch}\nproduct:\n{value}", LogType.UserAction, SystemType.YandexAppMetrica);
	}

	public void AddToCart(ProductOffer product, decimal diff)
	{
		string currentScreenName = GetCurrentScreenName();
		string value = JsonConvert.SerializeObject(product);
		_metricaPlatformSdk.Value.ReportAddCartItem(product, diff, currentScreenName, StoreId, CurrentSearchQueryIfCurrentScreenIsSearch);
		_logService.Value.LogInfo("baseEventSourceData: addCartItemEvent", $"screen name: {currentScreenName}\nstore id: {StoreId}\nsearch query:  {CurrentSearchQueryIfCurrentScreenIsSearch}\nqty: {diff}\nproduct: {value}", LogType.UserAction, SystemType.YandexAppMetrica);
	}

	public void RemoveFromCart(ProductOffer product, decimal diff)
	{
		string currentScreenName = GetCurrentScreenName();
		string value = JsonConvert.SerializeObject(product);
		_metricaPlatformSdk.Value.ReportRemoveCartItem(product, diff, currentScreenName, StoreId, CurrentSearchQueryIfCurrentScreenIsSearch);
		_logService.Value.LogInfo("baseEventSourceData: removeCartItemEvent", $"screen name: {currentScreenName}\nstore id: {StoreId}\nsearch query: {CurrentSearchQueryIfCurrentScreenIsSearch}\nqty: {diff}\nproduct: {value}", LogType.UserAction, SystemType.YandexAppMetrica);
	}

	public void CartScreenView()
	{
		TrackEvent("cartScreenView");
		SendCsvIgnoreLimit();
	}

	public void OpenEmptyCartScreenWithToCatalogueButton()
	{
		TrackEmptyCartScreen("screenView", value: true);
		TrackEmptyCartScreenButtonShown("toCatalogue");
	}

	public void TrackEmptyCartFavoritesShown()
	{
		TrackEmptyCartScreenButtonShown("toFavorites");
	}

	public void TrackEmptyCartRepeatLastOrderShown()
	{
		TrackEmptyCartScreenButtonShown("repeatLastOrder");
	}

	private void TrackEmptyCartScreenButtonShown(string button)
	{
		TrackEmptyCartScreen(button, "shown");
	}

	private void TrackEmptyCartScreen<T>(string @event, T value)
	{
		string eventJson = JsonConvert.SerializeObject(new Dictionary<string, T> { { @event, value } });
		TrackEvent("emptyCartScreen", eventJson);
	}

	public void OnEmptyCartScreenToCatalogueClick()
	{
		OnEmptyCartScreenToButtonClick("toCatalogue");
	}

	public void OnEmptyCartScreenToFavoritesClick()
	{
		OnEmptyCartScreenToButtonClick("toFavorites");
	}

	public void OnEmptyCartScreenRepeatLastOrderClick()
	{
		OnEmptyCartScreenToButtonClick("repeatLastOrder");
	}

	public void TrackPopUpCartUpdate()
	{
		TrackEvent("popUpCartUpdate");
	}

	public void TrackPopUpCartUpdateButtonChange()
	{
		TrackEvent("popUpCartUpdate_button_change");
	}

	public void TrackPopUpCartUpdateButtonCancel()
	{
		TrackEvent("popUpCartUpdate_button_cancel");
	}

	private void OnEmptyCartScreenToButtonClick(string button)
	{
		string eventJson = JsonConvert.SerializeObject(new Dictionary<string, string> { { button, "click" } });
		TrackEvent("emptyCartScreen", eventJson);
	}

	public void CheckoutScreenView()
	{
		foreach (ProductOffer item in _cart.Value.Items)
		{
			string text = JsonConvert.SerializeObject(new
			{
				Id = item.Id.ToString(),
				name = item.Name,
				category = (item.CategoryCodes?.FirstOrDefault()?.Code ?? ""),
				price = $"{item.PricePerOneOrPerKilo:N2}",
				oldPrice = $"{item.OldPricePerOneOrPerKilo.GetValueOrDefault():N2}",
				ispromo = (item.IsSaleActive ? "promo" : "non"),
				iscash = ((item.Cashback != null && item.Cashback.Amount != 0) ? "cash" : "non")
			});
			TrackEvent("checkout1Screen_view", text);
			_logService.Value.LogInfo("beginCheckoutEvent", text, LogType.UserAction, SystemType.YandexAppMetrica);
		}
		SendCsvIgnoreLimit();
	}

	public async Task BeginCheckoutEvent(IYandexMetricaScreenViewModel screenViewModel, string[] orderIds)
	{
		Dictionary<string, OrderEventBody> ordersAtCheckout = new Dictionary<string, OrderEventBody>();
		TaskCompletionSource<Dictionary<string, OrderEventBody>> tcs = new TaskCompletionSource<Dictionary<string, OrderEventBody>>();
		TaskCompletionSource<Dictionary<string, OrderEventBody>> taskCompletionSource = Interlocked.Exchange(ref _ordersAtCheckout, tcs);
		List<ProductOffer> allCartItems = _cart.Value.Items.ToList();
		taskCompletionSource.TrySetResult(new Dictionary<string, OrderEventBody>());
		await Task.Delay(3000);
		List<OrderModel> orders = new List<OrderModel>();
		foreach (string orderId in orderIds)
		{
			Result<OrderModel, DomainError> result = await _ordersRepository.Value.GetOrderAsync(orderId);
			if (result.IsSuccess)
			{
				orders.Add(result.Value);
			}
		}
		foreach (OrderModel order in orders)
		{
			OrderEventBody orderEventBody = new OrderEventBody
			{
				OrderNumber = order.Number,
				CartItems = allCartItems.Where((ProductOffer x) => x.IsAdult == order.IsAdult).ToList(),
				ScreenName = screenViewModel.ScreenName,
				Afil = StoreId,
				ReceiveMethodId = $"{_ecomContext.Value.ReceivingMethod}"
			};
			ordersAtCheckout[order.Number] = orderEventBody;
			_metricaPlatformSdk.Value.ReportBeginCheckout(orderEventBody.OrderNumber, orderEventBody.CartItems, orderEventBody.ScreenName, orderEventBody.Afil, orderEventBody.ReceiveMethodId);
			string description = JsonConvert.SerializeObject(orderEventBody);
			_logService.Value.LogInfo("baseEventSourceData: beginCheckoutEvent", description, LogType.UserAction, SystemType.YandexAppMetrica);
		}
		tcs.TrySetResult(ordersAtCheckout);
	}

	public void SeasonOfferClick(Banner banner)
	{
		SendFakeAdRevenue("promoClick", ("promoFormat", "seasonal"), ("promoId", banner.Id.ToString()), ("promoName", banner.Name));
	}

	public async Task ColdStartEnd()
	{
		if (ColdStartWatch.IsRunning)
		{
			ColdStartWatch.Stop();
			object value = new
			{
				coldStartTimeMs = ColdStartWatch.ElapsedMilliseconds,
				timestamp = DateTime.Now.ToTimestamp()
			};
			string eventJson = JsonConvert.SerializeObject(value);
			ColdStartWatch.Reset();
			await Task.Delay(TimeSpan.FromSeconds(10L));
			TrackEvent("coldStart", eventJson);
		}
	}

	public async Task WarmStartEnd()
	{
		if (WarmStartWatch.IsRunning)
		{
			WarmStartWatch.Stop();
			object value = new
			{
				warmStartTimeMs = WarmStartWatch.ElapsedMilliseconds,
				timestamp = DateTime.Now.ToTimestamp()
			};
			string eventJson = JsonConvert.SerializeObject(value);
			WarmStartWatch.Reset();
			await Task.Delay(TimeSpan.FromSeconds(5L));
			TrackEvent("warmStart", eventJson);
		}
	}

	public void SpeedAuthorizationEnd()
	{
		if (SpeedAuthorizationWatch.IsRunning)
		{
			SpeedAuthorizationWatch.Stop();
			string eventJson = JsonConvert.SerializeObject(new
			{
				speedAuthTimeMs = SpeedAuthorizationWatch.ElapsedMilliseconds,
				timestamp = DateTime.Now.ToTimestamp()
			});
			SpeedAuthorizationWatch.Reset();
			TrackEvent("speedAuthorization", eventJson);
		}
	}

	public void MainScreenLoadEnd()
	{
		if (MainScreenLoadWatch.IsRunning)
		{
			MainScreenLoadWatch.Stop();
			string eventJson = JsonConvert.SerializeObject(new
			{
				mainScreenTimeMs = MainScreenLoadWatch.ElapsedMilliseconds,
				timestamp = DateTime.Now.ToTimestamp()
			});
			MainScreenLoadWatch.Reset();
			TrackEvent("mainScreenLoad", eventJson);
		}
	}

	public async Task SuccessPaymentScreenViewAsync(IReadOnlyList<OrderDetailsDto> orderDetails)
	{
		Dictionary<string, OrderEventBody> dictionary = await _ordersAtCheckout.Task;
		foreach (OrderDetailsDto item in orderDetails.DistinctBy((OrderDetailsDto x) => x.Order.Number))
		{
			decimal orderPrice = default(decimal);
			Payment payment = item.Payments?.FirstOrDefault();
			if (payment != null)
			{
				orderPrice = payment.Sum.Value;
			}
			string eventJson = JsonConvert.SerializeObject(new
			{
				orderPrice = orderPrice,
				orderNumber = item.Order.Number,
				coupon = (item.Order.Promocode ?? ""),
				afil = (item.Shop?.MerchantId ?? 0).ToString()
			});
			TrackEvent("paymentScreen_payment_success", eventJson);
			if (dictionary.TryGetValue(item.Order.Number, out var value))
			{
				var anon = new
				{
					orderNumber = item.Order.Number,
					coupon = (item.Order.Promocode ?? ""),
					cartItems = value.CartItems,
					screenName = value.ScreenName,
					afil = value.Afil,
					receiveMethodId = value.ReceiveMethodId
				};
				_metricaPlatformSdk.Value.ReportPurchase(anon.orderNumber, anon.cartItems, anon.screenName, anon.afil, anon.receiveMethodId, anon.coupon);
				string description = JsonConvert.SerializeObject(anon);
				_logService.Value.LogInfo("baseEventSourceData: purchaseEvent", description, LogType.UserAction, SystemType.YandexAppMetrica);
			}
		}
		SendCsvIgnoreLimit();
	}

	public void SendFakeAdRevenue(string placementId, params (string key, string value)[] eventParams)
	{
		ImmutableDictionary<string, string> immutableDictionary = eventParams.ToImmutableDictionary(((string key, string value) i) => i.key, ((string key, string value) i) => i.value);
		SendFakeAdRevenue(placementId, immutableDictionary.Any() ? immutableDictionary : null);
	}

	public void SendFakeAdRevenue(string placementId, IReadOnlyDictionary<string, string>? payload = null)
	{
		Task.Run(delegate
		{
			AdRevenue adRevenue = new AdRevenue
			{
				Revenue = 0.01m,
				Currency = "RUB",
				AdPlacementID = placementId,
				Payload = payload
			};
			_metricaPlatformSdk.Value.ReportAdRevenue(adRevenue);
			string text = string.Join("\n", payload?.Select((KeyValuePair<string, string> i) => i.Key + ": " + i.Value) ?? Array.Empty<string>());
			_logService.Value.LogInfo("AppMetrica", "Sent fake ad revenue event " + placementId + ", payload: \n" + text, LogType.UserAction, SystemType.YandexAppMetrica);
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void FailurePaymentScreenView()
	{
		TrackEvent("paymentScreen_payment_failure");
	}

	public void AddLoyaltyCardToWallet()
	{
		string eventJson = JsonConvert.SerializeObject(new
		{
			Platform = DeviceInfo.Platform.ToString()
		});
		TrackEvent("addLoyaltyCardToWallet", eventJson);
	}

	public void AlreadyActiveLoyalityCardView()
	{
		TrackEvent("AlreadyActiveLoyalityCard_view");
	}

	public void ActivateLoyaltyPlasticCard()
	{
		TrackEvent("ActivateLoyaltyPlasticCard");
	}

	public void ScanLoyaltyManualInput()
	{
		TrackEvent("ScanLoyaltyManualInput");
	}

	public void ScanLoyaltySuccess()
	{
		TrackEvent("ScanLoyaltySuccess");
	}

	public void ScanLoyaltyError()
	{
		TrackEvent("ScanLoyaltyError");
	}

	public void СreateLoyaltyVirtualCard()
	{
		TrackEvent("СreateLoyaltyVirtualCard");
	}

	public void ActivationLoyaltyCardSuccess()
	{
		TrackEvent("ActivationLoyaltyCardSuccess");
	}

	public void TapMainOnLoyaltyCard()
	{
		TrackEvent("TapMainOnLoyaltyCard");
	}

	public void TapMainOnMyOffers()
	{
		TrackEvent("TapMainOnMyOffers");
	}

	public void TapLoyaltyOnCashback()
	{
		TrackEvent("TapLoyaltyOnCashback");
	}

	public void TapLoyaltyOnScoreStatistic()
	{
		TrackEvent("TapLoyaltyOnScoreStatistic");
	}

	public void TapLoyaltyOnShareBonus()
	{
		TrackEvent("TapLoyaltyOnShareBonus");
	}

	public void TapLoyaltyOnAllOffers()
	{
		TrackEvent("TapLoyaltyOnAllOffers");
	}

	public void TapMainOnNearbyStores()
	{
		TrackEvent("TapMainOnNearbyStores");
	}

	public void OpenQrTapped(LoyaltyCardQrPreviewViewModel.OpenedFrom openedFrom)
	{
		string eventJson = JsonConvert.SerializeObject(new
		{
			ActionField = openedFrom switch
			{
				LoyaltyCardQrPreviewViewModel.OpenedFrom.HomeTab => "Main", 
				LoyaltyCardQrPreviewViewModel.OpenedFrom.LoyaltyTab => "Loyalty", 
				_ => "noConnection", 
			}
		});
		TrackEvent("goToQrCode", eventJson);
	}

	public void OpenLoyaltyQuestions()
	{
		TrackEvent("TapLoyaltyOnQuestions");
	}

	public void OpenLoyaltyFeedback()
	{
		TrackEvent("TapLoyaltyOnContact");
	}

	public void OpenLoyaltyAddCard()
	{
		TrackEvent("TapLoyaltyAddPlasticCard");
	}

	public void OpenLoyaltyRules()
	{
		TrackEvent("TapLoyaltyOnRules");
	}

	public void SocialStatusConfirmed()
	{
		TrackEvent("SocialStatusConfirmed_view");
	}

	public void SocialStatusNotConfirmed()
	{
		TrackEvent("SocialStatusNotConfirmed_view");
	}

	public void OpenOrderDetails()
	{
		TrackEvent("HistoryOrderCompositionScreen_view");
	}

	public void LoyaltyQrOpened()
	{
		TrackEvent("qrCodeScreen_view");
	}

	public void PromocodeAttempted(string promocode, bool success)
	{
		string eventJson = JsonConvert.SerializeObject(new
		{
			Promocode = promocode,
			Success = success
		});
		TrackEvent("checkout1Screen_promocode_attempt", eventJson);
	}

	public void PointsUsed(decimal used, decimal left)
	{
		string eventJson = JsonConvert.SerializeObject(new
		{
			UsedPoints = used,
			Points = left
		});
		TrackEvent("checkout1Screen_loyaltyPoints", eventJson);
	}

	public void SurgeSlotDisplayed()
	{
		TrackEvent("surge_slot_displayed");
	}

	public void SurgeSlotSelected(string timeslotName, decimal slotPrice)
	{
		string eventJson = JsonConvert.SerializeObject(new
		{
			timeslot_name = timeslotName,
			slot_price = slotPrice
		});
		TrackEvent("surge_slot_selected", eventJson);
	}

	public void PersonalOfferCellDisplayed(int id, string name)
	{
	}

	public void PersonalOfferTapped(string id, string name, int positon, IYandexMetricaScreenViewModel from)
	{
		TrackEvent("Tap_offer");
		string eventJson = JsonConvert.SerializeObject(new
		{
			ActionField = (from.ScreenName ?? ""),
			offerId = id,
			offerName = name,
			offerPosition = positon
		});
		TrackEvent("personalOfferClick", eventJson);
	}

	public void RepeatLastCompletedOrderTapped()
	{
		TrackEvent("mainScreenButtonRepeatOrderClick");
		SendCsvIgnoreLimit();
	}

	public void RepeatLastCompletedOrderShown()
	{
		TrackEvent("mainScreenButtonRepeatOrderShown");
		SendCsvIgnoreLimit();
	}

	public void TapMainOnForBusiness()
	{
		Task.Run(delegate
		{
			TrackEvent("b2b");
		});
	}

	public void CreateSharedCartLink(bool linkCreated, string? sharedCartId)
	{
		string eventJson = JsonConvert.SerializeObject(new
		{
			afil = StoreId,
			createSuccess = linkCreated,
			sharedCartId = sharedCartId
		});
		TrackEvent("createSharedCartLink", eventJson);
	}

	public void AddSharedCartItems(bool goodsAdded, string? sharedCartId)
	{
		string eventJson = JsonConvert.SerializeObject(new
		{
			afil = StoreId,
			addSharedCartSuccess = goodsAdded,
			sharedCartId = sharedCartId
		});
		TrackEvent("addSharedCartItems", eventJson);
	}

	public void ExpiredLinkToCatalog()
	{
		TrackEvent("expiredLinkToCatalog");
	}

	public void ExpiredLinkToMain()
	{
		TrackEvent("expiredLinkToMain");
	}

	public void TrackAddressBlockClick(ReceivingMethod receivingMethod, AddressMapViewModel.NavigatedFrom navigatedFrom)
	{
		string item = receivingMethod switch
		{
			ReceivingMethod.Delivery => "delivery", 
			ReceivingMethod.ExpressDelivery => "express_delivery", 
			ReceivingMethod.Pickup => "pickup", 
			ReceivingMethod.CarPickup => "auto", 
			ReceivingMethod.RegionDefault => "null", 
			_ => "null", 
		};
		string item2 = navigatedFrom switch
		{
			AddressMapViewModel.NavigatedFrom.Cart => "Cart", 
			AddressMapViewModel.NavigatedFrom.Catalog => "Catalog", 
			AddressMapViewModel.NavigatedFrom.Home => "Main", 
			AddressMapViewModel.NavigatedFrom.Unknown => "null", 
			_ => "null", 
		};
		AppAnalytics.AppMetrica.TrackEvent("addressBlockClick", ("method", item), ("screen", item2));
	}

	public void TrackCoupon(Coupon coupon)
	{
		TrackEvent("TapMainOnMyCoupons");
	}

	public void TrackCashbackPersOffer(PersOfferItemViewModel offerViewModel)
	{
		TrackEvent("TapMainOnMyCashback");
	}

	public void TrackSaleCoupon(Coupon coupon)
	{
		TrackEvent("TapMainOnMyCoupons");
	}

	public void AddToOrderButtonTap(AddToOrderButtonPlacement placement)
	{
		Task.Run(delegate
		{
			switch (placement)
			{
			case AddToOrderButtonPlacement.ThankYouPurchase:
				TrackEvent("tapdozakazTyp");
				break;
			case AddToOrderButtonPlacement.Home:
				TrackEvent("tapdozakazMain");
				break;
			case AddToOrderButtonPlacement.Listing:
				TrackEvent("tapdozakazListing");
				break;
			case AddToOrderButtonPlacement.Order:
				TrackEvent("tapdozakazOrder");
				break;
			}
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void TrackAddToPreviousOrderTap()
	{
		Task.Run(delegate
		{
			TrackEvent("tapdozakazCart");
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void TrackConfirmAddToPreviousOrderTap(AddProductsToOrderPopupViewModel.Parameter parameter)
	{
		Task.Run(delegate
		{
			string eventJson = JsonConvert.SerializeObject(new
			{
				orderAdditionPrice = parameter.ProductsSum,
				products = parameter.AvailableItems.Select((AdditionalOrderProductItem i) => new
				{
					gimaId = i.GimaId,
					price = i.Price.Value
				}).ToImmutableList()
			});
			TrackEvent("tapdozakazPopupToAdd", eventJson);
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void TrackCtmShelfMonetization(string eventName, Shelf shelf)
	{
		Task.Run(delegate
		{
			string eventJson = JsonConvert.SerializeObject(new
			{
				id = $"{shelf.Id}/{shelf.Title}",
				@event = eventName
			});
			TrackEvent("monetization", eventJson);
		});
	}

	public void TrackCtmShelfMonetization(string eventName, ProductItemViewModel product)
	{
		TrackCtmShelfMonetization(eventName, product.RecomAnalytics.BlockId, product.Product);
	}

	public void TrackCtmShelfMonetization(string eventName, string blockId, Product product)
	{
		Task.Run(delegate
		{
			string eventJson = JsonConvert.SerializeObject(new
			{
				id = blockId,
				@event = eventName,
				title = product.Title
			});
			TrackEvent("monetization", eventJson);
		});
	}

	public void TrackGoingToExternalBank(bool appLaunched, IEnumerable<string> orderIds)
	{
		SendFakeAdRevenue("proceed_to_bank", ("isBankAppLaunched", appLaunched ? "true" : "false"), ("order_id", string.Join(',', orderIds)));
	}

	public void TrackPartialOrderInitiated()
	{
		TrackPartialOrderEvent("partial_order_initiated", (ProductOffer i) => i.IsSelected, (IReadOnlyList<ProductOffer> i) => true);
	}

	public void TrackItemsSavedForLater()
	{
		TrackPartialOrderEvent("items_saved_for_later", (ProductOffer i) => !i.IsSelected, (IReadOnlyList<ProductOffer> i) => i.Count > 0);
	}

	private void TrackPartialOrderEvent(string name, Func<ProductOffer, bool> predicate, Func<IReadOnlyList<ProductOffer>, bool> shouldSendEventPredicate)
	{
		Task.Run(delegate
		{
			ImmutableList<ProductOffer> immutableList = _cart.Value.Items.Where(predicate).ToImmutableList();
			if (shouldSendEventPredicate(immutableList))
			{
				string eventJson = JsonConvert.SerializeObject(immutableList.Select((ProductOffer i) => new
				{
					id = i.Id,
					sum = i.Price,
					count = i.Qty
				}).ToImmutableList());
				TrackEvent(name, eventJson);
			}
		}).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void TrackVpnFullscreen()
	{
		TrackEvent("vpnFullscreen");
	}

	private void SendCsvIgnoreLimit()
	{
		SendIfLimitIsReached(_csvString, _eventsCount, 1);
	}

	public void TrackEvent(string eventName, params (string key, string? value)[] eventParams)
	{
		string eventJson = JsonConvert.SerializeObject(eventParams.ToDictionary(((string key, string value) kvp) => kvp.key, ((string key, string value) kvp) => kvp.value));
		TrackEvent(eventName, eventJson);
	}

	private void TrackEvent(string eventName, string eventJson = "", bool forceMetricaDeviceID = false)
	{
		try
		{
			if (_adminContext.Value.AppConfigIsNotNull && _adminContext.Value.AppConfig.AppMetricaDisabledEvents.ContainsIgnoreCase(eventName))
			{
				_logService.Value.LogInfo(eventName, "REMOVED APPMETRICA EVENT DUE LIMIT REASONS (CONFIG IN ADMIN PANEL)", LogType.UserAction, SystemType.YandexAppMetrica);
				return;
			}
			if (_adminContext.Value.AppConfigIsNotNull && _adminContext.Value.AppConfig.AppMetricaLimitedEvents.FirstOrDefault((AppMetricaLimitedEvent x) => x.EventName == eventName) != null && !_eventLimiter.Value.IsInSendingWindow())
			{
				_logService.Value.LogInfo(eventName, "REMOVED APPMETRICA EVENT DUE LIMIT. ONLY WINDOW 11:30-12:30 ", LogType.UserAction, SystemType.YandexAppMetrica);
				return;
			}
			bool flag = forceMetricaDeviceID || !_userContext.Value.Authorized;
			if (_eventsQueue.Count != 0 && !string.IsNullOrWhiteSpace(_metricaDeviceID) && _userContext.Value.Authorized)
			{
				_eventsQueue.Add((eventName, eventJson));
				TrackQueuedEvents();
				return;
			}
			if (flag && string.IsNullOrWhiteSpace(_metricaDeviceID))
			{
				_eventsQueue.Add((eventName, eventJson));
				return;
			}
			string value = "4431094";
			string value2 = (flag ? _metricaDeviceID : (_userContext.Value.Profile?.MagentoAccountId.ToString() ?? _deviceService.Value.Udid));
			string value3 = TimeHelper.CurrentUnixTimeStamp.ToString();
			string value4 = "\"" + eventJson.Replace("\"", "\"\"") + "\"";
			if (string.IsNullOrEmpty(_csvString))
			{
				if (flag)
				{
					_csvString = "application_id,appmetrica_device_id,event_name,event_timestamp,event_json";
				}
				else
				{
					_csvString = "application_id,profile_id,event_name,event_timestamp,event_json";
				}
			}
			string text = $"\n{value},{value2},{eventName},{value3},{value4}";
			_csvString += text;
			_eventsCount++;
			_metricaCsvRepository.SaveNotFullCsv(_csvString).SafeFireAndForget((Action<Exception>)null, false);
			SendIfLimitIsReached(_csvString, _eventsCount, 100);
		}
		catch (Exception value5)
		{
			Console.WriteLine(value5);
			throw;
		}
	}

	private void TrackQueuedEvents()
	{
		_logService.Value.LogInfo("AppMetrica", $"Sending and flushing {_eventsQueue.Count} queued events (deviceId={_metricaDeviceID})", LogType.UserAction, SystemType.YandexAppMetrica);
		_eventsQueue.ForEach<(string, string)>(delegate((string eventName, string eventJson) e)
		{
			_logService.Value.LogInfo("AppMetrica", "Sending queued event: " + e.eventName, LogType.UserAction, SystemType.YandexAppMetrica);
			TrackEvent(e.eventName, e.eventJson, forceMetricaDeviceID: true);
		});
		_eventsQueue.Clear();
	}

	private void SendIfLimitIsReached(string csvData, int eventsCount, int limit)
	{
		if (eventsCount >= limit)
		{
			_metricaCsvRepository.SaveCsvToPoolAndTryToSend(csvData);
			_csvString = string.Empty;
			_eventsCount = 0;
			_metricaCsvRepository.SaveNotFullCsv(_csvString).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private string GetPreviousScreenName()
	{
		return _screenDataStore.GetPreviousScreenViewModelType()?.ScreenName ?? "";
	}

	private string GetCurrentScreenName()
	{
		return _screenDataStore.GetCurrentScreenViewModelType()?.ScreenName ?? "";
	}
}
