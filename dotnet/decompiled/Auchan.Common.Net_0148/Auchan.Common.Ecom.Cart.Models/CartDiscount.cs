using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record CartDiscount
{
	public required double Value { get; init; }

	public required int ValueInPercent { get; init; }

	public required string EndDate { get; init; }

	public required bool IsLoyaltyProgramDiscount { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private CartDiscount(CartDiscount original)
	{
		Value = original.Value;
		ValueInPercent = original.ValueInPercent;
		EndDate = original.EndDate;
		IsLoyaltyProgramDiscount = original.IsLoyaltyProgramDiscount;
	}

	public CartDiscount()
	{
	}
}
