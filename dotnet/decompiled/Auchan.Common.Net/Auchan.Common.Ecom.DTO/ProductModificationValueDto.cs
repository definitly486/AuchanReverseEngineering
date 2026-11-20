using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record ProductModificationValueDto
{
	[JsonProperty("value")]
	public required string Value { get; init; } = string.Empty;

	[JsonProperty("description")]
	public required string Description { get; init; } = string.Empty;

	[JsonProperty("previewImageUrl")]
	public required string PreviewImageUrl { get; init; } = string.Empty;

	[JsonProperty("imageUrls")]
	public required IReadOnlyList<string> ImageUrls { get; init; } = Array.Empty<string>();

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ProductModificationValueDto(ProductModificationValueDto original)
	{
		Value = original.Value;
		Description = original.Description;
		PreviewImageUrl = original.PreviewImageUrl;
		ImageUrls = original.ImageUrls;
	}

	public ProductModificationValueDto()
	{
	}
}
