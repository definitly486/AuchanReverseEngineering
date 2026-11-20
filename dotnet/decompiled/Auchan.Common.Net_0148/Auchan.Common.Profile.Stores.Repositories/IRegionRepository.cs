using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Profile.Stores.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.Stores.Repositories;

public interface IRegionRepository
{
	RegionModel DefaultRegion { get; }

	Task UpdateCacheOrNothingAsync();

	Task<Result<List<RegionModel>, DomainError>> FromCacheOrApiAsync();

	Task<Result<RegionModel, DomainError>> FromCacheAsync(int regionId);

	Task ClearCacheAsync();
}
