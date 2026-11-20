using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Cart.Models;

public sealed record MarkingInfo
{
	public required int MarkingCount { get; init; }

	public required int Limit { get; init; }

	public required int Excess { get; init; }

	public required bool LimitExcess { get; init; }

	public static readonly MarkingInfo Empty = new MarkingInfo
	{
		MarkingCount = 0,
		Limit = 0,
		Excess = 0,
		LimitExcess = false
	};

	[CompilerGenerated]
	[SetsRequiredMembers]
	private MarkingInfo(MarkingInfo original)
	{
		MarkingCount = original.MarkingCount;
		Limit = original.Limit;
		Excess = original.Excess;
		LimitExcess = original.LimitExcess;
	}

	public MarkingInfo()
	{
	}
}
