using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.Orders.Models;
using Auchan.Common.UniversalLinks;

namespace Auchan.Common.Profile.Orders;

internal sealed class AddToOrderButtonItemViewModel : BaseItemViewModel, IAddToOrderButtonItemViewModel, IBindable, INotifyPropertyChanged, IDisposable
{
	private AddToOrderButtonPlacement _placement;

	private IOrderModel? _orderModel;

	private UICommand<OrderDetailsViewModel.Parameter>? _navigateToOrderDetailsCommand;

	private readonly Lazy<IAdminContext> _adminContext;

	private readonly Lazy<IUniversalLinksService> _universalLinksService;

	private readonly Lazy<IOrderDetailsParameterFactory> _orderDetailsParameterFactory;

	private readonly Lazy<AppMetrica> _appMetrica;

	[CompilerGenerated]
	private bool _003CIsVisible_003Ek__BackingField;

	public string InfoText => "Что-то забыли? Просто добавьте нужные товары в корзину и подтвердите выбор до начала сборки заказа";

	public string AddToCartButtonText => "Добавить товары";

	public UICommand AddToCartButtonCommand { get; } = new UICommand();

	public bool IsVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsVisible_003Ek__BackingField != value)
			{
				_003CIsVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsVisible");
			}
		}
	}

	public AddToOrderButtonItemViewModel(Lazy<IAdminContext> adminContext, Lazy<IUniversalLinksService> universalLinksService, Lazy<IOrderDetailsParameterFactory> orderDetailsParameterFactory, Lazy<AppMetrica> appMetrica)
	{
		_adminContext = adminContext;
		_universalLinksService = universalLinksService;
		_orderDetailsParameterFactory = orderDetailsParameterFactory;
		_appMetrica = appMetrica;
		AddToCartButtonCommand.Subscribe(delegate
		{
			_appMetrica.Value.AddToOrderButtonTap(_placement);
			_universalLinksService.Value.HandleLink("auchan://categories?activate_tab=Catalog");
		}).AddTo(base.Disposables);
	}

	public void Setup(AddToOrderButtonPlacement placement, IOrderModel? orderModel, UICommand<OrderDetailsViewModel.Parameter>? navigateToOrderDetailsCommand)
	{
		_placement = placement;
		_orderModel = orderModel;
		_navigateToOrderDetailsCommand = navigateToOrderDetailsCommand;
		IsVisible = _adminContext.Value.AppConfig.IsCanAddGoodsToOrder && (orderModel?.IsCanAddGoodsToOrder ?? false);
	}

	public async Task NavigateToOrderDetails()
	{
		if (_navigateToOrderDetailsCommand != null && _orderModel != null)
		{
			OrderDetailsViewModel.Parameter parameter = await _orderDetailsParameterFactory.Value.CreateAsync(_orderModel);
			if (parameter != null)
			{
				_navigateToOrderDetailsCommand.Trigger(parameter);
			}
		}
	}
}
