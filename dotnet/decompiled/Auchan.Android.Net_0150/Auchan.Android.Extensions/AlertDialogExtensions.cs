using Android.App;
using Android.Views;
using Auchan.Android.Base;

namespace Auchan.Android.Extensions;

internal static class AlertDialogExtensions
{
	public static void ShowCentered(this Dialog dialog)
	{
		dialog.Show();
		WindowManagerLayoutParams windowManagerLayoutParams = new WindowManagerLayoutParams();
		windowManagerLayoutParams.CopyFrom(dialog.Window.Attributes);
		windowManagerLayoutParams.Width = Application.Context.Resources.DisplayMetrics.WidthPixels - Converter.DpToPx(40f);
		windowManagerLayoutParams.Height = -2;
		dialog.Window.Attributes = windowManagerLayoutParams;
	}

	public static Dialog SetCanceledOnTouchOutsideBuilder(this Dialog dialog, bool cancel)
	{
		dialog.SetCanceledOnTouchOutside(cancel);
		return dialog;
	}
}
