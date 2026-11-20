using Auchan.Common.Reviews.Api.Ecom.Dto;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax;

public class LoymaxHistoryResponseDto : LoymaxResponseBaseDto
{
	[JsonProperty("data")]
	public LoymaxHistoryDataDto? Data { get; set; }

	[JsonProperty("meta")]
	public OffsetPaginationMetaDto? Meta { get; set; }
}
