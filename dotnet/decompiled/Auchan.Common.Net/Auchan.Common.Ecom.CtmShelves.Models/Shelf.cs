using System.Collections.Generic;
using Auchan.Common.Recommendations.Models;

namespace Auchan.Common.Ecom.CtmShelves.Models;

public sealed class Shelf
{
	public required int Id { get; init; }

	public required string Title { get; init; }

	public required string? Subtitle { get; init; }

	public required int Rank { get; init; }

	public required Container Container { get; init; }

	public required CtmLink SeeAllLink { get; init; }

	public required ShelfBanner? Banner { get; init; }

	public required IReadOnlyList<ProductWithAnalyticsInfo> Products { get; init; }
}
