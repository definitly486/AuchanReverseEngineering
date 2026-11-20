using System;
using System.Collections.Generic;
using System.Reactive;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.LoyaltyProgram.ViewModels.CardRollout;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.Button;
using VisibilitySwitch;

namespace Auchan.Android.LoyaltyProgram;

internal class LoyaltyCardReattachedFragment : BaseBottomSheetDialogFragment<LoyaltyCardReattachedViewModel>
{
	protected override int LayoutId => 2131493046;

	public override int Theme => 2131951914;

	public LoyaltyCardReattachedFragment(Func<LoyaltyCardReattachPlasticCardNavigationParameter, LoyaltyCardReattachedViewModel> newViewModel)
		: base((Func<Fragment, LoyaltyCardReattachedViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<LoyaltyCardReattachPlasticCardNavigationParameter>())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		NestedScrollView nestedScrollView = view.RequireViewById<NestedScrollView>(2131296911);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		ImageView imageView = nestedScrollView.RequireViewById<ImageView>(2131296791);
		TextView textView = nestedScrollView.RequireViewById<TextView>(2131298159);
		TextView textView2 = nestedScrollView.RequireViewById<TextView>(2131298158);
		MaterialButton materialButton = nestedScrollView.RequireViewById<MaterialButton>(2131296846);
		TextView textView3 = constraintLayout.RequireViewById<TextView>(2131296808);
		TextView textView4 = constraintLayout.RequireViewById<TextView>(2131296809);
		TextView textView5 = constraintLayout.RequireViewById<TextView>(2131298646);
		ImageView errorImage = constraintLayout.RequireViewById<ImageView>(2131296807);
		ImageView imageView2 = constraintLayout.RequireViewById<ImageView>(2131296795);
		textView.Text = base.ViewModel.Title;
		materialButton.Text = base.ViewModel.ContinueButtonText;
		textView5.Text = base.ViewModel.ErrorTitle;
		textView3.AddScrollBehaviour();
		if (base.ViewModel.HasSubtitle)
		{
			textView2.Text = base.ViewModel.Subtitle;
			textView2.Visibility = ViewStates.Visible;
		}
		VisibilitySwitch<VisualState> viewSwitch = new VisibilitySwitch<VisualState>(base.ViewModel.State)
		{
			{
				VisualState.Default,
				nestedScrollView
			},
			{
				VisualState.Error,
				constraintLayout
			}
		};
		textView3.SetLinkedHtml(base.ViewModel.ConnectionErrorText, base.ViewModel.HandleUrl).AutoDisposeAllOnDestroy(ViewLifecycleOwner);
		textView4.Text = base.ViewModel.ErrorSubTitle;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				viewSwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				errorImage.FromUrlWithPlaceholder(base.ViewModel.ConnectionErrorImage, 2131231054);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ConnectionErrorImage"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(imageView.OnClick(base.ViewModel.OnContinueSelected), imageView2.OnClick(base.ViewModel.OnContinueSelected), materialButton.OnClick(base.ViewModel.OnContinueSelected)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.ContinueCommand.SafeSubscribe(OnClose, ViewLifecycleOwner);
	}

	public override void OnDismiss(IDialogInterface dialog)
	{
		base.ViewModel.OnContinueSelected();
	}

	private void OnClose(Unit obj)
	{
		Dismiss();
		this.ReturnResult(string.Empty);
		if (base.Activity == null || !(base.Activity is MainActivity mainActivity))
		{
			return;
		}
		FragmentManager fragmentManager = (mainActivity.SupportFragmentManager.FindFragmentById(2131296564) as BottomNavigationHostFragment)?.GetContainer()?.ChildFragmentManager;
		if (fragmentManager != null)
		{
			for (int i = 1; i < fragmentManager.Fragments.Count; i++)
			{
				fragmentManager.PopBackStack();
			}
			BottomNavigationView bottomNavigationView = mainActivity.RequireViewById<BottomNavigationView>(2131296565);
			bottomNavigationView.SelectedItemId = 2131297642;
			bottomNavigationView.SelectedItemId = 2131297642;
		}
	}
}
