using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Net;

namespace Microsoft.Maui.ApplicationModel;

internal class LauncherImplementation : ILauncher
{
	public Task<bool> OpenAsync(System.Uri uri)
	{
		if (uri == null)
		{
			throw new ArgumentNullException("uri");
		}
		return PlatformOpenAsync(uri);
	}

	public Task<bool> TryOpenAsync(System.Uri uri)
	{
		if (uri == null)
		{
			throw new ArgumentNullException("uri");
		}
		return PlatformTryOpenAsync(uri);
	}

	private Task<bool> PlatformCanOpenAsync(System.Uri uri)
	{
		Intent intent = new Intent("android.intent.action.VIEW", global::Android.Net.Uri.Parse(uri.OriginalString));
		return Task.FromResult(PlatformUtils.IsIntentSupported(intent));
	}

	private Task<bool> PlatformOpenAsync(System.Uri uri)
	{
		Intent intent = new Intent("android.intent.action.VIEW", global::Android.Net.Uri.Parse(uri.OriginalString));
		ActivityFlags flags = ActivityFlags.ClearTop | ActivityFlags.NewTask;
		intent.SetFlags(flags);
		Application.Context.StartActivity(intent);
		return Task.FromResult(result: true);
	}

	private async Task<bool> PlatformTryOpenAsync(System.Uri uri)
	{
		bool canOpen = await PlatformCanOpenAsync(uri);
		if (canOpen)
		{
			await PlatformOpenAsync(uri);
		}
		return canOpen;
	}
}
