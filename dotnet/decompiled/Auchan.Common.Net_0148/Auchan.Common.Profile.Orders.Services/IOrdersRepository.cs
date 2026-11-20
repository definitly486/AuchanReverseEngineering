using System.Collections.Generic;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Profile.Orders.Dto;
using Auchan.Common.Profile.Orders.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.Orders.Services;

public interface IOrdersRepository
{
	const int PER_PAGE = 10;

	Task<Result<IReadOnlyList<OrderListModel>, DomainError>> GetOrdersAsync(int page, int perPage);

	Task<Result<OrderModel, DomainError>> GetOrderAsync(long orderId);

	Task<Result<OrderModel, DomainError>> GetOrderAsync(string orderId);

	Task<Result<Unit, DomainError>> RepeatOrderAsync(long orderId);

	Task<Result<Unit, DomainError>> UpdateOrderAsync(long orderId, int arrived);

	Task<Result<OrderCancellationResponseDto, DomainError>> CancelOrderAsync(long orderId, int cancellationReasonId, string? commentary = null);

	Task<Result<IReadOnlyList<OrderListModel>, DomainError>> GetFirstPage();

	void PrefetchFirstPage();

	Task<Result<IReadOnlyList<OrderToAdditionModel>, DomainError>> GetOrdersAvailableToAdditionAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<Result<AddProductsToOrderPopupViewModel.Parameter, DomainError>> CheckAdditionItemsAsync(long orderId, IReadOnlyList<ProductOffer> offers, CancellationToken cancellationToken);

	Task<Result<SuccessAdditionalOrderPopupViewModel.Parameter, DomainError>> AddGoodsToOrderAsync(long orderId, IReadOnlyList<AdditionalOrderProductItem> items, CancellationToken cancellationToken);
}
