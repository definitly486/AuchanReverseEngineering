using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Recommendations.Models;

internal sealed record ProductGroupPlacementsArgument : ProductPlacementArgument
{
	public required IReadOnlyList<long> GimaIds { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ProductGroupPlacementsArgument(ProductGroupPlacementsArgument original)
		: base(original)
	{
		GimaIds = original.GimaIds;
	}

	public ProductGroupPlacementsArgument()
	{
	}
}
