using System;

namespace Auchan.Common.Ecom.AddressStoreSelection;

public static class ReceiveMethodConverter
{
	public static string FromReceiveModeToString(ReceivingMethod receiveInfoMode)
	{
		return receiveInfoMode switch
		{
			ReceivingMethod.RegionDefault => "Ваш регион:", 
			ReceivingMethod.Delivery => "Привезем заказ домой:", 
			ReceivingMethod.ExpressDelivery => "Привезем заказ домой:", 
			ReceivingMethod.Pickup => "Самовывоз", 
			ReceivingMethod.CarPickup => "Авто", 
			_ => throw new NotSupportedException(), 
		};
	}
}
