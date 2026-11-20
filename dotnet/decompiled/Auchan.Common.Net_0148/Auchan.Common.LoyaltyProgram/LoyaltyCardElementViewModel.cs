using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common.Binding;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.InfoPages;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase;
using Auchan.Common.LoyaltyProgram.ViewModels.NewLoyaltyCard;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsExpiration;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Authorization.Managers;
using Auchan.Common.UniversalLinks;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.LoyaltyProgram;

public class LoyaltyCardElementViewModel : ElementViewModel
{
	private readonly Lazy<ILoyaltyManager> _loyaltyManager;

	private readonly ILoyaltyCardManager _loyaltyCardManager;

	private readonly Lazy<IUserContext> _userContext;

	private readonly Lazy<ILoginManager> _loginManager;

	private readonly Lazy<IAdminContext> _adminContext;

	private readonly Lazy<IUniversalLinksService> _universalLinksService;

	private readonly LoyaltyCardScreen _loyaltyCardScreen;

	[CompilerGenerated]
	private bool _003CCodeAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCode_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CPointsAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CPoints_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CPointDecimals_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CPointsBurningAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CPointsBurningText_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CEPointsAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CEPoints_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CEPointDecimals_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CDelayedPointsAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CDelayedPointsText_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CMarksAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CMarks_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CMarkDecimals_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CMarksBurningAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CEmployeeInfoVisible_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CTimeout_003Ek__BackingField;

	[CompilerGenerated]
	private BalanceControlType _003CBalanceControlType_003Ek__BackingField;

	[CompilerGenerated]
	private ExpirationPointsEntity? _003CExpirationPoints_003Ek__BackingField;

