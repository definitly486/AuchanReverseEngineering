using System;
using System.Runtime.Versioning;
using Android.OS;
using Android.Webkit;

namespace Auchan.Android.Base;

internal sealed class ExternalLinkWebChromeClient : WebChromeClient
{
	private sealed class PopupWebViewClient : WebViewClient
	{
		private readonly Action<string> _openLink;

		public PopupWebViewClient(Action<string> openLink)
		{
			_openLink = openLink;
		}

		[ObsoletedOSPlatform("android24.0")]
		public override bool ShouldOverrideUrlLoading(WebView view, string url)
		{
			return OpenLink(view, url);
		}

		public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
		{
			return OpenLink(view, request?.Url?.ToString());
		}

		private bool OpenLink(WebView webView, string url)
		{
			if (string.IsNullOrWhiteSpace(url) || url == "about:blank")
			{
				return false;
			}
			_openLink(url);
			webView.StopLoading();
			webView.Destroy();
			return true;
		}
	}

	private readonly Action<string> _openLink;

	public ExternalLinkWebChromeClient(Action<string> openLink)
	{
		_openLink = openLink;
	}

	public override bool OnCreateWindow(WebView view, bool isDialog, bool isUserGesture, Message resultMsg)
	{
		if (view?.Context == null || !(resultMsg?.Obj is WebView.WebViewTransport webViewTransport))
		{
			return false;
		}
		WebView webView = new WebView(view.Context);
		webView.SetWebViewClient(new PopupWebViewClient(_openLink));
		webViewTransport.WebView = webView;
		resultMsg.SendToTarget();
		return true;
	}
}
