using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Recommendations.Models;

public sealed record PopularInCategoryByPathArgument : AlgorithmArgument
{
	public required IReadOnlyList<string> CategoryPaths { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private PopularInCategoryByPathArgument(PopularInCategoryByPathArgument original)
		: base(original)
	{
		CategoryPaths = original.CategoryPaths;
	}

	public PopularInCategoryByPathArgument()
	{
	}
}
