using System;
using System.Collections.Generic;

namespace Auchan.Common.Reviews.Model;

public sealed class ReviewList
{
	public required IReadOnlyList<Review> Reviews { get; init; }

	public required int Count { get; init; }

	public required bool HasImages { get; init; }

	public required ReviewSortDirection SortDirection { get; init; }

	public required ReviewSortField SortField { get; init; }

	public static ReviewList Empty { get; } = new ReviewList
	{
		Reviews = Array.Empty<Review>(),
		Count = 0,
		HasImages = false,
		SortDirection = ReviewSortDirection.Descend,
		SortField = ReviewSortField.Rate
	};
}