	public bool CodeAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CCodeAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CCodeAvailable_003Ek__BackingField != value)
			{
				_003CCodeAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("CodeAvailable");
			}
		}
	}

	public string Code
	{
		[CompilerGenerated]
		get
		{
			return _003CCode_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCode_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCode_003Ek__BackingField = value;
				RaisePropertyChanged("Code");
			}
		}
	} = string.Empty;

	public bool PointsAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CPointsAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CPointsAvailable_003Ek__BackingField != value)
			{
				_003CPointsAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("PointsAvailable");
			}
		}
	} = true;

	public string Points
	{
		[CompilerGenerated]
		get
		{
			return _003CPoints_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CPoints_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CPoints_003Ek__BackingField = value;
				RaisePropertyChanged("Points");
			}
		}
	} = string.Empty;

	public string PointDecimals
	{
		[CompilerGenerated]
		get
		{
			return _003CPointDecimals_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CPointDecimals_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CPointDecimals_003Ek__BackingField = value;
				RaisePropertyChanged("PointDecimals");
			}
		}
	} = string.Empty;

	public bool PointsBurningAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CPointsBurningAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CPointsBurningAvailable_003Ek__BackingField != value)
			{
				_003CPointsBurningAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("PointsBurningAvailable");
			}
		}
	}

	public string PointsBurningText
	{
		[CompilerGenerated]
		get
		{
			return _003CPointsBurningText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CPointsBurningText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CPointsBurningText_003Ek__BackingField = value;
				RaisePropertyChanged("PointsBurningText");
			}
		}
	} = string.Empty;

	public bool EPointsAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CEPointsAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CEPointsAvailable_003Ek__BackingField != value)
			{
				_003CEPointsAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("EPointsAvailable");
			}
		}
	} = true;

	public string EPoints
	{
		[CompilerGenerated]
		get
		{
			return _003CEPoints_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CEPoints_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CEPoints_003Ek__BackingField = value;
				RaisePropertyChanged("EPoints");
			}
		}
	} = string.Empty;

	public string EPointDecimals
	{
		[CompilerGenerated]
		get
		{
			return _003CEPointDecimals_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CEPointDecimals_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CEPointDecimals_003Ek__BackingField = value;
				RaisePropertyChanged("EPointDecimals");
			}
		}
	} = string.Empty;

	public bool DelayedPointsAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CDelayedPointsAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CDelayedPointsAvailable_003Ek__BackingField != value)
			{
				_003CDelayedPointsAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("DelayedPointsAvailable");
			}
		}
	}

	public string DelayedPointsText
	{
		[CompilerGenerated]
		get
		{
			return _003CDelayedPointsText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CDelayedPointsText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CDelayedPointsText_003Ek__BackingField = value;
				RaisePropertyChanged("DelayedPointsText");
			}
		}
	} = string.Empty;

	public bool MarksAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CMarksAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CMarksAvailable_003Ek__BackingField != value)
			{
				_003CMarksAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("MarksAvailable");
			}
		}
	}

	public string Marks
	{
		[CompilerGenerated]
		get
		{
			return _003CMarks_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CMarks_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CMarks_003Ek__BackingField = value;
				RaisePropertyChanged("Marks");
			}
		}
	} = string.Empty;

	public string MarkDecimals
	{
		[CompilerGenerated]
		get
		{
			return _003CMarkDecimals_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CMarkDecimals_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CMarkDecimals_003Ek__BackingField = value;
				RaisePropertyChanged("MarkDecimals");
			}
		}
	} = string.Empty;

	public bool MarksBurningAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CMarksBurningAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CMarksBurningAvailable_003Ek__BackingField != value)
			{
				_003CMarksBurningAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("MarksBurningAvailable");
			}
		}
	}

	public string MarksBurningText => _adminContext.Value.StampsConfig?.ExpirationInformerText ?? string.Empty;

	public string MarksBurningUrl => _adminContext.Value.StampsConfig?.ExpirationInformerLink ?? string.Empty;

	public string EmployeeText => "Сотрудник Ашан Ритеил";

	public bool IsEmployee
	{
		get
		{
			if (base.ParentViewModel is LoyaltyTabViewModel)
			{
				return _userContext.Value.Profile.IsAuchanEmployee;
			}
			return false;
		}
	}

	public string EmployeeInfoText => "Ваш персональный кешбэк 10%";

	public bool EmployeeInfoVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CEmployeeInfoVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CEmployeeInfoVisible_003Ek__BackingField != value)
			{
				_003CEmployeeInfoVisible_003Ek__BackingField = value;
				RaisePropertyChanged("EmployeeInfoVisible");
			}
		}
	}

	public int Timeout
	{
		[CompilerGenerated]
		get
		{
			return _003CTimeout_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CTimeout_003Ek__BackingField != value)
			{
				_003CTimeout_003Ek__BackingField = value;
				RaisePropertyChanged("Timeout");
			}
		}
	} = 15;

	public BalanceControlType BalanceControlType
	{
		[CompilerGenerated]
		get
		{
			return _003CBalanceControlType_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CBalanceControlType_003Ek__BackingField != value)
			{
				_003CBalanceControlType_003Ek__BackingField = value;
				RaisePropertyChanged("BalanceControlType");
			}
		}
	}

	private ExpirationPointsEntity? ExpirationPoints
	{
		[CompilerGenerated]
		get
		{
			return _003CExpirationPoints_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CExpirationPoints_003Ek__BackingField, value))
			{
				_003CExpirationPoints_003Ek__BackingField = value;
				RaisePropertyChanged("ExpirationPoints");
			}
		}
	}

	public UICommand<MyPurchasesViewModel.Parameter> OpenPurchasesCommand { get; } = new UICommand<MyPurchasesViewModel.Parameter>();

	public UICommand OpenPointsCommand { get; } = new UICommand();

	public UICommand OpenCodeCommand { get; } = new UICommand();

	public UICommand<LoyaltyCardPointsExpirationViewModel.Parameter> OpenPointsBurningCommand { get; } = new UICommand<LoyaltyCardPointsExpirationViewModel.Parameter>();

	public UICommand OpenDelayedPointsCommand { get; } = new UICommand();

	public UICommand<InfoPageViewModel.Parameter> OpenStampsBurningDocumentCommand { get; } = new UICommand<InfoPageViewModel.Parameter>();

	public UICommand LoadCommand { get; } = new UICommand();

	public UICommand SwitchEmployeeInfoCommand { get; } = new UICommand();

	public LoyaltyCardElementViewModel(LoyaltyCardScreen loyaltyCardScreen, ScreenViewModel parentViewModel, Lazy<ILoyaltyManager> loyaltyManager, Lazy<IUserContext> userContext, Lazy<ILoginManager> loginManager, ILoyaltyCardManager loyaltyCardManager, Lazy<IAdminContext> adminContext, Lazy<IUniversalLinksService> universalLinksService)
		: base(parentViewModel)
	{
		_loyaltyCardScreen = loyaltyCardScreen;
		_loyaltyManager = loyaltyManager;
		_userContext = userContext;
		_loginManager = loginManager;
		_loyaltyCardManager = loyaltyCardManager;
		_adminContext = adminContext;
		_universalLinksService = universalLinksService;
		LoadCommand.PerformDebouncingTask(Load).Subscribe().AddTo(base.Disposables);
		_loyaltyCardManager.CodeUpdatedCommand.PerformDebouncingTask((string _) => LoadCode(forceUpdate: false)).Subscribe().AddTo(base.Disposables);
		SwitchEmployeeInfoCommand.Subscribe(delegate
		{
			EmployeeInfoVisible = !EmployeeInfoVisible;
		}).AddTo(base.Disposables);
		OpenPointsCommand.Subscribe(delegate
		{
			OpenPurchasesCommand.Trigger(new MyPurchasesViewModel.Parameter());
		}).AddTo(base.Disposables);
		OpenDelayedPointsCommand.Subscribe(delegate
		{
			OpenPurchasesCommand.Trigger(new MyPurchasesViewModel.Parameter
			{
				OpenOnStartup = MyPurchasesViewModel.FiltersIds.Delayed
			});
		}).AddTo(base.Disposables);
	}

	public void OpenPointsClick()
	{
		if (_loyaltyCardScreen == LoyaltyCardScreen.Home)
		{
			AppAnalytics.AppMetrica.TrackEvent("TapMainOnBalance");
		}
		OpenPointsCommand.Trigger();
	}

	public void OpenQrCodeClick()
	{
		OpenCodeCommand.Trigger();
	}

	public override async Task Start()
	{
		await base.Start();
		LoadCommand.Trigger();
	}

	public Task Load()
	{
		return Load(forceUpdate: false);
	}

	public Task Load(bool forceUpdate)
	{
		return Task.WhenAll(LoadCode(forceUpdate), LoadBalance());
	}

	private async Task LoadCode(bool forceUpdate)
	{
		await _loyaltyCardManager.GetLoyaltyCard(CancellationToken.None, forceUpdate);
		LoyaltyCardEntity loyaltyCard = _userContext.Value.LoyaltyCard;
		Code = loyaltyCard?.QrCode ?? Code;
		CodeAvailable = !string.IsNullOrWhiteSpace(Code) && loyaltyCard != null && loyaltyCard.QrCodeExpirationDate.HasValue && loyaltyCard.QrCodeExpirationDate > DateTime.Now;
		if (!CodeAvailable && !forceUpdate)
		{
			await LoadCode(forceUpdate: true);
		}
	}

	public void StampsBurningTapped()
	{
		string marksBurningUrl = MarksBurningUrl;
		if (Uri.IsWellFormedUriString(marksBurningUrl, UriKind.Absolute))
		{
			if (!marksBurningUrl.ToLower().StartsWith("auchan://"))
			{
				try
				{
					Browser.OpenAsync(marksBurningUrl);
					return;
				}
				catch
				{
					return;
				}
			}
			_universalLinksService.Value.HandleLink(marksBurningUrl);
		}
		else
		{
			OpenStampsBurningDocumentCommand.Trigger(new InfoPageViewModel.Parameter(marksBurningUrl));
		}
	}

	private async Task LoadBalance()
	{
		Result<LoyaltyCardEntity, DomainError> result = await _loyaltyManager.Value.GetBalanceAsync(Timeout);
		EPointsAvailable = _adminContext.Value.AppConfig?.LoyaltyConfig?.EPointsBalanceEnabled ?? true;
		MarksAvailable = _adminContext.Value.StampsConfig?.ShowStampsBalance ?? false;
		if (result.IsFailure)
		{
			Points = "-";
			EPoints = "-";
			Marks = "-";
			PointDecimals = string.Empty;
			EPointDecimals = string.Empty;
			UpdateBurningPoints(null);
			return;
		}
		Points = $"{(int)result.Value.PointsAmount:0}";
		PointDecimals = $"{result.Value.PointsAmount % 1m * 100m:00}";
		EPoints = $"{(int)result.Value.EPointsAmount:0}";
		EPointDecimals = $"{result.Value.EPointsAmount % 1m * 100m:00}";
		Marks = $"{(int)result.Value.StampsAmount:0}";
		MarkDecimals = string.Empty;
		MarksBurningAvailable = _adminContext.Value.StampsConfig?.ShowStampsBalance == true && _loyaltyCardScreen == LoyaltyCardScreen.LoyaltyCard && result.Value.StampsAmount > 0m && !string.IsNullOrEmpty(_adminContext.Value.StampsConfig?.ExpirationInformerText);
		UpdateBurningPoints(result.Value.ExpirationPoints);
		UpdateDelayedPoints(result.Value.DelayedPoints);
		switch (result.Value.CardStatus)
		{
		case LoyaltyCardStatus.ClosedByFraud:
			await _loginManager.Value.OpenCardBlocked();
			break;
		case LoyaltyCardStatus.Blocked:
		case LoyaltyCardStatus.Closed:
			await _loginManager.Value.ProceedLoyaltyRolloutCardOptions();
			break;
		default:
			base.StateUpdatedCommand.Trigger();
			break;
		}
	}

	private void UpdateBurningPoints(ExpirationPointsEntity? expiration)
	{
		ExpirationPoints = expiration;
		PointsBurningAvailable = expiration != null && expiration.Points >= 1m;
		if (expiration == null || expiration.Points < 1m)
		{
			return;
		}
		decimal num = Math.Truncate(expiration.Points);
		if (BalanceControlType == BalanceControlType.Burning)
		{
			if (expiration.ExpirationDate < DateTime.Now)
			{
				PointsBurningText = $"Скоро {GrammarHelper.DeclineNoun(num, new string[3] { "сгорит ", "сгорят ", "сгорят " })}{num.ToPointsString()} {GrammarHelper.DeclineNoun(num, new string[3] { "балл ", "балла ", "баллов " })}";
			}
			else
			{
				PointsBurningText = $"Потратьте {num.ToPointsString()} {GrammarHelper.DeclineNoun(num, new string[3] { "балл ", "балла ", "баллов " })}до {expiration.ExpirationDate:M}";
			}
		}
		if (BalanceControlType == BalanceControlType.Balance)
		{
			DateTime? value = _userContext.Value.LoyaltyCard?.LastBalanceUpdateTime;
			PointsBurningText = (value.HasValue ? $"Баланс на {value:HH:mm}, {value:dd MMMM}" : "Не удалось загрузить данные");
		}
	}

	private void UpdateDelayedPoints(DelayedPointsEntity? delayed)
	{
		if (delayed == null || delayed.DelayedPoints.Count == 0 || delayed.DelayedPoints.First().Points < 1m)
		{
			DelayedPointsAvailable = false;
			return;
		}
		decimal num = Math.Truncate(delayed.DelayedPoints.First().Points);
		DelayedPointsAvailable = base.ParentViewModel is LoyaltyTabViewModel && delayed.DelayedPoints.Any();
		DelayedPointsText = $"Скоро {GrammarHelper.DeclineNoun(num, new string[3] { "станет", "станут", "станут" })} {GrammarHelper.DeclineNoun(num, new string[3] { "активен", "активны", "активны" })} {num.ToPointsString()} {GrammarHelper.DeclineNoun(num, new string[3] { "балл ", "балла ", "баллов " })}";
	}

	public void OpenBurningPointsTapped()
	{
		if (ExpirationPoints?.ExpirationCurrencyList != null)
		{
			OpenPointsBurningCommand.Trigger(new LoyaltyCardPointsExpirationViewModel.Parameter(ExpirationPoints.ExpirationCurrencyList));
		}
	}
}
