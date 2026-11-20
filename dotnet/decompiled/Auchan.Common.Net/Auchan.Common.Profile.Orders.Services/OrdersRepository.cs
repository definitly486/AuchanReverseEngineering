using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Home;
using Auchan.Common.Profile.Orders.Dto;
using Auchan.Common.Profile.Orders.Models;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.Orders.Services;

internal sealed class OrdersRepository : IOrdersRepository
{
	private readonly Lazy<IOrdersService> _service;

	private readonly IHomeScreenTracker _homeScreenTracker;

	private Task<Result<IReadOnlyList<OrderListModel>, DomainError>>? _prefetchedFirstPage;

	private Task<Result<IReadOnlyList<OrderListModel>, DomainError>>? _getFirstPageTask;

	public OrdersRepository(Lazy<IOrdersService> service, IHomeScreenTracker homeScreenTracker)
	{
		_service = service;
		_homeScreenTracker = homeScreenTracker;
		_homeScreenTracker.OnShown += delegate
		{
			_prefetchedFirstPage = null;
		};
	}

	public Task<Result<OrderCancellationResponseDto, DomainError>> CancelOrderAsync(long orderId, int cancellationReasonId, string? commentary = null)
	{
		return Task.Run(() => _service.Value.CancelOrderAsync(orderId, cancellationReasonId, commentary));
	}

	public Task<Result<OrderModel, DomainError>> GetOrderAsync(long orderId)
	{
		return Task.Run(() => _service.Value.GetOrderAsync(orderId));
	}

	public Task<Result<OrderModel, DomainError>> GetOrderAsync(string orderId)
	{
		return Task.Run(() => _service.Value.GetOrderAsync(orderId));
	}

	public Task<Result<IReadOnlyList<OrderListModel>, DomainError>> GetFirstPage()
	{
		return _prefetchedFirstPage ?? _getFirstPageTask ?? (_getFirstPageTask = GetFirstPageLocal());
		async Task<Result<IReadOnlyList<OrderListModel>, DomainError>> GetFirstPageLocal()
		{
			Result<IReadOnlyList<OrderListModel>, DomainError> result = await GetOrdersAsync(1, 10);
			_getFirstPageTask = null;
			return result;
		}
	}

	public void PrefetchFirstPage()
	{
		_prefetchedFirstPage = GetOrdersAsync(1, 10);
		_prefetchedFirstPage.SafeFireAndForget((Action<Exception>)null, false);
	}

	public Task<Result<IReadOnlyList<OrderListModel>, DomainError>> GetOrdersAsync(int page, int perPage)
	{
		return Task.Run(() => _service.Value.GetOrdersAsync(page, perPage));
	}

	public Task<Result<Unit, DomainError>> RepeatOrderAsync(long orderId)
	{
		return Task.Run(() => _service.Value.RepeatOrderAsync(orderId));
	}

	public Task<Result<Unit, DomainError>> UpdateOrderAsync(long orderId, int arrived)
	{
		return Task.Run(() => _service.Value.UpdateOrderAsync(orderId, arrived));
	}

	public Task<Result<IReadOnlyList<OrderToAdditionModel>, DomainError>> GetOrdersAvailableToAdditionAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		return Task.Run(() => _service.Value.GetOrdersAvailableToAdditionAsync(cancellationToken));
	}

	public Task<Result<AddProductsToOrderPopupViewModel.Parameter, DomainError>> CheckAdditionItemsAsync(long orderId, IReadOnlyList<ProductOffer> offers, CancellationToken cancellationToken)
	{
		return Task.Run(() => _service.Value.CheckAdditionItemsAsync(orderId, offers, cancellationToken));
	}

	public Task<Result<SuccessAdditionalOrderPopupViewModel.Parameter, DomainError>> AddGoodsToOrderAsync(long orderId, IReadOnlyList<AdditionalOrderProductItem> items, CancellationToken cancellationToken)
	{
		return Task.Run(() => _service.Value.AddGoodsToOrderAsync(orderId, items, cancellationToken));
	}
}
