using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Akavache.Sqlite3.Internal;
using AsyncAwaitBestPractices;
using Auchan.Common.Addresses;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Address.DTO;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Ecom.AddressStoreSelection.ViewModels;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.Ecom.Address;

public sealed class AddressMapViewModel : ScreenViewModel
{
	public enum DeliveryType
	{
		Delivery,
		Pickup,
		CarPickup
	}

	public enum NavigatedFrom
	{
		Home,
		Cart,
		Catalog,
		Unknown
	}

	public sealed class Parameter
	{
		public ReceivingMethod ReceivingMethod { get; init; }

		public NavigatedFrom NavigatedFrom { get; init; } = NavigatedFrom.Unknown;

		public ProductOffer? ProductOffer { get; init; }
	}

	public const float WEB_VIEW_PART_OF_SCREEN = 0.5479f;

	public const float POPUP_EXTENDED_STATE = 0.72605f;

	private const string YANDEX_MAP_API = "https://api-maps.yandex.ru";

	private const string LOG_MAP_LOADING = "map loading";

	private readonly Parameter _parameter;

	private readonly YandexMapUrlProvider _yandexMapUrlProvider;

	private readonly IEnvironmentManager _environmentManager;

	private readonly ITokenService _tokenService;

	private readonly ILocationProvider _locationProvider;

	private readonly IStoreService _storeService;

	private readonly IUserAddressService _userAddressService;

	private readonly IDataBroker _dataBroker;

	private readonly AddressChanger _addressChanger;

	private readonly IInfoMessageService _infoMessageService;

	private readonly IErrorTranslator _errorTranslator;

	private readonly StoreRepository _storeRepository;

	private readonly Lazy<ILogService> _logService;

	private bool _isEventListenerInstalled;

	private TaskCompletionSource<bool> _mapLoadedCompletionSource = new TaskCompletionSource<bool>();

	private readonly bool _isFirstTimeAddressSelection;

	private bool _initialized;

	private SavedAddress? _selectedSavedAddress;

	private readonly AsyncLock _updateStoresLock = new AsyncLock();

	private readonly List<YandexMapMessageDTO> _messagesSentToWebView = new List<YandexMapMessageDTO>();

	private Func<Task> _retryAction = DoNothing;

	private bool _disposed;

	private volatile int _sendMessageToWebViewRequestId;

	private readonly TaskCompletionSource<string> _tokenTcs = new TaskCompletionSource<string>();

	private bool _showExpressDeliveryPopupWhenReady;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CWebViewState_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CUpdatingStores_003Ek__BackingField;

	[CompilerGenerated]
	private DeliveryType _003CDeliveryState_003Ek__BackingField;

	[CompilerGenerated]
	private Suggestion? _003CDeliveryTo_003Ek__BackingField;

	[CompilerGenerated]
	private Coordinate? _003CUserLocation_003Ek__BackingField;

	[CompilerGenerated]
	private Coordinate? _003CDeliveryLocation_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsLocationDetecting_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsAddressValidationError_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CAddressValidationErrorText_003Ek__BackingField;

	[CompilerGenerated]
	private DeliveryMethodsForAddress? _003CAvailableDeliveryMethods_003Ek__BackingField;

	[CompilerGenerated]
	private SavedReceiveMethods? _003CSavedReceiveMethods_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsExpressDeliverySelected_003Ek__BackingField;

	[CompilerGenerated]
	private City? _003CSelectedCity_003Ek__BackingField;

	[CompilerGenerated]
	private Store? _003CSelectedPickupStore_003Ek__BackingField;

	[CompilerGenerated]
	private Store? _003CSelectedCarPickupStore_003Ek__BackingField;

	[CompilerGenerated]
	private IEnumerable<IGrouping<City, Store>>? _003CCityStoreGroups_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

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
				RaisePropertyChanged("IsSaveButtonEnabled");
				OnStateChanged();
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.InProgress;

