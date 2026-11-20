using System;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;
using Auchan.Common.Profile.Enums;

namespace Auchan.Common.Profile.DateOfBirthSelection;

public abstract class BaseDateSelectorItemViewModel : FeedItemViewModel
{
	private readonly DateSelectorItemDatePart _datePart;

	private readonly Action<DateSelectorItemDatePart, int> _itemSelectedHandler;

	private bool _isSelected;

	public int DatePartValue { get; }

	public bool IsSelected
	{
		get
		{
			return _isSelected;
		}
		set
		{
			if (_isSelected != value)
			{
				_isSelected = value;
				RaisePropertyChanged("IsSelected");
			}
		}
	}

	public virtual string Title => DatePartValue.ToString();

	public BaseDateSelectorItemViewModel(DateSelectorItemDatePart datePart, int datePartValue, bool isSelected, Action<DateSelectorItemDatePart, int> itemSelectedHandler)
	{
		DatePartValue = datePartValue;
		_datePart = datePart;
		_isSelected = isSelected;
		_itemSelectedHandler = itemSelectedHandler;
	}

	public override void OnItemsSelected(FeedItemViewModel item, int position)
	{
		if (!_isSelected)
		{
			_itemSelectedHandler?.Invoke(_datePart, DatePartValue);
		}
	}
}
