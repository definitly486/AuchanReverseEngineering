using System.Runtime.Versioning;
using Android.Content;
using Android.Net;
using Android.Util;
using Android.Webkit;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.Base;

public class BrowserWebViewClient : CustomWebViewClient
{
	[ObsoletedOSPlatform("android24.0")]
	public override bool ShouldOverrideUrlLoading(WebView view, string url)
	{
		Log.Info("BrowserWebViewClient", "[ShouldOverrideUrlLoading]: " + url);
		return base.Loading?.Invoke(view, url) ?? false;
	}

	public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
	{
		Log.Info("BrowserWebViewClient", $"[ShouldOverrideUrlLoading]: {request?.Url}");
		return base.Loading?.Invoke(view, request.Url.ToString()) ?? false;
	}

	private void StartLinkIntent(string url)
	{
		Uri uri = Uri.Parse(url);
		Intent intent = new Intent("android.intent.action.VIEW", uri);
		Platform.CurrentActivity?.StartActivity(intent);
	}

	protected override bool OverrideErrorLoading(WebView webView, string url)
	{
		return false;
	}
}
