using Auchan.Common.Reviews.Model;

namespace Auchan.Common.Reviews;

public sealed class ReviewItemViewModel
{
	public required Review Review { get; init; }

	public required IReviewListViewModel Parent { get; init; }
}
