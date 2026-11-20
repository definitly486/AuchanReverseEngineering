using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.Orders.Enums;
using Auchan.Common.Profile.Orders.Extensions;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Common.Profile.Orders;

public class OrderItemViewModel : BaseItemViewModel, IIdentifiable
{
	public OrderListModel Order { get; }

	public bool AwaitingPayment => Order.AwaitingPayment;

	public bool CollectOrder => Order.CollectOrder == true;

	public bool IsShowHeader { get; }

	public IAddToOrderButtonItemViewModel AddToOrderButtonItemViewModel { get; }

	public long OrderId => Order.Id;

	public string DateHeader => (Order.CreatedAt.ToString("MMMM, yyyy") ?? "").FirstCharToUpper();

	public CustomerStatus Status => Order.Status;

	public bool PaymentAvailable => Order.AwaitingPayment;

	public virtual string PayLabel => "Оплатить заказ";

	public string ReadyToReceiveButtonText
	{
		get
		{
			if (Order.DeliveryMethod != DeliveryMethod.Drive)
			{
				return "Забрать заказ";
			}
			return "Я на месте";
		}
	}

	public string StoreName => Order.StoreName;

	public string StoreAddress => Order.StoreAddress ?? string.Empty;

	public string PickupPointDescription => Order.PickupPointDescription ?? string.Empty;

	public int MaxProductsToDisplay => 5;

	public string? PlusNProductsText
	{
		get
		{
			if (Products.Count() > 5)
			{
				int value = Products.Count() - 5 + 1;
				return $"+{value}";
			}
			return null;
		}
	}

	public ObservableRangeCollection<OrderItemProductItemViewModel> Products { get; } = new ObservableRangeCollection<OrderItemProductItemViewModel>();

	public IReadOnlyList<string> PickupPointImageUrls => Order.PickupPointImageUrls;

	protected bool CanGetViaDrive
	{
		get
		{
			if (Order.Status == CustomerStatus.ReadyToIssue)
			{
				return Order.DeliveryMethod == DeliveryMethod.Drive;
			}
			return false;
		}
	}

	protected bool CanGetViaPickup
	{
		get
		{
			if (Order.Status == CustomerStatus.ReadyToIssue && Order.DeliveryMethod == DeliveryMethod.BySelf)
			{
				return Order.CollectOrder == true;
			}
			return false;
		}
	}

	public virtual bool NeedToShowGetOrderButton
	{
		get
		{
			if (!CanGetViaDrive)
			{
				return CanGetViaPickup;
			}
			return true;
		}
	}

	public bool RepeatButtonVisible
	{
		get
		{
			if (!PaymentAvailable)
			{
				return Order.Status.IsInFinalState();
			}
			return false;
		}
	}

	public string? RepeatButtonTitle => "Повторить заказ";

	public ICallToCourierItemViewModel CallToCourier { get; }

	public OrderItemViewModel(OrderListModel order, bool showHeader, Func<ProductModel, ICollection<IDisposable>, OrderItemProductItemViewModel> viewModelFactory, IAddToOrderButtonItemViewModel addToOrderButtonItemViewModel, ICallToCourierItemViewModel callToCourierItemViewModel, bool showNumberLongText = false)
	{
		OrderItemViewModel orderItemViewModel = this;
		Order = order;
		IsShowHeader = showHeader;
		AddToOrderButtonItemViewModel = addToOrderButtonItemViewModel.AddTo(base.Disposables);
		Products.AddRange(Order.Products.Select((ProductModel c) => viewModelFactory(c, orderItemViewModel.Disposables)));
		CallToCourier = callToCourierItemViewModel;
		CallToCourier.Order = Order;
		CallToCourier.AddTo(base.Disposables);
	}

	string IIdentifiable.GetId()
	{
		return $"order:{Order.Id.GetHashCode()}";
	}
}
