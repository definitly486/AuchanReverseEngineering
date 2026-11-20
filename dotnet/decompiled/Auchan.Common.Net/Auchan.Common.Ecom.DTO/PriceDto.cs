using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Ecom.Products;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auchan.Common.Ecom.DTO;

public sealed record PriceDto
{
	[JsonProperty("value")]
	public required decimal? Value { get; init; }

	[JsonProperty("currency")]
	public required string? Currency { get; init; }

	[JsonProperty("per")]
	[JsonConverter(typeof(StringEnumConverter))]
	public required ProductUnitType? UnitType { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private PriceDto(PriceDto original)
	{
		Value = original.Value;
		Currency = original.Currency;
		UnitType = original.UnitType;
	}

	public PriceDto()
	{
	}
}
