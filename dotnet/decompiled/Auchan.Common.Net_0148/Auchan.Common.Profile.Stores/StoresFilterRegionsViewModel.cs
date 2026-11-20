using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Profile.Stores.Models;
using Auchan.Common.Profile.Stores.Repositories;
using Auchan.Common.Profile.Stores.Services;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.Stores;

public class StoresFilterRegionsViewModel : ScreenViewModel
{
	public class Result
	{
		public string RegionName { get; set; }

		public Result(string regionName)
		{
			RegionName = regionName;
		}
	}

	private readonly IFullStoreFilterService _fullStoreFilter;

	private readonly IAllExistingRegionRepository _regionRepository;

	private Action<Result> _onResult;

	public FullStoreFilterModel Filter => _fullStoreFilter.Filter;

	public ObservableRangeCollection<StoresFilterRegionItemViewModel> Regions { get; } = new ObservableRangeCollection<StoresFilterRegionItemViewModel>();

	public StoresFilterRegionsViewModel(IFullStoreFilterService fullStoreFilter, IAllExistingRegionRepository regionRepository, Action<Result> onResult)
	{
		_fullStoreFilter = fullStoreFilter;
		_regionRepository = regionRepository;
		_onResult = onResult;
	}

	protected override async Task Start()
	{
		await Task.WhenAll(base.Start(), LoadRegions());
	}

	protected override async Task OnResumed()
	{
		await Task.WhenAll(base.OnResumed(), LoadRegions());
	}

	public async Task LoadRegions()
	{
		if (Regions.Any())
		{
			return;
		}
		Result<List<RegionModel>, DomainError> result = await _regionRepository.FromCacheOrApiAsync();
		if (!result.IsFailure)
		{
			Regions.ReplaceRange(result.Value.Select((RegionModel c) => new StoresFilterRegionItemViewModel(c)));
		}
	}

	public void ApplyFilter()
	{
		_fullStoreFilter.Apply(isFilterIconChange: false);
		_onResult(new Result(_fullStoreFilter.Filter.RegionName));
	}

	public void SetRegionsId(int regionId, string regionName)
	{
		_fullStoreFilter.SetRegion(regionId, regionName);
	}
}
