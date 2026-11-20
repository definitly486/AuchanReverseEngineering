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

public class StoresFilterServicesViewModel : ScreenViewModel
{
	private readonly IStoreRepository _storeServiceRepository;

	private readonly IFullStoreFilterService _filterService;

	public readonly Subject<Unit> _onDismiss = new Subject<Unit>();

	private Action _onResult;

	[CompilerGenerated]
	private bool _003CIsApplyEnabled_003Ek__BackingField;

	public IObservable<Unit> OnDissmiss => _onDismiss.Debounce();

	public FullStoreFilterModel Filter => _filterService.Filter;

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

	public StoresFilterServicesViewModel(IStoreRepository storeServiceRepository, IFullStoreFilterService filterService, Action onResult)
	{
		_storeServiceRepository = storeServiceRepository;
		_filterService = filterService;
		_onResult = onResult;
	}

	protected override async Task Start()
	{
		await Task.WhenAll(base.Start(), LoadServices());
	}

	protected override async Task OnResumed()
	{
		await Task.WhenAll(base.OnResumed(), LoadServices());
	}

	public async Task LoadServices()
	{
		if (Services.Any())
		{
			SetSelectedServices();
			return;
		}
		Result<List<FullStoreServiceModel>, DomainError> result = await _storeServiceRepository.GetServicesAsync();
		if (!result.IsFailure)
		{
			Services.ReplaceRange(result.Value.Select((FullStoreServiceModel c) => new StoresFilterServicesItemViewModel(c)
			{
				Selected = Filter.ServiceIds.Contains(c.Id)
			}));
			SetSelectedServices();
		}
	}

	public void Close()
	{
		_filterService.ClearServices();
		_filterService.ReloadServices();
		_onDismiss.OnNext(Unit.Default);
	}

	public void ApplyFilter()
	{
		_filterService.Apply();
		_onDismiss.OnNext(Unit.Default);
		_onResult();
	}

	public void SetServiceId(bool isChecked, int serviceId)
	{
		_filterService.SetService(isChecked, serviceId);
		IsApplyEnabled = _filterService.IsServicesChanged;
	}

	private void SetSelectedServices()
	{
		foreach (StoresFilterServicesItemViewModel service in Services)
		{
			service.Selected = Filter.ServiceIds.Contains(service.Id);
		}
		IsApplyEnabled = _filterService.IsServicesChanged;
	}
}
