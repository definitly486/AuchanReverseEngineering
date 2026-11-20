using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

public sealed record DiscountDto
{
	[JsonProperty("value")]
	public required decimal? Value { get; init; }

	[JsonProperty("size")]
	public required int? ValueInPercent { get; init; }

	[JsonProperty("date_end")]
	public required string? EndDate { get; init; }

	[JsonProperty("is_pl_discount")]
	public required bool IsLoyaltyProgramDiscount { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private DiscountDto(DiscountDto original)
	{
		Value = original.Value;
		ValueInPercent = original.ValueInPercent;
		EndDate = original.EndDate;
		IsLoyaltyProgramDiscount = original.IsLoyaltyProgramDiscount;
	}

	public DiscountDto()
	{
	}
}
