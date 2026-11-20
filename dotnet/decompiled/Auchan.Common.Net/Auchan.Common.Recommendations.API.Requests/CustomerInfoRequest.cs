using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API.Requests;

public class CustomerInfoRequest : TrackingRequest
{
	[JsonProperty("customerId", Required = Required.Always)]
	public required string CustomerId { get; init; }

	[JsonProperty("defaultStockId", Required = Required.Default)]
	public string? DefaultStockId { get; set; }

	[JsonProperty("softLinks", Required = Required.Default)]
	public SoftLinks? SoftLinks { get; set; }

	[JsonProperty("customData", Required = Required.Default)]
	public CustomData? CustomData { get; set; }

	[JsonProperty("isAgreedToReceiveMarketingMail", Required = Required.Default)]
	public bool IsAgreedToReceiveMarketingMail { get; set; }
}
