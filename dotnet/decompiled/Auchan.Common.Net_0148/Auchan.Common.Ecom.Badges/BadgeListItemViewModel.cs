using System;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;

namespace Auchan.Common.Ecom.Badges;

public sealed class BadgeListItemViewModel : BaseItemViewModel
{
	public BadgesListViewModel Parent { get; }

	public BadgeItemViewModel Badge { get; }

	public UICommand<string> OpenLinkCommand { get; }

	public LinkedText Description { get; }

	public BadgeListItemViewModel(BadgesListViewModel parent, BadgeItemViewModel badge, UICommand<string> openLinkCommand)
	{
		if (string.IsNullOrEmpty(badge.Item.Description))
		{
			throw new ArgumentException("badge description should be not null", "badge");
		}
		Parent = parent;
		Badge = badge;
		OpenLinkCommand = openLinkCommand;
		Description = LinkedText.FromTextWithHref(Badge.Item.Description, delegate(string link)
		{
			OpenLinkCommand.Trigger(link);
		});
	}
}
