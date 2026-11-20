using System;
using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Common;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.InfoPages;
using Auchan.Common.NewYearGame;
using Auchan.Common.NewYearGame.DTO;
using VisibilitySwitch;

namespace Auchan.Android.InfoPages;

internal class TutorialFragment : BaseToolbarFragment<TutorialViewModel>
{
	private const string PostMessageListenerScript = "window.addEventListener('message', event => { JSPostMessageInterface.OnPostMessage(event.data); });";

	private bool _closePostMessageHandled;

	protected override int LayoutId => 2131493113;

	public TutorialFragment(Func<TutorialViewModel.Parameter, TutorialViewModel> newViewModel)
		: base((Func<Fragment, TutorialViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<TutorialViewModel.Parameter>())))
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131296904);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		TextView textView = linearLayout.RequireViewById<TextView>(2131298679);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		TextView errorMessage = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView errorHint = constraintLayout.RequireViewById<TextView>(2131297563);
		Button button = constraintLayout.RequireViewById<Button>(2131296325);
		Button button2 = constraintLayout.RequireViewById<Button>(2131298371);
		WebView webView = linearLayout.RequireViewById<WebView>(2131298830);
		webView.SetWebViewClient(new CustomWebViewClient
		{
			Loading = (WebView wv, string url) => base.ViewModel.OverrideUrlHandlingIfNeccesary(url),
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
				webView.EvaluateJavascript("window.addEventListener('message', event => { JSPostMessageInterface.OnPostMessage(event.data); });", null);
				base.ViewModel.OnPageFinished();
			},
			AdditionalHeadersProvider = base.ViewModel.GetWebViewHeaders
		});
		webView.SetWebChromeClient(new WebChromeClient());
		webView.Settings.JavaScriptEnabled = true;
		webView.Settings.DomStorageEnabled = true;
		webView.AddJavascriptInterface(new JSPostMessageInterface(OnReceiveMessage), "JSPostMessageInterface");
		VisibilitySwitch<TutorialViewModel.VisualState> visibilitySwitch = new VisibilitySwitch<TutorialViewModel.VisualState>(TutorialViewModel.VisualState.Default)
		{
			{
				TutorialViewModel.VisualState.Default,
				linearLayout
			},
			{
				TutorialViewModel.VisualState.Error,
				constraintLayout
			},
			{
				TutorialViewModel.VisualState.InProgress,
				frameLayout
			}
		};
		textView.Text = base.ViewModel.Title;
		button.Text = base.ViewModel.ErrorButtonText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
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
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.RetryClick), ((View)button2).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.LoadDataCommand.StartWithDefault().SafeSubscribe(delegate
		{
			SetupData(webView);
		}, ViewLifecycleOwner);
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

	private void SetupData(WebView webView)
	{
		if (base.ViewModel.IsLoaded)
		{
			if (base.ViewModel.ContentType == TutorialContentType.Native)
			{
				SetupAsNative(webView);
			}
			else if (base.ViewModel.ContentType == TutorialContentType.WebView)
			{
				SetupAsWebView(webView);
			}
		}
	}

	private void SetupAsNative(WebView webView)
	{
		webView.SetInitialScale(300);
		webView.Settings.UseWideViewPort = false;
		webView.Settings.DefaultTextEncodingName = "utf-8";
		webView.LoadData(base.ViewModel.HtmlWrappedDescription, "text/html; charset=utf-8", "utf-8");
	}

	private void SetupAsWebView(WebView webView)
	{
		webView.SetInitialScale(100);
		webView.Settings.UseWideViewPort = true;
		webView.LoadUrl(base.ViewModel.Url, base.ViewModel.GetWebViewHeaders(base.ViewModel.Url));
	}
}
