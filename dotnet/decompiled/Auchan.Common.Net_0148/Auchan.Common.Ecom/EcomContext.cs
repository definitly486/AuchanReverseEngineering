using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Addresses;
using Auchan.Common.AdminTool;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Extensions;
using Auchan.Common.Home;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Storage;

namespace Auchan.Common.Ecom;

public class EcomContext : IEcomContext, INotifyPropertyChanged
{
	private const string ECOM_CONTEXT_PREFERENCES = "EcomContextPreferences";

	private readonly IUserContext _userContext;

	private readonly Lazy<IHomeScreenTracker> _homeScreenTracker;

	private readonly Lazy<IStoreService> _storeService;

	private readonly Lazy<IUserAddressService> _userAddressService;

	private readonly Lazy<IAdminContext> _adminContext;

	private TaskQueue _syncReceiveMethodQueue = new TaskQueue();

	private readonly TimeSpan _syncReceiveMethodBlockTime = TimeSpan.FromSeconds(10L);

	private readonly object _syncReceiveMethodGate = new object();

	private DateTime _lastSyncReceiveMethodStartedUtc = DateTime.MinValue;

	private int _resumeEpoch;

	private int _lastSyncReceiveMethodResumeEpoch = -1;

	private Store? _activeStore = PreferencesEx.Get<Store>("ActiveStore", "EcomContextPreferences");

	private DeliveryAddress? _deliveryAddress = PreferencesEx.Get<DeliveryAddress>("DeliveryAddress", "EcomContextPreferences");

	private ReceivingMethod? _receivingMethod;

	private AgreeState? _ageGateArgeement;

	private DeliveryAddress? _remoteAddress;

	private TaskCompletionSource<Store> _waitForActiveStoreAsync = new TaskCompletionSource<Store>();

	[CompilerGenerated]
	private Store? _003CSavedStore_003Ek__BackingField;

	public Store ActiveStore
	{
		get
		{
			return _activeStore ?? throw new InvalidOperationException("Not initialized yet");
		}
		private set
		{
			if (!object.Equals(_activeStore, value))
			{
				SetActiveStore(value);
				OnPropertyChanged("Initialized");
				OnPropertyChanged("ActiveStore");
			}
		}
	}

