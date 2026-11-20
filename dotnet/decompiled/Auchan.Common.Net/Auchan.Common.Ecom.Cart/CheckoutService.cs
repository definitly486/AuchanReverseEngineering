using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Cart;

internal sealed class CheckoutService : ICheckoutService
{
	private static readonly ServiceError s_defaultError = new ApiContractError();

	private readonly ICheckoutApi _checkoutApi;

	private readonly ICheckoutApiV2 _checkoutApiV2;

	private readonly IRequestExecutor _requestExecutor;

	public CheckoutService(ICheckoutApi checkoutApi, ICheckoutApiV2 checkoutApiV2, IRequestExecutor requestExecutor)
	{
		_checkoutApi = checkoutApi;
		_checkoutApiV2 = checkoutApiV2;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<RecalculateResult, DomainError>> RecalculateAsync(string? promocode, long? points, string? timeslotId, bool? stampDiscount, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (await _requestExecutor.ExecuteWithCustomTimeout<RecalculateResponseDto, ApiV2ResponseDto>(async (CancellationToken ct) => await _checkoutApiV2.RecalculateAsync(new RecalculateRequestDto
		{
			PromoCode = promocode,
			Points = points,
			TimeslotId = timeslotId,
			StampDiscount = stampDiscount
		}, ct), 30)).Ensure((RecalculateResponseDto dto) => dto.IsValid(), (RecalculateResponseDto dto) => new ApiContractError()).Map((RecalculateResponseDto dto) => dto.Map(), (ServiceError err) => err.ToRecalculateError());
	}

	public async Task<Result<CheckoutData, DomainError>> GetDataAsync(string? promoCode, long? points, bool? stampDiscount)
	{
		return (await _requestExecutor.ExecuteWithCustomTimeout<CheckoutDataResponseDto, ApiV2ResponseDto>(async (CancellationToken ct) => (await _checkoutApiV2.FullDataAsync(new CheckoutFullDataRequestDto
		{
			PromoCode = promoCode,
			Points = points,
			StampDiscount = stampDiscount
		}, ct)).GetVpnState(), 30)).Ensure((CheckoutDataResponseDto dto) => dto.IsValid(), (CheckoutDataResponseDto dto) => new ApiContractError()).Map((CheckoutDataResponseDto dto) => dto.Map(), (ServiceError err) => err.ToCheckoutFullDataError());
	}

	public async Task<Result<CheckoutCommitResultDto, DomainError>> Commit(CheckoutCommitDto commitData)
	{
		return (await _requestExecutor.Execute((CancellationToken cancellationToken) => _checkoutApi.Commit(commitData, cancellationToken))).Map((CheckoutCommitResultDto dto) => dto, (ServiceError err) => err.ToCheckoutCommitError());
	}

	public async Task<Result<CheckoutOrderDetails, DomainError>> OrderData(string orderId)
	{
		return (await _requestExecutor.Execute((CancellationToken ct) => _checkoutApi.OrderData(orderId, ct))).Map((OrderDetailsDto dto) => dto.Map(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<CheckoutOrderDetails, DomainError>[]> OrderData(IEnumerable<string> orderIds)
	{
		return await Task.WhenAll(orderIds.Select(async (string id) => (await _requestExecutor.Execute((CancellationToken cancellationToken) => _checkoutApi.OrderData(id, cancellationToken))).Ensure((OrderDetailsDto x) => x != null, s_defaultError).Ensure(delegate(OrderDetailsDto x)
		{
			IReadOnlyList<Delivery>? deliveries = x.Deliveries;
			return deliveries != null && deliveries.Count > 0;
		}, s_defaultError).Ensure(delegate(OrderDetailsDto x)
		{
			IReadOnlyList<Payment>? payments = x.Payments;
			return payments != null && payments.Count > 0;
		}, s_defaultError)
			.Ensure((OrderDetailsDto x) => x.Shop != null, s_defaultError)
			.Map((OrderDetailsDto x) => x.Map(), (ServiceError x) => x.ToBaseDomainError())));
	}
}
