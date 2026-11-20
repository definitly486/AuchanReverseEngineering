using System;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos.Balance;

public class LoyaltyProgramBalanceDetailsItemDto
{
	[JsonProperty("balanceDate")]
	public DateTime? BalanceDate { get; set; }

	[JsonProperty("customerId")]
	public int CustomerId { get; set; }

	[JsonProperty("pointType")]
	public string? PointsType { get; set; }

	[JsonProperty("pointTypeName")]
	public string? PointsTypeName { get; set; }

	[JsonProperty("delayedPoints")]
	public decimal DelayedPoints { get; set; }

	[JsonProperty("points")]
	public decimal Points { get; set; }
}
