using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record PlusOnePromotionDto
{
	[JsonProperty("value")]
	public required int? Value { get; init; }

	[JsonProperty("date_start")]
	public required string? DateStart { get; init; }

	[JsonProperty("date_end")]
	public required string? DateEnd { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private PlusOnePromotionDto(PlusOnePromotionDto original)
	{
		Value = original.Value;
		DateStart = original.DateStart;
		DateEnd = original.DateEnd;
	}

	public PlusOnePromotionDto()
	{
	}
}
