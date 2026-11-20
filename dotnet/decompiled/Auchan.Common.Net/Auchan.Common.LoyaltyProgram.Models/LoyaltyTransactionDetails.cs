using System;
using System.Collections.Generic;

namespace Auchan.Common.LoyaltyProgram.Models;

public class LoyaltyTransactionDetails
{
	public string Type { get; }

	public string Number { get; }

	public DateTime ReceivingDateTime { get; }

	public double Amount { get; }

	public decimal AddedPoints { get; }

	public decimal AddedExpressPoints { get; }

	public decimal AddedStamps { get; }

	public decimal RemovedPoints { get; }

	public decimal RemovedExpressPoints { get; }

	public decimal RemovedStamps { get; }

	public decimal DelayedPoints { get; }

	public DateTime? DelayedPointsBookDate { get; }

	public List<LoyaltyProduct> Products { get; }

	public LoyaltyTransactionDetails(string type, string number, DateTime receivingDateTime, double amount, decimal addedPoints, decimal addedExpressPoints, decimal addedStamps, decimal removedPoints, decimal removedExpressPoints, decimal removedStamps, decimal delayedPoints, DateTime? delayedPointsBookDate, List<LoyaltyProduct> products)
	{
		Type = type;
		Number = number;
		ReceivingDateTime = receivingDateTime;
		Amount = amount;
		AddedPoints = addedPoints;
		AddedExpressPoints = addedExpressPoints;
		AddedStamps = addedStamps;
		RemovedPoints = removedPoints;
		RemovedExpressPoints = removedExpressPoints;
		RemovedStamps = removedStamps;
		DelayedPoints = delayedPoints;
		DelayedPointsBookDate = delayedPointsBookDate;
		Products = products;
	}
}
