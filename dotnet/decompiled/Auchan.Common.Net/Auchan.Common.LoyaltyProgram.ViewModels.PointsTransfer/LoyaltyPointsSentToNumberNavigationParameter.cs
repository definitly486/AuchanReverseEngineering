using Auchan.Common.LoyaltyProgram.Enums;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer;

public class LoyaltyPointsSentToNumberNavigationParameter
{
	public LoyaltyPointType PointType { get; }

	public string PhoneNumber { get; }

	public int Amount { get; }

	public LoyaltyPointsSentToNumberNavigationParameter(LoyaltyPointType pointType, string phoneNumber, int amount)
	{
		PointType = pointType;
		PhoneNumber = phoneNumber;
		Amount = amount;
	}
}
