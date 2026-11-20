using System;
using Auchan.Common.LoyaltyProgram.Enums;

namespace Auchan.Common.LoyaltyProgram.Models;

public class DelayedPointsEntryEntity
{
	public decimal Points { get; set; }

	public ExpirationPointType PointsType { get; set; }

	public string PointsTypeName { get; set; } = string.Empty;

	public long CustomerId { get; set; }

	public DateTime OperationTime { get; set; }

	public DateTime TransactionDate { get; set; }

	public string ChequeNumber { get; set; } = string.Empty;

	public long TransactionId { get; set; }
}
