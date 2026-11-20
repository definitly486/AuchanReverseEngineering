using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics.Loymax;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.InfoPages;
using Auchan.Common.Navigation;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Authorization;
using Auchan.Common.PersonalCabinet.DomainModels;
using Auchan.Common.PersonalCabinet.Errors;
using Auchan.Common.PersonalCabinet.Interactors;
using Auchan.Common.Profile.DateOfBirthSelection;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Storage;

namespace Auchan.Common.Profile;

[RequiresAuthorization]
public sealed class UserDataViewModel : ScreenViewModel
{
	private const string EMAIL_RESEND_DUE_TIME = "CD780355-9043-414A-85FF-86B5707C895E";

	private readonly IUserContext _userContext;

	private readonly LogoutInteractor _logoutInteractor;

	private readonly ProfileInteractor _profileInteractor;

	private readonly IInfoMessageService _infoMessageService;

	private readonly IRestartService _restartService;

	private readonly IUserAccountDeletionService _userAccountDeletionService;

	private readonly SubscriptionsService _subscriptionsService;

	private readonly SubscriptionUpdateUseCase _subscriptionUpdateUseCase;

	private readonly IDeviceService _deviceService;

	private readonly LoymaxPushTokenService _loymaxPushTokenService;

	private readonly Subject<Unit> _onLogoutClick = new Subject<Unit>();

	private readonly Subject<Unit> _onLogoutFromAllClick = new Subject<Unit>();

	private readonly Subject<Unit> _onDeleteClick = new Subject<Unit>();

	private readonly Subject<DateOfBirthSelectionViewModel.Parameter> _onDataOfBirthChange = new Subject<DateOfBirthSelectionViewModel.Parameter>();

	private readonly Subject<Unit> _onChangesSaved = new Subject<Unit>();

	private readonly Subject<(SubscriptionItemViewModel item, bool isSubscribed)> _onMarketingSubscriptionChanged = new Subject<(SubscriptionItemViewModel, bool)>();

	private readonly List<SubscriptionCommunicationModel> _subscriptionCommunicationModels = new List<SubscriptionCommunicationModel>();

	private readonly AsyncValidator<bool> _firstNameValidator;

	private readonly AsyncValidator<bool> _lastNameValidator;

	private readonly AsyncValidator<bool> _emailValidator;

	private readonly System.Timers.Timer _mailResendTimeoutTimer = new System.Timers.Timer(TimeSpan.FromSeconds(1L))
	{
		AutoReset = false
	};

	private string? _firstNameInitial;

	private string? _lastNameInitial;

	private string? _emailInitial;

	private bool _isEmailConfirmed;

	private string? _phoneInitial;

	private bool _isEmailConfirmationNoteVisible;

	[CompilerGenerated]
	private string _003CEmailConfirmationTimeoutText_003Ek__BackingField;

	[CompilerGenerated]
	private DateTime _003CMailResendDueTime_003Ek__BackingField;

	private const string NAME_ERROR = "Удалите пробелы, цифры, символы";

	[CompilerGenerated]
	private string _003CFirstName_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsValidFirstName_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CLastName_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsValidLastName_003Ek__BackingField;

	[CompilerGenerated]
	private DateTime? _003CDateOfBirth_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsDateOfBirthEnabled_003Ek__BackingField;

	[CompilerGenerated]
	private Gender _003CGender_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CPhoneNumber_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CEmail_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CNewEmail_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsCanSendConfirmationMailAgain_003Ek__BackingField;

	[CompilerGenerated]
	private LinkedText _003CPersonalDataAgreementLinkedText_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CNewPhoneEntered_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsEmailValid_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CHasMarketingSubscriptions_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CEReceiptSubscriptionEnabled_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CPollsSubscriptionEnabled_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CHasPollsSubscription_003Ek__BackingField;

	public string ScreenTitle => "Мои данные";

	public string ProgressTitle => "Загружаем ваш профиль…";

	public string DateOfBirdthHint => "Регистрация возможна для пользователей старше 18 лет";

	public string PersonalDataHeader => "Персональная информация";

	public string GenderDataHeader => "Пол";

	public string ContactDataHeader => "Контакты";

	public string FirstNamePlaceholder => "Имя";

	public string LastNamePlaceholder => "Фамилия";

	public string BirthDatePlaceholder => "Дата рождения";

	public string PhonePlaceholder => "Телефон";

	public string EmailPlaceholder
	{
		get
		{
			if (!(NewEmail == string.Empty))
			{
				return "E-mail";
			}
			return "Укажите ваш e-mail";
		}
	}

