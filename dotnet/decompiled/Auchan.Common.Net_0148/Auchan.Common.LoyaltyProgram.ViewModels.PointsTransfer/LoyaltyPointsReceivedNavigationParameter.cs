using Auchan.Common.LoyaltyProgram.Enums;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer;

public class LoyaltyPointsReceivedNavigationParameter
{
	public LoyaltyPointType PointType { get; }

	public string Sender { get; }

	public int Amount { get; }

	public int AvailableAmount { get; }

	public LoyaltyPointsReceivedNavigationParameter(LoyaltyPointType pointType, string sender, int amount, int availableAmount)
	{
		PointType = pointType;
		Sender = sender;
		Amount = amount;
		AvailableAmount = availableAmount;
	}
}
