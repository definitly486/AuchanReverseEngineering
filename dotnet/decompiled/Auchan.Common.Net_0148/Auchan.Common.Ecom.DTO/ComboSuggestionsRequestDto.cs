using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record ComboSuggestionsRequestDto
{
	public sealed record ItemDto
	{
		[JsonProperty("product_id")]
		public required long ProductId { get; init; }

		[JsonProperty("offer_id")]
		public required long OfferId { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private ItemDto(ItemDto original)
		{
			ProductId = original.ProductId;
			OfferId = original.OfferId;
		}

		public ItemDto()
		{
		}
	}

	[JsonProperty("combo_item")]
	public required ItemDto Item { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ComboSuggestionsRequestDto(ComboSuggestionsRequestDto original)
	{
		Item = original.Item;
	}

	public ComboSuggestionsRequestDto()
	{
	}
}
