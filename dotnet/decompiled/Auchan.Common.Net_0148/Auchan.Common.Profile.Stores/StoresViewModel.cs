using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common.Location;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.Profile.Stores.Enums;
using Auchan.Common.Profile.Stores.Models;
using Auchan.Common.Profile.Stores.Repositories;
using Auchan.Common.Profile.Stores.Services;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.Profile.Stores;

public class StoresViewModel : ScreenViewModel
{
	public enum VisualState
	{
		InProgress,
		Default,
		Empty,
		Error
	}

	private readonly DefaultErrorTranslator _defaultErrorTranslator;

	private readonly IStoreRepository _storeRepository;

	private readonly ILogService _logService;

	private readonly IFullStoreFilterService _fullStoreFilterService;

	private readonly ILocationService _locationService;

	private readonly ILocationPermissionService _locationPermissionService;

	private readonly IAllExistingRegionRepository _regionRepository;

	private readonly IAdminContext _adminContext;

	private readonly Subject<StoreDetailsViewModel.Parameter> _navigateNext = new Subject<StoreDetailsViewModel.Parameter>();

	private readonly Subject<StoresFilterViewModel> _openFilterNext = new Subject<StoresFilterViewModel>();

	private readonly Subject<Location> _mapUpdate = new Subject<Location>();

	private readonly Subject<StoreDetailsMiniViewModel.Parameter> _openMiniStore = new Subject<StoreDetailsMiniViewModel.Parameter>();

	private readonly StoresFilterViewModel _storesFilterViewModel;

	private CancellationTokenSource? _pinCancellationToken;

	private Location? _geoPosition;

	private readonly Subject<Unit> _retrySubject = new Subject<Unit>();

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorHint_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CGotLocation_003Ek__BackingField;

	[CompilerGenerated]
	private StoresContentState _003CContentState_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private float _003CMapZoom_003Ek__BackingField;

	[CompilerGenerated]
	private float _003CAzimuth_003Ek__BackingField;

	[CompilerGenerated]
	private float _003CTilt_003Ek__BackingField;

	private volatile int _loadStoresLock;

	public string YandexMapKey => _adminContext.AppConfig?.YandexMapsModel?.ApiKey ?? string.Empty;

	public string Title => "Магазины рядом";

	public string ProgressTitle => "Ищем магазины…";

	public string ErrorButtonText => "Повторить";

	public string EmptyTitleText => "Ничего не найдено.";

	public string EmptyHintText => "Попробуйте смягчить условия фильтра.";

	public string ListButtonText => "Списком";

	public string MapButtonText => "На карте";

	public string SearchQueryHint => "Поиск";

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

