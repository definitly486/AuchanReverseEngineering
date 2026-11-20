using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Points;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Abstract;

public abstract class LoyaltyBaseTransferViewModel : ScreenViewModel
{
	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private LoyaltyPointType _003CPointsType_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CPointsBalanceInt_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CPointsBalanceFraction_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CStampsBalance_003Ek__BackingField;

	protected ILoyaltyManager LoyaltyManager { get; }

	protected IInfoMessageService InfoMessageService { get; }

	protected IAdminContext AdminContext { get; }

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	}

	public LoyaltyPointType PointsType
	{
		[CompilerGenerated]
		get
		{
			return _003CPointsType_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			if (_003CPointsType_003Ek__BackingField != value)
			{
				_003CPointsType_003Ek__BackingField = value;
				RaisePropertyChanged("EnterAmountLabel");
				RaisePropertyChanged("AmountInputHint");
				RaisePropertyChanged("PointsType");
			}
		}
	}

	public virtual bool ShowStamps => AdminContext.StampsConfig?.AllowStampsTransfer == true;

	public virtual bool ShowPoints => LoyaltyManager.IsPointsTransferToUserEnabled;

	public string ScreenTitle
	{
		get
		{
			if (!ShowPoints || !ShowStamps)
			{
				if (!ShowStamps)
				{
					return "Подарить баллы";
				}
				return "Подарить марки";
			}
			return "Подарить баллы или марки";
		}
	}

	public string EnterAmountLabel
	{
		get
		{
			if (PointsType != LoyaltyPointType.Points)
			{
				return "Укажите количество марок";
			}
			return "Укажите количество баллов";
		}
	}

	public string AmountInputHint
	{
		get
		{
			if (PointsType != LoyaltyPointType.Points)
			{
				return "Количество марок";
			}
			return "Количество баллов";
		}
	}

	public string PointsTitle => "Баллы";

	public string StampsTitle => "Марки";

	public int PointsBalanceInt
	{
		[CompilerGenerated]
		get
		{
			return _003CPointsBalanceInt_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			if (_003CPointsBalanceInt_003Ek__BackingField != value)
			{
				_003CPointsBalanceInt_003Ek__BackingField = value;
				RaisePropertyChanged("PointsBalanceIntString");
				RaisePropertyChanged("PointsBalanceInt");
			}
		}
	}

	public int PointsBalanceFraction
	{
		[CompilerGenerated]
		get
		{
			return _003CPointsBalanceFraction_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			if (_003CPointsBalanceFraction_003Ek__BackingField != value)
			{
				_003CPointsBalanceFraction_003Ek__BackingField = value;
				RaisePropertyChanged("PointsBalanceFractionString");
				RaisePropertyChanged("PointsBalanceFraction");
			}
		}
	}

	public int StampsBalance
	{
		[CompilerGenerated]
		get
		{
			return _003CStampsBalance_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			if (_003CStampsBalance_003Ek__BackingField != value)
			{
				_003CStampsBalance_003Ek__BackingField = value;
				RaisePropertyChanged("StampsBalanceString");
				RaisePropertyChanged("StampsBalance");
			}
		}
	}

	public string PointsBalanceIntString => $"{PointsBalanceInt}";

	public string PointsBalanceFractionString => $"{PointsBalanceFraction:00}";

	public string StampsBalanceString => $"{StampsBalance}";

	public LoyaltyBaseTransferViewModel(ILoyaltyManager loyaltyManager, IInfoMessageService infoMessageService, IAdminContext adminContext)
	{
		LoyaltyManager = loyaltyManager;
		InfoMessageService = infoMessageService;
		AdminContext = adminContext;
	}

	protected override async Task Start()
	{
		await base.Start();
		await LoadAvailableBalanceAsync();
	}

	protected LoyaltyPointsTransferNavigationParameter GetLoyaltyPointsTransferNavigationParameter(LoyaltyPointType pointType, bool replacePrevious)
	{
		return new LoyaltyPointsTransferNavigationParameter(PointsBalanceInt, PointsBalanceFraction, StampsBalance, pointType, replacePrevious);
	}

	protected virtual async Task LoadAvailableBalanceAsync()
	{
		State = VisualState.InProgress;
		Result<LoyaltyCardEntity, DomainError> result = await LoyaltyManager.GetBalanceAsync();
		if (result.IsFailure)
		{
			State = VisualState.Default;
			return;
		}
		PointsBalanceInt = decimal.ToInt32(Math.Truncate(result.Value.PointsAmount));
		PointsBalanceFraction = decimal.ToInt32((result.Value.PointsAmount - (decimal)PointsBalanceInt) * 100m);
		StampsBalance = decimal.ToInt32(result.Value.StampsAmount);
		State = VisualState.Default;
	}

	protected abstract string ConfirmationDialogBody(int amount);

	protected virtual async Task<bool> DoTransferAsync(int amount)
	{
		AlertButton obj = await InfoMessageService.ShowDialogAsync("Вы уверены, что хотите перевести " + ((PointsType == LoyaltyPointType.Points) ? "баллы" : "марки") + "?", ConfirmationDialogBody(amount), new AlertButton[2]
		{
			new AlertButton
			{
				Title = "Да",
				Type = ActionType.Positive
			},
			new AlertButton
			{
				Title = "Отмена",
				Type = ActionType.Negative
			}
		});
		if ((object)obj == null || obj.Type != ActionType.Positive)
		{
			return false;
		}
		State = VisualState.InProgress;
		bool num = await TransferAsync(amount);
		State = VisualState.Default;
		if (!num)
		{
			return false;
		}
		return true;
	}

	public virtual void StampsTabTapped()
	{
	}

	public virtual void PointsTabTapped()
	{
	}

	protected virtual Task<bool> TransferAsync(int amount)
	{
		return Task.FromResult(result: true);
	}
}
