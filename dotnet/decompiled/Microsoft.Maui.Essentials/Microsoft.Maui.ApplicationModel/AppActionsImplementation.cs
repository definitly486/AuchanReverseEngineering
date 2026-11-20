using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;

namespace Microsoft.Maui.ApplicationModel;

internal class AppActionsImplementation : IAppActions, IPlatformAppActions
{
	[SupportedOSPlatformGuard("android25.0")]
	public bool IsSupported => OperatingSystem.IsAndroidVersionAtLeast(25);

	public event EventHandler<AppActionEventArgs> AppActionActivated;

	public Task SetAsync(IEnumerable<AppAction> actions)
	{
		if (!IsSupported)
		{
			throw new FeatureNotSupportedException();
		}
		if (!(Application.Context.GetSystemService("shortcut") is ShortcutManager shortcutManager))
		{
			throw new FeatureNotSupportedException();
		}
		using JavaList<ShortcutInfo> dynamicShortcuts = new JavaList<ShortcutInfo>(actions.Select((AppAction a) => a.ToShortcutInfo()));
		shortcutManager.SetDynamicShortcuts(dynamicShortcuts);
		return Task.CompletedTask;
	}

	public void OnResume(Intent intent)
	{
		OnNewIntent(intent);
	}

	public void OnNewIntent(Intent intent)
	{
		if (intent?.Action == "ACTION_XE_APP_ACTION" && !intent.GetBooleanExtra("EXTRA_XE_APP_ACTION_HANDLED", defaultValue: false))
		{
			intent.PutExtra("EXTRA_XE_APP_ACTION_HANDLED", value: true);
			AppAction appAction = intent.ToAppAction();
			if (!string.IsNullOrEmpty(appAction?.Id))
			{
				this.AppActionActivated?.Invoke(null, new AppActionEventArgs(appAction));
			}
		}
	}
}
