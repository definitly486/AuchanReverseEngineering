using System.Runtime.Serialization;

namespace Auchan.Common.Ecom.DTO;

public enum ProductBadge
{
	Unknown,
	[EnumMember(Value = "cashback")]
	Cashback,
	[EnumMember(Value = "cashback_delayed")]
	DelayedCashback,
	[EnumMember(Value = "plus_one_promotion")]
	NPlusOne,
	[EnumMember(Value = "discount")]
	Discount,
	[EnumMember(Value = "edlp")]
	PriceDown,
	[EnumMember(Value = "collectible")]
	Stamps,
	[EnumMember(Value = "new")]
	NewProduct,
	[EnumMember(Value = "private_label")]
	PrivateLabel,
	[EnumMember(Value = "combo")]
	Combo,
	[EnumMember(Value = "progress_discount_1")]
	ProgressiveDiscount1,
	[EnumMember(Value = "progress_discount_2")]
	ProgressiveDiscount2
}
