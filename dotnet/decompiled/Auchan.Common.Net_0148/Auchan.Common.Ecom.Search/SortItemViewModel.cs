using System.Runtime.CompilerServices;
using Auchan.Common.Base;

namespace Auchan.Common.Ecom.Search;

public class SortItemViewModel : ElementViewModel
{
	[CompilerGenerated]
	private bool _003CIsSelected_003Ek__BackingField;

	public bool IsSelected
	{
		[CompilerGenerated]
		get
		{
			return _003CIsSelected_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsSelected_003Ek__BackingField != value)
			{
				_003CIsSelected_003Ek__BackingField = value;
				RaisePropertyChanged("IsSelected");
			}
		}
	}

	public string Title { get; }

	public string Value { get; }

	public SortItemViewModel(string title, string value, bool isSelected = false)
	{
		Title = title;
		Value = value;
		IsSelected = isSelected;
	}
}
