using Auchan.Common.Reviews.Api.Ecom.Dto;
using Newtonsoft.Json;

namespace Auchan.Common.LoyaltyProgramLoymax;

public class LoyaltyOperationsRequestBodyDto
{
	[JsonProperty("pagination")]
	public OffsetPaginationDto? Pagination { get; set; } = new OffsetPaginationDto
	{
		Offset = 0,
		Limit = 100
	};

	[JsonProperty("filter")]
	public LoyaltyOperationsFilterDto? Filter { get; set; }
}
