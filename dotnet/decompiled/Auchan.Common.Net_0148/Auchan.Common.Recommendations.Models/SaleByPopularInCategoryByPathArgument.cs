using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Recommendations.Models;

public sealed record SaleByPopularInCategoryByPathArgument : AlgorithmArgument
{
	public required IReadOnlyList<string> CategoryPaths { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private SaleByPopularInCategoryByPathArgument(SaleByPopularInCategoryByPathArgument original)
		: base(original)
	{
		CategoryPaths = original.CategoryPaths;
	}

	public SaleByPopularInCategoryByPathArgument()
	{
	}
}
