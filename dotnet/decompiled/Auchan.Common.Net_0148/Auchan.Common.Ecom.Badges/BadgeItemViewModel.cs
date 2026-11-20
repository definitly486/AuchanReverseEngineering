using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Auchan.Common.Ecom.Badges;

public sealed record BadgeItemViewModel
{
	public required BadgeModel Item { get; init; }

	public bool IsCompact { get; set; }

	[CompilerGenerated]
	[SetsRequiredMembers]
	private BadgeItemViewModel(BadgeItemViewModel original)
	{
		Item = original.Item;
		IsCompact = original.IsCompact;
	}

	public BadgeItemViewModel()
	{
	}
}
