using System.Runtime.Serialization;

namespace Auchan.Common.AdminTool.Enums;

public enum ExtraPromotionLocation
{
	[EnumMember(Value = "on-category*")]
	OnCategory = 1,
	[EnumMember(Value = "on-stores")]
	OnStores,
	[EnumMember(Value = "on-start")]
	OnStart,
	[EnumMember(Value = "on-cashback")]
	OnCashback,
	[EnumMember(Value = "on-sscan")]
	OnScan,
	[EnumMember(Value = "on-cart")]
	OnCart
}
