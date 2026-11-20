using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Auchan.Common.Ecom.Badges;

public sealed record BadgesListModel
{
	public IReadOnlyList<BadgeItemViewModel> Items { get; }

	public IReadOnlyList<BadgeItemViewModel> VisibleItems { get; }

	public static BadgesListModel Empty { get; } = new BadgesListModel(Array.Empty<BadgeItemViewModel>(), Array.Empty<BadgeItemViewModel>());

	public bool IsEmpty => this == Empty;

	public bool IsHaveBadgesWithDesicription => Items.Where((BadgeItemViewModel i) => !string.IsNullOrEmpty(i.Item.Description)).Any();

	private const int LIMIT = 2;

	public BadgesListModel(IReadOnlyList<BadgeModel> badges)
	{
		Items = badges.Select((BadgeModel i) => new BadgeItemViewModel
		{
			Item = i
		}).ToImmutableList();
		VisibleItems = Items.Take(2).ToImmutableList();
	}

	public BadgesListModel(IReadOnlyList<BadgeModel> badges, Func<BadgeItemViewModel, bool> visbileBadgesPredicate)
	{
		Items = badges.Select((BadgeModel i) => new BadgeItemViewModel
		{
			Item = i
		}).ToImmutableList();
		VisibleItems = Items.Where(visbileBadgesPredicate).Take(2).ToImmutableList();
	}

	[JsonConstructor]
	public BadgesListModel(IReadOnlyList<BadgeItemViewModel> items, IReadOnlyList<BadgeItemViewModel> visibleItems)
	{
		Items = items;
		VisibleItems = visibleItems;
	}

	[CompilerGenerated]
	private BadgesListModel(BadgesListModel original)
	{
		Items = original.Items;
		VisibleItems = original.VisibleItems;
	}
}
