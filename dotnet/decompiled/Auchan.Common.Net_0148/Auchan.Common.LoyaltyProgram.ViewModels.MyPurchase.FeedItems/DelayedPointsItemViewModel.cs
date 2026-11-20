using System;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;

namespace Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.FeedItems;

public class DelayedPointsItemViewModel : FeedItemViewModel, ILoyaltyOperation
{
	private bool _isPurchase;

	public DelayedPointsEntryEntity DelayedPointsEntryEntity { get; }

	public string ChequeNumber => DelayedPointsEntryEntity.ChequeNumber;

	public DateTime OperationDate => DelayedPointsEntryEntity.OperationTime;

	public string DelayedPointsOperationName => "Начисление баллов";

	public string FormattedDelayedPointsOrder => (_isPurchase ? "Покупка" : "Заказ") + " №" + DelayedPointsEntryEntity.ChequeNumber;

	public string FormattedDelayedPointsTransactionDate => $" от {DelayedPointsEntryEntity.TransactionDate:dd.MM.yyyy}";

	public string Points => NumberWithSignAndDecimal(DelayedPointsEntryEntity.Points);

	public DelayedPointsItemViewModel(DelayedPointsEntryEntity entry)
	{
		DelayedPointsEntryEntity = entry;
		_isPurchase = false;
		if (!string.IsNullOrEmpty(entry.ChequeNumber))
		{
			char[] array = entry.ChequeNumber.ToCharArray();
			if (array.Length >= 4 && array[3] == '0')
			{
				_isPurchase = true;
			}
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
}
