using System;
using System.Collections.Generic;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Common.Profile.Orders;

public class HomeOrderItemViewModel : OrderItemViewModel
{
	public override bool NeedToShowGetOrderButton
	{
		get
		{
			if (!base.CanGetViaPickup)
			{
				return base.CanGetViaDrive;
			}
			return true;
		}
	}

	public override string PayLabel => "Оплатить заказ";

	public HomeOrderItemViewModel(OrderListModel order, bool showHeader, Func<ProductModel, ICollection<IDisposable>, OrderItemProductItemViewModel> viewModelFactory, IAddToOrderButtonItemViewModel addToOrderButtonItemViewModel, ICallToCourierItemViewModel callToCourierItemViewModel, bool showNumberLongText = false)
		: base(order, showHeader, viewModelFactory, addToOrderButtonItemViewModel, callToCourierItemViewModel, showNumberLongText)
	{
	}
}
