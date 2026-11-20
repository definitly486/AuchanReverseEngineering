using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Auchan.Android.Base;
using Auchan.Android.Common;
using Auchan.Android.Ecom.PriceChecker;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Navigation;
using DryIoc;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android;

[Activity(Theme = "@style/AppTheme", ScreenOrientation = ScreenOrientation.Portrait, LaunchMode = LaunchMode.SingleTask, WindowSoftInputMode = SoftInput.AdjustPan)]
internal class MainActivity : BaseActivity
{
	private LinkerPleaseInclude _linkerPleaseInclude;

	public static bool MapKitInitialized { get; set; }

	protected override void OnCreate(Bundle savedInstanceState)
	{
		MapKitInitialized = false;
		DroidRestartService.CheckBundleAndRestartIfNeed(savedInstanceState);
		if (!Auchan.Android.StartActivity.WasLaunched)
		{
			DroidRestartService.Restart();
			return;
		}
		base.OnCreate(savedInstanceState);
		SetContentView(2131492895);
		SupportFragmentManager.RegisterFragmentLifecycleCallbacks(new ScannerFragmentListener(), recursive: true);
		TryToSetLightTheme();
		try
		{
			IntentFilter intentFilter = new IntentFilter();
			intentFilter.AddAction("android.location.PROVIDERS_CHANGED");
			intentFilter.AddAction("android.location.MODE_CHANGED");
		}
		catch
		{
		}
		if (DateTime.UtcNow.Ticks < 0)
		{
			_linkerPleaseInclude = new LinkerPleaseInclude();
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		try
		{
			if (!OperatingSystem.IsAndroidVersionAtLeast(31))
			{
				SendBroadcast(new Intent("android.intent.action.CLOSE_SYSTEM_DIALOGS"));
			}
		}
		catch
		{
		}
	}

	protected override void OnResume()
	{
		base.OnResume();
		DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<INavigationService>().ReadyForDelayedNavigation();
	}

	public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
	{
		Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
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
