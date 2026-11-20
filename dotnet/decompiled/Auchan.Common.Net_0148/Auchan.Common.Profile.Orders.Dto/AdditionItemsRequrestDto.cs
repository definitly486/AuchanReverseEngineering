using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.Orders.Dto;

internal sealed record AdditionItemsRequrestDto
{
	public sealed record ItemDto
	{
		[JsonProperty("offer_id")]
		public required long OfferId { get; init; }

		[JsonProperty("product_id")]
		public required long ProductId { get; init; }

		[JsonProperty("qty")]
		public required decimal Qty { get; init; }

		[JsonProperty("basket_step")]
		public required decimal BasketStep { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private ItemDto(ItemDto original)
		{
			OfferId = original.OfferId;
			ProductId = original.ProductId;
			Qty = original.Qty;
			BasketStep = original.BasketStep;
		}

		public ItemDto()
		{
		}
	}

	[JsonProperty("items")]
	public required IReadOnlyList<ItemDto> Items { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private AdditionItemsRequrestDto(AdditionItemsRequrestDto original)
	{
		Items = original.Items;
	}

	public AdditionItemsRequrestDto()
	{
	}
}
