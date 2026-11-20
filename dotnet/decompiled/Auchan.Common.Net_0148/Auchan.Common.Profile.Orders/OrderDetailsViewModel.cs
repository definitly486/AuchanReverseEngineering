using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Drive;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Navigation;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.Profile.Orders.Dto;
using Auchan.Common.Profile.Orders.Enums;
using Auchan.Common.Profile.Orders.Extensions;
using Auchan.Common.Profile.Orders.Models;
using Auchan.Common.Profile.Orders.Services;
using CSharpFunctionalExtensions;
using DryIoc.ImTools;
using EBind;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders;

[RequiresAuthorization]
public class OrderDetailsViewModel : ScreenViewModel
{
	public class Parameter
	{
		public long OrderId { get; }

		[Obsolete("For json serialization only. Create with factory", true)]
		[JsonConstructor]
		public Parameter(long orderId)
		{
			OrderId = orderId;
		}

		public Parameter(long orderId, IOrderDetailsParameterFactory.IPassToken passToken)
		{
			if (passToken == null)
			{
				throw new InvalidOperationException("should be created with factory");
			}
			OrderId = orderId;
		}
	}

	private readonly Parameter _parameter;

	private readonly IOrdersRepository _ordersRepository;

	private readonly IOrderCancellationReasonsService _orderCancellationReasonsService;

	private readonly IUserContext _userContext;

	private readonly DefaultErrorTranslator _defaultErrorTranslator;

	private readonly Func<ProductModel, ICollection<IDisposable>, OrderDetailProductItemViewModel> _viewModelFactory;

	private readonly IInfoMessageService _infoMessageService;

	private readonly INavigationService _navigationService;

	private readonly ICancelOrderManager _cancelOrderManager;

	private readonly PaymentUrlHelper _paymentUrlHelper;

	private readonly CultureInfo _numbersCulture = CultureInfo.InvariantCulture;

	private readonly Subject<ProductDetailsViewModel.Parameter> _navigateToProductDetails = new Subject<ProductDetailsViewModel.Parameter>();

	private readonly Subject<AskIsPersonArrivedViewModel.Parameter> _openIsArrivedDriveDialog = new Subject<AskIsPersonArrivedViewModel.Parameter>();

	private readonly Subject<IssuingAreaViewModel.Parameter> _openGetOrderDialog = new Subject<IssuingAreaViewModel.Parameter>();

	private readonly Subject<Unit> _reloadOrder = new Subject<Unit>();

	private bool _needReopen;

	[CompilerGenerated]
	private OrderModel? _003COrder_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	public IReadOnlyList<string> PickupPointImages
	{
		get
		{
			if (!(Order?.SelfPickupPointInfo == null))
			{
				return Order.Shop.PickupPhotoUrls;
			}
			return Array.Empty<string>();
		}
	}

