using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Recommendations.Models;

public sealed record SearchArgument : AlgorithmArgument
{
	public required string SearchPhrase { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private SearchArgument(SearchArgument original)
		: base(original)
	{
		SearchPhrase = original.SearchPhrase;
	}

	public SearchArgument()
	{
	}
}
