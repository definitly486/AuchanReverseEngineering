using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Recommendations.Models;

internal sealed record ProductPlacementsAndCrossSellForLargeBasketsArgument : ProductPlacementArgument
{
	public required long ProductGimaId { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ProductPlacementsAndCrossSellForLargeBasketsArgument(ProductPlacementsAndCrossSellForLargeBasketsArgument original)
		: base(original)
	{
		ProductGimaId = original.ProductGimaId;
	}

	public ProductPlacementsAndCrossSellForLargeBasketsArgument()
	{
	}
}
