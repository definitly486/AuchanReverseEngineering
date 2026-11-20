using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.SafeEntrance.ViewModels;
using Google.Android.Material.Button;

namespace Auchan.Android.SafeEntrance;

internal class CreatePinCodeFragment : BaseFragment<CreateBiometryViewModel>
{
	private PinArea _pinArea;

	private TextView _subtitle;

	private TextView _errorLabel;

	protected override int LayoutId => 2131493514;

	public CreatePinCodeFragment(Func<Fragment, CreateBiometryViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			base.ParentFragmentManager.PopBackStack();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131296795);
		TextView title = view.RequireViewById<TextView>(2131298655);
		_subtitle = view.RequireViewById<TextView>(2131298654);
		_errorLabel = view.RequireViewById<TextView>(2131297117);
		_pinArea = view.RequireViewById<PinArea>(2131297906);
		TextView description = view.RequireViewById<TextView>(2131297281);
		EnterPinView enterPinView = view.RequireViewById<EnterPinView>(2131297914);
		enterPinView.NumberButtonPressed = (EventHandler<int>)Delegate.Combine(enterPinView.NumberButtonPressed, (EventHandler<int>)delegate(object? _, int i)
		{
			base.ViewModel.AddPinCodeDigit(i);
		});
		enterPinView.RemoveButtonPressed = (EventHandler)Delegate.Combine(enterPinView.RemoveButtonPressed, (EventHandler)delegate
		{
			base.ViewModel.RemovePinCodeDigit();
		});
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
				description.Text = base.ViewModel.Description;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Description")),
			(delegate
			{
				_errorLabel.Text = base.ViewModel.EnteredWrongPinCode;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EnteredWrongPinCode")),
			(delegate
			{
				OnWrongPinCode(base.ViewModel.IsWrongPinCodeEntered);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsWrongPinCodeEntered"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((View)materialButton).OnClick((Action)delegate
		{
			base.ParentFragmentManager.PopBackStack();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.OnPropertyChanges((CreateBiometryViewModel x) => x.CodeStates).StartWith(base.ViewModel.CodeStates).SafeSubscribe(delegate
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
}
