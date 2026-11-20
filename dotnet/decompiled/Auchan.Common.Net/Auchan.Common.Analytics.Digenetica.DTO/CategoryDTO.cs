using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Analytics.Digenetica.DTO;

internal class CategoryDTO : BaseEventDTO
{
	[JsonProperty("pageNumber")]
	public string Page { get; set; }

	[JsonProperty("pageProducts")]
	public IReadOnlyList<string> ProductIds { get; set; } = Array.Empty<string>();

	[JsonProperty("categoryId")]
	public string CategoryId { get; set; }

	[JsonProperty("breadcrumbs")]
	public IReadOnlyList<string> Breadcrumbs { get; set; } = Array.Empty<string>();

	[JsonProperty("categoryName")]
	public string CategoryName { get; set; }
}
