using System;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.BarcodeScanner;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.PriceChecker;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.LoyaltyProgram.ViewModels.CardRollout;

public class CardScannerViewModel : ScreenViewModel, IScannerViewModel
{
	private const int ShowScanMessageDelayMs = 2000;

	private readonly Subject<UserMessage> _showDialogError = new Subject<UserMessage>();

	private readonly Subject<string> _closeAndReturnResult = new Subject<string>();

	private readonly Subject<Unit> _enterManuallySubject = new Subject<Unit>();

	private readonly Lazy<ILogService> _logService;

	private bool _isScanSuccessfullyFinished;

	[CompilerGenerated]
	private bool _003CIsScanProcessing_003Ek__BackingField;

	[CompilerGenerated]
	private MessageState _003CScannerFrameState_003Ek__BackingField;

	[CompilerGenerated]
	private ScannerState _003CScannerState_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CHasCameraPermissions_003Ek__BackingField;

	public BarcodeType BarcodeType => BarcodeType.Qr;

	public string TopPrompt => "Добавьте карту";

	public string PromptAboveFocusWindow => "Отсканируйте QR-код\nна вашей карте АШАН";

	public string InvalidQrMessageText => "Не удалось отсканировать QR-код.\nПопробуйте еще раз.";

	public string SuccessfullyScannedMessageText => "QR-код отсканирован";

	public bool IsScanProcessing
	{
		[CompilerGenerated]
		get
		{
			return _003CIsScanProcessing_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsScanProcessing_003Ek__BackingField != value)
			{
				_003CIsScanProcessing_003Ek__BackingField = value;
				RaisePropertyChanged("IsScanProcessing");
			}
		}
	}

	public IObservable<UserMessage> ShowSnackBarMessage => _showDialogError;

	public IObservable<string> CloseAndPassResultBackCommand => _closeAndReturnResult.Debounce();

	public string NoCameraTitle => "Предоставьте доступ к камере";

	public IObservable<Unit> EnterManullyCommand => _enterManuallySubject.Debounce();

	public UICommand<string> BarcodeResultCommand { get; } = new UICommand<string>();

	public MessageState ScannerFrameState
	{
		[CompilerGenerated]
		get
		{
			return _003CScannerFrameState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CScannerFrameState_003Ek__BackingField != value)
			{
				_003CScannerFrameState_003Ek__BackingField = value;
				RaisePropertyChanged("ScannerFrameState");
			}
		}
	}

	public ScannerState ScannerState
	{
		[CompilerGenerated]
		get
		{
			return _003CScannerState_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CScannerState_003Ek__BackingField != value)
			{
				_003CScannerState_003Ek__BackingField = value;
				RaisePropertyChanged("ScannerState");
			}
		}
	}

	public string EnterManuallyText => "Ввести вручную";

	public bool HasCameraPermissions
	{
		[CompilerGenerated]
		get
		{
			return _003CHasCameraPermissions_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CHasCameraPermissions_003Ek__BackingField != value)
			{
				_003CHasCameraPermissions_003Ek__BackingField = value;
				RaisePropertyChanged("HasCameraPermissions");
			}
		}
	}

	public CardScannerViewModel(Lazy<ILogService> logService)
	{
		_logService = logService;
		BarcodeResultCommand.PerformDebouncingTask(OnBarcodeResult).Subscribe().AddTo(base.CloseDisposable);
	}

	public void OnDialogErrorOkClicked()
	{
		throw new NotImplementedException();
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		HasCameraPermissions = await Permissions.CheckStatusAsync<Permissions.Camera>() == PermissionStatus.Granted;
		ScannerState = (HasCameraPermissions ? ScannerState.Enabled : ScannerState.Disabled);
	}

	protected override async Task OnPaused()
	{
		if (ScannerState == ScannerState.Enabled)
		{
			ScannerState = ScannerState.Disabled;
		}
		await base.OnPaused();
	}

	public async Task OnBarcodeResult(string qrCode)
	{
		if (!_isScanSuccessfullyFinished && !IsScanProcessing)
		{
			ScannerState = ScannerState.Disabled;
			IsScanProcessing = true;
			bool flag = false;
			try
			{
				flag = qrCode.IsCardNumberFormat();
			}
			catch (Exception ex)
			{
				DevAnalytics.Report("Failed to scan card", ex);
			}
			if (!flag)
			{
				await ShowInvalidQrMessage();
				IsScanProcessing = false;
				ScannerState = ScannerState.Enabled;
			}
			else
			{
				await ShowSuccessfullyScannedMessage();
				_closeAndReturnResult.OnNext(qrCode);
				_isScanSuccessfullyFinished = true;
				ScannerState = ScannerState.Enabled;
				IsScanProcessing = false;
			}
		}
	}

	private async Task ShowInvalidQrMessage()
	{
		AppAnalytics.AppMetrica.ScanLoyaltyError();
		ScannerFrameState = MessageState.Red;
		RaisePropertyChanged("ScannerFrameState");
		_showDialogError.OnNext(new UserMessage
		{
			MessageState = ScannerFrameState,
			Message = InvalidQrMessageText
		});
		await WaitAndRestoreDefaultFrame();
	}

	private async Task ShowSuccessfullyScannedMessage()
	{
		AppAnalytics.AppMetrica.ScanLoyaltySuccess();
		ScannerFrameState = MessageState.Green;
		RaisePropertyChanged("ScannerFrameState");
		_showDialogError.OnNext(new UserMessage
		{
			MessageState = ScannerFrameState,
			Message = SuccessfullyScannedMessageText
		});
		await WaitAndRestoreDefaultFrame();
	}

	private async Task WaitAndRestoreDefaultFrame()
	{
		await Task.Delay(2000);
		ScannerFrameState = MessageState.Default;
		RaisePropertyChanged("ScannerFrameState");
		_showDialogError.OnNext(new UserMessage
		{
			MessageState = ScannerFrameState
		});
	}

	public void EnterManually()
	{
		AppAnalytics.AppMetrica.ScanLoyaltyManualInput();
		_enterManuallySubject.OnNext(Unit.Default);
	}

	public void OnPlatformError(string description, Exception ex)
	{
		_logService.Value.LogError("CardScannerViewModel", $"{description} {ex}", LogType.UserAction, SystemType.SelfScanning);
	}
}
