using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Common.UiExtensions;
using Auchan.Android.Controls.PinEntryView;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.PersonalCabinet.Authorization;
using Google.Android.Material.Button;
using VisibilitySwitch;

namespace Auchan.Android.Authorization;

internal sealed class VerifyPinFragment : BaseFragment<VerifyPinViewModel>, IOnPinEnteringResultListener
{
	protected override int LayoutId => 2131493121;

	public VerifyPinFragment(Func<VerifyPinViewModel.Parameter, VerifyPinViewModel> newViewModel)
		: base((Func<Fragment, VerifyPinViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<VerifyPinViewModel.Parameter>())))
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.OpenSignUpCommand.SafeSubscribe(delegate(SignUpViewModel.Parameter p)
		{
			OpenSignUpAsync(p).SafeFireAndForget((Action<Exception>)null, false);
		}, this);
		base.ViewModel.OpenSupportCommand.SafeSubscribe(delegate(DidntReceiveSmsViewModel.Parameter p)
		{
			Show<DidntReceiveSmsBottomSheet, DidntReceiveSmsViewModel.Parameter>(p);
		}, this);
		base.ViewModel.OpenAuthOrRegisterCommand.SafeSubscribe(delegate
		{
			OpenAuthOrRegister();
		}, this);
		base.ViewModel.OpenCardBlockedCommand.SafeSubscribe(OpenCardBlocked, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131296904);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		TextView textView = linearLayout.RequireViewById<TextView>(2131297266);
		HighlightedTextView messageLabel = linearLayout.RequireViewById<HighlightedTextView>(2131297571);
		PinEntryView pinInput = linearLayout.RequireViewById<PinEntryView>(2131297913);
		TextView countDownText = linearLayout.RequireViewById<TextView>(2131298392);
		MaterialButton getPinButton = linearLayout.RequireViewById<MaterialButton>(2131297234);
		TextView textView2 = linearLayout.RequireViewById<TextView>(2131296983);
		IToolbarContainer toolbarContainer = (IToolbarContainer)RequireParentFragment();
		Toolbar toolbar = toolbarContainer.Toolbar;
		VisibilitySwitch<VerifyPinViewModel.VisualState> visibilitySwitch = new VisibilitySwitch<VerifyPinViewModel.VisualState>(VerifyPinViewModel.VisualState.Default)
		{
			{
				VerifyPinViewModel.VisualState.Default,
				linearLayout
			},
			{
				VerifyPinViewModel.VisualState.Default,
				toolbar
			},
			{
				VerifyPinViewModel.VisualState.InProgress,
				frameLayout
			}
		};
		toolbarContainer.Title = base.ViewModel.Title;
		toolbarContainer.CloseButtonText = base.ViewModel.CloseString;
		pinInput.ResultListener = this;
		pinInput.InputField.OnTextChanged(delegate(object? sender, TextChangedEventArgs args)
		{
			base.ViewModel.PinTextChangedCommand.Trigger(args.Text?.ToString() ?? string.Empty);
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		textView2.Text = base.ViewModel.UserCantEnter;
		getPinButton.Text = base.ViewModel.RequestCodeButtonTitle;
		textView.Text = base.ViewModel.Header;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[6]
		{
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
				switch (base.ViewModel.State)
				{
				case VerifyPinViewModel.VisualState.Default:
					pinInput.RequestFocus();
					break;
				case VerifyPinViewModel.VisualState.InProgress:
					pinInput.HideKeyboard(RequireActivity());
					break;
				}
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				messageLabel.AttributedText = base.ViewModel.VerificationLabel;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("VerificationLabel")),
			(delegate
			{
				getPinButton.Visibility = base.ViewModel.CanRequestPin.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanRequestPin")),
			(delegate
			{
				countDownText.Visibility = (!base.ViewModel.CanRequestPin).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanRequestPin")),
			(delegate
			{
				countDownText.Text = base.ViewModel.PinRequestCountDown;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PinRequestCountDown")),
			(delegate
			{
				getPinButton.Enabled = base.ViewModel.CanRequestPin;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanRequestPin"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(getPinButton.OnClick(base.ViewModel.RequestPin), textView2.OnClick(base.ViewModel.OnDidntReceiveSmsClicked), toolbarContainer.CloseButton.OnClick(base.ViewModel.CloseClickedAnalytics)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		ViewLifecycleOwner.LaunchWhen(delegate
		{
			RequireActivity().HideKeyboard();
		}, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		base.ViewModel.ResetPinCommand.SafeSubscribe(delegate
		{
			pinInput.Reset();
		}, ViewLifecycleOwner);
	}

	private async Task OpenSignUpAsync(SignUpViewModel.Parameter parameter)
	{
		(await this.GetParentFragmentManagerAsync()).PopBackStack(null, 1);
		await NavigateToAsync<SignUpFragment, SignUpViewModel.Parameter>(parameter);
	}

	private void OpenCardBlocked(Unit unit)
	{
		base.ParentFragmentManager.PopBackStack(null, 1);
		NavigateTo<LoyaltyCardBlockedFragment>();
	}

	private void OpenAuthOrRegister()
	{
		base.ParentFragmentManager.PopBackStack(null, 1);
		NavigateTo<AuthOrRegisterFragment>();
	}

	void IOnPinEnteringResultListener.OnResult(string result)
	{
		base.ViewModel.PinText = result;
	}
}
