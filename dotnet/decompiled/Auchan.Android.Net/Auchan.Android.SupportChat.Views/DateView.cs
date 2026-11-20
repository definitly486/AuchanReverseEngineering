using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;

namespace Auchan.Android.SupportChat.Views;

public sealed class DateView : ConstraintLayout, IChatContentView
{
	public TextView DateTextView { get; }

	public DateView(Context? context)
		: base(context)
	{
		View.Inflate(context, 2131493195, this);
		LayoutParameters = new ViewGroup.LayoutParams(-1, -2);
		DateTextView = RequireViewById<TextView>(2131298352);
	}
}
