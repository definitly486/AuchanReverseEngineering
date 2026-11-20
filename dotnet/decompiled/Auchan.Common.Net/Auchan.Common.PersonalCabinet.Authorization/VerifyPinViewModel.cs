using System;
using System.Diagnostics.CodeAnalysis;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.HardUpdate;
using Auchan.Common.Helpers;
using Auchan.Common.LoyaltyProgram;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgramLoymax;
using Auchan.Common.PersonalCabinet.Authorization.AuthPush;
using Auchan.Common.PersonalCabinet.Authorization.Managers;
using Auchan.Common.PersonalCabinet.DomainModels;
using Auchan.Common.PersonalCabinet.Errors;
using Auchan.Common.PersonalCabinet.Interactors;
using Auchan.Common.Recommendations;
using Auchan.Common.Sms;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.PersonalCabinet.Authorization;

public sealed class VerifyPinViewModel : ScreenViewModel, ISmsRetrieverListener
{
	public enum VisualState
	{
		Default,
		InProgress
	}

	public sealed record Parameter
	{
		public required string Phone { get; init; }

		[CompilerGenerated]
		[SetsRequiredMembers]
		private Parameter(Parameter original)
		{
			Phone = original.Phone;
		}

		public Parameter()
		{
		}
	}

	private readonly Parameter _parameter;

	private readonly IInfoMessageService _infoMessageService;

	private readonly PinInteractor _pinInteractor;

	private readonly DefaultPersonalCabinetErrorHandler _defaultPersonalCabinetErrorHandler;

	private readonly IUserContext _userContext;

	private readonly PinRetryFreezeManager _pinRetryFreezeManager;

	private readonly ITokenService _tokenService;

	private readonly ILoyaltyCardManager _loyaltyCardManager;

	private readonly IHardUpdateManager _hardUpdateManager;

	private readonly ISmsRetriever _smsRetriever;

	private readonly IDeviceService _deviceService;

	private readonly AuthPushListener _authPushListener;

	private readonly Subject<Unit> _requestPinSubject = new Subject<Unit>();

	private readonly ITrackingService _trackingService;

	private string _pinText = string.Empty;

	private Action<string>? _onSmsReceivedAction;

	private DateTime _cantSendSmsDueTime;

	private Timer? _cantSendSmsTimer;

