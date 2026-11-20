using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Auchan.Android.Base;

namespace Auchan.Android;

[Activity(Theme = "@style/AppTheme", ScreenOrientation = ScreenOrientation.Portrait, LaunchMode = LaunchMode.SingleTask, WindowSoftInputMode = SoftInput.AdjustPan)]
internal class MainNotAuthActivity : BaseActivity
{
	protected override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		SetContentView(2131492897);
		TryToSetLightTheme();
	}

	private void TryToSetLightTheme()
	{
		if (OperatingSystem.IsAndroidVersionAtLeast(26))
		{
			int systemUiVisibility = (int)Window.DecorView.SystemUiVisibility;
			systemUiVisibility |= 0x10;
			Window.DecorView.SystemUiVisibility = (StatusBarVisibility)systemUiVisibility;
		}
	}
}
