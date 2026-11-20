using System;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;
using Auchan.Common.Profile.DateOfBirthSelection.Items.Contracts;
using Auchan.Common.Profile.Enums;

namespace Auchan.Common.Profile.DateOfBirthSelection;

public class DaySelectorItemViewModel : BaseDateSelectorItemViewModel, IEnablable
{
	private bool _isEnabled;

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

	public DaySelectorItemViewModel(int day, bool isSelected, Action<DateSelectorItemDatePart, int> itemSelectedHandler)
		: base(DateSelectorItemDatePart.Day, day, isSelected, itemSelectedHandler)
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
