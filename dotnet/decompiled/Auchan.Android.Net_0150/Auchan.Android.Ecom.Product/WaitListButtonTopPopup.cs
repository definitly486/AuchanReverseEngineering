using Android.OS;
using Android.Views;
using Android.Widget;
using Auchan.Android.Base;
using Java.Lang;

namespace Auchan.Android.Ecom.Product;

internal sealed class WaitListButtonTopPopup : PopupWindow
{
	public WaitListButtonTopPopup(View contentView, int width, int height)
		: base(contentView, width, height)
	{
		Focusable = true;
		OutsideTouchable = false;
		Touchable = false;
	}

	public static void Show(View anchorView)
	{
		View rootView = anchorView.RootView;
		View view = LayoutInflater.From(anchorView.Context).Inflate(2131493504, null, attachToRoot: false);
		view.RequireViewById<TextView>(2131298661).Text = "Вы подписались на товар";
		view.RequireViewById<TextView>(2131296844).Text = "Пришлем уведомление, когда он снова появится по вашему адресу.";
		int widthPixels = rootView.Context.Resources.DisplayMetrics.WidthPixels;
		view.RequireViewById<View>(2131298767).Visibility = ViewStates.Gone;
		view.Measure(View.MeasureSpec.MakeMeasureSpec(widthPixels, MeasureSpecMode.Exactly), View.MeasureSpec.MakeMeasureSpec(rootView.Height, MeasureSpecMode.AtMost));
		WaitListButtonPopup waitListButtonPopup = new WaitListButtonPopup(view, view.MeasuredWidth - Converter.DpToPx(40f), view.MeasuredHeight);
		waitListButtonPopup.ShowAtLocation(rootView.RootView, GravityFlags.Top, 0, 180);
		if (Looper.MainLooper != null)
		{
			new Handler(Looper.MainLooper).PostDelayed(new Runnable(waitListButtonPopup.Dismiss), 5000L);
		}
	}
}
