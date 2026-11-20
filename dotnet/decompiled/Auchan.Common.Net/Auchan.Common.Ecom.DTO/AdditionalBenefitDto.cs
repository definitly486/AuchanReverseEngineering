using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.DTO;

internal sealed record AdditionalBenefitDto
{
	[JsonProperty("active_loyalty_mechanic", Required = Required.Always)]
	public required BenefitMechanic Mechanic { get; init; }

	[JsonProperty("informers")]
	public required CheckoutDataResponseDto.InformersDto? Informers { get; init; }

	[JsonProperty("points")]
	public required CheckoutDataResponseDto.PointsDto? Points { get; init; }

	[JsonProperty("promocode_condition")]
	public required CheckoutDataResponseDto.PromocodeConditionDto? PromocodeCondition { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private AdditionalBenefitDto(AdditionalBenefitDto original)
	{
		Mechanic = original.Mechanic;
		Informers = original.Informers;
		Points = original.Points;
		PromocodeCondition = original.PromocodeCondition;
	}

	public AdditionalBenefitDto()
	{
	}
}
