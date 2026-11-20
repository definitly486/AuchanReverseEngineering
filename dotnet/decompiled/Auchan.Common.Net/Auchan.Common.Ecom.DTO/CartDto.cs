using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record CartDto
{
	public sealed record MinCartDto
	{
		[JsonProperty("totalCount")]
		public required int TotalCount { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private MinCartDto(MinCartDto original)
		{
			TotalCount = original.TotalCount;
		}

		public MinCartDto()
		{
		}
	}

	[JsonProperty("summary", Required = Required.Always)]
	public required Summary Summary { get; init; }

	[JsonProperty("items", Required = Required.Always)]
	public required IReadOnlyList<CartItemDto> Items { get; set; }

	[JsonProperty("itemsUnavailable", Required = Required.Always)]
	public required IReadOnlyList<CartItemDto> ItemsUnavailable { get; init; }

	[JsonProperty("minCart")]
	public required MinCartDto MinCart { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private CartDto(CartDto original)
	{
		Summary = original.Summary;
		Items = original.Items;
		ItemsUnavailable = original.ItemsUnavailable;
		MinCart = original.MinCart;
	}

	public CartDto()
	{
	}
}
