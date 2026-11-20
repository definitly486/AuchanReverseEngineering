using System;
using Auchan.Common.Profile.Enums;

namespace Auchan.Common.Profile.DateOfBirthSelection;

public class YearSelectorItemViewModel : BaseDateSelectorItemViewModel
{
	public YearSelectorItemViewModel(int year, bool isSelected, Action<DateSelectorItemDatePart, int> itemSelectedHandler)
		: base(DateSelectorItemDatePart.Year, year, isSelected, itemSelectedHandler)
	{
	}
}
