using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Profile.Stores.Models;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.Profile.Stores.Services;

public interface IFullStoreService
{
	Task<Result<(List<FullStoreModel>, List<FullStoreServiceModel>), DomainError>> GetStoresAndServicesAsync(Location? geoPosition = null);

	Task<Result<List<FullStoreModel>, DomainError>> GetSelfScanStores(CancellationToken token = default(CancellationToken));
}