	public string EmailConfirmationText => "На\u00a0ваш\u00a0e-mail отправлено письмо. Перейдите по ссылке, чтобы подтвердить адрес и получать электронные чеки.";

	public string SendMailAgainButtonText => "Отправить письмо ещё раз";

	public string EmailConfirmationTimeoutText
	{
		[CompilerGenerated]
		get
		{
			return _003CEmailConfirmationTimeoutText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CEmailConfirmationTimeoutText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CEmailConfirmationTimeoutText_003Ek__BackingField = value;
				RaisePropertyChanged("EmailConfirmationTimeoutText");
			}
		}
	} = "";

	private DateTime MailResendDueTime
	{
		[CompilerGenerated]
		get
		{
			return _003CMailResendDueTime_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!DateTime.Equals(_003CMailResendDueTime_003Ek__BackingField, value))
			{
				_003CMailResendDueTime_003Ek__BackingField = value;
				RaisePropertyChanged("IsEmailConfirmationTimeoutVisible");
				RaisePropertyChanged("MailResendDueTime");
			}
		}
	} = Preferences.Get("CD780355-9043-414A-85FF-86B5707C895E", DateTime.MinValue, "UserContextPreferences");

	public string MaleGender => "Мужской";

	public string FemaleGender => "Женский";

	public string PersonalDataAgreementText => "Изменяя и сохраняя данные в Личном Кабинете, вы даете согласие на обработку персональных данных, предоставление данных Сервисам аналитики, согласие с Политикой конфиденциальности и подтверждаете свое совершеннолетие.";

	public string LogoutButtonText => "Выйти из аккаунта";

	public string LogoutFromAnotherButtonText => "Выйти на других устройствах";

	public string DeleteProfileButtonText => "Удалить аккаунт";

	public string CancelButtonText => "Отмена";

	public string SaveButtonText => "Сохранить";

	public string FirstName
	{
		[CompilerGenerated]
		get
		{
			return _003CFirstName_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CFirstName_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CFirstName_003Ek__BackingField = value;
				RaisePropertyChanged("FirstNameError");
				RaisePropertyChanged("IsProfileChanged");
				RaisePropertyChanged("IsSaveButtonVisible");
				RaisePropertyChanged("IsSaveButtonEnabled");
				RaisePropertyChanged("IsProfileValid");
				OnFirstNameChanged();
				RaisePropertyChanged("FirstName");
			}
		}
	} = string.Empty;

	public bool IsValidFirstName
	{
		[CompilerGenerated]
		get
		{
			return _003CIsValidFirstName_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsValidFirstName_003Ek__BackingField != value)
			{
				_003CIsValidFirstName_003Ek__BackingField = value;
				RaisePropertyChanged("FirstNameError");
				RaisePropertyChanged("IsProfileValid");
				RaisePropertyChanged("IsSaveButtonEnabled");
				RaisePropertyChanged("IsValidFirstName");
			}
		}
	} = true;

	public string? FirstNameError
	{
		get
		{
			if (string.IsNullOrEmpty(FirstName) || IsValidFirstName)
			{
				return null;
			}
			return "Удалите пробелы, цифры, символы";
		}
	}

	public string LastName
	{
		[CompilerGenerated]
		get
		{
			return _003CLastName_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CLastName_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CLastName_003Ek__BackingField = value;
				RaisePropertyChanged("IsProfileChanged");
				RaisePropertyChanged("IsSaveButtonVisible");
				RaisePropertyChanged("IsSaveButtonEnabled");
				OnLastNameChanged();
				RaisePropertyChanged("LastName");
			}
		}
	} = string.Empty;

	public bool IsValidLastName
	{
		[CompilerGenerated]
		get
		{
			return _003CIsValidLastName_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsValidLastName_003Ek__BackingField != value)
			{
				_003CIsValidLastName_003Ek__BackingField = value;
				RaisePropertyChanged("LastNameError");
				RaisePropertyChanged("IsProfileValid");
				RaisePropertyChanged("IsSaveButtonEnabled");
				RaisePropertyChanged("IsValidLastName");
			}
		}
	} = true;

	public string? LastNameError
	{
		get
		{
			if (IsValidLastName)
			{
				return null;
			}
			return "Удалите пробелы, цифры, символы";
		}
	}

	public DateTime MaxDateOfBirth => DateTime.UtcNow.Date.YearsAgo(18).AddDays(-1.0);

	public DateTime? DateOfBirth
	{
		[CompilerGenerated]
		get
		{
			return _003CDateOfBirth_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!Nullable.Equals(_003CDateOfBirth_003Ek__BackingField, value))
			{
				_003CDateOfBirth_003Ek__BackingField = value;
				RaisePropertyChanged("DateOfBirthText");
				RaisePropertyChanged("IsProfileChanged");
				RaisePropertyChanged("IsSaveButtonVisible");
				RaisePropertyChanged("IsSaveButtonEnabled");
				RaisePropertyChanged("DateOfBirth");
			}
		}
	}

	public bool IsDateOfBirthEnabled
	{
		[CompilerGenerated]
		get
		{
			return _003CIsDateOfBirthEnabled_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsDateOfBirthEnabled_003Ek__BackingField != value)
			{
				_003CIsDateOfBirthEnabled_003Ek__BackingField = value;
				RaisePropertyChanged("IsDateOfBirthEnabled");
			}
		}
	} = true;

	public string DateOfBirthText => DateOfBirth?.ToShortDate() ?? string.Empty;

	public Gender Gender
	{
		[CompilerGenerated]
		get
		{
			return _003CGender_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CGender_003Ek__BackingField != value)
			{
				_003CGender_003Ek__BackingField = value;
				RaisePropertyChanged("IsMaleGender");
				RaisePropertyChanged("IsFemaleGender");
				RaisePropertyChanged("IsProfileChanged");
				RaisePropertyChanged("IsSaveButtonVisible");
				RaisePropertyChanged("IsSaveButtonEnabled");
				RaisePropertyChanged("Gender");
			}
		}
	}

	public bool IsMaleGender => Gender == Gender.Male;

	public bool IsFemaleGender => Gender == Gender.Female;

	public string? PhoneNumber
	{
		[CompilerGenerated]
		get
		{
			return _003CPhoneNumber_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CPhoneNumber_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CPhoneNumber_003Ek__BackingField = value;
				RaisePropertyChanged("PhoneNumber");
			}
		}
	}

	public string Email
	{
		[CompilerGenerated]
		get
		{
			return _003CEmail_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CEmail_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CEmail_003Ek__BackingField = value;
				RaisePropertyChanged("IsEmailConfirmationNoteVisible");
				RaisePropertyChanged("Email");
			}
		}
	} = string.Empty;

	public string NewEmail
	{
		[CompilerGenerated]
		get
		{
			return _003CNewEmail_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CNewEmail_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CNewEmail_003Ek__BackingField = value;
				RaisePropertyChanged("EmailPlaceholder");
				RaisePropertyChanged("IsEmailConfirmationNoteVisible");
				RaisePropertyChanged("IsEmailChanged");
				RaisePropertyChanged("IsProfileChanged");
				RaisePropertyChanged("IsSaveButtonVisible");
				RaisePropertyChanged("IsSaveButtonEnabled");
				OnNewEmailChanged();
				RaisePropertyChanged("NewEmail");
			}
		}
	} = string.Empty;

	public bool IsEmailConfirmationNoteVisible
	{
		get
		{
			if (_isEmailConfirmationNoteVisible)
			{
				return string.Equals(NewEmail, Email, StringComparison.Ordinal);
			}
			return false;
		}
		set
		{
			if (_isEmailConfirmationNoteVisible != value)
			{
				_isEmailConfirmationNoteVisible = value;
				RaisePropertyChanged("IsEmailConfirmationNoteVisible");
			}
		}
	}

	public bool IsCanSendConfirmationMailAgain
	{
		[CompilerGenerated]
		get
		{
			return _003CIsCanSendConfirmationMailAgain_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsCanSendConfirmationMailAgain_003Ek__BackingField != value)
			{
				_003CIsCanSendConfirmationMailAgain_003Ek__BackingField = value;
				RaisePropertyChanged("IsCanSendConfirmationMailAgain");
			}
		}
	}

	public bool IsEmailConfirmationTimeoutVisible => MailResendDueTime > DateTime.UtcNow;

	public LinkedText PersonalDataAgreementLinkedText
	{
		[CompilerGenerated]
		get
		{
			return _003CPersonalDataAgreementLinkedText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CPersonalDataAgreementLinkedText_003Ek__BackingField, value))
			{
				_003CPersonalDataAgreementLinkedText_003Ek__BackingField = value;
				RaisePropertyChanged("PersonalDataAgreementLinkedText");
			}
		}
	}

	public string PhoneMask => "+7 ([000]) [000]-[00]-[00]";

	public bool NewPhoneEntered
	{
		[CompilerGenerated]
		get
		{
			return _003CNewPhoneEntered_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CNewPhoneEntered_003Ek__BackingField != value)
			{
				_003CNewPhoneEntered_003Ek__BackingField = value;
				RaisePropertyChanged("NewPhoneEntered");
			}
		}
	}

	public UICommand<InfoPageViewModel.Parameter, InfoType> OnNavigateToInfoPageCommand { get; } = new UICommand<InfoPageViewModel.Parameter, InfoType>((InfoType value) => new InfoPageViewModel.Parameter(value));

	public UICommand<DateOfBirthSelectionViewModel.Parameter> OnDateOfBirthChangeCommand { get; } = new UICommand<DateOfBirthSelectionViewModel.Parameter>();

	public UICommand OnChangesSavedCommand { get; } = new UICommand();

	public UICommand BeforeRestartAppCommand { get; } = new UICommand();

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.InProgress;

	public bool IsSaveButtonVisible => IsProfileChanged;

	public bool IsSaveButtonEnabled
	{
		get
		{
			if (IsProfileChanged && !IsProfileValid)
			{
				return false;
			}
			return IsSaveButtonVisible;
		}
	}

	private bool IsProfileChanged
	{
		get
		{
			if (!(FirstName != _firstNameInitial) && !(LastName != _lastNameInitial))
			{
				DateTime? dateOfBirth = DateOfBirth;
				DateTime? dateTime = _userContext.Profile?.Birthday;
				if (dateOfBirth.HasValue == dateTime.HasValue && (!dateOfBirth.HasValue || !(dateOfBirth.GetValueOrDefault() != dateTime.GetValueOrDefault())) && Gender == _userContext.Profile?.Gender)
				{
					return IsEmailChanged;
				}
			}
			return true;
		}
	}

	private bool IsProfileValid
	{
		get
		{
			if (!string.IsNullOrEmpty(FirstName) && IsValidFirstName && IsValidLastName)
			{
				return IsEmailValid;
			}
			return false;
		}
	}

	private bool IsEmailChanged => NewEmail != _emailInitial;

	public bool IsEmailValid
	{
		[CompilerGenerated]
		get
		{
			return _003CIsEmailValid_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsEmailValid_003Ek__BackingField != value)
			{
				_003CIsEmailValid_003Ek__BackingField = value;
				RaisePropertyChanged("IsProfileValid");
				RaisePropertyChanged("IsSaveButtonEnabled");
				RaisePropertyChanged("EmailValidationError");
				RaisePropertyChanged("IsEmailValid");
			}
		}
	} = true;

	public string? EmailValidationError
	{
		get
		{
			if (!IsEmailValid)
			{
				return "Не используйте кириллицу, пробелы и спецсимволы";
			}
			return null;
		}
	}

	public string MarketingSubscriptionsTitle => "Рекламные рассылки";

	public string MarketingSubscriptionsSubtitle => "Получайте актуальную информацию об акциях, скидках и персональных предложениях";

	public bool HasMarketingSubscriptions
	{
		[CompilerGenerated]
		get
		{
			return _003CHasMarketingSubscriptions_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CHasMarketingSubscriptions_003Ek__BackingField != value)
			{
				_003CHasMarketingSubscriptions_003Ek__BackingField = value;
				RaisePropertyChanged("HasMarketingSubscriptions");
			}
		}
	}

	public ObservableRangeCollection<SubscriptionItemViewModel> MarketingSubscriptions { get; } = new ObservableRangeCollection<SubscriptionItemViewModel>();

	public UICommand NavigateToNotificationSettingsCommand { get; } = new UICommand();

	public string EReceiptSubscriptionTitle => "Получать электронные чеки";

	public string PollsSubscriptionTitle => "Участвовать в опросах";

	public bool EReceiptSubscriptionEnabled
	{
		[CompilerGenerated]
		get
		{
			return _003CEReceiptSubscriptionEnabled_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CEReceiptSubscriptionEnabled_003Ek__BackingField != value)
			{
				_003CEReceiptSubscriptionEnabled_003Ek__BackingField = value;
				RaisePropertyChanged("EReceiptSubscriptionEnabled");
			}
		}
	}

	public bool PollsSubscriptionEnabled
	{
		[CompilerGenerated]
		get
		{
			return _003CPollsSubscriptionEnabled_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CPollsSubscriptionEnabled_003Ek__BackingField != value)
			{
				_003CPollsSubscriptionEnabled_003Ek__BackingField = value;
				RaisePropertyChanged("PollsSubscriptionEnabled");
			}
		}
	}

	public bool HasPollsSubscription
	{
		[CompilerGenerated]
		get
		{
			return _003CHasPollsSubscription_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CHasPollsSubscription_003Ek__BackingField != value)
			{
				_003CHasPollsSubscription_003Ek__BackingField = value;
				RaisePropertyChanged("HasPollsSubscription");
			}
		}
	}

	public UICommand<object> EReceiptCommand { get; } = new UICommand<object>();

	public UICommand<object> PollsCommand { get; } = new UICommand<object>();

	public UserDataViewModel(IUserContext userContext, LogoutInteractor logoutInteractor, ProfileInteractor profileInteractor, IInfoMessageService infoMessageService, IRestartService restartService, IUserAccountDeletionService userAccountDeletionService, SubscriptionsService subscriptionsService, SubscriptionUpdateUseCase subscriptionUpdateUseCase, IDeviceService deviceService, LoymaxPushTokenService loymaxPushTokenService)
	{
		_userContext = userContext;
		_logoutInteractor = logoutInteractor;
		_profileInteractor = profileInteractor;
		_infoMessageService = infoMessageService;
		_restartService = restartService;
		_userAccountDeletionService = userAccountDeletionService;
		_subscriptionsService = subscriptionsService;
		_subscriptionUpdateUseCase = subscriptionUpdateUseCase;
		_deviceService = deviceService;
		_loymaxPushTokenService = loymaxPushTokenService;
		_firstNameValidator = new AsyncValidator<bool>((CancellationToken ct) => AuthValidationHelper.IsValidFirstNameAsync(FirstName, ct), delegate(bool v)
		{
			IsValidFirstName = v;
		}).AddTo(base.CloseDisposable);
		_lastNameValidator = new AsyncValidator<bool>(ValidateLastNameAsync, delegate(bool v)
		{
			IsValidLastName = v;
		}).AddTo(base.CloseDisposable);
		_emailValidator = new AsyncValidator<bool>(ValidateEmailAsync, delegate(bool v)
		{
			IsEmailValid = v;
		}).AddTo(base.CloseDisposable);
		PersonalDataAgreementLinkedText = new LinkedText("Изменяя и сохраняя данные в Личном Кабинете, вы даете согласие на обработку персональных данных, предоставление данных Сервисам аналитики, согласие с Политикой конфиденциальности и подтверждаете свое совершеннолетие.", new string[2] { "Сервисам аналитики", "Политикой конфиденциальности" }, new Action[2]
		{
			delegate
			{
				OnNavigateToInfoPageCommand.Trigger(InfoType.PersonalDataProcessingPolicy);
			},
			delegate
			{
				OnNavigateToInfoPageCommand.Trigger(InfoType.PrivacyPolicy);
			}
		});
		SetProfileInitialValues();
		EReceiptCommand.PerformDebouncingTask((object x) => OnEReceiptTap((bool)x)).Subscribe().AddTo(base.CloseDisposable);
		PollsCommand.PerformDebouncingTask((object x) => OnPollsTap((bool)x)).Subscribe().AddTo(base.CloseDisposable);
		_onMarketingSubscriptionChanged.Debounce(1000).PerformDebouncingTask<(SubscriptionItemViewModel, bool)>(((SubscriptionItemViewModel item, bool isSubscribed) data) => OnMarketingSubscriptionChanged(data.item, data.isSubscribed)).Subscribe()
			.AddTo(base.CloseDisposable);
		_onLogoutClick.PerformDebouncingTask(OnLogoutApproved).Subscribe().AddTo(base.CloseDisposable);
		_onLogoutFromAllClick.PerformDebouncingTask(OnLogoutFromOtherDevices).Subscribe().AddTo(base.CloseDisposable);
		_onDeleteClick.PerformDebouncingTask(OnDeleteAccount).Subscribe().AddTo(base.CloseDisposable);
		_mailResendTimeoutTimer.AddTo(base.CloseDisposable);
		_mailResendTimeoutTimer.Elapsed += delegate
		{
			OnMailResendTimerTick();
		};
		if (IsEmailConfirmationTimeoutVisible)
		{
			_mailResendTimeoutTimer.Enabled = true;
			OnMailResendTimerTick();
		}
	}

	public void OnLogoutClick()
	{
		_onLogoutClick.OnNext(Unit.Default);
	}

	public void OnLogoutFromAllClick()
	{
		_onLogoutFromAllClick.OnNext(Unit.Default);
	}

	public void OnDeleteClick()
	{
		_onDeleteClick.OnNext(Unit.Default);
	}

	public void OnSwitchMarketingSubscription(SubscriptionItemViewModel item, bool isSubscribed)
	{
		_onMarketingSubscriptionChanged.OnNext((item, isSubscribed));
	}

	protected override async Task Start()
	{
		await base.Start();
		State = VisualState.Default;
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		await SyncProfile();
	}

	public void OnFemaleTap()
	{
		Gender = Gender.Female;
	}

	public void OnMaleTap()
	{
		Gender = Gender.Male;
	}

	public void EnterFormattedPhone(string newPhoneFormatted, bool isEnded)
	{
		NewPhoneEntered = isEnded;
	}

	public void SetPhoneNumber(string newPhone)
	{
		PhoneNumber = "7" + newPhone;
	}

	public async Task SaveChanges()
	{
		State = VisualState.InProgress;
		if (IsProfileChanged)
		{
			await SaveProfileChanges();
		}
		State = VisualState.Default;
	}

	public async Task SendMailAgain()
	{
		State = VisualState.InProgress;
		Result<ProfileModel, DomainError> result = await _profileInteractor.RequestMailConfirmation();
		if (result.IsSuccess)
		{
			_infoMessageService.ShowSnackbar("Письмо с подтверждением адреса отправлено.", SnackbarStyle.Success, 5);
		}
		else
		{
			_infoMessageService.ShowSnackbar("Не удалось отправить письмо. Попробуйте запросить ещё раз.", SnackbarStyle.Error, 5);
		}
		IsEmailConfirmationNoteVisible = result.IsSuccess;
		MailResendDueTime = DateTime.UtcNow + TimeSpan.FromMinutes(1L);
		Preferences.Set("CD780355-9043-414A-85FF-86B5707C895E", MailResendDueTime, "UserContextPreferences");
		_mailResendTimeoutTimer.Enabled = true;
		OnMailResendTimerTick();
		State = VisualState.Default;
	}

	private void OnMailResendTimerTick()
	{
		TimeSpan timeSpan = MailResendDueTime - DateTime.UtcNow;
		int num = Convert.ToInt32(timeSpan.TotalSeconds);
		string value = GrammarHelper.DeclineNoun(num, "секунду", "секунды", "секунд");
		_mailResendTimeoutTimer.Enabled = timeSpan > TimeSpan.Zero;
		EmailConfirmationTimeoutText = $"Выслать письмо повторно через: {num} {value}";
		if (!_mailResendTimeoutTimer.Enabled)
		{
			MailResendDueTime = DateTime.MinValue;
			IsCanSendConfirmationMailAgain = !_isEmailConfirmed && NewEmail == Email;
		}
		else
		{
			IsCanSendConfirmationMailAgain = false;
		}
	}

	public void TapOnDate()
	{
		OnDateOfBirthChangeCommand.Trigger(new DateOfBirthSelectionViewModel.Parameter(DateOfBirth));
	}

	public void OnDateOfBirthSelected(DateTime selectedDate)
	{
		DateOfBirth = selectedDate;
		RaisePropertyChanged("DateOfBirthText");
	}

	private void SetProfileInitialValues()
	{
		_firstNameInitial = AuthValidationHelper.CutdownNameToMaxLength(_userContext.Profile?.FirstName ?? string.Empty);
		FirstName = _firstNameInitial;
		_lastNameInitial = AuthValidationHelper.CutdownNameToMaxLength(_userContext.Profile?.LastName ?? string.Empty);
		LastName = _lastNameInitial;
		ProfileModel? profile = _userContext.Profile;
		IsDateOfBirthEnabled = profile == null || !profile.Birthday.HasValue;
		DateOfBirth = _userContext.Profile?.Birthday;
		Gender = _userContext.Profile?.Gender ?? Gender.Female;
		_emailInitial = _userContext.Profile?.Email ?? string.Empty;
		string email = (NewEmail = _emailInitial);
		Email = email;
		int isEmailConfirmed;
		if (!string.IsNullOrEmpty(_emailInitial))
		{
			ProfileModel profile2 = _userContext.Profile;
			isEmailConfirmed = ((profile2 == null || profile2.MailConfirmation) ? 1 : 0);
		}
		else
		{
			isEmailConfirmed = 1;
		}
		_isEmailConfirmed = (byte)isEmailConfirmed != 0;
		bool isCanSendConfirmationMailAgain = (IsEmailConfirmationNoteVisible = !_isEmailConfirmed);
		IsCanSendConfirmationMailAgain = isCanSendConfirmationMailAgain;
		if (_mailResendTimeoutTimer.Enabled)
		{
			IsCanSendConfirmationMailAgain = false;
		}
		_phoneInitial = _userContext.Profile?.Phone ?? string.Empty;
		PhoneNumber = _phoneInitial;
		EReceiptSubscriptionEnabled = _userContext.Profile?.EReceiptEnabled ?? false;
		PollsSubscriptionEnabled = _userContext.Profile?.Subscribes.Any((SubscriptionModel x) => x.CommunicationType.Title == "email_polls" && !x.EndDate.HasValue) ?? false;
		RaisePropertyChanged("IsSaveButtonVisible");
		RaisePropertyChanged("IsSaveButtonEnabled");
	}

	private async Task SyncProfile(bool showLoymaxError = false)
	{
		State = VisualState.InProgress;
		Task<Result<SubscriptionsListModel, DomainError>> subscriptionTypesTask = _profileInteractor.GetSubscriptionTypes();
		Task<Result<Unit, DomainError>> syncProfileTask = _profileInteractor.SyncProfile();
		await Task.WhenAll(subscriptionTypesTask, syncProfileTask);
		_userContext.UpdateProfileWithNotify(_userContext.Profile);
		if (subscriptionTypesTask.Result.IsSuccess)
		{
			_subscriptionCommunicationModels.Clear();
			_subscriptionCommunicationModels.AddRange(subscriptionTypesTask.Result.Value.SubscriptionCommTypes);
			_subscriptionsService.SetSubscriptions(subscriptionTypesTask.Result.Value);
			HasPollsSubscription = _subscriptionsService.IsAvailable("email_polls");
			LoadMarketingSubscriptions();
		}
		State = VisualState.Default;
		if (syncProfileTask.Result.IsSuccess)
		{
			SetProfileInitialValues();
		}
		if (syncProfileTask.Result.IsFailure || subscriptionTypesTask.Result.IsFailure)
		{
			string message = "";
			if (syncProfileTask.Result.IsFailure)
			{
				message = ((!showLoymaxError) ? "Не удалось получить актуальные данные профиля" : syncProfileTask.Result.Error.Message);
			}
			else if (subscriptionTypesTask.Result.IsFailure)
			{
				message = "Упс! Что-то пошло не так.";
			}
			if (_userContext.Authorized)
			{
				_infoMessageService.ShowSnackbar(message);
			}
			if (syncProfileTask.Result.IsFailure && syncProfileTask.Result.Error is SessionExpiredError)
			{
				_onLogoutClick.OnNext(Unit.Default);
			}
		}
	}

	private Task SaveProfileChanges()
	{
		ProfileModel profile = _userContext.Profile;
		profile.FirstName = FirstName;
		profile.LastName = LastName;
		profile.Gender = Gender;
		profile.Birthday = DateOfBirth;
		profile.Email = NewEmail;
		if (string.IsNullOrEmpty(profile.Email))
		{
			profile.EReceiptEnabled = false;
		}
		return UpdateProfile(profile);
	}

	private async Task UpdateProfile(ProfileModel requestProfile)
	{
		Result<ProfileModel, DomainError> result = await _profileInteractor.UpdateProfile(requestProfile);
		if (result.TryGetValue(out var _))
		{
			OnChangesSavedCommand.Trigger();
			SetProfileInitialValues();
			_infoMessageService.ShowSnackbar("Профиль успешно обновлен.", SnackbarStyle.Success);
			return;
		}
		_userContext.Profile.Email = _emailInitial;
		if (result.TryGetError(out var error))
		{
			if (error is EmailOfAnotherAccountError)
			{
				NewEmail = string.Empty;
				Email = string.Empty;
			}
			HandleError(error);
		}
		else
		{
			UserDataViewModel userDataViewModel = this;
			UserDataViewModel userDataViewModel2 = this;
			string? obj = _emailInitial ?? string.Empty;
			string email = obj;
			userDataViewModel2.NewEmail = obj;
			userDataViewModel.Email = email;
		}
		RaisePropertyChanged(NewEmail);
		RaisePropertyChanged(Email);
	}

	private async Task OnEReceiptTap(bool enabled)
	{
		State = VisualState.InProgress;
		bool num = await _subscriptionsService.UpdateEReceiptSubscription(enabled, SyncProfile);
		State = VisualState.Default;
		bool eReceiptSubscriptionEnabled = (num ? enabled : (!enabled));
		EReceiptSubscriptionEnabled = eReceiptSubscriptionEnabled;
		RaisePropertyChanged("EReceiptSubscriptionEnabled");
	}

	private void LoadMarketingSubscriptions()
	{
		IEnumerable<SubscriptionItemViewModel> collection = from x in _subscriptionsService.GetSubscriptionsViewModels()
			where !x.CommType.Title.Equals("email_polls") && !x.CommType.Title.Equals("e-receipt")
			select x;
		MarketingSubscriptions.ReplaceRange(collection);
		HasMarketingSubscriptions = MarketingSubscriptions.Any();
	}

	private async Task OnMarketingSubscriptionChanged(SubscriptionItemViewModel item, bool isSubscribed)
	{
		State = VisualState.InProgress;
		Result<Unit, DomainError> result = await _subscriptionUpdateUseCase.UpdateSubscription(item, _subscriptionCommunicationModels, isSubscribed);
		State = VisualState.Default;
		if (result.IsFailure)
		{
			MarketingSubscriptions.ForceNotifyItemChanged(MarketingSubscriptions.First((SubscriptionItemViewModel x) => x.SubscriptionTitle == item.SubscriptionTitle));
			_infoMessageService.ShowSnackbar(result.Error.Message);
			return;
		}
		item.Enabled = !item.Enabled;
		MarketingSubscriptions.ForceNotifyItemChanged(MarketingSubscriptions.First((SubscriptionItemViewModel x) => x.SubscriptionTitle == item.SubscriptionTitle));
		if (item.CommType.Title == "mobile_push" && isSubscribed)
		{
			_loymaxPushTokenService.RegisterUserInLoymaxOnSubscriptionChange();
			if (!(await _deviceService.NotificationsEnabled()) && await AskUserAboutNotificationPermission())
			{
				NavigateToNotificationSettingsCommand.Trigger();
			}
		}
	}

	private async Task<bool> AskUserAboutNotificationPermission()
	{
		AlertButton obj = await _infoMessageService.ShowDialogAsync("Включите уведомления в настройках телефона", "И вы сможете получать полезные push-уведомления", new AlertButton[2]
		{
			new AlertButton
			{
				Title = "Отмена",
				Type = ActionType.Negative
			},
			new AlertButton
			{
				Title = "Настройки",
				Type = ActionType.Positive
			}
		});
		return (object)obj != null && obj.Type == ActionType.Positive;
	}

	private async Task OnPollsTap(bool enabled)
	{
		State = VisualState.InProgress;
		bool flag = await _subscriptionsService.UpdatePollsSubscription(enabled);
		State = VisualState.Default;
		PollsSubscriptionEnabled = (flag ? enabled : (!enabled));
		RaisePropertyChanged("PollsSubscriptionEnabled");
	}

	private async Task OnLogoutApproved()
	{
		State = VisualState.InProgress;
		Result<Unit, DomainError> result = await _logoutInteractor.Logout();
		State = VisualState.Default;
		if (result.IsSuccess)
		{
			BeforeRestartAppCommand.Trigger();
			_restartService.Restart();
		}
		else
		{
			_infoMessageService.ShowCommonError();
		}
	}

	private async Task OnLogoutFromOtherDevices()
	{
		State = VisualState.InProgress;
		Result<Unit, DomainError> result = await _logoutInteractor.Logout(fromAll: true);
		State = VisualState.Default;
		if (result.IsFailure)
		{
			_infoMessageService.ShowCommonError();
		}
		else
		{
			_infoMessageService.ShowSnackbar("Сессии на других устройствах завершены", SnackbarStyle.Success);
		}
	}

	private async Task OnDeleteAccount()
	{
		State = VisualState.InProgress;
		switch (await _userAccountDeletionService.DeleteAccount())
		{
		case DeletionResult.Failure:
			_infoMessageService.ShowCommonError();
			break;
		case DeletionResult.Success:
			BeforeRestartAppCommand.Trigger();
			_restartService.Restart();
			return;
		}
		State = VisualState.Default;
	}

	private void HandleError(DomainError error)
	{
		if (error is ConnectionError)
		{
			_infoMessageService.ShowSnackbar("Нет соединения с интернетом");
		}
		else
		{
			_infoMessageService.ShowSnackbar(error.Message);
		}
	}

	private void OnFirstNameChanged()
	{
		_firstNameValidator.ValidateAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private void OnLastNameChanged()
	{
		_lastNameValidator.ValidateAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task<bool> ValidateLastNameAsync(CancellationToken cancellationToken)
	{
		string lastName = LastName;
		bool flag = string.IsNullOrEmpty(lastName);
		if (!flag)
		{
			flag = await AuthValidationHelper.IsValidLastNameAsync(lastName);
		}
		return flag;
	}

	private void OnNewEmailChanged()
	{
		_emailValidator.ValidateAsync().SafeFireAndForget((Action<Exception>)null, false);
		IsCanSendConfirmationMailAgain = !_isEmailConfirmed && NewEmail == Email;
	}

	private async Task<bool> ValidateEmailAsync(CancellationToken cancellationToken)
	{
		string newEmail = NewEmail;
		bool flag = string.IsNullOrEmpty(newEmail);
		if (!flag)
		{
			flag = await AuthValidationHelper.IsValidEmailAsync(newEmail, cancellationToken);
		}
		return flag;
	}
}
