using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.Stores.Models;
using Auchan.Common.Profile.Stores.Repositories;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.Stores.Services;

public class FullStoreFilterService : IFullStoreFilterService
{
	private readonly IStoreRepository _storeRepository;

	private readonly IAllExistingRegionRepository _regionRepository;

	private FullStoreFilterModel _filter = new FullStoreFilterModel();

	private Subject<bool> _onChangeFilterIcon = new Subject<bool>();

	public IObservable<bool> OnChangeFilterIcon => _onChangeFilterIcon.Debounce();

	public FullStoreFilterModel Filter { get; private set; } = new FullStoreFilterModel();

	public bool IsServicesChanged => !Filter.ServicesEquals(_filter);

	public FullStoreFilterService(IStoreRepository storeRepository, IAllExistingRegionRepository regionRepository)
	{
		_storeRepository = storeRepository;
		_regionRepository = regionRepository;
	}

	public void Apply(bool isFilterIconChange = true)
	{
		Filter.Apply(_filter);
		if (Filter.IsDefault)
		{
			_onChangeFilterIcon.OnNext(value: false);
		}
		else if (isFilterIconChange)
		{
			_onChangeFilterIcon.OnNext(value: true);
		}
	}

	public void ReloadServices()
	{
		foreach (int serviceId in Filter.ServiceIds)
		{
			_filter.ServiceIds.Add(serviceId);
		}
	}

	public void ClearServices()
	{
		_filter.ServiceIds.Clear();
	}

	public void ClearAll()
	{
		_filter.Clear();
		Filter.Clear();
		SetDefault();
	}

	public Task SetDefault()
	{
		return DoSetDefault();
	}

	private async Task DoSetDefault()
	{
		await SetFilterDefaultRegion();
		_onChangeFilterIcon.OnNext(value: false);
	}

	public void SetCurrentIcon()
	{
		_onChangeFilterIcon.OnNext(Filter.IsSaved);
	}

	public void SetRegion(int regionId, string regionName)
	{
		_filter.RegionId = regionId;
		_filter.RegionName = regionName;
	}

	public void SetService(bool isChecked, int serviceId)
	{
		if (isChecked)
		{
			_filter.ServiceIds.Add(serviceId);
		}
		else
		{
			_filter.ServiceIds.Remove(serviceId);
		}
	}

	public void SetStoreType(StoreType storeType)
	{
		_filter.StoreType = storeType;
	}

	private async Task SetFilterDefaultRegion()
	{
		int regionOfFirstStore = _storeRepository.RegionOfFirstStore;
		RegionModel regionModel;
		if (regionOfFirstStore < 0)
		{
			regionModel = _regionRepository.DefaultRegion;
		}
		else
		{
			Result<RegionModel, DomainError> result = await _regionRepository.FromCacheAsync(regionOfFirstStore);
			regionModel = ((!result.IsSuccess) ? _regionRepository.DefaultRegion : result.Value);
		}
		Filter.RegionId = regionModel.Id;
		Filter.RegionName = regionModel.Name;
	}
}
