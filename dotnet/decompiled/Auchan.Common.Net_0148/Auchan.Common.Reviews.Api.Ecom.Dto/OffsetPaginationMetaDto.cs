using Newtonsoft.Json;

namespace Auchan.Common.Reviews.Api.Ecom.Dto;

public class OffsetPaginationMetaDto
{
	[JsonProperty("pagination")]
	public OffsetPaginationDto? Pagination { get; set; }
}
