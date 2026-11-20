using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Profile.Orders.Enums;

namespace Auchan.Common.Ecom.Cart.Models;

public static class CheckoutReceiveMethodExtensions
{
	public static bool IsDelivery(this CheckoutReceiveMethod @this)
	{
		if (@this == CheckoutReceiveMethod.Delivery || @this == CheckoutReceiveMethod.ExpressDelivery)
		{
			return true;
		}
		return false;
	}

	public static Auchan.Common.Profile.Orders.Enums.DeliveryMethod ToDeliverMethod(this CheckoutReceiveMethod @this)
	{
		return (Auchan.Common.Profile.Orders.Enums.DeliveryMethod)(@this + 1);
	}

	public static ReceivingMethod ToReceivingMethod(this CheckoutReceiveMethod @this)
	{
		return (ReceivingMethod)(@this + 1);
	}
}
