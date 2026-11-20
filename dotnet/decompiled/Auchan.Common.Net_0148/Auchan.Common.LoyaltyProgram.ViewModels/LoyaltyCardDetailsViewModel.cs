using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cashback.Wallet;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Feedback;
using Auchan.Common.InfoPages;
using Auchan.Common.Logs;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.Navigation;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.ViewModels;

public class LoyaltyCardDetailsViewModel : ScreenViewModel
{
	private const int RefreshQrIntervalMs = 180000;

	private readonly INavigationService _navigationService;

	private readonly ILoyaltyCardManager _loyaltyCardManager;

	private readonly IUserContext _userContext;

	private readonly ILogService _logService;

	private readonly IWalletManager _walletManager;

	private readonly IInfoMessageService _infoMessageService;

	private readonly IFeedbackContactsProvider _feedbackContactsProvider;

	private CancellationTokenSource? _cts;

	private System.Timers.Timer? _timer;

	private bool _saveToWalletEnabled;

	private readonly Subject<Unit> _navigateToCantScan = new Subject<Unit>();

	private readonly Subject<Unit> _navigateToCardBlockOptions = new Subject<Unit>();

	private readonly Subject<InfoPageViewModel.Parameter> _navigateToLoyaltyRules = new Subject<InfoPageViewModel.Parameter>();

	private readonly Subject<Unit> _close = new Subject<Unit>();

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CQrCode_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsNotInternetConnectionVisible_003Ek__BackingField;

	public IObservable<Unit> NavigateToCantScanCommand => _navigateToCantScan.Debounce();

	public IObservable<Unit> NavigateToCardBlockOptionsCommand => _navigateToCardBlockOptions.Debounce();

	public IObservable<InfoPageViewModel.Parameter> NavigateToLoyaltyRulesCommand => _navigateToLoyaltyRules.Debounce();

	public IObservable<Unit> CloseCommand => _close.Debounce();

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

	public string ScreenTitle => "Подробнее о карте АШАН";

	public string CardNumberLabel
	{
		get
		{
			if (!IsCardBlocked)
			{
				return "Номер вашей карты";
			}
			return "Карта заблокирована";
		}
	}

	public string CardNumber => "№ " + ((LoyaltyCard?.CardNumber)?.GetCardNumberFormatted() ?? string.Empty);

	public string? QrCode
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
	}

	public string BlockCardLabel => "Заблокировать карту";

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

	public string CallCenterPhone => _feedbackContactsProvider.Phone.GetPhoneNumberFormatted(withDashes: true);

	public string CallCenterDescription => "Телефон контактного центра АШАН\nКруглосуточно, бесплатно по России";

	public string CantScanQrTitle => "Не считывается карта лояльности?";

	public string CantScanQrDescription => "Свяжитесь с нами удобным способом и сообщите о проблеме";

	public string PointsIncomeRulesTitle => "Получайте кешбэк баллами";

	public string PointsIncomeRules => "- Возвращаем баллами до 70% от стоимости товаров со специальными ценниками" + "\n" + "\n" + "- Начисляем эксклюзивные 5% за товары с фирменной птичкой АШАН красного и золотого цвета";

	public string PointsSpendingRulesTitle => "Тратьте баллы";

	public string PointsSpendingRules => "- Оплачивайте до 99% стоимости покупок баллами" + "\n" + "\n" + "- 1 балл = 1 рубль";

	public string LoyaltyProgramRulesLabel => "Правила программы Лояльности";

	public string CardIsBlockedLabel => "Карта заблокирована";

	public bool SaveToWalletEnabled
	{
		get
		{
			if (_saveToWalletEnabled && !IsCardBlocked)
			{
				return !IsNotInternetConnectionVisible;
			}
			return false;
		}
	}

	protected override string ScreenName => "loyalty_card_details";

	private LoyaltyCardEntity? LoyaltyCard => _userContext.LoyaltyCard;

	public LoyaltyCardDetailsViewModel(INavigationService navigationService, IUserContext userContext, ILoyaltyCardManager loyaltyCardManager, ILogService logService, IWalletManager walletManager, IInfoMessageService infoMessageService, IFeedbackContactsProvider feedbackContactsProvider)
	{
		_navigationService = navigationService;
		_userContext = userContext;
		_loyaltyCardManager = loyaltyCardManager;
		_logService = logService;
		_walletManager = walletManager;
		_infoMessageService = infoMessageService;
		_feedbackContactsProvider = feedbackContactsProvider;
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		_logService.LogInfo("LoyaltyCardDetailsViewModel", "Открыт экран деталей карты лояльности", LogType.UserAction, SystemType.MobileApp);
		_saveToWalletEnabled = await _walletManager.CanAddLoyaltyQr();
		RaisePropertyChanged("SaveToWalletEnabled");
		Result<LoyaltyCardEntity, DomainError> result = await _loyaltyCardManager.GetLoyaltyCard(CancellationToken.None);
		if (result.IsSuccess)
		{
			QrCode = result.Value.QrCode ?? string.Empty;
		}
	}

	public async Task OnSaveToWalletClick()
	{
		State = VisualState.InProgress;
		AppAnalytics.AppMetrica.AddLoyaltyCardToWallet();
		bool num = await _walletManager.AddLoyaltyQr();
		State = VisualState.Default;
		if (num)
		{
			_saveToWalletEnabled = await _walletManager.CanAddLoyaltyQr();
			RaisePropertyChanged("SaveToWalletEnabled");
		}
		else
		{
			_infoMessageService.ShowSnackbar("Сохранение не удалось. Попробуйте снова");
		}
	}

	public void OnCallCenterButtonClick()
	{
		_navigationService.CallToAuchanSupport();
	}

	public void OnCantScanQrButtonClick()
	{
		_navigateToCantScan.OnNext(Unit.Default);
	}

	public void OnBlockCardSelected()
	{
		_userContext.OnPropertyChanges((IUserContext x) => x.LoyaltyCard).StartWith(_userContext.LoyaltyCard).Subscribe(delegate
		{
			RaisePropertyChanged("IsCardBlocked");
			RaisePropertyChanged("CardIsBlockedLabel");
			RaisePropertyChanged("CardNumberLabel");
			RaisePropertyChanged("SaveToWalletEnabled");
		})
			.AddTo(base.CloseDisposable);
		_navigateToCardBlockOptions.OnNext(Unit.Default);
	}

	public void OnLoyaltyProgramRulesClickAsync()
	{
		AppAnalytics.AppMetrica.OpenLoyaltyRules();
		_navigateToLoyaltyRules.OnNext(new InfoPageViewModel.Parameter(InfoType.LoyaltyPolicy));
	}

	public void OnClose()
	{
		_close.OnNext(Unit.Default);
	}
}
