using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.LoyaltyProgram.ViewModels.CardBlock;
using Auchan.Common.LoyaltyProgram.ViewModels.CardRollout;
using Google.Android.Material.Button;

namespace Auchan.Android.LoyaltyProgram;

internal class LoyaltyCardReissueOptionsFragment : BaseBottomSheetDialogFragment<LoyaltyCardReissuePlasticOptionsViewModel>
{
	private readonly FragmentFactory _fragmentFactory;

	protected override int LayoutId => 2131493047;

	public override int Theme => 2131951914;

	public LoyaltyCardReissueOptionsFragment(Func<Fragment, LoyaltyCardReissuePlasticOptionsViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base(newViewModel)
	{
		_fragmentFactory = fragmentFactory;
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298646);
		ImageView imageView = view.RequireViewById<ImageView>(2131296795);
		TextView textView2 = view.RequireViewById<TextView>(2131296962);
		Button button = view.RequireViewById<Button>(2131296613);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131298817);
		textView.Text = base.ViewModel.ScreenTitle;
		textView2.Text = base.ViewModel.ScreenDialogMessage;
		button.Text = base.ViewModel.DismissButtonText;
		materialButton.Text = base.ViewModel.WantANewCardButtonText;
		base.ViewModel.BindEvents(imageView.OnClick(Dismiss), button.OnClick(Dismiss), materialButton.OnClick(base.ViewModel.OnWantANewCardSelected)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.NavigateToReattachPlasticCommand.SafeSubscribe(OnNavigateToReattach, ViewLifecycleOwner);
	}

	private void OnNavigateToReattach(LoyaltyCardReattachPlasticCardNavigationParameter parameter)
	{
		Dismiss();
		LoyaltyCardReattachPlasticFragment loyaltyCardReattachPlasticFragment = _fragmentFactory.Instantiate<LoyaltyCardReattachPlasticFragment>();
		loyaltyCardReattachPlasticFragment.Arguments = parameter.ToNavBundle();
		loyaltyCardReattachPlasticFragment.Show(base.ParentFragmentManager, null);
	}
}
