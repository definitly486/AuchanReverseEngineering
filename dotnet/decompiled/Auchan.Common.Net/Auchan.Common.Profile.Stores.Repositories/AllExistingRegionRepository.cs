using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.Address.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.Stores.Repositories;

public class AllExistingRegionRepository : RegionRepository, IAllExistingRegionRepository, IRegionRepository
{
	protected override string RegionsCacheKey => "ALL_EXISTING_REGIONS_CACHE_KEY";

	public AllExistingRegionRepository(ICache cache, IStoreService storeService)
		: base(cache, storeService)
	{
	}

	protected override async Task<Result<Cities, DomainError>> LoadFromApi()
	{
		Result<Cities, DomainError> regions = await _storeService.AllExistingRegions();
		if (regions.IsSuccess)
		{
			await SaveCache(regions.Value);
		}
		return regions;
	}
}
