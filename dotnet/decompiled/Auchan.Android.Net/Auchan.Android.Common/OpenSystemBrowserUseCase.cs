using System;
using Android.Content;
using Android.Net;
using Auchan.Common.Common;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Common;

internal class OpenSystemBrowserUseCase : IOpenSystemBrowserUseCase
{
	public void OpenSystemBrowser(string? url)
	{
		if (string.IsNullOrWhiteSpace(url))
		{
			return;
		}
		try
		{
			global::Android.Net.Uri uri = global::Android.Net.Uri.Parse(url);
			Intent intent = new Intent("android.intent.action.VIEW", uri);
			Platform.CurrentActivity?.StartActivity(intent);
		}
		catch (Exception)
		{
		}
	}
}
