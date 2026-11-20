using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Reviews.Api.Ecom.Dto;

public class UnreviewedProductsDataDto
{
	[JsonProperty("myreviews_is_visible")]
	public bool MyReviewsSectionVisible { get; set; }

	[JsonProperty("qnt")]
	public int? Count { get; set; }

	[JsonProperty("products")]
	public List<UnreviewedProductDto>? Products { get; set; }
}
