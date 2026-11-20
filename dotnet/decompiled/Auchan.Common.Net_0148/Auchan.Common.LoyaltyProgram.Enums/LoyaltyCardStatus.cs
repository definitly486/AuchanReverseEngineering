using Auchan.Common.Helpers.Enums;

namespace Auchan.Common.LoyaltyProgram.Enums;

public enum LoyaltyCardStatus
{
	[StringMappingValue("A")]
	Active,
	[StringMappingValue("B")]
	Blocked,
	[StringMappingValue("C")]
	Closed,
	[StringMappingValue("F")]
	ClosedByFraud,
	None
}
