using System;
using Auchan.Common.Ecom.Search.FilterViewModels;

namespace Auchan.Common.Ecom.Search;

public class SelectedFilterItemViewModel
{
	public BaseFilterItemViewModel? Filter { get; }

	private Tuple<string, string> FilterText { get; set; }

	public string Text => FilterText.Item1;

	public string HightlightedText => FilterText.Item2;

	public bool IsDeleteAll => Filter == null;

	public SelectedFilterItemViewModel(BaseFilterItemViewModel? filter)
	{
		Filter = filter;
		FilterText = Filter?.GetSelectedFilterText() ?? Tuple.Create("Удалить все", "Удалить все");
	}
}
