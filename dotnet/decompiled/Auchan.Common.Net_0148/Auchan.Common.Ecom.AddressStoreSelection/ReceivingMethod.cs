using System.Runtime.Serialization;

namespace Auchan.Common.Ecom.AddressStoreSelection;

public enum ReceivingMethod
{
	[EnumMember(Value = "default")]
	RegionDefault,
	[EnumMember(Value = "delivery")]
	Delivery,
	[EnumMember(Value = "pickup")]
	Pickup,
	[EnumMember(Value = "car_pickup")]
	CarPickup,
	[EnumMember(Value = "express_delivery")]
	ExpressDelivery
}
