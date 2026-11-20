using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Coupons.DTO;

public class CouponsResponseDTO
{
	[JsonProperty("data")]
	public List<CouponDTO> Data { get; set; }
}
