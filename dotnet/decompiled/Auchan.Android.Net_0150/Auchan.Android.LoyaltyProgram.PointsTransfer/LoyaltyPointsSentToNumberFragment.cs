using System;
using System.Reactive;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer;
using Google.Android.Material.Button;

namespace Auchan.Android.LoyaltyProgram.PointsTransfer;

internal class LoyaltyPointsSentToNumberFragment : BaseBottomSheetDialogFragment<LoyaltyPointsSentToNumberViewModel>
{
	protected override int LayoutId => 2131493052;

	public override int Theme => 2131951914;

	public LoyaltyPointsSentToNumberFragment(Func<LoyaltyPointsSentToNumberNavigationParameter, LoyaltyPointsSentToNumberViewModel> newViewModel)
		: base((Func<Fragment, LoyaltyPointsSentToNumberViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<LoyaltyPointsSentToNumberNavigationParameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298655);
		ImageView imageView = view.RequireViewById<ImageView>(2131296795);
		TextView textView2 = view.RequireViewById<TextView>(2131297499);
		TextView textView3 = view.RequireViewById<TextView>(2131296962);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131296846);
		ImageView imageView2 = view.RequireViewById<ImageView>(2131297761);
		textView.Text = base.ViewModel.TitleLabel;
		textView3.Text = base.ViewModel.CurrentBalanceLabel;
		materialButton.Text = base.ViewModel.ContinueButtonText;
		int num = base.ViewModel.OperationTitle.IndexOf(base.ViewModel.PhoneNumber);
		int end = num + base.ViewModel.PhoneNumber.Length;
		SpannableStringBuilder spannableStringBuilder = new SpannableStringBuilder(base.ViewModel.OperationTitle);
		spannableStringBuilder.SetSpan(new StyleSpan(TypefaceStyle.Bold), num, end, SpanTypes.ExclusiveExclusive);
		textView2.TextFormatted = spannableStringBuilder;
		imageView2.SetImageResource((base.ViewModel.PointType == LoyaltyPointType.Points) ? 2131231584 : 2131231585);
		base.ViewModel.BindEvents(materialButton.OnClick(base.ViewModel.OnCloseButtonSelected), imageView.OnClick(base.ViewModel.OnCloseButtonSelected)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(OnClose, ViewLifecycleOwner);
	}

	public override void OnDismiss(IDialogInterface dialog)
	{
		base.ViewModel.OnCloseButtonSelected();
	}

	private void OnClose(Unit obj)
	{
		Dismiss();
		this.ReturnResult(0);
	}
}
