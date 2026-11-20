using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class LoyaltyProgramPurchaseDto
{
	[JsonProperty("transactionId")]
	public long TransactionId { get; set; }

	[JsonProperty("trnNo")]
	public string TransactionNumber { get; set; } = string.Empty;

	[JsonProperty("accountId")]
	public string? Id { get; set; }

	[JsonProperty("date")]
	public DateTime? DateOperation { get; set; }

	[JsonProperty("totalValue")]
	public decimal Total { get; set; }

	[JsonProperty("points")]
	public decimal Points { get; set; }

	[JsonProperty("channel")]
	public string? Source { get; set; }

	[JsonProperty("location")]
	public string? StoreExternalId { get; set; }

	[JsonProperty("comments")]
	public string? Comments { get; set; }

	[JsonProperty("pointsBalances")]
	public List<PointsBalanceDto>? PointsBalances { get; set; }
}
