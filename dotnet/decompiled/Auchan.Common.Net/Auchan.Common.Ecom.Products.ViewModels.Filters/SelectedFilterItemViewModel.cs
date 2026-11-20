using System;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;

namespace Auchan.Common.Ecom.Products.ViewModels.Filters;

public sealed class SelectedFilterItemViewModel : ElementViewModel
{
	[CompilerGenerated]
	private Tuple<string, string> _003CFilterText_003Ek__BackingField;

	public BaseProductFilterItemViewModel? Filter { get; }

	private Tuple<string, string> FilterText
	{
		[CompilerGenerated]
		get
		{
			return _003CFilterText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CFilterText_003Ek__BackingField, value))
			{
				_003CFilterText_003Ek__BackingField = value;
				RaisePropertyChanged("Text");
				RaisePropertyChanged("HightlightedText");
				RaisePropertyChanged("FilterText");
			}
		}
	}

	public string Text => FilterText.Item1;

	public string HightlightedText => FilterText.Item2;

	public bool IsDeleteAll => Filter == null;

	public SelectedFilterItemViewModel(BaseProductFilterItemViewModel? filter)
	{
		Filter = filter;
		FilterText = Filter?.GetSelectedFilterText() ?? Tuple.Create("Удалить все", "Удалить все");
	}
}
