using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.Profile.Orders.Dto;
using Auchan.Common.Profile.Orders.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.Orders.Services;

internal class OrdersService : IOrdersService
{
	private readonly IOrdersApi _api;

	private readonly IEcomContext _ecomContext;

	private readonly IRequestExecutor _requestExecutor;

	public OrdersService(IOrdersApi api, IRequestExecutor requestExecutor, IEcomContext ecomContext)
	{
		_api = api;
		_requestExecutor = requestExecutor;
		_ecomContext = ecomContext;
	}

	public Task<Result<OrderModel, DomainError>> GetOrderAsync(long orderId)
	{
		return GetOrderAsync(orderId.ToString());
	}

	public async Task<Result<OrderModel, DomainError>> GetOrderAsync(string orderId)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.GetOrderAsync(orderId, t))).Map((OrderApiDto dto) => dto.ToModel(), (ServiceError err) => err.ToBaseDomainError()).Ensure<OrderModel, DomainError>((OrderModel m) => m != null, new NoDataError()).Map((OrderModel m) => m, (DomainError e) => e);
	}

	public async Task<Result<IReadOnlyList<OrderListModel>, DomainError>> GetOrdersAsync(int page, int perPage)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.GetOrdersAsync(page, perPage, t))).Map((OrdersDto dto) => dto.ToModel(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<Unit, DomainError>> RepeatOrderAsync(long orderId)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.RepeatOrderAsync(orderId, new RepeatCartRequest(_ecomContext.ActiveStore.Id.ToString()), t))).Map((object dto) => Unit.Default, (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<Unit, DomainError>> UpdateOrderAsync(long orderId, int arrived)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.UpdateOrderAsync(orderId, new UpdateCartRequest(_ecomContext.ActiveStore.Id.ToString(), arrived), t))).Map((object dto) => Unit.Default, (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<OrderCancellationResponseDto, DomainError>> CancelOrderAsync(long orderId, int cancellationReasonId, string? commentary = null)
	{
		return (await _requestExecutor.Execute((CancellationToken t) => _api.CancelOrderAsync(orderId, new OrderCancellationRequestDto(cancellationReasonId, commentary), t))).Map((OrderCancellationResponseDto dto) => dto, (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<IReadOnlyList<OrderToAdditionModel>, DomainError>> GetOrdersAvailableToAdditionAsync(CancellationToken cancellationToken)
	{
		return (await _requestExecutor.Execute((CancellationToken ct) => _api.GetOrdersAvailableToAddition(ct), cancellationToken)).Map((OrdersToAdditionDto dto) => dto.Data.Orders.ToModel(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<AddProductsToOrderPopupViewModel.Parameter, DomainError>> CheckAdditionItemsAsync(long orderId, IReadOnlyList<ProductOffer> offers, CancellationToken cancellationToken)
	{
		IEnumerable<AdditionItemsRequrestDto.ItemDto> items = from i in offers
			where i.Id.HasValue
			select new AdditionItemsRequrestDto.ItemDto
			{
				OfferId = i.Id.Value,
				ProductId = i.ProductId,
				Qty = i.Qty,
				BasketStep = i.BasketStep
			};
		Result<CheckAdditionItemsResponseDto, ServiceError> result = await _requestExecutor.Execute((CancellationToken ct) => _api.CheckAdditionItemsAsync(orderId, new AdditionItemsRequrestDto
		{
			Items = items.ToImmutableList()
		}, cancellationToken));
		if (result.TryGetValue(out var value))
		{
			if (value.Data != null)
			{
				return value.Data.ToModel();
			}
			return new NoDataError();
		}
		return result.Error.ToOrderAdditionError();
	}

	public async Task<Result<SuccessAdditionalOrderPopupViewModel.Parameter, DomainError>> AddGoodsToOrderAsync(long orderId, IReadOnlyList<AdditionalOrderProductItem> offers, CancellationToken cancellationToken)
	{
		IEnumerable<AdditionItemsRequrestDto.ItemDto> items = offers.Select((AdditionalOrderProductItem i) => new AdditionItemsRequrestDto.ItemDto
		{
			OfferId = i.Id,
			ProductId = i.ProductId,
			Qty = i.CurrentQty,
			BasketStep = i.BasketStep
		});
		Result<AddGoodsToOrderResposeDto, ServiceError> result = await _requestExecutor.Execute((CancellationToken ct) => _api.AddGoodsToOrderAsync(orderId, new AdditionItemsRequrestDto
		{
			Items = items.ToImmutableList()
		}, cancellationToken));
		if (result.TryGetValue(out var value))
		{
			if (value.Data != null && value.Data.Deliveries.Any())
			{
				return value.Data.ToModel();
			}
			return new NoDataError();
		}
		return result.Error.ToOrderAdditionError();
	}
}
