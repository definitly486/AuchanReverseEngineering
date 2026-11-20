using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Addresses;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.PriceChecker.Dto;
using Auchan.Common.Extensions;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Devices;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.Ecom.PriceChecker;

public class PriceCheckerAddressViewModel : ScreenViewModel<PriceCheckerAddressViewModel.Parameter>
{
	public sealed class Parameter : BrokeredParameter<Result?>
	{
		public Parameter()
			: base(default(CancellationToken))
		{
		}
	}

	public sealed class Result
	{
		public required Store Store { get; init; }
	}

	private readonly IEcomContext _ecomContext;

	private readonly IInfoMessageService _infoMessageService;

	private readonly ILocationProvider _locationProvider;

	private readonly PriceCheckerService _priceCheckerService;

	private readonly IStoreService _storeService;

	private readonly IAdminContext _adminContext;

	private readonly IUserContext _userContext;

	private readonly IPriceCheckerContext _priceCheckerContext;

	private readonly Store? _savedStore;

	private Result? _result;

	private IReadOnlyList<SelectionItemViewModel<Store, PriceCheckerAddressViewModel>> _allStores = Array.Empty<SelectionItemViewModel<Store, PriceCheckerAddressViewModel>>();

	private SelectionItemViewModel<Store, PriceCheckerAddressViewModel>? _pinnedStore;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CAddress_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CSearchQuery_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<SelectionItemViewModel<Store, PriceCheckerAddressViewModel>> _003CPriceCheckerStores_003Ek__BackingField;

	public string SelectAddressText => "Выберите магазин";

	public string SaveButtonText => "Сохранить";

	public string ErrorTitle { get; } = string.Empty;

	public string ErrorMessage { get; } = string.Empty;

	public string DifPricesWarningText { get; } = "Цены на товары в разных магазинах могут отличаться";

	public string DeliveryTitle => "Список магазинов";

	public string CannotGetStoresList => "Не удалось получить список магазинов";

	public string SearchPlaceholder => "Поиск магазина";

	public string StoresNotFoundTitle => "Магазины не найдены";

	public string StoresNotFoundSubtitle => "Проверьте название или попробуйте другой запрос";

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

