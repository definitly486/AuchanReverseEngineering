using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Mappers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgramLoymax;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Services;

public class LoyaltyProgramBalanceService : ILoyaltyProgramBalanceService
{
	private readonly ILoymaxLoyaltyApi _api;

	private readonly IRequestExecutor _requestExecutor;

	private readonly ITokenService _tokenService;

	public LoyaltyProgramBalanceService(ILoymaxLoyaltyApi api, ITokenService tokenService, IRequestExecutor requestExecutor)
	{
		_api = api;
		_tokenService = tokenService;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<LoyaltyCardEntity, DomainError>> GetBalanceAsync(int timeout)
	{
		Result<TokenModel, DomainError> tokenResult = await _tokenService.SavedToken80();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<LoyaltyCardEntity, DomainError>(tokenResult.Error);
		}
		return (await _requestExecutor.ExecuteWithCustomTimeout((CancellationToken t) => _api.Balance(tokenResult.Value.Token, t), timeout)).Map((BalanceDto dto) => dto.Map(), (ServiceError err) => err.ToBaseDomainError());
	}
}
