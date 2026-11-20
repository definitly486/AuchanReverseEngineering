using System;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Extensions;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Products.ViewModels;

namespace Auchan.Android.Common;

[Register("auchan.Android.Common.WebFragment")]
internal class WebFragment : BaseToolbarFragment<WebViewModel>
{
	protected override int LayoutId => 2131493125;

	public WebFragment(Func<WebViewModel.Parameter, WebViewModel> newViewModel)
		: base((Func<Fragment, WebViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<WebViewModel.Parameter>())))
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.OpenProductDetailsCommand.SafeSubscribe(delegate(ProductDetailsViewModel.Parameter p)
		{
			NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(p);
		}, this);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			base.ParentFragmentManager.PopBackStackImmediate();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298679);
		WebView webView = view.RequireViewById<WebView>(2131298830);
		textView.Text = base.ViewModel.Title;
		webView.VerticalScrollBarEnabled = false;
		webView.HorizontalScrollBarEnabled = false;
		webView.Settings.JavaScriptEnabled = true;
		webView.Settings.DomStorageEnabled = true;
		webView.Settings.DisplayZoomControls = false;
		webView.Settings.LoadWithOverviewMode = true;
		webView.SetWebChromeClient(new WebChromeClient());
		webView.AddJavascriptInterface(new JSPostMessageInterface(base.ViewModel.OnMessageReceived), "JSPostMessageInterface");
		base.ViewModel.PostMessageCommand.SafeSubscribe(delegate(string m)
		{
			webView.EvaluateJavascript("window.postMessage('" + m + "', '*');", null);
		}, ViewLifecycleOwner);
		if (!string.IsNullOrEmpty(base.ViewModel.Content))
		{
			webView.SetWebViewClient(new BrowserWebViewClient
			{
				Finished = delegate
				{
					webView.EvaluateJavascript(base.ViewModel.PostLoadJSCode, null);
				},
				Loading = (WebView wv, string url) => base.ViewModel.HandleLink(url)
			});
			webView.SetInitialScale(300);
			webView.Settings.UseWideViewPort = false;
			webView.Settings.DefaultTextEncodingName = "utf-8";
			webView.LoadData(base.ViewModel.Content, "text/html; charset=utf-8", "utf-8");
		}
		else if (!string.IsNullOrEmpty(base.ViewModel.Url))
		{
			webView.SetWebViewClient(new CustomWebViewClient
			{
				Finished = delegate
				{
					webView.EvaluateJavascript(base.ViewModel.PostLoadJSCode, null);
				},
				Loading = (WebView wv, string url) => base.ViewModel.HandleLink(url)
			});
			webView.SetInitialScale(100);
			webView.Settings.UseWideViewPort = true;
			webView.LoadUrl(base.ViewModel.Url);
		}
	}
}
