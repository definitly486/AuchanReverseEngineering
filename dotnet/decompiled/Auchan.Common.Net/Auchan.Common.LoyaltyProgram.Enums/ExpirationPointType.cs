using System.Runtime.Serialization;

namespace Auchan.Common.LoyaltyProgram.Enums;

public enum ExpirationPointType
{
	[EnumMember(Value = "EXTRA_PT")]
	EPoints,
	[EnumMember(Value = "AUCH_PT")]
	Points,
	[EnumMember(Value = "STAMP_PT")]
	Stamps,
	[EnumMember(Value = "")]
	PromoPoints
}