	private bool _sendLogs;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CCanRequestPin_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CTimerText_003Ek__BackingField;

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
	}

	public string Title => "Введите код";

	public string CloseString => "Закрыть";

	public string Header => "Код подтверждения";

	private string Phone => _parameter.Phone;

	public AttributedText VerificationLabel => new AttributedText("На номер {0} был отправлен код подтверждения", PhoneHelper.FormatPhone(Phone));

	public string AllowedDigits => "0123456789";

	public string PinText
	{
		get
		{
			return _pinText;
		}
		set
		{
			value = ((value.Length > 4) ? value.Substring(0, 4) : value);
			if (_pinText != value)
			{
				_pinText = value;
				RaisePropertyChanged("PinText");
			}
		}
	}

	public bool CanRequestPin
	{
		[CompilerGenerated]
		get
		{
			return _003CCanRequestPin_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CCanRequestPin_003Ek__BackingField != value)
			{
				_003CCanRequestPin_003Ek__BackingField = value;
				RaisePropertyChanged("CanRequestPin");
			}
		}
	}

	public string RequestCodeButtonTitle => "Получить новый код";

	private string TimerText
	{
		[CompilerGenerated]
		get
		{
			return _003CTimerText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CTimerText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTimerText_003Ek__BackingField = value;
				RaisePropertyChanged("PinRequestCountDown");
				RaisePropertyChanged("TimerText");
			}
		}
	} = TimeSpan.FromSeconds(0L).GetLeftSecondsFormatted();

	public string PinRequestCountDown => "Новый код можно будет запросить через:" + "\n" + TimerText;

	public string UserCantEnter => "Не приходит смс с кодом?";

	public UICommand<SignUpViewModel.Parameter> OpenSignUpCommand { get; } = new UICommand<SignUpViewModel.Parameter>();

	public UICommand<DidntReceiveSmsViewModel.Parameter> OpenSupportCommand { get; } = new UICommand<DidntReceiveSmsViewModel.Parameter>();

	public UICommand ResetPinCommand { get; } = new UICommand();

	public UICommand OpenAuthOrRegisterCommand { get; } = new UICommand();

	public UICommand OpenCardBlockedCommand { get; } = new UICommand();

	public UICommand<string> PinTextChangedCommand { get; } = new UICommand<string>();

	public VerifyPinViewModel(Parameter parameter, IInfoMessageService infoMessageService, PinInteractor pinInteractor, DefaultPersonalCabinetErrorHandler defaultPersonalCabinetErrorHandler, IUserContext userContext, PinRetryFreezeManager pinRetryFreezeManager, ITokenService tokenService, ILoyaltyCardManager loyaltyCardManager, IHardUpdateManager hardUpdateManager, ISmsRetriever smsRetriever, IDeviceService deviceService, AuthPushListener authPushListener, ITrackingService trackingService)
	{
		_parameter = parameter;
		_infoMessageService = infoMessageService;
		_pinInteractor = pinInteractor;
		_defaultPersonalCabinetErrorHandler = defaultPersonalCabinetErrorHandler;
		_userContext = userContext;
		_pinRetryFreezeManager = pinRetryFreezeManager;
		_tokenService = tokenService;
		_loyaltyCardManager = loyaltyCardManager;
		_hardUpdateManager = hardUpdateManager;
		_smsRetriever = smsRetriever;
		_deviceService = deviceService;
		_authPushListener = authPushListener;
		_trackingService = trackingService;
		_cantSendSmsTimer = new Timer(OnResendSmsTimerTick);
	}

	private async Task SetPin()
	{
		await Task.Delay(1000);
		PinText = "2222";
	}

	protected override async Task Start()
	{
		await base.Start();
		State = VisualState.InProgress;
		_smsRetriever.AddListener(this).AddTo(base.CloseDisposable);
		_smsRetriever.Prepare().SafeFireAndForget((Action<Exception>)null, false);
		_pinRetryFreezeManager.CheckAndUpdatePhone(Phone);
		(from p in this.OnPropertyChanges((VerifyPinViewModel p) => p.PinText)
			where p.Length == 4
			select p).PerformSamplingTask(VerifyPinAsync).Subscribe().AddTo(base.CloseDisposable);
		PinTextChangedCommand.Take(1).Subscribe(delegate
		{
			AppAnalytics.AppMetrica.TrackEvent("phoneVerificationScreenCodeStart");
		}).AddTo(base.CloseDisposable);
		_requestPinSubject.PerformDebouncingTask(SendPinAsyncIfRetryCountIsNotExceeded).Subscribe().AddTo(base.CloseDisposable);
		_requestPinSubject.OnNext(Unit.Default);
		State = VisualState.Default;
	}

	protected override Task OnResumed()
	{
		_onSmsReceivedAction = delegate(string sms)
		{
			PinText = sms.Substring(0, 4);
		};
		_authPushListener.OnPinReceivedAction = delegate(string pin)
		{
			PinText = pin;
		};
		StartCantSendSmsTimerIfNeed();
		AppAnalytics.AppMetrica.TrackEvent("phoneVerificationScreenView");
		return base.OnResumed();
	}

	protected override Task OnPaused()
	{
		_onSmsReceivedAction = null;
		_authPushListener.OnPinReceivedAction = null;
		PauseCantSendSmsTimer();
		return base.OnPaused();
	}

	public void OnSmsRecieved(string sms)
	{
		_onSmsReceivedAction?.Invoke(sms);
	}

	public void RequestPin()
	{
		AppAnalytics.AppMetrica.TrackEvent("phoneVerificationScreenButtonRepeatCode");
		_requestPinSubject.OnNext(Unit.Default);
	}

	public void OnDidntReceiveSmsClicked()
	{
		AppAnalytics.AppMetrica.TrackEvent("phoneVerificationScreenButtonHelp");
		OpenSupportCommand.Trigger(new DidntReceiveSmsViewModel.Parameter(Phone, _sendLogs));
	}

	public void CloseClicked()
	{
		AppAnalytics.AppMetrica.TrackEvent("phoneVerificationScreenButtonClose");
		OpenAuthOrRegisterCommand.Trigger();
	}

	public void CloseClickedAnalytics()
	{
		AppAnalytics.AppMetrica.TrackEvent("phoneVerificationScreenButtonClose");
	}

	private async Task VerifyPinAsync()
	{
		await Task.Delay(TimeSpan.FromMilliseconds(200L));
		State = VisualState.InProgress;
		Result<TokenModel, DomainError> result = await _tokenService.Token80ByPhone(Phone, PinText);
		if (result.IsSuccess)
		{
			_sendLogs = false;
			string phoneToken80 = result.Value.Token;
			AppMetrica.SpeedAuthorizationWatch.Start();
			Result<PhoneStatus, DomainError> verifyPinResult = await _pinInteractor.VerifyPin(phoneToken80);
			AppAnalytics.AppMetrica.SpeedAuthorizationEnd();
			if (verifyPinResult.IsSuccess)
			{
				await NavigateAfterLogin();
				AppAnalytics.AppMetrica.TrackEvent("authorisationPhoneVerification");
				if (verifyPinResult.Value != PhoneStatus.New)
				{
					AppAnalytics.Loymax.UserLogin();
				}
				return;
			}
			OnVerifyPinError(verifyPinResult.Error, phoneToken80);
		}
		else
		{
			OnVerifyPinError(result.Error);
		}
		State = VisualState.Default;
	}

	private void OnVerifyPinError(DomainError error, string? phoneToken80 = null)
	{
		ResetPinCommand.Trigger();
		_pinText = string.Empty;
		if (!_defaultPersonalCabinetErrorHandler.TryHandleError(error))
		{
			if (!(error is IncorrectPinError))
			{
				if (!(error is ExpiredPinError))
				{
					if (!(error is TemporarilyBlockedAccountError))
					{
						if (!(error is BlockedAccountError))
						{
							if (!(error is UpdateRequiredError updateRequiredError))
							{
								if (error is MissingToken80Error || error is AttributeError)
								{
									_sendLogs = true;
									_infoMessageService.ShowSnackbar("Произошла ошибка. Пожалуйста, повторите попытку позже.");
								}
								else
								{
									_infoMessageService.ShowSnackbar("Произошла ошибка. Пожалуйста, повторите попытку позже.");
								}
							}
							else
							{
								_hardUpdateManager.OnHardUpdateRequired(new HardUpdateViewModel.Parameter(updateRequiredError.Message));
							}
						}
						else
						{
							_infoMessageService.ShowBlockedAccountError();
						}
					}
					else
					{
						_infoMessageService.ShowSnackbar(error.Message);
					}
				}
				else
				{
					_infoMessageService.ShowSnackbar("Код устарел. Получите новый код подтверждения.");
				}
			}
			else
			{
				_infoMessageService.ShowSnackbar("Неверный код. Попробуйте еще раз.");
			}
		}
		AppAnalytics.AppMetrica.TrackEvent("authorisationError", ("errorId", error.GetType().Name + ": " + (error.Message ?? string.Empty)));
	}

	private async Task SendPinAsyncIfRetryCountIsNotExceeded()
	{
		if (_pinRetryFreezeManager.IsPinSendingBlocked())
		{
			SetRetryPinButtonTimer();
			return;
		}
		CanRequestPin = false;
		State = VisualState.InProgress;
		PinInteractor pinInteractor = _pinInteractor;
		string phone = Phone;
		_ = 1;
		Result<int, DomainError> result = await pinInteractor.SendPin(phone, !_deviceService.IsHuawei);
		CanRequestPin = result.IsFailure;
		if (result.IsFailure)
		{
			DomainError error = result.Error;
			if ((error is MissingToken80Error || error is AttributeError) ? true : false)
			{
				_sendLogs = true;
			}
			if (result.Error is UpdateRequiredError updateRequiredError)
			{
				_hardUpdateManager.OnHardUpdateRequired(new HardUpdateViewModel.Parameter(updateRequiredError.Message));
				return;
			}
			_defaultPersonalCabinetErrorHandler.HandleError(result.Error);
		}
		else
		{
			_sendLogs = false;
		}
		State = VisualState.Default;
		if (!CanRequestPin)
		{
			_pinRetryFreezeManager.PinRequestCountWasIncreased();
			SetRetryPinButtonTimer();
		}
	}

	private void OnResendSmsTimerTick(object? state)
	{
		Microsoft.Maui.ApplicationModel.MainThread.BeginInvokeOnMainThread(delegate
		{
			TimeSpan timeSpan = _cantSendSmsDueTime - DateTime.UtcNow;
			if (timeSpan > TimeSpan.Zero)
			{
				TimerText = timeSpan.GetLeftSecondsFormatted();
			}
			else if (_cantSendSmsDueTime != default(DateTime))
			{
				CanRequestPin = true;
				TimerText = TimeSpan.Zero.GetLeftSecondsFormatted();
				PauseCantSendSmsTimer();
				_cantSendSmsDueTime = default(DateTime);
			}
		});
	}

	private void StartCantSendSmsTimerIfNeed()
	{
		if (_cantSendSmsDueTime - DateTime.UtcNow > TimeSpan.Zero)
		{
			_cantSendSmsTimer?.Change(TimeSpan.Zero, TimeSpan.FromSeconds(1L));
		}
		else
		{
			OnResendSmsTimerTick(null);
		}
	}

	private void PauseCantSendSmsTimer()
	{
		_cantSendSmsTimer?.Change(0, -1);
	}

	private void SetRetryPinButtonTimer()
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(_pinRetryFreezeManager.GetSecondsToRetry());
		_cantSendSmsDueTime = DateTime.UtcNow + timeSpan;
		TimerText = timeSpan.GetLeftSecondsFormatted();
		StartCantSendSmsTimerIfNeed();
	}

	private async Task NavigateAfterLogin()
	{
		State = VisualState.InProgress;
		if (await _loyaltyCardManager.IsCardSilentRolloutNeeded())
		{
			if ((await _loyaltyCardManager.EnrollVirtualCard(LoyaltyEnrollmentRequestDto.ChannelDto.MobileApplication)).IsFailure)
			{
				_infoMessageService.ShowSnackbar("Произошла неизвестная ошибка");
			}
			_userContext.IsFirstTimeLogin = false;
			_infoMessageService.ShowHomePage();
			return;
		}
		switch (await _loyaltyCardManager.GetCardState())
		{
		case LoyaltyCardState.NotRollout:
			_userContext.IsSignupWasShown = true;
			OpenSignUpCommand.Trigger(new SignUpViewModel.Parameter(isLoyaltyTrigger: true));
			State = VisualState.Default;
			return;
		case LoyaltyCardState.Blocked:
			OpenCardBlockedCommand.Trigger();
			State = VisualState.Default;
			return;
		}
		await _userContext.LogIn();
		_userContext.IsFirstTimeLogin = false;
		Result<LoyaltyCardEntity, DomainError> result = await _loyaltyCardManager.GetLoyaltyCard(CancellationToken.None);
		if (result.IsSuccess)
		{
			await _trackingService.SetCustomer(_userContext.Profile, result.Value);
		}
		_infoMessageService.ShowHomePage();
	}

	public override void Dispose()
	{
		base.Dispose();
		_cantSendSmsTimer?.Dispose();
		_cantSendSmsTimer = null;
	}
}
