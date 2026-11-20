using System.Runtime.Serialization;

namespace Auchan.Common.AdminTool.Enums;

public enum ExtraPromotionTransition
{
	[EnumMember(Value = "to-sscan")]
	ToSScan = 1,
	[EnumMember(Value = "to-category*")]
	ToCategory,
	[EnumMember(Value = "to-cashback")]
	ToCashback,
	[EnumMember(Value = "to-store*")]
	ToStore,
	[EnumMember(Value = "to-cabinet")]
	ToCabinet,
	[EnumMember(Value = "to-cart")]
	ToCart
}
