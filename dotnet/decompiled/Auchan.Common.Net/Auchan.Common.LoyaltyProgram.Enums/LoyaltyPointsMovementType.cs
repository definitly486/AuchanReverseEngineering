using Auchan.Common.Helpers.Enums;

namespace Auchan.Common.LoyaltyProgram.Enums;

public enum LoyaltyPointsMovementType
{
	Undefined,
	[StringMappingValue("purchase")]
	Purchase,
	[StringMappingValue("purchase_ret")]
	PurchaseReturn,
	[StringMappingValue("marks_inc")]
	MarksIncome,
	[StringMappingValue("marks_out")]
	MarksTransfer,
	[StringMappingValue("pts_in")]
	PointsIncome,
	[StringMappingValue("cashback")]
	Cashback
}
