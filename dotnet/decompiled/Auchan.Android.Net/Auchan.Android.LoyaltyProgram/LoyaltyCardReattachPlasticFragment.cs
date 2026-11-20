using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content.Resources;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Common.UiExtensions;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.LoyaltyProgram.ViewModels.CardRollout;
using Google.Android.Material.Button;
using Google.Android.Material.TextField;
using VisibilitySwitch;

namespace Auchan.Android.LoyaltyProgram;

internal class LoyaltyCardReattachPlasticFragment : BaseBottomSheetDialogFragment<LoyaltyCardReattachPlasticCardViewModel>, IFragmentResultReceiver<string>
{
	private const int FinalDialogRequestCode = 68854;

	private readonly FragmentFactory _fragmentFactory;

	private const int CardScannerDialogRequestCode = 969521;

	private TextInputEditText? _cardNumberInput;

	private TextInputEditText? _cardCvcInput;

	protected override int LayoutId => 2131493045;

	public override int Theme => 2131951916;

	protected override bool FullScreen => true;

	public LoyaltyCardReattachPlasticFragment(FragmentFactory fragmentFactory, Func<LoyaltyCardReattachPlasticCardNavigationParameter, LoyaltyCardReattachPlasticCardViewModel> newViewModel)
		: base((Func<Fragment, LoyaltyCardReattachPlasticCardViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<LoyaltyCardReattachPlasticCardNavigationParameter>())))
	{
		_fragmentFactory = fragmentFactory;
	}

	public override void OnDestroyView()
	{
		_cardCvcInput = null;
		_cardNumberInput = null;
		base.OnDestroyView();
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131296904);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		View view2 = linearLayout.RequireViewById<View>(2131296490);
		TextView textView = linearLayout.RequireViewById<TextView>(2131298655);
		TextView textView2 = linearLayout.RequireViewById<TextView>(2131298560);
		MaterialButton materialButton = linearLayout.RequireViewById<MaterialButton>(2131296795);
		TextInputLayout cardNumberInputLayout = linearLayout.RequireViewById<TextInputLayout>(2131296661);
		_cardNumberInput = cardNumberInputLayout.RequireViewById<TextInputEditText>(2131296660);
		TextInputLayout cardCvcInputLayout = linearLayout.RequireViewById<TextInputLayout>(2131296649);
		_cardCvcInput = cardCvcInputLayout.RequireViewById<TextInputEditText>(2131296648);
		MaterialButton signUpButton = linearLayout.RequireViewById<MaterialButton>(2131298373);
		TextView textView3 = constraintLayout.RequireViewById<TextView>(2131296808);
		ImageView errorImage = constraintLayout.RequireViewById<ImageView>(2131296807);
		ImageView imageView = constraintLayout.RequireViewById<ImageView>(2131296795);
		TextView textView4 = constraintLayout.RequireViewById<TextView>(2131298646);
		TextView errorSubTitle = constraintLayout.RequireViewById<TextView>(2131296809);
		textView3.AddScrollBehaviour();
		textView.Text = base.ViewModel.ScreenTitle;
		textView2.Text = base.ViewModel.Subtitle;
		textView2.Visibility = base.ViewModel.IsSubtitleVisible.ToVisibility();
		materialButton.Text = base.ViewModel.CloseButtonTitle;
		signUpButton.Text = base.ViewModel.SignUpButtonTitle;
		cardNumberInputLayout.Hint = base.ViewModel.CardNumberTitle;
		cardNumberInputLayout.HelperText = base.ViewModel.CardNumberValidationHint;
		cardCvcInputLayout.Hint = base.ViewModel.CardCvcTitle;
		cardCvcInputLayout.HelperText = base.ViewModel.CardCvcValidationHint;
		_cardNumberInput.InstallMaskedListener(base.ViewModel.LoyaltyCardNumberMask, null);
		_cardCvcInput.SetFilters(new IInputFilter[1]
		{
			new InputFilterLengthFilter(base.ViewModel.LoyaltyCardCvcLength)
		});
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			{
				VisualState.Default,
				linearLayout
			},
			{
				VisualState.Error,
				constraintLayout
			},
			{
				VisualState.InProgress,
				frameLayout
			}
		};
		textView4.Text = base.ViewModel.ErrorTitle;
		errorSubTitle.Text = base.ViewModel.ErrorSubTitle;
		textView3.SetLinkedHtml(base.ViewModel.ConnectionErrorText, base.ViewModel.HandleLink).AutoDisposeAllOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[10]
		{
			(delegate
			{
				errorImage.FromUrlWithPlaceholder(base.ViewModel.ConnectionErrorImage, 2131231054);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ConnectionErrorImage")),
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				errorSubTitle.Text = base.ViewModel.ErrorSubTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorSubTitle")),
			(delegate
			{
				signUpButton.Enabled = base.ViewModel.IsSignUpButtonEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSignUpButtonEnabled")),
			(delegate
			{
				cardNumberInputLayout.SetError(base.ViewModel.CardNumberValidationHint, !base.ViewModel.IsCardNumberValid);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "CardNumberValidationHint", "IsCardNumberValid" })),
			(delegate
			{
				cardCvcInputLayout.SetError(base.ViewModel.CardCvcValidationHint, !base.ViewModel.IsCardCvcValid);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "CardCvcValidationHint", "IsCardCvcValid" })),
			(delegate
			{
				_cardCvcInput.SetHintTextColor(new Color(ResourcesCompat.GetColor(base.Activity.Resources, base.ViewModel.IsCardNumberValid ? 2131099703 : 2131099790, base.Activity.Theme)));
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCardNumberValid")),
			(delegate
			{
				_cardNumberInput.ApplyText(base.ViewModel.CardNumberText);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CardNumberText")),
			(delegate
			{
				_cardCvcInput.ApplyText(base.ViewModel.CardCvcText);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CardCvcText")),
			(delegate
			{
				_cardNumberInput.SetHintTextColor(new Color(ResourcesCompat.GetColor(base.Activity.Resources, base.ViewModel.IsCardNumberValid ? 2131099703 : 2131099790, base.Activity.Theme)));
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCardNumberValid"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(view2.OnClick(Dismiss), imageView.OnClick(Dismiss), materialButton.OnClick(Dismiss), signUpButton.OnClick(OnSignUpClicked), _cardNumberInput.OnFocusChange(OnCardNumberFocusChanged), _cardCvcInput.OnFocusChange(OnCardCvcFocusChanged), ((TextView)_cardNumberInput).OnTextChanged((Action)delegate
		{
			base.ViewModel.CardNumberText = _cardNumberInput.Text ?? "";
		}), ((TextView)_cardCvcInput).OnTextChanged((Action)delegate
		{
			base.ViewModel.CardCvcText = _cardCvcInput.Text ?? "";
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		_cardCvcInput.SetOnKeyListener(new ViewOnKeyListener(OnKeyboardKeyPressed));
		base.ViewModel.ShowSuccessfullyReattachedCommand.SafeSubscribe(ShowSuccessfullyReattached, ViewLifecycleOwner);
	}

	private void OnSignUpClicked()
	{
		RequireDialog().HideKeyboardInDialog();
		base.ViewModel.SignUp();
	}

	public void OnResult(int requestCode, string value)
	{
		switch (requestCode)
		{
		case 969521:
			_cardNumberInput.Text = value;
			break;
		case 68854:
			Dismiss();
			break;
		}
	}

	private bool OnKeyboardKeyPressed(View arg1, Keycode keyCode, KeyEvent arg3)
	{
		if (keyCode == Keycode.Enter)
		{
			View.RequestFocus();
			View.HideKeyboard(base.Activity);
			return true;
		}
		return false;
	}

	private void OnCardNumberFocusChanged()
	{
		TextInputEditText? cardNumberInput = _cardNumberInput;
		if (cardNumberInput != null && !cardNumberInput.HasFocus)
		{
			base.ViewModel.OnFinishCardNumberInput();
		}
	}

	private void OnCardCvcFocusChanged()
	{
		TextInputEditText? cardCvcInput = _cardCvcInput;
		if (cardCvcInput != null && !cardCvcInput.HasFocus)
		{
			base.ViewModel.OnFinishCardCvcInput();
		}
	}

	private void ShowSuccessfullyReattached(LoyaltyCardReattachPlasticCardNavigationParameter parameter)
	{
		LoyaltyCardReattachedFragment loyaltyCardReattachedFragment = _fragmentFactory.Instantiate<LoyaltyCardReattachedFragment>();
		if (base.ParentFragment is LoyaltyRolloutCardOptionsDialogFragment loyaltyRolloutCardOptionsDialogFragment)
		{
			loyaltyRolloutCardOptionsDialogFragment.Dismiss();
		}
		else
		{
			loyaltyCardReattachedFragment.SetTargetFragment(this, 68854);
		}
		loyaltyCardReattachedFragment.Arguments = parameter.ToNavBundle();
		loyaltyCardReattachedFragment.Show(base.ParentFragmentManager, null);
	}
}
