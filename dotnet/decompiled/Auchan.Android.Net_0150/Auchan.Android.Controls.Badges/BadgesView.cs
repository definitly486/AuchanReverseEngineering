using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Auchan.Android.Base;
using Auchan.Android.Base.WidgetBases;
using Auchan.Android.Extensions;
using Auchan.Common.Ecom.Badges;

namespace Auchan.Android.Controls.Badges;

[Register("auchan.BadgesView")]
public class BadgesView : LinearLayoutWidgetBase
{
	private BadgesListModel _badges = BadgesListModel.Empty;

	private bool _clickSet;

	protected BadgesView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public BadgesView(Context context)
		: base(context)
	{
	}

	public BadgesView(Context context, IAttributeSet? attrs)
		: base(context, attrs)
	{
	}

	public BadgesView(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public BadgesView(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	public void RemoveLastBadge()
	{
		if (ChildCount > 0)
		{
			RemoveViewAt(ChildCount - 1);
		}
	}

	public void SetBadges(BadgesListModel badges, bool smallStamps = false)
	{
		Clear();
		foreach (BadgeItemViewModel visibleItem in badges.VisibleItems)
		{
			if (visibleItem.Item.BadgeType == BadgeType.NPlusOne && badges.VisibleItems.Count > 1)
			{
				visibleItem.IsCompact = true;
			}
			if (visibleItem.Item.BadgeType == BadgeType.Stamps)
			{
				visibleItem.IsCompact = smallStamps;
			}
			BadgeView badgeView = new BadgeView(base.Context);
			badgeView.Setup(visibleItem);
			AddView(badgeView);
		}
		_badges = badges;
		if (!_clickSet)
		{
			_clickSet = true;
			base.Click += delegate(object? o, EventArgs e)
			{
				((BadgesView)o).OnClick();
			};
		}
	}

	private void OnClick()
	{
		if (base.Context is BaseActivity baseActivity && _badges.IsHaveBadgesWithDesicription)
		{
			BadgesListViewModel.Parameter parameter = new BadgesListViewModel.Parameter
			{
				Badges = _badges
			};
			BadgesListFragment badgesListFragment = baseActivity.SupportFragmentManager.FragmentFactory.Instantiate<BadgesListFragment>();
			badgesListFragment.Arguments = parameter.ToNavBundle();
			badgesListFragment.Show(baseActivity.SupportFragmentManager, null);
		}
	}

	public void Clear()
	{
		RemoveAllViews();
	}
}
