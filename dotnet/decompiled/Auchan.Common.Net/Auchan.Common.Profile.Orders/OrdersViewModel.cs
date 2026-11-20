using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.Navigation;
using Auchan.Common.Profile.Orders.Enums;
using Auchan.Common.Profile.Orders.Models;
using Auchan.Common.Profile.Orders.Services;
using CSharpFunctionalExtensions;
using EBind;

namespace Auchan.Common.Profile.Orders;

[RequiresAuthorization]
public class OrdersViewModel : ScreenViewModel
{
	private const int ItemCountPerPage = 10;

	private readonly IOrdersRepository _ordersRepository;

	private readonly ILogService _logService;

	private readonly IEcomContext _ecomContext;

	private readonly PickupPointOrdersChecker _pickupPointOrdersChecker;

	private readonly NumberFormatInfo _priceFormat = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();

	private readonly DefaultErrorTranslator _defaultErrorTranslator;

	private readonly Func<OrderListModel, bool, ICollection<IDisposable>, OrderItemViewModel> _viewModelFactory;

	private readonly IInfoMessageService _infoMessageService;

	private readonly PaymentUrlHelper _paymentUrlHelper;

	private readonly Lazy<IOrderDetailsParameterFactory> _orderDetailsParameterFactory;

	private readonly Subject<Unit> _loadMore = new Subject<Unit>();

	private readonly Subject<Unit> _navigateCatalogNext = new Subject<Unit>();

	private int _page = 1;

	private TaskQueue _ordersQueue = new TaskQueue();

	private bool _needReopen;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorHint_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsRefreshing_003Ek__BackingField;

	[CompilerGenerated]
	private OrderItemViewModel? _003CLastRepeatOrderItem_003Ek__BackingField;

	public string Title => "Мои заказы";

	public string ProgressTitle => "Загружаем вашу историю…";

