using Newtonsoft.Json;

namespace Auchan.Common.Reviews.Api.Ecom.Dto;

public class UnreviewedProductsRequestBodyDto
{
	[JsonProperty("pagination", NullValueHandling = NullValueHandling.Ignore)]
	public OffsetPaginationDto? Pagination { get; set; }
}
