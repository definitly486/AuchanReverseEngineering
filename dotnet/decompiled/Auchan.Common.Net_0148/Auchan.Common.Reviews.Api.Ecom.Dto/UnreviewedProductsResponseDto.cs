using Newtonsoft.Json;

namespace Auchan.Common.Reviews.Api.Ecom.Dto;

public class UnreviewedProductsResponseDto
{
	[JsonProperty("data")]
	public UnreviewedProductsDataDto? Data { get; set; }

	[JsonProperty("meta")]
	public OffsetPaginationMetaDto? Meta { get; set; }
}
