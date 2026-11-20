using System;
using Android.App;
using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.Lifecycle;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Helpers;

public static class ActivityHelper
{
	public static Type GetActiveOrLaunchActivity()
	{
		if (Platform.CurrentActivity is AppCompatActivity appCompatActivity && appCompatActivity.Lifecycle.CurrentState != Lifecycle.State.Destroyed)
		{
			return appCompatActivity.GetType();
		}
		return typeof(StartActivity);
	}

	public static void AddDecorFlags(Activity activity, SystemUiFlags flags)
	{
		if (activity is AppCompatActivity appCompatActivity)
		{
			View decorView = appCompatActivity.Window.DecorView;
			int systemUiVisibility = (int)decorView.SystemUiVisibility | (int)flags;
			decorView.SystemUiVisibility = (StatusBarVisibility)systemUiVisibility;
		}
	}

	public static void ClearDecorFlags(Activity activity, SystemUiFlags flags)
	{
		if (activity is AppCompatActivity appCompatActivity)
		{
			View decorView = appCompatActivity.Window.DecorView;
			int systemUiVisibility = (int)decorView.SystemUiVisibility;
			systemUiVisibility &= (int)(~flags);
			decorView.SystemUiVisibility = (StatusBarVisibility)systemUiVisibility;
		}
	}
}
