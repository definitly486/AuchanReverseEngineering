using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Activity;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.SafeEntrance.ViewModels;
using Google.Android.Material.Button;

namespace Auchan.Android.SafeEntrance;

internal class EnterPinCodeFragment : BaseFragment<EnterBiometryViewModel>
{
	private TextView _subtitle;

	private TextView _errorLabel;

	private PinArea _pinArea;

	private OnBackPressedCallback _backPressCallback;

	protected override int LayoutId => 2131493515;

	public EnterPinCodeFragment(Func<Fragment, EnterBiometryViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			PassControlToCaller();
		}, this);
		_backPressCallback = RequireActivity().OnBackPressedDispatcher.AddCallback(this, delegate
		{
		});
	}

	private void PassControlToCaller()
	{
		(base.Activity as ISafeEntranceFlowHandler)?.Handle();
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131297274);
		TextView title = view.RequireViewById<TextView>(2131298655);
		_subtitle = view.RequireViewById<TextView>(2131298654);
		_errorLabel = view.RequireViewById<TextView>(2131297117);
		_pinArea = view.RequireViewById<PinArea>(2131297906);
		EnterPinView enterPinView = view.RequireViewById<EnterPinView>(2131297914);
		EnterPinView enterPinView2 = enterPinView;
		enterPinView2.NumberButtonPressed = (EventHandler<int>)Delegate.Combine(enterPinView2.NumberButtonPressed, (EventHandler<int>)delegate(object? _, int i)
		{
			base.ViewModel.AddPinCodeDigit(i);
		});
		EnterPinView enterPinView3 = enterPinView;
		enterPinView3.RemoveButtonPressed = (EventHandler)Delegate.Combine(enterPinView3.RemoveButtonPressed, (EventHandler)delegate
		{
			base.ViewModel.RemovePinCodeDigit();
		});
		EnterPinView enterPinView4 = enterPinView;
		enterPinView4.BiometryButtonPressed = (EventHandler)Delegate.Combine(enterPinView4.BiometryButtonPressed, (EventHandler)delegate
		{
			base.ViewModel.OnShowBiometricLoginClick();
		});
		materialButton.Text = base.ViewModel.ForgotPinCode;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[5]
		{
			(delegate
			{
				title.Text = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				_subtitle.Text = base.ViewModel.Subtitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Subtitle")),
			(delegate
			{
				_errorLabel.Text = base.ViewModel.EnteredWrongPinCode;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EnteredWrongPinCode")),
			(delegate
			{
				enterPinView.BiometryButtonVisibility = base.ViewModel.IsEntranceWithBiometry;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsEntranceWithBiometry")),
			(delegate
			{
				OnWrongPinCode(base.ViewModel.IsWrongPinCodeEntered);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsWrongPinCodeEntered"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((View)materialButton).OnClick((Action)delegate
		{
			base.ViewModel.ForgotPinCodeClick().SafeFireAndForget((Action<Exception>)null, false);
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OnPropertyChanges((EnterBiometryViewModel x) => x.CodeStates).StartWith(base.ViewModel.CodeStates).SafeSubscribe(delegate
		{
			SetPins();
		}, ViewLifecycleOwner);
	}

	private void OnWrongPinCode(bool isWrongPinCodeEntered)
	{
		_subtitle.Visibility = (!isWrongPinCodeEntered).ToVisibility();
		_errorLabel.Visibility = isWrongPinCodeEntered.ToVisibility();
	}

	private void SetPins()
	{
		_pinArea.Pins = base.ViewModel.CodeStates.ToArray();
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (disposing)
		{
			_backPressCallback.Dispose();
		}
	}
}
