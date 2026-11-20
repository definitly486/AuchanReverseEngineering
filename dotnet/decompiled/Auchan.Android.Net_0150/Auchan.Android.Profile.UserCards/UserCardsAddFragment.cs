using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Android.OS;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Helpers;
using Auchan.Common.Profile.UserCards;
using VisibilitySwitch;

namespace Auchan.Android.Profile.UserCards;

internal class UserCardsAddFragment : BaseToolbarFragment<UserCardsAddViewModel>
{
	private WebView _webView;

	protected override int LayoutId => 2131493117;

	public UserCardsAddFragment(Func<Fragment, UserCardsAddViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131296904);
		TextView textView = view.RequireViewById<TextView>(2131298679);
		_webView = linearLayout.RequireViewById<WebView>(2131298830);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		TextView errorMessage = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView errorHint = constraintLayout.RequireViewById<TextView>(2131297563);
		Button button = constraintLayout.RequireViewById<Button>(2131296325);
		Button button2 = constraintLayout.RequireViewById<Button>(2131298371);
		textView.Text = base.ViewModel.ScreenTitle;
		_webView.SetWebViewClient(new CustomWebViewClient
		{
			Loading = OnWebViewStarted,
			Finished = OnWebViewFinished,
			HttpError = OnHttpError,
			WebViewError = OnWebViewError
		});
		_webView.Settings.JavaScriptEnabled = true;
		_webView.Settings.DomStorageEnabled = true;
		_webView.Settings.BuiltInZoomControls = true;
		_webView.Settings.LoadWithOverviewMode = true;
		_webView.Settings.UseWideViewPort = true;
		_webView.SetWebChromeClient(new WebChromeClient());
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(VisualState.Empty)
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
				constraintLayout
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				errorMessage.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				errorHint.Text = base.ViewModel.ErrorHint;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorHint")),
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.Retry), ((View)button2).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.LoadTokenUrlCommand.ObserveOn(MainThread.Scheduler).Subscribe(LoadTokenUrl).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		base.ViewModel.GoBackCommand.ObserveOn(MainThread.Scheduler).Subscribe(delegate
		{
			GoBack();
		}).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
	}

	private void LoadTokenUrl(string url)
	{
		_webView.LoadUrl(url);
	}

	private void GoBack()
	{
		base.ParentFragmentManager.PopBackStack();
	}

	private void OnWebViewError(WebView view, IWebResourceRequest request, WebResourceError error)
	{
		string error2 = "unknown error";
		if (OperatingSystem.IsAndroidVersionAtLeast(23))
		{
			error2 = error.Description;
		}
		base.ViewModel.OnError(error2);
	}

	private void OnHttpError(WebView view, IWebResourceRequest request, WebResourceResponse errorresponse)
	{
		base.ViewModel.OnError(errorresponse.ReasonPhrase);
	}

	private bool OnWebViewStarted(WebView view, string url)
	{
		return base.ViewModel.OnPageLoading(url);
	}

	private void OnWebViewFinished(WebView view, string url)
	{
		base.ViewModel.OnPageLoaded(url);
	}
}
