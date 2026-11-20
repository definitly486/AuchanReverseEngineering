using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

internal sealed record CheckoutFullDataRequestDto
{
	[JsonProperty("promo_code", NullValueHandling = NullValueHandling.Ignore)]
	public required string? PromoCode { get; init; }

	[JsonProperty("points", NullValueHandling = NullValueHandling.Ignore)]
	public required long? Points { get; init; }

	[JsonProperty("stamp_discount", NullValueHandling = NullValueHandling.Ignore)]
	public required bool? StampDiscount { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private CheckoutFullDataRequestDto(CheckoutFullDataRequestDto original)
	{
		PromoCode = original.PromoCode;
		Points = original.Points;
		StampDiscount = original.StampDiscount;
	}

	public CheckoutFullDataRequestDto()
	{
	}
}
