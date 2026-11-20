using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.Navigation;
using Auchan.Common.PersonalCabinet.Errors;
using Auchan.Common.PersonalCabinet.Interactors;
using Auchan.Common.Sms;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile;

[RequiresAuthorization]
public class EnterPinToUpdatePhoneViewModel : ScreenViewModel, ISmsRetrieverListener
{
	public class Parameter
	{
		public string? PhoneNumber { get; set; }

		public bool NeedHash { get; set; }
	}

	public class Result
	{
		public bool WasPhoneChanged { get; set; }

		public Result(bool wasPhoneChanged)
		{
			WasPhoneChanged = wasPhoneChanged;
		}
	}

	private readonly IInfoMessageService _infoMessageService;

	private readonly PinInteractor _pinInteractor;

	private readonly DefaultPersonalCabinetErrorHandler _defaultPersonalCabinetErrorHandler;

	private readonly ISmsRetriever _smsRetriever;

	private readonly Subject<Result> _onClose = new Subject<Result>();

	private string _pinText = string.Empty;

	private Result _result = new Result(wasPhoneChanged: false);

	[CompilerGenerated]
	private string _003CPhoneText_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CTimerText_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsGetPinButtonEnabled_003Ek__BackingField;

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
				RaisePropertyChanged("Hint");
				RaisePropertyChanged("PhoneText");
			}
		}
	}

	public bool NeedHash { get; }

	public AttributedText Hint => new AttributedText("На номер {0} отправлен код подтверждения", PhoneHelper.FormatPhone(PhoneText));

	public string PlaceholderString => "Код подтверждения";

	public string EnterString => "Готово";

	public string HelperText => "Повторный запрос кода возможен через 60 секунд";

	public string ButtonTitle
	{
		get
		{
			if (!IsGetPinButtonEnabled)
			{
				return "Запросить через " + TimerText;
			}
			return "Отправить код еще раз";
		}
	}

	public string? TimerText
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
				RaisePropertyChanged("ButtonTitle");
				RaisePropertyChanged("TimerText");
			}
		}
	}

	public IObservable<Result> CloseCommand => _onClose.Debounce();

	public string PinText
	{
		get
		{
			return _pinText;
		}
		set
		{
			_pinText = ((value.Length > 4) ? value.Substring(0, 4) : value);
			RaisePropertyChanged("PinText");
		}
	}

	public static int PinLength => 4;

	public bool IsGetPinButtonEnabled
	{
		[CompilerGenerated]
		get
		{
			return _003CIsGetPinButtonEnabled_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsGetPinButtonEnabled_003Ek__BackingField != value)
			{
				_003CIsGetPinButtonEnabled_003Ek__BackingField = value;
				RaisePropertyChanged("ButtonTitle");
				RaisePropertyChanged("IsGetPinButtonEnabled");
			}
		}
	}

	public string Title => "Введите код";

	public EnterPinToUpdatePhoneViewModel(IInfoMessageService infoMessageService, Parameter parameter, PinInteractor pinInteractor, DefaultPersonalCabinetErrorHandler defaultPersonalCabinetErrorHandler, ISmsRetriever smsRetriever, IDeviceService deviceService)
	{
		_infoMessageService = infoMessageService;
		_pinInteractor = pinInteractor;
		_defaultPersonalCabinetErrorHandler = defaultPersonalCabinetErrorHandler;
		_smsRetriever = smsRetriever;
		PhoneText = parameter.PhoneNumber;
		_ = 1;
		NeedHash = !deviceService.IsHuawei;
		ResetPinGettingState();
		(from p in this.OnPropertyChanges((EnterPinToUpdatePhoneViewModel p) => p.PinText)
			where p.Length == 4
			select p).PerformSamplingTask(SendPinAsync).Subscribe();
	}

	protected override async Task Start()
	{
		await base.Start();
		_smsRetriever.AddListener(this).AddTo(base.CloseDisposable);
		await _smsRetriever.Prepare();
		await GetPinAsync();
	}

	public async Task GetPinAsync()
	{
		if (!IsGetPinButtonEnabled)
		{
			YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
			_ = awaiter.IsCompleted;
			await awaiter;
			YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
			awaiter = yieldAwaiter;
			awaiter.GetResult();
		}
		IsGetPinButtonEnabled = false;
		Result<int, DomainError> result = await _pinInteractor.SendPin(PhoneText, NeedHash);
		if (result.IsFailure)
		{
			if (_defaultPersonalCabinetErrorHandler.TryHandleError(result.Error))
			{
				return;
			}
			if (result.Error is PhoneOfAnotherAccountError)
			{
				_infoMessageService.ShowSnackbar("Пользователь с таким номером уже существует.");
			}
			else
			{
				_infoMessageService.ShowSnackbar("Произошла ошибка. Пожалуйста, повторите попытку позже.");
			}
		}
		Observable.Interval(TimeSpan.FromSeconds(1L)).Take(60).Finally(ResetPinGettingState)
			.Subscribe(delegate(long t)
			{
				TimerText = TimeSpan.FromSeconds(60 - t - 1).ToString("mm\\:ss");
			})
			.AddTo(base.CloseDisposable);
	}

	private async Task SendPinAsync()
	{
		await VerifyPhoneAsync();
	}

	private void ResetPinGettingState()
	{
		IsGetPinButtonEnabled = true;
		TimerText = TimeSpan.FromSeconds(60L).ToString("mm\\:ss");
	}

	private async Task VerifyPhoneAsync()
	{
		var (_, flag3, _, domainError2) = await _pinInteractor.VerifyPhoneNumber(PhoneText, PinText);
		if (flag3)
		{
			if (_defaultPersonalCabinetErrorHandler.TryHandleError(domainError2))
			{
				return;
			}
			if (!(domainError2 is IncorrectPinError))
			{
				if (!(domainError2 is ExpiredPinError))
				{
					if (domainError2 is PhoneOfAnotherAccountError)
					{
						_infoMessageService.ShowSnackbar("Пользователь с таким номером уже существует.");
					}
					else
					{
						_infoMessageService.ShowSnackbar("Произошла ошибка. Пожалуйста, повторите попытку позже.");
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
		else
		{
			Close(successful: true);
		}
	}

	private void Close(bool successful = false)
	{
		_onClose.OnNext(new Result(successful));
	}

	public void ClosePage()
	{
		Close();
	}

	public void OnSmsRecieved(string sms)
	{
		PinText = sms.Substring(0, 4);
	}
}