	private OrderModel? Order
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
				RaisePropertyChanged("PickupPointImages");
				RaisePropertyChanged("NeedShowSelfPickupPoint");
				RaisePropertyChanged("DeliveryMethodTitle");
				RaisePropertyChanged("ShortAddressText");
				RaisePropertyChanged("IsInFinalState");
				RaisePropertyChanged("IsInActiveState");
				RaisePropertyChanged("Title");
				RaisePropertyChanged("OrderNumber");
				RaisePropertyChanged("Subtitle");
				RaisePropertyChanged("StatusText");
				RaisePropertyChanged("AddressText");
				RaisePropertyChanged("Description");
				RaisePropertyChanged("IsDescriptionVisible");
				RaisePropertyChanged("ShopImage");
				RaisePropertyChanged("IsShopImageVisible");
				RaisePropertyChanged("DeliveryDateTitle");
				RaisePropertyChanged("DeliveryDateText");
				RaisePropertyChanged("PaymentTypeText");
				RaisePropertyChanged("CommentContent");
				RaisePropertyChanged("IsCommentVisible");
				RaisePropertyChanged("IsAuchanDriveOrder");
				RaisePropertyChanged("DeliveryPriceTitle");
				RaisePropertyChanged("ReadyToReceiveButtonText");
				RaisePropertyChanged("IsPickupOrder");
				RaisePropertyChanged("IsDeliveryPriceBlockVisible");
				RaisePropertyChanged("IsExpressDeliveryOrder");
				RaisePropertyChanged("IsReadyToReceive");
				RaisePropertyChanged("WeightText");
				RaisePropertyChanged("QtyPriceSumLabel");
				RaisePropertyChanged("QtyPriceSumText");
				RaisePropertyChanged("DeliveryPriceText");
				RaisePropertyChanged("PointsPaymentVisible");
				RaisePropertyChanged("PointsPaymentValue");
				RaisePropertyChanged("StampsPaymentVisible");
				RaisePropertyChanged("StampsPaymentValue");
				RaisePropertyChanged("GeneralPriceText");
				RaisePropertyChanged("RepeatButtonVisible");
				RaisePropertyChanged("IsCancelButtonVisible");
				RaisePropertyChanged("PaymentAvailable");
				RaisePropertyChanged("OrderQtyText");
				RaisePropertyChanged("IsOrderChanged");
				RaisePropertyChanged("PickingPrice");
				RaisePropertyChanged("PickingPriceText");
				RaisePropertyChanged("PickingPriceVisible");
				RaisePropertyChanged("SurgeAmount");
				RaisePropertyChanged("SurgeAmountText");
				RaisePropertyChanged("SurgeAmountVisible");
				OnOrderChanged();
				RaisePropertyChanged("Order");
			}
		}
	}

	public OrderProgressViewModel OrderProgress { get; } = new OrderProgressViewModel();

	public IObservable<AskIsPersonArrivedViewModel.Parameter> OpenIsArrivedDialogCommand => _openIsArrivedDriveDialog.Debounce();

	public IObservable<IssuingAreaViewModel.Parameter> OpenGetOrderDialog => _openGetOrderDialog.Debounce();

	public IObservable<ProductDetailsViewModel.Parameter> NavigateToProductCommand => _navigateToProductDetails.Debounce();

	public UICommand PayCommand { get; } = new UICommand();

	public UICommand<CheckoutWebViewModel.Parameter> OpenPaymentCommand { get; } = new UICommand<CheckoutWebViewModel.Parameter>();

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

	public string DeliveryMethodTitle
	{
		get
		{
			if (!(Order == null))
			{
				if (!IsPickupOrder)
				{
					if (!Order.Delivery.DeliveryMethod.IsDelivery())
					{
						return "Ашан Авто по адресу";
					}
					return "Доставка по адресу";
				}
				return "Самовывоз по адресу";
			}
			return "";
		}
	}

	public string ShortAddressText => GetAddressText("");

	public bool IsInFinalState => Order?.Status.IsInFinalState() ?? false;

	public bool IsInActiveState => !IsInFinalState;

	public string Title
	{
		get
		{
			if (!(Order == null))
			{
				return "Заказ №" + Order.Number;
			}
			return "";
		}
	}

	public string OrderNumber => Order.Number;

	public string Subtitle
	{
		get
		{
			if (!(Order == null))
			{
				return "от " + Order.CreatedAt.ToLongDateWithFullMonth();
			}
			return "";
		}
	}

	public string StatusText => GetStatusText();

	public string AddressText => GetAddressText("По адресу: ");

	public bool IsDescriptionVisible => !string.IsNullOrEmpty(Description);

	public string? Description => Order?.SelfPickupPointInfo?.Description;

	public string? ShopImage => Order?.SelfPickupPointInfo?.ImageUrl;

	public bool IsShopImageVisible => !string.IsNullOrEmpty(ShopImage);

	public string DeliveryDateTitle
	{
		get
		{
			if (!(Order == null))
			{
				if (!IsPickupOrder)
				{
					if (!Order.Delivery.DeliveryMethod.IsDelivery())
					{
						return "Дата и время Ашан Авто";
					}
					return "Дата и время доставки";
				}
				return "Дата и время самовывоза";
			}
			return "";
		}
	}

	public string DeliveryDateText
	{
		get
		{
			if (Order == null)
			{
				return "";
			}
			string text = Order.Delivery.DeliveryDate.DateTime.ToLongDateWithFullMonth();
			string deliveryToTime = Order.Delivery.DeliveryToTime;
			if (!string.IsNullOrWhiteSpace(deliveryToTime))
			{
				return text + ", " + deliveryToTime;
			}
			return text;
		}
	}

	public string PaymentTypeLabel => "Оплата";

	public string PaymentTypeText
	{
		get
		{
			if (!(Order == null))
			{
				return Order.PaymentMethod.ConvertToString();
			}
			return "";
		}
	}

	public string CommentTitleText => "Комментарий";

	public string? CommentContent => Order?.Delivery.Comment.Trim();

	public bool IsCommentVisible => !string.IsNullOrEmpty(CommentContent);

	public string GeneralLabel => "Итого";

	public string OrdersInfoBlockTitle => "Информация о заказе";

	public string AuchanDriveBlockTitle => "Информация об Авто";

	public string AuchanDriveRecipientBlockTitle => "Получатель";

	public string AuchanDriveMapBlockTitle => "Схема парковки";

	public string UserName => _userContext.Profile?.FirstName ?? "";

	public bool IsAuchanDriveOrder
	{
		get
		{
			if (!(Order == null))
			{
				return ((IListOrderModel)Order).IsAuchanDriveOrder;
			}
			return false;
		}
	}

	public bool IsPickupOrder
	{
		get
		{
			if (!(Order == null))
			{
				return ((IListOrderModel)Order).IsPickupOrder;
			}
			return false;
		}
	}

	public bool IsExpressDeliveryOrder
	{
		get
		{
			if (Order != null)
			{
				return ((IListOrderModel)Order).DeliveryMethod == DeliveryMethod.ExpressDelivery;
			}
			return false;
		}
	}

	public bool IsReadyToReceive
	{
		get
		{
			if (!(Order == null))
			{
				return ((IListOrderModel)Order).IsReadyToReceive;
			}
			return false;
		}
	}

	public string SelfPickupPointTitle => "Выдача интернет-заказов";

	public string WeightLabel => "Вес";

	public string WeightText
	{
		get
		{
			if (!(Order == null))
			{
				return Order.Delivery.Products.Sum((ProductModel c) => c.CalculateWeight()).ToString("0.00", _numbersCulture) + " кг";
			}
			return "";
		}
	}

	public string QtyPriceSumLabel
	{
		get
		{
			if (!(Order == null))
			{
				return $"Товары ({Order.Delivery.Products.Count}) на сумму";
			}
			return "";
		}
	}

	public string QtyPriceSumText
	{
		get
		{
			if (!(Order == null))
			{
				return $"{Order.ProductsOnlyPrice ?? (Order.Price - Order.DeliveryPrice - SurgeAmount):C2}";
			}
			return "";
		}
	}

	public bool IsDeliveryPriceBlockVisible => !IsPickupOrder;

	public string DeliveryPriceTitle
	{
		get
		{
			if (!IsAuchanDriveOrder)
			{
				if (!IsPickupOrder)
				{
					if (!IsExpressDeliveryOrder)
					{
						return "Стоимость доставки";
					}
					return "Стоимость быстрой доставки";
				}
				return "Стоимость самовывоза";
			}
			return "Стоимость Авто";
		}
	}

	public string DeliveryPriceText
	{
		get
		{
			if (!(Order == null))
			{
				if (!(Order.DeliveryPrice == 0m))
				{
					return $"{Order.DeliveryPrice:C0}";
				}
				return "Бесплатно";
			}
			return "";
		}
	}

	public bool PointsPaymentVisible
	{
		get
		{
			if (!(Order == null))
			{
				return Order.UsedPoints != 0;
			}
			return false;
		}
	}

	public string PointsPaymentTitle => "Списание баллов";

	public string PointsPaymentValue
	{
		get
		{
			if (!(Order == null))
			{
				return $"-{Order.UsedPoints}";
			}
			return "";
		}
	}

	public bool StampsPaymentVisible
	{
		get
		{
			if (Order != null)
			{
				return Order.UsedStamps != 0;
			}
			return false;
		}
	}

	public string StampsPaymentTitle => "Списание марок";

	public string StampsPaymentValue
	{
		get
		{
			if (!(Order == null))
			{
				return $"-{Order.UsedStamps}";
			}
			return "";
		}
	}

	public string GeneralPriceLabel => "Всего к оплате";

	public string GeneralPriceText
	{
		get
		{
			if (!(Order == null))
			{
				return $"{Order.Price:C2}";
			}
			return "";
		}
	}

	public string RepeatButtonText => "Повторить заказ";

	public bool RepeatButtonVisible
	{
		get
		{
			if (!PaymentAvailable)
			{
				return Order?.Status.IsInFinalState() ?? false;
			}
			return false;
		}
	}

	public string CancelButtonText => "Отменить заказ";

	public bool IsCancelButtonVisible => Order?.IsCancellationPossible ?? false;

	public string PayButtonText => "Оплатить заказ";

	public bool PaymentAvailable => Order?.AwaitingPayment ?? false;

	public string OrderQtyLabel => "Состав заказа";

	public string OrderQtyText
	{
		get
		{
			if (!(Order == null))
			{
				return Order.Delivery.Products.Count.ToString();
			}
			return "";
		}
	}

	public string OrderChangedText => "Есть изменения";

	public bool IsOrderChanged => Order?.Delivery.Products.Any((ProductModel p) => p.HasChanges) ?? false;

	public ObservableRangeCollection<OrderDetailProductItemViewModel> Products { get; } = new ObservableRangeCollection<OrderDetailProductItemViewModel>();

	public string ErrorTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorTitle");
			}
		}
	} = string.Empty;

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

	public string ErrorButtonText => "Повторить";

	public bool NeedShowSelfPickupPoint
	{
		get
		{
			OrderModel? order = Order;
			if ((object)order != null && order.Delivery.DeliveryMethod == DeliveryMethod.BySelf && (IsShopImageVisible || IsDescriptionVisible || (PickupPointImages.Count > 0 && PickupPointImages.All((string x) => !string.IsNullOrWhiteSpace(x)))))
			{
				if (Order.Status != CustomerStatus.ReadyToIssue)
				{
					return Order.Status == CustomerStatus.InProcessBuild;
				}
				return true;
			}
			return false;
		}
	}

	public string ReadyToReceiveButtonText
	{
		get
		{
			if (!IsAuchanDriveOrder)
			{
				return "Забрать заказ";
			}
			return "Я на месте";
		}
	}

	public string PickingPriceLabel => "Сервисный сбор";

	public string PickingPriceText => $"{PickingPrice:C0}";

	public int PickingPrice => Order?.PickingPrice ?? 0;

	public bool PickingPriceVisible => PickingPrice != 0;

	public string SurgeAmountLabel => "Повышенный спрос";

	public string SurgeAmountText => $"{SurgeAmount:C0}";

	public decimal SurgeAmount => (Order?.SurgeAmount).GetValueOrDefault();

	public bool SurgeAmountVisible => SurgeAmount > 0m;

	public RepeatOrderService RepeatOrderService { get; }

	public IAddToOrderButtonItemViewModel AddToOrderButtonItemViewModel { get; }

	public ICallToCourierItemViewModel CallToCourier { get; }

	public OrderDetailsViewModel(Parameter parameter, IOrdersRepository ordersRepository, IOrderCancellationReasonsService orderCancellationReasonsService, IUserContext userContext, DefaultErrorTranslator defaultErrorTranslator, Func<ProductModel, ICollection<IDisposable>, OrderDetailProductItemViewModel> viewModelFactory, IInfoMessageService infoMessageService, INavigationService navigationService, ICancelOrderManager cancelOrderManager, PaymentUrlHelper paymentUrlHelper, RepeatOrderService repeatOrderService, IAddToOrderButtonItemViewModel addToOrderButtonItemViewModel, ICallToCourierItemViewModel callToCourierItemViewModel)
	{
		_parameter = parameter;
		_ordersRepository = ordersRepository;
		_orderCancellationReasonsService = orderCancellationReasonsService;
		_userContext = userContext;
		_defaultErrorTranslator = defaultErrorTranslator;
		_viewModelFactory = viewModelFactory;
		_infoMessageService = infoMessageService;
		_navigationService = navigationService;
		_cancelOrderManager = cancelOrderManager;
		_paymentUrlHelper = paymentUrlHelper;
		RepeatOrderService = repeatOrderService;
		AddToOrderButtonItemViewModel = addToOrderButtonItemViewModel.AddTo(base.CloseDisposable);
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
		_reloadOrder.PerformDebouncingTask(LoadOrder).Subscribe().AddTo(base.CloseDisposable);
		PayCommand.PerformDebouncingTask(OpenPayment).Subscribe().AddTo(base.CloseDisposable);
		CallToCourier = callToCourierItemViewModel.AddTo(base.CloseDisposable);
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		await LoadOrder();
		if (_needReopen)
		{
			await OpenRepeatOrderPopup();
		}
	}

	public async Task LoadOrder()
	{
		State = VisualState.InProgress;
		Result<OrderModel, DomainError> result = await Task.Run(() => _ordersRepository.GetOrderAsync(_parameter.OrderId));
		if (result.IsFailure)
		{
			State = VisualState.Error;
			(ErrorTitle, ErrorMessage) = _defaultErrorTranslator.Translate(result.Error);
			return;
		}
		Order = result.Value;
		IEnumerable<OrderDetailProductItemViewModel> collection = Order.Delivery.Products.Select((ProductModel product) => _viewModelFactory(product, base.CloseDisposable)).To(SortProducts);
		Products.Clear();
		Products.AddRange(collection);
		State = VisualState.Default;
	}

	public void OnClick(OrderDetailProductItemViewModel item)
	{
		_navigateToProductDetails.OnNext(new ProductDetailsViewModel.Parameter(item.Code));
	}

	public async Task RepeatOrder()
	{
		AppAnalytics.AppMetrica.TrackEvent("myordersScreenButtonRepeatOrder");
		await OpenRepeatOrderPopup();
	}

	private async Task OpenRepeatOrderPopup()
	{
		_needReopen = false;
		await RepeatOrderService.OpenRepeatOrderPopup(Order.Delivery.Products, Order.IsAdult);
	}

	public async Task CancelOrder()
	{
		if (Order == null || !Order.IsCancellationPossible)
		{
			return;
		}
		AppAnalytics.AppMetrica.TrackEvent("myordersScreenButtonCancelOrder");
		Task<Result<PossibleOrderCancellationReasonsDto, DomainError>> reasonsPrefetchTask = Task.Run(() => _orderCancellationReasonsService.GetOrderCancellationReasonsAsync());
		if (await _cancelOrderManager.AskDoYouWantToCancelOrder() != AgreeState.Yes)
		{
			return;
		}
		State = VisualState.InProgress;
		await Task.WhenAll(Task.Delay(500), reasonsPrefetchTask);
		Result<PossibleOrderCancellationReasonsDto, DomainError> result = await reasonsPrefetchTask;
		State = VisualState.Default;
		if (result.IsFailure)
		{
			await DoCallToSupport();
			return;
		}
		AskForOrderCancellationReasonViewModel.Result userResponse = await _cancelOrderManager.AskForOrderCancellationReason(result.Value);
		if (userResponse != null)
		{
			State = VisualState.InProgress;
			Result<OrderCancellationResponseDto, DomainError> result2 = await Task.Run(() => _ordersRepository.CancelOrderAsync(Order.Id, userResponse.CancellationReason.Id, userResponse.Commentary));
			State = VisualState.Default;
			if (result2.IsFailure)
			{
				await Task.WhenAll(DoCallToSupport(), LoadOrder());
			}
			else
			{
				OrderIsCancelled(result2.Value.GotRefund);
				await LoadOrder();
			}
		}
		async Task DoCallToSupport()
		{
			if (await _cancelOrderManager.ShowOrderCannotBeCanceled() == AgreeState.Yes)
			{
				_navigationService.CallToAuchanSupport();
			}
		}
		void OrderIsCancelled(bool moneyBack)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(15, 1, stringBuilder2);
			handler.AppendLiteral("Заказ №");
			handler.AppendFormatted(Order.Number);
			handler.AppendLiteral(" отменен");
			stringBuilder2.Append(ref handler);
			if (moneyBack)
			{
				stringBuilder.AppendLine();
				stringBuilder.Append("Деньги уже возвращены на вашу карту");
			}
			_infoMessageService.ShowSnackbar(stringBuilder.ToString(), SnackbarStyle.Success, 5);
		}
	}

	private IEnumerable<OrderDetailProductItemViewModel> SortProducts(IEnumerable<OrderDetailProductItemViewModel> source)
	{
		List<OrderDetailProductItemViewModel> list = new List<OrderDetailProductItemViewModel>();
		List<OrderDetailProductItemViewModel> list2 = source.ToList();
		OrderDetailProductItemViewModel currentElement;
		for (currentElement = list2.FirstOrDefault(); currentElement != null; currentElement = list2.Find((OrderDetailProductItemViewModel product) => product.ItemId == currentElement.DestItemId) ?? list2.FirstOrDefault())
		{
			list.Add(currentElement);
			list2.Remove(currentElement);
		}
		return list;
	}

	public void ReloadOrder()
	{
		_reloadOrder.OnNext(Unit.Default);
	}

	public void TapOnReadyButton()
	{
		if (!(Order == null))
		{
			if (IsAuchanDriveOrder)
			{
				_openIsArrivedDriveDialog.OnNext(new AskIsPersonArrivedViewModel.Parameter(_parameter.OrderId));
			}
			if (IsPickupOrder)
			{
				_openGetOrderDialog.OnNext(new IssuingAreaViewModel.Parameter(new long[1] { Order.Id }, Order.Shop.Name, Order.Shop.Address, Order.Shop.PickupDescription, Order.Shop.PickupPhotoUrls.ToArray()));
			}
		}
	}

	private async Task OpenPayment()
	{
		if (!(Order == null))
		{
			AppAnalytics.AppMetrica.TrackEvent("myordersScreenButtonReturnToPayment");
			State = VisualState.InProgress;
			Result<OrderModel, DomainError> result = await _ordersRepository.GetOrderAsync(Order.Id);
			if (result.IsFailure || !result.Value.AwaitingPayment || string.IsNullOrWhiteSpace(result.Value.PaymentUrl))
			{
				_infoMessageService.ShowSnackbar("Срок оплаты истек", SnackbarStyle.Error, 5);
				await LoadOrder();
			}
			else
			{
				State = VisualState.Default;
				OpenPaymentCommand.Trigger(_paymentUrlHelper.GetParameter(result.Value.PaymentUrl, Order.Id.ToString()));
			}
		}
	}

	private string GetStatusText()
	{
		if (Order?.Delivery == null)
		{
			return "";
		}
		if (Order.IsDelayed && Order.Delivery.DeliveryMethod.IsDelivery())
		{
			string delayNotificationText = Order.Status.GetDelayNotificationText();
			if (!string.IsNullOrEmpty(delayNotificationText))
			{
				return delayNotificationText;
			}
		}
		if (Order.Status == CustomerStatus.Canceled)
		{
			return "Отменён";
		}
		if (Order.Status == CustomerStatus.Delivered)
		{
			return "Доставлен";
		}
		if (Order.Status == CustomerStatus.Completed)
		{
			return "Получен";
		}
		StringBuilder stringBuilder = new StringBuilder();
		switch (Order.Delivery.DeliveryMethod)
		{
		case DeliveryMethod.BySelf:
			stringBuilder.Append("Самовывоз");
			break;
		case DeliveryMethod.Drive:
			stringBuilder.Append("Ашан Авто");
			break;
		case DeliveryMethod.Delivery:
			stringBuilder.Append("Доставка");
			break;
		case DeliveryMethod.ExpressDelivery:
			stringBuilder.Append("Быстрая доставка");
			break;
		}
		stringBuilder.Append(" ").Append(Order.Delivery.DeliveryDate.GetTodayTomorrowOrDate(DtFormat, DtFormat));
		string deliveryToTime = Order.Delivery.DeliveryToTime;
		if (!string.IsNullOrWhiteSpace(deliveryToTime))
		{
			stringBuilder.Append(" ").Append(deliveryToTime);
		}
		return stringBuilder.ToString();
		static string DtFormat(DateTimeOffset dt)
		{
			return dt.ToString("dd.MM.yy");
		}
	}

	private string GetAddressText(string prefix)
	{
		if (Order?.Delivery == null)
		{
			return "";
		}
		return prefix + (Order.Delivery.DeliveryMethod.IsDelivery() ? Order.Delivery.Address : (Order.Shop.Address + ", \"" + Order.Shop.Name + "\""));
	}

	private void OnOrderChanged()
	{
		if (Order != null)
		{
			OrderProgress.SetOrder(Order);
			AddToOrderButtonItemViewModel.Setup(AddToOrderButtonPlacement.Order, Order, null);
			CallToCourier.Order = Order;
		}
	}

	public void CopyOrderNumber()
	{
		Clipboard.SetTextAsync(OrderNumber).SafeFireAndForget((Action<Exception>)null, false);
		_infoMessageService.ShowSnackbar("Номер заказа скопирован", SnackbarStyle.Success);
	}
}
