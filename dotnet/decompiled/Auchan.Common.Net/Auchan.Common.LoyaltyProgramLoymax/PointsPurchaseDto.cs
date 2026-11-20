using System;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax;

public class PointsPurchaseDto
{
	[JsonProperty("operation_type")]
	public string OperationType { get; set; } = "";

	[JsonProperty("purchase_time")]
	public DateTime PurchaseTime { get; set; }

	[JsonProperty("cheque_number")]
	public string ChequeNumber { get; set; } = "";

	[JsonProperty("purchase_id")]
	public long PurchaseId { get; set; }
}
