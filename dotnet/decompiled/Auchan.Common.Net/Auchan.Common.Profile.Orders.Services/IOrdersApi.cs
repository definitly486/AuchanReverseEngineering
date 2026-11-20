using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Profile.Orders.Dto;
using Refit;

namespace Auchan.Common.Profile.Orders.Services;

internal interface IOrdersApi
{
	[Get("/lk/orders")]
	Task<OrdersDto> GetOrdersAsync([Query("page")] int page, [Query("perPage")] int perPage, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/lk/orders/{orderId}")]
	Task<OrderApiDto> GetOrderAsync(string orderId, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/lk/orders/{orderId}/repeat")]
	Task<object> RepeatOrderAsync(long orderId, [Body] RepeatCartRequest merchantId, CancellationToken cancellationToken = default(CancellationToken));

	[Put("/lk/orders/{orderId}")]
	Task<object> UpdateOrderAsync(long orderId, [Body] UpdateCartRequest request, CancellationToken cancellationToken = default(CancellationToken));

	[Post("/lk/orders/{orderId}/cancel")]
	Task<OrderCancellationResponseDto> CancelOrderAsync(long orderId, [Body] OrderCancellationRequestDto request, CancellationToken cancellationToken = default(CancellationToken));

	[Get("/oms/addition-available-orders")]
	Task<OrdersToAdditionDto> GetOrdersAvailableToAddition(CancellationToken cancellationToken);

	[Post("/lk/orders/{orderId}:check-addition-items")]
	Task<CheckAdditionItemsResponseDto> CheckAdditionItemsAsync(long orderId, [Body] AdditionItemsRequrestDto request, CancellationToken cancellationToken);

	[Post("/lk/orders/{orderId}:addition")]
	Task<AddGoodsToOrderResposeDto> AddGoodsToOrderAsync(long orderId, [Body] AdditionItemsRequrestDto request, CancellationToken cancellationToken);
}
