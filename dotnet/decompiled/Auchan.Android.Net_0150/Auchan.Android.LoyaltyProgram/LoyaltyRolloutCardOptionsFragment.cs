using System;
using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Authorization;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.LoyaltyProgram.ViewModels.CardRollout;
using Auchan.Common.PersonalCabinet.Authorization;
using Google.Android.Material.Button;

namespace Auchan.Android.LoyaltyProgram;

internal class LoyaltyRolloutCardOptionsFragment : BaseToolbarFragment<LoyaltyRolloutCardOptionsViewModel>
{
	private const int FinalDialogRequestCode = 68854;

	private readonly FragmentFactory _fragmentFactory;

	protected override int LayoutId => 2131493048;

	public LoyaltyRolloutCardOptionsFragment(Func<SignUpViewModel.Parameter, LoyaltyRolloutCardOptionsViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base((Func<Fragment, LoyaltyRolloutCardOptionsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<SignUpViewModel.Parameter>())))
	{
		_fragmentFactory = fragmentFactory;
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		IToolbarContainer obj = (IToolbarContainer)RequireParentFragment();
		obj.Title = base.ViewModel.ScreenTitle;
		obj.CustomBackAction(delegate
		{
			base.ViewModel.GoToAuthorization();
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		TextView messageText = view.RequireViewById<TextView>(2131297571);
		MaterialButton activatePlasticCardButton = view.RequireViewById<MaterialButton>(2131296338);
		MaterialButton createVirtualCardButton = view.RequireViewById<MaterialButton>(2131296870);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				messageText.Text = base.ViewModel.DoYouHaveACardMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DoYouHaveACardMessage")),
			(delegate
			{
				activatePlasticCardButton.Text = base.ViewModel.ActivatePlasticCardButtonText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ActivatePlasticCardButtonText")),
			(delegate
			{
				createVirtualCardButton.Text = base.ViewModel.CreateVirtualCardButtonText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CreateVirtualCardButtonText"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(activatePlasticCardButton.OnClick(base.ViewModel.OnActivatePlastic), createVirtualCardButton.OnClick(base.ViewModel.OnCreateVirtual)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.GoToPersonalProfileCommand.SafeSubscribe(OpenPersonalProfile, ViewLifecycleOwner);
		base.ViewModel.GoToReattachPlasticCardCommand.SafeSubscribe(OpenReattachCard, ViewLifecycleOwner);
		base.ViewModel.NavigateToAuthorizationCommand.SafeSubscribe(delegate
		{
			GoToAuthorization();
		}, ViewLifecycleOwner);
		base.ViewModel.ShowSuccessfullyReattachedCommand.SafeSubscribe(ShowSuccessfullyReattached, ViewLifecycleOwner);
	}

	private void OpenPersonalProfile(SignUpViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.PopBackStack();
		base.ParentFragmentManager.BeginTransaction().Replace<SignUpFragment>(this, parameter.ToNavBundle()).AddToBackStack(null)
			.CommitAllowingStateLoss();
	}

	private void OpenReattachCard(LoyaltyCardReattachPlasticCardNavigationParameter parameter)
	{
		FragmentManager parentFragmentManager = base.ParentFragmentManager;
		if (base.ParentFragment is LoyaltyRolloutCardOptionsDialogFragment loyaltyRolloutCardOptionsDialogFragment)
		{
			parentFragmentManager = loyaltyRolloutCardOptionsDialogFragment.ParentFragmentManager;
			loyaltyRolloutCardOptionsDialogFragment.Dismiss();
		}
		LoyaltyCardReattachPlasticFragment loyaltyCardReattachPlasticFragment = _fragmentFactory.Instantiate<LoyaltyCardReattachPlasticFragment>();
		loyaltyCardReattachPlasticFragment.Arguments = parameter.ToNavBundle();
		loyaltyCardReattachPlasticFragment.Show(parentFragmentManager, null);
	}

	private void GoToAuthorization()
	{
		base.ParentFragmentManager.PopBackStack(null, 1);
		NavigateTo<AuthOrRegisterFragment>();
	}

	private void ShowSuccessfullyReattached(LoyaltyCardReattachPlasticCardNavigationParameter parameter)
	{
		LoyaltyCardReattachedFragment loyaltyCardReattachedFragment = _fragmentFactory.Instantiate<LoyaltyCardReattachedFragment>();
		FragmentManager parentFragmentManager = base.ParentFragmentManager;
		if (base.ParentFragment is LoyaltyRolloutCardOptionsDialogFragment loyaltyRolloutCardOptionsDialogFragment)
		{
			parentFragmentManager = loyaltyRolloutCardOptionsDialogFragment.ParentFragmentManager;
			loyaltyRolloutCardOptionsDialogFragment.Dismiss();
		}
		else
		{
			loyaltyCardReattachedFragment.SetTargetFragment(this, 68854);
		}
		loyaltyCardReattachedFragment.Arguments = parameter.ToNavBundle();
		loyaltyCardReattachedFragment.Show(parentFragmentManager, null);
	}
}
