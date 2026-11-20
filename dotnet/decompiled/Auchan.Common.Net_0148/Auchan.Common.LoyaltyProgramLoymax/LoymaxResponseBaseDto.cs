using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax;

public class LoymaxResponseBaseDto
{
	[JsonProperty("errors")]
	public List<LoymaxErrorDto>? Errors { get; set; }
}
