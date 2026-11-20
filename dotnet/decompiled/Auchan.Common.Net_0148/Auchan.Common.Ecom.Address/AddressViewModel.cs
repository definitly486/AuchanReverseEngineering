using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Addresses;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Extensions;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Storage;

namespace Auchan.Common.Ecom.Address;

public sealed class AddressViewModel : ScreenViewModel
{
	public enum DeliveryType
	{
		Empty,
		Delivery,
		Pickup,
		CarPickup
	}

	public sealed class Parameter
	{
		public ReceivingMethod ReceivingMethod { get; init; }

		public ProductOffer? ProductOffer { get; init; }
	}

	private const string? SAVED_ADDRESS_INFO_PREFERENCES = "saved_address_info_preferences";

	private readonly IUserAddressService _userAddressService;

	private readonly Parameter _parameter;

	private readonly IStoreService _storeService;

	private readonly AddressChanger _addressChanger;

	private readonly IInfoMessageService _infoMessageService;

	private readonly IDataBroker _dataBroker;

	private readonly IErrorTranslator _errorTranslator;

	private readonly StoreRepository _storeRepository;

	private readonly bool _isFirstTimeAddressSelection;

	private Suggestion? _lastSavedAddress;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private IEnumerable<Store>? _003CAllCityShops_003Ek__BackingField;

	[CompilerGenerated]
	private SavedAddress? _003CSelectedAddress_003Ek__BackingField;

	[CompilerGenerated]
	private SavedStore? _003CSelectedPickupStore_003Ek__BackingField;

	[CompilerGenerated]
	private SavedStore? _003CSelectedCarPickupStore_003Ek__BackingField;

	[CompilerGenerated]
	private DeliveryType _003CLayoutState_003Ek__BackingField;

	[CompilerGenerated]
	private DeliveryType _003CSelectedButtonState_003Ek__BackingField;

	[CompilerGenerated]
	private IEnumerable<IGrouping<City, Store>>? _003CCityStoreGroups_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsExpressDeliverySelected_003Ek__BackingField;

	[CompilerGenerated]
	private DeliveryMethodsForAddress? _003CAvailableDeliveryMethods_003Ek__BackingField;

	[CompilerGenerated]
	private SavedReceiveMethods? _003CSavedReceiveMethods_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CAddressUpdating_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand<AddressMapViewModel.Parameter> _003COpenMapCommand_003Ek__BackingField;

	public string Title => "Список сохранённых адресов";

	public string EmptyText => "Здесь будут храниться ваши " + ((SelectedButtonState == DeliveryType.Delivery) ? "адреса" : "магазины") + ", наличие товаров зависит от выбранного магазина";

	public string SaveButtonText => "Сохранить";

	public string AddButtonText
	{
		get
		{
			if (SelectedButtonState != DeliveryType.Delivery)
			{
				return "Добавить новый магазин";
			}
			return "Добавить новый адрес";
		}
	}

	public bool AddButtonActive => LayoutState == DeliveryType.Empty;

	public bool SaveButtonVisibility => !AddButtonActive;

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
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.Default;

