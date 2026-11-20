using Android.App;
using Android.Runtime;
using Android.Util;
using Android.Views;

namespace Auchan.Android.Utils;

public static class Util
{
	public static int ConvertPixelsToDp(float pixelValue)
	{
		DisplayMetrics displayMetrics = GetDisplayMetrics();
		return (int)(pixelValue / displayMetrics.Density);
	}

	public static float ConvertPixelsToDp(int pixelValue)
	{
		DisplayMetrics displayMetrics = GetDisplayMetrics();
		return (float)pixelValue / displayMetrics.Density;
	}

	public static int ConvertDpToPixels(float dpValue)
	{
		DisplayMetrics displayMetrics = GetDisplayMetrics();
		return (int)(dpValue * displayMetrics.Density);
	}

	public static DisplayMetrics GetDisplayMetrics()
	{
		IWindowManager? windowManager = Application.Context.GetSystemService("window").JavaCast<IWindowManager>();
		DisplayMetrics displayMetrics = new DisplayMetrics();
		windowManager.DefaultDisplay.GetRealMetrics(displayMetrics);
		return displayMetrics;
	}
}
