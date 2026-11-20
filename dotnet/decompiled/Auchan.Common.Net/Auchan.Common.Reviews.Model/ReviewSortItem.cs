using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Auchan.Common.Common;

namespace Auchan.Common.Reviews.Model;

public sealed record ReviewSortItem : ITitle
{
	public required string Title { get; init; }

	public ReviewSortField Field { get; init; }

	public ReviewSortDirection Direction { get; init; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private ReviewSortItem(ReviewSortItem original)
	{
		Title = original.Title;
		Field = original.Field;
		Direction = original.Direction;
	}

	public ReviewSortItem()
	{
	}
}
