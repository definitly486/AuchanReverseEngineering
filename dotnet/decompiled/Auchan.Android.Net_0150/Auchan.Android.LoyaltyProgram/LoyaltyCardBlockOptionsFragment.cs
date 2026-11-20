using System;
using System.Collections.Generic;
using System.Reactive;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.LoyaltyProgram.ViewModels.CardBlock;
using Auchan.Common.LoyaltyProgram.ViewModels.CardRollout;
using Google.Android.Material.Button;
using VisibilitySwitch;

namespace Auchan.Android.LoyaltyProgram;

internal class LoyaltyCardBlockOptionsFragment : BaseBottomSheetDialogFragment<LoyaltyCardBlockOptionsViewModel>
{
	private readonly FragmentFactory _fragmentFactory;

	protected override int LayoutId => 2131493037;

	public override int Theme => 2131951914;

	public LoyaltyCardBlockOptionsFragment(Func<Fragment, LoyaltyCardBlockOptionsViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base(newViewModel)
	{
		_fragmentFactory = fragmentFactory;
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.CloseCommand.SafeSubscribe(OnClose, this);
		base.ViewModel.GoToReattachPlasticCardCommand.SafeSubscribe(OpenReattachCard, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131296911);
		ConstraintLayout constraintLayout2 = view.RequireViewById<ConstraintLayout>(2131297111);
		TextView textView = constraintLayout.RequireViewById<TextView>(2131298646);
		ImageView imageView = constraintLayout.RequireViewById<ImageView>(2131296795);
		MaterialButton materialButton = constraintLayout.RequireViewById<MaterialButton>(2131296539);
		TextView textView2 = constraintLayout2.RequireViewById<TextView>(2131296808);
		ImageView errorImage = constraintLayout2.RequireViewById<ImageView>(2131296807);
		ImageView imageView2 = constraintLayout2.RequireViewById<ImageView>(2131296795);
		TextView textView3 = constraintLayout2.RequireViewById<TextView>(2131298646);
		textView2.AddScrollBehaviour();
		textView.Text = base.ViewModel.ScreenTitle;
		materialButton.Text = base.ViewModel.PerformBlockAndReissueButtonText;
		VisibilitySwitch<VisualState> viewSwitch = new VisibilitySwitch<VisualState>(base.ViewModel.State)
		{
			{
				VisualState.Default,
				constraintLayout
			},
			{
				VisualState.Error,
				constraintLayout2
			}
		};
		textView3.Text = base.ViewModel.ErrorTitle;
		textView2.SetLinkedHtml(base.ViewModel.ConnectionErrorText, base.ViewModel.HandleLink).AutoDisposeAllOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				errorImage.FromUrlWithPlaceholder(base.ViewModel.ConnectionErrorImage, 2131231054);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ConnectionErrorImage")),
			(delegate
			{
				viewSwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(imageView.OnClick(Dismiss), imageView2.OnClick(Dismiss), materialButton.OnClick(base.ViewModel.OnPerformBlockAndReissueButtonSelected)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void OnClose(Unit obj)
	{
		Dismiss();
	}

	private void OpenReattachCard(LoyaltyCardReattachPlasticCardNavigationParameter parameter)
	{
		Dismiss();
		_fragmentFactory.Instantiate<LoyaltyRolloutCardOptionsDialogFragment>().Show(RequireActivity().SupportFragmentManager, null);
	}
}
