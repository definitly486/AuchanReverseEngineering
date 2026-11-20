using System.Runtime.Serialization;

namespace Auchan.Common.InfoPages;

public enum InfoPagePosition
{
	[EnumMember(Value = "slug_only")]
	None,
	[EnumMember(Value = "documents")]
	Documents,
	[EnumMember(Value = "payment_delivery")]
	PaymentDelivery,
	[EnumMember(Value = "refund_exchange")]
	RefundExchange
}