	public string ErrorHint
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorHint_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorHint_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorHint_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorHint");
			}
		}
	} = string.Empty;

	public bool GotLocation
	{
		[CompilerGenerated]
		get
		{
			return _003CGotLocation_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CGotLocation_003Ek__BackingField != value)
			{
				_003CGotLocation_003Ek__BackingField = value;
				RaisePropertyChanged("GotLocation");
			}
		}
	}

	public StoresContentState ContentState
	{
		[CompilerGenerated]
		get
		{
			return _003CContentState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CContentState_003Ek__BackingField != value)
			{
				_003CContentState_003Ek__BackingField = value;
				RaisePropertyChanged("ContentState");
			}
		}
	}

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
				RaisePropertyChanged("IsFilterButtonActive");
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.Default;

	public float MapZoom
	{
		[CompilerGenerated]
		get
		{
			return _003CMapZoom_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!(_003CMapZoom_003Ek__BackingField == value))
			{
				_003CMapZoom_003Ek__BackingField = value;
				RaisePropertyChanged("MapZoom");
			}
		}
	} = 13f;

	public float Azimuth
	{
		[CompilerGenerated]
		get
		{
			return _003CAzimuth_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!(_003CAzimuth_003Ek__BackingField == value))
			{
				_003CAzimuth_003Ek__BackingField = value;
				RaisePropertyChanged("Azimuth");
			}
		}
	}

	public float Tilt
	{
		[CompilerGenerated]
		get
		{
			return _003CTilt_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!(_003CTilt_003Ek__BackingField == value))
			{
				_003CTilt_003Ek__BackingField = value;
				RaisePropertyChanged("Tilt");
			}
		}
	}

	public bool IsFilterButtonActive
	{
		get
		{
			if (State != VisualState.Error)
			{
				return State != VisualState.InProgress;
			}
			return false;
		}
	}

	public ObservableRangeCollection<StoresItemViewModel> Stores { get; } = new ObservableRangeCollection<StoresItemViewModel>();

	public IObservable<StoreDetailsViewModel.Parameter> NavigateNextCommand => _navigateNext.Debounce();

	public IObservable<StoresFilterViewModel> OpenFilterCommand => _openFilterNext.Debounce();

	public IObservable<Location> OnMapUpdate => _mapUpdate.Debounce();

	public IObservable<StoreDetailsMiniViewModel.Parameter> OnOpenMiniStore => _openMiniStore.Debounce();

	public IObservable<bool> OnChangeFilterIcon => _fullStoreFilterService.OnChangeFilterIcon;

	public StoresViewModel(DefaultErrorTranslator defaultErrorTranslator, IStoreRepository storeRepository, ILogService logService, IFullStoreFilterService fullStoreFilterService, ILocationService locationService, ILocationPermissionService locationPermissionService, IAllExistingRegionRepository regionRepository, IAdminContext adminContext)
	{
		_defaultErrorTranslator = defaultErrorTranslator;
		_storeRepository = storeRepository;
		_logService = logService;
		_fullStoreFilterService = fullStoreFilterService;
		_locationService = locationService;
		_locationPermissionService = locationPermissionService;
		_regionRepository = regionRepository;
		_adminContext = adminContext;
		_geoPosition = locationService.GetMoscowLocation();
		_storesFilterViewModel = new StoresFilterViewModel(fullStoreFilterService, regionRepository, storeRepository);
		_storesFilterViewModel.Setup(OnResult);
	}

	protected override async Task Start()
	{
		State = VisualState.InProgress;
		_retrySubject.PerformSamplingTask(LoadStores).Subscribe().AddTo(base.CloseDisposable);
		await base.Start();
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		await LoadStores();
	}

	private async Task LoadStores()
	{
		int @lock = Interlocked.Increment(ref _loadStoresLock);
		State = VisualState.InProgress;
		GotLocation = false;
		PermissionStatus permission = await _locationPermissionService.GetForegroundPermissionStatus();
		if (permission != PermissionStatus.Granted)
		{
			permission = await _locationPermissionService.RequestForegroundPermission();
		}
		if (IsPermissionRejected(permission))
		{
			_geoPosition = _locationService.GetMoscowLocation();
		}
		else
		{
			if (permission != PermissionStatus.Granted)
			{
				Stores.Clear();
				State = VisualState.Default;
				return;
			}
			_geoPosition = await _locationService.GetGeoPosition();
		}
		if (permission == PermissionStatus.Granted && _geoPosition != null)
		{
			GotLocation = true;
		}
		if (@lock != _loadStoresLock)
		{
			return;
		}
		await _regionRepository.UpdateCacheOrNothingAsync();
		if (@lock != _loadStoresLock)
		{
			return;
		}
		Stores.Clear();
		Result<List<FullStoreModel>, DomainError> result = await _storeRepository.FromCacheOrApiByGeoAsync(_geoPosition);
		if (@lock != _loadStoresLock)
		{
			return;
		}
		if (result.IsFailure)
		{
			State = VisualState.Error;
			(ErrorMessage, ErrorHint) = _defaultErrorTranslator.Translate(result.Error);
			return;
		}
		if (!result.Value.Any())
		{
			State = VisualState.Empty;
			return;
		}
		if (!_fullStoreFilterService.Filter.IsSaved)
		{
			await _fullStoreFilterService.SetDefault();
		}
		if (@lock != _loadStoresLock)
		{
			return;
		}
		List<FullStoreModel> source = _storeRepository.FilterStores(result.Value, null, _fullStoreFilterService.Filter);
		Stores.AddRange(source.Select((FullStoreModel c) => new StoresItemViewModel(c)));
		FullStoreModel fullStoreModel = source.FirstOrDefault((FullStoreModel s) => s.TempWorkHours != null && s.TempWorkHours.Count > 0);
		if (fullStoreModel != null && Stores.Count > 0)
		{
			Stores.Insert(0, new StoresItemViewModel(fullStoreModel, isInformer: true));
		}
		if (_fullStoreFilterService.Filter.IsSaved && Stores.Any((StoresItemViewModel s) => !s.IsTempWorkInformerModel))
		{
			StoresItemViewModel storesItemViewModel = Stores.First((StoresItemViewModel s) => !s.IsTempWorkInformerModel);
			_mapUpdate.OnNext(new Location(storesItemViewModel.Latitude, storesItemViewModel.Longitude));
		}
		else
		{
			_mapUpdate.OnNext(_geoPosition ?? _locationService.GetDefaultPosition());
		}
		State = VisualState.Default;
	}

	private static bool IsPermissionRejected(PermissionStatus permission)
	{
		if ((uint)(permission - 1) <= 1u || permission == PermissionStatus.Restricted)
		{
			return true;
		}
		return false;
	}

	public async Task OpenMiniStore(int userData)
	{
		if (_pinCancellationToken == null || _pinCancellationToken.IsCancellationRequested)
		{
			FullStoreModel fullStoreModel = Stores.First((StoresItemViewModel c) => c.Id == userData).FullStoreModel;
			_openMiniStore.OnNext(new StoreDetailsMiniViewModel.Parameter(fullStoreModel));
			_pinCancellationToken = new CancellationTokenSource();
			await Task.Delay(1000);
			_pinCancellationToken.Cancel();
		}
	}

	public void NavigateToDetails(StoresItemViewModel itemViewModel)
	{
		_logService.LogInfo("OrderViewModel", "Запрошен переход на экран заказа", LogType.UserAction, SystemType.MobileApp);
		_navigateNext.OnNext(new StoreDetailsViewModel.Parameter(itemViewModel.Id));
	}

	public void OpenFilter()
	{
		_openFilterNext.OnNext(_storesFilterViewModel);
	}

	public void RestoreFilterIcon()
	{
		_fullStoreFilterService.SetCurrentIcon();
	}

	public void TabListClick()
	{
		ContentState = StoresContentState.List;
	}

	public void TabMapClick()
	{
		ContentState = StoresContentState.Map;
	}

	private void OnResult(StoresFilterViewModel.Result result)
	{
		if (result.IsFilterSaved)
		{
			_retrySubject.OnNext(Unit.Default);
		}
	}

	public void Retry()
	{
		_retrySubject.OnNext(Unit.Default);
	}
}
