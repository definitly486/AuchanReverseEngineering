using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

internal sealed record RecalculateRequestDto
{
	[JsonProperty("promo_code", NullValueHandling = NullValueHandling.Ignore)]
	public required string? PromoCode { get; init; }

	[JsonProperty("points", NullValueHandling = NullValueHandling.Ignore)]
	public required long? Points { get; init; }

	[JsonProperty("timeslot_id", NullValueHandling = NullValueHandling.Ignore)]
	public required string? TimeslotId { get; init; }

	[JsonProperty("stamp_discount", NullValueHandling = NullValueHandling.Ignore)]
	public required bool? StampDiscount { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private RecalculateRequestDto(RecalculateRequestDto original)
	{
		PromoCode = original.PromoCode;
		Points = original.Points;
		TimeslotId = original.TimeslotId;
		StampDiscount = original.StampDiscount;
	}

	public RecalculateRequestDto()
	{
	}
}
