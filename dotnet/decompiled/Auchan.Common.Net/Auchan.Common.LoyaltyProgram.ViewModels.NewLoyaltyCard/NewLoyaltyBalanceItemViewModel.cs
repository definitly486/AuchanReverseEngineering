using System;
using System.Globalization;
using System.Reactive;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Authorization.Managers;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.ViewModels.NewLoyaltyCard;

public class NewLoyaltyBalanceItemViewModel : BaseItemViewModel
{
	private readonly ILoyaltyManager _loyaltyManager;

	private readonly IUserContext _userContext;

	private readonly ILoginManager _loginManager;

	private readonly IAdminContext _adminContext;

	private readonly Subject<Unit> _navigateToPointsExpiration = new Subject<Unit>();

	private bool _isInitialized;

	[CompilerGenerated]
	private BalanceControlType _003CBalanceControlType_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsRefreshing_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsBalanceEmpty_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsMarksViewAvailable_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CPoints_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CKopecks_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CExpressPoints_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CExpressKopecks_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CMarks_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CMessageText_003Ek__BackingField;

	private readonly Subject<Unit> _navigateToPurchaseHistory = new Subject<Unit>();

	public BalanceControlType BalanceControlType
	{
		[CompilerGenerated]
		get
		{
			return _003CBalanceControlType_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CBalanceControlType_003Ek__BackingField != value)
			{
				_003CBalanceControlType_003Ek__BackingField = value;
				RaisePropertyChanged("BalanceControlType");
			}
		}
	} = BalanceControlType.Balance;

	public bool IsRefreshing
	{
		[CompilerGenerated]
		get
		{
			return _003CIsRefreshing_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsRefreshing_003Ek__BackingField != value)
			{
				_003CIsRefreshing_003Ek__BackingField = value;
				RaisePropertyChanged("IsRefreshing");
			}
		}
	}

	public bool IsBalanceEmpty
	{
		[CompilerGenerated]
		get
		{
			return _003CIsBalanceEmpty_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsBalanceEmpty_003Ek__BackingField != value)
			{
				_003CIsBalanceEmpty_003Ek__BackingField = value;
				RaisePropertyChanged("IsBalanceEmpty");
			}
		}
	}

	public bool IsMarksViewAvailable
	{
		[CompilerGenerated]
		get
		{
			return _003CIsMarksViewAvailable_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsMarksViewAvailable_003Ek__BackingField != value)
			{
				_003CIsMarksViewAvailable_003Ek__BackingField = value;
				RaisePropertyChanged("IsMarksViewAvailable");
			}
		}
	}

	public string PointsName => "Баллы";

	public string ExpressPointsName => "Экспресс";

	public string MarksName => "Марки";

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
	} = "-";

	public string Kopecks
	{
		[CompilerGenerated]
		get
		{
			return _003CKopecks_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CKopecks_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CKopecks_003Ek__BackingField = value;
				RaisePropertyChanged("Kopecks");
			}
		}
	} = "-";

	public string ExpressPoints
	{
		[CompilerGenerated]
		get
		{
			return _003CExpressPoints_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CExpressPoints_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CExpressPoints_003Ek__BackingField = value;
				RaisePropertyChanged("ExpressPoints");
			}
		}
	} = "-";

	public string ExpressKopecks
	{
		[CompilerGenerated]
		get
		{
			return _003CExpressKopecks_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CExpressKopecks_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CExpressKopecks_003Ek__BackingField = value;
				RaisePropertyChanged("ExpressKopecks");
			}
		}
	} = "-";

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
	} = "-";

	public string MessageText
	{
		[CompilerGenerated]
		get
		{
			return _003CMessageText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CMessageText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CMessageText_003Ek__BackingField = value;
				RaisePropertyChanged("MessageText");
			}
		}
	} = "";

	public IObservable<Unit> NavigateToPointsExpirationCommand => _navigateToPointsExpiration.Debounce();

	public IObservable<Unit> NavigateToPurchaseHistoryCommand => _navigateToPurchaseHistory.Debounce();

	public NewLoyaltyBalanceItemViewModel(ILoyaltyManager loyaltyManager, IUserContext userContext, IAdminContext adminContext, ILoginManager loginManager)
	{
		_loyaltyManager = loyaltyManager;
		_userContext = userContext;
		_adminContext = adminContext;
		_loginManager = loginManager;
	}

	public void NavigateToPurchaseHistory()
	{
		AppAnalytics.AppMetrica.TapLoyaltyOnScoreStatistic();
		_navigateToPurchaseHistory.OnNext(Unit.Default);
	}

	public void NavigateToPointsExpiration()
	{
		_navigateToPointsExpiration.OnNext(Unit.Default);
	}

	public async Task InitializeAsync(BalanceControlType balanceControlType, int timeout = 15)
	{
		BalanceControlType = balanceControlType;
		Result<LoyaltyCardEntity, DomainError> result = await _loyaltyManager.GetBalanceAsync(timeout);
		IsMarksViewAvailable = _adminContext.StampsConfig?.ShowStampsBalance == true;
		if (result.IsSuccess)
		{
			Points = $"{(int)result.Value.PointsAmount}";
			Kopecks = result.Value.PointsAmount.ToString("0.00", CultureInfo.InvariantCulture).Split('.')[1] ?? "";
			ExpressPoints = $"{(int)result.Value.EPointsAmount}";
			ExpressKopecks = result.Value.EPointsAmount.ToString("0.00", CultureInfo.InvariantCulture).Split('.')[1] ?? "";
			Marks = $"{(int)result.Value.StampsAmount}";
			if (result.Value.PointsAmount == 0m && result.Value.EPointsAmount == 0m)
			{
				IsBalanceEmpty = true;
			}
			switch (result.Value.CardStatus)
			{
			case LoyaltyCardStatus.ClosedByFraud:
				await _loginManager.OpenCardBlocked();
				return;
			case LoyaltyCardStatus.Blocked:
			case LoyaltyCardStatus.Closed:
				await _loginManager.ProceedLoyaltyRolloutCardOptions();
				return;
			}
			if (result.Value.ExpirationPoints != null && balanceControlType == BalanceControlType.Burning)
			{
				ExpirationPointsEntity expirationPoints = result.Value.ExpirationPoints;
				MessageText = $"Потратьте {expirationPoints.Points:N2} {GrammarHelper.DeclineNoun(expirationPoints.Points, new string[3] { "балл ", "балла ", "баллов " })}до {expirationPoints.ExpirationDate:dd.MM.yy}";
			}
		}
		IsBalanceEmpty = result.IsFailure || result.Value.ExpirationPoints == null;
		if (balanceControlType == BalanceControlType.Balance)
		{
			DateTime? value = _userContext.LoyaltyCard?.LastBalanceUpdateTime;
			MessageText = (value.HasValue ? $"Баланс на {value:HH:mm}, {value:dd MMMM}" : "Не удалось загрузить данные");
		}
		_isInitialized = true;
	}

	public async Task Refresh()
	{
		if (_isInitialized)
		{
			IsRefreshing = true;
			await InitializeAsync(BalanceControlType);
			IsRefreshing = false;
		}
	}
}
