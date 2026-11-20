using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common.Binding;
using Auchan.Common.Profile.Orders.Enums;
using Auchan.Common.Profile.Orders.Extensions;
using Auchan.Common.Profile.Orders.Models;
using Auchan.Common.Profile.Orders.Services;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.Orders;

public sealed class NearestOrderInfoViewModel : BaseItemViewModel
{
	private enum DeliveryPriority
	{
		ExpressDelivery,
		Delivery,
		BySelf,
		Drive
	}

	private enum PaymentMethodPriority
	{
		Online,
		Offline
	}

	private readonly IOrdersRepository _ordersRepository;

	private readonly Lazy<IOrderDetailsParameterFactory> _orderDetailsParameterFactory;

	[CompilerGenerated]
	private OrderListModel? _003COrder_003Ek__BackingField;

	public UICommand<OrderDetailsViewModel.Parameter> NavigateToOrderDetailsCommand { get; } = new UICommand<OrderDetailsViewModel.Parameter>();

	public UICommand<IssuingAreaViewModel.Parameter> OpenIssuingZonePopupCommand { get; } = new UICommand<IssuingAreaViewModel.Parameter>();

	public UICommand<OrderItemViewModel> OpenIsArrivedPopupCommand { get; } = new UICommand<OrderItemViewModel>();

	public OrderListModel? Order
	{
		[CompilerGenerated]
		get
		{
			return _003COrder_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!(_003COrder_003Ek__BackingField == value))
			{
				_003COrder_003Ek__BackingField = value;
				RaisePropertyChanged("Status");
				RaisePropertyChanged("Visible");
				RaisePropertyChanged("Title");
				RaisePropertyChanged("Description");
				RaisePropertyChanged("Order");
			}
		}
	}

	public CustomerStatus Status => Order?.Status ?? CustomerStatus.InForm;

	public bool Visible => Order != null;

	public string Title => Order?.ConvertToNearestOrderStatusString() ?? "";

	public string Description => Order.GetNearestOrderStatusDescription();

	public NearestOrderInfoViewModel(IOrdersRepository ordersRepository, Lazy<IOrderDetailsParameterFactory> orderDetailsParameterFactory)
	{
		_ordersRepository = ordersRepository;
		_orderDetailsParameterFactory = orderDetailsParameterFactory;
	}

	public async Task Load()
	{
		Order = null;
		if ((await Task.Run((Func<Task<Result<IReadOnlyList<OrderListModel>, DomainError>>?>)_ordersRepository.GetFirstPage)).TryGetValue(out var value))
		{
			DateTime nowDate = DateTimeOffset.Now.Date;
			Order = (from i in value
				where IsStatusSupported(i)
				let deliveryDateOffset = i.DeliveryDate - nowDate
				where TimeSpan.Zero <= deliveryDateOffset && deliveryDateOffset < TimeSpan.FromDays(2)
				orderby i.DeliveryDate, Map(i.DeliveryMethod), i.MapDeliveryTimeStart(), i.MapDeliveryTimeEnd(), i.CreatedAt, Map(i.PaymentMethod)
				select i).FirstOrDefault();
		}
	}

	public async Task OpenQuickInfoPopupAsync()
	{
		if (!(Order == null))
		{
			OrderDetailsViewModel.Parameter parameter = await _orderDetailsParameterFactory.Value.CreateAsync(Order);
			if (parameter != null)
			{
				NavigateToOrderDetailsCommand.Trigger(parameter);
			}
		}
	}

	private static DeliveryPriority Map(DeliveryMethod deliveryMethod)
	{
		return deliveryMethod switch
		{
			DeliveryMethod.Delivery => DeliveryPriority.Delivery, 
			DeliveryMethod.BySelf => DeliveryPriority.BySelf, 
			DeliveryMethod.Drive => DeliveryPriority.Drive, 
			DeliveryMethod.ExpressDelivery => DeliveryPriority.ExpressDelivery, 
			_ => throw new NotImplementedException("dead code"), 
		};
	}

	private static PaymentMethodPriority Map(PaymentMethod paymentMethod)
	{
		return paymentMethod switch
		{
			PaymentMethod.Online => PaymentMethodPriority.Online, 
			PaymentMethod.Offline => PaymentMethodPriority.Offline, 
			_ => throw new NotImplementedException("dead code"), 
		};
	}

	private static bool IsStatusSupported(OrderListModel order)
	{
		switch (order.Status)
		{
		case CustomerStatus.InForm:
			return order.AwaitingPayment;
		case CustomerStatus.InProcessBuild:
		case CustomerStatus.OnWay:
		case CustomerStatus.ReadyToIssue:
		case CustomerStatus.Takeout:
		case CustomerStatus.Accepted:
			return true;
		default:
			return false;
		}
	}
}
