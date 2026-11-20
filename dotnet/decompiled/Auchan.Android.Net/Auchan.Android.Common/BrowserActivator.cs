using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using AndroidX.Browser.CustomTabs;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Common;

internal sealed class BrowserActivator : IBrowserActivator
{
	public async Task LaunchBrowserAsync(System.Uri uri, BrowserLaunchMode browserLaunchMode)
	{
		while (ActivityStateManager.Default.GetCurrentActivity() is StartActivity)
		{
			await Task.Delay(200);
		}
		global::Android.Net.Uri uri2 = global::Android.Net.Uri.Parse(uri.ToString());
		if (browserLaunchMode == BrowserLaunchMode.External)
		{
			Intent intent = new Intent("android.intent.action.VIEW", uri2);
			Context context = GetContext(intent);
			intent.SetComponent(GetBrowserComponentName(context));
			context.StartActivity(intent);
			return;
		}
		CustomTabsIntent.Builder builder = new CustomTabsIntent.Builder();
		builder.SetShowTitle(showTitle: true);
		CustomTabsIntent customTabsIntent = builder.Build();
		Context context2 = GetContext(customTabsIntent.Intent);
		customTabsIntent.Intent.SetComponent(GetBrowserComponentName(context2));
		if (uri2 != null)
		{
			customTabsIntent.LaunchUrl(context2, uri2);
		}
	}

	private static Context GetContext(Intent intent)
	{
		Context context = ActivityStateManager.Default.GetCurrentActivity();
		if (context == null)
		{
			context = Application.Context;
			intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
		}
		return context;
	}

	private static ComponentName GetBrowserComponentName(Context context)
	{
		IList<ResolveInfo> source = context.PackageManager.QueryIntentActivities(new Intent("android.intent.action.VIEW", global::Android.Net.Uri.Parse("https://")), PackageInfoFlags.MatchDefaultOnly);
		ResolveInfo resolveInfo = source.FirstOrDefault(delegate(ResolveInfo a)
		{
			if (a.ActivityInfo == null)
			{
				return false;
			}
			string? name = a.ActivityInfo.Name;
			if (name != null && name.ContainsIgnoreCase("com.android.internal.app.ResolverActivity"))
			{
				return false;
			}
			string? name2 = a.ActivityInfo.Name;
			return (name2 == null || !name2.ContainsIgnoreCase(AppInfo.PackageName)) ? true : false;
		}) ?? source.First();
		return new ComponentName(resolveInfo.ActivityInfo.PackageName, resolveInfo.ActivityInfo.Name);
	}
}
