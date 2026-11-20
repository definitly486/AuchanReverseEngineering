using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using AsyncAwaitBestPractices;
using Auchan.Common.Common;
using Java.Lang;

namespace Auchan.Android.Common;

public class DroidRestartService : IRestartService
{
	private readonly IApplicationStateManager _applicationStateManager;

	private const string FRAGMENTS_KEY = "android:fragments";

	private const string STATE_KEY = "androidx.lifecycle.BundlableSavedStateRegistry.key";

	public DroidRestartService(IApplicationStateManager applicationStateManager)
	{
		_applicationStateManager = applicationStateManager;
	}

	void IRestartService.Restart()
	{
		RestartAsync(_applicationStateManager).SafeFireAndForget((Action<System.Exception>)null, false);
	}

	public static void Restart()
	{
		RestartAsync().SafeFireAndForget((Action<System.Exception>)null, false);
	}

	[DoesNotReturn]
	private static async Task RestartAsync(IApplicationStateManager? applicationStateManager = null)
	{
		TryPushPreferencesToStorage();
		if (applicationStateManager != null)
		{
			await applicationStateManager.OnPausedAsync();
		}
		Context context = Application.Context;
		Intent intent = Intent.MakeRestartActivityTask(context.PackageManager.GetLaunchIntentForPackage(context.PackageName).Component);
		intent.SetPackage(context.PackageName);
		context.StartActivity(intent);
		Runtime.GetRuntime().Exit(0);
		throw new NotImplementedException("dead code: app killed and gonna restart");
	}

	public static void TryPushPreferencesToStorage()
	{
		PreferenceManager.GetDefaultSharedPreferences(Application.Context).Edit().Commit();
	}

	public static bool IsAndroidWantToRestore(Bundle? savedInstanceState)
	{
		if (savedInstanceState != null && savedInstanceState.ContainsKey("android:fragments"))
		{
			return savedInstanceState.ContainsKey("androidx.lifecycle.BundlableSavedStateRegistry.key");
		}
		return false;
	}

	public static void CheckBundleAndRestartIfNeed(Bundle? savedInstanceState)
	{
		if (IsAndroidWantToRestore(savedInstanceState))
		{
			Restart();
		}
	}
}
