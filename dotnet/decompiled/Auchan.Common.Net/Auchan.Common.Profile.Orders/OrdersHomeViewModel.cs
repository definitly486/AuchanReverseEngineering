using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Extensions;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.Profile.Orders.Enums;
using Auchan.Common.Profile.Orders.Models;
using Auchan.Common.Profile.Orders.Services;
using CSharpFunctionalExtensions;
using EBind;

namespace Auchan.Common.Profile.Orders;

public class OrdersHomeViewModel : BaseItemViewModel
{
	private const bool ShowDateHeader = false;

	private const bool ShowNumberLongText = true;

	private readonly NumberFormatInfo _priceFormat = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();

	private readonly IUserContext _userContext;

	private readonly IOrdersRepository _ordersRepository;

	private readonly Lazy<IOrderDetailsParameterFactory> _orderDetailsParameterFactory;

	private readonly Cart _cart;

	private readonly Func<OrderListModel, bool, ICollection<IDisposable>, bool, HomeOrderItemViewModel> _orderItemVm;

	private readonly Subject<Unit> _ordersUpdated = new Subject<Unit>();

	private bool _needReopen;

	[CompilerGenerated]
	private OrderListModel? _003CLastCompletedOrder_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsOrdersListLoaded_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CHasLastCompletedOrder_003Ek__BackingField;

	public string OrdersBlockTitle => "Мои заказы";

	public string AllButtonText => "Все";

	public string UnsuccessfulRepeatOrder => "Не удалось повторить заказ";

	public string RepeatCompletedOrderText => "Повторить прошлый заказ?";

