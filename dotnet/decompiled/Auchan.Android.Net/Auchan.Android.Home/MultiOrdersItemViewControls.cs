using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Android.Profile.Orders;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Home;
using Auchan.Common.Profile.Orders;
using Google.Android.Material.Button;

namespace Auchan.Android.Home;

internal sealed class MultiOrdersItemViewControls
{
	private readonly View _view;

	private readonly OrderListCellControls _orderListCellControls;

	private readonly TextView _getOrdersButton;

	private readonly TextView _payOrderButton;

	private readonly AddToOrderButtonControls _addToOrderButtonControls;

	private readonly TextView _repeatButton;

	private readonly TextView _callToCourierButton;

	public MultiOrdersItemViewControls(CachingViewHolder viewHolder)
	{
		_ = viewHolder.ItemView.Context;
		_view = viewHolder.ItemView;
		_orderListCellControls = new OrderListCellControls(viewHolder.RequireCachedView<View>(2131297767));
		_getOrdersButton = viewHolder.RequireCachedView<MaterialButton>(2131296593);
		_payOrderButton = viewHolder.RequireCachedView<MaterialButton>(2131296594);
		_addToOrderButtonControls = new AddToOrderButtonControls(viewHolder.RequireCachedView<View>(2131296350));
		_repeatButton = viewHolder.RequireCachedView<TextView>(2131298200);
		_callToCourierButton = viewHolder.RequireCachedView<TextView>(2131296604);
	}

	public void Bind(HomeViewModel homeViewModel, OrderItemViewModel order, ICollection<IDisposable> disposable)
	{
		_getOrdersButton.Text = order.ReadyToReceiveButtonText;
		_getOrdersButton.Visibility = order.NeedToShowGetOrderButton.ToVisibility();
		_payOrderButton.Text = order.PayLabel;
		_payOrderButton.Visibility = order.PaymentAvailable.ToVisibility();
		_repeatButton.Visibility = order.RepeatButtonVisible.ToVisibility();
		_repeatButton.Text = order.RepeatButtonTitle;
		_callToCourierButton.Visibility = order.CallToCourier.IsVisible.ToVisibility();
		_callToCourierButton.Text = order.CallToCourier.Text;
		_orderListCellControls.Setup(order.Order);
		homeViewModel.OrdersHomeViewModel.BindEvents(((View)_getOrdersButton).OnClick((Action)delegate
		{
			homeViewModel.OrdersHomeViewModel.OnGetOrderClick(order);
		}), ((View)_payOrderButton).OnClick((Action)delegate
		{
			homeViewModel.OrdersHomeViewModel.PayCommand.Trigger(order);
		}), _view.OnClick((Action)delegate
		{
			homeViewModel.OrdersHomeViewModel.NavigateToOrderDetails(order.Order).SafeFireAndForget((Action<Exception>)null, false);
		}), ((View)_callToCourierButton).OnClick((Action)delegate
		{
			order.CallToCourier.Command.Trigger();
		})).AddTo(disposable);
		order.AddToOrderButtonItemViewModel.Setup(AddToOrderButtonPlacement.Home, order.Order, homeViewModel.OrdersHomeViewModel.NavigateToOrderDetailsCommand);
		_addToOrderButtonControls.Setup(order.AddToOrderButtonItemViewModel).AddTo(disposable);
	}
}
