using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Dtos;
using Auchan.Common.LoyaltyProgram.Mappers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.Services.Infrastructure;
using Auchan.Common.LoyaltyProgramLoymax;
using Auchan.Common.Networking;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Services;

public class LoyaltySocialStatusService : ILoyaltySocialStatusService
{
	private readonly ILoymaxLoyaltyApi _loymaxLoyaltyApi;

	private readonly IRequestExecutor _requestExecutor;

	private readonly ILoyaltyProgramRequestsProvider _requestsProvider;

	public LoyaltySocialStatusService(ILoyaltyProgramRequestsProvider requestsProvider, IRequestExecutor requestExecutor, ILoymaxLoyaltyApi loymaxLoyaltyApi)
	{
		_requestsProvider = requestsProvider;
		_requestExecutor = requestExecutor;
		_loymaxLoyaltyApi = loymaxLoyaltyApi;
	}

	public async Task<Result<LoyaltyProgramSocialStatusResponse, DomainError>> GetSocialStatusAsync(int timeout = 15)
	{
		Result<LoyaltyProgramCommonRequestDto, DomainError> requestDto = await _requestsProvider.GetLoyaltyProgramRequestDto();
		if (requestDto.IsFailure)
		{
			return Result.Failure<LoyaltyProgramSocialStatusResponse, DomainError>(requestDto.Error);
		}
		return (await _requestExecutor.ExecuteWithCustomTimeout((CancellationToken t) => _loymaxLoyaltyApi.SocialStatus(requestDto.Value.AccessToken ?? string.Empty, t), timeout)).Map((SocialStatusDto dto) => dto.Map(), (ServiceError err) => err.ToBaseDomainError());
	}
}
