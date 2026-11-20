using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.PriceChecker;

public sealed record PriceCheckerResponseDto
{
	public sealed record DataDto
	{
		[JsonProperty("ean")]
		public required string Ean { get; init; }

		[JsonProperty("name")]
		public required string Name { get; init; }

		[JsonProperty("gima_id")]
		public required string GimaId { get; init; }

		[JsonProperty("is_online")]
		public required bool IsOnline { get; init; }

		[JsonProperty("product_type_id")]
		public required UnitTypeDto UnitType { get; init; }

		[JsonProperty("showcase_type")]
		public required ShowcaseTypeDto ShowCaseType { get; init; }

		[JsonProperty("price")]
		public required decimal Price { get; init; }

		[JsonProperty("discount")]
		public required DiscountDto? Discount { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private DataDto(DataDto original)
		{
			Ean = original.Ean;
			Name = original.Name;
			GimaId = original.GimaId;
			IsOnline = original.IsOnline;
			UnitType = original.UnitType;
			ShowCaseType = original.ShowCaseType;
			Price = original.Price;
			Discount = original.Discount;
		}

		public DataDto()
		{
		}
	}

	public enum ShowcaseTypeDto
	{
		[EnumMember(Value = "offline")]
		Offline,
		[EnumMember(Value = "online")]
		Online
	}

	public sealed class DiscountDto
	{
		[JsonProperty("discount_price")]
		public required decimal? DiscountPrice { get; init; }

		[JsonProperty("size")]
		public required int? InPercent { get; init; }

		[JsonProperty("discount_end_date")]
		public required DateTime? EndDate { get; init; }
	}

	public enum UnitTypeDto
	{
		Unknown,
		Unit,
		PerKilo
	}

	[JsonProperty("data")]
	public required DataDto Data { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private PriceCheckerResponseDto(PriceCheckerResponseDto original)
	{
		Data = original.Data;
	}

	public PriceCheckerResponseDto()
	{
	}
}
