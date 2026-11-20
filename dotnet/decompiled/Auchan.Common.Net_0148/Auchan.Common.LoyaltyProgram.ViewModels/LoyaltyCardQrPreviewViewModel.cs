using System;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cashback.Wallet;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel.DataTransfer;

namespace Auchan.Common.LoyaltyProgram.ViewModels;

public class LoyaltyCardQrPreviewViewModel : ScreenViewModel
{
	public class Parameter
	{
		public readonly OpenedFrom From;

		public Parameter(OpenedFrom from)
		{
			From = from;
		}
	}

	public enum OpenedFrom
	{
		ErrorScreen,
		HomeTab,
		LoyaltyTab
	}

	public enum VisualState
	{
		Default,
		InProgress
	}

	private readonly ILoyaltyCardManager _loyaltyCardManager;

	private readonly IUserContext _userContext;

	private readonly IWalletManager _walletManager;

	private readonly IInfoMessageService _infoMessageService;

	private CancellationTokenSource _cts;

	private bool _saveToWalletEnabled;

	private Parameter _parameter;

	[CompilerGenerated]
	private UICommand _003CCloseCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CShowAdvantagesCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CSaveToWalletCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003COpenDetailsCommand_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003COpenEmployeeDetailsCommand_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsNotInternetConnectionVisible_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CQrCode_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsEmployee_003Ek__BackingField;

