using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Dtos;
using Auchan.Common.LoyaltyProgram.Mappers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Services.TransactionDetails;

public class TransactionDetailsService : ITransactionDetailsService
{
	private readonly ILoyaltyProgramApi _api;

	private readonly IRequestExecutor _requestExecutor;

	private readonly ITokenService _tokenService;

	public TransactionDetailsService(ITokenService tokenService, ILoyaltyProgramApi api, IRequestExecutor requestExecutor)
	{
		_api = api;
		_requestExecutor = requestExecutor;
		_tokenService = tokenService;
	}

	public async Task<Result<LoyaltyTransactionDetails, DomainError>> GetTransactionDetails(string transactionId)
	{
		Result<TokenModel, DomainError> tokenResult = await _tokenService.SavedToken80();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<LoyaltyTransactionDetails, DomainError>(tokenResult.Error);
		}
		return (await _requestExecutor.Execute((CancellationToken t) => _api.TransactionDetails(tokenResult.Value, transactionId, t))).Map((TransactionDetailsDto dto) => dto.MapTransaction(), (ServiceError err) => err.ToBaseDomainError());
	}
}
