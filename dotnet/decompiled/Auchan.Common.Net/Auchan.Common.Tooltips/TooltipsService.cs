using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Tooltips;

public class TooltipsService : ITooltipsService
{
	private readonly ITooltipsApi _api;

	private readonly IAdminToolAuthorizer _authorizer;

	private readonly IRequestExecutor _requestExecutor;

	public TooltipsService(ITooltipsApi api, IAdminToolAuthorizer authorizer, IRequestExecutor requestExecutor)
	{
		_api = api;
		_authorizer = authorizer;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<Tooltip[], DomainError>> GetTooltips()
	{
		Result<string, ServiceError> tokenResult = await _authorizer.UdidKey();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<Tooltip[], DomainError>(tokenResult.Error.ToBaseDomainError());
		}
		return (await _requestExecutor.Execute((CancellationToken t) => _api.Tooltips(tokenResult.Value, t))).Ensure((List<TooltipDto> r) => r.Count > 0, new ApiContractError()).Map((List<TooltipDto> dto) => dto.Select((TooltipDto x) => x.ToModel()).ToArray(), (ServiceError err) => err.ToBaseDomainError());
	}
}