	public OrderListModel? LastCompletedOrder
	{
		[CompilerGenerated]
		get
		{
			return _003CLastCompletedOrder_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!(_003CLastCompletedOrder_003Ek__BackingField == value))
			{
				_003CLastCompletedOrder_003Ek__BackingField = value;
				RaisePropertyChanged("LastCompletedOrder");
			}
		}
	}

	public bool IsOrdersListLoaded
	{
		[CompilerGenerated]
		get
		{
			return _003CIsOrdersListLoaded_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsOrdersListLoaded_003Ek__BackingField != value)
			{
				_003CIsOrdersListLoaded_003Ek__BackingField = value;
				RaisePropertyChanged("IsOrdersListLoaded");
			}
		}
	}

	public ObservableRangeCollection<HomeOrderItemViewModel> Orders { get; } = new ObservableRangeCollection<HomeOrderItemViewModel>();

	public bool HasLastCompletedOrder
	{
		[CompilerGenerated]
		get
		{
			return _003CHasLastCompletedOrder_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CHasLastCompletedOrder_003Ek__BackingField != value)
			{
				_003CHasLastCompletedOrder_003Ek__BackingField = value;
				RaisePropertyChanged("HasLastCompletedOrder");
			}
		}
	}

	public IObservable<Unit> OnOrdersUpdated => _ordersUpdated;

	public UICommand ReloadCommand { get; } = new UICommand();

	public UICommand RepeatLastCompletedOrderCommand { get; } = new UICommand();

	public UICommand<OrderItemViewModel> PayCommand { get; } = new UICommand<OrderItemViewModel>();

	public UICommand<IssuingAreaViewModel.Parameter> OpenIssuingZonePopupCommand { get; } = new UICommand<IssuingAreaViewModel.Parameter>();

	public UICommand<OrderItemViewModel> OpenIsArrivedPopupCommand { get; } = new UICommand<OrderItemViewModel>();

	public UICommand<OrderDetailsViewModel.Parameter> NavigateToOrderDetailsCommand { get; } = new UICommand<OrderDetailsViewModel.Parameter>();

	public RepeatOrderService RepeatOrderService { get; }

	public OrdersHomeViewModel(IUserContext userContext, IOrdersRepository ordersRepository, Lazy<IOrderDetailsParameterFactory> orderDetailsParameterFactory, Cart cart, Func<List<OrderItemViewModel>, Task> openPayment, Func<OrderListModel, bool, ICollection<IDisposable>, bool, HomeOrderItemViewModel> orderItemVm, RepeatOrderService repeatOrderService)
	{
		OrdersHomeViewModel ordersHomeViewModel = this;
		_priceFormat.NumberGroupSeparator = " ";
		_userContext = userContext;
		_ordersRepository = ordersRepository;
		_orderDetailsParameterFactory = orderDetailsParameterFactory;
		_cart = cart;
		_orderItemVm = orderItemVm;
		RepeatOrderService = repeatOrderService;
		_ordersUpdated.AddTo(base.Disposables);
		RepeatOrderService.OnShowReplacement += new DisposableDelegate<Action>(delegate
		{
			ordersHomeViewModel._needReopen = true;
		}, delegate(Action h)
		{
			ordersHomeViewModel.RepeatOrderService.OnShowReplacement -= h;
		}).AddTo(base.Disposables);
		_userContext.AfterLoggedIn += AfterLoggedIn;
		ReloadCommand.PerformDebouncingTask(Load).Subscribe().AddTo(base.Disposables);
		PayCommand.PerformDebouncingTask(delegate(OrderItemViewModel order)
		{
			AppAnalytics.AppMetrica.TrackEvent("myordersScreenButtonReturnToPayment");
			Func<List<OrderItemViewModel>, Task> func = openPayment;
			int num = 1;
			List<OrderItemViewModel> list = new List<OrderItemViewModel>(num);
			CollectionsMarshal.SetCount(list, num);
			CollectionsMarshal.AsSpan(list)[0] = order;
			return func(list);
		}).Subscribe().AddTo(base.Disposables);
		RepeatLastCompletedOrderCommand.PerformDebouncingTask(RepeatLastCompletedOrderAsync).Subscribe().AddTo(base.Disposables);
	}

	public async Task Load()
	{
		if (_needReopen)
		{
			await RepeatLastCompletedOrderAsync();
		}
		if (!_userContext.Authorized)
		{
			UpdateOrders(Array.Empty<OrderListModel>());
			return;
		}
		Result<IReadOnlyList<OrderListModel>, DomainError> result = await Task.Run(() => _ordersRepository.GetFirstPage());
		if (!result.IsFailure)
		{
			UpdateOrders(result.Value);
		}
	}

	private void UpdateOrders(IReadOnlyList<OrderListModel> orders)
	{
		IEnumerable<long> formingOrdersToDisplay = from c in orders.Where((OrderListModel c) => c.Status == CustomerStatus.InForm && c.AwaitingPayment).Take(2)
			select c.Id;
		LoadLastCompletedOrder(orders);
		HomeOrderItemViewModel[] collection = (from x in orders
			where formingOrdersToDisplay.Contains(x.Id) || x.Status == CustomerStatus.ReadyToIssue || x.Status == CustomerStatus.Takeout || x.Status == CustomerStatus.OnWay || x.Status == CustomerStatus.InProcessBuild || x.Status == CustomerStatus.Accepted
			select _orderItemVm(x, arg2: false, base.Disposables, arg4: true)).ToArray();
		Orders.DisposeAll();
		Orders.ReplaceRange(collection);
		IsOrdersListLoaded = Orders.Any();
		_ordersUpdated.OnNext(Unit.Default);
	}

	private void LoadLastCompletedOrder(IReadOnlyList<OrderListModel> orders)
	{
		LastCompletedOrder = null;
		if (orders.FirstOrDefault((OrderListModel c) => c.Status == CustomerStatus.InForm || c.Status == CustomerStatus.InProcessBuild || c.Status == CustomerStatus.OnWay || c.Status == CustomerStatus.ReadyToIssue || c.Status == CustomerStatus.Takeout || c.Status == CustomerStatus.Accepted) != null)
		{
			HasLastCompletedOrder = false;
			return;
		}
		OrderListModel orderListModel = (from c in orders
			where c.Status == CustomerStatus.Delivered || c.Status == CustomerStatus.Completed
			orderby c.CreatedAt descending
			select c).FirstOrDefault();
		if (orderListModel != null)
		{
			LastCompletedOrder = orderListModel;
			HasLastCompletedOrder = true;
		}
		else
		{
			HasLastCompletedOrder = false;
		}
	}

	public void OnGetOrderClick(OrderItemViewModel order)
	{
		int num = 1;
		List<OrderItemViewModel> list = new List<OrderItemViewModel>(num);
		CollectionsMarshal.SetCount(list, num);
		CollectionsMarshal.AsSpan(list)[0] = order;
		OnGetOrderClick(list);
	}

	public void OnGetOrderClick(List<OrderItemViewModel> orders)
	{
		OrderItemViewModel orderItemViewModel = orders.First();
		if (orderItemViewModel.Order.DeliveryMethod == DeliveryMethod.BySelf)
		{
			OpenIssuingZonePopupCommand.Trigger(new IssuingAreaViewModel.Parameter(orders));
		}
		if (orderItemViewModel.Order.DeliveryMethod == DeliveryMethod.Drive)
		{
			OpenIsArrivedPopupCommand.Trigger(orderItemViewModel);
		}
	}

	private async Task RepeatLastCompletedOrderAsync()
	{
		if ((object)LastCompletedOrder != null)
		{
			_needReopen = false;
			await RepeatOrderService.OpenRepeatOrderPopup(LastCompletedOrder.Products, LastCompletedOrder.IsAdult);
			await _cart.Update(Guid.NewGuid());
		}
	}

	public async Task NavigateToOrderDetails(IListOrderModel orderModel)
	{
		OrderDetailsViewModel.Parameter parameter = await _orderDetailsParameterFactory.Value.CreateAsync(orderModel);
		if (parameter != null)
		{
			NavigateToOrderDetailsCommand.Trigger(parameter);
		}
	}

	private Task AfterLoggedIn()
	{
		ReloadCommand.Trigger();
		return Task.CompletedTask;
	}
}
