using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class PointsTransferResponseDto
{
	[JsonProperty("data")]
	public Data? Data { get; set; }

	[JsonProperty("errors")]
	public Error[]? Errors { get; set; }
}
