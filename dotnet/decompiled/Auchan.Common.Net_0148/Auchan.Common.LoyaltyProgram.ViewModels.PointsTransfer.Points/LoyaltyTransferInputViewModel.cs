using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.Common;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Extensions;
using Auchan.Common.LoyaltyProgram.Managers;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Abstract;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Points;

public abstract class LoyaltyTransferInputViewModel : LoyaltyBaseTransferViewModel
{
	[CompilerGenerated]
	private int _003CEnteredAmount_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsAmountValid_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CAmountErrorText_003Ek__BackingField;

	protected LoyaltyPointsTransferNavigationParameter NavigationParameter { get; }

	protected IPointsTransferManager PointsTransferManager { get; }

	protected int EnteredAmount
	{
		[CompilerGenerated]
		get
		{
			return _003CEnteredAmount_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CEnteredAmount_003Ek__BackingField != value)
			{
				_003CEnteredAmount_003Ek__BackingField = value;
				RaisePropertyChanged("IsTransferButtonEnabled");
				RaisePropertyChanged("EnteredAmount");
			}
		}
	}

	public bool IsAmountValid
	{
		[CompilerGenerated]
		get
		{
			return _003CIsAmountValid_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsAmountValid_003Ek__BackingField != value)
			{
				_003CIsAmountValid_003Ek__BackingField = value;
				RaisePropertyChanged("IsTransferButtonEnabled");
				RaisePropertyChanged("IsAmountValid");
			}
		}
	} = true;

	public string AmountErrorText
	{
		[CompilerGenerated]
		get
		{
			return _003CAmountErrorText_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			if (!string.Equals(_003CAmountErrorText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CAmountErrorText_003Ek__BackingField = value;
				RaisePropertyChanged("AmountErrorText");
			}
		}
	} = "";

	public bool IsTransferButtonEnabled
	{
		get
		{
			if (EnteredAmount > 0 && IsAmountValid && IsPhoneValid)
			{
				return base.State != VisualState.InProgress;
			}
			return false;
		}
	}

	public string TransferButtonText => "Перевести";

	public virtual bool IsPhoneValid => true;

	public string ChooseRecipientLabel => "Выберите получателя";

	public string EnterPhoneLabel => "Укажите номер телефона получателя";

	public string EnterPointsLabel => "Укажите количество " + 5.GetLoyaltyPointsDeclined(base.PointsType);

	public string PointsHint => "Количество " + 5.GetLoyaltyPointsDeclined(base.PointsType);

	public LoyaltyTransferInputViewModel(LoyaltyPointsTransferNavigationParameter navigationParameter, ILoyaltyManager loyaltyManager, IInfoMessageService infoMessageService, IAdminContext adminContext, IPointsTransferManager pointsTransferManager)
		: base(loyaltyManager, infoMessageService, adminContext)
	{
		NavigationParameter = navigationParameter;
		PointsTransferManager = pointsTransferManager;
	}

	protected override Task LoadAvailableBalanceAsync()
	{
		if (NavigationParameter.ForStamps)
		{
			return base.LoadAvailableBalanceAsync();
		}
		base.PointsBalanceInt = NavigationParameter.PointsBalanceInt;
		base.PointsBalanceFraction = NavigationParameter.PointsBalanceFraction;
		base.StampsBalance = NavigationParameter.StampsBalance;
		return Task.CompletedTask;
	}

	protected void OnAmountInputChanged(string amountInput)
	{
		int result;
		bool flag = int.TryParse(amountInput, out result) || string.IsNullOrEmpty(amountInput);
		int num = ((base.PointsType == LoyaltyPointType.Points) ? base.PointsBalanceInt : base.StampsBalance);
		bool flag2 = (flag && result > num) || (!flag && amountInput.All((char c) => c >= '0' && c <= '9'));
		IsAmountValid = flag && !flag2;
		if (flag)
		{
			EnteredAmount = result;
		}
		if (flag2)
		{
			AmountErrorText = "У вас недостаточно " + 5.GetLoyaltyPointsDeclined(base.PointsType);
		}
		else if (!flag)
		{
			AmountErrorText = "Введите корректное число";
		}
		else
		{
			AmountErrorText = "";
		}
		RaisePropertyChanged("IsTransferButtonEnabled");
	}
}
