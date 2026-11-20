using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Coupons.DTO;

public class CouponResponseDTO
{
	[JsonProperty("data")]
	public CouponDTO Data { get; set; }
}