	public string Address
	{
		[CompilerGenerated]
		get
		{
			return _003CAddress_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CAddress_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CAddress_003Ek__BackingField = value;
				RaisePropertyChanged("Address");
			}
		}
	} = string.Empty;

	public string SearchQuery
	{
		[CompilerGenerated]
		get
		{
			return _003CSearchQuery_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CSearchQuery_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CSearchQuery_003Ek__BackingField = value;
				RaisePropertyChanged("StoresNotFound");
				RaisePropertyChanged("CanSave");
				RaisePropertyChanged("SearchQuery");
			}
		}
	} = string.Empty;

	public IReadOnlyList<SelectionItemViewModel<Store, PriceCheckerAddressViewModel>> PriceCheckerStores
	{
		[CompilerGenerated]
		get
		{
			return _003CPriceCheckerStores_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CPriceCheckerStores_003Ek__BackingField, value))
			{
				_003CPriceCheckerStores_003Ek__BackingField = value;
				RaisePropertyChanged("StoresNotFound");
				RaisePropertyChanged("CanSave");
				RaisePropertyChanged("PriceCheckerStores");
			}
		}
	} = Array.Empty<SelectionItemViewModel<Store, PriceCheckerAddressViewModel>>();

	public bool StoresNotFound
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(SearchQuery))
			{
				return PriceCheckerStores.Count == 0;
			}
			return false;
		}
	}

	public bool CanSave => !StoresNotFound;

	public UICommand CloseCommand { get; } = new UICommand();

	public PriceCheckerAddressViewModel(BrokerToken brokerToken, IEcomContext ecomContext, IInfoMessageService infoMessageService, PriceCheckerService priceCheckerService, ILocationProvider locationProvider, IAdminContext adminContext, IUserContext userContext, IStoreService storeService, IPriceCheckerContext priceCheckerContext)
		: base(brokerToken)
	{
		_ecomContext = ecomContext;
		_infoMessageService = infoMessageService;
		_priceCheckerService = priceCheckerService;
		_locationProvider = locationProvider;
		_storeService = storeService;
		_adminContext = adminContext;
		_userContext = userContext;
		_priceCheckerContext = priceCheckerContext;
		_savedStore = _priceCheckerContext.SavedStore;
		TabBarVisible = false;
		this.OnPropertyChanges((PriceCheckerAddressViewModel x) => x.SearchQuery).Subscribe(delegate
		{
			ApplyFilter();
		});
	}

	protected override async Task Start()
	{
		AppAnalytics.AppMetrica.TrackEvent("TapPricecheckerAddress");
		await base.Start();
		State = VisualState.Default;
		GetStoresForPriceChecker().SafeFireAndForget((Action<Exception>)null, false);
	}

	public void OnBackPressed()
	{
		CloseCommand.Trigger();
	}

	public void OnStoreSelected(SelectionItemViewModel<Store, PriceCheckerAddressViewModel> storeItemViewModel)
	{
		SelectStore(storeItemViewModel);
	}

	public void OnClose()
	{
		CloseCommand.Trigger();
	}

	public async void OnSaveClick()
	{
		State = VisualState.InProgress;
		SelectionItemViewModel<Store, PriceCheckerAddressViewModel> selectionItemViewModel = _allStores.First((SelectionItemViewModel<Store, PriceCheckerAddressViewModel> x) => x.Selected);
		_result = new Result
		{
			Store = selectionItemViewModel.Item
		};
		_priceCheckerContext.SaveStore(selectionItemViewModel.Item);
		if (_savedStore == null && (_adminContext.AppConfig?.PriceCheckerMWEventsEnabled ?? false))
		{
			PriceCheckerMiddleWareEventDtoAfterOpenPricechecker requestDto = new PriceCheckerMiddleWareEventDtoAfterOpenPricechecker
			{
				Name = "price_check_login",
				ValueDto = new ValueAfterOpenPricecheckerDto
				{
					ClientId = (_userContext.Profile?.ClientAccountId ?? string.Empty),
					StoreId = selectionItemViewModel.Item.Id.ToString(),
					Device = DeviceInfo.Model,
					OperatingSystem = DeviceInfo.Platform.ToString() + " " + DeviceInfo.VersionString
				}
			};
			await _priceCheckerService.Events(requestDto);
		}
		State = VisualState.Default;
		CloseCommand.Trigger();
	}

	private void SelectStore(SelectionItemViewModel<Store, PriceCheckerAddressViewModel> storeItemViewModel)
	{
		storeItemViewModel.Selected = true;
		Address = storeItemViewModel.Item.Address;
		foreach (SelectionItemViewModel<Store, PriceCheckerAddressViewModel> allStore in _allStores)
		{
			allStore.Selected = allStore.Item.Id == storeItemViewModel.Item.Id;
		}
	}

	private void ApplyFilter()
	{
		string query = SearchQuery?.Trim() ?? string.Empty;
		if (string.IsNullOrEmpty(query))
		{
			PriceCheckerStores = PinFirst(_allStores, _pinnedStore);
			return;
		}
		ImmutableList<SelectionItemViewModel<Store, PriceCheckerAddressViewModel>> immutableList = _allStores.Where(Matches).ToImmutableList();
		SelectionItemViewModel<Store, PriceCheckerAddressViewModel> pinned = _allStores.FirstOrDefault((SelectionItemViewModel<Store, PriceCheckerAddressViewModel> store) => store.Selected);
		IReadOnlyList<SelectionItemViewModel<Store, PriceCheckerAddressViewModel>> priceCheckerStores;
		if (immutableList.Count <= 0)
		{
			IReadOnlyList<SelectionItemViewModel<Store, PriceCheckerAddressViewModel>> readOnlyList = immutableList;
			priceCheckerStores = readOnlyList;
		}
		else
		{
			priceCheckerStores = PinFirst(immutableList, pinned);
		}
		PriceCheckerStores = priceCheckerStores;
		bool Matches(SelectionItemViewModel<Store, PriceCheckerAddressViewModel> store)
		{
			if (!store.Item.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
			{
				return store.Item.Address.Contains(query, StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}
	}

	private static IReadOnlyList<SelectionItemViewModel<Store, PriceCheckerAddressViewModel>> PinFirst(IReadOnlyList<SelectionItemViewModel<Store, PriceCheckerAddressViewModel>> stores, SelectionItemViewModel<Store, PriceCheckerAddressViewModel>? pinned)
	{
		if (pinned != null)
		{
			return stores.Where((SelectionItemViewModel<Store, PriceCheckerAddressViewModel> store) => store != pinned).Prepend<SelectionItemViewModel<Store, PriceCheckerAddressViewModel>>(pinned).ToImmutableList();
		}
		return stores;
	}

	private async Task GetStoresForPriceChecker()
	{
		State = VisualState.InProgress;
		using (Disposable.Create(delegate
		{
			State = VisualState.Default;
		}))
		{
			Result<Location, DomainError> locationResult = await _locationProvider.GetLocation();
			if ((await _storeService.AllCityShops(locationResult.IsSuccess ? locationResult.Value : null, showVisible: true)).TryGetValue(out var value))
			{
				IEnumerable<Store> source = value.Where((IGrouping<City, Store> i) => i.Key.FiasId == _ecomContext.ActiveStore.City.FiasId).Select((Func<IGrouping<City, Store>, IEnumerable<Store>>)((IGrouping<City, Store> i) => i)).FirstOrDefault() ?? Array.Empty<Store>();
				if (!source.Any())
				{
					_infoMessageService.ShowSnackbar(CannotGetStoresList);
					return;
				}
				Store selectedStore = source.FirstOrDefault((Store x) => x.Id == _savedStore?.Id);
				IEnumerable<SelectionItemViewModel<Store, PriceCheckerAddressViewModel>> source2 = source.Select((Store x) => new SelectionItemViewModel<Store, PriceCheckerAddressViewModel>(x, this, selected: false));
				if (locationResult.IsFailure)
				{
					if (selectedStore == null)
					{
						selectedStore = source.FirstOrDefault((Store x) => x.IsDefaultInCity);
					}
					source2 = source2.OrderBy((SelectionItemViewModel<Store, PriceCheckerAddressViewModel> x) => x.Item.Name);
				}
				if (selectedStore == null)
				{
					selectedStore = source.First();
				}
				_allStores = source2.ToImmutableList();
				_pinnedStore = _allStores.First((SelectionItemViewModel<Store, PriceCheckerAddressViewModel> i) => i.Item == selectedStore);
				SelectStore(_pinnedStore);
				ApplyFilter();
			}
			else
			{
				_infoMessageService.ShowSnackbar(CannotGetStoresList);
			}
		}
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(_result);
	}
}
