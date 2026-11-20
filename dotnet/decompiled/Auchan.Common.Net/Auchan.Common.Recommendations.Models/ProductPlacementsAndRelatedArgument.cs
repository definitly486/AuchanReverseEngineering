using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Recommendations.Models;

internal sealed record ProductPlacementsAndRelatedArgument : ProductPlacementArgument
{
	public required long ProductGimaId { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ProductPlacementsAndRelatedArgument(ProductPlacementsAndRelatedArgument original)
		: base(original)
	{
		ProductGimaId = original.ProductGimaId;
	}

	public ProductPlacementsAndRelatedArgument()
	{
	}
}
