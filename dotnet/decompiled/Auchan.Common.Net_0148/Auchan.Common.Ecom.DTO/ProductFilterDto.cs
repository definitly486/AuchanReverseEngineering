using System.Collections.Generic;
using Auchan.Common.Common;
using Auchan.Common.Ecom.ProducModels.Filters;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed class ProductFilterDto
{
	[JsonProperty("name")]
	public string Name { get; set; } = string.Empty;

	[JsonProperty("code")]
	public string Code { get; set; } = string.Empty;

	[JsonProperty("url")]
	public string? Url { get; set; }

	[JsonProperty("type")]
	[JsonConverter(typeof(EnumMemberJsonConverter<ProductFilterType>))]
	public ProductFilterType Type { get; set; }

	[JsonProperty("isFixed")]
	public bool IsFixed { get; set; }

	[JsonProperty("isUrlContain")]
	public bool IsUrlContain { get; set; }

	[JsonProperty("positionInUrl")]
	public int? PositionInUrl { get; set; }

	[JsonProperty("sort")]
	public int Sort { get; set; }

	[JsonProperty("min")]
	public int? Min { get; set; }

	[JsonProperty("max")]
	public int? Max { get; set; }

	[JsonProperty("disabled")]
	public bool? Disabled { get; set; }

	[JsonProperty("forActive")]
	public bool IsForActive { get; set; }

	[JsonProperty("items")]
	public IReadOnlyList<ProductResultFilterMultiItemDTO>? Items { get; set; }

	[JsonProperty("informer")]
	public string? Informer { get; set; }
}
