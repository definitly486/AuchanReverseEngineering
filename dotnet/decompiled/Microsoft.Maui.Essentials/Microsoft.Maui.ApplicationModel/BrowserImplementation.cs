using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Net;
using AndroidX.Browser.CustomTabs;

namespace Microsoft.Maui.ApplicationModel;

internal class BrowserImplementation : IBrowser
{
	public Task<bool> OpenAsync(System.Uri uri, BrowserLaunchOptions options)
	{
		global::Android.Net.Uri nativeUri = global::Android.Net.Uri.Parse(uri.AbsoluteUri);
		switch (options.LaunchMode)
		{
		case BrowserLaunchMode.SystemPreferred:
			LaunchChromeTabs(options, nativeUri);
			break;
		case BrowserLaunchMode.External:
			LaunchExternalBrowser(options, nativeUri);
			break;
		}
		return Task.FromResult(result: true);
	}

	private static void LaunchChromeTabs(BrowserLaunchOptions options, global::Android.Net.Uri? nativeUri)
	{
		CustomTabsIntent.Builder builder = new CustomTabsIntent.Builder();
		builder.SetShowTitle(showTitle: true);
		if (options.PreferredToolbarColor != null)
		{
			builder.SetToolbarColor(options.PreferredToolbarColor.ToInt());
		}
		if (options.TitleMode != BrowserTitleMode.Default)
		{
			builder.SetShowTitle(options.TitleMode == BrowserTitleMode.Show);
		}
		CustomTabsIntent customTabsIntent = builder.Build();
		ActivityFlags? activityFlags = null;
		Context context = ActivityStateManager.Default.GetCurrentActivity(throwOnNull: false);
		if (context == null)
		{
			context = Application.Context;
			activityFlags = ActivityFlags.ClearTop | ActivityFlags.NewTask;
		}
		if (OperatingSystem.IsAndroidVersionAtLeast(24) && options.HasFlag(BrowserLaunchFlags.LaunchAdjacent))
		{
			activityFlags = (ActivityFlags?)((!activityFlags.HasValue) ? ((ValueType)new ActivityFlags?(ActivityFlags.LaunchAdjacent | ActivityFlags.NewTask)) : ((ValueType)((uint?)activityFlags | 0x10001000u)));
		}
		if (activityFlags.HasValue)
		{
			customTabsIntent.Intent.SetFlags(activityFlags.Value);
		}
		if (nativeUri != null)
		{
			customTabsIntent.LaunchUrl(context, nativeUri);
		}
	}

	private static void LaunchExternalBrowser(BrowserLaunchOptions options, global::Android.Net.Uri? nativeUri)
	{
		Intent intent = new Intent("android.intent.action.VIEW", nativeUri);
		ActivityFlags activityFlags = ActivityFlags.ClearTop | ActivityFlags.NewTask;
		if (OperatingSystem.IsAndroidVersionAtLeast(24) && options.HasFlag(BrowserLaunchFlags.LaunchAdjacent))
		{
			activityFlags |= ActivityFlags.LaunchAdjacent;
		}
		intent.SetFlags(activityFlags);
		if (!PlatformUtils.IsIntentSupported(intent))
		{
			throw new FeatureNotSupportedException();
		}
		Application.Context.StartActivity(intent);
	}
}
