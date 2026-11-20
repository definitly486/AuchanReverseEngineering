using System;
using System.IO;
using System.Runtime.Versioning;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics.Drawables;

namespace Microsoft.Maui.ApplicationModel;

public static class AppActionsExtensions
{
	private static IPlatformAppActions AsPlatform(this IAppActions appActions)
	{
		if (!(appActions is IPlatformAppActions result))
		{
			throw new PlatformNotSupportedException("This implementation of IAppActions does not implement IPlatformAppActions.");
		}
		return result;
	}

	public static void OnResume(this IAppActions appActions, Intent? intent)
	{
		appActions.AsPlatform().OnResume(intent);
	}

	internal static AppAction ToAppAction(this Intent intent)
	{
		return new AppAction(intent.GetStringExtra("EXTRA_XE_APP_ACTION_ID"), intent.GetStringExtra("EXTRA_XE_APP_ACTION_TITLE"), intent.GetStringExtra("EXTRA_XE_APP_ACTION_SUBTITLE"), intent.GetStringExtra("EXTRA_XE_APP_ACTION_ICON"));
	}

	[SupportedOSPlatform("android25.0")]
	internal static ShortcutInfo ToShortcutInfo(this AppAction action)
	{
		Context context = Application.Context;
		ShortcutInfo.Builder builder = new ShortcutInfo.Builder(context, action.Id).SetShortLabel(action.Title);
		if (!string.IsNullOrWhiteSpace(action.Subtitle))
		{
			builder.SetLongLabel(action.Subtitle);
		}
		action.Icon = Path.GetFileNameWithoutExtension(action.Icon);
		if (!string.IsNullOrWhiteSpace(action.Icon))
		{
			int identifier = context.Resources.GetIdentifier(action.Icon, "drawable", context.PackageName);
			builder.SetIcon(Icon.CreateWithResource(context, identifier));
		}
		Intent intent = new Intent("ACTION_XE_APP_ACTION");
		intent.SetPackage(context.PackageName);
		intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);
		intent.PutExtra("EXTRA_XE_APP_ACTION_ID", action.Id);
		intent.PutExtra("EXTRA_XE_APP_ACTION_TITLE", action.Title);
		intent.PutExtra("EXTRA_XE_APP_ACTION_SUBTITLE", action.Subtitle);
		intent.PutExtra("EXTRA_XE_APP_ACTION_ICON", action.Icon);
		builder.SetIntent(intent);
		return builder.Build();
	}
}
