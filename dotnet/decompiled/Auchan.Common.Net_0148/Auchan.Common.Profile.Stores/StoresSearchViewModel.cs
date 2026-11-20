using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common.Location;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.Profile.Stores.Models;
using Auchan.Common.Profile.Stores.Repositories;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.Profile.Stores;

public sealed class StoresSearchViewModel : ScreenViewModel
{
	public enum SearchVisualState
	{
		Content,
		InProgress,
		NotFound
	}

	private const int MinSearchQueryLength = 3;

	private const int MaxSearchQueryLength = 30;

	private readonly ILogService _logService;

	private readonly ILocationService _locationService;

	private readonly ILocationPermissionService _locationPermissionService;

	private readonly IStoreRepository _storeRepository;

	private readonly Subject<StoreDetailsViewModel.Parameter> _navigateNext = new Subject<StoreDetailsViewModel.Parameter>();

	private Location? _currentGeoPosition;

	private bool _hasLocationPermission;

	[CompilerGenerated]
	private SearchVisualState _003CSearchState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CSearchQuery_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CGotLocation_003Ek__BackingField;

	public SearchVisualState SearchState
	{
		[CompilerGenerated]
		get
		{
			return _003CSearchState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CSearchState_003Ek__BackingField != value)
			{
				_003CSearchState_003Ek__BackingField = value;
				RaisePropertyChanged("SearchState");
			}
		}
	}

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
				RaisePropertyChanged("IsSearchIconVisible");
				RaisePropertyChanged("SearchQuery");
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

	public ObservableRangeCollection<StoresItemViewModel> SearchProductResults { get; } = new ObservableRangeCollection<StoresItemViewModel>();

	public bool IsSearchIconVisible => string.IsNullOrEmpty(SearchQuery);

	public int MaxQueryLength => 30;

	public string SearchPlaceholder => "Поиск";

	public string EmptySearchTitle => "Ничего не найдено.";

	public string EmptySearchSubtitle => "Попробуйте изменить\nусловия поиска.";

	public IObservable<StoreDetailsViewModel.Parameter> NavigateNextCommand => _navigateNext.Debounce();

	public StoresSearchViewModel(ILogService logService, ILocationService locationService, ILocationPermissionService locationPermissionService, IStoreRepository storeRepository)
	{
		_logService = logService;
		_locationService = locationService;
		_locationPermissionService = locationPermissionService;
		_storeRepository = storeRepository;
		(from query in this.OnPropertyChanges((StoresSearchViewModel x) => x.SearchQuery).Throttle(TimeSpan.FromMilliseconds(400L))
			where query.Length >= 3
			select query).PerformSamplingTask(SearchAsync).Subscribe();
		(from query in this.OnPropertyChanges((StoresSearchViewModel x) => x.SearchQuery)
			where query.Length < 3
			select query).PerformSamplingTask(ClearSearchAsync).Subscribe();
	}

	public void NavigateToDetails(StoresItemViewModel itemViewModel)
	{
		_logService.LogInfo("OrderViewModel", "Запрошен переход на экран заказа", LogType.UserAction, SystemType.MobileApp);
		_navigateNext.OnNext(new StoreDetailsViewModel.Parameter(itemViewModel.Id));
	}

	protected override async Task Start()
	{
		await base.Start();
		_hasLocationPermission = await _locationPermissionService.IsForegroundPermissionGranted();
		_currentGeoPosition = await _locationService.GetGeoPosition();
	}

	private async Task SearchAsync(string query)
	{
		SearchState = SearchVisualState.InProgress;
		if (!_hasLocationPermission)
		{
			GotLocation = false;
			SearchProductResults.Clear();
			SearchState = SearchVisualState.Content;
			return;
		}
		GotLocation = _currentGeoPosition != null;
		Result<List<FullStoreModel>, DomainError> result = ((!GotLocation) ? (await _storeRepository.FromCacheOrApiAsync(query)) : (await _storeRepository.FromCacheOrApiAsync(query, null, _currentGeoPosition)));
		if (result.IsFailure)
		{
			SearchState = SearchVisualState.NotFound;
			return;
		}
		if (!result.Value.Any())
		{
			SearchState = SearchVisualState.NotFound;
			return;
		}
		SearchProductResults.ReplaceRange(result.Value.Select((FullStoreModel c) => new StoresItemViewModel(c)).ToList());
		FullStoreModel fullStoreModel = result.Value.FirstOrDefault((FullStoreModel s) => s.TempWorkHours != null && s.TempWorkHours.Count > 0);
		if (fullStoreModel != null && SearchProductResults.Count > 0)
		{
			SearchProductResults.Insert(0, new StoresItemViewModel(fullStoreModel, isInformer: true));
		}
		SearchState = SearchVisualState.Content;
	}

	private Task ClearSearchAsync()
	{
		SearchProductResults.Clear();
		return Task.CompletedTask;
	}
}
