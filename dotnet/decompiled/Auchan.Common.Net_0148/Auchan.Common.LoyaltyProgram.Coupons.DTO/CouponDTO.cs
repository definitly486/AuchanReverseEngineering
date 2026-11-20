using System;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Coupons.DTO;

public class CouponDTO
{
	[JsonProperty("id")]
	public long Id { get; set; }

	[JsonProperty("usageStartDate")]
	public DateTime? UsageStartDate { get; set; }

	[JsonProperty("expiryDate")]
	public DateTime? ExpiryDate { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; } = string.Empty;

	[JsonProperty("description")]
	public string Description { get; set; } = string.Empty;

	[JsonProperty("bottom_description")]
	public string BottomDescription { get; set; } = string.Empty;

	[JsonProperty("mediaUrls")]
	public string MediaUrl { get; set; } = string.Empty;

	[JsonProperty("couponNumber")]
	public string CouponNumber { get; set; } = string.Empty;

	[JsonProperty("image")]
	public string Image { get; set; } = string.Empty;

	[JsonProperty("background")]
	public string? BackgroundHEXColor { get; set; }
}
