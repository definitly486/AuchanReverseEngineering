using System;
using System.Diagnostics.CodeAnalysis;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.Loymax;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Custom;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.InfoPages;
using Auchan.Common.LoyaltyProgram;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.ViewModels.Component;
using Auchan.Common.LoyaltyProgramLoymax;
using Auchan.Common.PersonalCabinet.DomainModels;
using Auchan.Common.PersonalCabinet.Interactors;
using Auchan.Common.Profile;
using Auchan.Common.Recommendations;
using CSharpFunctionalExtensions;

namespace Auchan.Common.PersonalCabinet.Authorization;

public class SignUpViewModel : ScreenViewModel
{
	public class Parameter
	{
		public bool IsLoyaltyTrigger { get; }

		public LoyaltyCardRolloutType CardRolloutType { get; set; }

		public LoyaltyCardReattachType ReattachType { get; set; }

		public Parameter(bool isLoyaltyTrigger = false)
		{
			IsLoyaltyTrigger = isLoyaltyTrigger;
		}
	}

	private readonly Parameter _parameter;

	private readonly IInfoMessageService _infoMessageService;

	private readonly IUserContext _userContext;

	private readonly ProfileInteractor _profileInteractor;

	private readonly AuthorizationCacheInteractor _authorizationCacheInteractor;

	private readonly ILoyaltyCardManager _loyaltyCardManager;

	private readonly ILoyaltyPersonalizedGreetingsManager _loyaltyPersonalizedGreetingsManager;

	private readonly LoymaxPushTokenService _loymaxPushTokenService;

	private readonly ITrackingService _trackingService;

	private readonly ITokenService _tokenService;

	private readonly AsyncValidator<bool> _emailValidator;

	private readonly Subject<Unit> _verifyProfileSubject = new Subject<Unit>();

	private readonly Subject<Unit> _signUpSubject = new Subject<Unit>();

	private readonly AttachCardInfoViewModelComponent _cardInfoComponent = new AttachCardInfoViewModelComponent();

	private ProfileModel? _profileModel;

	private TokenModel? _token80;

	private bool _isWrongDate;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CPhoneText_003Ek__BackingField;

	private string _firstNameText = string.Empty;

	[CompilerGenerated]
	private DateTime? _003CDateOfBirth_003Ek__BackingField;

	private string _dateOfBirthText = string.Empty;

	[CompilerGenerated]
	private bool _003CIsDateErrorVisible_003Ek__BackingField;

	[CompilerGenerated]
	private Gender _003CSelectedGender_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CEmailText_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsEmailValid_003Ek__BackingField;

	[CompilerGenerated]
	private LoyaltyCardRolloutType _003CCardRolloutType_003Ek__BackingField;

	private bool _isPlasticCardOwnershipChecked;

	[CompilerGenerated]
	private bool _003CIsCardNumberValid_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsCardCvcValid_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsWantToReceiveSuggestions_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsSignUpButtonEnabled_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsAgreeWithLoyaltyProgram_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CNeedCardNumberFocus_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CFocusToErrorField_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CNeedScrollToEmail_003Ek__BackingField;

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.Default;

	public string DoneString => "Готово";

	public string CloseString => "Закрыть";

	public bool IsCloseButtonEnabled => true;

	public string NextString => "Далее";

