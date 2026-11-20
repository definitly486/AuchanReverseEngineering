using System;
using System.Collections.Generic;
using System.Linq;
using Android.Views;
using Android.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.Orders;
using Google.Android.Material.Button;

namespace Auchan.Android.Profile.Orders;

public class OrdersItemViewHolder : CachingViewHolder
{
	private readonly OrdersViewModel _ordersViewModel;

	private readonly TextView _orderItemDateHeader;

	private readonly MaterialButton _getOrdersButton;

	private readonly MaterialButton _payButton;

	private readonly MaterialButton _repeatButton;

	private readonly AddToOrderButtonControls _addToOrderButtonControls;

	private readonly OrderListCellControls _orderListCellControls;

	private readonly TextView _callToCourierButton;

	public OrdersItemViewHolder(View itemView, OrdersViewModel ordersViewModel)
		: base(itemView)
	{
		_ordersViewModel = ordersViewModel;
		_orderItemDateHeader = this.RequireCachedView<TextView>(2131297765);
		_getOrdersButton = this.RequireCachedView<MaterialButton>(2131296593);
		_payButton = this.RequireCachedView<MaterialButton>(2131297850);
		_repeatButton = this.RequireCachedView<MaterialButton>(2131298200);
		_addToOrderButtonControls = new AddToOrderButtonControls(this.RequireCachedView<View>(2131296350));
		_orderListCellControls = new OrderListCellControls(this.RequireCachedView<View>(2131297767));
		_callToCourierButton = this.RequireCachedView<TextView>(2131296604);
	}

	public void DoBind(List<OrderItemViewModel> orderItemViewModels, ICollection<IDisposable> disposable)
	{
		OrderItemViewModel item = orderItemViewModels.First();
		_orderItemDateHeader.Visibility = item.IsShowHeader.ToVisibility();
		_orderItemDateHeader.Text = item.DateHeader;
		_getOrdersButton.Visibility = item.NeedToShowGetOrderButton.ToVisibility();
		_getOrdersButton.Text = item.ReadyToReceiveButtonText;
		_payButton.Visibility = item.PaymentAvailable.ToVisibility();
		_payButton.Text = item.PayLabel;
		_repeatButton.Visibility = item.RepeatButtonVisible.ToVisibility();
		_repeatButton.Text = item.RepeatButtonTitle;
		_ordersViewModel.BindEvents(((View)_getOrdersButton).OnClick((Action)delegate
		{
			_ordersViewModel.OnGetOrderClick(orderItemViewModels);
		}), ((View)_payButton).OnClick((Action)delegate
		{
			_ordersViewModel.PayCommand.Trigger(orderItemViewModels);
		}), ((View)_repeatButton).OnClick((Action)delegate
		{
			_ordersViewModel.RepeatOrder(item).SafeFireAndForget((Action<Exception>)null, false);
		}), ((View)_callToCourierButton).OnClick((Action)delegate
		{
			item.CallToCourier.Command.Trigger();
		})).AddTo(disposable);
		_callToCourierButton.Visibility = item.CallToCourier.IsVisible.ToVisibility();
		_callToCourierButton.Text = item.CallToCourier.Text;
		_orderListCellControls.Setup(item.Order);
		item.AddToOrderButtonItemViewModel.Setup(AddToOrderButtonPlacement.Listing, item.Order, _ordersViewModel.NavigateNextCommand);
		_addToOrderButtonControls.Setup(item.AddToOrderButtonItemViewModel).AddTo(disposable);
	}
}
