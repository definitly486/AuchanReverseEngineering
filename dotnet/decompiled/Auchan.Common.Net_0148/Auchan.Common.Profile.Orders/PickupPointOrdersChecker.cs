using System.Collections.Generic;
using System.Linq;
using Auchan.Common.Profile.Orders.Enums;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Common.Profile.Orders;

public class PickupPointOrdersChecker
{
	public bool NeedToGroupOrdersByPickupPointAndStatus(OrderListModel order, IReadOnlyList<OrderListModel> allOrders, int countMoreThan = 1)
	{
		bool num = order.Status == CustomerStatus.ReadyToIssue;
		bool flag = order.DeliveryMethod == DeliveryMethod.BySelf;
		bool flag2 = allOrders.Count((OrderListModel x) => x.DeliveryDate.Day == order.DeliveryDate.Day && x.DeliveryTime.Equals(order.DeliveryTime) && x.StoreName == order.StoreName && x.Status == CustomerStatus.ReadyToIssue && x.DeliveryMethod == DeliveryMethod.BySelf) > countMoreThan;
		bool valueOrDefault = order.CollectOrder == true;
		return num && flag && flag2 && valueOrDefault;
	}

	public bool IsReadyToIssueDeliveredBySelfOrderInThisStore(OrderListModel currentOrder, OrderListModel anotherOrder)
	{
		bool num = anotherOrder.Status == CustomerStatus.ReadyToIssue;
		bool flag = anotherOrder.DeliveryMethod == DeliveryMethod.BySelf;
		bool flag2 = anotherOrder.StoreName == currentOrder.StoreName;
		bool flag3 = anotherOrder.DeliveryDate.Day == currentOrder.DeliveryDate.Day && anotherOrder.DeliveryTime.Equals(currentOrder.DeliveryTime);
		bool valueOrDefault = anotherOrder.CollectOrder == true;
		return num && flag && flag2 && flag3 && valueOrDefault;
	}

	public bool OrderAlreadyAdded(List<List<OrderItemViewModel>> listsOfOrders, OrderListModel currentOrder)
	{
		if (listsOfOrders.Any((List<OrderItemViewModel> x) => x.Any((OrderItemViewModel y) => y.OrderId == currentOrder.Id)))
		{
			return true;
		}
		return false;
	}
}
