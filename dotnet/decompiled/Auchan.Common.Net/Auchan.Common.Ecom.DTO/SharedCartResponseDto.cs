using System;
using System.Collections.Generic;
using Auchan.Common.Ecom.Products;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.Ecom.DTO;

public sealed class SharedCartResponseDto
{
	public sealed class DataDto
	{
		[JsonProperty("items")]
		public IReadOnlyList<ProductDto> Items { get; init; } = Array.Empty<ProductDto>();

		[JsonProperty("items_unavailable")]
		public IReadOnlyList<ProductDto> Unavailable { get; init; } = Array.Empty<ProductDto>();

		[JsonProperty("summary", Required = Required.Always)]
		public required SummaryDto Summary { get; init; }
	}

	public sealed class ProductDto
	{
		[JsonProperty("id")]
		public required long? OfferId { get; init; }

		[JsonProperty("product_id", Required = Required.Always)]
		public required long ProductId { get; init; }

		[JsonProperty("code", Required = Required.Always)]
		public required string Code { get; init; }

		[JsonProperty("name", Required = Required.Always)]
		public required string Name { get; init; }

		[JsonProperty("count", Required = Required.Always)]
		public required decimal Count { get; init; }

		[JsonProperty("image_url")]
		public string? ImageUrl { get; init; }

		[JsonProperty("is_adult")]
		public bool IsAdult { get; init; }

		[JsonProperty("old_price")]
		public PriceDto? OldPrice { get; init; }

		[JsonProperty("price", Required = Required.Always)]
		public required PriceDto Price { get; init; }

		[JsonProperty("price_per_one")]
		public decimal? PricePerOne { get; init; }

		[JsonProperty("basket_step", Required = Required.Always)]
		public required decimal BasketStep { get; init; }

		[JsonProperty("stock_qty")]
		public decimal? StockQty { get; init; }

		[JsonProperty("selected_modifications")]
		public IReadOnlyCollection<ModificationDto> SelectedModifications { get; init; } = (IReadOnlyCollection<ModificationDto>)(object)Array.Empty<ModificationDto>();
	}

	public sealed class PriceDto
	{
		[JsonProperty("value", Required = Required.Always)]
		public decimal Value { get; init; }

		[JsonProperty("currency", Required = Required.Always)]
		public required string Currency { get; init; }

		[JsonProperty("per", Required = Required.Always)]
		[JsonConverter(typeof(StringEnumConverter))]
		public required ProductUnitType UnitType { get; init; }
	}

	public sealed class ModificationDto
	{
		[JsonProperty("code", Required = Required.Always)]
		public required string Code { get; init; }

		[JsonProperty("value", Required = Required.Always)]
		public required string Value { get; init; }
	}

	public sealed class SummaryDto
	{
		[JsonProperty("count", Required = Required.Always)]
		public required int Count { get; init; }

		[JsonProperty("is_adult")]
		public bool IsAdult { get; init; }

		[JsonProperty("total", Required = Required.Always)]
		public required TotalDto Total { get; init; }
	}

	public sealed class TotalDto
	{
		[JsonProperty("currency", Required = Required.Always)]
		public required string Currency { get; init; }

		[JsonProperty("value", Required = Required.Always)]
		public decimal Value { get; init; }
	}

	[JsonProperty("data", Required = Required.Always)]
	public required DataDto Data { get; init; }
}
