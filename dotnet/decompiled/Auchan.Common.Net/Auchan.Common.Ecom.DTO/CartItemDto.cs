using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record CartItemDto
{
	[JsonProperty("count", Required = Required.Always)]
	public required decimal Count { get; init; }

	[JsonProperty("p", Required = Required.Always)]
	public required CartProductDto Product { get; init; }

	[JsonProperty("selectedModifications", Required = Required.Default)]
	public required IReadOnlyList<SelectedModificationDto>? SelectedModifications { get; init; }

	[JsonProperty("comment")]
	public required string? Comment { get; init; }

	[JsonProperty("is_selected", Required = Required.Always)]
	public required bool IsSelected { get; init; }

	[JsonProperty("marking_active")]
	public required bool IsMarkedProduct { get; init; }

	[JsonProperty("inCombo")]
	public bool InCombo { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private CartItemDto(CartItemDto original)
	{
		Count = original.Count;
		Product = original.Product;
		SelectedModifications = original.SelectedModifications;
		Comment = original.Comment;
		IsSelected = original.IsSelected;
		IsMarkedProduct = original.IsMarkedProduct;
		InCombo = original.InCombo;
	}

	public CartItemDto()
	{
	}
}
