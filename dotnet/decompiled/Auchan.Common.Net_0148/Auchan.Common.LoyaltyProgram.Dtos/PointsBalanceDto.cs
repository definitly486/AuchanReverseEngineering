using Auchan.Common.LoyaltyProgram.Enums;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class PointsBalanceDto
{
	[JsonProperty("customerId")]
	public long? CustomerId { get; set; }

	[JsonProperty("pointType")]
	public ExpirationPointType? PointType { get; set; }

	[JsonProperty("pointTypeName")]
	public string? PointTypeName { get; set; }

	[JsonProperty("points")]
	public decimal? Points { get; set; }

	[JsonProperty("status")]
	public string? Status { get; set; }

	[JsonProperty("statusName")]
	public string? StatusName { get; set; }

	[JsonProperty("billingPartner")]
	public string? BillingPartner { get; set; }

	[JsonProperty("expirationDate")]
	public string? ExpirationDate { get; set; }
}