	public string ErrorMessage
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorMessage_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorMessage_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorMessage");
			}
		}
	} = string.Empty;

	public string ErrorHint
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorHint_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorHint_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorHint_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorHint");
			}
		}
	} = string.Empty;

	public string ErrorButtonText => "Повторить";

	public string EmptyPageButtonText => "В каталог";

	public string EmptyTitleText => "Вы еще не оформляли заказы";

	public string EmptyHintText => "Воспользуйтесь каталогом,\n чтобы начать покупки";

	public ObservableRangeCollection<List<OrderItemViewModel>> Orders { get; } = new ObservableRangeCollection<List<OrderItemViewModel>>();

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
	} = VisualState.Default;

	public bool IsRefreshing
	{
		[CompilerGenerated]
		get
		{
			return _003CIsRefreshing_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsRefreshing_003Ek__BackingField != value)
			{
				_003CIsRefreshing_003Ek__BackingField = value;
				RaisePropertyChanged("IsRefreshing");
			}
		}
	}

	public UICommand<OrderDetailsViewModel.Parameter> NavigateNextCommand { get; } = new UICommand<OrderDetailsViewModel.Parameter>();

	public IObservable<Unit> NavigateCatalogCommand => _navigateCatalogNext.Debounce();

	public UICommand<IssuingAreaViewModel.Parameter> NavigateToIssuingZonePopup { get; } = new UICommand<IssuingAreaViewModel.Parameter>();

	public UICommand<OrderItemViewModel> OpenIsArrivedPopupCommand { get; } = new UICommand<OrderItemViewModel>();

	public UICommand<IReadOnlyList<OrderItemViewModel>> PayCommand { get; } = new UICommand<IReadOnlyList<OrderItemViewModel>>();

	public UICommand<CheckoutWebViewModel.Parameter> OpenPaymentCommand { get; } = new UICommand<CheckoutWebViewModel.Parameter>();

	public RepeatOrderService RepeatOrderService { get; }

	private OrderItemViewModel? LastRepeatOrderItem
	{
		[CompilerGenerated]
		get
		{
			return _003CLastRepeatOrderItem_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CLastRepeatOrderItem_003Ek__BackingField, value))
			{
				_003CLastRepeatOrderItem_003Ek__BackingField = value;
				RaisePropertyChanged("LastRepeatOrderItem");
			}
		}
	}

	public OrdersViewModel(IOrdersRepository ordersRepository, ILogService logService, IEcomContext ecomContext, PickupPointOrdersChecker pickupPointOrdersChecker, DefaultErrorTranslator defaultErrorTranslator, Func<OrderListModel, bool, ICollection<IDisposable>, OrderItemViewModel> viewModelFactory, IInfoMessageService infoMessageService, PaymentUrlHelper paymentUrlHelper, Lazy<IOrderDetailsParameterFactory> orderDetailsParameterFactory, RepeatOrderService repeatOrderService)
	{
		RepeatOrderService = repeatOrderService;
		_ordersRepository = ordersRepository;
		_logService = logService;
		_ecomContext = ecomContext;
		_defaultErrorTranslator = defaultErrorTranslator;
		_viewModelFactory = viewModelFactory;
		_pickupPointOrdersChecker = pickupPointOrdersChecker;
		_infoMessageService = infoMessageService;
		_paymentUrlHelper = paymentUrlHelper;
		_orderDetailsParameterFactory = orderDetailsParameterFactory;
		_priceFormat.NumberGroupSeparator = " ";
		_loadMore.PerformDebouncingTask((Unit _) => LoadNextPageCommand()).Subscribe().AddTo(base.CloseDisposable);
		PayCommand.PerformDebouncingTask(OpenPayment).Subscribe().AddTo(base.CloseDisposable);
		RepeatOrderService.OnStateChanged += new DisposableDelegate<Action<VisualState>>(delegate(VisualState state)
		{
			State = state;
		}, delegate(Action<VisualState> h)
		{
			RepeatOrderService.OnStateChanged -= h;
		}).AddTo(base.CloseDisposable);
		RepeatOrderService.OnShowReplacement += new DisposableDelegate<Action>(delegate
		{
			_needReopen = true;
		}, delegate(Action h)
		{
			RepeatOrderService.OnShowReplacement -= h;
		}).AddTo(base.CloseDisposable);
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		_logService.LogInfo("OrdersViewModel", "Открыта страница 'Мои заказы'", LogType.UserAction, SystemType.MobileApp);
		LoadFirstPageOrdersQueued();
		if (_needReopen)
		{
			await RepeatOrder(LastRepeatOrderItem);
		}
	}

	public async Task NavigateToDetailsAsync(IListOrderModel order)
	{
		OrderDetailsViewModel.Parameter parameter = await _orderDetailsParameterFactory.Value.CreateAsync(order);
		if (parameter != null)
		{
			_logService.LogInfo("OrderViewModel", "Запрошен переход на экран заказа", LogType.UserAction, SystemType.MobileApp);
			NavigateNextCommand.Trigger(parameter);
		}
	}

	public void NavigateToCatalog()
	{
		_logService.LogInfo("OrderViewModel", "Запрошен переход на экран каталога", LogType.UserAction, SystemType.MobileApp);
		_navigateCatalogNext.OnNext(Unit.Default);
	}

	public void LoadNextPage()
	{
		_loadMore.OnNext(Unit.Default);
	}

	public async Task RefreshOrders()
	{
		IsRefreshing = true;
		LoadFirstPageOrdersQueued(fullscreenThrobber: false);
		await Task.Delay(1000);
		IsRefreshing = false;
	}

	public void LoadFirstPageOrdersQueued(bool fullscreenThrobber = true)
	{
		_ordersQueue.Enqueue(() => LoadFirstPageOrders(fullscreenThrobber)).SafeFireAndForget((Action<Exception>)null, false);
	}

	public void OnGetOrderClick(IReadOnlyList<OrderItemViewModel> orders)
	{
		OrderItemViewModel orderItemViewModel = orders.FirstOrDefault();
		if (orderItemViewModel != null)
		{
			switch (orderItemViewModel.Order.DeliveryMethod)
			{
			case DeliveryMethod.BySelf:
				NavigateToIssuingZonePopup.Trigger(new IssuingAreaViewModel.Parameter(orders));
				break;
			case DeliveryMethod.Drive:
				OpenIsArrivedPopupCommand.Trigger(orderItemViewModel);
				break;
			}
		}
	}

	private async Task LoadFirstPageOrders(bool fullscreenThrobber = true)
	{
		_page = 1;
		Orders.ForEach(delegate(List<OrderItemViewModel> i)
		{
			i.DisposeAll();
		});
		Orders.Clear();
		if (fullscreenThrobber)
		{
			State = VisualState.InProgress;
		}
		Result<IReadOnlyList<OrderListModel>, DomainError> result = await _ordersRepository.GetOrdersAsync(_page, 10);
		if (result.IsFailure)
		{
			State = VisualState.Error;
			(ErrorMessage, ErrorHint) = _defaultErrorTranslator.Translate(result.Error);
			return;
		}
		if (!result.Value.Any())
		{
			State = VisualState.Empty;
			return;
		}
		OrderListModel previousOrder = null;
		foreach (OrderListModel currentOrder in result.Value)
		{
			if (_pickupPointOrdersChecker.OrderAlreadyAdded(Orders.ToList(), currentOrder))
			{
				continue;
			}
			bool showDateHeader = ShowDateHeader(previousOrder, currentOrder);
			if (_pickupPointOrdersChecker.NeedToGroupOrdersByPickupPointAndStatus(currentOrder, result.Value))
			{
				List<OrderItemViewModel> item = (from x in result.Value
					where _pickupPointOrdersChecker.IsReadyToIssueDeliveredBySelfOrderInThisStore(currentOrder, x)
					select _viewModelFactory(x, showDateHeader, base.CloseDisposable)).ToList();
				Orders.Add(item);
			}
			else
			{
				OrderItemViewModel item2 = _viewModelFactory(currentOrder, showDateHeader, base.CloseDisposable);
				Orders.Add(new List<OrderItemViewModel> { item2 });
			}
			previousOrder = currentOrder;
		}
		State = VisualState.Default;
	}

	private bool ShowDateHeader(OrderListModel? previousOrder, OrderListModel currentOrder)
	{
		if (previousOrder == null)
		{
			return false;
		}
		bool num = previousOrder == null;
		bool flag = previousOrder != null && previousOrder.CreatedAt.Month != currentOrder.CreatedAt.Month;
		return num || flag;
	}

	private async Task LoadNextPageCommand()
	{
		_page++;
		Result<IReadOnlyList<OrderListModel>, DomainError> result = await _ordersRepository.GetOrdersAsync(_page, 10);
		if (result.IsFailure)
		{
			_page--;
			return;
		}
		OrderListModel previousOrder = null;
		foreach (OrderListModel currentOrder in result.Value)
		{
			if (_pickupPointOrdersChecker.OrderAlreadyAdded(Orders.ToList(), currentOrder))
			{
				continue;
			}
			bool showDateHeader = ShowDateHeader(previousOrder, currentOrder);
			if (_pickupPointOrdersChecker.NeedToGroupOrdersByPickupPointAndStatus(currentOrder, result.Value))
			{
				List<OrderItemViewModel> item = (from x in result.Value
					where _pickupPointOrdersChecker.IsReadyToIssueDeliveredBySelfOrderInThisStore(currentOrder, x)
					select _viewModelFactory(x, showDateHeader, base.CloseDisposable)).ToList();
				Orders.Add(item);
			}
			else
			{
				OrderItemViewModel item2 = _viewModelFactory(currentOrder, showDateHeader, base.CloseDisposable);
				Orders.Add(new List<OrderItemViewModel> { item2 });
			}
			previousOrder = currentOrder;
		}
	}

	private async Task OpenPayment(IReadOnlyList<OrderItemViewModel> orders)
	{
		AppAnalytics.AppMetrica.TrackEvent("myordersScreenButtonReturnToPayment");
		OrderItemViewModel order = orders?.FirstOrDefault((OrderItemViewModel o) => o.AwaitingPayment);
		if (order == null)
		{
			_infoMessageService.ShowSnackbar("Произошла неизвестная ошибка");
			return;
		}
		State = VisualState.InProgress;
		Result<OrderModel, DomainError> result = await _ordersRepository.GetOrderAsync(order.OrderId);
		if (result.IsFailure || !result.Value.AwaitingPayment || string.IsNullOrWhiteSpace(result.Value.PaymentUrl))
		{
			_infoMessageService.ShowSnackbar("Срок оплаты истек", SnackbarStyle.Error, 5);
			await LoadFirstPageOrders();
		}
		else
		{
			State = VisualState.Default;
			OpenPaymentCommand.Trigger(_paymentUrlHelper.GetParameter(result.Value.PaymentUrl, order.OrderId.ToString()));
		}
	}

	public async Task RepeatOrder(OrderItemViewModel? orderItem)
	{
		_needReopen = false;
		if (orderItem != null)
		{
			LastRepeatOrderItem = orderItem;
			await RepeatOrderService.OpenRepeatOrderPopup(orderItem.Order.Products, orderItem.Order.IsAdult);
		}
	}
}
