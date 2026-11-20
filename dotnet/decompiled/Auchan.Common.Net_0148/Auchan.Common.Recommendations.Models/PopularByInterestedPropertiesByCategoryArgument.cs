using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Recommendations.Models;

public sealed record PopularByInterestedPropertiesByCategoryArgument : AlgorithmArgument
{
	public required string CategoryPath { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private PopularByInterestedPropertiesByCategoryArgument(PopularByInterestedPropertiesByCategoryArgument original)
		: base(original)
	{
		CategoryPath = original.CategoryPath;
	}

	public PopularByInterestedPropertiesByCategoryArgument()
	{
	}
}
