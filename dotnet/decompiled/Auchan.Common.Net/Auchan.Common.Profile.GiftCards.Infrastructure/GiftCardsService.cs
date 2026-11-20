using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.Profile.GiftCards.Errors;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.GiftCards.Infrastructure;

public class GiftCardsService
{
	private readonly IRequestExecutor _requestExecutor;

	private readonly IGiftCardsApi _api;

	public GiftCardsService(IRequestExecutor requestExecutor, IGiftCardsApi api)
	{
		_requestExecutor = requestExecutor;
		_api = api;
	}

	public async Task<Result<GiftCardDataDTO, DomainError>> GiftCardData(string number, string pin)
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken ct, TokenModel token) => _api.GiftCardData(token, number, pin, ct))).Map((GiftCardDataDTO dto) => dto, (ServiceError error) => error.ToGiftCardError());
	}
}
