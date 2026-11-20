using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Profile.Stores.Dto;
using Refit;

namespace Auchan.Common.Profile.Stores.Services;

public interface IRegionApi
{
	[Get("/regions")]
	Task<List<FullRegionDto>> GetRegions(CancellationToken cancellationToken = default(CancellationToken));
}
