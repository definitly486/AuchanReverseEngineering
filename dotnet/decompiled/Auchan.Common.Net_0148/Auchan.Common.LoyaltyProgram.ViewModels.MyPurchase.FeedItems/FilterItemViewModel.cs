using System;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;
using Auchan.Common.LoyaltyProgramLoymax;

namespace Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.FeedItems;

public class FilterItemViewModel : FeedItemViewModel
{
	private readonly Action<FilterItemViewModel, int> _itemSelectedHandler;

	private bool _isSelected;

	public HistoryFilter Filter { get; }

	public string OperationTypeName => Filter.Name;

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

	public FilterItemViewModel(Action<FilterItemViewModel, int> itemSelectedHandler, HistoryFilter filter)
	{
		_itemSelectedHandler = itemSelectedHandler;
		Filter = filter;
	}

	public override void OnItemsSelected(FeedItemViewModel item, int position)
	{
		if (item is FilterItemViewModel arg)
		{
			_itemSelectedHandler?.Invoke(arg, position);
		}
	}
}
