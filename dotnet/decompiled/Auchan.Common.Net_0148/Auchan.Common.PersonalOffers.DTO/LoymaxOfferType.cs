using System.Runtime.Serialization;

namespace Auchan.Common.PersonalOffers.DTO;

public enum LoymaxOfferType
{
	Unknown,
	[EnumMember(Value = "CheckAmountCashbackNoLimit")]
	CheckAmountCashbackNoLimit,
	[EnumMember(Value = "CheckAmountCashback")]
	CheckAmountCashback,
	[EnumMember(Value = "CashbackPercentCategory")]
	CashbackPercentCategory,
	[EnumMember(Value = "CashbackPercentGoods")]
	CashbackPercentGoods,
	[EnumMember(Value = "CheckAmountDiscountNoLimit")]
	CheckAmountDiscountNoLimit,
	[EnumMember(Value = "CheckAmountDiscount")]
	CheckAmountDiscount,
	[EnumMember(Value = "DiscountPercentCategory")]
	DiscountPercentCategory,
	[EnumMember(Value = "DiscountPercentGoods")]
	DiscountPercentGoods,
	[EnumMember(Value = "CheckAmountFixDiscountNoLimit")]
	CheckAmountFixDiscountNoLimit
}
