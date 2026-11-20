using System;
using Android.Content;

namespace Xamarin.RangeSlider;

public class PixelUtil
{
	public static int SpToPx(Context context, int dp)
	{
		return (int)Math.Round((float)dp * context.Resources.DisplayMetrics.ScaledDensity);
	}

	public static int PxToSp(Context context, int px)
	{
		return (int)Math.Round((float)px / context.Resources.DisplayMetrics.ScaledDensity);
	}

	public static int DpToPx(Context context, int dp)
	{
		return (int)Math.Round((float)dp * GetPixelScaleFactor(context));
	}

	private static float GetPixelScaleFactor(Context context)
	{
		return context.Resources.DisplayMetrics.Xdpi / 160f;
	}
}
