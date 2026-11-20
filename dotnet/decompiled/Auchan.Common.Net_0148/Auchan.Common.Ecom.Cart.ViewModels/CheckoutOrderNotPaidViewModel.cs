using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.Navigation;
using Auchan.Common.Profile.Orders;
using Auchan.Common.Profile.Orders.Dto;
using Auchan.Common.Profile.Orders.Enums;
using Auchan.Common.Profile.Orders.Models;
using Auchan.Common.Profile.Orders.Services;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Cart.ViewModels;

public class CheckoutOrderNotPaidViewModel : ScreenViewModel
{
	public enum VisualState
	{
		Default,
		InProgress
	}

	public class Parameter
	{
		public required IEnumerable<string> OrderIds { get; init; }
	}

	private readonly Parameter _parameter;

	private readonly IOrdersRepository _ordersRepository;

	private readonly ICancelOrderManager _cancelOrderManager;

	private readonly IOrderCancellationReasonsService _orderCancellationReasonsService;

	private readonly INavigationService _navigationService;

	private readonly IInfoMessageService _infoMessageService;

	private readonly ICheckoutService _checkoutService;

	private readonly Lazy<Cart> _cart;

	private readonly Lazy<IOrderDetailsParameterFactory> _orderDetailsParameterFactory;

	private readonly PaymentUrlHelper _paymentUrlHelper;

	private OrderModel? _unpaidOrder;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CTitleText_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CCancelOrderAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private string _003COrderPriceText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CReceiveMethodTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CReceiveMethodText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CReceiveTimeTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CReceiveTimeText_003Ek__BackingField;

	private string PaymentUrl => _unpaidOrder?.PaymentUrl ?? string.Empty;

	private long OrderId => _unpaidOrder?.Id ?? 0;

	public override bool TabBarVisible => false;

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.InProgress;

