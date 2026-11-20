using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Android.Graphics;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Core.Content.Resources;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Common.UiExtensions;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Helpers;
using Auchan.Common.InfoPages;
using Auchan.Common.PersonalCabinet.Authorization;
using Auchan.Common.PersonalCabinet.DomainModels;
using EBind;
using Google.Android.Material.Button;
using Google.Android.Material.CheckBox;
using Google.Android.Material.RadioButton;
using Google.Android.Material.TextField;
using VisibilitySwitch;

namespace Auchan.Android.Authorization;

internal class SignUpFragment : BaseFragment<SignUpViewModel>, IFragmentResultReceiver<string>
{
	private const int CardScannerDialogRequestCode = 969521;

	private OutlinedErrorEditText _cardNumberInput;

	private OutlinedErrorEditText _cardCvcInput;

	private View _cvcHintView;

	private OutlinedErrorEditText _emailInput;

	private TextInputLayout _emailInputLayout;

	private OutlinedErrorEditText _firstNameInput;

	private OutlinedErrorEditText _dateOfBirthInput;

	private TextView _femaleButton;

	private TextView _maleButton;

	private TextInputLayout _dateOfBirthInputLayout;

	private TextView _dobPlaceholder;

	private MaterialRadioButton _havePlasticCardCheckbox;

	private MaterialRadioButton _noHavePlasticCardCheckbox;

	private NestedScrollView _scrollView;

	protected override int LayoutId => 2131493096;

