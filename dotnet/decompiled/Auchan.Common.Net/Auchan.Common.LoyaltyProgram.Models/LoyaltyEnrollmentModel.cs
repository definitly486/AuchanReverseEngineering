namespace Auchan.Common.LoyaltyProgram.Models;

public class LoyaltyEnrollmentModel
{
	public int? LoyaltyId { get; }

	public string? CardNumber { get; }

	public string? VirtualCardNumber { get; }

	public LoyaltyEnrollmentModel(int? loyaltyId, string? virtualCardNumber, string? cardNumber)
	{
		LoyaltyId = loyaltyId;
		VirtualCardNumber = virtualCardNumber;
		CardNumber = cardNumber;
	}
}
