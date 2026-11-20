using System;
using System.Collections.Generic;
using Auchan.Common.LoyaltyProgram.Enums;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class TransactionDetailsDto
{
	[JsonProperty("accountId")]
	public long? AccountId { get; set; }

	[JsonProperty("channel")]
	public string? Channel { get; set; }

	[JsonProperty("comments")]
	public string? Comments { get; set; }

	[JsonProperty("customerId")]
	public long? CustomerId { get; set; }

	[JsonProperty("date")]
	public DateTime Date { get; set; }

	[JsonProperty("identifierNo")]
	public string? IdentifierNo { get; set; }

	[JsonProperty("location")]
	public string? Location { get; set; }

	[JsonProperty("locationName")]
	public string? LocationName { get; set; }

	[JsonProperty("points")]
	public decimal? Points { get; set; }

	[JsonProperty("status")]
	public string? Status { get; set; }

	[JsonProperty("statusName")]
	public string? StatusName { get; set; }

	[JsonProperty("totalValue")]
	public decimal? TotalValue { get; set; }

	[JsonProperty("transactionId")]
	public string? TransactionId { get; set; }

	[JsonProperty("type")]
	[JsonConverter(typeof(LoyaltyPurchaseOperationTypeConverter))]
	public LoyaltyPurchaseOperationTypeDto OperationType { get; set; }

	[JsonProperty("typeName")]
	public string? TypeName { get; set; }

	[JsonProperty("trnNo")]
	public string? TransactionNumber { get; set; }

	[JsonProperty("pointsBalances")]
	public List<PointsBalanceDto>? PointsBalances { get; set; }

	[JsonProperty("order_details")]
	public OrderDetailsDto? OrderDetails { get; set; }

	[JsonProperty("order")]
	public OrderDataDto? Order { get; set; }

	[JsonProperty("isRefund")]
	public bool? IsRefund { get; set; }
}
