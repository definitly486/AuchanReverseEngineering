using System;
using System.Collections.Generic;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Common.UiExtensions;
using Auchan.Android.DynamicFeedback;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.DynamicFeedback;
using Auchan.Common.Profile.GiftCards;
using Google.Android.Material.TextField;
using VisibilitySwitch;

namespace Auchan.Android.Profile.GiftCards;

internal class GiftCardBalanceFragment : BaseBottomSheetDialogFragment<GiftCardBalanceViewModel>
{
	private ImageView _pinButton;

	private Button _checkButon;

	private TextView _expiryTitle;

	private TextView _expiryText;

	private TextView _balanceTitle;

	private TextView _balanceText;

	private Button _okButton;

	private TextView _feedbackButton;

	private TextInputLayout _numberLayout;

	private TextInputLayout _pinLayout;

	private TextInputEditText _pinInput;

	protected override int LayoutId => 2131493470;

	public override int Theme => 2131951914;

	public GiftCardBalanceFragment(Func<Fragment, GiftCardBalanceViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView title = view.RequireViewById<TextView>(2131298646);
		View view2 = view.RequireViewById<View>(2131296909);
		View view3 = view.RequireViewById<View>(2131298084);
		Space space = view.RequireViewById<Space>(2131298086);
		Space space2 = view.RequireViewById<Space>(2131298081);
		View view4 = view.RequireViewById<View>(2131297118);
		TextView errorMessage = view4.RequireViewById<TextView>(2131297119);
		Button retryButton = view4.RequireViewById<Button>(2131297120);
		TextView errorFeedbackButton = view4.RequireViewById<TextView>(2131297115);
		View view5 = view4.RequireViewById<View>(2131296795);
		ViewGroup viewGroup = view.RequireViewById<ViewGroup>(2131296651);
		TextView cardErrorTitle = viewGroup.RequireViewById<TextView>(2131296653);
		TextView cardErrorMessage = viewGroup.RequireViewById<TextView>(2131296652);
		TextView textView = viewGroup.RequireViewById<TextView>(2131296650);
		View view6 = viewGroup.RequireViewById<View>(2131296795);
		_numberLayout = view.RequireViewById<TextInputLayout>(2131296661);
		TextInputEditText numberInput = view.RequireViewById<TextInputEditText>(2131296660);
		_pinLayout = view.RequireViewById<TextInputLayout>(2131296664);
		_pinInput = view.RequireViewById<TextInputEditText>(2131296663);
		_pinButton = view.RequireViewById<ImageView>(2131296665);
		_checkButon = view.RequireViewById<Button>(2131296507);
		_expiryTitle = view.RequireViewById<TextView>(2131296655);
		_expiryText = view.RequireViewById<TextView>(2131296654);
		_balanceTitle = view.RequireViewById<TextView>(2131296645);
		_balanceText = view.RequireViewById<TextView>(2131296644);
		_okButton = view.RequireViewById<Button>(2131297728);
		_feedbackButton = view.RequireViewById<TextView>(2131297150);
		_numberLayout.EndIconVisible = false;
		_pinLayout.EndIconVisible = false;
		_numberLayout.Hint = base.ViewModel.CardNumberPlaceholder;
		_pinLayout.Hint = base.ViewModel.CardPINPlaceholder;
		_pinInput.InputType = InputTypes.ClassNumber | InputTypes.DatetimeVariationDate;
		numberInput.InstallMaskedListener(base.ViewModel.CardNumberMask, null);
		TextInputEditText pinInput = _pinInput;
		IInputFilter[] filters = new InputFilterLengthFilter[1]
		{
			new InputFilterLengthFilter(base.ViewModel.CardPinLength)
		};
		pinInput.SetFilters(filters);
		_checkButon.Text = base.ViewModel.CheckButtonText;
		_expiryTitle.Text = base.ViewModel.CardExpireTimeTitle;
		_balanceTitle.Text = base.ViewModel.CardBalanceTitle;
		_okButton.Text = base.ViewModel.OkButtonText;
		_feedbackButton.Text = base.ViewModel.FeedbackButtonText;
		_feedbackButton.Visibility = ViewStates.Gone;
		textView.Text = base.ViewModel.FeedbackButtonText;
		errorFeedbackButton.Text = base.ViewModel.FeedbackButtonText;
		retryButton.Text = base.ViewModel.RetryButtonText;
		SetCardDataVisilibility(isVisible: false);
		VisibilitySwitch<GiftCardBalanceViewModel.VisualState> visibilySwitch = new VisibilitySwitch<GiftCardBalanceViewModel.VisualState>(GiftCardBalanceViewModel.VisualState.Default)
		{
			{
				GiftCardBalanceViewModel.VisualState.Default,
				view2
			},
			{
				GiftCardBalanceViewModel.VisualState.InProgress,
				view3,
				space,
				space2
			},
			{
				GiftCardBalanceViewModel.VisualState.Error,
				view4
			},
			{
				GiftCardBalanceViewModel.VisualState.CardError,
				viewGroup
			}
		};
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[12]
		{
			(delegate
			{
				visibilySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				SetErrorState(_numberLayout, base.ViewModel.CardNumberError);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CardNumberError")),
			(delegate
			{
				SetErrorState(_pinLayout, base.ViewModel.CardPINError);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CardPINError")),
			(delegate
			{
				title.Text = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				title.Visibility = (base.ViewModel.State != GiftCardBalanceViewModel.VisualState.InProgress).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				_expiryText.Text = base.ViewModel.CardExpireTimeText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CardExpireTimeText")),
			(delegate
			{
				_balanceText.Text = base.ViewModel.CardBalanceText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CardBalanceText")),
			(delegate
			{
				errorMessage.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				cardErrorTitle.Text = base.ViewModel.CardErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CardErrorTitle")),
			(delegate
			{
				cardErrorMessage.Text = base.ViewModel.CardErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CardErrorMessage")),
			(delegate
			{
				retryButton.Visibility = base.ViewModel.RetryButtonVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("RetryButtonVisible")),
			(delegate
			{
				errorFeedbackButton.Visibility = (!base.ViewModel.RetryButtonVisible).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("RetryButtonVisible"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((TextView)numberInput).OnTextChanged((EventHandler<TextChangedEventArgs>)delegate
		{
			base.ViewModel.CardNumberText = numberInput.Text;
		}), ((TextView)_pinInput).OnTextChanged((EventHandler<TextChangedEventArgs>)delegate
		{
			base.ViewModel.CardPINText = _pinInput.Text;
		}), _pinButton.OnClick(SwitchPinInputType), _checkButon.OnClick(base.ViewModel.RequestCardCommand.Trigger), _okButton.OnClick(base.ViewModel.CloseCommand.Trigger), _feedbackButton.OnClick(base.ViewModel.OpenFeedbackCommand.Trigger), textView.OnClick(base.ViewModel.OpenFeedbackCommand.Trigger), errorFeedbackButton.OnClick(base.ViewModel.OpenFeedbackCommand.Trigger), retryButton.OnClick(base.ViewModel.RetryCommand.Trigger), view5.OnClick(base.ViewModel.CloseCommand.Trigger), view6.OnClick(base.ViewModel.CloseCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
		base.ViewModel.OpenFeedbackCommand.SafeSubscribe(OpenFeedback, ViewLifecycleOwner);
		base.ViewModel.ShowCardDataCommand.SafeSubscribe(delegate
		{
			SetCardDataVisilibility(isVisible: true);
		}, ViewLifecycleOwner);
		base.ViewModel.ShowCardBalanceCommand.SafeSubscribe(delegate
		{
			SetCardBalanceVisilibility(isVisible: true);
		}, ViewLifecycleOwner);
		base.ViewModel.ShowFeedbackCommand.SafeSubscribe(delegate
		{
			_feedbackButton.Visibility = ViewStates.Visible;
		}, ViewLifecycleOwner);
		base.ViewModel.RequestCardCommand.SafeSubscribe(delegate
		{
			View?.ClearFocus();
			View?.HideKeyboard(base.Activity);
		}, ViewLifecycleOwner);
	}

	private void OpenFeedback(DynamicFeedbackViewModel.Parameter parameter)
	{
		base.ParentFragment.ParentFragmentManager.BeginTransaction().Hide(base.ParentFragment).Add<DynamicFeedbackFragment>(base.ParentFragment, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
		Dismiss();
	}

	private void SetCardDataVisilibility(bool isVisible)
	{
		_numberLayout.Enabled = !isVisible;
		_pinLayout.Enabled = !isVisible;
		_checkButon.Visibility = (!isVisible).ToVisibility();
		_expiryTitle.Visibility = isVisible.ToVisibility();
		_expiryText.Visibility = isVisible.ToVisibility();
		_balanceTitle.Visibility = isVisible.ToVisibility();
		_balanceText.Visibility = isVisible.ToVisibility();
		_okButton.Visibility = isVisible.ToVisibility();
	}

	private void SetCardBalanceVisilibility(bool isVisible)
	{
		_numberLayout.Enabled = !isVisible;
		_pinLayout.Enabled = !isVisible;
		_checkButon.Visibility = (!isVisible).ToVisibility();
		_balanceTitle.Visibility = isVisible.ToVisibility();
		_balanceText.Visibility = isVisible.ToVisibility();
		_okButton.Visibility = isVisible.ToVisibility();
	}

	private void SetErrorState(TextInputLayout layout, string error)
	{
		layout.Error = error;
		layout.ErrorEnabled = !string.IsNullOrEmpty(error);
	}

	private void SwitchPinInputType()
	{
		if (_pinInput.InputType == InputTypes.ClassNumber)
		{
			_pinButton.SetImageResource(2131231355);
			_pinInput.InputType = InputTypes.ClassNumber | InputTypes.DatetimeVariationDate;
		}
		else
		{
			_pinButton.SetImageResource(2131231192);
			_pinInput.InputType = InputTypes.ClassNumber;
		}
	}
}
