using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Content.PM;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Base.Widgets;
using Auchan.Android.Common.UiExtensions;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram.PointsTransfer.Contacts;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.AccomplishedTransfer;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Points;
using EBind;
using Google.Android.Material.Button;
using InputMask;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Android.LoyaltyProgram.PointsTransfer;

internal class LoyaltyPointsTransferToNumberFragment : BaseToolbarFragment<LoyaltyPointsTransferToNumberViewModel>, IFragmentResultReceiver<int>, IFragmentResultReceiver<string>
{
	private const int FinalDialogRequestCode = 19101;

	private readonly FragmentFactory _fragmentFactory;

	private OutlinedTextInput _phoneInputLayout;

	private EditText _phoneInput;

	private ViewOnClickListener contactsEndIconClickListener;

	private ViewGroup _pointsTab;

	private ViewGroup _stampsTab;

	protected override int LayoutId => 2131493055;

	public LoyaltyPointsTransferToNumberFragment(Func<LoyaltyPointsTransferNavigationParameter, LoyaltyPointsTransferToNumberViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base((Func<Fragment, LoyaltyPointsTransferToNumberViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<LoyaltyPointsTransferNavigationParameter>())))
	{
		_fragmentFactory = fragmentFactory;
	}

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		LinearLayout linearLayout = view.RequireViewById<LinearLayout>(2131297843);
		_pointsTab = view.RequireViewById<ViewGroup>(2131297940);
		View progress = view.RequireViewById<View>(2131298079);
		TextView pointsTitleLabel = view.RequireViewById<TextView>(2131297953);
		TextView pointsIntLabel = view.RequireViewById<TextView>(2131297938);
		TextView pointsFractionLabel = view.RequireViewById<TextView>(2131297933);
		_stampsTab = view.RequireViewById<ViewGroup>(2131298448);
		TextView stampsTitleLabel = view.RequireViewById<TextView>(2131298456);
		TextView stampsIntLabel = view.RequireViewById<TextView>(2131298447);
		TextView chooseRecipientLabel = view.RequireViewById<TextView>(2131296778);
		TextView enterPhoneLabel = view.RequireViewById<TextView>(2131297098);
		_phoneInputLayout = linearLayout.RequireViewById<OutlinedTextInput>(2131297873);
		_phoneInput = _phoneInputLayout.EditText;
		TextView enterAmountLabel = view.RequireViewById<TextView>(2131297096);
		OutlinedTextInput amountInputLayout = view.RequireViewById<OutlinedTextInput>(2131296438);
		EditText amountInput = amountInputLayout.EditText;
		TextView amountLimitLabel = view.RequireViewById<TextView>(2131296439);
		MaterialButton transferButton = linearLayout.RequireViewById<MaterialButton>(2131298751);
		View transferButtonGhost = linearLayout.RequireViewById<View>(2131298752);
		View view2 = linearLayout.RequireViewById<View>(2131297425);
		base.ToolbarTitle = base.ViewModel.ScreenTitle;
		MaskedTextChangedListener watcher = new MaskedTextChangedListener(base.ViewModel.PhoneMask, _phoneInput, new ValueListener(OnPhoneChanged));
		_phoneInput.AddTextChangedListener(watcher);
		_phoneInputLayout.Hint = base.ViewModel.PhoneNumberHint;
		transferButton.Text = base.ViewModel.TransferButtonText;
		amountInput.InputType = InputTypes.ClassNumber;
		_phoneInput.InputType = InputTypes.ClassPhone;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[19]
		{
			(delegate
			{
				UpdateLoyaltyTabs(base.ViewModel.PointsType);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsType")),
			(delegate
			{
				pointsTitleLabel.Text = base.ViewModel.PointsTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsTitle")),
			(delegate
			{
				pointsIntLabel.Text = base.ViewModel.PointsBalanceIntString;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsBalanceIntString")),
			(delegate
			{
				pointsFractionLabel.Text = base.ViewModel.PointsBalanceFractionString;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsBalanceFractionString")),
			(delegate
			{
				stampsTitleLabel.Text = base.ViewModel.StampsTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StampsTitle")),
			(delegate
			{
				stampsIntLabel.Text = base.ViewModel.StampsBalanceString;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StampsBalanceString")),
			(delegate
			{
				progress.Visibility = (base.ViewModel.State == VisualState.InProgress).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				chooseRecipientLabel.Text = base.ViewModel.ChooseRecipientLabel;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ChooseRecipientLabel")),
			(delegate
			{
				enterPhoneLabel.Text = base.ViewModel.EnterPhoneLabel;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EnterPhoneLabel")),
			(delegate
			{
				enterAmountLabel.Text = base.ViewModel.EnterAmountLabel;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EnterAmountLabel")),
			(delegate
			{
				amountLimitLabel.Text = base.ViewModel.AmountLimitText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AmountLimitText")),
			(delegate
			{
				amountLimitLabel.Visibility = base.ViewModel.IsAmountValid.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAmountValid")),
			(delegate
			{
				amountInput.ApplyText(base.ViewModel.PointsAmount);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsAmount")),
			(delegate
			{
				amountInputLayout.Hint = base.ViewModel.AmountInputHint;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AmountInputHint")),
			(delegate
			{
				amountInputLayout.SetError(base.ViewModel.AmountErrorText, !base.ViewModel.IsAmountValid);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "AmountErrorText", "IsAmountValid" })),
			(delegate
			{
				transferButton.Enabled = base.ViewModel.IsTransferButtonEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsTransferButtonEnabled")),
			(delegate
			{
				transferButtonGhost.Visibility = (!base.ViewModel.IsTransferButtonEnabled).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsTransferButtonEnabled")),
			(delegate
			{
				_phoneInputLayout.Hint = base.ViewModel.PhoneNumberHint;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PhoneNumberHint")),
			(delegate
			{
				_phoneInputLayout.SetError(base.ViewModel.PhoneNumberNotFoundLabel, base.ViewModel.IsPhoneNumberInvalid);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "PhoneNumberNotFoundLabel", "IsPhoneNumberInvalid" }))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(_pointsTab.OnClick(base.ViewModel.PointsTabTapped), _stampsTab.OnClick(base.ViewModel.StampsTabTapped), ((View)transferButton).OnClick((Action)delegate
		{
			ClickTransferButton().SafeFireAndForget((Action<Exception>)null, false);
		}), ((TextView)amountInput).OnTextChanged((Action)delegate
		{
			base.ViewModel.PointsAmount = amountInput.Text ?? "";
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		View[] array = new View[8] { linearLayout, amountInput, transferButtonGhost, amountInputLayout, chooseRecipientLabel, enterPhoneLabel, enterAmountLabel, view2 };
		foreach (View listener in array)
		{
			listener.Click += new DisposableDelegate<EventHandler>(delegate
			{
				if (base.ViewModel.IsPhoneNumberComplete)
				{
					SetPhoneInputEndIconContactState();
				}
			}, delegate(EventHandler h)
			{
				listener.Click -= h;
			}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		}
		_phoneInputLayout.ButtonTapped += new DisposableDelegate<Action<OutlinedTextInput.ButtonStyle>>(delegate(OutlinedTextInput.ButtonStyle style)
		{
			PhoneInputButtonTapped(style);
		}, delegate(Action<OutlinedTextInput.ButtonStyle> h)
		{
			_phoneInputLayout.ButtonTapped -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		amountInputLayout.ButtonTapped += new DisposableDelegate<Action<OutlinedTextInput.ButtonStyle>>(delegate(OutlinedTextInput.ButtonStyle style)
		{
			AmountInputButtonTapped(style);
		}, delegate(Action<OutlinedTextInput.ButtonStyle> h)
		{
			amountInputLayout.ButtonTapped -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.NavigateToTransferSuccess.SafeSubscribe(OnNavigateToTransferSuccess, ViewLifecycleOwner);
		base.ViewModel.NavigateToTransferFailure.SafeSubscribe(OnNavigateToTransferFailure, ViewLifecycleOwner);
		base.ViewModel.UpdatePhoneCommand.SafeSubscribe(delegate(string x)
		{
			_phoneInput.Text = x;
		}, ViewLifecycleOwner);
		base.ViewModel.NavigateToTransferOptionsCommand.SafeSubscribe(delegate
		{
			base.ParentFragmentManager.PopBackStack();
		}, ViewLifecycleOwner);
		SetPhoneInputEndIconContactState();
	}

	private async Task ClickTransferButton()
	{
		_phoneInputLayout.HideKeyboard(RequireContext());
		if (!(await base.ViewModel.OnTransferButtonSelected()))
		{
			_phoneInputLayout.ShowKeyboard(RequireContext());
		}
	}

	private void AmountInputButtonTapped(OutlinedTextInput.ButtonStyle style)
	{
		if (style == OutlinedTextInput.ButtonStyle.Clear)
		{
			base.ViewModel.PointsAmount = "";
		}
	}

	private void PhoneInputButtonTapped(OutlinedTextInput.ButtonStyle style)
	{
		if (style == OutlinedTextInput.ButtonStyle.Clear)
		{
			_phoneInputLayout.Clear();
			SetPhoneInputEmptyState().SafeFireAndForget((Action<Exception>)null, false);
		}
		if (style == OutlinedTextInput.ButtonStyle.Contacts)
		{
			CheckPermissionAndOpenContactsSelector();
		}
	}

	private void UpdateLoyaltyTabs(LoyaltyPointType pointType)
	{
		_pointsTab.Activated = pointType == LoyaltyPointType.Points;
		_stampsTab.Activated = pointType == LoyaltyPointType.Stamps;
		_stampsTab.Visibility = base.ViewModel.ShowStamps.ToVisibility();
		_pointsTab.Visibility = base.ViewModel.ShowPoints.ToVisibility();
		_phoneInputLayout.Clear();
		SetPhoneInputEmptyState().SafeFireAndForget((Action<Exception>)null, false);
	}

	private void OnNavigateToTransferSuccess(LoyaltyPointsSentToNumberNavigationParameter obj)
	{
		LoyaltyPointsSentToNumberFragment loyaltyPointsSentToNumberFragment = _fragmentFactory.Instantiate<LoyaltyPointsSentToNumberFragment>();
		loyaltyPointsSentToNumberFragment.Arguments = obj.ToNavBundle();
		loyaltyPointsSentToNumberFragment.SetTargetFragment(this, 19101);
		loyaltyPointsSentToNumberFragment.Show(base.ParentFragmentManager, null);
	}

	private void OnNavigateToTransferFailure(LoyaltyTransferErrorViewModel.Parameter parameter)
	{
		LoyaltyPointTransferErrorFragment loyaltyPointTransferErrorFragment = _fragmentFactory.Instantiate<LoyaltyPointTransferErrorFragment>();
		loyaltyPointTransferErrorFragment.Arguments = parameter.ToNavBundle();
		loyaltyPointTransferErrorFragment.Show(base.ParentFragmentManager, null);
	}

	private void CheckPermissionAndOpenContactsSelector()
	{
		if (ContextCompat.CheckSelfPermission(Context, "android.permission.READ_CONTACTS") != Permission.Granted)
		{
			RequestPermissions(new string[1] { "android.permission.READ_CONTACTS" }, 312);
		}
		else
		{
			OpenContactsSelector();
		}
	}

	public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
	{
		base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		if (requestCode == 312 && grantResults.Length != 0 && grantResults[0] == Permission.Granted)
		{
			OpenContactsSelector();
		}
		if (requestCode == 312 && grantResults.Length != 0 && grantResults[0] != Permission.Granted)
		{
			new AlertDialog.Builder(Context).SetTitle("Отсутствует доступ к контактам").SetMessage("Для получения списка контактов приложению необходимо дать разрешение на получение контактов.\nОткрыть настройки?").SetPositiveButton("ДА", delegate
			{
				AppInfo.ShowSettingsUI();
			})
				.SetNegativeButton("НЕТ", delegate
				{
				})
				.SetCancelable(cancelable: false)
				.Create()
				.SetCanceledOnTouchOutsideBuilder(cancel: false)
				.ShowCentered();
		}
	}

	private void OpenContactsSelector()
	{
		ContactsFragment contactsFragment = _fragmentFactory.Instantiate<ContactsFragment>();
		contactsFragment.SetTargetFragment(this, 0);
		contactsFragment.Show(base.ParentFragmentManager, null);
	}

	private void OnPhoneChanged(bool maskFilled, string extractedValue, string formattedValue)
	{
		base.ViewModel.PhoneText = extractedValue;
		base.ViewModel.IsPhoneNumberComplete = maskFilled;
		if (maskFilled)
		{
			SetPhoneDoneState().SafeFireAndForget((Action<Exception>)null, false);
		}
		else
		{
			_phoneInputLayout.SetButtonStyle(OutlinedTextInput.ButtonStyle.Clear);
		}
		if (string.IsNullOrEmpty(formattedValue))
		{
			SetPhoneInputEmptyState().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private async Task SetPhoneInputEmptyState()
	{
		await Task.Delay(50);
		SetPhoneInputEndIconContactState();
	}

	private async Task SetPhoneDoneState()
	{
		await Task.Delay(50);
		_phoneInputLayout.SetButtonStyle(OutlinedTextInput.ButtonStyle.Checkmark);
	}

	private void SetPhoneInputEndIconContactState()
	{
		_phoneInputLayout.SetButtonStyle(OutlinedTextInput.ButtonStyle.Contacts);
	}

	public void OnResult(int requestCode, int value)
	{
		base.ParentFragmentManager.PopBackStack("LoyaltyTransferFlowBackstack", 1);
	}

	public void OnResult(int requestCode, string value)
	{
		base.ViewModel.OnContactPhoneSelected(value);
	}

	protected override void OnNavigationButtonClick()
	{
		InputMethodManager.FromContext(Context).HideSoftInputFromWindow(View.WindowToken, HideSoftInputFlags.None);
		base.ParentFragmentManager.PopBackStack();
		if (base.ViewModel.PointsType == LoyaltyPointType.Stamps)
		{
			base.ParentFragmentManager.PopBackStack();
		}
	}
}
