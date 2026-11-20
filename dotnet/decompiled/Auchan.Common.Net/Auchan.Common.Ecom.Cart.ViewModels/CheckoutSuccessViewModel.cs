using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.Navigation;
using Auchan.Common.Profile.Orders;
using Auchan.Common.Profile.Orders.Enums;
using Auchan.Common.Recommendations;
using Auchan.Common.Recommendations.Models;
using Auchan.Common.Recommendations.ViewModels;
using Auchan.Common.StoreReview;
using Auchan.Common.UniversalLinks;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Ecom.Cart.ViewModels;

[RequiresAuthorization]
public class CheckoutSuccessViewModel : ScreenViewModel, IYandexMetricaScreenViewModel, IScreenViewModel
{
	public class Parameter
	{
		public CheckoutSuccessType Type { get; }

		public IEnumerable<string> OrderIds { get; }

		public PaymentCode PaymentType { get; }

		public Parameter(CheckoutSuccessType type, IEnumerable<string> orderIds, PaymentCode paymentType)
		{
			Type = type;
			OrderIds = orderIds;
			PaymentType = paymentType;
		}
	}

	private const string HINT_TEXT = "Заказ будет передан на сборку ближе ко времени получения";

	private const string EXPRESS_DELIVERY_HINT_TEXT = "Сборщик ищет самые качественные товары и проверяет сроки годности.";

	private readonly Parameter _parameter;

	private readonly ILogService _logService;

	private readonly CustomerFlagService _customerFlagService;

	private readonly Auchan.Common.StoreReview.StoreReview _storeReview;

	private readonly ICheckoutService _checkoutService;

	private readonly Cart _cart;

	private readonly Subject<Unit> _onNavigateToHome = new Subject<Unit>();

	private readonly Subject<Unit> _onNavigateToOrders = new Subject<Unit>();

	private readonly Dictionary<CheckoutSuccessType, string> _messageTextValues = new Dictionary<CheckoutSuccessType, string>
	{
		[CheckoutSuccessType.OrderPlaced] = "Спасибо за заказ!",
		[CheckoutSuccessType.PaymentCompleted] = "Спасибо за заказ!",
		[CheckoutSuccessType.PaymentFailed] = "К сожалению, оплата не удалась."
	};

	private readonly IEcomContext _ecomContext;

	private readonly Func<RecommendationBuilder> _recommendationBuilderFactory;

	private readonly IAdminContext _adminContext;

	private readonly IUniversalLinksService _universalLinksService;

	[CompilerGenerated]
	private string _003CHintText_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<CheckoutItemViewModel> _003CItems_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CTabBarVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsAdultOrder_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CNeedShowTooltip_003Ek__BackingField;

	public string MessageText
	{
		get
		{
			if (_parameter.PaymentType != PaymentCode.Offline)
			{
				return _messageTextValues[_parameter.Type];
			}
			return _messageTextValues[CheckoutSuccessType.OrderPlaced];
		}
	}

