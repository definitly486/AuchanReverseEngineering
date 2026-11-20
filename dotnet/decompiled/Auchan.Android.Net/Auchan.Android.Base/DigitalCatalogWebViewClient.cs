using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using Android.Graphics;
using Android.Webkit;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Networking;
using DryIoc;

namespace Auchan.Android.Base;

public class DigitalCatalogWebViewClient : WebViewClient
{
	public delegate bool UrlLoadingHandler(WebView view, string url);

	public delegate void PageStartedHandler(WebView view, string url);

	public delegate void PageFinishedHandler(WebView view, string url);

	public delegate void WebViewErrorHandler(WebView view, IWebResourceRequest request, WebResourceError error);

	public delegate void HttpErrorHandler(WebView view, IWebResourceRequest request, WebResourceResponse errorResponse);

	private readonly IHeaderInjector _injector = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<IHeaderInjector>();

	private readonly IHeaderInjector2 _injector2 = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<IHeaderInjector2>();

	public UrlLoadingHandler? Loading { get; set; }

	public PageStartedHandler? Started { get; set; }

	public PageFinishedHandler? Finished { get; set; }

	public WebViewErrorHandler? WebViewError { get; set; }

	public HttpErrorHandler? HttpError { get; set; }

	public (string username, string password)? HttpAuthCredentials { get; set; }

	public bool InjectQratorHeaders { get; set; } = true;

	public bool IgnoreError400 { get; set; }

	public Func<string, IDictionary<string, string>> AdditionalHeadersProvider { get; set; }

	public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
	{
		string text = request?.Url?.ToString();
		IDictionary<string, string> dictionary = request?.RequestHeaders ?? new Dictionary<string, string>();
		if (!string.IsNullOrWhiteSpace(text))
		{
			UrlLoadingHandler? loading = Loading;
			if (loading != null && loading(view, text))
			{
				return true;
			}
			_injector2.Inject(text, dictionary);
			AddAdditionalHeaders(text, dictionary);
			if (InjectQratorHeaders)
			{
				_injector.Inject(text, dictionary);
			}
			view.LoadUrl(text, dictionary);
			return true;
		}
		return base.ShouldOverrideUrlLoading(view, request);
	}

	public override void OnPageStarted(WebView view, string url, Bitmap favicon)
	{
		Started?.Invoke(view, url);
		base.OnPageStarted(view, url, favicon);
	}

	public override void OnPageFinished(WebView view, string url)
	{
		Finished?.Invoke(view, url);
		base.OnPageFinished(view, url);
	}

	[SupportedOSPlatform("android23.0")]
	public override void OnReceivedError(WebView view, IWebResourceRequest request, WebResourceError error)
	{
		if (string.IsNullOrWhiteSpace(request?.Url?.ToString()) || !OverrideErrorLoading(view, request.Url.ToString()))
		{
			WebViewError?.Invoke(view, request, error);
			base.OnReceivedError(view, request, error);
		}
	}

	public override void OnReceivedHttpError(WebView view, IWebResourceRequest request, WebResourceResponse errorResponse)
	{
		if (IgnoreError400 && errorResponse.StatusCode == 400)
		{
			return;
		}
		string text = request?.Url?.ToString();
		bool flag = !string.IsNullOrWhiteSpace(text);
		if (InjectQratorHeaders && errorResponse.StatusCode == 403 && flag)
		{
			IDictionary<string, string> dictionary = request.RequestHeaders ?? new Dictionary<string, string>();
			if (_injector.Inject(text, dictionary))
			{
				AddAdditionalHeaders(text, dictionary);
				view.LoadUrl(text, dictionary);
				return;
			}
		}
		if (!flag || !OverrideErrorLoading(view, request.Url.ToString()))
		{
			HttpError?.Invoke(view, request, errorResponse);
			base.OnReceivedHttpError(view, request, errorResponse);
		}
	}

	protected virtual bool OverrideErrorLoading(WebView webView, string url)
	{
		if (Loading != null)
		{
			return Loading(webView, url);
		}
		return false;
	}

	private void AddAdditionalHeaders(string url, IDictionary<string, string> headers)
	{
		if (AdditionalHeadersProvider == null)
		{
			return;
		}
		foreach (KeyValuePair<string, string> item in AdditionalHeadersProvider(url))
		{
			item.Deconstruct(out var key, out var value);
			string key2 = key;
			string value2 = value;
			headers[key2] = value2;
		}
	}

	public override void OnReceivedHttpAuthRequest(WebView view, HttpAuthHandler handler, string host, string realm)
	{
		if (HttpAuthCredentials.HasValue)
		{
			handler.Proceed(HttpAuthCredentials.Value.username, HttpAuthCredentials.Value.password);
		}
	}
}
