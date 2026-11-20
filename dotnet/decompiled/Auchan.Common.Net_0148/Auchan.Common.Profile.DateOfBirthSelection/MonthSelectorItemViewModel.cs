using System;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;
using Auchan.Common.Profile.DateOfBirthSelection.Items.Contracts;
using Auchan.Common.Profile.Enums;
using Auchan.Common.Profile.Extensions;

namespace Auchan.Common.Profile.DateOfBirthSelection;

public class MonthSelectorItemViewModel : BaseDateSelectorItemViewModel, IEnablable
{
	private bool _isEnabled;

	public override string Title => base.DatePartValue.GetMonthTitle();

	public bool IsEnabled
	{
		get
		{
			return _isEnabled;
		}
		set
		{
			if (_isEnabled != value)
			{
				_isEnabled = value;
				RaisePropertyChanged("IsEnabled");
			}
		}
	}

	public MonthSelectorItemViewModel(int month, bool isSelected, Action<DateSelectorItemDatePart, int> itemSelectedHandler)
		: base(DateSelectorItemDatePart.Month, month, isSelected, itemSelectedHandler)
	{
	}

	public override void OnItemsSelected(FeedItemViewModel item, int position)
	{
		if (IsEnabled)
		{
			base.OnItemsSelected(item, position);
		}
	}
}