	public string TitleText
	{
		[CompilerGenerated]
		get
		{
			return _003CTitleText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CTitleText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTitleText_003Ek__BackingField = value;
				RaisePropertyChanged("TitleText");
			}
		}
	} = string.Empty;

	public string ReturnToPaymentText => "Вернуться к оплате";

	public bool CancelOrderAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CCancelOrderAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CCancelOrderAvailable_003Ek__BackingField != value)
			{
				_003CCancelOrderAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("CancelOrderAvailable");
			}
		}
	}

	public string CancelOrderText => "Отменить заказ";

	public string OrderPriceTitle => "Стоимость заказа";

	public string OrderPriceText
	{
		[CompilerGenerated]
		get
		{
			return _003COrderPriceText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003COrderPriceText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003COrderPriceText_003Ek__BackingField = value;
				RaisePropertyChanged("OrderPriceText");
			}
		}
	} = string.Empty;

	public string ReceiveMethodTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CReceiveMethodTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CReceiveMethodTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CReceiveMethodTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ReceiveMethodTitle");
			}
		}
	} = string.Empty;

	public string ReceiveMethodText
	{
		[CompilerGenerated]
		get
		{
			return _003CReceiveMethodText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CReceiveMethodText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CReceiveMethodText_003Ek__BackingField = value;
				RaisePropertyChanged("ReceiveMethodText");
			}
		}
	} = string.Empty;

	public string ReceiveTimeTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CReceiveTimeTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CReceiveTimeTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CReceiveTimeTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ReceiveTimeTitle");
			}
		}
	} = string.Empty;

	public string ReceiveTimeText
	{
		[CompilerGenerated]
		get
		{
			return _003CReceiveTimeText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CReceiveTimeText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CReceiveTimeText_003Ek__BackingField = value;
				RaisePropertyChanged("ReceiveTimeText");
			}
		}
	} = string.Empty;

	public string InfoText => "В неоплаченном заказе могут быть заморожены ваши баллы или промокод. Отмените заказ для возврата баллов или попыток применения промокода.";

	public UICommand ReturnToPaymentCommand { get; } = new UICommand();

	public UICommand<CheckoutWebViewModel.Parameter> OpenPaymentCommand { get; } = new UICommand<CheckoutWebViewModel.Parameter>();

	public UICommand CancelOrderCommand { get; } = new UICommand();

	public UICommand OpenOrdersCommand { get; } = new UICommand();

	public UICommand<OrderDetailsViewModel.Parameter> OpenOrderCommand { get; } = new UICommand<OrderDetailsViewModel.Parameter>();

	public UICommand CloseCommand { get; } = new UICommand();

	public UICommand CloseButtonClickCommand { get; } = new UICommand();

	public UICommand ReturnToCheckoutCommand { get; } = new UICommand();

	public UICommand ReturnToCartCommand { get; } = new UICommand();

	public CheckoutOrderNotPaidViewModel(Parameter parameter, IOrdersRepository ordersRepository, PaymentUrlHelper paymentUrlHelper, ICancelOrderManager cancelOrderManager, IOrderCancellationReasonsService orderCancellationReasonsService, INavigationService navigationService, IInfoMessageService infoMessageService, ICheckoutService checkoutService, Lazy<Cart> cart, Lazy<IOrderDetailsParameterFactory> orderDetailsParameterFactory)
	{
		_parameter = parameter;
		_ordersRepository = ordersRepository;
		_paymentUrlHelper = paymentUrlHelper;
		_cancelOrderManager = cancelOrderManager;
		_navigationService = navigationService;
		_infoMessageService = infoMessageService;
		_orderCancellationReasonsService = orderCancellationReasonsService;
		_checkoutService = checkoutService;
		_cart = cart;
		_orderDetailsParameterFactory = orderDetailsParameterFactory;
		((IObservable<Unit>)ReturnToPaymentCommand).PerformDebouncingTask((Func<Unit, Task>)async delegate
		{
			AppAnalytics.AppMetrica.TrackEvent("pendingOrderClick", (_unpaidOrder?.Number ?? string.Empty, "backToPayPage"));
			State = VisualState.InProgress;
			Result<OrderModel, DomainError> result = await _ordersRepository.GetOrderAsync(OrderId);
			if (result.IsFailure || !result.Value.AwaitingPayment)
			{
				State = VisualState.Default;
				_infoMessageService.ShowSnackbar("Срок оплаты истек", SnackbarStyle.Error, 5);
				CloseCommand.Trigger();
			}
			else
			{
				OpenPaymentCommand.Trigger(_paymentUrlHelper.GetParameter(PaymentUrl, _parameter.OrderIds));
				State = VisualState.Default;
			}
		}, (IScheduler?)null).Subscribe().AddTo(base.CloseDisposable);
		((IObservable<Unit>)CancelOrderCommand).PerformDebouncingTask((Func<Unit, Task>)delegate
		{
			AppAnalytics.AppMetrica.TrackEvent("pendingOrderClick", (_unpaidOrder?.Number ?? string.Empty, "cancelOrder"));
			return CancelOrder();
		}, (IScheduler?)null).Subscribe().AddTo(base.CloseDisposable);
		CloseCommand.PerformDebouncingTask(Close).Subscribe().AddTo(base.CloseDisposable);
		CloseButtonClickCommand.Subscribe(delegate
		{
			CloseCommand.Trigger();
			AppAnalytics.AppMetrica.TrackEvent("pendingOrderClick", (_unpaidOrder?.Number ?? string.Empty, "close"));
		}).AddTo(base.CloseDisposable);
	}

	protected override async Task Start()
	{
		State = VisualState.InProgress;
		await base.Start();
		OrderModel orderModel = (from o in await Task.WhenAll(_parameter.OrderIds.Select((string orderId) => _ordersRepository.GetOrderAsync(orderId)))
			where o.IsSuccess
			select o.Value).FirstOrDefault((OrderModel o) => o.AwaitingPayment);
		if (orderModel == null || orderModel.PaymentMethod == PaymentMethod.Offline || DateTime.UtcNow.UTCToMoscow() - orderModel.CreatedAt >= TimeSpan.FromMinutes(15L) || string.IsNullOrWhiteSpace(orderModel.PaymentUrl))
		{
			CloseCommand.Trigger();
			return;
		}
		_unpaidOrder = orderModel;
		TitleText = "Заказ №" + orderModel.Number + " не оплачен";
		CancelOrderAvailable = orderModel.IsCancellationPossible;
		OrderPriceText = $"{orderModel.Price:N2} ₽, оплата онлайн";
		ReceiveMethodTitle = GetReceiveMethodTitle(orderModel);
		ReceiveMethodText = GetReceiveMethodText(orderModel);
		ReceiveTimeTitle = GetReceiveTimeTitle(orderModel);
		ReceiveTimeText = GetReceiveTimeText(orderModel);
		AppAnalytics.AppMetrica.TrackEvent("pendingOrderView", (orderModel.Number, CancelOrderAvailable ? "cancelButtonActive" : "cancelButtonNotActive"));
		State = VisualState.Default;
	}

	private string GetReceiveMethodTitle(OrderModel order)
	{
		return order.Delivery.DeliveryMethod switch
		{
			DeliveryMethod.BySelf => "Магазин для самовывоза", 
			DeliveryMethod.Drive => "Магазин для получения АШАН Авто", 
			DeliveryMethod.Delivery => "Адрес доставки", 
			DeliveryMethod.ExpressDelivery => "Адрес быстрой доставки", 
			_ => string.Empty, 
		};
	}

	private string GetReceiveMethodText(OrderModel order)
	{
		return order.Delivery.DeliveryMethod switch
		{
			DeliveryMethod.BySelf => order.Shop.Address, 
			DeliveryMethod.Drive => order.Shop.Address, 
			DeliveryMethod.Delivery => order.Delivery.Address, 
			DeliveryMethod.ExpressDelivery => order.Delivery.Address, 
			_ => string.Empty, 
		};
	}

	private string GetReceiveTimeTitle(OrderModel order)
	{
		return order.Delivery.DeliveryMethod switch
		{
			DeliveryMethod.BySelf => "Дата и время самовывоза", 
			DeliveryMethod.Drive => "Дата и время получения", 
			DeliveryMethod.Delivery => "Дата и время доставки", 
			DeliveryMethod.ExpressDelivery => "Дата и время доставки", 
			_ => string.Empty, 
		};
	}

	private string GetReceiveTimeText(OrderModel order)
	{
		string text = $"{order.Delivery.DeliveryDate:M}, {order.Delivery.DeliveryDate:dddd}";
		if (!string.IsNullOrWhiteSpace(order.Delivery.DeliveryTime))
		{
			return text + ", " + order.Delivery.DeliveryTime;
		}
		return text;
	}

	private async Task CancelOrder()
	{
		if (!CancelOrderAvailable)
		{
			return;
		}
		State = VisualState.InProgress;
		Result<OrderModel, DomainError> orderData = await _ordersRepository.GetOrderAsync(OrderId);
		if (orderData.IsFailure || !orderData.Value.IsCancellationPossible)
		{
			CancelOrderAvailable = false;
			State = VisualState.Default;
			await _cancelOrderManager.ShowOrderCannotBeCanceled();
			AppAnalytics.AppMetrica.TrackEvent("pendingOrderCancel", (_unpaidOrder?.Number ?? string.Empty, "cancellationAborted"));
			return;
		}
		State = VisualState.Default;
		if (await _cancelOrderManager.AskDoYouWantToCancelOrder() != AgreeState.Yes)
		{
			AppAnalytics.AppMetrica.TrackEvent("pendingOrderCancel", (_unpaidOrder?.Number ?? string.Empty, "cancellationAborted"));
			return;
		}
		Result<PossibleOrderCancellationReasonsDto, DomainError> result = await _orderCancellationReasonsService.GetOrderCancellationReasonsAsync();
		if (result.IsFailure)
		{
			await DoCallToSupport();
			AppAnalytics.AppMetrica.TrackEvent("pendingOrderCancel", (_unpaidOrder?.Number ?? string.Empty, "cancellationAborted"));
			return;
		}
		AskForOrderCancellationReasonViewModel.Result result2 = await _cancelOrderManager.AskForOrderCancellationReason(result.Value);
		if (result2 == null)
		{
			AppAnalytics.AppMetrica.TrackEvent("pendingOrderCancel", (_unpaidOrder?.Number ?? string.Empty, "cancellationAborted"));
			return;
		}
		State = VisualState.InProgress;
		Result<OrderCancellationResponseDto, DomainError> result3 = await _ordersRepository.CancelOrderAsync(OrderId, result2.CancellationReason.Id, result2.Commentary);
		if (result3.IsFailure)
		{
			await DoCallToSupport();
			AppAnalytics.AppMetrica.TrackEvent("pendingOrderCancel", (_unpaidOrder?.Number ?? string.Empty, "cancellationAborted"));
			return;
		}
		AppAnalytics.AppMetrica.TrackEvent("pendingOrderCancel", (_unpaidOrder?.Number ?? string.Empty, "canceled"));
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = stringBuilder;
		StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(15, 1, stringBuilder2);
		handler.AppendLiteral("Заказ №");
		handler.AppendFormatted(orderData.Value.Number);
		handler.AppendLiteral(" отменен");
		stringBuilder2.Append(ref handler);
		if (result3.Value.GotRefund)
		{
			stringBuilder.AppendLine();
			stringBuilder.Append("Деньги уже возвращены на вашу карту");
		}
		_infoMessageService.ShowSnackbar(stringBuilder.ToString(), SnackbarStyle.Success, 5);
		ReturnToCartCommand.Trigger();
		State = VisualState.Default;
	}

	private async Task DoCallToSupport()
	{
		if (await _cancelOrderManager.ShowOrderCannotBeCanceled() == AgreeState.Yes)
		{
			_navigationService.CallToAuchanSupport();
		}
	}

	private async Task Close()
	{
		if (_unpaidOrder == null)
		{
			ReturnToCartCommand.Trigger();
			return;
		}
		State = VisualState.InProgress;
		OrderDetailsViewModel.Parameter parameter = await _orderDetailsParameterFactory.Value.CreateAsync(_unpaidOrder);
		if (parameter == null)
		{
			ReturnToCartCommand.Trigger();
		}
		else
		{
			OpenOrderCommand.Trigger(parameter);
		}
		State = VisualState.Default;
	}
}
