using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.DeveloperMenu;
using Auchan.Common.Extensions;
using Auchan.Common.InfoPages;
using Auchan.Common.PersonalCabinet.Interactors;

namespace Auchan.Common.PersonalCabinet.Authorization;

public sealed class LoginViewModel : ScreenViewModel
{
	public enum VisualState
	{
		Default,
		InProgress
	}

	public sealed class Parameter
	{
	}

	private const int VersionClickMaxCount = 10;

	private readonly AuthorizationCacheInteractor _authorizationCacheInteractor;

	private readonly IInfoMessageService _infoMessageService;

	private bool _iOSHackApplied;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CPhoneText_003Ek__BackingField;

	private bool _canLoginByPhone;

	private int _versionClickCount;

	private bool _withDevModeAccess;

	public string Title => "Введите номер";

	public string CloseString => "Закрыть";

	public string DoneString => "Готово";

	public string PhoneLabelText => "Tелефон";

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
	} = VisualState.InProgress;

	public UICommand FocusPhoneInputCommand { get; } = new UICommand();

	public UICommand<InfoPageViewModel.Parameter> OpenPrivacyPolicyCommand { get; } = new UICommand<InfoPageViewModel.Parameter>();

	public UICommand OpenAuthOrRegisterCommand { get; } = new UICommand();

	public string PhonePlaceholder => "+7 (___) ___-__-__";

	public string PhoneText
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
				RaisePropertyChanged("PhoneTextFormatted");
				RaisePropertyChanged("PhoneText");
			}
		}
	} = string.Empty;

	private string PhoneTextFormatted => "7" + ((PhoneText[0] == '7') ? PhoneText.Substring(1, PhoneText.Length - 1) : PhoneText);

	public string PhoneMask => "+7 ([000]) [000]-[00]-[00]";

	public string ReceiveSmsButton => "Получить код";

	public bool CanLoginByPhone
	{
		get
		{
			return _canLoginByPhone;
		}
		set
		{
			if (!_canLoginByPhone && value)
			{
				AppAnalytics.AppMetrica.TrackEvent("authorisationPhone");
			}
			_canLoginByPhone = value;
			RaisePropertyChanged("CanLoginByPhone");
		}
	}

	public LinkedText PhoneLegalString => new LinkedText("Нажимая на кнопку «" + "Получить код" + "», вы соглашаетесь с {0} и даете согласие на обработку ваших персональных данных", "Политикой конфиденциальности", ShowPrivacyPolicy);

	public UICommand<VerifyPinViewModel.Parameter> NavigateToPinCommand { get; } = new UICommand<VerifyPinViewModel.Parameter>();

	public UICommand OpenPasswordInputCommand { get; } = new UICommand();

	public UICommand PasswordAcceptedCommand { get; } = new UICommand();

	public LoginViewModel(Parameter parameter, AuthorizationCacheInteractor authorizationCacheInteractor, IInfoMessageService infoMessageService)
	{
		_authorizationCacheInteractor = authorizationCacheInteractor;
		_infoMessageService = infoMessageService;
	}

	private void ShowPrivacyPolicy()
	{
		OpenPrivacyPolicyCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.PrivacyPolicy));
	}

	protected override async Task Start()
	{
		await base.Start();
		this.OnPropertyChanges((LoginViewModel p) => p.PhoneText).PerformSamplingTask(SavePhone).Subscribe()
			.AddTo(base.CloseDisposable);
		PhoneText = await _authorizationCacheInteractor.GetPhone();
	}

	public void CloseClicked()
	{
		OpenAuthOrRegisterCommand.Trigger();
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		if (!_iOSHackApplied)
		{
			_iOSHackApplied = true;
			State = VisualState.Default;
		}
		FocusPhoneInputCommand.Trigger();
		FirstOpenReporter.ReportFirstOpen();
	}

	public void LoginByPhone()
	{
		if (PhoneText[0] == '9' || _withDevModeAccess)
		{
			NavigateToPinCommand.Trigger(new VerifyPinViewModel.Parameter
			{
				Phone = PhoneTextFormatted
			});
		}
		else
		{
			_infoMessageService.ShowSnackbar("Номер телефона имеет неправильный формат");
		}
	}

	private async Task SavePhone(string phone)
	{
		await _authorizationCacheInteractor.SavePhone(phone);
	}

	public void OnTitleClick()
	{
		_versionClickCount++;
		if (_versionClickCount >= 10)
		{
			_versionClickCount = 0;
			OpenPasswordInputCommand.Trigger();
		}
	}

	public void VerifyPassword(string password)
	{
		if (DevMenuViewModel.VerifyPassword(password))
		{
			_withDevModeAccess = true;
			PasswordAcceptedCommand.Trigger();
		}
		else if (password.Length == 6)
		{
			_infoMessageService.ShowSnackbar("Введен неверный пароль");
		}
	}
}
