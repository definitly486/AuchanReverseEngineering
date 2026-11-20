using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Auchan.Common.Common;
using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

internal sealed record ProductsStructMessageReceiveWSDTO : StructMessageReceivedWSDTO
{
	internal sealed record DataDto
	{
		[JsonProperty("products")]
		public required IReadOnlyList<ProductDto> Products { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private DataDto(DataDto original)
		{
			Products = original.Products;
		}

		public DataDto()
		{
		}
	}

	internal sealed record ProductDto
	{
		[JsonProperty("name")]
		public required string? Name { get; init; }

		[JsonProperty("price")]
		public required decimal? Price { get; init; }

		[JsonProperty("price_per_one")]
		public required decimal? PricePerOne { get; init; }

		[JsonProperty("gima_id")]
		public required string GimaId { get; init; }

		[JsonProperty("status")]
		public required string? Status { get; init; }

		[JsonProperty("qnt_return")]
		public required decimal? AvailableToReturn { get; init; }

		[JsonProperty("image_url")]
		public required string? ImageUrl { get; init; }

		[JsonProperty("is_refund_enabled")]
		public required bool IsEnabled { get; init; }

		[JsonProperty("type_code")]
		public required ItemTypeDto ItemType { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private ProductDto(ProductDto original)
		{
			Name = original.Name;
			Price = original.Price;
			PricePerOne = original.PricePerOne;
			GimaId = original.GimaId;
			Status = original.Status;
			AvailableToReturn = original.AvailableToReturn;
			ImageUrl = original.ImageUrl;
			IsEnabled = original.IsEnabled;
			ItemType = original.ItemType;
		}

		public ProductDto()
		{
		}
	}

	[JsonConverter(typeof(EnumMemberJsonConverter<ItemTypeDto>))]
	internal enum ItemTypeDto
	{
		[EnumMember(Value = "per_item")]
		Item,
		[EnumMember(Value = "per_kilo")]
		Weight
	}

	[JsonIgnore]
	public override CacheMessageType CacheMessageType => CacheMessageType.StructProducts;

	[JsonProperty("data")]
	public required DataDto Data { get; init; }

	public const string PREFIX = "[STRUCT=Products]";

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ProductsStructMessageReceiveWSDTO(ProductsStructMessageReceiveWSDTO original)
		: base(original)
	{
		Data = original.Data;
	}

	public ProductsStructMessageReceiveWSDTO()
	{
	}
}
