using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common.Binding;
using Auchan.Common.Common.Location;
using Auchan.Common.Extensions;
using Auchan.Common.Navigation;
using Auchan.Common.Profile.Stores.Models;
using Auchan.Common.Profile.Stores.Repositories;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.Profile.Stores;

public class StoreDetailsViewModel : ScreenViewModel
{
	public class Parameter
	{
		public int StoreId { get; private set; }

		public Parameter(int storeId)
		{
			StoreId = storeId;
		}
	}

	public enum VisualState
	{
		InProgress,
		Default,
		Error
	}

	public const int DescriptionMaxLenght = 165;

	private readonly Parameter _parameter;

	private readonly IStoreRepository _storeRepository;

	private readonly DefaultErrorTranslator _defaultErrorTranslator;

	private readonly ILocationService _locationService;

	private readonly INavigationService _navigationService;

	private readonly IAdminContext _adminContext;

	private readonly Func<FullStoreServiceModel, ICollection<IDisposable>, StoreDetailsServicesItemViewModel> _viewModelFactory;

	private readonly Subject<StoreDetailsServicesViewModel.Parameter> _navigatePopupServices = new Subject<StoreDetailsServicesViewModel.Parameter>();

	private readonly Subject<Location> _buildRouteCommand = new Subject<Location>();

	private FullStoreModel _store = new FullStoreModel();

	private Location? _currentGeoPosition;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CNameText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CStoreTypeText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CDistanceText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CAddressText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CParkingLotsText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CPhone_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CScheduleText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CServicesLabel_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CDescriptionText_003Ek__BackingField;

	[CompilerGenerated]
	private float _003CMapZoom_003Ek__BackingField;

	[CompilerGenerated]
	private float _003CAzimuth_003Ek__BackingField;

	[CompilerGenerated]
	private float _003CTilt_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorHint_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsLocationGetted_003Ek__BackingField;

	[CompilerGenerated]
	private Location? _003CStoreLocation_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsOpen_003Ek__BackingField;

	[CompilerGenerated]
	private string _003COpenStatusText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003COpenStatusDescription_003Ek__BackingField;

	public UICommand<TextDetailsViewModel.Parameter> OpenTextDetailsCommand = new UICommand<TextDetailsViewModel.Parameter>();

	public UICommand CloseCommand = new UICommand();

	public FullStoreModel Store => _store;

