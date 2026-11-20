using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Profile.Stores.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.Stores.Repositories;

public interface ISelfScanStoresRepository
{
	Task<Result<List<FullStoreModel>, DomainError>> GetSelfScanStores(CancellationToken token = default(CancellationToken));

	Task<Result<List<FullStoreModel>, DomainError>> GetSelfScanStores(double latitude, double longitude, float? maxDistanceInKm = null, int? maxCount = null, CancellationToken token = default(CancellationToken));
}
