using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Logs;
using Auchan.Common.Profile.Stores.Models;
using Auchan.Common.Profile.Stores.Services;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.Profile.Stores.Repositories;

public class SelfScanStoresRepository : ISelfScanStoresRepository
{
	private const string SelfScanStoresCacheKey = "SelfScanStoresCacheKey";

	private readonly IFullStoreService _storeService;

	private readonly ICache _cache;

	private readonly SemaphoreSlim _syncLock = new SemaphoreSlim(1);

	public SelfScanStoresRepository(IFullStoreService storeService, ICache cache, ILogService logService)
	{
		_storeService = storeService;
		_cache = cache;
	}

	public async Task<Result<List<FullStoreModel>, DomainError>> GetSelfScanStores(CancellationToken token = default(CancellationToken))
	{
		await _syncLock.WaitAsync();
		try
		{
			List<FullStoreModel> list = await _cache.TryGet<List<FullStoreModel>>("SelfScanStoresCacheKey");
			if (list != null)
			{
				return Result.Success<List<FullStoreModel>, DomainError>(list);
			}
			Result<List<FullStoreModel>, DomainError> apiRequest = await _storeService.GetSelfScanStores(token);
			if (apiRequest.IsSuccess)
			{
				await _cache.Save("SelfScanStoresCacheKey", apiRequest.Value, TimeSpan.FromDays(1));
			}
			return apiRequest;
		}
		finally
		{
			_syncLock.Release();
		}
	}

	public async Task<Result<List<FullStoreModel>, DomainError>> GetSelfScanStores(double latitude, double longitude, float? maxDistanceInKm = null, int? maxCount = null, CancellationToken token = default(CancellationToken))
	{
		Result<List<FullStoreModel>, DomainError> result = await GetSelfScanStores(token);
		if (result.IsFailure)
		{
			return result;
		}
		List<FullStoreModel> value = result.Value;
		for (int num = value.Count - 1; num >= 0; num--)
		{
			FullStoreModel fullStoreModel = value[num];
			if (fullStoreModel.Latitude == 0.0 || fullStoreModel.Longitude == 0.0)
			{
				value.RemoveAt(num);
			}
			else
			{
				double num2 = Location.CalculateDistance(latitude, longitude, fullStoreModel.Latitude, fullStoreModel.Longitude, DistanceUnits.Kilometers);
				if (maxDistanceInKm.HasValue && num2 > (double)maxDistanceInKm.Value)
				{
					value.RemoveAt(num);
				}
				else
				{
					fullStoreModel.DistanceFromGeo = num2;
				}
			}
		}
		if (value.Count > 0)
		{
			value.Sort((FullStoreModel x, FullStoreModel y) => x.DistanceFromGeo.CompareTo(y.DistanceFromGeo));
			if (maxCount.HasValue && maxCount > 0 && value.Count > maxCount)
			{
				int num3 = value.Count - maxCount.Value;
				int index = value.Count - num3;
				value.RemoveRange(index, num3);
			}
		}
		return Result.Success<List<FullStoreModel>, DomainError>(value).Ensure((List<FullStoreModel> x) => x.Count > 0, new NoDataError());
	}
}
