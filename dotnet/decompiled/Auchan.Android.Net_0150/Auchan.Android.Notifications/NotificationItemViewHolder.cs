using Android.Views;
using Android.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Notifications;

namespace Auchan.Android.Notifications;

public class NotificationItemViewHolder : CachingViewHolder
{
	private readonly View _unreadDot;

	private readonly TextView _title;

	private readonly TextView _text;

	private readonly TextView _date;

	private readonly ImageView _chevron;

	public NotificationItemViewHolder(View itemView)
		: base(itemView)
	{
		_unreadDot = this.RequireCachedView<View>(2131297703);
		_title = this.RequireCachedView<TextView>(2131297702);
		_text = this.RequireCachedView<TextView>(2131297701);
		_date = this.RequireCachedView<TextView>(2131297700);
		_chevron = this.RequireCachedView<ImageView>(2131297699);
	}

	public void Bind(NotificationItemViewModel item)
	{
		_title.Text = item.Title;
		_text.Text = item.Text;
		_date.Text = item.DateLabel;
		_chevron.Visibility = item.HasDeeplink.ToVisibility();
		_unreadDot.Visibility = item.IsUnread.ToVisibility();
	}
}
