using Auchan.Common.Reviews.Model;

namespace Auchan.Common.Reviews;

public sealed class UserReviewItemViewModel
{
	public required Review Review { get; init; }

	public required UserReviewsViewModel Parent { get; init; }
}