	public VisualState WebViewState
	{
		[CompilerGenerated]
		get
		{
			return _003CWebViewState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CWebViewState_003Ek__BackingField != value)
			{
				_003CWebViewState_003Ek__BackingField = value;
				RaisePropertyChanged("WebViewState");
			}
		}
	} = VisualState.InProgress;

	public string UserAgent => "auchan-mobile-web-view";

	private string BaseMapAddress => _yandexMapUrlProvider.BaseUrlForEnvironment(_environmentManager.CurrentEnvironment) ?? "";

	public UICommand<string> EvaluateJavascript { get; } = new UICommand<string>();

	public UICommand AddEventListenerCommand { get; } = new UICommand();

	public UICommand<BrokerToken> OpenAddressDetailsCommand { get; } = new UICommand<BrokerToken>();

	public IDictionary<string, string> Headers { get; }

	public string NoMapAvailableText => "Не удалось загрузить карту";

	public bool UpdatingStores
	{
		[CompilerGenerated]
		get
		{
			return _003CUpdatingStores_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CUpdatingStores_003Ek__BackingField != value)
			{
				_003CUpdatingStores_003Ek__BackingField = value;
				RaisePropertyChanged("IsSaveButtonEnabled");
				RaisePropertyChanged("UpdatingStores");
			}
		}
	}

	public string CurrentRegionName => SelectedCity?.Name ?? "";

	public UICommand<BrokerToken> SelectRegionCommand { get; } = new UICommand<BrokerToken>();

	public UICommand SaveCommand { get; } = new UICommand();

	public string SaveButtonText => "Сохранить";

	public bool IsSaveButtonEnabled
	{
		get
		{
			if (State == VisualState.Default && !IsLocationDetecting && !UpdatingStores)
			{
				return GetSaveButtonState();
			}
			return false;
		}
	}

	public DeliveryType DeliveryState
	{
		[CompilerGenerated]
		get
		{
			return _003CDeliveryState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CDeliveryState_003Ek__BackingField != value)
			{
				_003CDeliveryState_003Ek__BackingField = value;
				RaisePropertyChanged("IsSaveButtonEnabled");
				RaisePropertyChanged("UnavailableInfoText");
				RaisePropertyChanged("UnavailableInfoVisible");
				OnDeliveryStateChanged();
				RaisePropertyChanged("DeliveryState");
			}
		}
	}

	public bool IsDeliveryAvailable => AllStoresOfSelectedCity.Any((Store i) => i.HasDelivery);

	public bool IsPickupAvailable => AllStoresOfSelectedCity.Any((Store i) => i.HasStorePickUp);

	public bool IsCarPickupAvailable => AllStoresOfSelectedCity.Any((Store i) => i.HasCarPickup);

	private Suggestion? DeliveryTo
	{
		[CompilerGenerated]
		get
		{
			return _003CDeliveryTo_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!(_003CDeliveryTo_003Ek__BackingField == value))
			{
				_003CDeliveryTo_003Ek__BackingField = value;
				RaisePropertyChanged("IsSaveButtonEnabled");
				RaisePropertyChanged("SelectAddressText");
				RaisePropertyChanged("DeliveryTypesBlockVisible");
				OnDeliveryToChanged();
				RaisePropertyChanged("DeliveryTo");
			}
		}
	}

	private Coordinate? UserLocation
	{
		[CompilerGenerated]
		get
		{
			return _003CUserLocation_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!(_003CUserLocation_003Ek__BackingField == value))
			{
				_003CUserLocation_003Ek__BackingField = value;
				RaisePropertyChanged("UserLocation");
			}
		}
	}

	private Coordinate? DeliveryLocation
	{
		[CompilerGenerated]
		get
		{
			return _003CDeliveryLocation_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!(_003CDeliveryLocation_003Ek__BackingField == value))
			{
				_003CDeliveryLocation_003Ek__BackingField = value;
				RaisePropertyChanged("DeliveryLocation");
			}
		}
	}

	private bool IsLocationDetecting
	{
		[CompilerGenerated]
		get
		{
			return _003CIsLocationDetecting_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsLocationDetecting_003Ek__BackingField != value)
			{
				_003CIsLocationDetecting_003Ek__BackingField = value;
				RaisePropertyChanged("IsSaveButtonEnabled");
				RaisePropertyChanged("SelectAddressText");
				RaisePropertyChanged("DeliveryTypesBlockVisible");
				RaisePropertyChanged("IsLocationDetecting");
			}
		}
	}

	public string SelectAddressText
	{
		get
		{
			object obj;
			if (!IsLocationDetecting)
			{
				obj = DeliveryTo?.Address?.AddressLine;
				if (obj == null)
				{
					return "";
				}
			}
			else
			{
				obj = "Определяем адрес...";
			}
			return (string)obj;
		}
	}

	public bool IsAddressValidationError
	{
		[CompilerGenerated]
		get
		{
			return _003CIsAddressValidationError_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsAddressValidationError_003Ek__BackingField != value)
			{
				_003CIsAddressValidationError_003Ek__BackingField = value;
				RaisePropertyChanged("IsSaveButtonEnabled");
				RaisePropertyChanged("IsAddressValidationError");
			}
		}
	}

	public string AddressValidationErrorText
	{
		[CompilerGenerated]
		get
		{
			return _003CAddressValidationErrorText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CAddressValidationErrorText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CAddressValidationErrorText_003Ek__BackingField = value;
				RaisePropertyChanged("AddressValidationErrorText");
			}
		}
	} = "";

	public string StreetHouseText => "Город, улица, дом";

	public string DeliveryTypeExpressTitle => "Быстро";

	public string DeliveryTypeExpressSubtitle => AvailableDeliveryMethods?.ExpressDelivery?.DeliveryStartText ?? AvailableDeliveryMethods?.ExpressDeliveryUnavailableInfo?.UnavailableHint ?? string.Empty;

	public string DeliveryTypeStandardTitle => "Доставка";

	public string DeliveryTypeStandardSubtitle => AvailableDeliveryMethods?.StandardDelivery?.DeliveryStartText ?? string.Empty;

	public string ExpressDeliveryIsAvailableText => "Хорошая новость!\nВам доступна быстрая доставка";

	public DeliveryMethodsForAddress? AvailableDeliveryMethods
	{
		[CompilerGenerated]
		get
		{
			return _003CAvailableDeliveryMethods_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!(_003CAvailableDeliveryMethods_003Ek__BackingField == value))
			{
				_003CAvailableDeliveryMethods_003Ek__BackingField = value;
				RaisePropertyChanged("IsSaveButtonEnabled");
				RaisePropertyChanged("DeliveryTypeExpressSubtitle");
				RaisePropertyChanged("DeliveryTypeStandardSubtitle");
				RaisePropertyChanged("StandardDeliveryVisible");
				RaisePropertyChanged("DeliveryTypesBlockVisible");
				RaisePropertyChanged("ExpressDeliveryAvailable");
				RaisePropertyChanged("ExpressDeliveryVisible");
				RaisePropertyChanged("ExpressDeliveryCostMin");
				RaisePropertyChanged("DeliveryMinCost");
				RaisePropertyChanged("ExpressDeliveryCostFree");
				RaisePropertyChanged("FreeDeliveryMinCost");
				RaisePropertyChanged("FreeDeliveryMinCostText");
				RaisePropertyChanged("IsFreeDeliveryMinCostVisible");
				RaisePropertyChanged("StandardDeliveryCostMin");
				RaisePropertyChanged("StandardDeliveryCostFree");
				OnAvailableDeliveryMethodsChanged();
				RaisePropertyChanged("AvailableDeliveryMethods");
			}
		}
	}

	public SavedReceiveMethods? SavedReceiveMethods
	{
		[CompilerGenerated]
		get
		{
			return _003CSavedReceiveMethods_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!(_003CSavedReceiveMethods_003Ek__BackingField == value))
			{
				_003CSavedReceiveMethods_003Ek__BackingField = value;
				RaisePropertyChanged("SavedReceiveMethods");
			}
		}
	}

	public bool StandardDeliveryVisible => AvailableDeliveryMethods?.StandardDelivery != null;

	public bool ExpressDeliveryAvailable => AvailableDeliveryMethods?.ExpressDelivery != null;

	public bool ExpressDeliveryVisible
	{
		get
		{
			if (!(AvailableDeliveryMethods?.ExpressDelivery != null))
			{
				return AvailableDeliveryMethods?.ExpressDeliveryUnavailableInfo != null;
			}
			return true;
		}
	}

	public UICommand<BrokerToken> OpenAddressSuggestorCommand { get; } = new UICommand<BrokerToken>();

	public bool DeliveryTypesBlockVisible
	{
		get
		{
			if (ExpressDeliveryVisible || StandardDeliveryVisible)
			{
				return !string.IsNullOrEmpty(SelectAddressText);
			}
			return false;
		}
	}

	public string DeliveryShortInfo
	{
		get
		{
			if (!IsExpressDeliverySelected)
			{
				return "Широкий ассортимент";
			}
			return "Есть всё необходимое";
		}
	}

	public string DeliveryMinCost => $"Привезём заказ от {(IsExpressDeliverySelected ? ExpressDeliveryCostMin : StandardDeliveryCostMin):C0}";

	public string FreeDeliveryMinCostText => $"Доставим бесплатно от {FreeDeliveryMinCost:C0}";

	public decimal? FreeDeliveryMinCost
	{
		get
		{
			if (!IsExpressDeliverySelected)
			{
				return StandardDeliveryCostFree;
			}
			return ExpressDeliveryCostFree;
		}
	}

	public bool IsFreeDeliveryMinCostVisible => FreeDeliveryMinCost.HasValue;

	public bool IsExpressDeliverySelected
	{
		[CompilerGenerated]
		get
		{
			return _003CIsExpressDeliverySelected_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsExpressDeliverySelected_003Ek__BackingField != value)
			{
				_003CIsExpressDeliverySelected_003Ek__BackingField = value;
				RaisePropertyChanged("IsSaveButtonEnabled");
				RaisePropertyChanged("DeliveryShortInfo");
				RaisePropertyChanged("DeliveryMinCost");
				RaisePropertyChanged("FreeDeliveryMinCost");
				RaisePropertyChanged("FreeDeliveryMinCostText");
				RaisePropertyChanged("IsFreeDeliveryMinCostVisible");
				RaisePropertyChanged("IsExpressDeliverySelected");
			}
		}
	}

	private decimal ExpressDeliveryCostMin => (AvailableDeliveryMethods?.ExpressDelivery?.CostMin).GetValueOrDefault();

	private decimal? ExpressDeliveryCostFree => AvailableDeliveryMethods?.ExpressDelivery?.CostFreeFrom;

	private decimal StandardDeliveryCostMin => (AvailableDeliveryMethods?.StandardDelivery?.CostMin).GetValueOrDefault();

	private decimal? StandardDeliveryCostFree => AvailableDeliveryMethods?.StandardDelivery?.CostFreeFrom;

	public UICommand ShowExpressDeliveryPopup { get; } = new UICommand();

	public City? SelectedCity
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedCity_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CSelectedCity_003Ek__BackingField, value))
			{
				_003CSelectedCity_003Ek__BackingField = value;
				RaisePropertyChanged("CurrentRegionName");
				RaisePropertyChanged("AllStoresOfSelectedCity");
				RaisePropertyChanged("IsDeliveryAvailable");
				RaisePropertyChanged("UnavailableInfoVisible");
				RaisePropertyChanged("IsPickupAvailable");
				RaisePropertyChanged("IsCarPickupAvailable");
				UpdateStores();
				RaisePropertyChanged("SelectedCity");
			}
		}
	}

	public IEnumerable<City> AllCities => CityStoreGroups?.Select((IGrouping<City, Store> g) => g.Key) ?? Enumerable.Empty<City>();

	private IEnumerable<Store> AllStoresOfSelectedCity
	{
		get
		{
			IEnumerable<Store> enumerable = CityStoreGroups?.FirstOrDefault((IGrouping<City, Store> g) => g.Key.FiasId == SelectedCity?.FiasId);
			return enumerable ?? Enumerable.Empty<Store>();
		}
	}

	public ObservableRangeCollection<SelectionItemViewModel<Store>> PickupStoresOfSelectedCity { get; } = new ObservableRangeCollection<SelectionItemViewModel<Store>>();

	public ObservableRangeCollection<SelectionItemViewModel<Store>> CarPickupStoresOfSelectedCity { get; } = new ObservableRangeCollection<SelectionItemViewModel<Store>>();

	public Store? SelectedPickupStore
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedPickupStore_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CSelectedPickupStore_003Ek__BackingField = value;
			RaisePropertyChanged("IsSaveButtonEnabled");
			RaisePropertyChanged("IsPickupInfoHeaderVisible");
			OnSelectedPickupStoreChanged();
			RaisePropertyChanged("SelectedPickupStore");
		}
	}

	public Store? SelectedCarPickupStore
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedCarPickupStore_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CSelectedCarPickupStore_003Ek__BackingField = value;
			RaisePropertyChanged("IsSaveButtonEnabled");
			OnSelectedCarPickupStoreChanged();
			RaisePropertyChanged("SelectedCarPickupStore");
		}
	}

	public bool IsPickupInfoHeaderVisible => SelectedPickupStore == null;

	private IEnumerable<IGrouping<City, Store>>? CityStoreGroups
	{
		[CompilerGenerated]
		get
		{
			return _003CCityStoreGroups_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CCityStoreGroups_003Ek__BackingField, value))
			{
				_003CCityStoreGroups_003Ek__BackingField = value;
				RaisePropertyChanged("AllCities");
				RaisePropertyChanged("AllStoresOfSelectedCity");
				RaisePropertyChanged("IsDeliveryAvailable");
				RaisePropertyChanged("UnavailableInfoVisible");
				RaisePropertyChanged("IsPickupAvailable");
				RaisePropertyChanged("IsCarPickupAvailable");
				RaisePropertyChanged("CityStoreGroups");
			}
		}
	}

	public string PickupInfoHeader => "Найти пункт самовывоза на карте или\u00a0списком";

	public string PickupInfoDescription => "Укажите магазин, чтобы увидеть актуальную информацию по\u00a0наличию\u00a0товаров";

	public string CarPickupInfoHeader => "Услуга Ашан Авто доступна в\u00a0вашем\u00a0регионе";

	public string CarPickupInfoDescription => "Закажите товары через АШАН Авто. Чтобы забрать заказ достаточно просто заехать на\u00a0парковку, а мы вынесем ваш заказ ";

	public string AllStoresTitle => "Все магазины";

	public UICommand<BrokerToken> OpenPopupChangeCartItemsCommand { get; } = new UICommand<BrokerToken>();

	public UICommand CloseCommand { get; } = new UICommand();

	public UICommand RetryCommand { get; } = new UICommand();

	public UICommand LoadWebViewCommand { get; } = new UICommand();

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
	} = "";

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
	} = "";

	public string UnavailableInfoText => "Услуга “" + GetDeliveryTypeName() + "” недоступна в вашем регионе. Чтобы оформить заказ, выберите другой способ получения ";

	public bool UnavailableInfoVisible => DeliveryState switch
	{
		DeliveryType.Delivery => !IsDeliveryAvailable, 
		DeliveryType.Pickup => !IsPickupAvailable, 
		DeliveryType.CarPickup => !IsCarPickupAvailable, 
		_ => throw new ArgumentOutOfRangeException(), 
	};

	public override bool TabBarVisible => false;

	public AddressMapViewModel(Parameter parameter, YandexMapUrlProvider yandexMapUrlProvider, IEnvironmentManager environmentManager, IEcomContext ecomContext, ITokenService tokenService, ILocationProvider locationProvider, IStoreService storeService, IUserAddressService userAddressService, IDataBroker dataBroker, AddressChanger addressChanger, IInfoMessageService infoMessageService, IAdminContext adminContext, DefaultErrorTranslator errorTranslator, StoreRepository storeRepository, Lazy<ILogService> logService)
	{
		_parameter = parameter;
		_yandexMapUrlProvider = yandexMapUrlProvider;
		_environmentManager = environmentManager;
		_tokenService = tokenService;
		_locationProvider = locationProvider;
		_storeService = storeService;
		_userAddressService = userAddressService;
		_dataBroker = dataBroker;
		_addressChanger = addressChanger;
		_infoMessageService = infoMessageService;
		_errorTranslator = errorTranslator;
		_storeRepository = storeRepository;
		_logService = logService;
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			{ "user-agent", "auchan-mobile-web-view" },
			{ "userAgent", "auchan-mobile-web-view" }
		};
		if (_environmentManager.CurrentEnvironment != Auchan.Common.Networking.Environment.Production && adminContext.AppConfigIsNotNull)
		{
			string basicAuthToken = adminContext.AppConfig.BasicAuthToken;
			if (basicAuthToken != null && basicAuthToken.Length > 0)
			{
				dictionary["Authorization"] = "Basic " + basicAuthToken;
			}
		}
		Headers = dictionary;
		_isFirstTimeAddressSelection = ecomContext.ReceivingMethodNotSelected;
	}

	public void SelectExpressDelivery()
	{
		if (ExpressDeliveryAvailable)
		{
			IsExpressDeliverySelected = true;
		}
	}

	protected override async Task Start()
	{
		await base.Start();
		AppAnalytics.AppMetrica.TrackEvent("addressPopUpView");
		SaveCommand.PerformDebouncingTask(OnSaveCommand).Subscribe().AddTo(base.CloseDisposable);
		RetryCommand.PerformDebouncingTask(OnRetryCommand).Subscribe().AddTo(base.CloseDisposable);
		await InitialSetup(retry: false);
		async Task InitialSetup(bool retry)
		{
			State = VisualState.InProgress;
			await _locationProvider.GetPermissionAsync(askPermission: true);
			if (retry && _mapLoadedCompletionSource.Task.IsCompleted && !_mapLoadedCompletionSource.Task.Result)
			{
				WebViewState = VisualState.InProgress;
				_mapLoadedCompletionSource = new TaskCompletionSource<bool>();
				LoadWebViewCommand.Trigger();
			}
			ReceivingMethod receivingMethod = ((_parameter.ReceivingMethod == ReceivingMethod.RegionDefault) ? ReceivingMethod.Delivery : _parameter.ReceivingMethod);
			if ((await _tokenService.SavedToken80()).TryGetValue(out var value))
			{
				_tokenTcs.TrySetResult(value);
			}
			Task<Result<Location, DomainError>> high = GetLocation(GeolocationAccuracy.High);
			Task<Result<Location, DomainError>> @default = GetLocation(GeolocationAccuracy.Default);
			await Task.WhenAll<Result<Location, DomainError>>(high, @default);
			if (!high.Result.TryGetValue(out Location highLocation))
			{
				highLocation = null;
			}
			if (!@default.Result.TryGetValue(out Location defaultLocation))
			{
				defaultLocation = null;
			}
			UserLocation = null;
			switch (receivingMethod)
			{
			case ReceivingMethod.Delivery:
			case ReceivingMethod.ExpressDelivery:
				UserLocation = highLocation;
				break;
			case ReceivingMethod.RegionDefault:
			case ReceivingMethod.Pickup:
			case ReceivingMethod.CarPickup:
				UserLocation = defaultLocation;
				break;
			default:
				throw new InvalidOperationException("dead code");
			}
			Task<Result<SavedReceiveMethods, DomainError>> srm = UpdateSavedReceiveMethods();
			Task<Result<IEnumerable<IGrouping<City, Store>>, DomainError>> csg = UpdateCityStoreGroups(defaultLocation);
			await Task.WhenAll(srm, csg);
			if (srm.Result.IsFailure || csg.Result.IsFailure)
			{
				_retryAction = () => InitialSetup(retry: true);
				(string, string) tuple = _errorTranslator.Translate(srm.Result.IsFailure ? srm.Result.Error : csg.Result.Error);
				ErrorTitle = tuple.Item1;
				ErrorMessage = tuple.Item2;
				State = VisualState.Error;
			}
			else
			{
				SelectedCity = await FindCityByLocation(defaultLocation);
				await UpdateStoresAsync(forceAtStart: true);
				if (DeliveryTo == null && highLocation != null)
				{
					var (suggestion, validationError) = await GetAddressSuggestionBy(highLocation);
					if (suggestion != null && suggestion?.RegionId == SelectedCity?.EcomId)
					{
						DeliveryTo = suggestion;
						await SetupDeliveryViewAsync(suggestion, validationError);
					}
				}
				switch (receivingMethod)
				{
				case ReceivingMethod.Delivery:
					DeliveryState = DeliveryType.Delivery;
					AppAnalytics.AppMetrica.TrackEvent("deliveryInputView");
					break;
				case ReceivingMethod.ExpressDelivery:
					DeliveryState = DeliveryType.Delivery;
					AppAnalytics.AppMetrica.TrackEvent("deliveryInputView");
					break;
				case ReceivingMethod.RegionDefault:
				case ReceivingMethod.Pickup:
					DeliveryState = DeliveryType.Pickup;
					break;
				case ReceivingMethod.CarPickup:
					DeliveryState = DeliveryType.CarPickup;
					break;
				default:
					throw new InvalidOperationException("dead code");
				}
				RaisePropertyChanged("UnavailableInfoVisible");
				State = VisualState.Default;
				_initialized = true;
				await LoadMapAsync(DeliveryTo?.Address?.Coordinate ?? UserLocation);
			}
		}
	}

	private async Task<City?> FindCityByLocation(Location? defaultLocation)
	{
		if (SavedReceiveMethods?.CurrentDeliveryMethod.HasValue ?? false)
		{
			City city = AllCities.FirstOrDefault((City i) => i.EcomId == SavedReceiveMethods?.CurrentRegionId);
			if (city != null)
			{
				return city;
			}
		}
		if (defaultLocation != null)
		{
			ImmutableList<City> allCities = AllCities.ToImmutableList();
			if ((await Task.Run(() => _storeService.CityByLocation(allCities, defaultLocation))).TryGetValue(out var value) && value != null)
			{
				return value;
			}
		}
		return AllCities.FirstOrDefault((City i) => i.EcomId == SavedReceiveMethods?.CurrentRegionId) ?? AllCities.FirstOrDefault((City i) => i.IsDefault) ?? AllCities.FirstOrDefault();
	}

	private async Task<Result<IEnumerable<IGrouping<City, Store>>, DomainError>> UpdateCityStoreGroups(Location? defaultLocation)
	{
		Result<IEnumerable<IGrouping<City, Store>>, DomainError> result = await Task.Run(() => _storeService.AllCityShops(defaultLocation));
		if (result.TryGetValue(out var value))
		{
			CityStoreGroups = value;
		}
		return result;
	}

	private async Task<Result<SavedReceiveMethods, DomainError>> UpdateSavedReceiveMethods()
	{
		Result<SavedReceiveMethods, DomainError> result = await Task.Run(() => _userAddressService.SavedReceiveMethods());
		if (result.TryGetValue(out var value))
		{
			SavedReceiveMethods = value;
		}
		return result;
	}

	private async Task<Result<Location, DomainError>> GetLocation(GeolocationAccuracy accuracy)
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		return await _locationProvider.GetLocation(askPermission: false, accuracy, TimeSpan.FromSeconds(5L));
	}

	private void OnSelectedPickupStoreChanged()
	{
		OnSelectedPickupStoreChanged(ReceivingMethod.Pickup, SelectedPickupStore, PickupStoresOfSelectedCity, PickupStoresOfSelectedCity);
	}

	private void OnSelectedCarPickupStoreChanged()
	{
		OnSelectedPickupStoreChanged(ReceivingMethod.CarPickup, SelectedCarPickupStore, CarPickupStoresOfSelectedCity, CarPickupStoresOfSelectedCity);
	}

	private void OnSelectedPickupStoreChanged(ReceivingMethod receivingMethod, Store? selectedStore, IReadOnlyList<SelectionItemViewModel<Store>> stores, ObservableRangeCollection<SelectionItemViewModel<Store>> observable)
	{
		foreach (SelectionItemViewModel<Store> store in stores)
		{
			store.Selected = store.Item == selectedStore;
		}
		UpdateWebView(dontShowDeliveryHereText: false, 2);
	}

	public async Task<string> GetMapAddressAsync()
	{
		string baseMapAddress = BaseMapAddress;
		return baseMapAddress + "/map/" + await _tokenTcs.Task;
	}

	private async Task LoadMapAsync(Coordinate? coordinate)
	{
		YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
		_ = awaiter.IsCompleted;
		await awaiter;
		YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
		awaiter = yieldAwaiter;
		awaiter.GetResult();
		if (await _mapLoadedCompletionSource.Task)
		{
			InstallEventListener();
			ReceivingMethod selectedReceivingMethod = GetSelectedReceivingMethod();
			Store selectedStore = GetSelectedStore();
			if (!selectedReceivingMethod.IsDelivery())
			{
				coordinate = UserLocation;
			}
			await SendMessageToWebViewAsync(selectedReceivingMethod, coordinate, selectedStore, dontShowDeliveryHereText: true, GetFocusExcludingGeo());
			WebViewState = VisualState.Default;
		}
		else
		{
			WebViewState = VisualState.Error;
		}
		_logService.Value.LogInfo("map loading", $"map loaded with {WebViewState} status", LogType.ApiRequest, SystemType.MapFrontend);
	}

	public override void Dispose()
	{
		_disposed = true;
		base.Dispose();
		_mapLoadedCompletionSource.TrySetResult(result: false);
	}

	public void OnReceiveMessage(string message)
	{
		YandexMapMessageDTO yandexMapMessageDTO = JsonSerializer.Deserialize(message, EcomSerializationContext.Default.YandexMapMessageDTO);
		if (!(yandexMapMessageDTO != null) || IsEcho(yandexMapMessageDTO))
		{
			return;
		}
		if (yandexMapMessageDTO.FiasId != null && yandexMapMessageDTO.MerchantId.HasValue && yandexMapMessageDTO.ReceivingMethod.HasValue)
		{
			ReceivingMethod value = yandexMapMessageDTO.ReceivingMethod.Value;
			if (!value.IsDelivery())
			{
				OnPickupMessageReceived(yandexMapMessageDTO.FiasId, yandexMapMessageDTO.MerchantId.Value, value);
			}
		}
		else if (!string.IsNullOrEmpty(yandexMapMessageDTO.Latitude) && !string.IsNullOrEmpty(yandexMapMessageDTO.Longitude))
		{
			Coordinate coordinate = Coordinate.Parse(yandexMapMessageDTO.Latitude, yandexMapMessageDTO.Longitude);
			OnDeliveryMessageReceived(coordinate).SafeFireAndForget((Action<Exception>)null, false);
		}
		bool IsEcho(YandexMapMessageDTO item)
		{
			lock (_messagesSentToWebView)
			{
				int num = _messagesSentToWebView.IndexOf(item);
				if (num >= 0)
				{
					_messagesSentToWebView.RemoveAt(num);
					return true;
				}
			}
			return false;
		}
	}

	private async Task OnDeliveryMessageReceived(Coordinate? coordinate)
	{
		IsLocationDetecting = true;
		IsAddressValidationError = false;
		var (sr, ve) = await GetAddressSuggestionBy(coordinate);
		await SetSelectedCityBySuggestion(sr);
		await SetupDeliveryViewAsync(sr, ve);
		DeliveryLocation = coordinate;
		IsLocationDetecting = false;
		DeliveryTo = sr;
		AppAnalytics.AppMetrica.TrackEvent("tapClickToDeliver");
	}

	private async Task SetSelectedCityBySuggestion(Suggestion? suggestion)
	{
		if (_initialized && !UpdatingStores && suggestion != null && suggestion.RegionId != SelectedCity?.EcomId)
		{
			SelectedCity = AllCities.FirstOrDefault((City i) => i.EcomId == suggestion.RegionId) ?? SelectedCity;
			await WaitWhileUpdatingStoresAsync();
		}
	}

	private async Task SetupDeliveryViewAsync(Suggestion? suggestion, string validationError)
	{
		if (suggestion?.Address == null)
		{
			SetupDeliveryViewError(validationError);
			return;
		}
		AvailableDeliveryMethods = null;
		Result<DeliveryMethodsForAddress, DomainError> result = await GetDeliveryMethodsAsync(suggestion);
		DomainError error;
		if (result.TryGetValue(out var result2))
		{
			if (_initialized && !UpdatingStores)
			{
				City city = AllCities.FirstOrDefault((City i) => i.EcomId == result2.Region?.EcomId);
				if (city != null)
				{
					SelectedCity = city;
					await WaitWhileUpdatingStoresAsync();
				}
			}
			SetupDeliveryView(result2, validationError);
		}
		else if (result.TryGetError(out error))
		{
			SetupDeliveryViewError(error);
		}
	}

	private async Task<Result<DeliveryMethodsForAddress, DomainError>> GetDeliveryMethodsAsync(Suggestion suggestion)
	{
		IEnumerable<IGrouping<City, Store>> allCityStores = CityStoreGroups ?? throw new InvalidOperationException("CityStoreGroups is not set");
		if (suggestion.Address?.Coordinate == null)
		{
			return new UnknownError();
		}
		return await _storeService.DeliveryMethodsForAddressAsync(suggestion.Address.Coordinate, allCityStores);
	}

	private void OnPickupMessageReceived(string fiasId, int merchantId, ReceivingMethod receiveMethod)
	{
		Store store = AllStoresOfSelectedCity.Where((Store s) => s.Id == merchantId).FirstOrDefault();
		if (store != null)
		{
			switch (receiveMethod)
			{
			case ReceivingMethod.Pickup:
				SelectedPickupStore = store;
				break;
			case ReceivingMethod.CarPickup:
				SelectedCarPickupStore = store;
				break;
			}
		}
	}

	public void OnMapPageLoaded()
	{
		_mapLoadedCompletionSource.TrySetResult(result: true);
	}

	public void OnMapPageError(string resource, int code)
	{
		_logService.Value.LogError("map loading", $"got code {code} from [{resource}]", LogType.ApiRequest, SystemType.MapFrontend);
		_mapLoadedCompletionSource.TrySetResult(result: false);
	}

	private void InstallEventListener()
	{
		if (!_isEventListenerInstalled)
		{
			_isEventListenerInstalled = true;
			AddEventListenerCommand.Trigger();
		}
	}

	private async Task SendMessageToWebViewAsync(ReceivingMethod receivingMethod, Coordinate? coordinate, Store? store, bool dontShowDeliveryHereText, int? focus = null)
	{
		if (!_initialized || UpdatingStores)
		{
			return;
		}
		int rid = Interlocked.Increment(ref _sendMessageToWebViewRequestId);
		await Task.Delay(500);
		if (rid == _sendMessageToWebViewRequestId)
		{
			YandexMapMessageDTO dto = new YandexMapMessageDTO
			{
				FiasId = SelectedCity?.FiasId,
				ReceivingMethod = receivingMethod,
				MerchantId = store?.Id,
				EchoMark = Guid.NewGuid().ToString(),
				DontShowDeliveryHereText = dontShowDeliveryHereText
			};
			dto.Focus = focus;
			if (coordinate != null)
			{
				dto.Latitude = coordinate.Lat.ToString("G", CultureInfo.InvariantCulture);
				dto.Longitude = coordinate.Lon.ToString("G", CultureInfo.InvariantCulture);
			}
			string text = JsonSerializer.Serialize(dto, EcomSerializationContext.Default.YandexMapMessageDTO);
			string text2 = text;
			string text3 = await GetMapAddressAsync();
			string subject = "window.postMessage(" + text2 + ", '" + text3 + "');";
			lock (_messagesSentToWebView)
			{
				_messagesSentToWebView.Add(dto);
			}
			EvaluateJavascript.Trigger(subject);
		}
	}

	private void UpdateWebView(bool dontShowDeliveryHereText = false, int? focus = null, bool withoutCoordinate = false)
	{
		if (_initialized)
		{
			switch (DeliveryState)
			{
			case DeliveryType.Delivery:
				SendMessageToWebViewAsync(GetSelectedReceivingMethod(), withoutCoordinate ? null : (DeliveryTo?.Address?.Coordinate ?? DeliveryLocation ?? UserLocation), null, dontShowDeliveryHereText, focus).SafeFireAndForget((Action<Exception>)null, false);
				break;
			case DeliveryType.Pickup:
			case DeliveryType.CarPickup:
				SendMessageToWebViewAsync(GetSelectedReceivingMethod(), UserLocation, GetSelectedStore(), dontShowDeliveryHereText, focus).SafeFireAndForget((Action<Exception>)null, false);
				break;
			}
		}
	}

	private void OnDeliveryStateChanged()
	{
		UpdateWebView(dontShowDeliveryHereText: false, GetFocusExcludingGeo());
		ShowExpressDeliveryPopupIfNeeded();
	}

	private void OnAvailableDeliveryMethodsChanged()
	{
		ShowExpressDeliveryPopupIfNeeded();
	}

	private void ShowExpressDeliveryPopupIfNeeded()
	{
		if (DeliveryState != DeliveryType.Delivery || !ExpressDeliveryAvailable || _storeRepository.IsExpressDeliveryInformerShown)
		{
			_showExpressDeliveryPopupWhenReady = false;
			return;
		}
		if (State != VisualState.Default)
		{
			_showExpressDeliveryPopupWhenReady = true;
			return;
		}
		if (!_storeRepository.TryMarkExpressDeliveryInformerShown())
		{
			_showExpressDeliveryPopupWhenReady = false;
			return;
		}
		_showExpressDeliveryPopupWhenReady = false;
		ShowExpressDeliveryPopup.Trigger();
	}

	private async Task OnSaveCommand(Unit unit)
	{
		AppAnalytics.AppMetrica.TrackEvent("tapSaveAddress");
		if (!IsSaveButtonEnabled || SelectedCity == null)
		{
			return;
		}
		State = VisualState.InProgress;
		Store store = GetSelectedStore();
		if (store == null)
		{
			State = VisualState.Default;
			return;
		}
		ReceivingMethod receivingMethod = GetSelectedReceivingMethodWithExpress();
		Result<bool> result = await _addressChanger.Simulate(store, receivingMethod);
		if (result.TryGetError(out var error))
		{
			State = VisualState.Default;
			_infoMessageService.ShowSnackbar(error);
			return;
		}
		if (result.TryGetValue(out var value) && value)
		{
			ChangeCartItemsPopupViewModel.Parameter parameter = new ChangeCartItemsPopupViewModel.Parameter();
			OpenPopupChangeCartItemsCommand.Trigger(_dataBroker.Push(parameter));
			if (!(await parameter.TaskCompletionSource.Task))
			{
				State = VisualState.Default;
				return;
			}
		}
		DeliveryAddress lastSelectedAddressModel = DeliveryTo?.Address;
		if (_selectedSavedAddress != null)
		{
			SavedReceiveMethods? savedReceiveMethods = SavedReceiveMethods;
			if ((object)savedReceiveMethods == null || !savedReceiveMethods.Addresses.Any((SavedAddress i) => i == _selectedSavedAddress))
			{
				_selectedSavedAddress = null;
			}
		}
		Result<SavedAddress, DomainError> result2 = await _addressChanger.Change(store, receivingMethod, _isFirstTimeAddressSelection, _parameter.ProductOffer, _selectedSavedAddress, lastSelectedAddressModel);
		State = VisualState.Default;
		if (result2.IsFailure)
		{
			_infoMessageService.ShowSnackbar("Не удалось сохранить адрес, попробуйте еще раз");
		}
		else if (DeliveryState != DeliveryType.Delivery)
		{
			CloseCommand.Trigger();
		}
		else if (result2.Value != null)
		{
			AddressDetailsViewModel.Parameter parameter2 = new AddressDetailsViewModel.Parameter
			{
				Address = result2.Value,
				IsNew = true
			};
			OpenAddressDetailsCommand.Trigger(_dataBroker.Push(parameter2));
			if (await parameter2.WaitForResultAsync())
			{
				CloseCommand.Trigger();
			}
		}
		else
		{
			_infoMessageService.ShowSnackbar("Не удалось сохранить адрес, попробуйте еще раз");
		}
	}

	private IReadOnlyList<SelectionItemViewModel<Store>> GetStoresByReceivingMethod(ReceivingMethod receivingMethod)
	{
		return (from i in AllStoresOfSelectedCity.Where(StoreHasSelectedReceivingMethod)
			select new SelectionItemViewModel<Store>(i, selected: false)).ToImmutableList();
		bool StoreHasSelectedReceivingMethod(Store store)
		{
			return receivingMethod switch
			{
				ReceivingMethod.ExpressDelivery => store.HasExpressDelivery, 
				ReceivingMethod.Delivery => store.HasDelivery, 
				ReceivingMethod.Pickup => store.HasStorePickUp, 
				ReceivingMethod.CarPickup => store.HasCarPickup, 
				_ => throw new NotImplementedException(), 
			};
		}
	}

	private void SetupDeliveryView(DeliveryMethodsForAddress deliveryMethods, string validationError)
	{
		AvailableDeliveryMethods = deliveryMethods;
		IsExpressDeliverySelected = GetDefaultExpressDeliveryState(deliveryMethods);
		AddressValidationErrorText = (AvailableDeliveryMethods.IsDeliveryAvailable ? validationError : "По указанному адресу доставка недоступна");
		IsAddressValidationError = !string.IsNullOrEmpty(AddressValidationErrorText);
	}

	private bool GetDefaultExpressDeliveryState(DeliveryMethodsForAddress deliveryMethods)
	{
		if (deliveryMethods.ExpressDelivery == null)
		{
			return false;
		}
		DeliveryMethodsForAddress.Delivery? expressDelivery = deliveryMethods.ExpressDelivery;
		if ((object)expressDelivery != null && expressDelivery.IsDefault)
		{
			return true;
		}
		DeliveryMethodsForAddress.Delivery? standardDelivery = deliveryMethods.StandardDelivery;
		if ((object)standardDelivery != null && standardDelivery.IsDefault)
		{
			return false;
		}
		if (_initialized)
		{
			return !StandardDeliveryVisible;
		}
		if (_parameter.ReceivingMethod != ReceivingMethod.ExpressDelivery || !ExpressDeliveryAvailable)
		{
			return !StandardDeliveryVisible;
		}
		return true;
	}

	public int? GetIndexOfStore(ObservableRangeCollection<SelectionItemViewModel<Store>> stores, Store? store)
	{
		int num = stores.Select((SelectionItemViewModel<Store> x) => x.Item).IndexOf<Store>(store);
		if (num < 0)
		{
			return null;
		}
		if (store != null)
		{
			return num;
		}
		return null;
	}

	public void SetupDeliveryViewError(string error)
	{
		IsAddressValidationError = true;
		AvailableDeliveryMethods = null;
		DeliveryTo = null;
		AddressValidationErrorText = error;
	}

	private void SetupDeliveryViewError(DomainError domainError)
	{
		IsAddressValidationError = true;
		AvailableDeliveryMethods = null;
		AddressValidationErrorText = "По указанному адресу доставка недоступна";
	}

	public void OpenAddressSuggestor()
	{
		OpenAddressSuggestorAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task OpenAddressSuggestorAsync()
	{
		City selectedCity = SelectedCity;
		if (selectedCity != null)
		{
			AddressSuggestionViewModel.Parameter parameter = new AddressSuggestionViewModel.Parameter
			{
				OldAddress = SelectAddressText,
				SelectedRegion = selectedCity
			};
			BrokerToken subject = _dataBroker.Push(parameter);
			OpenAddressSuggestorCommand.Trigger(subject);
			Suggestion suggestion = await parameter.WaitForResultAsync();
			if (suggestion != null)
			{
				(Suggestion, string) tuple = await GetAdditionalSuggestion(suggestion);
				Suggestion s = tuple.Item1;
				string ve = tuple.Item2;
				DeliveryTo = s;
				await SetSelectedCityBySuggestion(s);
				await SetupDeliveryViewAsync(s, ve);
				UpdateWebView(dontShowDeliveryHereText: true);
			}
		}
		async Task<(Suggestion? Suggestion, string ValidationError)> GetAdditionalSuggestion(Suggestion suggestion2)
		{
			DeliveryAddress a = suggestion2.Address;
			if (a != null)
			{
				return ProcessSuggestionResult(await Task.Run(() => _userAddressService.SuggestGeocode(a)));
			}
			return (Suggestion: null, ValidationError: "Адрес не найден. Попробуйте указать нужный адрес на карте");
		}
	}

	public void OpenRegionSelector()
	{
		OpenRegionSelectorAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task OpenRegionSelectorAsync()
	{
		if (AllCities.Any())
		{
			RegionSelectorViewModel.Parameter parameter = new RegionSelectorViewModel.Parameter
			{
				Regions = AllCities,
				Preselected = (SelectedCity ?? AllCities.First())
			};
			SelectRegionCommand.Trigger(_dataBroker.Push(parameter));
			City result = await parameter.WaitForResultAsync();
			if (result != null)
			{
				DeliveryTo = null;
				IsAddressValidationError = false;
				State = VisualState.InProgress;
				await UpdateSavedReceiveMethods();
				State = VisualState.Default;
				SelectedCity = result;
				await WaitWhileUpdatingStoresAsync();
				UpdateWebView(DeliveryState == DeliveryType.Delivery && DeliveryTo != null, GetFocusExcludingGeo(), DeliveryState == DeliveryType.Delivery);
			}
		}
	}

	private int? GetFocusExcludingGeo()
	{
		if (DeliveryState != DeliveryType.Delivery)
		{
			return (GetSelectedStore() != null) ? 2 : 0;
		}
		return null;
	}

	private bool GetSaveButtonState()
	{
		switch (DeliveryState)
		{
		case DeliveryType.Delivery:
			if (DeliveryTo != null)
			{
				DeliveryMethodsForAddress? availableDeliveryMethods = AvailableDeliveryMethods;
				if ((object)availableDeliveryMethods != null && availableDeliveryMethods.IsDeliveryAvailable && GetSelectedStore() != null)
				{
					return !IsAddressValidationError;
				}
			}
			return false;
		case DeliveryType.Pickup:
			return SelectedPickupStore != null;
		case DeliveryType.CarPickup:
			return SelectedCarPickupStore != null;
		default:
			throw new InvalidOperationException("dead code");
		}
	}

	private ReceivingMethod GetSelectedReceivingMethod()
	{
		return DeliveryState switch
		{
			DeliveryType.Delivery => ReceivingMethod.Delivery, 
			DeliveryType.Pickup => ReceivingMethod.Pickup, 
			DeliveryType.CarPickup => ReceivingMethod.CarPickup, 
			_ => throw new InvalidOperationException("dead code"), 
		};
	}

	private ReceivingMethod GetSelectedReceivingMethodWithExpress()
	{
		switch (DeliveryState)
		{
		case DeliveryType.Delivery:
			if (!IsExpressDeliverySelected)
			{
				return ReceivingMethod.Delivery;
			}
			return ReceivingMethod.ExpressDelivery;
		case DeliveryType.Pickup:
			return ReceivingMethod.Pickup;
		case DeliveryType.CarPickup:
			return ReceivingMethod.CarPickup;
		default:
			throw new InvalidOperationException("dead code");
		}
	}

	private Store? GetSelectedStore()
	{
		switch (DeliveryState)
		{
		case DeliveryType.Delivery:
			if (!IsExpressDeliverySelected)
			{
				return AvailableDeliveryMethods?.StandardDelivery?.Store;
			}
			return AvailableDeliveryMethods?.ExpressDelivery?.Store;
		case DeliveryType.Pickup:
			return SelectedPickupStore;
		case DeliveryType.CarPickup:
			return SelectedCarPickupStore;
		default:
			return null;
		}
	}

	private async Task<(Suggestion? Suggestion, string ValidationError)> GetAddressSuggestionBy(SavedAddress? savedAddress)
	{
		if (savedAddress == null)
		{
			return (Suggestion: null, ValidationError: "");
		}
		return ProcessSuggestionResult(await Task.Run(() => _userAddressService.SuggestGeocode(savedAddress)));
	}

	private async Task<(Suggestion? Suggestion, string ValidationError)> GetAddressSuggestionBy(Coordinate? location)
	{
		if (location == null)
		{
			return (Suggestion: null, ValidationError: "");
		}
		return ProcessSuggestionResult(await Task.Run(() => _userAddressService.SuggestGeocode(location)));
	}

	private (Suggestion? Suggestion, string ValidationError) ProcessSuggestionResult(Result<SuggestionResult, DomainError> suggestionResult)
	{
		Suggestion suggestion = null;
		string item = "Произошла ошибка. Пожалуйста, повторите попытку позже";
		if (suggestionResult.TryGetValue(out SuggestionResult value))
		{
			suggestion = value.Suggestions.FirstOrDefault((Suggestion i) => i.Address != null);
			item = value.GetValidationError() ?? suggestion.GetValidationError() ?? "";
		}
		return (Suggestion: suggestion, ValidationError: item);
	}

	private void UpdateStores()
	{
		UpdateStoresAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task UpdateStoresAsync(bool forceAtStart = false)
	{
		if ((!forceAtStart && (!_initialized || SelectedCity == null || CityStoreGroups == null)) || _disposed)
		{
			return;
		}
		using (await _updateStoresLock.LockAsync(default(CancellationToken)))
		{
			UpdatingStores = true;
			ReceivingMethod receivingMethod = _parameter.ReceivingMethod;
			if (receivingMethod != ReceivingMethod.Delivery && receivingMethod != ReceivingMethod.ExpressDelivery)
			{
				IReadOnlyList<SelectionItemViewModel<Store>> storesByReceivingMethod = GetStoresByReceivingMethod(ReceivingMethod.Pickup);
				PickupStoresOfSelectedCity.ReplaceRange(storesByReceivingMethod);
				IReadOnlyList<SelectionItemViewModel<Store>> storesByReceivingMethod2 = GetStoresByReceivingMethod(ReceivingMethod.CarPickup);
				CarPickupStoresOfSelectedCity.ReplaceRange(storesByReceivingMethod2);
				IEnumerable<Store> source = from store in PickupStoresOfSelectedCity
					where store.Item.Id == SavedReceiveMethods?.CurrentPickupShop?.MerchantId
					select store.Item;
				IEnumerable<Store> source2 = from store in CarPickupStoresOfSelectedCity
					where store.Item.Id == SavedReceiveMethods?.CurrentCarPickupShop?.MerchantId
					select store.Item;
				IEnumerable<Store> source3 = from store in PickupStoresOfSelectedCity
					join saved in SavedReceiveMethods?.PickupShops ?? new List<SavedStore>() on store.Item.Id equals saved.MerchantId
					where saved.IsLastSaved
					select store.Item;
				IEnumerable<Store> source4 = from store in CarPickupStoresOfSelectedCity
					join saved in SavedReceiveMethods?.CarPickupShops ?? new List<SavedStore>() on store.Item.Id equals saved.MerchantId
					where saved.IsLastSaved
					select store.Item;
				SelectedPickupStore = source.FirstOrDefault() ?? source3.FirstOrDefault();
				SelectedCarPickupStore = source2.FirstOrDefault() ?? source4.FirstOrDefault();
			}
			else
			{
				SavedReceiveMethods? savedReceiveMethods = SavedReceiveMethods;
				if ((object)savedReceiveMethods == null || !savedReceiveMethods.CurrentMerchantId.HasValue)
				{
					SavedReceiveMethods? savedReceiveMethods2 = SavedReceiveMethods;
					if ((object)savedReceiveMethods2 == null || !savedReceiveMethods2.CurrentDeliveryMethod.HasValue)
					{
						DeliveryTo = null;
						AvailableDeliveryMethods = null;
						goto IL_0610;
					}
				}
				if (DeliveryTo == null || (DeliveryTo.RegionId.HasValue && DeliveryTo.RegionId != SelectedCity?.EcomId))
				{
					SavedAddress savedAddress = SavedReceiveMethods?.CurrentAddress;
					if (savedAddress?.RegionId != SelectedCity?.EcomId)
					{
						savedAddress = null;
					}
					SavedAddress savedAddress2 = SavedReceiveMethods?.Addresses.FirstOrDefault((SavedAddress i) => i.RegionId == SelectedCity?.EcomId && i.IsLastSaved);
					SavedAddress savedAddress3 = savedAddress ?? savedAddress2;
					var (suggestion, validationError) = await GetAddressSuggestionBy(savedAddress3);
					if (suggestion != null)
					{
						DeliveryTo = suggestion;
						_selectedSavedAddress = savedAddress3;
						await SetupDeliveryViewAsync(suggestion, validationError);
					}
					else
					{
						DeliveryTo = null;
						AvailableDeliveryMethods = null;
					}
				}
			}
			goto IL_0610;
			IL_0610:
			UpdatingStores = false;
		}
	}

	private async Task WaitWhileUpdatingStoresAsync()
	{
		if (_disposed)
		{
			return;
		}
		using (await _updateStoresLock.LockAsync(default(CancellationToken)))
		{
		}
	}

	public async Task Locate()
	{
		if (IsLocationDetecting)
		{
			return;
		}
		IsLocationDetecting = true;
		IsAddressValidationError = false;
		Result<Location, DomainError> result = await GetLocation(GeolocationAccuracy.High);
		DomainError error;
		if (result.TryGetValue(out var value))
		{
			(Suggestion, string) tuple = await GetAddressSuggestionBy(value);
			Suggestion sr = tuple.Item1;
			string ve = tuple.Item2;
			UserLocation = value;
			DeliveryTo = sr;
			await SetSelectedCityBySuggestion(sr);
			await SetupDeliveryViewAsync(sr, ve);
			UpdateWebView(dontShowDeliveryHereText: true, 1);
		}
		else if (result.TryGetError(out error))
		{
			DeliveryTo = null;
			UserLocation = null;
			SetupDeliveryViewError("Не удалось определить местоположение");
			AlertButton alertButton = ((error is NoPermissionError) ? AlertButtons.Settings : ((!(error is ServiceDisabledError)) ? null : new AlertButton
			{
				Action = _locationProvider.OpenSystemLocationSettings,
				Title = "Настройки",
				Type = ActionType.Positive
			}));
			AlertButton alertButton2 = alertButton;
			if (alertButton2 != null)
			{
				await _infoMessageService.ShowAlertAsync("Геолокация отключена", "Включите службу геолокации в настройках, чтобы определить адрес", new AlertButton[2]
				{
					alertButton2,
					AlertButtons.Decline
				});
			}
		}
		IsLocationDetecting = false;
	}

	private void OnDeliveryToChanged()
	{
		_selectedSavedAddress = null;
	}

	public bool ShouldOverrideUrlLoading(string url)
	{
		bool flag = !url.StartsWith(BaseMapAddress) && !url.StartsWith("https://api-maps.yandex.ru");
		if (flag)
		{
			string host = new Uri(url).Host;
			if (host == null)
			{
				goto IL_00e3;
			}
			int length = host.Length;
			if (length <= 21)
			{
				if (length != 16)
				{
					if (length != 19)
					{
						if (length != 21 || !(host == "js-agent.newrelic.com"))
						{
							goto IL_00e3;
						}
					}
					else if (!(host == "cdn.retailrocket.ru"))
					{
						goto IL_00e3;
					}
				}
				else if (!(host == "auchan.digift.ru"))
				{
					goto IL_00e3;
				}
			}
			else if (length != 28)
			{
				if (length != 30)
				{
					if (length != 35)
					{
						goto IL_00e3;
					}
					char c = host[0];
					if (c != 'c')
					{
						if (c != 'g' || !(host == "gmonit-collector.dostavka.auchan.ru"))
						{
							goto IL_00e3;
						}
					}
					else if (!(host == "core-renderer-tiles.maps.yandex.net"))
					{
						goto IL_00e3;
					}
				}
				else if (!(host == "pprod-front.dostavka.auchan.ru"))
				{
					goto IL_00e3;
				}
			}
			else if (!(host == "front-preprod.ecom.auchan.ru"))
			{
				goto IL_00e3;
			}
		}
		goto IL_00f8;
		IL_00e3:
		DoLaunchBrowserAtUrlAsync(url).SafeFireAndForget((Action<Exception>)null, false);
		goto IL_00f8;
		IL_00f8:
		return flag;
		static async Task DoLaunchBrowserAtUrlAsync(string uri)
		{
			YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
			_ = awaiter.IsCompleted;
			await awaiter;
			YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
			awaiter = yieldAwaiter;
			awaiter.GetResult();
			await Browser.OpenAsync(uri);
		}
	}

	private Task OnRetryCommand()
	{
		return _retryAction();
	}

	private static Task DoNothing()
	{
		return Task.CompletedTask;
	}

	private void OnStateChanged()
	{
		if (State == VisualState.Default && _showExpressDeliveryPopupWhenReady)
		{
			ShowExpressDeliveryPopupIfNeeded();
		}
	}

	private string GetDeliveryTypeName()
	{
		return DeliveryState switch
		{
			DeliveryType.Delivery => "Доставка", 
			DeliveryType.Pickup => "Самовывоз", 
			DeliveryType.CarPickup => "АШАН Авто", 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}
}
