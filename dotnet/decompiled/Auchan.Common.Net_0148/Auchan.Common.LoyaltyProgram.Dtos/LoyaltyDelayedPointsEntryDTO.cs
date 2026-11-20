using System;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class LoyaltyDelayedPointsEntryDTO
{
	[JsonProperty("points")]
	public decimal Points { get; set; }

	[JsonProperty("pointType")]
	public string PointsType { get; set; } = string.Empty;

	[JsonProperty("pointTypeName")]
	public string PointsTypeName { get; set; } = string.Empty;

	[JsonProperty("customerId")]
	public long CustomerId { get; set; }

	[JsonProperty("bookDate")]
	public DateTime? BookDate { get; set; }

	[JsonProperty("trnDate")]
	public DateTime TransactionDate { get; set; }

	[JsonProperty("trnNo")]
	public string TransactionNumber { get; set; } = string.Empty;

	[JsonProperty("transactionId")]
	public long TransactionId { get; set; }
}
