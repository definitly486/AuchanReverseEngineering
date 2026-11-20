using System;
using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Streams;
using VisibilitySwitch;

namespace Auchan.Android.Streams;

internal class StreamFragment : BaseFragment<StreamViewModel>
{
	private WebView? _webView;

	protected override int LayoutId => 2131493103;

	public StreamFragment(Func<StreamViewModel.Parameter, StreamViewModel> newViewModel)
		: base((Func<Fragment, StreamViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<StreamViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131296904);
		TextView textView = linearLayout.RequireViewById<TextView>(2131298679);
		_webView = linearLayout.RequireViewById<WebView>(2131298826);
		ImageView imageView = linearLayout.RequireViewById<ImageView>(2131296490);
		textView.Text = base.ViewModel.Title;
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		TextView textView2 = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView textView3 = constraintLayout.RequireViewById<TextView>(2131297563);
		Button button = constraintLayout.RequireViewById<Button>(2131296325);
		Button button2 = constraintLayout.RequireViewById<Button>(2131298371);
		VisibilitySwitch<StreamViewModel.VisualState> viewSwitch = new VisibilitySwitch<StreamViewModel.VisualState>(base.ViewModel.State)
		{
			{
				StreamViewModel.VisualState.Default,
				linearLayout
			},
			{
				StreamViewModel.VisualState.InProgress,
				frameLayout
			},
			{
				StreamViewModel.VisualState.Error,
				constraintLayout
			}
		};
		_webView.Settings.JavaScriptEnabled = true;
		_webView.AddJavascriptInterface(new WebAppInterface(Context, base.ViewModel), "shopstory");
		_webView.SetWebViewClient(new StreamWebViewClient
		{
			InjectQratorHeaders = false,
			IgnoreErrConnectionReset = true,
			HttpError = delegate
			{
				base.ViewModel.OnError();
			},
			WebViewError = delegate
			{
				base.ViewModel.OnError();
			}
		});
		_webView.SetWebChromeClient(new WebChromeClient());
		_webView.LoadUrl(base.ViewModel.StreamUrl);
		textView2.Text = base.ViewModel.ErrorTitle;
		textView3.Text = base.ViewModel.ErrorMessage;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			viewSwitch.SwitchState(base.ViewModel.State);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(imageView.OnClick(base.ParentFragmentManager.PopBackStack), ((View)button).OnClick((Action)delegate
		{
			base.ViewModel.OnRetry();
			_webView.LoadUrl(base.ViewModel.StreamUrl);
		}), ((View)button2).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.NavigateToProductDetailsCommand.SafeSubscribe(NavigateToProduct, ViewLifecycleOwner);
	}

	private void NavigateToProduct(ProductDetailsViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<ProductDetailsFragment>(this, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}
}