	public UICommand CloseCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CCloseCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CCloseCommand_003Ek__BackingField, value))
			{
				_003CCloseCommand_003Ek__BackingField = value;
				RaisePropertyChanged("CloseCommand");
			}
		}
	} = new UICommand();

	public UICommand ShowAdvantagesCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CShowAdvantagesCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CShowAdvantagesCommand_003Ek__BackingField, value))
			{
				_003CShowAdvantagesCommand_003Ek__BackingField = value;
				RaisePropertyChanged("ShowAdvantagesCommand");
			}
		}
	} = new UICommand();

	public UICommand SaveToWalletCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CSaveToWalletCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CSaveToWalletCommand_003Ek__BackingField, value))
			{
				_003CSaveToWalletCommand_003Ek__BackingField = value;
				RaisePropertyChanged("SaveToWalletCommand");
			}
		}
	} = new UICommand();

	public UICommand OpenDetailsCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenDetailsCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COpenDetailsCommand_003Ek__BackingField, value))
			{
				_003COpenDetailsCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenDetailsCommand");
			}
		}
	} = new UICommand();

	public UICommand OpenEmployeeDetailsCommand
	{
		[CompilerGenerated]
		get
		{
			return _003COpenEmployeeDetailsCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003COpenEmployeeDetailsCommand_003Ek__BackingField, value))
			{
				_003COpenEmployeeDetailsCommand_003Ek__BackingField = value;
				RaisePropertyChanged("OpenEmployeeDetailsCommand");
			}
		}
	} = new UICommand();

	public UICommand CopyCardNumberCommand { get; } = new UICommand();

	public string ScreenTitle => "Карта АШАН";

	public string YourLoyaltyCard => "Ваша карта лояльности";

	public string CardAdvantages => "Преимущества вашей карты АШАН >";

	public bool IsNotInternetConnectionVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsNotInternetConnectionVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsNotInternetConnectionVisible_003Ek__BackingField != value)
			{
				_003CIsNotInternetConnectionVisible_003Ek__BackingField = value;
				RaisePropertyChanged("SaveToWalletEnabled");
				RaisePropertyChanged("IsNotInternetConnectionVisible");
			}
		}
	}

	public string NoInternetConnectionTitle => "Отсутствует подключение к интернету";

	public string NoInternetConnectionDescription => "В данный момент списание баллов недоступно, но баллы за покупку будут начислены.";

	public bool IsCardBlocked
	{
		get
		{
			LoyaltyCardEntity? loyaltyCard = LoyaltyCard;
			if (loyaltyCard == null)
			{
				return false;
			}
			return loyaltyCard.CardStatus == LoyaltyCardStatus.Blocked;
		}
	}

	public string CardIsBlockedText => "Карта заблокирована";

	public string YourCardNumber => "Номер вашей карты лояльности";

	public string CardNumber => LoyaltyCard?.CardNumber?.GetCardNumberFormatted() ?? string.Empty;

	public string QrCode
	{
		[CompilerGenerated]
		get
		{
			return _003CQrCode_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CQrCode_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CQrCode_003Ek__BackingField = value;
				RaisePropertyChanged("QrCode");
			}
		}
	} = "";

	public string CloseButtonText => "Закрыть";

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

	public bool IsEmployee
	{
		[CompilerGenerated]
		get
		{
			return _003CIsEmployee_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsEmployee_003Ek__BackingField != value)
			{
				_003CIsEmployee_003Ek__BackingField = value;
				RaisePropertyChanged("IsEmployee");
			}
		}
	}

	public bool SaveToWalletEnabled
	{
		get
		{
			if (_saveToWalletEnabled)
			{
				return !IsNotInternetConnectionVisible;
			}
			return false;
		}
	}

	private LoyaltyCardEntity? LoyaltyCard => _userContext.LoyaltyCard;

	public LoyaltyCardQrPreviewViewModel(IUserContext userContext, ILoyaltyCardManager loyaltyCardManager, IWalletManager walletManager, IInfoMessageService infoMessageService, Parameter? parameter = null)
	{
		_parameter = parameter ?? new Parameter(OpenedFrom.ErrorScreen);
		_userContext = userContext;
		_loyaltyCardManager = loyaltyCardManager;
		_walletManager = walletManager;
		_infoMessageService = infoMessageService;
		_cts = new CancellationTokenSource();
		IsEmployee = _userContext.Profile.IsAuchanEmployee;
		CloseCommand.Subscribe(delegate
		{
			StopScreenProcesses();
		}).AddTo(base.CloseDisposable);
		ShowAdvantagesCommand.Subscribe(delegate
		{
			StopScreenProcesses();
			if (IsEmployee)
			{
				OpenEmployeeDetailsCommand.Trigger();
			}
			else
			{
				OpenDetailsCommand.Trigger();
			}
		}).AddTo(base.CloseDisposable);
		SaveToWalletCommand.PerformDebouncingTask((Unit _) => SaveToWallet()).Subscribe().AddTo(base.CloseDisposable);
		CopyCardNumberCommand.Subscribe(OnCopyNumberCommand).AddTo(base.CloseDisposable);
	}

	public void ShowAdvantages()
	{
		if (_parameter.From == OpenedFrom.HomeTab)
		{
			AppAnalytics.AppMetrica.TrackEvent("TapMainOnDetails");
		}
		if (_parameter.From == OpenedFrom.LoyaltyTab)
		{
			AppAnalytics.AppMetrica.TrackEvent("TapLoyaltyOnDetails");
		}
		ShowAdvantagesCommand.Trigger();
	}

	protected override async Task Start()
	{
		await base.Start();
		await LoadQrCode();
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		AppAnalytics.AppMetrica.OpenQrTapped(_parameter.From);
		_saveToWalletEnabled = await _walletManager.CanAddLoyaltyQr();
		RaisePropertyChanged("SaveToWalletEnabled");
	}

	private async Task SaveToWallet()
	{
		State = VisualState.InProgress;
		bool num = await _walletManager.AddLoyaltyQr();
		State = VisualState.Default;
		if (!num)
		{
			_infoMessageService.ShowSnackbar("Сохранение не удалось. Попробуйте снова");
		}
	}

	private async Task LoadQrCode()
	{
		await LoadCachedQrCode();
		_ = IsCardBlocked;
	}

	private async Task LoadCachedQrCode()
	{
		Result<LoyaltyCardEntity, DomainError> result = await _loyaltyCardManager.GetLoyaltyCard(_cts.Token);
		if (result.IsSuccess)
		{
			IsNotInternetConnectionVisible = false;
			RaisePropertyChanged("IsNotInternetConnectionVisible");
			RaisePropertyChanged("SaveToWalletEnabled");
			QrCode = result.Value.QrCode ?? string.Empty;
		}
		else if (result.IsFailure && result.Error is ConnectionError)
		{
			IsNotInternetConnectionVisible = true;
			RaisePropertyChanged("IsNotInternetConnectionVisible");
			RaisePropertyChanged("SaveToWalletEnabled");
		}
	}

	private void StopScreenProcesses()
	{
		_cts.Cancel();
	}

	private void OnCopyNumberCommand(Unit unit)
	{
		AppAnalytics.AppMetrica.TrackEvent("TapCopyCard");
		Clipboard.SetTextAsync(CardNumber).SafeFireAndForget((Action<Exception>)null, false);
		_infoMessageService.ShowVerticalSnackbar("Номер карты скопирован", SnackbarStyle.Success);
	}
}