	public IEnumerable<Store>? AllCityShops
	{
		[CompilerGenerated]
		get
		{
			return _003CAllCityShops_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CAllCityShops_003Ek__BackingField, value))
			{
				_003CAllCityShops_003Ek__BackingField = value;
				RaisePropertyChanged("AllCityShops");
			}
		}
	}

	public UICommand CloseCommand { get; } = new UICommand();

	public UICommand<SavedAddress> EditItemCommand { get; } = new UICommand<SavedAddress>();

	public UICommand<BrokerToken> OpenEditableItemCommand { get; } = new UICommand<BrokerToken>();

	public ObservableRangeCollection<SelectionItemViewModel<SavedAddress>> AddressesOfSelectedCity { get; } = new ObservableRangeCollection<SelectionItemViewModel<SavedAddress>>();

	public ObservableRangeCollection<SelectionItemViewModel<SavedStore>> PickupStoresOfSelectedCity { get; } = new ObservableRangeCollection<SelectionItemViewModel<SavedStore>>();

	public ObservableRangeCollection<SelectionItemViewModel<SavedStore>> CarPickupStoresOfSelectedCity { get; } = new ObservableRangeCollection<SelectionItemViewModel<SavedStore>>();

	public SavedAddress? SelectedAddress
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedAddress_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CSelectedAddress_003Ek__BackingField = value;
			RaisePropertyChanged("IsSaveButtonEnabled");
			OnSelectedDeliveryAddressChanged();
			RaisePropertyChanged("SelectedAddress");
		}
	}

	public SavedStore? SelectedPickupStore
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
			OnSelectedPickupStoreChanged();
			RaisePropertyChanged("SelectedPickupStore");
		}
	}

	public SavedStore? SelectedCarPickupStore
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

	public DeliveryType LayoutState
	{
		[CompilerGenerated]
		get
		{
			return _003CLayoutState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CLayoutState_003Ek__BackingField != value)
			{
				_003CLayoutState_003Ek__BackingField = value;
				RaisePropertyChanged("AddButtonActive");
				RaisePropertyChanged("SaveButtonVisibility");
				RaisePropertyChanged("LayoutState");
			}
		}
	}

	public DeliveryType SelectedButtonState
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedButtonState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CSelectedButtonState_003Ek__BackingField != value)
			{
				_003CSelectedButtonState_003Ek__BackingField = value;
				RaisePropertyChanged("EmptyText");
				RaisePropertyChanged("AddButtonText");
				RaisePropertyChanged("IsSaveButtonEnabled");
				RaisePropertyChanged("SelectedButtonState");
			}
		}
	}

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
				RaisePropertyChanged("CityStoreGroups");
			}
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
				RaisePropertyChanged("DeliveryShortInfo");
				RaisePropertyChanged("DeliveryMinCost");
				RaisePropertyChanged("FreeDeliveryMinCost");
				RaisePropertyChanged("FreeDeliveryMinCostText");
				RaisePropertyChanged("IsFreeDeliveryMinCostVisible");
				RaisePropertyChanged("IsSaveButtonEnabled");
				RaisePropertyChanged("IsExpressDeliverySelected");
			}
		}
	}

	private decimal ExpressDeliveryCostMin => (AvailableDeliveryMethods?.ExpressDelivery?.CostMin).GetValueOrDefault();

	private decimal? ExpressDeliveryCostFree => AvailableDeliveryMethods?.ExpressDelivery?.CostFreeFrom;

	private decimal StandardDeliveryCostMin => (AvailableDeliveryMethods?.StandardDelivery?.CostMin).GetValueOrDefault();

	private decimal? StandardDeliveryCostFree => AvailableDeliveryMethods?.StandardDelivery?.CostFreeFrom;

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
				RaisePropertyChanged("ExpressDeliveryCostMin");
				RaisePropertyChanged("DeliveryMinCost");
				RaisePropertyChanged("ExpressDeliveryCostFree");
				RaisePropertyChanged("FreeDeliveryMinCost");
				RaisePropertyChanged("FreeDeliveryMinCostText");
				RaisePropertyChanged("IsFreeDeliveryMinCostVisible");
				RaisePropertyChanged("StandardDeliveryCostMin");
				RaisePropertyChanged("StandardDeliveryCostFree");
				RaisePropertyChanged("DeliveryTypeExpressSubtitle");
				RaisePropertyChanged("DeliveryTypeStandardSubtitle");
				RaisePropertyChanged("StandardDeliveryVisible");
				RaisePropertyChanged("ExpressDeliveryAvailable");
				RaisePropertyChanged("ExpressDeliveryVisible");
				RaisePropertyChanged("IsSaveButtonEnabled");
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

	public UICommand<int> ShowExpressDeliveryPopupCommand { get; } = new UICommand<int>();

	public string AddressValidationErrorText => "По выбранному адресу доставка недоступна";

	public string CarPickupInfoDescription => "Закажите товары через АШАН Авто. Чтобы забрать заказ достаточно просто заехать на\u00a0парковку, а мы вынесем ваш заказ ";

	public bool IsSaveButtonEnabled
	{
		get
		{
			if (State == VisualState.Default && !AddressUpdating)
			{
				if ((SelectedButtonState != DeliveryType.Pickup || !(SelectedPickupStore != null)) && (SelectedButtonState != DeliveryType.CarPickup || !(SelectedCarPickupStore != null)))
				{
					if (SelectedButtonState == DeliveryType.Delivery)
					{
						SavedAddress selectedAddress = SelectedAddress;
						if ((object)selectedAddress != null && selectedAddress.DeliveryAvailable)
						{
							DeliveryMethodsForAddress? availableDeliveryMethods = AvailableDeliveryMethods;
							if ((object)availableDeliveryMethods != null && availableDeliveryMethods.IsDeliveryAvailable)
							{
								if (!IsExpressDeliverySelected)
								{
									return AvailableDeliveryMethods?.StandardDelivery?.Store != null;
								}
								return AvailableDeliveryMethods?.ExpressDelivery?.Store != null;
							}
						}
					}
					return false;
				}
				return true;
			}
			return false;
		}
	}

	public UICommand<BrokerToken> OpenPopupChangeCartItemsCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<SelectionItemViewModel<SavedStore>> RemoveItemCommand { get; } = new UICommand<SelectionItemViewModel<SavedStore>>();

	public string DeliveryText => "Доставка";

	public string PickupText => "Самовывоз";

	public string CarPickupText => "Авто";

	public bool AddressUpdating
	{
		[CompilerGenerated]
		get
		{
			return _003CAddressUpdating_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CAddressUpdating_003Ek__BackingField != value)
			{
				_003CAddressUpdating_003Ek__BackingField = value;
				RaisePropertyChanged("IsSaveButtonEnabled");
				RaisePropertyChanged("AddressUpdating");
			}
		}
	}

	public UICommand<BrokerToken> OpenAskToRemoveAddressPopupCommand { get; } = new UICommand<BrokerToken>();

	public UICommand SaveCommand { get; } = new UICommand();

	public UICommand<AddressMapViewModel.Parameter> OpenMapCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenMapCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003COpenMapCommand_003Ek__BackingField, value))
			{
				_003COpenMapCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenMapCommand");
			}
		}
	} = new UICommand<AddressMapViewModel.Parameter>();

	public override bool TabBarVisible => false;

	public AddressViewModel(IUserAddressService userAddressService, Parameter parameter, IStoreService storeService, AddressChanger addressChanger, IInfoMessageService infoMessageService, IDataBroker dataBroker, IEcomContext ecomContext, DefaultErrorTranslator errorTranslator, StoreRepository storeRepository)
	{
		_userAddressService = userAddressService;
		_parameter = parameter;
		_storeService = storeService;
		_addressChanger = addressChanger;
		_infoMessageService = infoMessageService;
		_dataBroker = dataBroker;
		_errorTranslator = errorTranslator;
		_storeRepository = storeRepository;
		EditItemCommand.PerformDebouncingTask(OnEditItemCommand).Subscribe().AddTo(base.CloseDisposable);
		_isFirstTimeAddressSelection = ecomContext.ReceivingMethodNotSelected;
		RemoveItemCommand.PerformDebouncingTask(RemoveStore).Subscribe().AddTo(base.CloseDisposable);
		SaveCommand.PerformDebouncingTask(OnSaveCommand).Subscribe().AddTo(base.CloseDisposable);
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
		UpdateStores();
	}

	private async Task OnEditItemCommand(SavedAddress address)
	{
		AddressDetailsViewModel.Parameter parameter = new AddressDetailsViewModel.Parameter
		{
			Address = address,
			IsNew = false
		};
		OpenEditableItemCommand.Trigger(_dataBroker.Push(parameter));
		if (await parameter.WaitForResultAsync())
		{
			SelectedAddress = null;
			UpdateStores();
		}
	}

	private void OnSelectedDeliveryAddressChanged()
	{
		foreach (SelectionItemViewModel<SavedAddress> item in AddressesOfSelectedCity)
		{
			item.Selected = item.Item == SelectedAddress;
		}
	}

	private void OnSelectedPickupStoreChanged()
	{
		OnSelectedPickupStoreChanged(SelectedPickupStore, PickupStoresOfSelectedCity);
	}

	private void OnSelectedCarPickupStoreChanged()
	{
		OnSelectedPickupStoreChanged(SelectedCarPickupStore, CarPickupStoresOfSelectedCity);
	}

	private void OnSelectedPickupStoreChanged(SavedStore? selectedStore, IReadOnlyList<SelectionItemViewModel<SavedStore>> stores)
	{
		foreach (SelectionItemViewModel<SavedStore> store in stores)
		{
			store.Selected = store.Item == selectedStore;
		}
	}

	private void UpdateStores()
	{
		UpdateStoresAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task UpdateStoresAsync()
	{
		State = VisualState.InProgress;
		await UpdateSavedReceiveMethods();
		if (SavedReceiveMethods != null)
		{
			IList<SavedStore> pickupShops = SavedReceiveMethods.PickupShops;
			PickupStoresOfSelectedCity.ReplaceRange(pickupShops.Select((SavedStore x) => new SelectionItemViewModel<SavedStore>(x, x.IsLastSaved)));
			IList<SavedStore> carPickupShops = SavedReceiveMethods.CarPickupShops;
			CarPickupStoresOfSelectedCity.ReplaceRange(carPickupShops.Select((SavedStore x) => new SelectionItemViewModel<SavedStore>(x, x.IsLastSaved)));
			IList<SavedAddress> addresses = SavedReceiveMethods.Addresses;
			AddressesOfSelectedCity.ReplaceRange(addresses.Select((SavedAddress i) => new SelectionItemViewModel<SavedAddress>(i, selected: false)));
			await UpdateShops(SavedReceiveMethods.CurrentRegionId);
			SavedAddress currentAddressFromListOrLastSaved = GetCurrentAddressFromListOrLastSaved(addresses);
			if (currentAddressFromListOrLastSaved != null)
			{
				await UpdateSelectedAddress(currentAddressFromListOrLastSaved);
			}
			IEnumerable<SavedStore> source = from store in PickupStoresOfSelectedCity
				where store.Item.MerchantId == SavedReceiveMethods?.CurrentPickupShop?.MerchantId
				select store.Item;
			IEnumerable<SavedStore> source2 = from store in CarPickupStoresOfSelectedCity
				where store.Item.MerchantId == SavedReceiveMethods?.CurrentCarPickupShop?.MerchantId
				select store.Item;
			IEnumerable<SavedStore> source3 = from store in PickupStoresOfSelectedCity
				join saved in SavedReceiveMethods?.PickupShops ?? new List<SavedStore>() on store.Item.MerchantId equals saved.MerchantId
				where saved.IsLastSaved
				select store.Item;
			IEnumerable<SavedStore> source4 = from store in CarPickupStoresOfSelectedCity
				join saved in SavedReceiveMethods?.CarPickupShops ?? new List<SavedStore>() on store.Item.MerchantId equals saved.MerchantId
				where saved.IsLastSaved
				select store.Item;
			SelectedPickupStore = source.FirstOrDefault() ?? source3.FirstOrDefault();
			SelectedCarPickupStore = source2.FirstOrDefault() ?? source4.FirstOrDefault();
		}
		if (LayoutState == DeliveryType.Empty)
		{
			switch (_parameter.ReceivingMethod)
			{
			case ReceivingMethod.RegionDefault:
			case ReceivingMethod.Delivery:
			case ReceivingMethod.ExpressDelivery:
				LayoutState = (AddressesOfSelectedCity.Any() ? DeliveryType.Delivery : DeliveryType.Empty);
				SelectedButtonState = DeliveryType.Delivery;
				break;
			case ReceivingMethod.Pickup:
				LayoutState = (PickupStoresOfSelectedCity.Any() ? DeliveryType.Pickup : DeliveryType.Empty);
				SelectedButtonState = DeliveryType.Pickup;
				break;
			case ReceivingMethod.CarPickup:
				LayoutState = (CarPickupStoresOfSelectedCity.Any() ? DeliveryType.CarPickup : DeliveryType.Empty);
				SelectedButtonState = DeliveryType.CarPickup;
				break;
			default:
				throw new InvalidOperationException("dead code");
			}
		}
		else
		{
			switch (SelectedButtonState)
			{
			case DeliveryType.Delivery:
				LayoutState = (AddressesOfSelectedCity.Any() ? DeliveryType.Delivery : DeliveryType.Empty);
				break;
			case DeliveryType.Pickup:
				LayoutState = (PickupStoresOfSelectedCity.Any() ? DeliveryType.Pickup : DeliveryType.Empty);
				break;
			case DeliveryType.CarPickup:
				LayoutState = (CarPickupStoresOfSelectedCity.Any() ? DeliveryType.CarPickup : DeliveryType.Empty);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		State = VisualState.Default;
	}

	private async Task UpdateShops(int? regionId)
	{
		if ((await _storeService.AllCityShops()).TryGetValue(out var value))
		{
			CityStoreGroups = value;
			AllCityShops = CityStoreGroups.FirstOrDefault((IGrouping<City, Store> x) => x.Key.EcomId == regionId);
		}
	}

	private async Task<bool> UpdateSelectedAddress(SavedAddress address)
	{
		Result<DeliveryMethodsForAddress, DomainError> result = await GetDeliveryMethodsAsync(address);
		if (result.TryGetError(out var error))
		{
			_infoMessageService.ShowSnackbar(error.Message ?? _errorTranslator.Translate(error).description);
			return false;
		}
		DeliveryMethodsForAddress value = result.Value;
		address.DeliveryAvailable = value.IsDeliveryAvailable;
		AvailableDeliveryMethods = value;
		IsExpressDeliverySelected = GetExpressDeliveryState(address, value);
		SelectedAddress = address;
		ShowExpressDeliveryPopupIfNeeded(address);
		return true;
	}

	private async Task<Result<DeliveryMethodsForAddress, DomainError>> GetDeliveryMethodsAsync(SavedAddress address)
	{
		DeliveryMethodsForAddress deliveryMethodsForAddress = PreferencesEx.Get<DeliveryMethodsForAddress>(address.Id.ToString(), "saved_address_info_preferences");
		if (deliveryMethodsForAddress == null)
		{
			Result<DeliveryMethodsForAddress, DomainError> result = await _storeService.DeliveryMethodsForAddressAsync(address.Coordinate, CityStoreGroups);
			if (result.IsSuccess)
			{
				return PreferencesEx.Set(address.Id.ToString(), result.Value, TimeSpan.FromMinutes(1L), "saved_address_info_preferences");
			}
			return result;
		}
		return deliveryMethodsForAddress;
	}

	private SavedAddress? GetCurrentAddressFromListOrLastSaved(IEnumerable<SavedAddress> addresses)
	{
		SavedAddress currentAddress = SavedReceiveMethods?.CurrentAddress;
		if (currentAddress != null)
		{
			SavedAddress savedAddress = addresses.FirstOrDefault((SavedAddress i) => i.Id == currentAddress.Id);
			if (savedAddress != null)
			{
				return savedAddress;
			}
		}
		return addresses.FirstOrDefault((SavedAddress x) => x.IsLastSaved);
	}

	private bool GetExpressDeliveryState(SavedAddress address, DeliveryMethodsForAddress deliveryMethods)
	{
		bool? apiDefaultExpressDeliveryState = GetApiDefaultExpressDeliveryState(deliveryMethods);
		if (apiDefaultExpressDeliveryState.HasValue)
		{
			return apiDefaultExpressDeliveryState.Value;
		}
		if (IsCurrentAddress(address))
		{
			SavedReceiveMethods? savedReceiveMethods = SavedReceiveMethods;
			if ((object)savedReceiveMethods != null && savedReceiveMethods.CurrentDeliveryMethod == ReceivingMethod.ExpressDelivery && deliveryMethods.ExpressDelivery != null)
			{
				return true;
			}
			SavedReceiveMethods? savedReceiveMethods2 = SavedReceiveMethods;
			if ((object)savedReceiveMethods2 != null && savedReceiveMethods2.CurrentDeliveryMethod == ReceivingMethod.Delivery && deliveryMethods.StandardDelivery != null)
			{
				return false;
			}
		}
		if (_parameter.ReceivingMethod == ReceivingMethod.ExpressDelivery && deliveryMethods.ExpressDelivery != null)
		{
			return true;
		}
		if (_parameter.ReceivingMethod == ReceivingMethod.Delivery && deliveryMethods.StandardDelivery != null)
		{
			return false;
		}
		return GetDefaultExpressDeliveryState(deliveryMethods);
	}

	private bool IsCurrentAddress(SavedAddress address)
	{
		SavedAddress savedAddress = SavedReceiveMethods?.CurrentAddress;
		if (savedAddress != null)
		{
			return savedAddress.Id == address.Id;
		}
		if (address.IsLastSaved)
		{
			int? num = SavedReceiveMethods?.CurrentRegionId;
			if (num.HasValue)
			{
				int valueOrDefault = num.GetValueOrDefault();
				return address.RegionId == valueOrDefault;
			}
		}
		return false;
	}

	private static bool GetDefaultExpressDeliveryState(DeliveryMethodsForAddress deliveryMethods)
	{
		bool? apiDefaultExpressDeliveryState = GetApiDefaultExpressDeliveryState(deliveryMethods);
		if (apiDefaultExpressDeliveryState.HasValue)
		{
			return apiDefaultExpressDeliveryState.Value;
		}
		if (deliveryMethods.StandardDelivery == null)
		{
			return deliveryMethods.ExpressDelivery != null;
		}
		return false;
	}

	private static bool? GetApiDefaultExpressDeliveryState(DeliveryMethodsForAddress deliveryMethods)
	{
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
		return null;
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

	public void OnDeliveryStateChanged(DeliveryType deliveryType)
	{
		bool flag = deliveryType switch
		{
			DeliveryType.Delivery => !AddressesOfSelectedCity.Any(), 
			DeliveryType.Pickup => !PickupStoresOfSelectedCity.Any(), 
			DeliveryType.CarPickup => !CarPickupStoresOfSelectedCity.Any(), 
			_ => false, 
		};
		SelectedButtonState = deliveryType;
		LayoutState = ((!flag) ? deliveryType : DeliveryType.Empty);
		if (SelectedAddress != null)
		{
			ShowExpressDeliveryPopupIfNeeded(SelectedAddress);
		}
	}

	public async Task SelectAddress(SavedAddress address)
	{
		if (AddressUpdating || State != VisualState.Default || SelectedAddress == address)
		{
			return;
		}
		AddressUpdating = true;
		try
		{
			Suggestion suggestion = (await GetAddressSuggestionBy(SelectedAddress)).Item1;
			if (await UpdateSelectedAddress(address) && suggestion != null)
			{
				_lastSavedAddress = suggestion;
			}
		}
		finally
		{
			AddressUpdating = false;
		}
	}

	public void OpenMap()
	{
		AddressMapViewModel.Parameter parameter = new AddressMapViewModel.Parameter();
		AddressMapViewModel.Parameter parameter2 = parameter;
		parameter2.ReceivingMethod = SelectedButtonState switch
		{
			DeliveryType.Delivery => ReceivingMethod.Delivery, 
			DeliveryType.Pickup => ReceivingMethod.Pickup, 
			DeliveryType.CarPickup => ReceivingMethod.CarPickup, 
			_ => _parameter.ReceivingMethod, 
		};
		parameter.ProductOffer = _parameter.ProductOffer;
		AddressMapViewModel.Parameter subject = parameter;
		OpenMapCommand.Trigger(subject);
	}

	private async Task OnSaveCommand()
	{
		AppAnalytics.AppMetrica.TrackEvent("tapSaveAddress");
		if (!IsSaveButtonEnabled)
		{
			return;
		}
		State = VisualState.InProgress;
		Store store = await GetSelectedStore();
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
		Result<SavedAddress, DomainError> result2 = await _addressChanger.Change(store, receivingMethod, _isFirstTimeAddressSelection, _parameter.ProductOffer, SelectedAddress, _lastSavedAddress?.Address);
		State = VisualState.Default;
		if (result2.IsFailure)
		{
			_infoMessageService.ShowSnackbar(result2.Error.Message ?? _errorTranslator.Translate(result2.Error).description);
		}
		else
		{
			CloseCommand.Trigger();
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

	private async Task<Store?> GetSelectedStore()
	{
		return SelectedButtonState switch
		{
			DeliveryType.Delivery => (!IsExpressDeliverySelected) ? AvailableDeliveryMethods?.StandardDelivery?.Store : AvailableDeliveryMethods?.ExpressDelivery?.Store, 
			DeliveryType.Pickup => await GetPickupStore(SelectedPickupStore.MerchantId, SelectedPickupStore.RegionId), 
			DeliveryType.CarPickup => await GetPickupStore(SelectedCarPickupStore.MerchantId, SelectedCarPickupStore.RegionId), 
			_ => null, 
		};
	}

	private async Task<Store?> GetPickupStore(int id, int regionId)
	{
		await UpdateShops(regionId);
		return AllCityShops?.First((Store x) => x.Id == id);
	}

	private ReceivingMethod GetSelectedReceivingMethodWithExpress()
	{
		switch (SelectedButtonState)
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

	public async Task RemoveStore(SelectionItemViewModel<SavedStore> model)
	{
		AskToRemoveAddressPopupViewModel.Parameter parameter = new AskToRemoveAddressPopupViewModel.Parameter
		{
			ForStore = true
		};
		OpenAskToRemoveAddressPopupCommand.Trigger(_dataBroker.Push(parameter));
		if (!(await parameter.TaskCompletionSource.Task))
		{
			return;
		}
		if (LayoutState == DeliveryType.Pickup)
		{
			if ((await _userAddressService.RemoveSavedPickupShop(model.Item.Id)).IsSuccess)
			{
				PickupStoresOfSelectedCity.Remove(model);
				if (!PickupStoresOfSelectedCity.Any())
				{
					LayoutState = DeliveryType.Empty;
				}
				if (model.Item == SelectedPickupStore)
				{
					SelectedPickupStore = null;
				}
			}
		}
		else if (LayoutState == DeliveryType.CarPickup && (await _userAddressService.RemoveSavedCarPickupShop(model.Item.Id)).IsSuccess)
		{
			CarPickupStoresOfSelectedCity.Remove(model);
			if (!CarPickupStoresOfSelectedCity.Any())
			{
				LayoutState = DeliveryType.Empty;
			}
			if (model.Item == SelectedCarPickupStore)
			{
				SelectedCarPickupStore = null;
			}
		}
	}

	public bool IsLastStore(int id, bool isCarPickupItem)
	{
		if (!isCarPickupItem)
		{
			return PickupStoresOfSelectedCity.Last().Item.Id == id;
		}
		return CarPickupStoresOfSelectedCity.Last().Item.Id == id;
	}

	public bool IsLastAddress(SelectionItemViewModel<SavedAddress> itemViewModel)
	{
		return AddressesOfSelectedCity.Last() == itemViewModel;
	}

	private void ShowExpressDeliveryPopupIfNeeded(SavedAddress address)
	{
		bool flag = SelectedButtonState == DeliveryType.Empty;
		if (flag)
		{
			ReceivingMethod receivingMethod = _parameter.ReceivingMethod;
			bool flag2 = ((receivingMethod == ReceivingMethod.Delivery || receivingMethod == ReceivingMethod.ExpressDelivery) ? true : false);
			flag = flag2;
		}
		if ((flag || SelectedButtonState == DeliveryType.Delivery) && ExpressDeliveryAvailable && _storeRepository.TryMarkExpressDeliveryInformerShown())
		{
			ShowExpressDeliveryPopupCommand.Trigger(AddressesOfSelectedCity.Select((SelectionItemViewModel<SavedAddress> x) => x.Item).IndexOf(address));
		}
	}

	public override void Dispose()
	{
		Preferences.Clear("saved_address_info_preferences");
		base.Dispose();
	}

	public void ShowSuccessInfo()
	{
		_infoMessageService.ShowSnackbar("Сохранили ваш новый адрес", SnackbarStyle.Success);
	}
}