	public string HintText
	{
		[CompilerGenerated]
		get
		{
			return _003CHintText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CHintText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CHintText_003Ek__BackingField = value;
				RaisePropertyChanged("HintText");
			}
		}
	} = string.Empty;

	public RecommendationsViewModel Recommendations { get; }

	public string ActionButtonText => "На главную";

	public string TrackButtonText => "Перейти к заказу";

	public IObservable<Unit> NavigateToHomeCommand => _onNavigateToHome.Debounce();

	public IObservable<Unit> NavigateToOrders => _onNavigateToOrders.Debounce();

	public IReadOnlyList<CheckoutItemViewModel> Items
	{
		[CompilerGenerated]
		get
		{
			return _003CItems_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CItems_003Ek__BackingField, value))
			{
				_003CItems_003Ek__BackingField = value;
				RaisePropertyChanged("Items");
			}
		}
	} = Array.Empty<CheckoutItemViewModel>();

	public override bool TabBarVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CTabBarVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			if (_003CTabBarVisible_003Ek__BackingField != value)
			{
				_003CTabBarVisible_003Ek__BackingField = value;
				RaisePropertyChanged("TabBarVisible");
			}
		}
	}

	string IYandexMetricaScreenViewModel.ScreenNameForBaseEvents => "";

	string IYandexMetricaScreenViewModel.ScreenName => "ThankYou";

	public string AdultWarningText => "При получении заказа учитывайте ограничения по времени для продажи 18+ в вашем регионе. Для получения некоторых позиций необходим документ, удостоверяющий личность.";

	public bool IsAdultOrder
	{
		[CompilerGenerated]
		get
		{
			return _003CIsAdultOrder_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsAdultOrder_003Ek__BackingField != value)
			{
				_003CIsAdultOrder_003Ek__BackingField = value;
				RaisePropertyChanged("IsAdultOrder");
			}
		}
	}

	public IAddToOrderButtonItemViewModel AddToOrderButtonItemViewModel { get; }

	public bool NeedShowTooltip
	{
		[CompilerGenerated]
		get
		{
			return _003CNeedShowTooltip_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CNeedShowTooltip_003Ek__BackingField != value)
			{
				_003CNeedShowTooltip_003Ek__BackingField = value;
				RaisePropertyChanged("NeedShowTooltip");
			}
		}
	}

	public string TooltipTitle => "Что-то забыли?";

	public string TooltipDescription => "Добавьте товары из каталога в корзину\nдо начала сборки заказа и нажмите\nв корзине на кнопку «Да, добавить»";

	public string TooltipButtonText => "Понятно";

	public void OnContinueClick()
	{
		_onNavigateToHome.OnNext(Unit.Default);
	}

	public void OnTrackClick()
	{
		_onNavigateToOrders.OnNext(Unit.Default);
	}

	public CheckoutSuccessViewModel(Parameter parameter, ICheckoutService checkoutService, Cart cart, ILogService logService, RecommendationsViewModel recommendations, IEcomContext ecomContext, Func<RecommendationBuilder> recommendationBuilderFactory, CustomerFlagService customerFlagService, Auchan.Common.StoreReview.StoreReview storeReview, IAddToOrderButtonItemViewModel addToOrderButtonItemViewModel, IAdminContext adminContext, IUniversalLinksService universalLinksService)
	{
		_parameter = parameter;
		_checkoutService = checkoutService;
		_cart = cart;
		_logService = logService;
		Recommendations = recommendations.Setup(base.CloseDisposable, this);
		_ecomContext = ecomContext;
		_recommendationBuilderFactory = recommendationBuilderFactory;
		_customerFlagService = customerFlagService;
		_storeReview = storeReview;
		AddToOrderButtonItemViewModel = addToOrderButtonItemViewModel;
		_adminContext = adminContext;
		_universalLinksService = universalLinksService;
		universalLinksService.WeakOnLinkReceived += OnLinkReceived;
	}

	protected override async Task Start()
	{
		await base.Start();
		if (_parameter.Type != CheckoutSuccessType.PaymentFailed)
		{
			Result<CheckoutOrderDetails, DomainError>[] results = await _checkoutService.OrderData(_parameter.OrderIds);
			if (results.All((Result<CheckoutOrderDetails, DomainError> r) => r.IsSuccess))
			{
				await TrySendFirstPurchaseEvent(results);
				CheckoutItemViewModel[] items = results.Select((Result<CheckoutOrderDetails, DomainError> item) => new CheckoutItemViewModel(item.Value).AddTo(base.CloseDisposable)).ToArray();
				Items = items;
				IsAdultOrder = results.Any((Result<CheckoutOrderDetails, DomainError> x) => x.Value.IsAdult);
				HintText = (results.Any((Result<CheckoutOrderDetails, DomainError> x) => x.Value.DeliveryMethod == Auchan.Common.Profile.Orders.Enums.DeliveryMethod.ExpressDelivery) ? "Сборщик ищет самые качественные товары и проверяет сроки годности." : "Заказ будет передан на сборку ближе ко времени получения");
				CheckoutOrderDetails orderModel = (from i in results
					where i.Value.IsCanAddGoodsToOrder
					select i.Value).FirstOrDefault();
				AddToOrderButtonItemViewModel.Setup(AddToOrderButtonPlacement.ThankYouPurchase, orderModel, null);
				await LoadRecommendations();
				DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<Auchan.Common.StoreReview.StoreReview>().RequestReviewIfNeeded().SafeFireAndForget((Action<Exception>)null, false);
				AppAnalytics.Ecom.SuccessfulPurchase(_cart.CartId, results.Select((Result<CheckoutOrderDetails, DomainError> res) => res.Value.Dto).ToImmutableList());
			}
			else
			{
				Result<CheckoutOrderDetails, DomainError>[] array = results;
				for (int num = 0; num < array.Length; num++)
				{
					Result<CheckoutOrderDetails, DomainError> result = array[num];
					if (result.IsSuccess)
					{
						HintText = ((result.Value.DeliveryMethod == Auchan.Common.Profile.Orders.Enums.DeliveryMethod.ExpressDelivery) ? "Сборщик ищет самые качественные товары и проверяет сроки годности." : "Заказ будет передан на сборку ближе ко времени получения");
						AddToOrderButtonItemViewModel.Setup(AddToOrderButtonPlacement.ThankYouPurchase, result.Value, null);
						continue;
					}
					_logService.LogError("CheckoutSuccessViewModel", $"Ошибка при запросе данных заказа - {result.Error}", LogType.ApiRequest, SystemType.ECom);
					DevAnalytics.Report("Failed to get order data", new Dictionary<string, string>
					{
						{
							"orderIds",
							string.Join(",", _parameter.OrderIds)
						},
						{
							"reason",
							result.Error.ToString()
						}
					});
				}
			}
		}
		else
		{
			HintText = "Попробуйте повторить заказ.";
		}
		if (AddToOrderButtonItemViewModel.IsVisible && !_adminContext.AdditionalOrderTooltipShown)
		{
			NeedShowTooltip = true;
			_adminContext.AdditionalOrderTooltipShown = true;
		}
		await _cart.Update(Guid.NewGuid());
	}

	private async Task TrySendFirstPurchaseEvent(Result<CheckoutOrderDetails, DomainError>[] results)
	{
		bool num = results.Any((Result<CheckoutOrderDetails, DomainError> x) => x.IsSuccess && x.Value.Dto.Order.IsPayed && (x.Value.Dto.Payments?.Any(delegate(Payment p)
		{
			long paymentMethod = p.PaymentMethod;
			return ((ulong)(paymentMethod - 1) <= 1uL) ? true : false;
		}) ?? false));
		bool flag = results.Any((Result<CheckoutOrderDetails, DomainError> x) => x.IsSuccess && x.Value.Dto.Order.IsAdult);
		if ((!num && !flag) || _storeReview.IsFirstPurchaseApp == true)
		{
			return;
		}
		Result<CustomerFlags, DomainError> result = await _customerFlagService.GetCustomerFlags();
		if (result.IsFailure)
		{
			return;
		}
		if (result.IsSuccess && result.Value.IsFirstPurchaseApp)
		{
			_storeReview.IsFirstPurchaseApp = true;
			return;
		}
		decimal valueOrDefault = results.Sum((Result<CheckoutOrderDetails, DomainError> x) => x.Value.Dto.Payments?.Sum((Payment s) => s.Sum.Value)).GetValueOrDefault();
		string text = results.FirstOrDefault().Value.Dto?.Payments?.FirstOrDefault()?.Sum.Currency ?? "";
		long value = results.FirstOrDefault().Value.Dto?.Order.Id ?? (-1);
		string text2 = results.FirstOrDefault().Value.Dto?.Order.Number ?? string.Empty;
		AppAnalytics.AppMetrica.TrackEvent("first_purchase", ("currency", text ?? ""), ("order_price", $"{valueOrDefault}"), ("order_id", $"{value}"), ("order_number", text2 ?? ""));
		_storeReview.IsFirstPurchaseApp = true;
		await _customerFlagService.UpdateCustomerFlags(new UpdateCustomerFlagsRequestDto
		{
			IsFirstPurchaseApp = true
		});
	}

	private Task LoadRecommendations()
	{
		string[] productIds = _cart.Items.Select((ProductOffer x) => x.GimaId).ToArray();
		LoadRequest loadRequest = _recommendationBuilderFactory().AddRelatedWithPopularityPenalty("Подобрали для Вас", "typ", productIds).Build();
		return Recommendations.Load(loadRequest);
	}

	private void OnLinkReceived(object? sender, UniversalLinkServiceLinkEvent e)
	{
		_universalLinksService.WeakOnLinkReceived -= OnLinkReceived;
		e.Handled = true;
		_onNavigateToHome.OnNext(Unit.Default);
		ResendLinkWithDelay().SafeFireAndForget((Action<Exception>)null, false);
		async Task ResendLinkWithDelay()
		{
			YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
			_ = awaiter.IsCompleted;
			await awaiter;
			YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
			awaiter = yieldAwaiter;
			awaiter.GetResult();
			await _universalLinksService.HandleLink(e.Link);
		}
	}
}
