using System;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;

namespace Auchan.Common.LoyaltyProgram.ViewModels.PointsExpiration;

public class MonthAndYearItemViewModel : FeedItemViewModel
{
	public string Text { get; }

	public DateTime OperationTime { get; }

	public MonthAndYearItemViewModel(DateTime dateTime)
	{
		OperationTime = dateTime;
		Text = dateTime.ToMonthAndYear();
	}
}
