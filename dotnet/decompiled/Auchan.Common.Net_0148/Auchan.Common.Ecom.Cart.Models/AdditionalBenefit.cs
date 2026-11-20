using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Ecom.DTO;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record AdditionalBenefit
{
	public required BenefitMechanic Mechanic { get; init; }

	public required Informers? Informers { get; init; }

	public required Points? Points { get; init; }

	public required PromocodeCondition? PromocodeCondition { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private AdditionalBenefit(AdditionalBenefit original)
	{
		Mechanic = original.Mechanic;
		Informers = original.Informers;
		Points = original.Points;
		PromocodeCondition = original.PromocodeCondition;
	}

	public AdditionalBenefit()
	{
	}
}
