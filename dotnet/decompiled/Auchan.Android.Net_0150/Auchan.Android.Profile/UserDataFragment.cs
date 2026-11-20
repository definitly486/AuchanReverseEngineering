using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Disposables;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Authorization;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Android.InfoPages;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.InfoPages;
using Auchan.Common.Profile;
using Auchan.Common.Profile.DateOfBirthSelection;
using Google.Android.Material.BottomNavigation;
using InputMask;
using VisibilitySwitch;

namespace Auchan.Android.Profile;

internal sealed class UserDataFragment : BaseToolbarFragment<UserDataViewModel>, IFragmentResultReceiver<DateTime>
{
	private sealed class Controls
	{
		public View View => _003Cview_003EP;

		public View DefaultLayout { get; }

		public View ProgressLayout { get; }

		public TextView ProgressTitle { get; }

		public TextView PersonalDataHeader { get; }

		public TextView ContactDataHeader { get; }

		public TextView GenderDataHeader { get; }

		public TextFieldControls FirstName { get; }

		public TextFieldControls LastName { get; }

		public TextFieldControls DateOfBirth { get; }

		public TextFieldControls Phone { get; }

		public TextFieldControls Email { get; }

		public View EmailConfirmationSnack { get; }

		public TextView EmailConfirmationText { get; }

		public TextView SendMailAgainButton { get; }

		public TextView EmailConfirmationTimeoutText { get; }

		public TextView SubTitleEReceipt { get; }

		public View SubLayoutPolls { get; }

		public TextView SubTitlePolls { get; }

		public View MarketingSubscriptionsLayout { get; }

		public TextView MarketingSubscriptionsTitle { get; }

		public TextView MarketingSubscriptionsSubtitle { get; }

		public RecyclerView MarketingSubscriptionsRecycler { get; }

		public View SaveChangesButtonBottomMark { get; }

		public TextView SaveChangesButton { get; }

		public FrameLayout SaveChangesButtonContainer { get; }

		public Button BottomSaveChangesButton { get; }

		public View BottomSaveChangesButtonContainer { get; }

		public ScrollView ScrollView { get; }

		public BottomNavigationView BottomNavigationView { get; }

		public AppCompatCheckBox FemaleRadioButton { get; }

		public AppCompatCheckBox MaleRadioButton { get; }

		public TextView LogoutButton { get; }

		public TextView LogoutFromAllButton { get; }

		public View DeleteAccountLayout { get; }

		public TextView DeleteAccountText { get; }

		public TextView LegalLabel { get; }

		public Switch SubSwitchEReceipt { get; }

		public Switch SubSwitchPolls { get; }

