namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer;

public class LoyaltyPointsSentToCharityNavigationParameter
{
	public int Amount { get; }

	public int AvailableAmount { get; }

	public LoyaltyPointsSentToCharityNavigationParameter(int amount, int availableAmount)
	{
		Amount = amount;
		AvailableAmount = availableAmount;
	}
}
