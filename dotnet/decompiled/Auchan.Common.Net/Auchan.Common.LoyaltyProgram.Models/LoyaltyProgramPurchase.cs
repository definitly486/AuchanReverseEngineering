using System;
using Auchan.Common.LoyaltyProgram.Enums;

namespace Auchan.Common.LoyaltyProgram.Models;

public class LoyaltyProgramPurchase
{
	public required LoyaltyTransactionDetails Transaction { get; init; }

	public required string TransactionId { get; init; }

	public required string TransactionNumber { get; init; }

	public required string OrderNumber { get; init; }

	public required LoyaltyPurchaseOperationTypeDto OperationType { get; init; }

	public required DateTime OperationDate { get; init; }

	public required decimal Total { get; init; }

	public required decimal Points { get; init; }

	public required decimal Stamps { get; init; }

	public required string? Source { get; init; }

	public required decimal EPoints { get; init; }

	public required decimal DelayedPoints { get; init; }

	public required DateTime DelayedPointsBookDate { get; init; }

	public required int DelayedPointsIndex { get; init; }

	public required int? StoreExternalId { get; init; }

	public required bool IsOperationTimeOnly { get; init; }

	public required string Comments { get; init; }

	public bool IsRefund { get; init; }
}
