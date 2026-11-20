using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using AndroidX.Activity;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Extensions;
using Microsoft.Maui.ApplicationModel;
using VisibilitySwitch;

namespace Auchan.Android.Ecom.Cart;

internal class CheckoutWebViewFragment : BaseToolbarFragment<CheckoutWebViewModel>
{
	private sealed class Controls(View view)
	{
		public View View => view;

		public LinearLayout DefaultLayout { get; } = view.RequireViewById<LinearLayout>(2131296904);

		public ErrorLayoutControls ErrorLayout { get; } = new ErrorLayoutControls(view.RequireViewById<View>(2131297111));

		public FrameLayout ProgressLayout { get; } = view.RequireViewById<FrameLayout>(2131298079);

		public WebView WebView { get; } = view.RequireViewById<WebView>(2131298826);
	}

	private VisibilitySwitch<CheckoutWebViewModel.VisualState>? _visibilitySwitch;

	private List<string> _urlsForIgnore = new List<string> { "https://3dsp2.vtb.ru/http-json" };

	private OnBackPressedCallback? _backPressCallback;

	private WeakReference<Controls> _controls = new WeakReference<Controls>(null);

	protected override int LayoutId => 2131493011;

	public CheckoutWebViewFragment(Func<CheckoutWebViewModel.Parameter, CheckoutWebViewModel> newViewModel)
		: base((Func<Fragment, CheckoutWebViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<CheckoutWebViewModel.Parameter>())))
	{
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	protected override void OnNavigationButtonClick()
	{
		base.ViewModel.OnBackCommand.Trigger();
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		_backPressCallback = RequireActivity().OnBackPressedDispatcher.AddCallback(this, base.ViewModel.OnBackCommand.Trigger);
		base.ViewModel.SuccessfulPaymentCommand.SafeSubscribe(delegate(CheckoutSuccessViewModel.Parameter p)
		{
			ShowSuccessfulPayment(p).SafeFireAndForget((Action<Exception>)null, false);
		}, this);
		base.ViewModel.ReturnToCheckoutCommand.SafeSubscribe(ReturnToCheckout, this);
		base.ViewModel.ReturnToCartCommand.SafeSubscribe(ReturnToCart, this);
		base.ViewModel.OpenThirdPartyAppCommand.SafeSubscribe(LaunchThirdPartyIntent, this);
		base.ViewModel.OpenOrderNotPaidCommand.PerformDebouncingTask(OpenOrderNotPaid).SafeSubscribe(delegate
		{
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Controls controls = new Controls(view);
		_controls.SetTarget(controls);
		controls.WebView.SetWebViewClient(new CustomWebViewClient
		{
			InjectQratorHeaders = false,
			Loading = OnWebViewStarted,
			Finished = OnWebViewFinished,
			HttpError = OnHttpError,
			WebViewError = OnWebViewError
		});
		controls.WebView.Settings.JavaScriptEnabled = true;
		controls.WebView.Settings.DomStorageEnabled = true;
		controls.WebView.Settings.BuiltInZoomControls = true;
		controls.WebView.Settings.LoadWithOverviewMode = true;
		controls.WebView.Settings.UseWideViewPort = true;
		controls.WebView.SetWebChromeClient(new WebChromeClient());
		_visibilitySwitch = new VisibilitySwitch<CheckoutWebViewModel.VisualState>(base.ViewModel.State)
		{
			{
				CheckoutWebViewModel.VisualState.Default,
				controls.DefaultLayout
			},
			{
				CheckoutWebViewModel.VisualState.InProgress,
				controls.ProgressLayout
			},
			{
				CheckoutWebViewModel.VisualState.Error,
				controls.ErrorLayout.Layout
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[6]
		{
			(delegate
			{
				_visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				base.ToolbarTitle = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				controls.WebView.LoadUrl(base.ViewModel.Url);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Url")),
			(delegate
			{
				controls.ErrorLayout.Title.Text = base.ViewModel.ErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				controls.ErrorLayout.Message.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				controls.ErrorLayout.Action.Text = base.ViewModel.ErrorButtonTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorButtonTitle"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(controls.ErrorLayout.Action.OnClick(base.ViewModel.Retry), ((View)controls.ErrorLayout.ShowQrButton).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.ReloadCommand.SafeSubscribe(delegate
		{
			ReloadWebView(controls);
		}, ViewLifecycleOwner);
	}

	private void OnWebViewError(WebView view, IWebResourceRequest request, WebResourceError error)
	{
		base.ViewModel.OnWebError(error.Description);
	}

	private void OnHttpError(WebView view, IWebResourceRequest request, WebResourceResponse errorresponse)
	{
		if (_urlsForIgnore.Contains(request.Url?.ToString() ?? ""))
		{
			_visibilitySwitch?.SwitchState(CheckoutWebViewModel.VisualState.Default);
		}
		else
		{
			base.ViewModel.OnHttpError(errorresponse.ReasonPhrase);
		}
	}

	private bool OnWebViewStarted(WebView view, string url)
	{
		return base.ViewModel.OnPageLoading(url);
	}

	private void OnWebViewFinished(WebView view, string url)
	{
		base.ViewModel.OnPageLoaded(url);
	}

	public override void OnHiddenChanged(bool hidden)
	{
		base.OnHiddenChanged(hidden);
		if (_backPressCallback != null)
		{
			_backPressCallback.Enabled = !hidden;
		}
	}

	private async Task ShowSuccessfulPayment(CheckoutSuccessViewModel.Parameter parameter)
	{
		(await this.GetParentFragmentManagerAsync()).BeginTransaction().AddToBackStack(null).Hide(this)
			.Add<CheckoutSuccessFragment>(this, parameter.ToNavBundle())
			.Commit();
	}

	private void ReloadWebView(Controls controls)
	{
		controls.WebView.Reload();
	}

	private void ReturnToCheckout(Unit _)
	{
		this.PopBackStackAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private void ReturnToCart(Unit _)
	{
		this.PopBackStackAsync(null, 1).SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task OpenOrderNotPaid(CheckoutOrderNotPaidViewModel.Parameter parameter)
	{
		FragmentManager obj = await this.GetParentFragmentManagerAsync();
		obj.PopBackStackImmediate();
		Fragment fragment = obj.Fragments.Last();
		obj.BeginTransaction().AddToBackStack(null).Hide(fragment)
			.Add<CheckoutOrderNotPaidFragment>(fragment, parameter.ToNavBundle())
			.Commit();
	}

	private void LaunchThirdPartyIntent(string url)
	{
		if (string.IsNullOrWhiteSpace(url))
		{
			return;
		}
		try
		{
			Intent intent = Intent.ParseUri(url, IntentUriType.None);
			Platform.CurrentActivity?.StartActivity(intent);
		}
		catch (Exception)
		{
		}
	}
}
