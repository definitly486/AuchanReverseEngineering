using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Recommendations.API.DTO;

internal sealed class ProductPlacementsResponseDto
{
	public sealed class ContentDto
	{
		[JsonProperty("id")]
		public required string Id { get; init; }

		[JsonProperty("productIds")]
		public required IReadOnlyList<int> ProductIds { get; init; }
	}

	[JsonProperty("id")]
	public required string Id { get; init; }

	[JsonProperty("contentType")]
	public required string ContentType { get; init; }

	[JsonProperty("content")]
	public required IReadOnlyList<ContentDto> Content { get; init; }
}
