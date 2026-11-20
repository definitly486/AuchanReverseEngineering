using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Recommendations.Models;

public sealed record CategoryPlacementsArgument : ProductPlacementArgument
{
	public required string CategoryPath { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private CategoryPlacementsArgument(CategoryPlacementsArgument original)
		: base(original)
	{
		CategoryPath = original.CategoryPath;
	}

	public CategoryPlacementsArgument()
	{
	}
}
