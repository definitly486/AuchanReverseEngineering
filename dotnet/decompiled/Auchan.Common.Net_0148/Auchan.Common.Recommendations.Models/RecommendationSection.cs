using System.Collections.Generic;

namespace Auchan.Common.Recommendations.Models;

public sealed class RecommendationSection
{
	public required IReadOnlyList<IAlgorithm> Algorithms { get; init; }
}
