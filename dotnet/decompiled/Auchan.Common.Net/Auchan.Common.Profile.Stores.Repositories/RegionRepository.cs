using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Profile.Stores.Infrastructure;
using Auchan.Common.Profile.Stores.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.Stores.Repositories;

public class RegionRepository : IRegionRepository
{
	private readonly ICache _cache;

	private protected readonly IStoreService _storeService;

	protected virtual string RegionsCacheKey => "REGIONS_CACHE_KEY";

	public RegionModel DefaultRegion { get; } = new RegionModel
	{
		Name = "Москва и область",
		Id = 1
	};

	public RegionRepository(ICache cache, IStoreService storeService)
	{
		_cache = cache;
		_storeService = storeService;
	}

	public async Task<Result<List<RegionModel>, DomainError>> FromCacheOrApiAsync()
	{
		IReadOnlyList<City> readOnlyList = await RestoreCacheAsync();
		if (readOnlyList == null || readOnlyList.Count <= 0)
		{
			return Result.Success<List<RegionModel>, DomainError>(new List<RegionModel>());
		}
		return Result.Success<List<RegionModel>, DomainError>(readOnlyList.ToModel().ToList());
	}

	public async Task<Result<RegionModel, DomainError>> FromCacheAsync(int regionId)
	{
		City city = (await RestoreCacheAsync()).FirstOrDefault((City c) => c.EcomId == regionId);
		return (city == null) ? Result.Failure<RegionModel, DomainError>(new UnknownError()) : Result.Success<RegionModel, DomainError>(city.ToModel());
	}

	public async Task UpdateCacheOrNothingAsync()
	{
		DateTimeOffset? dateTimeOffset = await _cache.GetCreatedAt(RegionsCacheKey);
		if (!dateTimeOffset.HasValue || (dateTimeOffset.HasValue && IsMoreThenOnDayAgo(dateTimeOffset.Value.UtcDateTime)))
		{
			await LoadFromApi();
		}
	}

	public async Task ClearCacheAsync()
	{
		await _cache.Remove(RegionsCacheKey);
	}

	private async Task<IReadOnlyList<City>> RestoreCacheAsync()
	{
		IReadOnlyList<City> readOnlyList = await _cache.TryGet<IReadOnlyList<City>>(RegionsCacheKey);
		if (readOnlyList != null && readOnlyList.Any())
		{
			return readOnlyList;
		}
		Result<Cities, DomainError> result = await LoadFromApi();
		if (result.IsFailure)
		{
			return Array.Empty<City>();
		}
		return result.Value;
	}

	protected virtual async Task<Result<Cities, DomainError>> LoadFromApi()
	{
		Result<Cities, DomainError> regions = await _storeService.Cities();
		if (regions.IsSuccess)
		{
			await SaveCache(regions.Value);
		}
		return regions;
	}

	protected async Task SaveCache(IReadOnlyList<City> regions)
	{
		await _cache.Save(RegionsCacheKey, regions);
	}

	private bool IsMoreThenOnDayAgo(DateTime dateTime)
	{
		return dateTime.Date != DateTime.UtcNow.Date;
	}
}
