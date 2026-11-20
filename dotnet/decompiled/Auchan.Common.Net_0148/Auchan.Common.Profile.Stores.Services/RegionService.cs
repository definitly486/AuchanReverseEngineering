using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.Profile.Stores.Dto;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.Stores.Services;

public class RegionService : IRegionService
{
	private readonly IRegionApi _api;

	private readonly IRequestExecutor _requestExecutor;

	public RegionService(IRegionApi api, IRequestExecutor requestExecutor)
	{
		_api = api;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<List<FullRegionDto>, DomainError>> GetRegionAsync()
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.GetRegions(t))).Map((List<FullRegionDto> dto) => dto, (ServiceError err) => err.ToBaseDomainError());
	}
}
