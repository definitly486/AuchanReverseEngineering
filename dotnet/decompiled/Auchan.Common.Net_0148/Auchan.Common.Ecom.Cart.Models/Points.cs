using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record Points
{
	public required long Total { get; init; }

	public required long Available { get; init; }

	public required string? BurnablePoints { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private Points(Points original)
	{
		Total = original.Total;
		Available = original.Available;
		BurnablePoints = original.BurnablePoints;
	}

	public Points()
	{
	}
}
