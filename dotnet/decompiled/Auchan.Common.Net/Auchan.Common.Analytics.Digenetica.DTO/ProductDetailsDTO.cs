using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Analytics.Digenetica.DTO;

internal class ProductDetailsDTO : BaseEventDTO
{
	[JsonProperty("availability")]
	public bool Availability { get; set; }

	[JsonProperty("productId")]
	public string ProductId { get; set; }

	[JsonProperty("productName")]
	public string ProductName { get; set; }

	[JsonProperty("breadcrumbs")]
	public IReadOnlyList<string>? Breadcrumbs { get; set; }
}
