using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Recommendations.Models;

public sealed record PersonalCompositeForCategoryByCategoryPathArgument : AlgorithmArgument
{
	public required string CategoryPath { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private PersonalCompositeForCategoryByCategoryPathArgument(PersonalCompositeForCategoryByCategoryPathArgument original)
		: base(original)
	{
		CategoryPath = original.CategoryPath;
	}

	public PersonalCompositeForCategoryByCategoryPathArgument()
	{
	}
}
