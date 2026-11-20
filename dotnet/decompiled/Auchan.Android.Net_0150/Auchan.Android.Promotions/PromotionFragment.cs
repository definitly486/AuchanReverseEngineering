using System;
using System.Collections.Generic;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Common;
using Auchan.Android.Extensions;
using Auchan.Common.AdminTool;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Promotions;
using Microsoft.Maui.ApplicationModel;
using VisibilitySwitch;

namespace Auchan.Android.Promotions;

[Register("auchan.Android.Promotions.PromotionFragment")]
internal class PromotionFragment : BaseToolbarFragment<PromotionViewModel>
{
	private LinearLayout? _linearLayout;

	private TextView? _toolbarTitle;

	private WebView? _webView;

	private ConstraintLayout? _errorLayout;

	private readonly IBrowserActivator _browserActivator;

	protected override int LayoutId => 2131493083;

	public PromotionFragment(Func<PromotionViewModel.Parameter, PromotionViewModel> newViewModel, IBrowserActivator browserActivator)
		: base((Func<Fragment, PromotionViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<PromotionViewModel.Parameter>())))
	{
		_browserActivator = browserActivator;
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.OpenSystemBrowserCommand.SafeSubscribe(delegate(string url)
		{
			OpenBrowser(url);
		}, this);
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131296904);
		_toolbarTitle = linearLayout.RequireViewById<TextView>(2131298679);
		_webView = linearLayout.RequireViewById<WebView>(2131298830);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		_errorLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		_webView.VerticalScrollBarEnabled = false;
		_webView.HorizontalScrollBarEnabled = false;
		_webView.Settings.JavaScriptEnabled = true;
		_webView.Settings.DomStorageEnabled = true;
		_webView.Settings.DisplayZoomControls = false;
		_webView.Settings.LoadWithOverviewMode = true;
		_webView.SetWebChromeClient(new WebChromeClient());
		_webView.AddJavascriptInterface(new JSPostMessageInterface(OnReceiveMessage), "JSPostMessageInterface");
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(base.ViewModel.State)
		{
			{
				VisualState.Default,
				linearLayout
			},
			{
				VisualState.InProgress,
				frameLayout
			},
			{
				VisualState.Error,
				_errorLayout
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				SetData(base.ViewModel.PromotionKind);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PromotionKind")),
			(delegate
			{
				OnStartRedirectUrl(base.ViewModel.OnStartRedirectUrl);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OnStartRedirectUrl"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OpenProductDetailsCommand.SafeSubscribe(OpenPeoductDetails, ViewLifecycleOwner);
		base.ViewModel.PostMessageCommand.SafeSubscribe(PostMessage, ViewLifecycleOwner);
	}

	private void OnStartRedirectUrl(string url)
	{
		if (!string.IsNullOrWhiteSpace(url))
		{
			OnNavigationButtonClick();
			OpenBrowser(url);
		}
	}

	private void SetData(PromotionKind? promotionKind)
	{
		if (!promotionKind.HasValue)
		{
			return;
		}
		_toolbarTitle.Text = base.ViewModel.Title;
		if (promotionKind.HasValue)
		{
			switch (promotionKind.GetValueOrDefault())
			{
			case PromotionKind.Native:
				SetupAsNative();
				break;
			case PromotionKind.Webview:
				SetupAsWebView();
				break;
			}
		}
	}

	private void SetupAsNative()
	{
		_webView.Settings.SetSupportMultipleWindows(support: false);
		_webView.SetWebChromeClient(new WebChromeClient());
		_webView.SetWebViewClient(new BrowserWebViewClient
		{
			Finished = delegate
			{
				_webView.LoadUrl("javascript:(function f() { " + base.ViewModel.PostLoadJSCode + " })();");
				base.ViewModel.OnPageLoad();
			},
			Loading = Loading
		});
		_webView.SetInitialScale(300);
		_webView.Settings.UseWideViewPort = false;
		_webView.Settings.DefaultTextEncodingName = "utf-8";
		_webView.LoadData(base.ViewModel.DescriptionHtml, "text/html; charset=utf-8", "utf-8");
	}

	private void SetupAsWebView()
	{
		_webView.Settings.SetSupportMultipleWindows(support: true);
		_webView.SetWebChromeClient(new ExternalLinkWebChromeClient(delegate(string url)
		{
			base.ViewModel.HandleLink(url, opensNewWindow: true);
		}));
		if (base.ViewModel.IsDigitalCatalog)
		{
			_webView.SetWebViewClient(new DigitalCatalogWebViewClient
			{
				Finished = delegate
				{
					_webView.LoadUrl("javascript:(function f() { " + base.ViewModel.PostLoadJSCode + " })();");
					base.ViewModel.OnPageLoad();
				},
				Loading = Loading,
				AdditionalHeadersProvider = base.ViewModel.GetWebViewHeaders
			});
		}
		else
		{
			_webView.SetWebViewClient(new CustomWebViewClient
			{
				Finished = delegate
				{
					_webView.LoadUrl("javascript:(function f() { " + base.ViewModel.PostLoadJSCode + " })();");
					base.ViewModel.OnPageLoad();
				},
				Loading = Loading,
				AdditionalHeadersProvider = base.ViewModel.GetWebViewHeaders
			});
		}
		_webView.SetInitialScale(100);
		_webView.Settings.UseWideViewPort = true;
		_webView.LoadUrl(base.ViewModel.Url, base.ViewModel.GetWebViewHeaders(base.ViewModel.Url));
	}

	private bool Loading(WebView webView, string url)
	{
		return base.ViewModel.HandleLink(url);
	}

	private void OpenBrowser(string url)
	{
		if (!string.IsNullOrWhiteSpace(url) && Uri.TryCreate(url, UriKind.Absolute, out Uri result))
		{
			_browserActivator.LaunchBrowserAsync(result, BrowserLaunchMode.External).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private void OpenPeoductDetails(ProductDetailsViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<ProductDetailsFragment>(base.ParentFragment, parameter.ToNavBundle(), null, 2131297216)
			.AddToBackStack(null)
			.Commit();
	}

	private void PostMessage(string message)
	{
		_webView.EvaluateJavascript("window.postMessage('" + message + "', '*');", null);
	}

	public void OnReceiveMessage(string message)
	{
		base.ViewModel.OnMessageReceived(message);
	}
}
