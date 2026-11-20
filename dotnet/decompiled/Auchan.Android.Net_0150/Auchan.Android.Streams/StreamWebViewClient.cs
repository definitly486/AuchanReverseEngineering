using Android.Webkit;
using Auchan.Android.Base;

namespace Auchan.Android.Streams;

public class StreamWebViewClient : CustomWebViewClient
{
	public override bool ShouldOverrideUrlLoading(WebView? view, string? url)
	{
		base.ShouldOverrideUrlLoading(view, url);
		view?.LoadUrl(url);
		return true;
	}
}
