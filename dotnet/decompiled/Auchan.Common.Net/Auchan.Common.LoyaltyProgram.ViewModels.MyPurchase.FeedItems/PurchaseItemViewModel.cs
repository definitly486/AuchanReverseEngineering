using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Enums;
using Auchan.Common.LoyaltyProgram.Extensions;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;

namespace Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.FeedItems;

public class PurchaseItemViewModel : FeedItemViewModel, ILoyaltyOperation
{
	[CompilerGenerated]
	private bool _003CShouldDisplayStamps_003Ek__BackingField;

	private string[] _orderSources = new string[5] { "W", "M", "D", "R", "O" };

	public LoyaltyProgramPurchase LoyaltyProgramPurchase { get; }

	public bool ShouldDisplayStamps
	{
		[CompilerGenerated]
		get
		{
			return _003CShouldDisplayStamps_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CShouldDisplayStamps_003Ek__BackingField != value)
			{
				_003CShouldDisplayStamps_003Ek__BackingField = value;
				RaisePropertyChanged("HasStamps");
				RaisePropertyChanged("ShouldDisplayStamps");
			}
		}
	}

	public string TransactionId => LoyaltyProgramPurchase.TransactionId;

	public string OrderNumber => LoyaltyProgramPurchase.OrderNumber;

	public int? StoreExternalId => LoyaltyProgramPurchase.StoreExternalId;

	public DateTime OperationDate => LoyaltyProgramPurchase.OperationDate;

	public QualifiedLoyaltyOperationType OperationType => GetOperationType();

	public string OperationName => GetOperationName();

	public string FormattedTime => LoyaltyProgramPurchase.OperationDate.ToString("dd.MM.yyyy, HH:mm");

	public string FormattedDelayedPointsOrder
	{
		get
		{
			if (OperationType != QualifiedLoyaltyOperationType.Purchase)
			{
				return "Заказ";
			}
			return "Покупка";
		}
	}

	public string FormattedDelayedPointsTime => $" от {LoyaltyProgramPurchase.OperationDate:dd.MM.yyyy}";

	public string Amount => OperationAmount();

	public string Points => NumberWithSignAndDecimal(LoyaltyProgramPurchase.Points);

	public bool HasPoints => LoyaltyProgramPurchase.Points != 0m;

	public string EPoints => NumberWithSignAndDecimal(LoyaltyProgramPurchase.EPoints);

	public bool HasEPoints => LoyaltyProgramPurchase.EPoints != 0m;

	public string Stamps => NumberWithSign(LoyaltyProgramPurchase.Stamps);

	public bool HasStamps
	{
		get
		{
			if (LoyaltyProgramPurchase.Stamps != 0m)
			{
				return ShouldDisplayStamps;
			}
			return false;
		}
	}

	public string DelayedPointsOperationName => "Начисление баллов";

	public string DelayedPoints => "+" + LoyaltyProgramPurchase.DelayedPoints.ToPointsString("### ##0.00", removeDecimals: false);

	public bool HasDelayedPoints => LoyaltyProgramPurchase.DelayedPoints != 0m;

	public bool IsOrderOrPurchase
	{
		get
		{
			if (OperationType != QualifiedLoyaltyOperationType.Order && OperationType != QualifiedLoyaltyOperationType.Purchase)
			{
				return OperationType == QualifiedLoyaltyOperationType.Refund;
			}
			return true;
		}
	}

	public PurchaseItemViewModel(LoyaltyProgramPurchase loyaltyProgramPurchase)
	{
		LoyaltyProgramPurchase = loyaltyProgramPurchase;
	}

	private QualifiedLoyaltyOperationType GetOperationType()
	{
		switch (LoyaltyProgramPurchase.OperationType)
		{
		case LoyaltyPurchaseOperationTypeDto.Purchase:
			if (LoyaltyProgramPurchase.IsRefund)
			{
				return QualifiedLoyaltyOperationType.Refund;
			}
			if (!_orderSources.Contains<string>(LoyaltyProgramPurchase.Source))
			{
				return QualifiedLoyaltyOperationType.Purchase;
			}
			return QualifiedLoyaltyOperationType.Order;
		case LoyaltyPurchaseOperationTypeDto.Undefined:
			return QualifiedLoyaltyOperationType.Undefined;
		case LoyaltyPurchaseOperationTypeDto.PointsIncome:
			if (LoyaltyProgramPurchase.Stamps > 0m)
			{
				return QualifiedLoyaltyOperationType.StampsRecieved;
			}
			if (LoyaltyProgramPurchase.Stamps < 0m)
			{
				return QualifiedLoyaltyOperationType.StampsGivenAway;
			}
			if (LoyaltyProgramPurchase.Points > 0m)
			{
				return QualifiedLoyaltyOperationType.PointsRecieved;
			}
			return QualifiedLoyaltyOperationType.PointsGivenAway;
		case LoyaltyPurchaseOperationTypeDto.PurchaseReturn:
			if (LoyaltyProgramPurchase.Comments.EqualsIgnoreCase("баллы за игру") && LoyaltyProgramPurchase.Stamps == 0m)
			{
				return QualifiedLoyaltyOperationType.GamePoints;
			}
			if (LoyaltyProgramPurchase.Comments.EqualsIgnoreCase("марки за игру") && LoyaltyProgramPurchase.Stamps != 0m)
			{
				return QualifiedLoyaltyOperationType.GameStamps;
			}
			if (!(LoyaltyProgramPurchase.Stamps != 0m))
			{
				return QualifiedLoyaltyOperationType.PointsCorrected;
			}
			return QualifiedLoyaltyOperationType.StampsCorrecred;
		case LoyaltyPurchaseOperationTypeDto.PointsExpiration:
			if (!(LoyaltyProgramPurchase.Stamps != 0m))
			{
				return QualifiedLoyaltyOperationType.PointsExpired;
			}
			return QualifiedLoyaltyOperationType.StampsExpired;
		case LoyaltyPurchaseOperationTypeDto.Order:
			return QualifiedLoyaltyOperationType.Order;
		default:
			return QualifiedLoyaltyOperationType.Undefined;
		}
	}

	private string OperationAmount()
	{
		switch (OperationType)
		{
		case QualifiedLoyaltyOperationType.Purchase:
		case QualifiedLoyaltyOperationType.Order:
		case QualifiedLoyaltyOperationType.Refund:
			return LoyaltyProgramPurchase.Total.GetFormattedMoneyAmount(OperationType);
		case QualifiedLoyaltyOperationType.StampsRecieved:
		case QualifiedLoyaltyOperationType.StampsGivenAway:
		case QualifiedLoyaltyOperationType.StampsCorrecred:
		case QualifiedLoyaltyOperationType.StampsExpired:
		case QualifiedLoyaltyOperationType.GameStamps:
			return NumberWithSign(LoyaltyProgramPurchase.Stamps);
		case QualifiedLoyaltyOperationType.PointsRecieved:
		case QualifiedLoyaltyOperationType.PointsGivenAway:
		case QualifiedLoyaltyOperationType.PointsCorrected:
		case QualifiedLoyaltyOperationType.PointsExpired:
		case QualifiedLoyaltyOperationType.GamePoints:
			return NumberWithSignAndOptionalTwoDigitDecimal(HasPoints ? LoyaltyProgramPurchase.Points : LoyaltyProgramPurchase.EPoints);
		default:
			return "";
		}
	}

	private string NumberWithSign(decimal x)
	{
		if (x > 0m)
		{
			return $"+{x:#,#.#}";
		}
		if (x < 0m)
		{
			return $"{x:#,#.#}";
		}
		return "0";
	}

	private string NumberWithSignAndOptionalTwoDigitDecimal(decimal x)
	{
		if (x % 1m != 0m)
		{
			return NumberWithSignAndDecimal(x);
		}
		if (x > 0m)
		{
			return $"+{x:#,##}";
		}
		if (x < 0m)
		{
			return $"{x:#,##}";
		}
		return "0";
	}

	private string NumberWithSignAndDecimal(decimal x)
	{
		if (x > 0m)
		{
			return $"+{x:0.00}";
		}
		if (x < 0m)
		{
			return $"{x:0.00}";
		}
		return "0";
	}

	private string GetOperationName()
	{
		QualifiedLoyaltyOperationType operationType = OperationType;
		switch (operationType)
		{
		case QualifiedLoyaltyOperationType.PointsRecieved:
			return "Перевод баллов";
		case QualifiedLoyaltyOperationType.PointsGivenAway:
			return "Перевод баллов";
		case QualifiedLoyaltyOperationType.Undefined:
			return "";
		case QualifiedLoyaltyOperationType.StampsRecieved:
			return "Вам подарили марки";
		case QualifiedLoyaltyOperationType.StampsGivenAway:
			return "Вы подарили марки";
		case QualifiedLoyaltyOperationType.Purchase:
			return "Покупка";
		case QualifiedLoyaltyOperationType.PointsCorrected:
			return "Корректировка баллов";
		case QualifiedLoyaltyOperationType.StampsCorrecred:
			return "Корректировка марок";
		case QualifiedLoyaltyOperationType.PointsExpired:
			return "Сгоревшие баллы";
		case QualifiedLoyaltyOperationType.StampsExpired:
			return "Сгорание марок. Акция завершена";
		case QualifiedLoyaltyOperationType.Order:
			return "Заказ";
		case QualifiedLoyaltyOperationType.GamePoints:
			return "Баллы за игру";
		case QualifiedLoyaltyOperationType.GameStamps:
			return "Марки за игру";
		case QualifiedLoyaltyOperationType.Refund:
			return "Возврат";
		default:
		{
			global::_003CPrivateImplementationDetails_003E.ThrowSwitchExpressionException(operationType);
			string result = default(string);
			return result;
		}
		}
	}
}