	public Store? SavedStore
	{
		[CompilerGenerated]
		get
		{
			return _003CSavedStore_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CSavedStore_003Ek__BackingField, value))
			{
				_003CSavedStore_003Ek__BackingField = value;
				OnPropertyChanged("SavedStore");
			}
		}
	}

	public DeliveryAddress? DeliveryAddress
	{
		get
		{
			return _deliveryAddress;
		}
		set
		{
			if (!(_deliveryAddress == value))
			{
				_deliveryAddress = PreferencesEx.Set("DeliveryAddress", value, "EcomContextPreferences");
				OnPropertyChanged("ReceivingMethodNotSelected");
				OnDeliveryAddressChanged();
				OnPropertyChanged("DeliveryAddress");
			}
		}
	}

	public ReceivingMethod ReceivingMethod
	{
		get
		{
			ReceivingMethod valueOrDefault = _receivingMethod.GetValueOrDefault();
			if (!_receivingMethod.HasValue)
			{
				valueOrDefault = PreferencesEx.GetEnum("ReceivingMethod", ReceivingMethod.RegionDefault, "EcomContextPreferences");
				_receivingMethod = valueOrDefault;
				return valueOrDefault;
			}
			return valueOrDefault;
		}
		set
		{
			if (ReceivingMethod != value)
			{
				_receivingMethod = PreferencesEx.SetEnum("ReceivingMethod", value, "EcomContextPreferences");
				OnPropertyChanged("ReceivingMethodNotSelected");
				OnPropertyChanged("ReceivingMethod");
			}
		}
	}

	public bool Initialized => _activeStore != null;

	public bool ReceivingMethodNotSelected
	{
		get
		{
			if (DeliveryAddress == null)
			{
				return ReceivingMethod == ReceivingMethod.RegionDefault;
			}
			return false;
		}
	}

	public AgreeState AgeGateAgreement
	{
		get
		{
			AgreeState valueOrDefault = _ageGateArgeement.GetValueOrDefault();
			if (!_ageGateArgeement.HasValue)
			{
				valueOrDefault = PreferencesEx.GetEnum("AgeGateAgreement", AgreeState.None, "EcomContextPreferences");
				_ageGateArgeement = valueOrDefault;
				return valueOrDefault;
			}
			return valueOrDefault;
		}
		set
		{
			if (AgeGateAgreement != value)
			{
				_ageGateArgeement = PreferencesEx.SetEnum("AgeGateAgreement", value, "EcomContextPreferences");
				OnPropertyChanged("AgeGateAgreement");
			}
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	public event Func<Task> AfterAddressSet = () => Task.CompletedTask;

	public EcomContext(IUserContext userContext, Lazy<IHomeScreenTracker> homeScreenTracker, Lazy<IStoreService> storeService, Lazy<IUserAddressService> userAddressService, Lazy<IAdminContext> adminContext)
	{
		_userContext = userContext;
		_homeScreenTracker = homeScreenTracker;
		_storeService = storeService;
		_userAddressService = userAddressService;
		_adminContext = adminContext;
		_userContext.AfterLoggedIn += SetReceiveMethodAddressAndStore;
		_userContext.AfterLoggedOut += CleanDeinitialize;
	}

	public Task<Store> GetActiveStoreAsync()
	{
		if (_activeStore != null)
		{
			return Task.FromResult(_activeStore);
		}
		return _waitForActiveStoreAsync.Task;
	}

	private void SetActiveStore(Store store)
	{
		_activeStore = store;
		_waitForActiveStoreAsync.TrySetResult(store);
		PreferencesEx.Set("ActiveStore", store, "EcomContextPreferences");
	}

	public async Task<Result<Unit, DomainError>> Initialize()
	{
		if (!Initialized)
		{
			Result<Store, DomainError> result = await _storeService.Value.DefaultStore();
			if (result.IsFailure)
			{
				return Result.Failure<Unit, DomainError>(result.Error);
			}
			ActiveStore = result.Value;
		}
		return Result.Success<Unit, DomainError>(Unit.Default);
	}

	public Task CleanDeinitialize()
	{
		DeliveryAddress = null;
		_remoteAddress = null;
		ReceivingMethod = ReceivingMethod.RegionDefault;
		AgeGateAgreement = AgreeState.None;
		_activeStore = null;
		_waitForActiveStoreAsync = new TaskCompletionSource<Store>();
		Preferences.Remove("ActiveStore", "EcomContextPreferences");
		lock (_syncReceiveMethodGate)
		{
			_lastSyncReceiveMethodResumeEpoch = -1;
			_lastSyncReceiveMethodStartedUtc = DateTime.MinValue;
		}
		return Task.CompletedTask;
	}

	public async Task<Result<bool, DomainError>> CanChange(Store store, ReceivingMethod receivingMethod)
	{
		Result<SetShopResponse, DomainError> result = await _storeService.Value.SetCurrentUserStore(store, receivingMethod, true);
		return result.IsSuccess ? Result.Success<bool, DomainError>(result.Value.BasketChanged) : Result.Failure<bool, DomainError>(result.Error);
	}

	public async Task<Result<SetShopResponse, DomainError>> SaveOnServer(Store store, ReceivingMethod receivingMethod)
	{
		Result<SetShopResponse, DomainError> result = await _storeService.Value.SetCurrentUserStore(store, receivingMethod, false);
		if (result.IsSuccess)
		{
			SavedStore = store;
			ActiveStore = store;
			_adminContext.Value.UpdateExtraPromotions();
		}
		return result;
	}

	public void NotifyDeliveryAddressChanged()
	{
		OnPropertyChanged("DeliveryAddress");
	}

	public void NotifyAppResumed()
	{
		lock (_syncReceiveMethodGate)
		{
			_resumeEpoch++;
		}
	}

	public Task SyncReceiveMethodQueued(bool appSessionStarted = false, bool force = false)
	{
		if (!_userContext.Authorized)
		{
			return Task.CompletedTask;
		}
		if (!force && !_homeScreenTracker.Value.Shown && !appSessionStarted)
		{
			return Task.CompletedTask;
		}
		lock (_syncReceiveMethodGate)
		{
			if (!force)
			{
				if ((_resumeEpoch == 0 || _lastSyncReceiveMethodResumeEpoch >= _resumeEpoch) && !appSessionStarted)
				{
					return Task.CompletedTask;
				}
				DateTime utcNow = DateTime.UtcNow;
				if (utcNow - _lastSyncReceiveMethodStartedUtc < _syncReceiveMethodBlockTime)
				{
					return Task.CompletedTask;
				}
				_lastSyncReceiveMethodStartedUtc = utcNow;
				_lastSyncReceiveMethodResumeEpoch = _resumeEpoch;
			}
			else
			{
				_lastSyncReceiveMethodStartedUtc = DateTime.UtcNow;
				if (_resumeEpoch > 0)
				{
					_lastSyncReceiveMethodResumeEpoch = _resumeEpoch;
				}
			}
		}
		return _syncReceiveMethodQueue.Enqueue(() => SyncStores());
	}

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	private async Task SetReceiveMethodAddressAndStore()
	{
		_ageGateArgeement = AgreeState.None;
		bool flag = DeliveryAddress != null;
		bool flag2 = ReceivingMethod == ReceivingMethod.RegionDefault;
		if (!flag || flag2)
		{
			await SyncReceiveMethodQueued(appSessionStarted: true, force: true);
		}
	}

	private async Task SyncStores()
	{
		Store currentShop = null;
		Task<Result<IEnumerable<IGrouping<City, Store>>, DomainError>> allCityShopsTask = Task.Run(() => _storeService.Value.AllCityShops());
		Task<Result<SavedReceiveMethods, DomainError>> savedReceiveMethodsTask = Task.Run(() => _userAddressService.Value.SavedReceiveMethods());
		await Task.WhenAll(allCityShopsTask, savedReceiveMethodsTask);
		if (allCityShopsTask.Result.TryGetValue(out var value))
		{
			if (savedReceiveMethodsTask.Result.TryGetValue(out var value2))
			{
				ReceivingMethod = value2.CurrentDeliveryMethod.GetValueOrDefault();
				DeliveryAddress = (_deliveryAddress = value2.CurrentAddress?.ToDeliveryAddress());
				SavedStore = (value2.CurrentMerchantId.HasValue ? value2.GetCurrentShop(value) : null);
				currentShop = value2.GetCurrentOrDefaultShop(value);
			}
			else
			{
				currentShop = (from shopsByCity in value
					let city = shopsByCity.Key
					where city.IsDefault
					from shop in shopsByCity
					where shop.IsDefaultInCity
					select shop).FirstOrDefault();
			}
		}
		if (currentShop != null)
		{
			ActiveStore = currentShop;
		}
		_adminContext.Value.UpdateExtraPromotions();
	}

	private void OnDeliveryAddressChanged()
	{
		DoAsync().SafeFireAndForget((Action<Exception>)null, false);
		async Task DoAsync()
		{
			DeliveryAddress deliveryAddress = DeliveryAddress;
			if (!(deliveryAddress == null))
			{
				if (deliveryAddress == _remoteAddress)
				{
					_remoteAddress = null;
				}
				else
				{
					deliveryAddress.Comment = string.Empty;
					await Task.WhenAll((from t in this.AfterAddressSet.GetInvocationList().OfType<Func<Task>>()
						select t()).ToArray());
				}
			}
		}
	}

	public void UpdateActiveStoreProperties(IEnumerable<Store> stores)
	{
		foreach (Store store in stores)
		{
			if (store.Id == _activeStore?.Id)
			{
				SetActiveStore(store);
				break;
			}
		}
	}
}
