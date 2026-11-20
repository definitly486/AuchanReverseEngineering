using System;
using Android.OS;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Android.Helpers;
using Auchan.Common.Base;
using Auchan.Common.Profile.SocialStatus;
using Google.Android.Material.Button;

namespace Auchan.Android.Profile.SocialStatus;

internal class UnconfirmedSocialStatusFragment : BaseBottomSheetDialogFragment<UnconfirmedSocialStatusViewModel>
{
	public override int Theme => 2131951916;

	protected override int LayoutId => 2131493503;

	protected override bool FullScreen => true;

	public UnconfirmedSocialStatusFragment(Func<Fragment, UnconfirmedSocialStatusViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131296795);
		TextView textView2 = view.RequireViewById<TextView>(2131298680);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131298780);
		WebView webView = view.RequireViewById<WebView>(2131298409);
		textView2.Text = base.ViewModel.ToolbarTitle;
		materialButton.Text = base.ViewModel.ButtonText;
		webView.SetWebViewClient(new CustomWebViewClient
		{
			Loading = (WebView webView2, string url) => base.ViewModel.OverrideUrlHandlingIfNeccesary(url)
		});
		webView.Settings.DefaultTextEncodingName = "utf-8";
		webView.LoadData(base.ViewModel.Content, "text/html; charset=utf-8", "utf-8");
		base.ViewModel.BindEvents(materialButton.OnClick(base.ViewModel.OnButtonClick), textView.OnClick(base.ViewModel.OnButtonClick)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OnCloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
		UserFontSizeHelper.AdjustFontScale(base.Resources.Configuration, base.Resources, base.Activity);
	}
}
