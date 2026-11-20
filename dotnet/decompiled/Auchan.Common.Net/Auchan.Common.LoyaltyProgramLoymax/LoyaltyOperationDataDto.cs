using System;
using Auchan.Common.LoyaltyProgram.Enums;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax;

public class LoyaltyOperationDataDto
{
	[JsonProperty("operation_date")]
	public DateTime? OperationDate { get; set; }

	[JsonProperty("point_type")]
	public ExpirationPointType PointType { get; set; }

	[JsonProperty("amount")]
	public decimal Amount { get; set; }

	[JsonProperty("purchase")]
	public PointsPurchaseDto? Purchase { get; set; }
}
