using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Text;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.LoyaltyProgram.ViewModels;
using Google.Android.Material.Button;

namespace Auchan.Android.LoyaltyProgram;

internal class LoyaltyPersonalizedGreetingFragment : BaseBottomSheetDialogFragment<LoyaltyPersonalizedGreetingViewModel>
{
	protected override int LayoutId => 2131493049;

	public override int Theme => 2131951914;

	public LoyaltyPersonalizedGreetingFragment(Func<Fragment, LoyaltyPersonalizedGreetingViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ImageView imageView = view.RequireViewById<ImageView>(2131296791);
		TextView textView = view.RequireViewById<TextView>(2131296962);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131296846);
		textView.TextFormatted = HtmlCompat.FromHtml(base.ViewModel.TextHtml, 0);
		materialButton.Text = base.ViewModel.ContinueButtonText;
		base.ViewModel.BindEvents(imageView.OnClick(Dismiss), materialButton.OnClick(Dismiss)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		base.ViewModel.OnClose();
	}
}
