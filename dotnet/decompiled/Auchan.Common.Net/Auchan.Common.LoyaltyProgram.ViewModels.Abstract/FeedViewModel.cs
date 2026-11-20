using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;

namespace Auchan.Common.LoyaltyProgram.ViewModels.Abstract;

public abstract class FeedViewModel<TItemViewModel> : ScreenViewModel where TItemViewModel : FeedItemViewModel
{
	public ObservableRangeCollection<TItemViewModel> ItemsCollection { get; }

	public bool IsEmpty
	{
		get
		{
			if (IsDataLoaded)
			{
				return !ItemsCollection.Any();
			}
			return false;
		}
	}

	public bool IsDataLoaded
	{
		[CompilerGenerated]
		get
		{
			return _003CIsDataLoaded_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsDataLoaded_003Ek__BackingField != value)
			{
				_003CIsDataLoaded_003Ek__BackingField = value;
				RaisePropertyChanged("IsEmpty");
				RaisePropertyChanged("IsDataLoaded");
			}
		}
	}

	public FeedViewModel()
	{
		ItemsCollection = new ObservableRangeCollection<TItemViewModel>();
	}
}
