using Auchan.Common.Reviews.Api.Ecom.Dto;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax;

public class LoyaltyOperationsResponseDto
{
	[JsonProperty("data")]
	public LoyaltyOperationDataDto[]? Data { get; set; }

	[JsonProperty("meta")]
	public OffsetPaginationMetaDto? Meta { get; set; }
}
