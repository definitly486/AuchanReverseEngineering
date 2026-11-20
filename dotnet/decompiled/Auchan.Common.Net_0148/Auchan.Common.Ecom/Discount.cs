using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom;

public sealed record Discount
{
	public required decimal Value { get; init; }

	public required int ValueInPercent { get; init; }

	public required DateTime EndDate { get; init; }

	public required bool IsLoyaltyProgramDiscount { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private Discount(Discount original)
	{
		Value = original.Value;
		ValueInPercent = original.ValueInPercent;
		EndDate = original.EndDate;
		IsLoyaltyProgramDiscount = original.IsLoyaltyProgramDiscount;
	}

	public Discount()
	{
	}
}
