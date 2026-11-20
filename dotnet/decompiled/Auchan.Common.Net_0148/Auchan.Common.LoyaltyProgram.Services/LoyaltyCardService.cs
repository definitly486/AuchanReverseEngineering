using System;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Dtos;
using Auchan.Common.LoyaltyProgram.Extensions;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.Services.Infrastructure;
using Auchan.Common.LoyaltyProgramLoymax;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.DomainModels;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Services;

public class LoyaltyCardService : ILoyaltyCardService
{
	private readonly ILoyaltyProgramApi _api;

	private readonly IRequestExecutor _requestExecutor;

	[Obsolete]
	private readonly ILoyaltyProgramRequestsProvider _requestsProvider;

	private readonly ITokenService _tokenService;

	private readonly ILoymaxLoyaltyApi _loymaxLoyaltyApi;

	private readonly IUserContext _userContext;

	public LoyaltyCardService(ILoyaltyProgramRequestsProvider requestsProvider, ILoyaltyProgramApi api, IRequestExecutor requestExecutor, ITokenService tokenService, ILoymaxLoyaltyApi loymaxLoyaltyApi, IUserContext userContext)
	{
		_requestsProvider = requestsProvider;
		_api = api;
		_requestExecutor = requestExecutor;
		_tokenService = tokenService;
		_loymaxLoyaltyApi = loymaxLoyaltyApi;
		_userContext = userContext;
	}

	public async Task<Result<LoyaltyProgramQrCodeResponseDto, DomainError>> GetLoyaltyCode(CancellationToken token, int timeout)
	{
		Result<TokenModel, DomainError> tokenResult = await _tokenService.SavedToken80();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<LoyaltyProgramQrCodeResponseDto, DomainError>(tokenResult.Error);
		}
		return (await _requestExecutor.ExecuteWithCustomTimeout((CancellationToken t) => _loymaxLoyaltyApi.GetQrCode(tokenResult.Value.Token, t), timeout, token)).Map((LoyaltyProgramQrCodeResponseDto dto) => dto, (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<Unit, DomainError>> BlockCardAsync()
	{
		Result<TokenModel, DomainError> tokenResult = await _tokenService.SavedToken80();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<Unit, DomainError>(tokenResult.Error);
		}
		return (await _requestExecutor.Execute((CancellationToken t) => _api.BlockCard(tokenResult.Value.Token, _requestsProvider.GetLoyaltyCardBlockDto(), t))).Map((LoyaltyProgramBlockCardResponseDto dto) => Unit.Default, (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<Unit, DomainError>> BlockAndReissueCardAsync(string? cardNumber, string? cardCvvNamber)
	{
		Result<TokenModel, DomainError> tokenResult = await _tokenService.SavedToken80();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<Unit, DomainError>(tokenResult.Error);
		}
		object requestBody = ((cardNumber != null) ? new
		{
			card_number = cardNumber,
			cvc_code = cardCvvNamber
		} : null);
		return (await _requestExecutor.Execute((CancellationToken t) => _loymaxLoyaltyApi.LoyaltyCardMerge(requestBody, tokenResult.Value.Token, t))).Map((LoymaxResponseBaseDto dto) => Unit.Default, (ServiceError err) => err.ToCardMergeError());
	}

	public Task<Result<LoyaltyEnrollmentModel, DomainError>> EnrollVirtualCard(LoyaltyEnrollmentRequestDto.ChannelDto fromChannel)
	{
		return EnrollVirtualCard(_userContext.Profile, fromChannel);
	}

	public async Task<Result<LoyaltyEnrollmentModel, DomainError>> EnrollVirtualCard(ProfileModel profileModel, LoyaltyEnrollmentRequestDto.ChannelDto fromChannel)
	{
		Result<TokenModel, DomainError> tokenResult = await _tokenService.SavedToken80();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<LoyaltyEnrollmentModel, DomainError>(tokenResult.Error);
		}
		LoyaltyEnrollmentRequestDto requestBody = new LoyaltyEnrollmentRequestDto
		{
			Profile = profileModel.ToProfileSnackCaseDto(),
			Channel = fromChannel
		};
		return (await _requestExecutor.Execute((CancellationToken t) => _loymaxLoyaltyApi.LoyaltyEnrollment(requestBody, tokenResult.Value.Token, t))).Map((LoyaltyEnrollmentDtos dto) => new LoyaltyEnrollmentModel(null, dto.Data?.VirtualCardNumber, dto.Data?.CardNumber), (ServiceError err) => err.ToCardEnrollError());
	}

	public async Task<Result<LoyaltyEnrollmentModel, DomainError>> EnrollPlasticCard(LoyaltyCardEntity card)
	{
		Result<TokenModel, DomainError> tokenResult = await _tokenService.SavedToken80();
		if (tokenResult.IsFailure)
		{
			return Result.Failure<LoyaltyEnrollmentModel, DomainError>(tokenResult.Error);
		}
		LoyaltyEnrollmentRequestDto requestBody = new LoyaltyEnrollmentRequestDto
		{
			Profile = _userContext.Profile.ToProfileSnackCaseDto(),
			CardNumber = card.CardNumber,
			CvcCode = card.Cvc,
			Channel = LoyaltyEnrollmentRequestDto.ChannelDto.MobileApplication
		};
		return (await _requestExecutor.Execute((CancellationToken t) => _loymaxLoyaltyApi.LoyaltyEnrollment(requestBody, tokenResult.Value.Token, t))).Map((LoyaltyEnrollmentDtos dto) => new LoyaltyEnrollmentModel(null, dto.Data?.VirtualCardNumber, dto.Data?.CardNumber), (ServiceError err) => err.ToCardEnrollError());
	}
}
