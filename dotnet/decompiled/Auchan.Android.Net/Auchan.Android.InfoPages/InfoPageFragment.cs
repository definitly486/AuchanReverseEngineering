using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Android.OS;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Common;
using Auchan.Android.Extensions;
using Auchan.Android.Helpers;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.InfoPages;
using Auchan.Common.NewYearGame;
using Auchan.Common.NewYearGame.DTO;
using Microsoft.Maui.ApplicationModel;
using VisibilitySwitch;

namespace Auchan.Android.InfoPages;

internal class InfoPageFragment : BaseToolbarFragment<InfoPageViewModel>
{
	private const string PostMessageListenerScript = "window.addEventListener('message', event => { JSPostMessageInterface.OnPostMessage(event.data); });";

	private FrameLayout _contentContainer;

	private LinearLayout _linearLayout;

	private ImageView _bannerImageView;

	private WebView _webView;

	private ScrollView? _scrollView;

	private bool _closePostMessageHandled;

	private readonly IBrowserActivator _browserActivator;

	protected override int LayoutId => 2131493033;

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public InfoPageFragment(Func<InfoPageViewModel.Parameter, InfoPageViewModel> newViewModel, IBrowserActivator browserActivator)
		: base((Func<Fragment, InfoPageViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<InfoPageViewModel.Parameter>())))
	{
		_browserActivator = browserActivator;
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131296904);
		FrameLayout progressLayout = view.RequireViewById<FrameLayout>(2131298079);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		TextView errorMessage = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView errorHint = constraintLayout.RequireViewById<TextView>(2131297563);
		Button button = constraintLayout.RequireViewById<Button>(2131296325);
		Button button2 = constraintLayout.RequireViewById<Button>(2131298371);
		_contentContainer = linearLayout.RequireViewById<FrameLayout>(2131297349);
		_linearLayout = _contentContainer.RequireViewById<LinearLayout>(2131297354);
		_bannerImageView = _linearLayout.RequireViewById<ImageView>(2131297348);
		_webView = _linearLayout.RequireViewById<WebView>(2131297350);
		_webView.SetWebViewClient(new CustomWebViewClient
		{
			Loading = (WebView webView, string url) => base.ViewModel.OverrideUrlHandlingIfNeccesary(url),
			Started = delegate
			{
				base.ViewModel.OnPageStarted();
			},
			HttpError = delegate
			{
				base.ViewModel.OnPageError();
			},
			WebViewError = delegate
			{
				base.ViewModel.OnPageError();
			},
			Finished = delegate
			{
				_webView.EvaluateJavascript("window.addEventListener('message', event => { JSPostMessageInterface.OnPostMessage(event.data); });", null);
				base.ViewModel.OnPageFinished();
			},
			AdditionalHeadersProvider = base.ViewModel.GetWebViewHeaders,
			HttpAuthCredentials = ("gs", "gs")
		});
		_webView.SetWebChromeClient(new WebChromeClient());
		_webView.Settings.JavaScriptEnabled = true;
		_webView.Settings.DomStorageEnabled = true;
		_webView.AddJavascriptInterface(new JSPostMessageInterface(OnReceiveMessage), "JSPostMessageInterface");
		VisibilitySwitch<InfoPageViewModel.VisualState> visibilitySwitch = new VisibilitySwitch<InfoPageViewModel.VisualState>(base.ViewModel.State)
		{
			InfoPageViewModel.VisualState.Default,
			{
				InfoPageViewModel.VisualState.InProgress,
				progressLayout
			},
			{
				InfoPageViewModel.VisualState.Error,
				constraintLayout
			}
		};
		((View)base.Toolbar).OnLayoutChange((Action)delegate
		{
			if (progressLayout.LayoutParameters is ViewGroup.MarginLayoutParams marginLayoutParams && marginLayoutParams.TopMargin != base.Toolbar.Height)
			{
				marginLayoutParams.TopMargin = base.Toolbar.Height;
				progressLayout.LayoutParameters = marginLayoutParams;
			}
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		button.Text = base.ViewModel.ErrorButtonText;
		button2.Visibility = base.ViewModel.IsQrButtonVisible.ToVisibility();
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[4]
		{
			(delegate
			{
				errorMessage.Text = base.ViewModel.ErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				errorHint.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				base.ToolbarTitle = base.ViewModel.InfoTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("InfoTitle"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.RetryClick), ((View)button2).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.LoadDataCommand.StartWith(base.ViewModel.InfoContentType).SafeSubscribe(SetupData, ViewLifecycleOwner);
		base.ViewModel.OpenSystemBrowserCommand.SafeSubscribe(OpenBrowser, ViewLifecycleOwner);
		UserFontSizeHelper.AdjustFontScale(base.Resources.Configuration, base.Resources, base.Activity);
	}

	private void OnReceiveMessage(string message)
	{
		GameMessageDTO dTO = NewYearGameMessageHelper.GetDTO(message);
		if (dTO != null && dTO.Type == NewYearGameActionType.Close)
		{
			CloseByPostMessage();
		}
	}

	private void CloseByPostMessage()
	{
		if (!_closePostMessageHandled)
		{
			_closePostMessageHandled = true;
			OnNavigationButtonClick();
		}
	}

	private void SetupData(InfoContentType contentType)
	{
		if (contentType != InfoContentType.Unknown)
		{
			SetupContentContainer(contentType);
			SetWebViewMargins(contentType);
			base.ToolbarTitle = base.ViewModel.InfoTitle;
			switch (contentType)
			{
			case InfoContentType.Native:
				SetupDataAsNative();
				break;
			case InfoContentType.Webview:
				SetupDataAsWebView();
				break;
			}
			int height = ((contentType == InfoContentType.Native) ? (-2) : (-1));
			_linearLayout.LayoutParameters = new FrameLayout.LayoutParams(-1, height);
		}
	}

	private void SetupContentContainer(InfoContentType contentType)
	{
		switch (contentType)
		{
		case InfoContentType.Native:
		{
			ScrollView scrollView2 = _scrollView;
			if (scrollView2 == null)
			{
				ScrollView obj = new ScrollView(RequireContext())
				{
					LayoutParameters = new FrameLayout.LayoutParams(-1, -1),
					VerticalScrollBarEnabled = false
				};
				ScrollView scrollView3 = obj;
				_scrollView = obj;
				scrollView2 = scrollView3;
			}
			ScrollView scrollView4 = scrollView2;
			if (_linearLayout.Parent == _contentContainer)
			{
				_contentContainer.RemoveView(_linearLayout);
			}
			if (scrollView4.Parent == null)
			{
				_contentContainer.AddView(scrollView4);
			}
			if (_linearLayout.Parent == null)
			{
				scrollView4.AddView(_linearLayout);
			}
			break;
		}
		case InfoContentType.Webview:
		{
			ScrollView scrollView = _scrollView;
			if (scrollView != null)
			{
				if (_linearLayout.Parent == scrollView)
				{
					scrollView.RemoveView(_linearLayout);
				}
				if (scrollView.Parent == _contentContainer)
				{
					_contentContainer.RemoveView(scrollView);
				}
			}
			if (_linearLayout.Parent == null)
			{
				_contentContainer.AddView(_linearLayout);
			}
			break;
		}
		}
	}

	private void SetupDataAsNative()
	{
		_webView.Settings.SetSupportMultipleWindows(support: false);
		_webView.SetWebChromeClient(new WebChromeClient());
		_bannerImageView.Visibility = base.ViewModel.IsBannerVisible.ToVisibility();
		_bannerImageView.FromUrl(base.ViewModel.InfoBannerUrl);
		_webView.Settings.DefaultTextEncodingName = "utf-8";
		_webView.LoadData(base.ViewModel.HtmlWrappedInfoContent, "text/html; charset=utf-8", "utf-8");
	}

	private void SetupDataAsWebView()
	{
		_bannerImageView.Visibility = ViewStates.Gone;
		_webView.Settings.SetSupportMultipleWindows(support: true);
		_webView.SetWebChromeClient(new ExternalLinkWebChromeClient(delegate(string url)
		{
			base.ViewModel.OverrideUrlHandlingIfNeccesary(url, opensNewWindow: true);
		}));
		_webView.LoadUrl(base.ViewModel.InfoUrl, base.ViewModel.GetWebViewHeaders(base.ViewModel.InfoUrl));
	}

	private void OpenBrowser(string url)
	{
		if (!string.IsNullOrWhiteSpace(url) && Uri.TryCreate(url, UriKind.Absolute, out Uri result))
		{
			_browserActivator.LaunchBrowserAsync(result, BrowserLaunchMode.External).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private void SetWebViewMargins(InfoContentType contentType)
	{
		int num = 0;
		switch (contentType)
		{
		case InfoContentType.Native:
			num = Converter.DpToPx(base.Resources.DisplayMetrics.Density);
			break;
		}
		int height = ((contentType == InfoContentType.Native) ? (-2) : (-1));
		LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(-1, height);
		layoutParams.SetMargins(num, 0, num, 0);
		_webView.LayoutParameters = layoutParams;
	}
}
