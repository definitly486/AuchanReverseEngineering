using Android.OS;
using Android.Views;
using Android.Widget;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Java.Lang;

namespace Auchan.Android.Ecom.Product;

internal sealed class WaitListButtonPopup : HintPopupBase
{
	private const int MarginBottom = 8;

	public WaitListButtonPopup(View contentView, int width, int height)
		: base(contentView, width, height)
	{
	}

	public static void Show(View anchorView)
	{
		View rootView = anchorView.RootView;
		View view = LayoutInflater.From(anchorView.Context).Inflate(2131493504, null, attachToRoot: false);
		TextView textView = view.RequireViewById<TextView>(2131298661);
		TextView textView2 = view.RequireViewById<TextView>(2131296844);
		textView.Text = "Вы подписались на товар";
		textView2.Text = "Пришлем уведомление, когда он снова появится по вашему адресу.";
		view.Measure(View.MeasureSpec.MakeMeasureSpec(anchorView.Width, MeasureSpecMode.Exactly), View.MeasureSpec.MakeMeasureSpec(rootView.Height, MeasureSpecMode.AtMost));
		WaitListButtonPopup waitListButtonPopup = new WaitListButtonPopup(view, view.MeasuredWidth, view.MeasuredHeight);
		waitListButtonPopup.ShowAsDropDown(anchorView, 0, -Converter.DpToPx(8f) - waitListButtonPopup.Height - anchorView.Height, GravityFlags.AxisSpecified);
		if (Looper.MainLooper != null)
		{
			new Handler(Looper.MainLooper).PostDelayed(new Runnable(waitListButtonPopup.Dismiss), 5000L);
		}
	}
}
