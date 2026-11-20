using System;
using System.Collections.Generic;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Base.Widgets;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Home;
using Auchan.Common.LoyaltyProgram;
using Microsoft.Maui.ApplicationModel;
using VisibilitySwitch;

namespace Auchan.Android.LoyaltyProgram;

internal class OfferDetailsFragment : BaseBottomSheetDialogFragment<OfferDetailsViewModel>
{
	private WebView? _webView;

	private FrameLayout? _progressLayout;

	private AppCompatButton _acceptButtonBottom;

	private TextView _acceptedLabel;

	private ViewGroup _acceptedLayout;

	private NestedScrollView _scrollView;

	private List<string> _resourceUrls = new List<string>();

	public override int Theme => 2131951916;

	protected override int LayoutId => 2131493073;

	protected override bool FullScreen => true;

	public OfferDetailsFragment(Func<BrokerToken, OfferDetailsViewModel> newViewModel)
		: base((Func<Fragment, OfferDetailsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ViewGroup viewGroup = view.RequireViewById<ViewGroup>(2131298827);
		ImageView imageView = view.RequireViewById<ImageView>(2131296791);
		_acceptButtonBottom = view.RequireViewById<AppCompatButton>(2131296275);
		_scrollView = view.RequireViewById<NestedScrollView>(2131298827);
		_progressLayout = view.RequireViewById<FrameLayout>(2131298079);
		ViewGroup viewGroup2 = view.RequireViewById<ViewGroup>(2131297111);
		TextView errorMessage = viewGroup2.RequireViewById<TextView>(2131298646);
		TextView errorHint = viewGroup2.RequireViewById<TextView>(2131297563);
		Button button = viewGroup2.RequireViewById<Button>(2131296325);
		Button button2 = viewGroup2.RequireViewById<Button>(2131298371);
		_acceptedLabel = view.RequireViewById<TextView>(2131296277);
		_acceptedLayout = view.RequireViewById<ViewGroup>(2131296276);
		PersonalOfferView offerView = view.RequireViewById<PersonalOfferView>(2131297726);
		_webView = view.RequireViewById<WebView>(2131298826);
		_webView.SetWebViewClient(new CustomWebViewClient
		{
			InjectQratorHeaders = false,
			Loading = OnWebViewWillLoad,
			LoadResource = OnLoadResource
		});
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			{
				VisualState.Default,
				viewGroup
			},
			{
				VisualState.InProgress,
				_progressLayout
			},
			{
				VisualState.Error,
				viewGroup2
			}
		};
		button2.Visibility = ViewStates.Gone;
		button.Visibility = ViewStates.Visible;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[6]
		{
			(delegate
			{
				errorMessage.Text = base.ViewModel.ErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				errorHint.Text = base.ViewModel.ErrorDescription;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorDescription")),
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				UpdateHtml(base.ViewModel.Content);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Content")),
			(delegate
			{
				SetupOfferView(offerView, base.ViewModel.OfferModel);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OfferModel")),
			(delegate
			{
				SetupActivateButton(base.ViewModel.OfferModel);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OfferModel"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.Retry), imageView.OnClick(base.ViewModel.CloseCommand.Trigger), ((View)_acceptButtonBottom).OnClick((Action)delegate
		{
			AcceptTapped();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
		base.ViewModel.OpenBrowserCommand.SafeSubscribe(delegate(string url)
		{
			LaunchSystemBrowser(url);
		}, ViewLifecycleOwner);
	}

	private void AcceptTapped()
	{
		if (base.ViewModel.OfferModel != null && !base.ViewModel.OfferModel.IsAccepted)
		{
			base.ViewModel.AcceptOfferTapped().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private void SetupActivateButton(PersOfferItemViewModel model)
	{
		if (model != null)
		{
			_acceptButtonBottom.SetBackgroundResource(2131231546);
			_acceptButtonBottom.Text = model.ActivateLabel;
			_acceptButtonBottom.Visibility = (model.IsAccepted ? ViewStates.Invisible : ViewStates.Visible);
			_acceptedLabel.Text = model.ActivateLabel;
			_acceptedLayout.Visibility = ((!model.IsAccepted) ? ViewStates.Invisible : ViewStates.Visible);
		}
	}

	private void SetupOfferView(PersonalOfferView offerView, PersOfferItemViewModel? model)
	{
		if (model != null)
		{
			offerView.Setup(model);
			offerView.AcceptButton.Visibility = ViewStates.Gone;
		}
	}

	private bool LaunchSystemBrowser(string url)
	{
		if (string.IsNullOrWhiteSpace(url))
		{
			return false;
		}
		try
		{
			global::Android.Net.Uri uri = global::Android.Net.Uri.Parse(url);
			Intent intent = new Intent("android.intent.action.VIEW", uri);
			Platform.CurrentActivity?.StartActivity(intent);
		}
		catch (Exception)
		{
			return false;
		}
		return true;
	}

	private bool OnWebViewWillLoad(WebView view, string url)
	{
		lock (_resourceUrls)
		{
			if (!string.IsNullOrEmpty(url) && !_resourceUrls.Contains(url))
			{
				base.ViewModel.HandleUrl(url);
			}
		}
		return true;
	}

	private void OnLoadResource(WebView view, string url)
	{
		lock (_resourceUrls)
		{
			if (!string.IsNullOrEmpty(url))
			{
				_resourceUrls.Add(url);
			}
		}
	}

	private void UpdateHtml(string html)
	{
		if (!string.IsNullOrEmpty(html))
		{
			_webView?.LoadData(html, null, null);
		}
	}
}
