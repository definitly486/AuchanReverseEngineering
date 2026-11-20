using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Auchan.Common.LoyaltyProgram.ViewModels.Abstract;

namespace Auchan.Common.LoyaltyProgram.ViewModels.MyPurchase.FeedItems;

public class HeaderViewModel : FeedItemViewModel
{
	[CompilerGenerated]
	private IReadOnlyList<FilterItemViewModel> _003CFilters_003Ek__BackingField;

	[CompilerGenerated]
	private FilterItemViewModel? _003CActiveFilter_003Ek__BackingField;

	public string OperationType => "Тип операции";

	public IReadOnlyList<FilterItemViewModel> Filters
	{
		[CompilerGenerated]
		get
		{
			return _003CFilters_003Ek__BackingField;
		}
		[CompilerGenerated]
		internal set
		{
			if (!object.Equals(_003CFilters_003Ek__BackingField, value))
			{
				_003CFilters_003Ek__BackingField = value;
				RaisePropertyChanged("Filters");
			}
		}
	}

	public FilterItemViewModel? ActiveFilter
	{
		[CompilerGenerated]
		get
		{
			return _003CActiveFilter_003Ek__BackingField;
		}
		[CompilerGenerated]
		internal set
		{
			if (!object.Equals(_003CActiveFilter_003Ek__BackingField, value))
			{
				_003CActiveFilter_003Ek__BackingField = value;
				RaisePropertyChanged("ActiveFilter");
			}
		}
	}

	public HeaderViewModel()
	{
		Filters = Array.Empty<FilterItemViewModel>();
	}

	public void ScrollToActiveFilter()
	{
		RaisePropertyChanged("ActiveFilter");
	}
}