	public SignUpFragment(Func<SignUpViewModel.Parameter, SignUpViewModel> newViewModel)
		: base((Func<Fragment, SignUpViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<SignUpViewModel.Parameter>())))
	{
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.OpenInfoPageCommand.SafeSubscribe(OpenInfoPage, this);
		base.ViewModel.RestartAuthCommand.SafeSubscribe(delegate
		{
			RestartAuth();
		}, this);
		base.ViewModel.FocusFirstNameInputCommand.SafeSubscribe(delegate
		{
			_firstNameInput?.ForceFocusKeyboard();
		}, this);
		base.ViewModel.FocusFirstNameInputCommand.SafeSubscribe(delegate
		{
			if (base.ViewModel.NeedCardNumberFocus)
			{
				_cardNumberInput?.ForceFocusKeyboard();
				base.ViewModel.NeedCardNumberFocus = false;
			}
			else
			{
				_firstNameInput?.ForceFocusKeyboard();
			}
		}, this);
		base.ViewModel.FocusToErrorField.SafeSubscribe(delegate
		{
			OnFocusToError();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		_scrollView = view.RequireViewById<NestedScrollView>(2131298297);
		ConstraintLayout constraintLayout = view.RequireViewById<ConstraintLayout>(2131296904);
		FrameLayout frameLayout = view.RequireViewById<FrameLayout>(2131298079);
		Fragment fragment = RequireParentFragment();
		Toolbar toolbar;
		if (fragment is IToolbarContainer toolbarContainer)
		{
			toolbar = toolbarContainer.Toolbar;
			if (!base.ViewModel.IsCloseButtonEnabled)
			{
			}
			toolbarContainer.CloseButtonText = base.ViewModel.CloseString;
			toolbarContainer.Title = base.ViewModel.Title;
			toolbarContainer.CustomBackAction(delegate
			{
				base.ViewModel.GoToAuthorization();
			}).AutoDisposeOnDestroy(ViewLifecycleOwner);
			base.ViewModel.NavigateToAuthOrRegister.SafeSubscribe(delegate
			{
				NavigateToAuthOrRegister();
			}, ViewLifecycleOwner);
			Disposable.Create(toolbarContainer, delegate(IToolbarContainer p)
			{
				p.CloseButtonText = null;
			}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		}
		else
		{
			if (!(fragment is ISignupFragmentContainer signupFragmentContainer))
			{
				throw new InvalidCastException("Parent fragment is not valid");
			}
			toolbar = signupFragmentContainer.Toolbar;
			if (!base.ViewModel.IsCloseButtonEnabled)
			{
			}
			signupFragmentContainer.CloseButtonText = base.ViewModel.CloseString;
			signupFragmentContainer.Title = base.ViewModel.Title;
		}
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			{
				VisualState.Default,
				constraintLayout
			},
			{
				VisualState.Default,
				toolbar
			},
			{
				VisualState.InProgress,
				frameLayout
			}
		};
		TextInputLayout firstNameInputLayout = constraintLayout.RequireViewById<TextInputLayout>(2131297206);
		_firstNameInput = firstNameInputLayout.RequireViewById<OutlinedErrorEditText>(2131297205);
		_dateOfBirthInputLayout = constraintLayout.RequireViewById<TextInputLayout>(2131297009);
		_dobPlaceholder = constraintLayout.RequireViewById<TextView>(2131297010);
		_dateOfBirthInput = _dateOfBirthInputLayout.RequireViewById<OutlinedErrorEditText>(2131297008);
		_femaleButton = constraintLayout.RequireViewById<TextView>(2131297230);
		_maleButton = constraintLayout.RequireViewById<TextView>(2131297233);
		_emailInputLayout = constraintLayout.RequireViewById<TextInputLayout>(2131297053);
		_emailInput = _emailInputLayout.RequireViewById<OutlinedErrorEditText>(2131297052);
		_havePlasticCardCheckbox = constraintLayout.RequireViewById<MaterialRadioButton>(2131297263);
		_noHavePlasticCardCheckbox = constraintLayout.RequireViewById<MaterialRadioButton>(2131297685);
		RadioGroup radioGroup = constraintLayout.RequireViewById<RadioGroup>(2131297264);
		MaterialCheckBox wantReceiveCheckbox = constraintLayout.RequireViewById<MaterialCheckBox>(2131298818);
		ExpandTouchArea(constraintLayout, wantReceiveCheckbox);
		TextView textView = constraintLayout.RequireViewById<TextView>(2131297265);
		TextView textView2 = constraintLayout.RequireViewById<TextView>(2131298819);
		LinearLayout cardInfo = constraintLayout.RequireViewById<LinearLayout>(2131296658);
		TextView rollCardText = constraintLayout.RequireViewById<TextView>(2131298256);
		TextInputLayout cardNumberInputLayout = constraintLayout.RequireViewById<TextInputLayout>(2131296661);
		_cardNumberInput = cardNumberInputLayout.RequireViewById<OutlinedErrorEditText>(2131296660);
		TextInputLayout cardCvcInputLayout = constraintLayout.RequireViewById<TextInputLayout>(2131296649);
		_cardCvcInput = cardCvcInputLayout.RequireViewById<OutlinedErrorEditText>(2131296648);
		_cvcHintView = constraintLayout.RequireViewById<View>(2131296886);
		TextView textView3 = _cvcHintView.RequireViewById<TextView>(2131296887);
		MaterialButton signUpButton = constraintLayout.RequireViewById<MaterialButton>(2131298373);
		TextView textView4 = constraintLayout.RequireViewById<TextView>(2131297433);
		_dateOfBirthInputLayout.EndIconVisible = false;
		firstNameInputLayout.Hint = base.ViewModel.FirstNamePlaceholder;
		_dateOfBirthInputLayout.Hint = base.ViewModel.DateOfBirthPlaceholder;
		_dateOfBirthInput.OnTextChanged(OnInputTextChanged).AutoDisposeOnDestroy(ViewLifecycleOwner);
		_femaleButton.Text = base.ViewModel.FemaleGenderTitle;
		_maleButton.Text = base.ViewModel.MaleGenderTitle;
		textView.Text = base.ViewModel.IHavePlasticCardTitle;
		radioGroup.Check(base.ViewModel.IsPlasticCardOwnershipChecked ? 2131297263 : 2131297685);
		UpdatePlasticCardRadioButtons(base.ViewModel.IsPlasticCardOwnershipChecked);
		rollCardText.Text = base.ViewModel.RollCardText;
		textView2.Text = base.ViewModel.WantToReceiveSuggestionsText;
		_emailInputLayout.Hint = base.ViewModel.EmailPlaceholder;
		signUpButton.Text = base.ViewModel.SignUpButtonTitle;
		textView4.AddLinkedText(base.ViewModel.LegalString);
		ViewOnClickListener viewOnClickListener = new ViewOnClickListener(OnGenderSelected);
		_femaleButton.SetOnClickListener(viewOnClickListener);
		_maleButton.SetOnClickListener(viewOnClickListener);
		viewOnClickListener.AutoDisposeOnDestroy(ViewLifecycleOwner);
		_emailInput.TextChanged += new DisposableDelegate<EventHandler<TextChangedEventArgs>>(delegate
		{
			_emailInput.SetError(isError: false);
		}, delegate(EventHandler<TextChangedEventArgs> h)
		{
			_emailInput.TextChanged -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		cardNumberInputLayout.Hint = base.ViewModel.CardNumberTitle;
		cardNumberInputLayout.HelperText = base.ViewModel.CardNumberValidationHint;
		cardCvcInputLayout.Hint = base.ViewModel.CardCvcTitle;
		cardCvcInputLayout.HelperText = base.ViewModel.CardCvcValidationHint;
		textView3.Text = base.ViewModel.CardCvcHintPopupTitle;
		_cardNumberInput.InstallMaskedListener(base.ViewModel.LoyaltyCardNumberMask, null);
		_dateOfBirthInput.InstallMaskedListener(base.ViewModel.DateOfBirthMask, null);
		_cardCvcInput.SetFilters(new IInputFilter[1]
		{
			new InputFilterLengthFilter(base.ViewModel.LoyaltyCardCvcLength)
		});
		_firstNameInput.SetFilters(new IInputFilter[1]
		{
			new InputFilterLengthFilter(25)
		});
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[17]
		{
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				_firstNameInput.SetHintTextColor(base.ViewModel.IsFirstNameValid ? Color.Rgb(255, 59, 47) : Color.Rgb(150, 161, 174));
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsFirstNameValid")),
			(delegate
			{
				firstNameInputLayout.SetError(base.ViewModel.FirstNameError, !base.ViewModel.IsFirstNameValid);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "FirstNameError", "IsFirstNameValid" })),
			(delegate
			{
				_firstNameInput.SetError(!base.ViewModel.IsFirstNameValid);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsFirstNameValid")),
			(delegate
			{
				_dateOfBirthInputLayout.SetError(base.ViewModel.DateOfBirthHelperText, base.ViewModel.IsDateErrorVisible);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "DateOfBirthHelperText", "IsDateErrorVisible" })),
			(delegate
			{
				_dateOfBirthInput.SetError(base.ViewModel.IsDateErrorVisible);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsDateErrorVisible")),
			(delegate
			{
				_emailInputLayout.SetErrorOrCorrect(base.ViewModel.IsEmailValid && _emailInputLayout.HasFocus, _emailInput.Text);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsEmailValid")),
			(delegate
			{
				wantReceiveCheckbox.Checked = base.ViewModel.IsWantToReceiveSuggestions;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsWantToReceiveSuggestions")),
			(delegate
			{
				signUpButton.Enabled = base.ViewModel.IsSignUpButtonEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSignUpButtonEnabled")),
			(delegate
			{
				cardInfo.Visibility = base.ViewModel.IsPlasticCardOwnershipChecked.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsPlasticCardOwnershipChecked")),
			(delegate
			{
				rollCardText.Visibility = (!base.ViewModel.IsPlasticCardOwnershipChecked).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsPlasticCardOwnershipChecked")),
			(delegate
			{
				cardNumberInputLayout.SetError(base.ViewModel.CardNumberValidationHint, !base.ViewModel.IsCardNumberValid);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "CardNumberValidationHint", "IsCardNumberValid" })),
			(delegate
			{
				_cardNumberInput.SetError(!base.ViewModel.IsCardNumberValid);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCardNumberValid")),
			(delegate
			{
				cardCvcInputLayout.SetError(base.ViewModel.CardCvcValidationHint, !base.ViewModel.IsCardCvcValid);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "CardCvcValidationHint", "IsCardCvcValid" })),
			(delegate
			{
				_cardCvcInput.SetError(!base.ViewModel.IsCardCvcValid);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCardCvcValid")),
			(delegate
			{
				_cardCvcInput.SetHintTextColor(new Color(ResourcesCompat.GetColor(base.Activity.Resources, base.ViewModel.IsCardNumberValid ? 2131099703 : 2131099790, base.Activity.Theme)));
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCardNumberValid")),
			(delegate
			{
				_cardNumberInput.SetHintTextColor(new Color(ResourcesCompat.GetColor(base.Activity.Resources, base.ViewModel.IsCardNumberValid ? 2131099703 : 2131099790, base.Activity.Theme)));
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCardNumberValid"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((TextView)_firstNameInput).OnTextChanged((EventHandler<TextChangedEventArgs>)delegate
		{
			base.ViewModel.FirstNameText = _firstNameInput.Text;
		}), ((TextView)_emailInput).OnTextChanged((EventHandler<TextChangedEventArgs>)delegate
		{
			base.ViewModel.EmailText = _emailInput.Text;
		}), wantReceiveCheckbox.OnCheckedChange(delegate(object? o, CompoundButton.CheckedChangeEventArgs e)
		{
			base.ViewModel.IsWantToReceiveSuggestions = e.IsChecked;
		}), ((TextView)_cardNumberInput).OnTextChanged((EventHandler<TextChangedEventArgs>)delegate
		{
			base.ViewModel.CardNumberText = _cardNumberInput.Text;
		}), ((TextView)_cardCvcInput).OnTextChanged((EventHandler<TextChangedEventArgs>)delegate
		{
			base.ViewModel.CardCvcText = _cardCvcInput.Text;
		}), ((TextView)_dateOfBirthInput).OnTextChanged((EventHandler<TextChangedEventArgs>)delegate
		{
			base.ViewModel.DateOfBirthText = _dateOfBirthInput.Text;
		}), ((View)signUpButton).OnClick((EventHandler)delegate
		{
			base.ViewModel.SignUp();
		}), ((View)_cardNumberInput).OnFocusChange((EventHandler<View.FocusChangeEventArgs>)delegate
		{
			OnCardNumberFocusChanged();
		}), ((View)_dateOfBirthInput).OnFocusChange((EventHandler<View.FocusChangeEventArgs>)delegate
		{
			OnDateFocusChanged();
		}), ((View)_cardCvcInput).OnFocusChange((EventHandler<View.FocusChangeEventArgs>)delegate
		{
			OnCardCvcFocusChanged();
		}), ((View)_emailInput).OnFocusChange((EventHandler<View.FocusChangeEventArgs>)delegate
		{
			OnEmailFocusChanged();
		}), ((TextView)_emailInput).OnAfterTextChanged((EventHandler<AfterTextChangedEventArgs>)delegate
		{
			TextChanged();
		}), radioGroup.OnCheckedChange(SelectPlasticCardButton), cardCvcInputLayout.OnClick(base.ViewModel.TapOnCvcHintIcon)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		ViewOnKeyListener viewOnKeyListener = new ViewOnKeyListener(OnKeyboardKeyPressed);
		viewOnKeyListener.AutoDisposeOnDestroy(ViewLifecycleOwner);
		_dateOfBirthInput.SetOnKeyListener(viewOnKeyListener);
		_cardCvcInput.SetOnKeyListener(viewOnKeyListener);
		_cardNumberInput.SetOnKeyListener(viewOnKeyListener);
		base.ViewModel.ShowCvcHintPopupCommand.SafeSubscribe(OnShowCvcHintPopup, this);
	}

	private void TextChanged()
	{
		_emailInput.SetError(isError: false);
	}

	private void ExpandTouchArea(View parent, params View[] targetViews)
	{
		ViewOnTouchListener viewOnTouchListener = new ViewOnTouchListener(delegate(View v, MotionEvent e)
		{
			if (e.Action == MotionEventActions.Down)
			{
				float positionX = e.GetX();
				float positionY = e.GetY();
				return targetViews.Any((View x) => TouchInAreaOf(x, positionY, positionX));
			}
			return false;
		});
		viewOnTouchListener.AutoDisposeOnDestroy(ViewLifecycleOwner);
		parent.SetOnTouchListener(viewOnTouchListener);
		static bool TouchInAreaOf(View view, float positionY, float positionX)
		{
			if ((Math.Abs((float)view.Top - positionY) <= (float)Converter.DpToPx(8f) || Math.Abs((float)view.Bottom - positionY) <= (float)Converter.DpToPx(8f) || (positionY > (float)view.Top && positionY < (float)view.Bottom)) && (Math.Abs((float)view.Left - positionX) <= (float)Converter.DpToPx(8f) || Math.Abs((float)view.Right - positionX) <= (float)Converter.DpToPx(8f) || (positionX > (float)view.Left && positionX < (float)view.Right)))
			{
				view.PerformClick();
				return true;
			}
			return false;
		}
	}

	private void NavigateToAuthOrRegister()
	{
		base.ParentFragmentManager.PopBackStack(null, 1);
		NavigateTo<AuthOrRegisterFragment>();
	}

	private void OnDateFocusChanged()
	{
		if (string.IsNullOrEmpty(_dateOfBirthInput.Text))
		{
			_dobPlaceholder.Visibility = _dateOfBirthInput.HasFocus.ToVisibility();
		}
	}

	private void SelectPlasticCardButton(object sender, RadioGroup.CheckedChangeEventArgs e)
	{
		bool flag = e.CheckedId == 2131297263;
		UpdatePlasticCardRadioButtons(flag);
		base.ViewModel.IsPlasticCardOwnershipChecked = flag;
	}

	private void UpdatePlasticCardRadioButtons(bool hasCard)
	{
		_havePlasticCardCheckbox.SetButtonDrawable(hasCard ? 2131231310 : 2131231309);
		_noHavePlasticCardCheckbox.SetButtonDrawable(hasCard ? 2131231309 : 2131231310);
	}

	private void OnInputTextChanged(object sender, TextChangedEventArgs e)
	{
		string text = e.Text?.ToString();
		string text2 = MakePlaceHolder(text);
		if (!string.IsNullOrEmpty(text2))
		{
			_dobPlaceholder.Text = text2;
		}
		_dobPlaceholder.SetTextColor(string.IsNullOrEmpty(text) ? new Color(ContextCompat.GetColor(RequireContext(), 2131100604)) : new Color(ContextCompat.GetColor(RequireContext(), 2131099872)));
	}

	private string MakePlaceHolder(string text)
	{
		int num = text?.Length ?? 0;
		if (num > base.ViewModel.DateOfBirthMaskPlaceholder.Length)
		{
			return null;
		}
		string text2 = base.ViewModel.DateOfBirthMaskPlaceholder.Substring(num, base.ViewModel.DateOfBirthMaskPlaceholder.Length - num);
		return text + text2;
	}

	private bool OnKeyboardKeyPressed(View view, Keycode keyCode, KeyEvent keyEvent)
	{
		if (keyCode == Keycode.Enter)
		{
			if (!base.ViewModel.IsPlasticCardOwnershipChecked && view.Id == _dateOfBirthInput.Id)
			{
				view.ClearFocus();
				View.HideKeyboard(base.Activity);
			}
			else
			{
				if (view.Id == _cardCvcInput.Id)
				{
					view.ClearFocus();
					View.HideKeyboard(base.Activity);
					return true;
				}
				if (view.Id == _cardNumberInput.Id)
				{
					_cardCvcInput.RequestFocus();
				}
			}
		}
		return false;
	}

	private void OnShowCvcHintPopup(Unit _)
	{
		if (_cvcHintView.Visibility != ViewStates.Visible)
		{
			_cvcHintView.Visibility = ViewStates.Visible;
			Observable.Timer(TimeSpan.FromSeconds(5L)).ObserveOn(MainThread.Scheduler).SafeSubscribe(delegate
			{
				_cvcHintView.Visibility = ViewStates.Gone;
			}, ViewLifecycleOwner);
		}
	}

	private void OnEmailFocusChanged()
	{
		if (!_emailInput.HasFocus)
		{
			SetEmailError();
		}
	}

	private void SetEmailError()
	{
		_emailInput.SetHintTextColor((!base.ViewModel.IsEmailValid) ? Color.Rgb(255, 59, 47) : Color.Rgb(150, 161, 174));
		_emailInputLayout.SetError(base.ViewModel.EmailError, !base.ViewModel.IsEmailValid);
		_emailInput.SetError(!base.ViewModel.IsEmailValid);
	}

	private void OnCardNumberFocusChanged()
	{
		if (!_cardNumberInput.HasFocus)
		{
			base.ViewModel.OnFinishCardNumberInput();
		}
	}

	private void OnCardCvcFocusChanged()
	{
		if (!_cardCvcInput.HasFocus)
		{
			base.ViewModel.OnFinishCardCvcInput();
		}
	}

	private void OnGenderSelected(View view)
	{
		if (view.Id == 2131297233)
		{
			_maleButton.SetBackgroundResource(2131230922);
			_femaleButton.SetBackgroundResource(2131230932);
			_maleButton.SetTextColor(new Color(ContextCompat.GetColor(RequireContext(), 2131100630)));
			_femaleButton.SetTextColor(new Color(ContextCompat.GetColor(RequireContext(), 2131100600)));
			base.ViewModel.SelectedGender = Gender.Male;
		}
		else
		{
			_femaleButton.SetBackgroundResource(2131230922);
			_maleButton.SetBackgroundResource(2131230932);
			_femaleButton.SetTextColor(new Color(ContextCompat.GetColor(RequireContext(), 2131100630)));
			_maleButton.SetTextColor(new Color(ContextCompat.GetColor(RequireContext(), 2131100600)));
			base.ViewModel.SelectedGender = Gender.Female;
		}
	}

	private void OpenInfoPage(InfoPageViewModel.Parameter parameter)
	{
		FragmentManager supportFragmentManager = RequireActivity().SupportFragmentManager;
		BottomSheetInfoPageFragmentContainer bottomSheetInfoPageFragmentContainer = supportFragmentManager.FragmentFactory.Instantiate<BottomSheetInfoPageFragmentContainer>();
		bottomSheetInfoPageFragmentContainer.Arguments = parameter.ToNavBundle();
		bottomSheetInfoPageFragmentContainer.Show(supportFragmentManager, null);
	}

	private void RestartAuth()
	{
		base.ParentFragmentManager.PopBackStack(null, 1);
		NavigateTo<AuthOrRegisterFragment>();
	}

	public void OnResult(int requestCode, string value)
	{
		if (requestCode == 969521)
		{
			_cardNumberInput.Text = value;
			base.ViewModel.NeedCardNumberFocus = true;
		}
	}

	private void OnFocusToError()
	{
		if (base.ViewModel.NeedScrollToEmail)
		{
			SetEmailError();
			_emailInput.ForceFocusKeyboard();
			int topRelativeTo = _emailInput.GetTopRelativeTo(_scrollView);
			_scrollView.SmoothScrollTo(0, topRelativeTo - base.Resources.DisplayMetrics.HeightPixels / 3);
		}
		else if (_dateOfBirthInput.IsError)
		{
			_dateOfBirthInput.ForceFocusKeyboard();
			int topRelativeTo2 = _dateOfBirthInput.GetTopRelativeTo(_scrollView);
			_scrollView.SmoothScrollTo(0, topRelativeTo2 - base.Resources.DisplayMetrics.HeightPixels / 3);
		}
		else if (_cardNumberInput.IsError)
		{
			_cardNumberInput.ForceFocusKeyboard();
			int topRelativeTo3 = _cardNumberInput.GetTopRelativeTo(_scrollView);
			_scrollView.SmoothScrollTo(0, topRelativeTo3 - base.Resources.DisplayMetrics.HeightPixels / 3);
		}
		else if (_cardCvcInput.IsError)
		{
			_cardCvcInput.ForceFocusKeyboard();
			int topRelativeTo4 = _cardCvcInput.GetTopRelativeTo(_scrollView);
			_scrollView.SmoothScrollTo(0, topRelativeTo4 - base.Resources.DisplayMetrics.HeightPixels / 3);
		}
	}
}