		public Controls(View view, Activity activity)
		{
			_003Cview_003EP = view;
			DefaultLayout = _003Cview_003EP.RequireViewById<View>(2131296904);
			ProgressLayout = _003Cview_003EP.RequireViewById<View>(2131298079);
			ProgressTitle = _003Cview_003EP.RequireViewById<TextView>(2131298080);
			PersonalDataHeader = _003Cview_003EP.RequireViewById<TextView>(2131297867);
			ContactDataHeader = _003Cview_003EP.RequireViewById<TextView>(2131296835);
			GenderDataHeader = _003Cview_003EP.RequireViewById<TextView>(2131297232);
			FirstName = new TextFieldControls(_003Cview_003EP.RequireViewById<View>(2131297207));
			LastName = new TextFieldControls(_003Cview_003EP.RequireViewById<View>(2131298405));
			DateOfBirth = new TextFieldControls(_003Cview_003EP.RequireViewById<View>(2131297012));
			Phone = new TextFieldControls(_003Cview_003EP.RequireViewById<View>(2131297884));
			Email = new TextFieldControls(_003Cview_003EP.RequireViewById<View>(2131297054));
			EmailConfirmationSnack = _003Cview_003EP.RequireViewById<View>(2131297047);
			EmailConfirmationText = _003Cview_003EP.RequireViewById<TextView>(2131297048);
			SendMailAgainButton = _003Cview_003EP.RequireViewById<TextView>(2131298348);
			EmailConfirmationTimeoutText = _003Cview_003EP.RequireViewById<TextView>(2131297049);
			SubTitleEReceipt = _003Cview_003EP.RequireViewById<TextView>(2131298550);
			SubLayoutPolls = _003Cview_003EP.RequireViewById<View>(2131298547);
			SubTitlePolls = _003Cview_003EP.RequireViewById<TextView>(2131298551);
			MarketingSubscriptionsLayout = _003Cview_003EP.RequireViewById<View>(2131297524);
			MarketingSubscriptionsTitle = _003Cview_003EP.RequireViewById<TextView>(2131297527);
			MarketingSubscriptionsSubtitle = _003Cview_003EP.RequireViewById<TextView>(2131297526);
			MarketingSubscriptionsRecycler = _003Cview_003EP.RequireViewById<RecyclerView>(2131297525);
			SaveChangesButtonBottomMark = _003Cview_003EP.RequireViewById<View>(2131298286);
			SaveChangesButton = _003Cview_003EP.RequireViewById<TextView>(2131298288);
			SaveChangesButtonContainer = _003Cview_003EP.RequireViewById<FrameLayout>(2131298289);
			BottomSaveChangesButton = _003Cview_003EP.RequireViewById<Button>(2131296566);
			BottomSaveChangesButtonContainer = _003Cview_003EP.RequireViewById<View>(2131296567);
			ScrollView = _003Cview_003EP.RequireViewById<ScrollView>(2131298301);
			BottomNavigationView = activity.RequireViewById<BottomNavigationView>(2131296565);
			FemaleRadioButton = _003Cview_003EP.RequireViewById<AppCompatCheckBox>(2131297230);
			MaleRadioButton = _003Cview_003EP.RequireViewById<AppCompatCheckBox>(2131297233);
			LogoutButton = _003Cview_003EP.RequireViewById<TextView>(2131297484);
			LogoutFromAllButton = _003Cview_003EP.RequireViewById<TextView>(2131297485);
			DeleteAccountLayout = _003Cview_003EP.RequireViewById<View>(2131296925);
			DeleteAccountText = _003Cview_003EP.RequireViewById<TextView>(2131296926);
			LegalLabel = _003Cview_003EP.RequireViewById<TextView>(2131297433);
			SubSwitchEReceipt = _003Cview_003EP.RequireViewById<Switch>(2131298548);
			SubSwitchPolls = _003Cview_003EP.RequireViewById<Switch>(2131298549);
			base._002Ector();
		}
	}

	private const int DobSelectionDialogRequestCode = 897481;

	private int _previousSystemWindowYInsetSum;

	private Controls? _controls;

	protected override int LayoutId => 2131493119;

	protected override bool NeedToAdjustScreenToKeyboardMoves => true;

	protected override bool HasNavigationButton()
	{
		return true;
	}

