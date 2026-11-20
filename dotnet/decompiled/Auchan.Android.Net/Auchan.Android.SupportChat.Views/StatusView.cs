using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;

namespace Auchan.Android.SupportChat.Views;

public sealed class StatusView : ConstraintLayout, IChatContentView
{
	public TextView StatusTextView { get; }

	public StatusView(Context context)
		: base(context)
	{
		View.Inflate(context, 2131493196, this);
		LayoutParameters = new ViewGroup.LayoutParams(-1, -2);
		StatusTextView = RequireViewById<TextView>(2131298477);
	}
}
