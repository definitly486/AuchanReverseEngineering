using System.Collections.Generic;
using System.Runtime.Serialization;
using Auchan.Common.Common;
using Auchan.Common.Ecom.DTO;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.CtmShelves.DTO;

internal sealed class ShelfResponseDto
{
	internal sealed class DataDto
	{
		[JsonProperty("id")]
		public required int Id { get; init; }

		[JsonProperty("title")]
		public required string Title { get; init; }

		[JsonProperty("subtitle")]
		public required string? Subtitle { get; init; }

		[JsonProperty("rank")]
		public required int Rank { get; init; }

		[JsonProperty("container")]
		[JsonConverter(typeof(EnumMemberJsonConverter<ContainerDto>))]
		public required ContainerDto Container { get; init; }

		[JsonProperty("see_all_link")]
		public required string? SeeAllLink { get; init; }

		[JsonProperty("banner")]
		public required BannerDto? Banner { get; init; }

		[JsonProperty("products")]
		public required IReadOnlyList<ProductDto> Products { get; init; }
	}

	internal sealed class BannerDto
	{
		[JsonProperty("banner_image_mobile")]
		public required string? ImageUrl { get; init; }

		[JsonProperty("button_text")]
		public required string? ButtonText { get; init; }

		[JsonProperty("button_link")]
		public required string? ButtonLink { get; init; }
	}

	public enum ContainerDto
	{
		Unknown,
		[EnumMember(Value = "mp_offers")]
		Offers,
		[EnumMember(Value = "mp_hot_price")]
		HotPrice
	}

	[JsonProperty("data")]
	public required IReadOnlyList<DataDto> Data { get; init; }
}
