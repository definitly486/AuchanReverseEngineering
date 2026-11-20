using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Ecom.PriceChecker.Dto;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.PriceChecker;

public class PriceCheckerService
{
	private readonly IRequestExecutor _requestExecutor;

	private readonly IPriceCheckerApi _priceCheckerApi;

	private readonly IPriceCheckerEventsApi _priceCheckerEventsApi;

	public PriceCheckerService(IPriceCheckerApi priceCheckerApi, IRequestExecutor requestExecutor, IPriceCheckerEventsApi priceCheckerEventsApi)
	{
		_priceCheckerApi = priceCheckerApi;
		_requestExecutor = requestExecutor;
		_priceCheckerEventsApi = priceCheckerEventsApi;
	}

	public async Task<Result<PriceCheckerResponseDto, PriceCheckerError>> ProductByEan(PriceCheckerRequestDto requestDto)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _priceCheckerApi.ProductByEan(requestDto, t))).Map((PriceCheckerResponseDto x) => x, (ServiceError serviceError) => serviceError.ToPriceCheckerError());
	}

	public async Task<Result<Unit, DomainError>> Events(PriceCheckerMiddleWareEventDto requestDto)
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel token) => _priceCheckerEventsApi.Events(token, requestDto, cancellationToken))).Map((object x) => Unit.Default, (ServiceError x) => x.ToBaseDomainError());
	}

	public async Task<Result<Unit, DomainError>> Events(PriceCheckerMiddleWareEventDtoAfterOpenPricechecker requestDto)
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel token) => _priceCheckerEventsApi.Events(token, requestDto, cancellationToken))).Map((object x) => Unit.Default, (ServiceError x) => x.ToBaseDomainError());
	}
}