	public string? PhoneText
	{
		[CompilerGenerated]
		get
		{
			return _003CPhoneText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CPhoneText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CPhoneText_003Ek__BackingField = value;
				RaisePropertyChanged("PhoneText");
			}
		}
	}

	public string PhonePlaceholder => "Телефон";

	public string PhoneMask => "+7 ([000]) [000]-[00]-[00]";

	public string FirstNameText
	{
		get
		{
			return _firstNameText;
		}
		[param: AllowNull]
		set
		{
			if (!string.Equals(_firstNameText, value, StringComparison.Ordinal))
			{
				_firstNameText = value ?? "";
				RaisePropertyChanged("IsFirstNameNotEmptyAndValid");
				RaisePropertyChanged("IsSignUpEnabled");
				RaisePropertyChanged("IsFirstNameValid");
				RaisePropertyChanged("FirstNameText");
				UpdateIsSignUpButtonEnabled();
			}
		}
	}

	public string FirstNamePlaceholder => "Имя *";

	public string FirstNameError => "Удалите пробелы, цифры, символы";

	public bool IsFirstNameNotEmptyAndValid => AuthValidationHelper.IsValidFirstName(FirstNameText);

	public bool IsFirstNameValid
	{
		get
		{
			if (!string.IsNullOrEmpty(FirstNameText))
			{
				return AuthValidationHelper.IsValidFirstName(FirstNameText);
			}
			return true;
		}
	}

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
				RaisePropertyChanged("IsDateOfBirthValid");
				RaisePropertyChanged("IsSignUpEnabled");
				RaisePropertyChanged("DateOfBirth");
			}
		}
	}

	public string DateOfBirthText
	{
		get
		{
			return _dateOfBirthText;
		}
		set
		{
			if (string.Equals(_dateOfBirthText, value, StringComparison.Ordinal))
			{
				return;
			}
			_dateOfBirthText = value;
			RaisePropertyChanged("IsDateOfBirthValid");
			RaisePropertyChanged("IsSignUpEnabled");
			RaisePropertyChanged("DateOfBirthText");
			string text = "[00].[00].[0000]".Replace("[", "").Replace("]", "");
			IsSignUpButtonEnabled = IsFirstNameNotEmptyAndValid && string.IsNullOrEmpty(_dateOfBirthText);
			if (_dateOfBirthText.Length == text.Length)
			{
				if (DateTime.TryParse(value, out var result))
				{
					_isWrongDate = false;
					DateOfBirth = result;
					UpdateIsSignUpButtonEnabled();
				}
				else
				{
					_isWrongDate = true;
				}
				IsDateErrorVisible = !IsDateOfBirthValid;
			}
			else
			{
				DateOfBirth = null;
				IsDateErrorVisible = false;
				UpdateIsSignUpButtonEnabled();
			}
			RaisePropertyChanged("DateOfBirthHelperText");
			RaisePropertyChanged("IsDateErrorVisible");
		}
	}

	public string DateOfBirthPlaceholder => "Дата рождения";

	public string DateOfBirthMaskPlaceholder => "__.__.____";

	public string DateOfBirthHelperText
	{
		get
		{
			if (!_isWrongDate)
			{
				return "Регистрация возможна для пользователей\nстарше 18 лет";
			}
			return "Введите верную дату";
		}
	}

	public bool IsDateErrorVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsDateErrorVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsDateErrorVisible_003Ek__BackingField != value)
			{
				_003CIsDateErrorVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsDateErrorVisible");
			}
		}
	}

	public bool IsDateOfBirthValid
	{
		get
		{
			if (!string.IsNullOrEmpty(DateOfBirthText))
			{
				return AuthValidationHelper.IsValidDateOfBirth(DateOfBirth);
			}
			return true;
		}
	}

	public Gender SelectedGender
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedGender_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CSelectedGender_003Ek__BackingField != value)
			{
				_003CSelectedGender_003Ek__BackingField = value;
				RaisePropertyChanged("IsGenderValid");
				RaisePropertyChanged("SelectedGender");
			}
		}
	}

	public bool IsGenderValid => AuthValidationHelper.IsValidGender(SelectedGender);

	public string MaleGenderTitle => "Я мужчина";

	public string FemaleGenderTitle => "Я женщина";

	public string EmailText
	{
		[CompilerGenerated]
		get
		{
			return _003CEmailText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CEmailText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CEmailText_003Ek__BackingField = value;
				OnEmailTextChanged();
				RaisePropertyChanged("EmailText");
			}
		}
	} = string.Empty;

	public string EmailPlaceholder => "E-mail";

	public string EmailError => "Не используйте кириллицу, пробелы и спецсимволы";

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
				RaisePropertyChanged("IsSignUpEnabled");
				RaisePropertyChanged("IsEmailValid");
			}
		}
	} = true;

	public LoyaltyCardRolloutType CardRolloutType
	{
		[CompilerGenerated]
		get
		{
			return _003CCardRolloutType_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CCardRolloutType_003Ek__BackingField != value)
			{
				_003CCardRolloutType_003Ek__BackingField = value;
				RaisePropertyChanged("IsLoyaltyCardInfoNeeded");
				RaisePropertyChanged("CardRolloutType");
			}
		}
	}

	public bool IsLoyaltyCardInfoNeeded => CardRolloutType == LoyaltyCardRolloutType.Plastic;

	public string IHavePlasticCardTitle => "У меня есть пластиковая карта АШАН";

	public bool IsPlasticCardOwnershipChecked
	{
		get
		{
			return _isPlasticCardOwnershipChecked;
		}
		set
		{
			if (_isPlasticCardOwnershipChecked != value)
			{
				_isPlasticCardOwnershipChecked = value;
				RaisePropertyChanged("IsPlasticCardValidationPassed");
				RaisePropertyChanged("IsSignUpEnabled");
				RaisePropertyChanged("IsPlasticCardOwnershipChecked");
				if (_isPlasticCardOwnershipChecked)
				{
					AppAnalytics.AppMetrica.ActivateLoyaltyPlasticCard();
					CardRolloutType = LoyaltyCardRolloutType.Plastic;
				}
				else
				{
					CardRolloutType = LoyaltyCardRolloutType.Virtual;
				}
				RaisePropertyChanged("IsLoyaltyCardInfoNeeded");
			}
		}
	}

	public string CardNumberTitle => _cardInfoComponent.CardNumberTitle;

	public string CardNumberText
	{
		get
		{
			return _cardInfoComponent.CardNumberText;
		}
		[param: AllowNull]
		set
		{
			if (!string.Equals(CardNumberText, value, StringComparison.Ordinal))
			{
				if (value == null)
				{
					value = "";
				}
				_cardInfoComponent.CardNumberText = value;
				if (value.Replace(" ", "").Length == 13)
				{
					IsCardNumberValid = true;
				}
				RaisePropertyChanged("CardNumberText");
			}
		}
	}

	public string CardNumberValidationHint => _cardInfoComponent.CardNumberValidationHint;

	public bool IsCardNumberValid
	{
		[CompilerGenerated]
		get
		{
			return _003CIsCardNumberValid_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsCardNumberValid_003Ek__BackingField != value)
			{
				_003CIsCardNumberValid_003Ek__BackingField = value;
				RaisePropertyChanged("IsPlasticCardValidationPassed");
				RaisePropertyChanged("IsSignUpEnabled");
				RaisePropertyChanged("IsCardNumberValid");
			}
		}
	} = true;

	public string LoyaltyCardNumberMask => "[0000] [0000] [0000] [0]";

	public string CardCvcTitle => _cardInfoComponent.CardCvcTitle;

	public string CardCvcText
	{
		get
		{
			return _cardInfoComponent.CardCvcText;
		}
		[param: AllowNull]
		set
		{
			if (!string.Equals(CardCvcText, value, StringComparison.Ordinal))
			{
				if (value == null)
				{
					value = "";
				}
				_cardInfoComponent.CardCvcText = value;
				if (value.Length == 3)
				{
					IsCardCvcValid = true;
				}
				RaisePropertyChanged("CardCvcText");
			}
		}
	}

	public string CardCvcValidationHint => _cardInfoComponent.CardCvcValidationHint;

	public bool IsCardCvcValid
	{
		[CompilerGenerated]
		get
		{
			return _003CIsCardCvcValid_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsCardCvcValid_003Ek__BackingField != value)
			{
				_003CIsCardCvcValid_003Ek__BackingField = value;
				RaisePropertyChanged("IsPlasticCardValidationPassed");
				RaisePropertyChanged("IsSignUpEnabled");
				RaisePropertyChanged("IsCardCvcValid");
			}
		}
	} = true;

	public int LoyaltyCardCvcLength => 3;

	public string CardCvcHintPopupTitle => _cardInfoComponent.CardCvcHintPopupTitle;

	public string WantToReceiveSuggestionsText => "Согласен на получение рекламных рассылок";

	public bool IsWantToReceiveSuggestions
	{
		[CompilerGenerated]
		get
		{
			return _003CIsWantToReceiveSuggestions_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsWantToReceiveSuggestions_003Ek__BackingField != value)
			{
				_003CIsWantToReceiveSuggestions_003Ek__BackingField = value;
				RaisePropertyChanged("IsWantToReceiveSuggestions");
			}
		}
	} = true;

	public string SignUpButtonTitle => "Зарегистрироваться";

	public bool IsPlasticCardValidationPassed
	{
		get
		{
			if (IsPlasticCardOwnershipChecked)
			{
				if (IsCardNumberValid && IsCardCvcValid && _cardInfoComponent.IsCardNumberEntered)
				{
					return _cardInfoComponent.IsCardCvcEntered;
				}
				return false;
			}
			return true;
		}
	}

	public bool IsSignUpButtonEnabled
	{
		[CompilerGenerated]
		get
		{
			return _003CIsSignUpButtonEnabled_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsSignUpButtonEnabled_003Ek__BackingField != value)
			{
				_003CIsSignUpButtonEnabled_003Ek__BackingField = value;
				RaisePropertyChanged("IsSignUpButtonEnabled");
			}
		}
	}

	public bool IsSignUpEnabled
	{
		get
		{
			if (IsFirstNameNotEmptyAndValid && IsDateOfBirthValid && IsEmailValid)
			{
				return IsPlasticCardValidationPassed;
			}
			return false;
		}
	}

	public LinkedText LegalString => new LinkedText("Нажимая на кнопку \"Зарегистрироваться\", вы соглашаетесь с \"Политикой конфиденциальности\", \"Обработкой персональных данных\", \"Правилами программы лояльности\" и \"Публичной офертой\"", new string[4] { "Политикой конфиденциальности", "Обработкой персональных данных", "Правилами программы лояльности", "Публичной офертой" }, new Action[4]
	{
		delegate
		{
			OpenInfoPageCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.PrivacyPolicy));
		},
		ShowPersonalDataProcessingPolicy,
		ShowLoyatyPolicy,
		delegate
		{
			OpenInfoPageCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.Offerta));
		}
	});

	public bool IsAgreeWithLoyaltyProgram
	{
		[CompilerGenerated]
		get
		{
			return _003CIsAgreeWithLoyaltyProgram_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsAgreeWithLoyaltyProgram_003Ek__BackingField != value)
			{
				_003CIsAgreeWithLoyaltyProgram_003Ek__BackingField = value;
				RaisePropertyChanged("IsAgreeWithLoyaltyProgram");
			}
		}
	}

	public string Title => "Давайте познакомимся";

	public bool NeedCardNumberFocus
	{
		[CompilerGenerated]
		get
		{
			return _003CNeedCardNumberFocus_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CNeedCardNumberFocus_003Ek__BackingField != value)
			{
				_003CNeedCardNumberFocus_003Ek__BackingField = value;
				RaisePropertyChanged("NeedCardNumberFocus");
			}
		}
	}

	public bool IsLoyaltyProgramRegistration => _parameter.IsLoyaltyTrigger;

	public UICommand<InfoPageViewModel.Parameter> OpenInfoPageCommand { get; } = new UICommand<InfoPageViewModel.Parameter>();

	public UICommand ShowCvcHintPopupCommand { get; } = new UICommand();

	public UICommand FocusFirstNameInputCommand { get; } = new UICommand();

	public UICommand NavigateToAuthOrRegister { get; } = new UICommand();

	public UICommand RestartAuthCommand { get; } = new UICommand();

	protected override string ScreenName => "entry_reg";

	public string DateOfBirthMask => "[00].[00].[0000]";

	public string RollCardText => "После регистрации Вам будет выпущена виртуальная карта АШАН";

	public UICommand FocusToErrorField
	{
		[CompilerGenerated]
		get
		{
			return _003CFocusToErrorField_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CFocusToErrorField_003Ek__BackingField, value))
			{
				_003CFocusToErrorField_003Ek__BackingField = value;
				RaisePropertyChanged("FocusToErrorField");
			}
		}
	} = new UICommand();

	public bool NeedScrollToEmail
	{
		[CompilerGenerated]
		get
		{
			return _003CNeedScrollToEmail_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CNeedScrollToEmail_003Ek__BackingField != value)
			{
				_003CNeedScrollToEmail_003Ek__BackingField = value;
				RaisePropertyChanged("NeedScrollToEmail");
			}
		}
	}

	public SignUpViewModel(Parameter parameter, IInfoMessageService infoMessageService, IUserContext userContext, ProfileInteractor profileInteractor, AuthorizationCacheInteractor authorizationCacheInteractor, ILoyaltyCardManager loyaltyCardManager, ILoyaltyPersonalizedGreetingsManager loyaltyPersonalizedGreetingsManager, LoymaxPushTokenService loymaxPushTokenService, ITrackingService trackingService, ITokenService tokenService)
	{
		_parameter = parameter;
		_infoMessageService = infoMessageService;
		_userContext = userContext;
		_profileInteractor = profileInteractor;
		_authorizationCacheInteractor = authorizationCacheInteractor;
		_loyaltyCardManager = loyaltyCardManager;
		_loyaltyPersonalizedGreetingsManager = loyaltyPersonalizedGreetingsManager;
		_loymaxPushTokenService = loymaxPushTokenService;
		_trackingService = trackingService;
		_tokenService = tokenService;
		CardRolloutType = _parameter.CardRolloutType;
		IsPlasticCardOwnershipChecked = _parameter.CardRolloutType == LoyaltyCardRolloutType.Plastic;
		_emailValidator = new AsyncValidator<bool>(ValidateEmailAsync, delegate(bool v)
		{
			IsEmailValid = v;
		}).AddTo(base.CloseDisposable);
	}

	protected override async Task Start()
	{
		State = VisualState.InProgress;
		await base.Start();
		(await _tokenService.SavedToken80()).TryGetValue(out _token80);
		_signUpSubject.PerformDebouncingTask(SignUpAsync).Subscribe().AddTo(base.CloseDisposable);
		_verifyProfileSubject.SkipFirst().PerformSamplingTask(CheckProfile).Subscribe()
			.AddTo(base.CloseDisposable);
		ProfileModel profile = _userContext.Profile;
		if (profile != null)
		{
			_profileModel = profile;
			PhoneText = _profileModel.Phone;
			FirstNameText = _profileModel.FirstName ?? string.Empty;
			DateOfBirth = _profileModel.Birthday;
			SelectedGender = _profileModel.Gender;
			EmailText = _profileModel.Email ?? string.Empty;
		}
		if (!IsLoyaltyProgramRegistration)
		{
			this.OnPropertyChanges((SignUpViewModel x) => x.PhoneText).CombineLatest(this.OnPropertyChanges((SignUpViewModel x) => x.FirstNameText).Throttle(TimeSpan.FromMilliseconds(500L)), this.OnPropertyChanges((SignUpViewModel x) => x.EmailText).Throttle(TimeSpan.FromMilliseconds(500L)), this.OnPropertyChanges((SignUpViewModel x) => x.SelectedGender), this.OnPropertyChanges((SignUpViewModel x) => x.DateOfBirth), this.OnPropertyChanges((SignUpViewModel x) => x.IsWantToReceiveSuggestions), (string p, string f, string e, Gender g, DateTime? d, bool i) => new SignUpCachedData(p, f, e, g, d, i)).PerformSamplingTask(SaveData)
				.Subscribe()
				.AddTo(base.CloseDisposable);
			SignUpCachedData signUpCachedData = await _authorizationCacheInteractor.GetSignUpCache();
			if (signUpCachedData != null)
			{
				if (PhoneText == null)
				{
					PhoneText = signUpCachedData.PhoneText;
				}
				FirstNameText = signUpCachedData.FirstName;
				EmailText = signUpCachedData.EmailText;
				SelectedGender = signUpCachedData.SelectedGender;
				DateOfBirth = signUpCachedData.Birthday;
				IsWantToReceiveSuggestions = signUpCachedData.SubscriptionFlag;
			}
		}
		State = VisualState.Default;
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		if (!(await _tokenService.SavedToken80()).TryGetValue(out var _) && _token80 != null)
		{
			await _tokenService.SaveToken(_token80);
		}
		if (_userContext.Profile == null && _profileModel != null)
		{
			_userContext.Profile = _profileModel;
		}
		AppAnalytics.AppMetrica.TrackEvent("registrationNewAccScreenView");
		if (!IsLoyaltyProgramRegistration)
		{
			_verifyProfileSubject.OnNext(Unit.Default);
		}
		FocusFirstNameInputCommand.Trigger();
	}

	public void SignUp()
	{
		_cardInfoComponent.OnFinishCardCvcInput();
		_cardInfoComponent.OnFinishCardNumberInput();
		if (!IsSignUpEnabled)
		{
			NeedScrollToEmail = !IsEmailValid;
			if (IsPlasticCardOwnershipChecked)
			{
				AttachCardInfoViewModelComponent cardInfoComponent = _cardInfoComponent;
				IsCardNumberValid = cardInfoComponent != null && cardInfoComponent.IsCardNumberValid && cardInfoComponent.IsCardNumberEntered;
				cardInfoComponent = _cardInfoComponent;
				IsCardCvcValid = cardInfoComponent != null && cardInfoComponent.IsCardCvcValid && cardInfoComponent.IsCardCvcEntered;
				RaisePropertyChanged("IsCardNumberValid");
				RaisePropertyChanged("IsCardCvcValid");
			}
			IsSignUpButtonEnabled = IsFirstNameNotEmptyAndValid && IsDateOfBirthValid;
			RaisePropertyChanged("IsFirstNameNotEmptyAndValid");
			if (DateOfBirth.HasValue)
			{
				IsDateErrorVisible = !IsDateOfBirthValid;
				RaisePropertyChanged("IsDateErrorVisible");
			}
			FocusToErrorField.Trigger();
		}
		else
		{
			AppAnalytics.AppMetrica.TrackEvent("registrationNewAccScreenButtonReg");
			_signUpSubject.OnNext(Unit.Default);
		}
	}

	public void OnFinishCardNumberInput()
	{
		_cardInfoComponent.OnFinishCardNumberInput();
		AttachCardInfoViewModelComponent cardInfoComponent = _cardInfoComponent;
		IsCardNumberValid = cardInfoComponent != null && cardInfoComponent.IsCardNumberValid && cardInfoComponent.IsCardNumberEntered;
		RaisePropertyChanged("IsCardNumberValid");
		RaisePropertyChanged("CardNumberText");
		RaisePropertyChanged("IsSignUpButtonEnabled");
	}

	public void OnFinishCardCvcInput()
	{
		_cardInfoComponent.OnFinishCardCvcInput();
		AttachCardInfoViewModelComponent cardInfoComponent = _cardInfoComponent;
		IsCardCvcValid = cardInfoComponent != null && cardInfoComponent.IsCardCvcValid && cardInfoComponent.IsCardCvcEntered;
		RaisePropertyChanged("IsCardCvcValid");
		RaisePropertyChanged("CardCvcText");
		RaisePropertyChanged("IsSignUpButtonEnabled");
	}

	public void TapOnCvcHintIcon()
	{
		ShowCvcHintPopupCommand.Trigger();
	}

	public void Logout()
	{
		_userContext.LogOut();
	}

	public void GoToAuthorization()
	{
		Logout();
		NavigateToAuthOrRegister.Trigger();
	}

	private async Task SaveData(SignUpCachedData arg)
	{
		await _authorizationCacheInteractor.SaveSignUpCache(arg);
	}

	private async Task CheckProfile()
	{
		var (flag4, _, flag5, _) = await _profileInteractor.CheckIfProfileIsDeleted();
		if (flag4 && flag5)
		{
			_infoMessageService.ShowSnackbar("Сессия завершена");
			RestartAuthCommand.Trigger();
		}
	}

	private void ShowLoyatyPolicy()
	{
		OpenInfoPageCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.LoyaltyPolicy));
	}

	private void ShowPersonalDataProcessingPolicy()
	{
		OpenInfoPageCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.PersonalDataProcessingAgreement));
	}

	private async Task SignUpAsync()
	{
		State = VisualState.InProgress;
		if (_profileModel == null)
		{
			State = VisualState.Default;
			return;
		}
		await PopulateProfileModel(_profileModel);
		if (!(await RolloutLoyaltyCardIfNeeded()))
		{
			State = VisualState.Default;
			return;
		}
		AppAnalytics.AppMetrica.TrackEvent("registrationNewAccScreenNieventSuccess");
		await _userContext.LogIn();
		SendProfileInfoToAnalytics();
		Result<LoyaltyCardEntity, DomainError> result = await _loyaltyCardManager.GetLoyaltyCard(CancellationToken.None);
		if (result.IsSuccess)
		{
			await _trackingService.SetCustomer(_userContext.Profile, result.Value);
		}
		State = VisualState.Default;
		_userContext.LoyaltyCard = _cardInfoComponent.Entity;
		_userContext.IsAuthorizedAcrossRegistration = true;
		_loyaltyPersonalizedGreetingsManager.SetGreetingShouldBeShown(shouldBeShown: true);
		NavigateAfterSignup();
	}

	private async Task PopulateProfileModel(ProfileModel requestProfile)
	{
		FirstNameText = FirstNameText.Trim();
		EmailText = EmailText.Trim();
		requestProfile.FirstName = FirstNameText;
		requestProfile.Email = EmailText;
		requestProfile.Gender = SelectedGender;
		requestProfile.Birthday = DateOfBirth;
		if (IsWantToReceiveSuggestions)
		{
			await _profileInteractor.UpdateWithSubscriptionsOn(requestProfile);
		}
		if (IsLoyaltyProgramRegistration)
		{
			requestProfile.LoyaltyFlag = true;
		}
	}

	private void NavigateAfterSignup()
	{
		_infoMessageService.ShowHomePage();
	}

	private async Task<bool> RolloutLoyaltyCardIfNeeded()
	{
		Result<Unit, DomainError> result;
		if (CardRolloutType == LoyaltyCardRolloutType.Plastic)
		{
			if (_userContext.LoyaltyCard != null && _userContext.LoyaltyCard.CardStatus != LoyaltyCardStatus.Active)
			{
				result = await _loyaltyCardManager.BlockAndReissueCardAsync(_cardInfoComponent.CardNumberText, _cardInfoComponent.CardCvcText);
			}
			else
			{
				Result<LoyaltyEnrollmentModel, DomainError> enrollResult = await _loyaltyCardManager.EnrollPlasticCard(_cardInfoComponent.Entity);
				_loymaxPushTokenService.SaveEnrollmentResult(enrollResult, IsWantToReceiveSuggestions);
				result = (enrollResult.IsSuccess ? Result.Success<Unit, DomainError>(Unit.Default) : Result.Failure<Unit, DomainError>(enrollResult.Error));
			}
			if (result.IsFailure)
			{
				string text = "Произошла ошибка. Пожалуйста, повторите попытку позже.";
				if (result.Error is CardEnrollError || result.Error is CardMergeError)
				{
					text = result.Error.Message ?? text;
				}
				_infoMessageService.ShowSnackbar(text);
				if (result.Error is CardEnrollError { ErrorType: CardEnrollError.Type.CMDTemporaryUnavailable })
				{
					RestartAuthCommand.Trigger();
				}
				return false;
			}
			return true;
		}
		if (_userContext.LoyaltyCard != null && _userContext.LoyaltyCard.CardStatus != LoyaltyCardStatus.Active && _userContext.LoyaltyCard.CardStatus != LoyaltyCardStatus.None)
		{
			result = await _loyaltyCardManager.BlockAndReissueCardAsync();
		}
		else
		{
			Result<LoyaltyEnrollmentModel, DomainError> enrollResult2 = await _loyaltyCardManager.EnrollVirtualCard(LoyaltyEnrollmentRequestDto.ChannelDto.MobileApplication);
			_loymaxPushTokenService.SaveEnrollmentResult(enrollResult2, IsWantToReceiveSuggestions);
			result = (enrollResult2.IsSuccess ? Result.Success<Unit, DomainError>(Unit.Default) : Result.Failure<Unit, DomainError>(enrollResult2.Error));
		}
		if (result.IsFailure)
		{
			string text2 = "Произошла ошибка. Пожалуйста, повторите попытку позже.";
			if (result.Error is CardEnrollError || result.Error is CardMergeError)
			{
				text2 = result.Error.Message ?? text2;
			}
			_infoMessageService.ShowSnackbar(text2);
			if (result.Error is CardEnrollError { ErrorType: CardEnrollError.Type.CMDTemporaryUnavailable })
			{
				RestartAuthCommand.Trigger();
			}
			return false;
		}
		return true;
	}

	private void SendProfileInfoToAnalytics()
	{
		if (_userContext.Profile != null)
		{
			AppAnalytics.Loymax.UserLogin();
		}
	}

	private void OnEmailTextChanged()
	{
		_emailValidator.ValidateAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task<bool> ValidateEmailAsync(CancellationToken cancellationToken)
	{
		string emailText = EmailText;
		bool flag = string.IsNullOrEmpty(emailText);
		if (!flag)
		{
			flag = await AuthValidationHelper.IsValidEmailAsync(emailText, cancellationToken);
		}
		return flag;
	}

	private void UpdateIsSignUpButtonEnabled()
	{
		IsSignUpButtonEnabled = IsFirstNameNotEmptyAndValid && IsDateOfBirthValid;
	}
}
