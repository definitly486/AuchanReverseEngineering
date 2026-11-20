using System.Collections.Generic;
using Auchan.Common.Common;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Search.DTO;

public class SearchResultFilterDTO
{
	[JsonProperty("name")]
	public string Name { get; init; } = string.Empty;

	[JsonProperty("code")]
	public string Code { get; init; } = string.Empty;

	[JsonProperty("type")]
	[JsonConverter(typeof(EnumMemberJsonConverter<SearchFilterType>))]
	public SearchFilterType Type { get; init; }

	[JsonProperty("sort")]
	public int Sort { get; init; }

	[JsonProperty("Min")]
	public int? Min { get; init; }

	[JsonProperty("Max")]
	public int? Max { get; init; }

	[JsonProperty("disabled")]
	public bool? Disabled { get; init; }

	[JsonProperty("items")]
	public IReadOnlyList<SearchResultFilterMultiItemDTO>? Items { get; init; }

	[JsonProperty("informer")]
	public string? Informer { get; init; }
}
