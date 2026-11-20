using System.Globalization;
using Android.App;
using Android.Graphics;
using Android.Views;
using AndroidX.AppCompat.App;
using Auchan.Android.Helpers;

namespace Auchan.Android.Ecom.PriceChecker;

public static class Utils
{
	private static CultureInfo? s_ruCulture;

	private static CultureInfo Culture
	{
		get
		{
			if (s_ruCulture == null)
			{
				CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("ru-RU");
				cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
				s_ruCulture = cultureInfo;
			}
			return s_ruCulture;
		}
	}

	public static string GetPrice(this double price)
	{
		return price.ToString("C2", Culture);
	}

	public static void SetFlags(Activity activity)
	{
		if (activity is AppCompatActivity appCompatActivity)
		{
			appCompatActivity.SupportActionBar?.Hide();
			Window? window = appCompatActivity.Window;
			View decorView = window.DecorView;
			int systemUiVisibility = (int)decorView.SystemUiVisibility;
			systemUiVisibility |= 0x500;
			systemUiVisibility &= -8209;
			decorView.SystemUiVisibility = (StatusBarVisibility)systemUiVisibility;
			window.SetStatusBarColor(Color.Transparent);
			window.SetNavigationBarColor(Color.Black);
		}
	}

	public static void RestoreFlags(Activity activity)
	{
		if (activity is AppCompatActivity appCompatActivity)
		{
			appCompatActivity.SupportActionBar?.Show();
			Window? window = appCompatActivity.Window;
			View decorView = window.DecorView;
			int systemUiVisibility = (int)decorView.SystemUiVisibility;
			systemUiVisibility &= -1281;
			systemUiVisibility |= 0x2010;
			decorView.SystemUiVisibility = (StatusBarVisibility)systemUiVisibility;
			Color statusBarColor = ColorHelper.FromId(activity, 2131099795);
			Color navigationBarColor = ColorHelper.FromId(activity, 2131099794);
			window.SetStatusBarColor(statusBarColor);
			window.SetNavigationBarColor(navigationBarColor);
		}
	}
}
