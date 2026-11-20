using Auchan.Common.Ecom.AddressStoreSelection;

namespace Auchan.Android.Helpers;

public static class ReceiveMethodConverter
{
	public static int FromReceiveMethodToIcon(ReceivingMethod receiveMethod)
	{
		return receiveMethod switch
		{
			ReceivingMethod.RegionDefault => 2131231278, 
			ReceivingMethod.ExpressDelivery => 2131231278, 
			ReceivingMethod.Delivery => 2131231278, 
			ReceivingMethod.Pickup => 2131231276, 
			ReceivingMethod.CarPickup => 2131231155, 
			_ => 2131231278, 
		};
	}
}
