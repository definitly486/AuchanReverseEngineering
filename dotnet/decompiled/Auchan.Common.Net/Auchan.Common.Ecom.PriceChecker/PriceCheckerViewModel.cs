using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.BarcodeScanner;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.DynamicFeedback;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.PriceChecker.Dto;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Logs;
using Auchan.Common.Navigation;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices;

namespace Auchan.Common.Ecom.PriceChecker;

public class PriceCheckerViewModel : ScreenViewModel, IScannerViewModel
{
	private readonly PriceChecker _priceChecker;

	private readonly PriceCheckerService _priceCheckerService;

	private readonly ILogService _logService;

	private readonly IAdminContext _adminContext;

	private readonly IUserContext _userContext;

	private readonly IDataBroker _dataBroker;

	private readonly IPriceCheckerContext _priceCheckerContext;

	[CompilerGenerated]
	private Store? _003CCurrentStore_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CSuccessScanIndicatorEnabled_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CFlashEnabled_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CThrobberEnabled_003Ek__BackingField;

	[CompilerGenerated]
	private ScannerState _003CScannerState_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CHasCameraPermissions_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsWarningVisible_003Ek__BackingField;

	private readonly TaskQueue _scannedQueue = new TaskQueue();

	public Store? CurrentStore
	{
		[CompilerGenerated]
		get
		{
			return _003CCurrentStore_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CCurrentStore_003Ek__BackingField, value))
			{
				_003CCurrentStore_003Ek__BackingField = value;
				RaisePropertyChanged("AddressTopTitle");
				RaisePropertyChanged("CurrentStore");
			}
		}
	}

	public string AddressTopTitle => CurrentStore?.Name ?? "";

	public string ScanPromptText => "Для сканирования поместите штрихкод в рамку";

	public string ScanErrorText => "Штрих-код товара не найден. Пожалуйста, обратитесь к сотруднику магазина.";

	public string EnterBarcodeButton => "Ввести штрихкод";

	public string NoCameraTitle => "Предоставьте доступ к камере";

	public string NoCameraSubtitle => "Вы сможете быстро узнать цену на\nтовар и добавить его в корзину";

	public string NoCameraSettings => "Открыть настройки";

	public bool SuccessScanIndicatorEnabled
	{
		[CompilerGenerated]
		get
		{
			return _003CSuccessScanIndicatorEnabled_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CSuccessScanIndicatorEnabled_003Ek__BackingField != value)
			{
				_003CSuccessScanIndicatorEnabled_003Ek__BackingField = value;
				RaisePropertyChanged("SuccessScanIndicatorEnabled");
			}
		}
	}

	public bool FlashEnabled
	{
		[CompilerGenerated]
		get
		{
			return _003CFlashEnabled_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CFlashEnabled_003Ek__BackingField != value)
			{
				_003CFlashEnabled_003Ek__BackingField = value;
				RaisePropertyChanged("FlashEnabled");
			}
		}
	}

	public bool ThrobberEnabled
	{
		[CompilerGenerated]
		get
		{
			return _003CThrobberEnabled_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CThrobberEnabled_003Ek__BackingField != value)
			{
				_003CThrobberEnabled_003Ek__BackingField = value;
				RaisePropertyChanged("ThrobberEnabled");
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
		private set
		{
			if (_003CScannerState_003Ek__BackingField != value)
			{
				_003CScannerState_003Ek__BackingField = value;
				RaisePropertyChanged("ScannerState");
			}
		}
	}

	public bool HasCameraPermissions
	{
		[CompilerGenerated]
		get
		{
			return _003CHasCameraPermissions_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CHasCameraPermissions_003Ek__BackingField != value)
			{
				_003CHasCameraPermissions_003Ek__BackingField = value;
				RaisePropertyChanged("HasCameraPermissions");
			}
		}
	}

	public BarcodeType BarcodeType => BarcodeType.Ean13;

	public bool IsWarningVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsWarningVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsWarningVisible_003Ek__BackingField != value)
			{
				_003CIsWarningVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsWarningVisible");
			}
		}
	}

	public UICommand<BrokerToken> OpenAddressCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<BrokerToken> ShowManualViewCommand { get; } = new UICommand<BrokerToken>();

	public UICommand SendInfoAfterOpenPricecheckerCommand { get; } = new UICommand();

	public UICommand<BrokerToken> ShowProductCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<ProductDetailsViewModel.Parameter> ShowProductDetailsCommand { get; } = new UICommand<ProductDetailsViewModel.Parameter>();

	public UICommand<DynamicFeedbackViewModel.Parameter> NavigateToFeedback { get; } = new UICommand<DynamicFeedbackViewModel.Parameter>();

	public UICommand CancelPriceCheckerCommand { get; } = new UICommand();

	public UICommand<string> BarcodeResultCommand { get; } = new UICommand<string>();

	public UICommand<BrokerToken> ShowBarcodeNotFoundCommand { get; } = new UICommand<BrokerToken>();

	public PriceCheckerViewModel(PriceChecker priceChecker, PriceCheckerService priceCheckerService, ILogService logService, IAdminContext adminContext, IUserContext userContext, IDataBroker dataBroker, IPriceCheckerContext priceCheckerContext)
	{
		_priceChecker = priceChecker;
		_priceCheckerService = priceCheckerService;
		_logService = logService;
		_adminContext = adminContext;
		_userContext = userContext;
		_dataBroker = dataBroker;
		_priceCheckerContext = priceCheckerContext;
		SendInfoAfterOpenPricecheckerCommand.PerformDebouncingTask(SendInfoAfterOpenPricechecker).Subscribe().AddTo(base.CloseDisposable);
		BarcodeResultCommand.PerformDebouncingTask(OnBarcodeResult).Subscribe().AddTo(base.CloseDisposable);
		CancelPriceCheckerCommand.Subscribe(delegate
		{
			ScannerState = ScannerState.Disabled;
		}).AddTo(base.CloseDisposable);
		TabBarVisible = false;
	}

	protected override async Task Start()
	{
		await base.Start();
		CurrentStore = _priceCheckerContext.SavedStore;
		_logService.LogInfo("PriceCheckerViewModel", "Открыт PriceChecker", LogType.UserAction, SystemType.MobileApp);
		if (CurrentStore == null)
		{
			YieldAwaitable.YieldAwaiter awaiter = Task.Yield().GetAwaiter();
			_ = awaiter.IsCompleted;
			await awaiter;
			YieldAwaitable.YieldAwaiter yieldAwaiter = default(YieldAwaitable.YieldAwaiter);
			awaiter = yieldAwaiter;
			awaiter.GetResult();
			await OpenAddressAsync();
			if (CurrentStore == null)
			{
				CancelPriceCheckerCommand.Trigger();
				return;
			}
		}
		SendInfoAfterOpenPricecheckerCommand.Trigger();
		await RequestCameraPermissions();
		if (HasCameraPermissions)
		{
			ScannerState = ScannerState.Enabled;
		}
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		HasCameraPermissions = await Permissions.CheckStatusAsync<Permissions.Camera>() == PermissionStatus.Granted;
		if (HasCameraPermissions)
		{
			ScannerState = ScannerState.Enabled;
		}
	}

	private async Task SendInfoAfterOpenPricechecker()
	{
		if (CurrentStore != null && (_adminContext.AppConfig?.PriceCheckerMWEventsEnabled ?? false))
		{
			PriceCheckerMiddleWareEventDtoAfterOpenPricechecker requestDto = new PriceCheckerMiddleWareEventDtoAfterOpenPricechecker
			{
				Name = "price_check_login",
				ValueDto = new ValueAfterOpenPricecheckerDto
				{
					ClientId = (_userContext.Profile?.ClientAccountId ?? string.Empty),
					StoreId = CurrentStore.Id.ToString(),
					Device = DeviceInfo.Model,
					OperatingSystem = DeviceInfo.Platform.ToString() + " " + DeviceInfo.VersionString
				}
			};
			await _priceCheckerService.Events(requestDto);
		}
	}

	public void OnAddressClicked()
	{
		OpenAddressAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task OpenAddressAsync()
	{
		PriceCheckerAddressViewModel.Parameter parameter = new PriceCheckerAddressViewModel.Parameter();
		OpenAddressCommand.Trigger(_dataBroker.Push(parameter));
		PriceCheckerAddressViewModel.Result result = await parameter;
		if (result != null)
		{
			CurrentStore = result.Store;
		}
	}

	protected override async Task OnPaused()
	{
		if (ScannerState == ScannerState.Enabled)
		{
			ScannerState = ScannerState.Disabled;
		}
		await base.OnPaused();
	}

	private async Task RequestCameraPermissions()
	{
		if (CurrentStore != null)
		{
			HasCameraPermissions = await Permissions.RequestAsync<Permissions.Camera>() == PermissionStatus.Granted;
		}
	}

	private Task OnBarcodeResult(string barcode)
	{
		if (!_scannedQueue.HasRunningTasks)
		{
			_scannedQueue.Enqueue(() => ValidateProduct(barcode)).SafeFireAndForget((Action<Exception>)null, false);
		}
		return Task.CompletedTask;
	}

	public void OnAddManualClicked()
	{
		DoAsync().SafeFireAndForget((Action<Exception>)null, false);
		async Task DoAsync()
		{
			if (CurrentStore != null)
			{
				PauseScannerAnalysis();
				ManualBarcodeViewModel.Parameter parameter = new ManualBarcodeViewModel.Parameter
				{
					Store = CurrentStore
				};
				ShowManualViewCommand.Trigger(_dataBroker.Push(parameter));
				await ProcessValidationResult(await parameter);
			}
		}
	}

	private async Task ProcessValidationResult(Result<ValidationResult, ValidationError> validationResult)
	{
		ValidationError error;
		if (validationResult.TryGetValue(out ValidationResult value))
		{
			IsWarningVisible = false;
			if (value.IsOnline)
			{
				ShowProductDetailsCommand.Trigger(new ProductDetailsViewModel.Parameter
				{
					Product = value.Product,
					ForCase = ProductDetailsViewModel.ForCase.PriceChecker
				});
			}
			else
			{
				ProductMiniViewModel.Parameter parameter = new ProductMiniViewModel.Parameter
				{
					Product = value.Product
				};
				ShowProductCommand.Trigger(_dataBroker.Push(parameter));
				ProcessMiniProductResult(await parameter);
			}
		}
		else if (validationResult.TryGetError(out error))
		{
			if (!string.IsNullOrEmpty(error.Barcode))
			{
				IsWarningVisible = true;
				await Task.Delay(3000);
				IsWarningVisible = false;
			}
			StartScannerAnalysis();
		}
	}

	private void ProcessMiniProductResult(ProductMiniViewModel.Result result)
	{
		StartScannerAnalysis();
		if (result == ProductMiniViewModel.Result.NavigateToFeedback)
		{
			NavigateToFeedback.Trigger(new DynamicFeedbackViewModel.Parameter(FeedbackState.WithTopicAndCategory, ForCase.PriceChecker));
		}
	}

	public void OnDialogErrorOkClicked()
	{
		PauseScannerAnalysis();
		SuccessScanIndicatorEnabled = false;
		ThrobberEnabled = false;
	}

	public void PauseScannerAnalysis()
	{
		ScannerState = ScannerState.Disabled;
	}

	public void StartScannerAnalysis()
	{
		ScannerState = ScannerState.Enabled;
	}

	private async Task ValidateProduct(string barcode)
	{
		if (CurrentStore == null)
		{
			throw new InvalidOperationException("Store is not set. Dead code.");
		}
		Vibration.Vibrate(200.0);
		ScannerState = ScannerState.Disabled;
		await ProcessValidationResult(await _priceChecker.Validate(CurrentStore, barcode));
	}

	public override NavigationPossibilityType OnNavigateFrom()
	{
		CancelPriceCheckerCommand.Trigger();
		return NavigationPossibilityType.Delayed;
	}

	public void OnPlatformError(string description, Exception ex)
	{
		_logService.LogError("PriceCheckerViewModel", $"{description} {ex}", LogType.UserAction, SystemType.SelfScanning);
	}
}