	public UserDataFragment(Func<AndroidX.Fragment.App.Fragment, UserDataViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.OnNavigateToInfoPageCommand.SafeSubscribe(OnNavigateToInfoPage, this);
		base.ViewModel.OnChangesSavedCommand.SafeSubscribe(OnChangesSaved, this);
		base.ViewModel.OnDateOfBirthChangeCommand.SafeSubscribe(OnDateOfBirthClicked, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Controls controls = new Controls(view, RequireActivity());
		_controls = controls;
		VisibilitySwitch<VisualState> visibilitySwitch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			{
				VisualState.Default,
				controls.DefaultLayout
			},
			{
				VisualState.InProgress,
				controls.ProgressLayout
			}
		};
		controls.FirstName.EditText.InputType = InputTypes.TextVariationPersonName | InputTypes.NumberFlagDecimal;
		controls.LastName.EditText.InputType = InputTypes.TextVariationPersonName | InputTypes.NumberFlagDecimal;
		controls.DateOfBirth.View.Alpha = 0.5f;
		controls.DateOfBirth.EditText.InputType = InputTypes.DatetimeVariationDate;
		controls.DateOfBirth.EditText.Focusable = false;
		controls.Phone.View.Alpha = 0.5f;
		controls.Phone.EditText.InputType = InputTypes.ClassPhone;
		controls.Phone.EditText.Enabled = false;
		controls.LogoutButton.Text = base.ViewModel.LogoutButtonText;
		controls.LogoutFromAllButton.Text = base.ViewModel.LogoutFromAnotherButtonText;
		controls.DeleteAccountText.Text = base.ViewModel.DeleteProfileButtonText;
		base.ToolbarTitle = base.ViewModel.ScreenTitle;
		controls.ProgressTitle.Text = base.ViewModel.ProgressTitle;
		controls.PersonalDataHeader.Text = base.ViewModel.PersonalDataHeader;
		controls.ContactDataHeader.Text = base.ViewModel.ContactDataHeader;
		controls.GenderDataHeader.Text = base.ViewModel.GenderDataHeader;
		controls.FirstName.InputLayout.Hint = base.ViewModel.FirstNamePlaceholder;
		controls.LastName.InputLayout.Hint = base.ViewModel.LastNamePlaceholder;
		controls.DateOfBirth.InputLayout.Hint = base.ViewModel.BirthDatePlaceholder;
		controls.MaleRadioButton.Text = base.ViewModel.MaleGender;
		controls.FemaleRadioButton.Text = base.ViewModel.FemaleGender;
		controls.Phone.InputLayout.Hint = base.ViewModel.PhonePlaceholder;
		IInputFilter[] filters = new IInputFilter[1]
		{
			new InputFilterLengthFilter(25)
		};
		controls.FirstName.EditText.SetFilters(filters);
		controls.LastName.EditText.SetFilters(filters);
		controls.SubTitleEReceipt.Text = base.ViewModel.EReceiptSubscriptionTitle;
		controls.SubTitlePolls.Text = base.ViewModel.PollsSubscriptionTitle;
		controls.MarketingSubscriptionsTitle.Text = base.ViewModel.MarketingSubscriptionsTitle;
		controls.MarketingSubscriptionsSubtitle.Text = base.ViewModel.MarketingSubscriptionsSubtitle;
		ObservableRecyclerAdapter<SubscriptionItemViewModel, CachingViewHolder> marketingSubscriptionsAdapter = new ObservableRecyclerAdapter<SubscriptionItemViewModel, CachingViewHolder>
		{
			CreateViewHolderDelegate = CreateViewHolderDelegate,
			GetItemViewTypeDelegate = GetItemViewTypeDelegate,
			BindViewHolderDelegate = OnBindMarketingSubscription
		};
		controls.MarketingSubscriptionsRecycler.SetAdapter(marketingSubscriptionsAdapter);
		controls.Email.EditText.InputType = InputTypes.DatetimeVariationTime;
		controls.LegalLabel.Text = base.ViewModel.PersonalDataAgreementText;
		TextViewExtensions.AddLinkedText(highlightColor: new Color(ContextCompat.GetColor(Context, 2131100611)), textView: controls.LegalLabel, linkedText: base.ViewModel.PersonalDataAgreementLinkedText, underlineLinks: true);
		controls.Phone.EditText.Enabled = false;
		controls.Phone.EditText.InstallMaskedListener(base.ViewModel.PhoneMask, new ValueListener(OnPhoneChanged));
		controls.SaveChangesButton.Text = base.ViewModel.SaveButtonText;
		controls.BottomSaveChangesButton.Text = base.ViewModel.SaveButtonText;
		controls.Email.WarningButton.SetImageResource(2131231412);
		controls.EmailConfirmationText.Text = base.ViewModel.EmailConfirmationText;
		controls.SendMailAgainButton.Text = base.ViewModel.SendMailAgainButtonText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[27]
		{
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				SetTextFieldError(controls.FirstName, base.ViewModel.FirstNameError);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("FirstNameError")),
			(delegate
			{
				SetTextFieldError(controls.LastName, base.ViewModel.LastNameError);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("LastNameError")),
			(delegate
			{
				controls.EmailConfirmationSnack.Visibility = base.ViewModel.IsEmailConfirmationNoteVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsEmailConfirmationNoteVisible")),
			(delegate
			{
				controls.SendMailAgainButton.Visibility = base.ViewModel.IsCanSendConfirmationMailAgain.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCanSendConfirmationMailAgain")),
			(delegate
			{
				controls.EmailConfirmationTimeoutText.Text = base.ViewModel.EmailConfirmationTimeoutText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EmailConfirmationTimeoutText")),
			(delegate
			{
				controls.EmailConfirmationTimeoutText.Visibility = base.ViewModel.IsEmailConfirmationTimeoutVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsEmailConfirmationTimeoutVisible")),
			(delegate
			{
				controls.Email.EditText.ApplyText(base.ViewModel.Email);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Email")),
			(delegate
			{
				SetSaveFloatingButtonVisible(controls, base.ViewModel.IsSaveButtonVisible);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSaveButtonVisible")),
			(delegate
			{
				controls.FirstName.EditText.ApplyText(base.ViewModel.FirstName);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("FirstName")),
			(delegate
			{
				controls.LastName.EditText.ApplyText(base.ViewModel.LastName);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("LastName")),
			(delegate
			{
				controls.DateOfBirth.EditText.Text = base.ViewModel.DateOfBirthText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DateOfBirthText")),
			(delegate
			{
				controls.MaleRadioButton.Checked = base.ViewModel.IsMaleGender;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsMaleGender")),
			(delegate
			{
				controls.FemaleRadioButton.Checked = base.ViewModel.IsFemaleGender;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsFemaleGender")),
			(delegate
			{
				controls.Phone.EditText.Text = base.ViewModel.PhoneNumber;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PhoneNumber")),
			(delegate
			{
				controls.MarketingSubscriptionsLayout.Visibility = base.ViewModel.HasMarketingSubscriptions.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasMarketingSubscriptions")),
			(delegate
			{
				marketingSubscriptionsAdapter.DataSource = base.ViewModel.MarketingSubscriptions;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("MarketingSubscriptions")),
			(delegate
			{
				controls.SubSwitchEReceipt.Checked = base.ViewModel.EReceiptSubscriptionEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EReceiptSubscriptionEnabled")),
			(delegate
			{
				controls.SubLayoutPolls.Visibility = base.ViewModel.HasPollsSubscription.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasPollsSubscription")),
			(delegate
			{
				controls.SubSwitchPolls.Checked = base.ViewModel.PollsSubscriptionEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PollsSubscriptionEnabled")),
			(delegate
			{
				controls.Email.InputLayout.Hint = base.ViewModel.EmailPlaceholder;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EmailPlaceholder")),
			(delegate
			{
				controls.SaveChangesButtonContainer.Visibility = base.ViewModel.IsSaveButtonVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSaveButtonVisible")),
			(delegate
			{
				controls.FirstName.ClearButton.Visibility = (!string.IsNullOrEmpty(controls.FirstName.EditText.Text) && controls.FirstName.EditText.IsFocused).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "Text", "IsFocused" })),
			(delegate
			{
				controls.LastName.ClearButton.Visibility = (!string.IsNullOrEmpty(controls.LastName.EditText.Text) && controls.LastName.EditText.IsFocused).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "Text", "IsFocused" })),
			(delegate
			{
				controls.SaveChangesButton.Enabled = base.ViewModel.IsSaveButtonEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSaveButtonEnabled")),
			(delegate
			{
				controls.BottomSaveChangesButton.Enabled = base.ViewModel.IsSaveButtonEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSaveButtonEnabled")),
			(delegate
			{
				controls.DateOfBirth.EditText.Enabled = base.ViewModel.IsDateOfBirthEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsDateOfBirthEnabled"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((View)controls.Email.ClearButton).OnClick((Action)delegate
		{
			controls.Email.EditText.Text = string.Empty;
		}), ((View)controls.SendMailAgainButton).OnClick((Action)delegate
		{
			base.ViewModel.SendMailAgain().SafeFireAndForget((Action<Exception>)null, false);
		}), ((View)controls.SaveChangesButton).OnClick((Action)delegate
		{
			base.ViewModel.SaveChanges().SafeFireAndForget((Action<Exception>)null, false);
		}), ((View)controls.BottomSaveChangesButton).OnClick((Action)delegate
		{
			base.ViewModel.SaveChanges().SafeFireAndForget((Action<Exception>)null, false);
		}), controls.LogoutButton.OnClick(base.ViewModel.OnLogoutClick), controls.LogoutFromAllButton.OnClick(base.ViewModel.OnLogoutFromAllClick), controls.DeleteAccountLayout.OnClick(base.ViewModel.OnDeleteClick), controls.DateOfBirth.EditText.OnClick(base.ViewModel.TapOnDate), ((View)controls.FirstName.ClearButton).OnClick((Action)delegate
		{
			controls.FirstName.EditText.Text = string.Empty;
		}), ((View)controls.LastName.ClearButton).OnClick((Action)delegate
		{
			controls.LastName.EditText.Text = string.Empty;
		}), controls.ScrollView.ViewTreeObserver.OnScrollChange((EventHandler)delegate
		{
			SetSaveFloatingButtonVisible(controls, base.ViewModel.IsSaveButtonVisible);
		}), ((View)controls.FemaleRadioButton).OnClick((EventHandler)delegate
		{
			controls.FemaleRadioButton.Checked = true;
			controls.MaleRadioButton.Checked = false;
			base.ViewModel.OnFemaleTap();
		}), ((View)controls.MaleRadioButton).OnClick((EventHandler)delegate
		{
			controls.MaleRadioButton.Checked = true;
			controls.FemaleRadioButton.Checked = false;
			base.ViewModel.OnMaleTap();
		}), controls.Phone.EditText.OnFocusChange(delegate(object? o, View.FocusChangeEventArgs e)
		{
			if (e.HasFocus && controls.Phone.EditText.Enabled)
			{
				controls.Phone.EditText.Text = string.Empty;
			}
		}), ((View)controls.SubSwitchEReceipt).OnClick((EventHandler)delegate
		{
			base.ViewModel.EReceiptCommand.Trigger(controls.SubSwitchEReceipt.Checked);
		}), ((View)controls.SubSwitchPolls).OnClick((EventHandler)delegate
		{
			base.ViewModel.PollsCommand.Trigger(controls.SubSwitchPolls.Checked);
		}), ((TextView)controls.FirstName.EditText).OnTextChanged((Action)delegate
		{
			base.ViewModel.FirstName = controls.FirstName.EditText.Text ?? string.Empty;
		}), ((TextView)controls.LastName.EditText).OnTextChanged((Action)delegate
		{
			base.ViewModel.LastName = controls.LastName.EditText.Text ?? string.Empty;
		}), ((TextView)controls.Email.EditText).OnTextChanged((Action)delegate
		{
			base.ViewModel.NewEmail = controls.Email.EditText.Text ?? string.Empty;
		}), ((View)controls.FirstName.EditText).OnFocusChange((EventHandler<View.FocusChangeEventArgs>)delegate
		{
			controls.FirstName.ClearButton.Visibility = (!string.IsNullOrEmpty(controls.FirstName.EditText.Text) && controls.FirstName.EditText.IsFocused).ToVisibility();
		}), ((View)controls.LastName.EditText).OnFocusChange((EventHandler<View.FocusChangeEventArgs>)delegate
		{
			controls.LastName.ClearButton.Visibility = (!string.IsNullOrEmpty(controls.LastName.EditText.Text) && controls.LastName.EditText.IsFocused).ToVisibility();
		}), ((View)controls.Email.EditText).OnFocusChange((EventHandler<View.FocusChangeEventArgs>)delegate
		{
			SetTextFieldError(controls.Email, controls.Email.EditText.HasFocus ? null : base.ViewModel.EmailValidationError);
			if (controls.Email.WarningButton.Visibility == ViewStates.Gone)
			{
				controls.Email.ClearButton.Visibility = (!string.IsNullOrEmpty(controls.Email.EditText.Text) && controls.Email.EditText.IsFocused).ToVisibility();
			}
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.NavigateToNotificationSettingsCommand.SafeSubscribe(delegate
		{
			GoToSettings();
		}, ViewLifecycleOwner);
		if (OperatingSystem.IsAndroidVersionAtLeast(23))
		{
			_previousSystemWindowYInsetSum = View.RootWindowInsets.SystemWindowInsetTop + View.RootWindowInsets.SystemWindowInsetBottom;
			View.ViewTreeObserver.OnGlobalLayout((EventHandler)delegate
			{
				ToggleBottomNavViewVisibilityIfNeeded(controls).SafeFireAndForget((Action<Exception>)null, false);
			}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		}
	}

	private CachingViewHolder CreateViewHolderDelegate(ViewGroup recyclerView, int cellLayoutId)
	{
		return new CachingViewHolder(base.LayoutInflater.Inflate(cellLayoutId, recyclerView, attachToRoot: false));
	}

	private int GetItemViewTypeDelegate(int position)
	{
		return 2131493352;
	}

	private void OnBindMarketingSubscription(CachingViewHolder viewHolder, SubscriptionItemViewModel item, int position, CompositeDisposable disposable)
	{
		TextView? textView = viewHolder.FindCachedView<TextView>(2131298092);
		Switch subSwitch = viewHolder.FindCachedView<Switch>(2131298090);
		textView.Text = item.SubscriptionTitle;
		subSwitch.Checked = item.Enabled;
		item.BindEvents(((View)subSwitch).OnClick((Action)delegate
		{
			base.ViewModel.OnSwitchMarketingSubscription(item, subSwitch.Checked);
		})).AddTo(disposable);
	}

	private void GoToSettings()
	{
		Intent intent = new Intent("android.settings.APP_NOTIFICATION_SETTINGS");
		intent.AddFlags(ActivityFlags.NewTask);
		intent.PutExtra("android.provider.extra.APP_PACKAGE", Context.PackageName);
		intent.PutExtra("android.provider.extra.CHANNEL_ID", Context.ApplicationInfo.Uid);
		StartActivity(intent);
	}

	private void SetSaveFloatingButtonVisible(Controls controls, bool visible)
	{
		controls.BottomSaveChangesButtonContainer.Visibility = (IsSaveFloatingButtonAboveSaveButton(controls) && visible).ToVisibility();
	}

	private bool IsSaveFloatingButtonAboveSaveButton(Controls controls, int deviation = 20)
	{
		int num = Converter.DpToPx(deviation);
		int top = controls.SaveChangesButtonBottomMark.Top;
		int num2 = controls.ScrollView.ScrollY + controls.ScrollView.Height;
		if (top == 0)
		{
			return false;
		}
		return top + num > num2;
	}

	public override void OnDestroyView()
	{
		base.OnDestroyView();
		if (_controls != null)
		{
			_controls.BottomNavigationView.Visibility = ViewStates.Visible;
		}
	}

	private void SetTextFieldError(TextFieldControls controls, string? errorText)
	{
		bool flag = errorText != null;
		ColorStateList colorStateList = ColorStateList.ValueOf(new Color(ContextCompat.GetColor(Context, 2131100568)));
		controls.ErrorMessage.Text = errorText;
		controls.ErrorMessage.Visibility = flag.ToVisibility();
		controls.ErrorMessage.SetTextColor(colorStateList);
		controls.WarningButton.Visibility = flag.ToVisibility();
		controls.WarningButton.ImageTintList = colorStateList;
		controls.ClearButton.Visibility = (!flag).ToVisibility();
		controls.InputLayout.DefaultHintTextColor = ColorStateList.ValueOf(new Color(ContextCompat.GetColor(Context, flag ? 2131100568 : 2131099703)));
		controls.SetEndIconVisibility(flag ? TextFieldControls.EndIconVisibility.Warning : TextFieldControls.EndIconVisibility.Clear);
		controls.View.RequestLayout();
	}

	private void OnPhoneChanged(bool maskFilled, string extractedValue, string formattedValue)
	{
		base.ViewModel.SetPhoneNumber(extractedValue);
		base.ViewModel.EnterFormattedPhone(formattedValue, maskFilled);
	}

	private void OnNavigateToInfoPage(InfoPageViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<InfoPageFragment>(this, parameter.ToNavBundle(), 123)
			.AddToBackStack(null)
			.Commit();
	}

	[SupportedOSPlatform("android23.0")]
	private async Task ToggleBottomNavViewVisibilityIfNeeded(Controls controls)
	{
		if (View != null)
		{
			int currentSystemWindowYInsetSum = View.RootWindowInsets.SystemWindowInsetTop + View.RootWindowInsets.SystemWindowInsetBottom;
			bool flag = controls.BottomNavigationView.Visibility == ViewStates.Visible;
			if (currentSystemWindowYInsetSum > _previousSystemWindowYInsetSum && flag)
			{
				controls.BottomNavigationView.Visibility = ViewStates.Gone;
				_previousSystemWindowYInsetSum = currentSystemWindowYInsetSum;
			}
			else if (currentSystemWindowYInsetSum < _previousSystemWindowYInsetSum && !flag)
			{
				await Task.Delay(10);
				controls.BottomNavigationView.Visibility = ViewStates.Visible;
				_previousSystemWindowYInsetSum = currentSystemWindowYInsetSum;
			}
		}
	}

	private void OnDateOfBirthClicked(DateOfBirthSelectionViewModel.Parameter parameter)
	{
		DateOfBirthSelectionFragment dateOfBirthSelectionFragment = base.ParentFragmentManager.FragmentFactory.Instantiate<DateOfBirthSelectionFragment>();
		dateOfBirthSelectionFragment.SetTargetFragment(this, 897481);
		dateOfBirthSelectionFragment.Arguments = parameter.ToNavBundle();
		base.ParentFragmentManager.BeginTransaction().Add(2131297216, dateOfBirthSelectionFragment).AddToBackStack(null)
			.CommitAllowingStateLoss();
	}

	private void OnChangesSaved(Unit _)
	{
		base.Activity.HideKeyboard();
	}

	public void OnResult(int requestCode, DateTime value)
	{
		if (requestCode == 897481 && value != DateTime.MinValue)
		{
			base.ViewModel.OnDateOfBirthSelected(value);
		}
	}
}
