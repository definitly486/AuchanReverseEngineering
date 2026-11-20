using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgram.Dtos;

public class LoyaltyDelayedPointsDTO
{
	[JsonProperty("delayedPoints")]
	public List<LoyaltyDelayedPointsEntryDTO> DelayedPoints { get; set; } = new List<LoyaltyDelayedPointsEntryDTO>();
}
