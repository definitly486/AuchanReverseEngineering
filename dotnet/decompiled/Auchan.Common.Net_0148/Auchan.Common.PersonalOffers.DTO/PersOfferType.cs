using System.Runtime.Serialization;

namespace Auchan.Common.PersonalOffers.DTO;

public enum PersOfferType
{
	Unknown,
	[EnumMember(Value = "discount")]
	Discount,
	[EnumMember(Value = "cashback")]
	Cashback
}
