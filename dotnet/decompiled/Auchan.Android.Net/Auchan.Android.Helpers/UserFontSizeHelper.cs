using Android.App;
using Android.Content.Res;
using Android.Runtime;
using Android.Util;
using Android.Views;

namespace Auchan.Android.Helpers;

public static class UserFontSizeHelper
{
	public static void AdjustFontScale(Configuration configuration, Resources resurses, Activity activity)
	{
		if (configuration.FontScale != 1f)
		{
			configuration.FontScale = 1f;
			DisplayMetrics displayMetrics = resurses.DisplayMetrics;
			activity.GetSystemService("window").JavaCast<IWindowManager>().DefaultDisplay.GetMetrics(displayMetrics);
			displayMetrics.ScaledDensity = configuration.FontScale * displayMetrics.Density;
			activity.Resources.UpdateConfiguration(configuration, displayMetrics);
		}
	}
}
