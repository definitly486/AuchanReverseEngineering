using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Recommendations.Models;

public sealed record AlternativesArgument : AlgorithmArgument
{
	public required IReadOnlyList<string> ProductIds { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private AlternativesArgument(AlternativesArgument original)
		: base(original)
	{
		ProductIds = original.ProductIds;
	}

	public AlternativesArgument()
	{
	}
}
