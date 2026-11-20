using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed class CartItemsChangeRequest
{
	public sealed class ItemDto
	{
		[JsonProperty("id")]
		public required long? Id { get; init; }

		[JsonProperty("product_id")]
		public required long? ProductId { get; init; }

		[JsonProperty("qty", Required = Required.Always)]
		public required decimal Qty { get; init; }

		[JsonProperty("basket_step", Required = Required.Always)]
		public required decimal BasketStep { get; init; }

		[JsonProperty("is_selected")]
		public required bool IsSelected { get; init; }

		[JsonProperty("comment", NullValueHandling = NullValueHandling.Ignore)]
		public required string? Comment { get; init; }

		[JsonProperty("selected_modifications", NullValueHandling = NullValueHandling.Ignore)]
		public required IReadOnlyList<SelectedModificationDto>? SelectedModifications { get; init; }
	}

	[JsonProperty("can_change_offer", Required = Required.Always)]
	public required bool CanChangeOffer { get; init; }

	[JsonProperty("items", Required = Required.Always)]
	public required IReadOnlyList<ItemDto> Items { get; init; }
}
