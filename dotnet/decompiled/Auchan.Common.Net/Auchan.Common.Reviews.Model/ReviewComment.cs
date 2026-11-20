using System;

namespace Auchan.Common.Reviews.Model;

public class ReviewComment
{
	public required int Id { get; init; }

	public required string? Author { get; init; }

	public required DateTime? CreatedAt { get; init; }

	public required string Text { get; init; }

	public bool Expanded { get; set; }
}
