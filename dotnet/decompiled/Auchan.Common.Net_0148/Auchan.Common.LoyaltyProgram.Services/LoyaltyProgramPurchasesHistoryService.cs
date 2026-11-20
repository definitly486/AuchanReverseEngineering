using System.Collections.Generic;
using System.Linq;
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
using Auchan.Common.Reviews.Api.Ecom.Dto;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Services;

public class LoyaltyProgramPurchasesHistoryService : ILoyaltyProgramPurchasesHistoryService
{
	private readonly ILoymaxLoyaltyApi _api;

	private readonly IRequestExecutor _requestExecutor;

	private readonly ITokenService _tokenService;

	public LoyaltyProgramPurchasesHistoryService(ITokenService tokenService, ILoymaxLoyaltyApi api, IRequestExecutor requestExecutor)
	{
		_api = api;
		_requestExecutor = requestExecutor;
		_tokenService = tokenService;
	}

	public async Task<Result<LoyaltyProgramPurchase, DomainError>> GetTransactionDetailsAsync(string chequeNumber)
	{
		Result<TokenModel, DomainError> tokenResult = await _tokenService.SavedToken80();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<LoyaltyProgramPurchase, DomainError>(tokenResult.Error);
		}
		var requestBody = new
		{
			channel = "M",
			pagination = new OffsetPaginationDto
			{
				Offset = 0,
				Limit = 1
			},
			filter = new { chequeNumber }
		};
		Result<LoymaxHistoryResponseDto, ServiceError> result = await _requestExecutor.ExecuteWithCustomTimeout((CancellationToken t) => _api.LoyaltyHistory(requestBody, tokenResult.Value.Token, t), 60);
		if (result.IsSuccess && (result.Value.Data?.Items == null || result.Value.Data.Items.Count() == 0))
		{
			return Result.Failure<LoyaltyProgramPurchase, DomainError>(new NoDataError());
		}
		return result.Map((LoymaxHistoryResponseDto dto) => dto.Data.Items.First().MapPurchase(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<(IEnumerable<LoyaltyProgramPurchase>, int, HistoryFilter[]?), DomainError>> GetHistoryAsync(HistoryFilter? filter, int offset, int limit)
	{
		Result<TokenModel, DomainError> tokenResult = await _tokenService.SavedToken80();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<(IEnumerable<LoyaltyProgramPurchase>, int, HistoryFilter[]), DomainError>(tokenResult.Error);
		}
		int? id = filter?.Id;
		if (filter != null && filter.Id == 0)
		{
			id = null;
		}
		var requestBody = new
		{
			channel = "M",
			pagination = new OffsetPaginationDto
			{
				Offset = offset,
				Limit = limit
			},
			filter = new { id }
		};
		Result<LoymaxHistoryResponseDto, ServiceError> result = await _requestExecutor.ExecuteWithCustomTimeout((CancellationToken t) => _api.LoyaltyHistory(requestBody, tokenResult.Value.Token, t), 60);
		if (result.IsSuccess && result.Value.Data?.Items == null)
		{
			return Result.Failure<(IEnumerable<LoyaltyProgramPurchase>, int, HistoryFilter[]), DomainError>(new NoDataError());
		}
		return result.Map((LoymaxHistoryResponseDto dto) => dto.Map(), (ServiceError err) => err.ToBaseDomainError());
	}
}
