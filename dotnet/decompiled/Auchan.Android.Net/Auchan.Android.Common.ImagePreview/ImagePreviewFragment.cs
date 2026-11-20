using System;
using Android.OS;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Common.ImagePreview;

namespace Auchan.Android.Common.ImagePreview;

internal class ImagePreviewFragment : BaseFragment<ImagePreviewViewModel>
{
	private WebView? _webView;

	protected override int LayoutId => 2131493032;

	public ImagePreviewFragment(Func<ImagePreviewViewModel.Parameter, ImagePreviewViewModel> newViewModel)
		: base((Func<Fragment, ImagePreviewViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<ImagePreviewViewModel.Parameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298679);
		_webView = view.RequireViewById<WebView>(2131298826);
		ImageView imageView = view.RequireViewById<ImageView>(2131296490);
		_webView.SetWebViewClient(new CustomWebViewClient());
		_webView.Settings.DisplayZoomControls = false;
		_webView.Settings.BuiltInZoomControls = true;
		_webView.Settings.LoadWithOverviewMode = true;
		_webView.Settings.UseWideViewPort = true;
		_webView.SetWebChromeClient(new WebChromeClient());
		textView.Text = base.ViewModel.Title;
		_webView.LoadUrl(base.ViewModel.ImageUrl);
		imageView.OnClick(base.ParentFragmentManager.PopBackStack).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}
}
