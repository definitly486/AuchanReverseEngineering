namespace Auchan.Common.Reviews.Model;

public sealed class Rate
{
	public required double Rating { get; init; }

	public required int ReviewsCount { get; init; }

	public required int Rate5 { get; init; }

	public required int Rate4 { get; init; }

	public required int Rate3 { get; init; }

	public required int Rate2 { get; init; }

	public required int Rate1 { get; init; }
}
