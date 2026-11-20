using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Recommendations.Models;

public record AlgorithmArgument
{
	public required string Title { get; init; }

	public required string BlockId { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	protected AlgorithmArgument(AlgorithmArgument original)
	{
		Title = original.Title;
		BlockId = original.BlockId;
	}

	public AlgorithmArgument()
	{
	}
}
