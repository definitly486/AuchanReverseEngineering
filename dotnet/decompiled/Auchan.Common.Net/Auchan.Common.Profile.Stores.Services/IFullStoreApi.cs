using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Profile.Stores.Dto;
using Refit;

namespace Auchan.Common.Profile.Stores.Services;

public interface IFullStoreApi
{
	[Get("/stores")]
	Task<List<FullStoreDto>> GetStores(CancellationToken cancellationToken = default(CancellationToken));

	[Get("/stores/{storeId}")]
	Task<FullStoreDto> GetStore(int storeId, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/services")]
	Task<List<FullStoreServiceDto>> GetAllServicesAsync([Header("User-Agent")] string userAgent, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/stores?scanning=true")]
	Task<List<FullStoreDto>> GetSelfScanStores(CancellationToken cancellationToken = default(CancellationToken));
}
