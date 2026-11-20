using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.Profile.UserCards.DTO;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.UserCards;

public class UserCardsService : IUserCardsService
{
	private readonly IUserCardsApi _api;

	private readonly IRequestExecutor _requestExecutor;

	private readonly IUserContext _userContext;

	public UserCardsService(IUserCardsApi api, IUserContext userContext, IRequestExecutor requestExecutor)
	{
		_api = api;
		_userContext = userContext;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<List<CardModel>, DomainError>> GetCards()
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.Tokens(_userContext.Profile.MagentoAccountId.ToString(), t))).Map((TokenListResponseDto dto) => dto.ToModel(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<string, DomainError>> AddCardUrl(string callbackUrl)
	{
		CreateTokenRequestDto request = new CreateTokenRequestDto
		{
			RefNumber = $"{_userContext.Profile.MagentoAccountId}^{DateTime.UtcNow.ToTimestamp()}",
			TransactionType = "token",
			SignedDateTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssK"),
			CallbackUrl = callbackUrl
		};
		return (await _requestExecutor.Execute((CancellationToken t) => _api.CreateTokenValidate(request, t))).Map((CreateTokenResponseDto dto) => dto.TokenUrl, (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<List<CardModel>, DomainError>> RemoveCard(int id)
	{
		DeleteTokenRequestDto request = new DeleteTokenRequestDto
		{
			RefNumber = $"{_userContext.Profile.MagentoAccountId}^{DateTime.UtcNow.ToTimestamp()}",
			TokenId = id.ToString()
		};
		return (await _requestExecutor.Execute((CancellationToken t) => _api.DeleteToken(request, t))).Map((DeleteTokenResponseDto dto) => dto.ToModel(), (ServiceError err) => err.ToBaseDomainError());
	}
}
