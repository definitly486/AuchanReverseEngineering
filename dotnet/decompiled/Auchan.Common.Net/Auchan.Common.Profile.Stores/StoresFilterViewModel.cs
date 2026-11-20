using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.Stores.Models;
using Auchan.Common.Profile.Stores.Repositories;
using Auchan.Common.Profile.Stores.Services;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.Stores;

public class StoresFilterViewModel : ScreenViewModel
{
	public class Result
	{
		public bool IsFilterSaved { get; set; }

		public Result(bool isFilterSaved)
		{
			IsFilterSaved = isFilterSaved;
		}
	}

	private readonly IStoreRepository _storeServiceRepository;

	private readonly IFullStoreFilterService _filterService;

	private readonly IAllExistingRegionRepository _regionRepository;

	private readonly Subject<StoreType> _onStoreTypeChanged = new Subject<StoreType>();

	private readonly Subject<Unit> _onDissmiss = new Subject<Unit>();

	private Action<Result>? _onResult;

	private Subject<StoresFilterRegionsViewModel> _onNavigateRegionsCommand = new Subject<StoresFilterRegionsViewModel>();

	private Subject<StoresFilterServicesViewModel> _onNavigateServicesCommand = new Subject<StoresFilterServicesViewModel>();

	[CompilerGenerated]
	private string _003CRegionChoiseText_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsApplyEnabled_003Ek__BackingField;

	public IObservable<StoreType> OnStoreTypeChanged => _onStoreTypeChanged.Debounce();

	public IObservable<Unit> OnDissmiss => _onDissmiss.Debounce();

	public IObservable<StoresFilterRegionsViewModel> NavigateRegionCommand => _onNavigateRegionsCommand.Debounce();

	public IObservable<StoresFilterServicesViewModel> NavigateServicesCommand => _onNavigateServicesCommand.Debounce();

	public FullStoreFilterModel Filter => _filterService.Filter;

	public string TitleLabel => "Фильтр";

	public string RegionHint => "Регион";

	public string TypeLabel => "Тип магазина";

	public string SupermarketButtonLabel => "Супермаркет";

	public string GipermarketButtonLabel => "Гипермаркет";

	public string ServicesLabel => "Услуги";

	public string AllServicesText => "Все";

	public string ApplyButtonText => "Применить";

	public string ClearButtonText => "Очистить фильтр";

	public string RegionChoiseText
	{
		[CompilerGenerated]
		get
		{
			return _003CRegionChoiseText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CRegionChoiseText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CRegionChoiseText_003Ek__BackingField = value;
				RaisePropertyChanged("RegionChoiseText");
			}
		}
	} = string.Empty;

	public ObservableRangeCollection<StoresFilterServicesItemViewModel> Services { get; } = new ObservableRangeCollection<StoresFilterServicesItemViewModel>();

	public bool IsApplyEnabled
	{
		[CompilerGenerated]
		get
		{
			return _003CIsApplyEnabled_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsApplyEnabled_003Ek__BackingField != value)
			{
				_003CIsApplyEnabled_003Ek__BackingField = value;
				RaisePropertyChanged("IsApplyEnabled");
			}
		}
	}

	public StoresFilterViewModel(IFullStoreFilterService filterService, IAllExistingRegionRepository regionRepository, IStoreRepository storeServiceRepository)
	{
		_filterService = filterService;
		_regionRepository = regionRepository;
		_storeServiceRepository = storeServiceRepository;
	}

	public void Setup(Action<Result> onResult)
	{
		_onResult = onResult;
	}

	protected override async Task Start()
	{
		IsApplyEnabled = _filterService.Filter.IsSaved;
		if (Services.Any())
		{
			return;
		}
		Result<List<FullStoreServiceModel>, DomainError> result = await _storeServiceRepository.GetServicesAsync();
		if (!result.IsFailure)
		{
			Services.ReplaceRange(result.Value.Select((FullStoreServiceModel c) => new StoresFilterServicesItemViewModel(c)
			{
				Selected = _filterService.Filter.ServiceIds.Contains(c.Id)
			}));
		}
	}

	public void ApplyFilterThenDissmiss()
	{
		_filterService.Apply();
		_onResult(new Result(isFilterSaved: true));
		_onDissmiss.OnNext(Unit.Default);
	}

	public void ClearFilter()
	{
		IsApplyEnabled = false;
		_filterService.ClearAll();
		RegionChoiseText = _filterService.Filter.RegionName;
		_onResult(new Result(isFilterSaved: true));
		_onStoreTypeChanged.OnNext(StoreType.None);
		foreach (StoresFilterServicesItemViewModel service in Services)
		{
			service.Selected = false;
		}
	}

	public void SetStoreType(StoreType storeType)
	{
		IsApplyEnabled = true;
		_filterService.SetStoreType(storeType);
		_onStoreTypeChanged.OnNext(storeType);
	}

	public void SetService(StoresFilterServicesItemViewModel service)
	{
		IsApplyEnabled = true;
		service.Selected = !service.Selected;
		_filterService.SetService(service.Selected, service.Id);
		_filterService.Apply(isFilterIconChange: false);
	}

	public void RestoreFilter()
	{
		if (Filter.StoreType.HasValue)
		{
			_onStoreTypeChanged.OnNext(Filter.StoreType.Value);
		}
		if (Filter.RegionId.HasValue)
		{
			RegionChoiseText = Filter.RegionName;
		}
	}

	public void NavigateToRegions()
	{
		_onNavigateRegionsCommand.OnNext(new StoresFilterRegionsViewModel(_filterService, _regionRepository, OnResult));
	}

	public void NavigateToServices()
	{
		_onNavigateServicesCommand.OnNext(new StoresFilterServicesViewModel(_storeServiceRepository, _filterService, OnServicesResult));
	}

	private void OnResult(StoresFilterRegionsViewModel.Result result)
	{
		if (!string.IsNullOrEmpty(result.RegionName))
		{
			RegionChoiseText = result.RegionName;
			IsApplyEnabled = true;
		}
	}

	private void OnServicesResult()
	{
		IsApplyEnabled = true;
		foreach (StoresFilterServicesItemViewModel service in Services)
		{
			service.Selected = _filterService.Filter.ServiceIds.Contains(service.Id);
		}
	}
}
