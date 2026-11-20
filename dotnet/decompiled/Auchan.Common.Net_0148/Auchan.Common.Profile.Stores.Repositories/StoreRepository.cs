using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.Stores.Models;
using Auchan.Common.Profile.Stores.Services;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.Profile.Stores.Repositories;

public class StoreRepository : IStoreRepository
{
	private const string FullStoresCacheKey = "FULL_STORES_CACHE_KEY";

	public const string FullStoresServicesCacheKey = "STORES_SERVICES_CACHE_KEY";

	private readonly IFullStoreService _storeService;

	private readonly ICache _cache;

	public int RegionOfFirstStore { get; private set; } = -1;

	public StoreRepository(IFullStoreService storeService, ICache cache)
	{
		_storeService = storeService;
		_cache = cache;
	}

	public async Task<Result<List<FullStoreModel>, DomainError>> FromCacheOrApiAsync(string? searchText = null, FullStoreFilterModel? filter = null, Location? geoPosition = null)
	{
		Result<List<FullStoreModel>, DomainError> result = await FromCacheOrApiByGeoAsync(geoPosition);
		if (result.IsFailure)
		{
			return Result.Success<List<FullStoreModel>, DomainError>(new List<FullStoreModel>());
		}
		IEnumerable<FullStoreModel> enumerable = result.Value.AsEnumerable();
		if (!string.IsNullOrWhiteSpace(searchText))
		{
			searchText = searchText.Trim();
			enumerable = enumerable.Where((FullStoreModel c) => c.Address.ContainsIgnoreCase(searchText) || c.Name.ContainsIgnoreCase(searchText));
		}
		if (filter != null)
		{
			if (filter.RegionId.HasValue)
			{
				enumerable = enumerable.Where((FullStoreModel c) => c.RegionId == filter.RegionId.Value);
			}
			if (filter.StoreType.HasValue)
			{
				enumerable = enumerable.Where((FullStoreModel c) => c.StoreType == filter.StoreType);
			}
			if (filter.ServiceIds.Any())
			{
				enumerable = enumerable.Where((FullStoreModel c) => filter.ServiceIds.All((int serviceId) => c.Services.Any((FullStoreServiceModel service) => service.Id == serviceId)));
			}
		}
		if (geoPosition != null)
		{
			foreach (FullStoreModel item in enumerable)
			{
				if (item.Latitude != 0.0 && item.Longitude != 0.0)
				{
					Location locationEnd = new Location(item.Latitude, item.Longitude);
					item.DistanceFromGeo = Location.CalculateDistance(geoPosition, locationEnd, DistanceUnits.Kilometers);
				}
			}
			enumerable = enumerable.OrderBy((FullStoreModel store) => store.DistanceFromGeo);
		}
		return Result.Success<List<FullStoreModel>, DomainError>(enumerable.ToList());
	}

	public async Task<Result<List<FullStoreModel>, DomainError>> FromCacheOrApiByGeoAsync(Location? geoPosition)
	{
		Result<List<FullStoreModel>, DomainError> result = await GetStoresAsync(geoPosition);
		if (result.IsFailure)
		{
			return result;
		}
		return Result.Success<List<FullStoreModel>, DomainError>(result.Value);
	}

	public List<FullStoreModel> FilterStores(List<FullStoreModel> stores, string? searchText = null, FullStoreFilterModel? filter = null)
	{
		IEnumerable<FullStoreModel> source = stores.AsEnumerable();
		if (!string.IsNullOrWhiteSpace(searchText))
		{
			searchText = searchText.Trim();
			source = source.Where((FullStoreModel c) => c.Address.ContainsIgnoreCase(searchText) || c.Name.ContainsIgnoreCase(searchText));
		}
		if (filter != null)
		{
			if (filter.RegionId.HasValue)
			{
				source = source.Where((FullStoreModel c) => c.RegionId == filter.RegionId.Value);
			}
			if (filter.StoreType.HasValue)
			{
				source = source.Where((FullStoreModel c) => c.StoreType == filter.StoreType);
			}
			if (filter.ServiceIds.Any())
			{
				source = source.Where((FullStoreModel c) => filter.ServiceIds.All((int serviceId) => c.Services.Any((FullStoreServiceModel service) => service.Id == serviceId)));
			}
		}
		return source.ToList();
	}

