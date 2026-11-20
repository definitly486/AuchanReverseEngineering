using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public class CategoryDto
{
	[JsonProperty("id", Required = Required.Always)]
	public long Id { get; set; }

	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("code")]
	public string Code { get; set; }

	[JsonProperty("show_code")]
	public string? PathCode { get; set; }

	[JsonProperty("isAdult", Required = Required.Default)]
	public bool? IsAdult { get; set; }

	[JsonProperty("icon")]
	public string? Icon { get; set; }

	[JsonProperty("items")]
	public List<CategoryDto>? Items { get; set; }

	[JsonProperty("image")]
	public string? Image { get; set; }

	[JsonProperty("image_url")]
	public string? ImageUrl { get; set; }

	[JsonProperty("mobile_image_url")]
	public string? TopCategoryImageUrl { get; set; }

	[JsonProperty("productsCount")]
	public int ProductsCount { get; set; }

	[JsonProperty("activeProductsCount")]
	public int ActiveProductsCount { get; set; }

	[JsonProperty("sort")]
	public Dictionary<int, ProductSortSelectionDto>? DefaultSortMap { get; set; }
}
