using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Recommendations.API.DTO;

namespace Auchan.Common.Recommendations.Models;

public record ProductPlacementArgument : AlgorithmArgument
{
	public required PlacementId PlacementId { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	protected ProductPlacementArgument(ProductPlacementArgument original)
		: base(original)
	{
		PlacementId = original.PlacementId;
	}

	public ProductPlacementArgument()
	{
	}
}