	public string YandexMapKey => _adminContext.AppConfig?.YandexMapsModel?.ApiKey ?? string.Empty;

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
	} = VisualState.Default;

	public bool IsPublicTransportExist => !string.IsNullOrEmpty(_store?.PublicTransport);

	public bool IsScheduleExist => !string.IsNullOrEmpty(_store?.Schedule);

	public string AddressLabel => "Адрес";

	public string BuildRouteLabel => "Построить маршрут";

	public string ExternalAppChooseText => "Открыть с помощью приложения";

	public string PublicTransportLabel => "Общественный транспорт";

	public string PublicTransportDetailsLabel => "Как добраться";

	public string ScheduleLabel => "Часы работы";

	public string AllServicesLabel => "Все";

	public string DescriptionLabel => "Описание";

	public string DescriptionMoreText => "Подробнее";

	public string ContactsLabel => "Связаться с нами";

	public string CallLabel => "Позвонить";

	public string WriteLabel => "Написать";

	public string ErrorButtonText => "Обновить";

	public string NameText
	{
		[CompilerGenerated]
		get
		{
			return _003CNameText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CNameText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CNameText_003Ek__BackingField = value;
				RaisePropertyChanged("NameText");
			}
		}
	} = string.Empty;

	public string StoreTypeText
	{
		[CompilerGenerated]
		get
		{
			return _003CStoreTypeText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CStoreTypeText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CStoreTypeText_003Ek__BackingField = value;
				RaisePropertyChanged("StoreTypeText");
			}
		}
	} = string.Empty;

	public string DistanceText
	{
		[CompilerGenerated]
		get
		{
			return _003CDistanceText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CDistanceText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CDistanceText_003Ek__BackingField = value;
				RaisePropertyChanged("DistanceText");
			}
		}
	} = string.Empty;

	public string AddressText
	{
		[CompilerGenerated]
		get
		{
			return _003CAddressText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CAddressText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CAddressText_003Ek__BackingField = value;
				RaisePropertyChanged("AddressText");
			}
		}
	} = string.Empty;

	public string ParkingLotsText
	{
		[CompilerGenerated]
		get
		{
			return _003CParkingLotsText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CParkingLotsText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CParkingLotsText_003Ek__BackingField = value;
				RaisePropertyChanged("ParkingLotsText");
			}
		}
	} = string.Empty;

	public string Phone
	{
		[CompilerGenerated]
		get
		{
			return _003CPhone_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CPhone_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CPhone_003Ek__BackingField = value;
				RaisePropertyChanged("Phone");
			}
		}
	} = string.Empty;

	public string ScheduleText
	{
		[CompilerGenerated]
		get
		{
			return _003CScheduleText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CScheduleText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CScheduleText_003Ek__BackingField = value;
				RaisePropertyChanged("ScheduleText");
			}
		}
	} = string.Empty;

	public string ServicesLabel
	{
		[CompilerGenerated]
		get
		{
			return _003CServicesLabel_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CServicesLabel_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CServicesLabel_003Ek__BackingField = value;
				RaisePropertyChanged("ServicesLabel");
			}
		}
	} = string.Empty;

	public string DescriptionText
	{
		[CompilerGenerated]
		get
		{
			return _003CDescriptionText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CDescriptionText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CDescriptionText_003Ek__BackingField = value;
				RaisePropertyChanged("DescriptionText");
			}
		}
	} = string.Empty;

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
	} = 11f;

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

	public bool IsLocationGetted
	{
		[CompilerGenerated]
		get
		{
			return _003CIsLocationGetted_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsLocationGetted_003Ek__BackingField != value)
			{
				_003CIsLocationGetted_003Ek__BackingField = value;
				RaisePropertyChanged("IsLocationGetted");
			}
		}
	}

	public Location? StoreLocation
	{
		[CompilerGenerated]
		get
		{
			return _003CStoreLocation_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!(_003CStoreLocation_003Ek__BackingField == value))
			{
				_003CStoreLocation_003Ek__BackingField = value;
				RaisePropertyChanged("StoreLocation");
			}
		}
	}

	public bool IsOpen
	{
		[CompilerGenerated]
		get
		{
			return _003CIsOpen_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsOpen_003Ek__BackingField != value)
			{
				_003CIsOpen_003Ek__BackingField = value;
				RaisePropertyChanged("IsOpen");
			}
		}
	}

	public string OpenStatusText
	{
		[CompilerGenerated]
		get
		{
			return _003COpenStatusText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003COpenStatusText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003COpenStatusText_003Ek__BackingField = value;
				RaisePropertyChanged("OpenStatusText");
			}
		}
	} = string.Empty;

	public string OpenStatusDescription
	{
		[CompilerGenerated]
		get
		{
			return _003COpenStatusDescription_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003COpenStatusDescription_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003COpenStatusDescription_003Ek__BackingField = value;
				RaisePropertyChanged("OpenStatusDescription");
			}
		}
	} = string.Empty;

	public string TempWorkTitle => "Временный график";

	public ObservableRangeCollection<StoreDetailsServicesItemViewModel> Services { get; } = new ObservableRangeCollection<StoreDetailsServicesItemViewModel>();

	public IObservable<StoreDetailsServicesViewModel.Parameter> OpenPopupServicesCommand => _navigatePopupServices.Debounce();

	public IObservable<Location> BuildRouteCommand => _buildRouteCommand.Debounce();

	public StoreDetailsViewModel(Parameter parameter, IStoreRepository storeRepository, DefaultErrorTranslator defaultErrorTranslator, ILocationService locationService, Func<FullStoreServiceModel, ICollection<IDisposable>, StoreDetailsServicesItemViewModel> viewModelFactory, INavigationService navigationService, IAdminContext adminContext)
	{
		_parameter = parameter;
		_storeRepository = storeRepository;
		_defaultErrorTranslator = defaultErrorTranslator;
		_locationService = locationService;
		_viewModelFactory = viewModelFactory;
		_navigationService = navigationService;
		_adminContext = adminContext;
	}

	protected override async Task Start()
	{
		State = VisualState.InProgress;
		await base.Start();
	}

	protected override async Task OnResumed()
	{
		State = VisualState.InProgress;
		await base.OnResumed();
		_currentGeoPosition = await _locationService.GetGeoPosition();
		await LoadStore();
	}

	public async Task LoadStore()
	{
		State = VisualState.InProgress;
		Result<FullStoreModel, DomainError> result = await _storeRepository.FromCacheOrApiByExternalIdAsync(_parameter.StoreId);
		if (result.IsFailure)
		{
			if (_store.ExternalId != -1)
			{
				CloseCommand.Trigger();
				return;
			}
			State = VisualState.Error;
			(ErrorMessage, ErrorHint) = _defaultErrorTranslator.Translate(result.Error);
		}
		else
		{
			_store = result.Value;
			SetProperties();
			Services.ReplaceRange(_store.Services.Select((FullStoreServiceModel c) => _viewModelFactory(c, base.CloseDisposable)));
			State = VisualState.Default;
		}
	}

	public void OpenPopupServices()
	{
		_navigatePopupServices.OnNext(new StoreDetailsServicesViewModel.Parameter(_store));
	}

	private void SetProperties()
	{
		NameText = _store.Name;
		StoreTypeText = _store.StoreFormat;
		AddressText = _store.Address;
		Phone = _store.Phone;
		ScheduleText = _store.Schedule;
		IsOpen = _store.IsOpen;
		OpenStatusText = _store.OpenStatusText;
		OpenStatusDescription = _store.OpenStatusDescription;
		ServicesLabel = (string.IsNullOrEmpty(_store.StoreFormat) ? "Услуги" : ("Услуги в " + _store.StoreFormat.ToLower() + "е"));
		DescriptionText = _store.Description;
		StoreLocation = new Location(_store.Latitude, _store.Longitude);
		IsLocationGetted = _currentGeoPosition != null;
		DistanceText = GetDistanceText();
		ParkingLotsText = _store.ParkingLotsText;
		RaisePropertyChanged("IsPublicTransportExist");
		RaisePropertyChanged("IsScheduleExist");
		RaisePropertyChanged("Store");
	}

	private string GetDistanceText()
	{
		if (!IsLocationGetted)
		{
			return string.Empty;
		}
		double num = Location.CalculateDistance(_currentGeoPosition, StoreLocation, DistanceUnits.Kilometers);
		if (num > 5.0)
		{
			return "более 5 км";
		}
		return num.ToString("0.00", CultureInfo.InvariantCulture) + " км";
	}

	public void MakeCall()
	{
		_navigationService.CallTo(_store.Phone);
	}

	public void BuildRoute()
	{
		_buildRouteCommand.OnNext(new Location(_store.Latitude, _store.Longitude));
	}

	public void NavigateToPublicTransport()
	{
		OpenTextDetailsCommand.Trigger(new TextDetailsViewModel.Parameter("Как добраться", _store.PublicTransport));
	}

	public void OpenDescriptionDetails()
	{
		OpenTextDetailsCommand.Trigger(new TextDetailsViewModel.Parameter("Описание", _store.Description));
	}
}