	public async Task<Result<FullStoreModel, DomainError>> FromCacheOrApiByExternalIdAsync(int externalStoreId)
	{
		Result<List<FullStoreModel>, DomainError> result = await GetStoresAsync();
		if (result.IsSuccess)
		{
			FullStoreModel fullStoreModel = result.Value.FirstOrDefault((FullStoreModel c) => c.ExternalId == externalStoreId);
			return (fullStoreModel == null) ? Result.Failure<FullStoreModel, DomainError>(new ConnectionError()) : Result.Success<FullStoreModel, DomainError>(fullStoreModel);
		}
		return Result.Failure<FullStoreModel, DomainError>(result.Error);
	}

	public Task ClearCacheAsync()
	{
		return Task.WhenAll(_cache.Remove("FULL_STORES_CACHE_KEY"), _cache.Remove("STORES_SERVICES_CACHE_KEY"));
	}

	private async Task<Result<bool, DomainError>> LoadStoresAndServicesFromApiAsync(Location? geoPosition = null)
	{
		Result<(List<FullStoreModel>, List<FullStoreServiceModel>), DomainError> result = await _storeService.GetStoresAndServicesAsync(geoPosition);
		if (result.IsSuccess)
		{
			List<FullStoreModel> list;
			List<FullStoreServiceModel> services;
			(list, services) = result.Value;
			foreach (FullStoreModel item in list)
			{
				if (item.Latitude != 0.0 && item.Longitude != 0.0 && geoPosition != null)
				{
					item.DistanceFromGeo = Location.CalculateDistance(geoPosition, new Location(item.Latitude, item.Longitude), DistanceUnits.Kilometers);
				}
				else
				{
					item.DistanceFromGeo = double.MaxValue;
				}
			}
			List<FullStoreModel> list2 = list.OrderBy((FullStoreModel c) => c.DistanceFromGeo).ToList();
			RegionOfFirstStore = (list2.FirstOrDefault()?.RegionId).GetValueOrDefault();
			await _cache.Save("FULL_STORES_CACHE_KEY", list2, TimeSpan.FromSeconds(5L));
			await _cache.Save("STORES_SERVICES_CACHE_KEY", services, TimeSpan.FromDays(1));
			return Result.Success<bool, DomainError>(value: true);
		}
		return Result.Failure<bool, DomainError>(result.Error);
	}

	private async Task<Result<List<FullStoreModel>, DomainError>> GetStoresAsync(Location? geoPosition = null)
	{
		List<FullStoreModel> list = await _cache.TryGet<List<FullStoreModel>>("FULL_STORES_CACHE_KEY");
		if (list != null && list.Count > 0)
		{
			return Result.Success<List<FullStoreModel>, DomainError>(list);
		}
		Result<bool, DomainError> result = await LoadStoresAndServicesFromApiAsync(geoPosition);
		if (result.IsSuccess)
		{
			list = await _cache.TryGet<List<FullStoreModel>>("FULL_STORES_CACHE_KEY");
			if (list != null)
			{
				return Result.Success<List<FullStoreModel>, DomainError>(list);
			}
			return Result.Failure<List<FullStoreModel>, DomainError>(new NoDataError());
		}
		return Result.Failure<List<FullStoreModel>, DomainError>(result.Error);
	}

	public async Task<Result<List<FullStoreServiceModel>, DomainError>> GetServicesAsync()
	{
		List<FullStoreServiceModel> list = await _cache.TryGet<List<FullStoreServiceModel>>("STORES_SERVICES_CACHE_KEY");
		if (list != null)
		{
			return list;
		}
		Result<bool, DomainError> result = await LoadStoresAndServicesFromApiAsync();
		if (result.IsSuccess)
		{
			list = await _cache.TryGet<List<FullStoreServiceModel>>("STORES_SERVICES_CACHE_KEY");
			if (list != null)
			{
				return Result.Success<List<FullStoreServiceModel>, DomainError>(list);
			}
			return Result.Failure<List<FullStoreServiceModel>, DomainError>(new NoDataError());
		}
		return Result.Failure<List<FullStoreServiceModel>, DomainError>(result.Error);
	}
}
