using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Profile.Stores.Models;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.Profile.Stores.Repositories;

public interface IStoreRepository
{
	int RegionOfFirstStore { get; }

	Task<Result<List<FullStoreModel>, DomainError>> FromCacheOrApiByGeoAsync(Location? geoPosition);

	Task<Result<List<FullStoreModel>, DomainError>> FromCacheOrApiAsync(string? searchText = null, FullStoreFilterModel? filter = null, Location? geoPosition = null);

	List<FullStoreModel> FilterStores(List<FullStoreModel> stores, string? searchText = null, FullStoreFilterModel? filter = null);

	Task<Result<FullStoreModel, DomainError>> FromCacheOrApiByExternalIdAsync(int externalStoreId);

	Task ClearCacheAsync();

	Task<Result<List<FullStoreServiceModel>, DomainError>> GetServicesAsync();
}
