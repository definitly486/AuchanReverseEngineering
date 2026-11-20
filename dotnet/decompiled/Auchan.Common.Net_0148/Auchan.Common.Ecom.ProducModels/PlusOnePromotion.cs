using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.ProducModels;

public sealed record PlusOnePromotion
{
	public required int? Value { get; init; }

	public required string? DateStart { get; init; }

	public required string? DateEnd { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private PlusOnePromotion(PlusOnePromotion original)
	{
		Value = original.Value;
		DateStart = original.DateStart;
		DateEnd = original.DateEnd;
	}

	public PlusOnePromotion()
	{
	}
}
