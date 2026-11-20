using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Recommendations.Models;

public sealed record PopularEndlessArgument : AlgorithmArgument
{
	public required string PersonalizedBlockId { get; init; }

	public required string GenericBlockId { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private PopularEndlessArgument(PopularEndlessArgument original)
		: base(original)
	{
		PersonalizedBlockId = original.PersonalizedBlockId;
		GenericBlockId = original.GenericBlockId;
	}

	public PopularEndlessArgument()
	{
	}
}
