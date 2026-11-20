using Auchan.Common.Ecom.AddressStoreSelection;

namespace Auchan.Common.Extensions;

public static class ReceivingMethodExtensions
{
	public static bool IsDelivery(this ReceivingMethod receivingMethod)
	{
		if (receivingMethod != ReceivingMethod.Delivery)
		{
			return receivingMethod == ReceivingMethod.ExpressDelivery;
		}
		return true;
	}

	public static bool IsPickupOrAuto(this ReceivingMethod receivingMethod)
	{
		if (receivingMethod != ReceivingMethod.Pickup)
		{
			return receivingMethod == ReceivingMethod.CarPickup;
		}
		return true;
	}
}
