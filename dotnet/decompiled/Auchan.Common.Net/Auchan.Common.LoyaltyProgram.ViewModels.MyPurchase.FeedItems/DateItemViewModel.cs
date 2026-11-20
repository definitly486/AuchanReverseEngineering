using System;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;

namespace Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.FeedItems;

public class DateItemViewModel : FeedItemViewModel
{
	public DateTime OperationTime;

	public string Text { get; }

	public DateItemViewModel(DateTime dateTime)
	{
		OperationTime = dateTime;
		Text = GetDateName(OperationTime);
	}

	private string GetDateName(DateTime dateTime)
	{
		if (dateTime.Date == DateTime.Now.Date)
		{
			return "Сегодня";
		}
		return dateTime.ToDayAndMonth();
	}
}
