using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Custom;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Dtos;
using Auchan.Common.LoyaltyProgramLoymax;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Services;

public class PointsTransferService : IPointsTransferService
{
	private readonly ILoymaxLoyaltyApi _loyaltyProgramApi;

	private readonly ITokenService _tokenService;

	private readonly IRequestExecutor _requestExecutor;

	public PointsTransferService(ILoymaxLoyaltyApi loyaltyProgramApi, ITokenService tokenService, IRequestExecutor requestExecutor)
	{
		_loyaltyProgramApi = loyaltyProgramApi;
		_tokenService = tokenService;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<PointsTransferResponseDto, PointsTransactionError>> TransferPointsAsync(string? phone, int amount, string code)
	{
		Result<TokenModel, DomainError> tokenResult = await _tokenService.SavedToken80();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<PointsTransferResponseDto, PointsTransactionError>(new PointsTransactionError(tokenResult.Error.WrapIntoServiceError()));
		}
		object body = new
		{
			phone_number = phone,
			points = new { amount, code }
		};
		return (await _requestExecutor.Execute((CancellationToken t) => _loyaltyProgramApi.TransferPoints(tokenResult.Value.Token, body, t))).Map((PointsTransferResponseDto dto) => dto, (ServiceError err) => new PointsTransactionError(err));
	}
}
