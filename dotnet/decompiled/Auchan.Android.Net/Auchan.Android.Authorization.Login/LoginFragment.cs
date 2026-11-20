using System;
using System.Collections.Generic;
using System.Reactive;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Common.UiExtensions;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.InfoPages;
using Auchan.Common.PersonalCabinet.Authorization;
using Google.Android.Material.TextField;
using VisibilitySwitch;

namespace Auchan.Android.Authorization.Login;

internal class LoginFragment : BaseFragment<LoginViewModel>
{
	private sealed class Controls
	{
		public TextInputEditText PasswordInput { get; } = view.RequireViewById<TextInputEditText>(2131297845);

		public View DefaultLayout { get; } = view.RequireViewById<View>(2131296909);

		public View ProgressLayout { get; } = view.RequireViewById<View>(2131298084);

		public TextInputLayout PhoneInputLayout { get; } = view.RequireViewById<TextInputLayout>(2131297873);

		public OutlinedErrorEditText PhoneInput { get; } = view.RequireViewById<OutlinedErrorEditText>(2131297872);

		public TextView PhonePlaceHolder { get; } = view.RequireViewById<TextView>(2131296546);

		public TextView GetPinButton { get; } = view.RequireViewById<TextView>(2131297234);

		public TextView PhoneLegalLabel { get; } = view.RequireViewById<TextView>(2131297876);

		public Controls(View view)
		{
		}
	}

	private Controls? _controls;

	protected override int LayoutId => 2131493035;

	public LoginFragment(Func<LoginViewModel.Parameter, LoginViewModel> newViewModel)
		: base((Func<Fragment, LoginViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<LoginViewModel.Parameter>())))
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.OpenPrivacyPolicyCommand.SafeSubscribe(OpenPrivacyPolicy, this);
		base.ViewModel.NavigateToPinCommand.SafeSubscribe(OpenPinScreen, this);
		base.ViewModel.OpenAuthOrRegisterCommand.SafeSubscribe(delegate
		{
			OpenAuthOrRegister();
		}, this);
		base.ViewModel.FocusPhoneInputCommand.SafeSubscribe(FocusPhoneInput, this);
		base.ViewModel.PasswordAcceptedCommand.SafeSubscribe(delegate
		{
			_controls?.PasswordInput.ForceUnfocusKeyboard();
		}, this);
		base.ViewModel.OpenPasswordInputCommand.SafeSubscribe(delegate
		{
			if (_controls != null)
			{
				_controls.PasswordInput.Text = string.Empty;
				_controls.PasswordInput.ForceFocusKeyboard();
			}
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ToolbarContainerFragment toolbarContainerFragment = (ToolbarContainerFragment)RequireParentFragment();
		Controls controls = new Controls(view);
		_controls = controls;
		VisibilitySwitch<LoginViewModel.VisualState> switcher = new VisibilitySwitch<LoginViewModel.VisualState>(LoginViewModel.VisualState.Default)
		{
			{
				LoginViewModel.VisualState.Default,
				toolbarContainerFragment.Toolbar
			},
			{
				LoginViewModel.VisualState.Default,
				controls.DefaultLayout
			},
			{
				LoginViewModel.VisualState.InProgress,
				controls.ProgressLayout
			}
		};
		toolbarContainerFragment.Title = base.ViewModel.Title;
		toolbarContainerFragment.CloseButtonText = base.ViewModel.CloseString;
		controls.PhoneInput.SetupPhoneMask(base.ViewModel.PhoneMask, base.ViewModel.PhonePlaceholder, controls.PhonePlaceHolder, OnPhoneChanged, ViewLifecycleOwner);
		controls.PhoneInputLayout.Hint = base.ViewModel.PhoneLabelText;
		ViewOnKeyListener viewOnKeyListener = new ViewOnKeyListener(OnKeyboardKeyPressed);
		viewOnKeyListener.AutoDisposeOnDestroy(ViewLifecycleOwner);
		controls.PhoneInput.SetOnKeyListener(viewOnKeyListener);
		controls.PasswordInput.SetOnKeyListener(viewOnKeyListener);
		controls.PasswordInput.OnTextChanged(delegate(object? o, TextChangedEventArgs e)
		{
			base.ViewModel.VerifyPassword(e.Text?.ToString() ?? "");
			if (e.Text != null && e.Text.ToString().Length == 6)
			{
				controls.PasswordInput.Text = string.Empty;
			}
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		controls.GetPinButton.Text = base.ViewModel.ReceiveSmsButton;
		controls.PhoneLegalLabel.AddLinkedText(base.ViewModel.PhoneLegalString);
		RequireActivity().Window.HideKeyboardOnTouchOutside(controls.PhoneInput, ViewLifecycleOwner);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				switcher.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				controls.GetPinButton.Enabled = base.ViewModel.CanLoginByPhone;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CanLoginByPhone")),
			(delegate
			{
				controls.PhoneInput.Text = base.ViewModel.PhoneText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PhoneText"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(toolbarContainerFragment.SetTitleClickAction(base.ViewModel.OnTitleClick), ((View)controls.PhoneInput).OnFocusChange((Action)delegate
		{
			OnFocusChanged(controls);
		}), controls.GetPinButton.OnClick(base.ViewModel.LoginByPhone)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private void OnFocusChanged(Controls controls)
	{
		if (!controls.PhoneInput.HasFocus)
		{
			if (string.IsNullOrEmpty(controls.PhoneInput.Text))
			{
				controls.PhonePlaceHolder.Visibility = ViewStates.Gone;
			}
		}
		else
		{
			controls.PhonePlaceHolder.Visibility = ViewStates.Visible;
		}
	}

	private void OnPhoneChanged(bool maskFilled, string extractedValue)
	{
		base.ViewModel.CanLoginByPhone = maskFilled;
		base.ViewModel.PhoneText = extractedValue;
	}

	private void OpenPrivacyPolicy(InfoPageViewModel.Parameter parameter)
	{
		FragmentManager supportFragmentManager = RequireActivity().SupportFragmentManager;
		BottomSheetInfoPageFragmentContainer bottomSheetInfoPageFragmentContainer = supportFragmentManager.FragmentFactory.Instantiate<BottomSheetInfoPageFragmentContainer>();
		bottomSheetInfoPageFragmentContainer.Arguments = parameter.ToNavBundle();
		bottomSheetInfoPageFragmentContainer.Show(supportFragmentManager, null);
	}

	private void OpenPinScreen(VerifyPinViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Replace<VerifyPinFragment>(this, parameter.ToNavBundle()).AddToBackStack(null)
			.Commit();
	}

	private void OpenAuthOrRegister()
	{
		base.ParentFragmentManager.PopBackStack(null, 1);
		base.ParentFragmentManager.BeginTransaction().Replace<AuthOrRegisterFragment>(this).Commit();
	}

	private bool OnKeyboardKeyPressed(View view, Keycode keyCode, KeyEvent keyEvent)
	{
		if (keyCode == Keycode.Enter)
		{
			View.ClearFocus();
			View.HideKeyboard(base.Activity);
			return true;
		}
		return false;
	}

	private void FocusPhoneInput(Unit unit)
	{
		if (_controls != null)
		{
			_controls.PhoneInput.ForceFocusKeyboard();
			_controls.PhoneInput.ResetText(base.ViewModel.PhoneText);
		}
	}
}
