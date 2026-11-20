using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.SupportChat.DTO;

internal sealed record RefundProductsRequestDto
{
	public sealed record ProductDto
	{
		[JsonProperty("qnt")]
		public required decimal Quantity { get; init; }

		[JsonProperty("gima_id")]
		public required string GimaId { get; init; }

		[JsonProperty("price_per_one", NullValueHandling = NullValueHandling.Ignore)]
		public required decimal? PricePerOne { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private ProductDto(ProductDto original)
		{
			Quantity = original.Quantity;
			GimaId = original.GimaId;
			PricePerOne = original.PricePerOne;
		}

		public ProductDto()
		{
		}
	}

	[JsonProperty("products")]
	public required IReadOnlyList<ProductDto> Products { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private RefundProductsRequestDto(RefundProductsRequestDto original)
	{
		Products = original.Products;
	}

	public RefundProductsRequestDto()
	{
	}
}
