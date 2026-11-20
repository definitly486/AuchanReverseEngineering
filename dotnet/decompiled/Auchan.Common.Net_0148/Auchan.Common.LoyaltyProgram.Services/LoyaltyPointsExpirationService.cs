using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Cache;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Mappers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgramLoymax;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.Reviews.Api.Ecom.Dto;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Services;

public class LoyaltyPointsExpirationService : ILoyaltyPointsExpirationService
{
	private const string ExpirationCacheKey = "loyalty_expiration_cache";

	private const string DelayedCacheKey = "loyalty_delayed_points_cache";

	private readonly ILoymaxLoyaltyApi _loymaxApi;

	private readonly ICache _cache;

	private readonly IRequestExecutor _requestExecutor;

	private readonly ITokenService _tokenService;

	private readonly SemaphoreSlim _lock = new SemaphoreSlim(1);

	public LoyaltyPointsExpirationService(ITokenService tokenService, ILoymaxLoyaltyApi loymaxApi, IRequestExecutor requestExecutor, ICache cache, IUserContext userContext)
	{
		_tokenService = tokenService;
		_loymaxApi = loymaxApi;
		_requestExecutor = requestExecutor;
		_cache = cache;
		userContext.AfterLoggedOut += delegate
		{
			_cache.Remove("loyalty_expiration_cache");
			return Task.CompletedTask;
		};
	}

	public async Task<Result<IEnumerable<ExpirationPointsEntity>, DomainError>> GetPointsExpirationsAsync(LoyaltyCurrencyDto[] currencies, int timeout = 15)
	{
		await _lock.WaitAsync();
		try
		{
			Result<ExpirationPointsEntity[], DomainError> request = await RequestPointsExpirationsAsync(currencies, timeout);
			if (request.IsFailure)
			{
				ExpirationPointsEntity[] array = await _cache.TryGet<ExpirationPointsEntity[]>("loyalty_expiration_cache");
				if (array == null)
				{
					return Result.Failure<IEnumerable<ExpirationPointsEntity>, DomainError>(request.Error);
				}
				return Result.Success<IEnumerable<ExpirationPointsEntity>, DomainError>(array);
			}
			IEnumerable<ExpirationPointsEntity> expirationEntity = request.Value.Where((ExpirationPointsEntity p) => p.PointType != ExpirationPointType.Stamps);
			await _cache.Save("loyalty_expiration_cache", expirationEntity);
			return Result.Success<IEnumerable<ExpirationPointsEntity>, DomainError>(expirationEntity);
		}
		finally
		{
			_lock.Release();
		}
	}

	public async Task<Result<(IEnumerable<ExpirationPointsEntity>, int), DomainError>> GetPointsExpirationsAsync(LoyaltyCurrencyDto[] currencies, int offset = 0, int limit = 100, int timeout = 15)
	{
		await _lock.WaitAsync();
		try
		{
			Result<(ExpirationPointsEntity[], int), DomainError> result = await RequestPointsExpirationsAsync(currencies, offset, limit, timeout);
			if (result.IsFailure)
			{
				return Result.Failure<(IEnumerable<ExpirationPointsEntity>, int), DomainError>(result.Error);
			}
			ExpirationPointsEntity[] array = result.Value.Item1.Where((ExpirationPointsEntity p) => p.PointType != ExpirationPointType.Stamps).ToArray();
			if (!array.Any())
			{
				return Result.Failure<(IEnumerable<ExpirationPointsEntity>, int), DomainError>(new NoDataError());
			}
			return Result.Success<(IEnumerable<ExpirationPointsEntity>, int), DomainError>((array, result.Value.Item2));
		}
		finally
		{
			_lock.Release();
		}
	}

	public async Task<Result<(IEnumerable<DelayedPointsEntryEntity>, int), DomainError>> GetDelayedPointsAsync(LoyaltyCurrencyDto[] currencies, int offset, int limit, int timeout = 15)
	{
		await _lock.WaitAsync();
		try
		{
			return await RequestDelayedPointsAsync(currencies, offset, limit, timeout);
		}
		finally
		{
			_lock.Release();
		}
	}

	private async Task<Result<ExpirationPointsEntity[], DomainError>> RequestPointsExpirationsAsync(LoyaltyCurrencyDto[] currencies, int timeout = 15)
	{
		Result<TokenModel, DomainError> tokenResult = await _tokenService.SavedToken80();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<ExpirationPointsEntity[], DomainError>(tokenResult.Error);
		}
		LoyaltyOperationsRequestBodyDto body = new LoyaltyOperationsRequestBodyDto
		{
			Filter = new LoyaltyOperationsFilterDto
			{
				ExpirationCurrencyList = currencies
			}
		};
		return (await _requestExecutor.ExecuteWithCustomTimeout((CancellationToken t) => _loymaxApi.LoyaltyPointsOperations(body, tokenResult.Value.Token, t), timeout)).Map((LoyaltyOperationsResponseDto dto) => dto.Map(), (ServiceError err) => err.ToBaseDomainError());
	}

	private async Task<Result<(ExpirationPointsEntity[], int), DomainError>> RequestPointsExpirationsAsync(LoyaltyCurrencyDto[] currencies, int offset, int limit, int timeout = 15)
	{
		Result<TokenModel, DomainError> tokenResult = await _tokenService.SavedToken80();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<(ExpirationPointsEntity[], int), DomainError>(tokenResult.Error);
		}
		LoyaltyOperationsRequestBodyDto body = new LoyaltyOperationsRequestBodyDto
		{
			Filter = new LoyaltyOperationsFilterDto
			{
				ExpirationCurrencyList = currencies
			},
			Pagination = new OffsetPaginationDto
			{
				Type = "offset",
				Offset = offset,
				Limit = limit
			}
		};
		return (await _requestExecutor.ExecuteWithCustomTimeout((CancellationToken t) => _loymaxApi.LoyaltyPointsOperations(body, tokenResult.Value.Token, t), timeout)).Map((LoyaltyOperationsResponseDto dto) => (dto.Map(), (dto.Meta?.Pagination?.Total).GetValueOrDefault()), (ServiceError err) => err.ToBaseDomainError());
	}

	private async Task<Result<(IEnumerable<DelayedPointsEntryEntity>, int), DomainError>> RequestDelayedPointsAsync(LoyaltyCurrencyDto[] currencies, int offset, int limit, int timeout = 15)
	{
		Result<TokenModel, DomainError> tokenResult = await _tokenService.SavedToken80();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<(IEnumerable<DelayedPointsEntryEntity>, int), DomainError>(tokenResult.Error);
		}
		LoyaltyOperationsRequestBodyDto body = new LoyaltyOperationsRequestBodyDto
		{
			Filter = new LoyaltyOperationsFilterDto
			{
				ActivationCurrencyList = currencies
			},
			Pagination = new OffsetPaginationDto
			{
				Type = "offset",
				Offset = offset,
				Limit = limit
			}
		};
		return (await _requestExecutor.ExecuteWithCustomTimeout((CancellationToken t) => _loymaxApi.LoyaltyPointsOperations(body, tokenResult.Value.Token, t), timeout)).Map((LoyaltyOperationsResponseDto dto) => dto.MapDelayed(), (ServiceError err) => err.ToBaseDomainError());
	}
}
