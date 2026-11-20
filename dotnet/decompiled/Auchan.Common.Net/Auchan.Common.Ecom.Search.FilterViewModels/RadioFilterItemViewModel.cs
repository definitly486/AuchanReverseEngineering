using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Search.Infrastructure;
using Auchan.Common.Ecom.Search.Models;

namespace Auchan.Common.Ecom.Search.FilterViewModels;

public class RadioFilterItemViewModel : BaseFilterItemViewModel
{
	[CompilerGenerated]
	private string _003CTitle_003Ek__BackingField;

	private SearchFilterMultiItem? _selectedItem;

	public string Title
	{
		[CompilerGenerated]
		get
		{
			return _003CTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTitle_003Ek__BackingField = value;
				RaisePropertyChanged("Title");
			}
		}
	}

	public string ClearText => "Очистить";

	public SearchFilterMultiItem? SelectedItem
	{
		get
		{
			return _selectedItem;
		}
		set
		{
			if (!object.Equals(_selectedItem, value))
			{
				_selectedItem = value;
				RaisePropertyChanged("SelectedItem");
				_repository.OnFilterChanged(this);
			}
		}
	}

	public UICommand<RadioFilterItemViewModel> OpenRadioCommand { get; } = new UICommand<RadioFilterItemViewModel>();

	public RadioFilterItemViewModel(SearchProductsRepository repository, SearchFilter filter)
		: base(repository, filter)
	{
		Title = base.Filter.Name;
	}

	public override Tuple<string, object>? GetSelectedFilter()
	{
		if (SelectedItem == null)
		{
			return null;
		}
		return new Tuple<string, object>(base.Filter.Code, SelectedItem.Code);
	}

	public override Tuple<string, string> GetSelectedFilterText()
	{
		return Tuple.Create(base.Filter.Name + ": " + SelectedItem?.Name, (SelectedItem?.Name ?? "") ?? "");
	}

	public override void SetSelectedFilter(Tuple<string, object>? selectedValues)
	{
		if (selectedValues == null)
		{
			return;
		}
		object item = selectedValues.Item2;
		string code = item as string;
		if (code != null)
		{
			SelectedItem = base.Filter.Items.FirstOrDefault((SearchFilterMultiItem searchFilterMultiItem) => searchFilterMultiItem.Code == code);
		}
	}

	public override void ResetFilter(bool raiseFilterChanged = false)
	{
		SelectedItem = null;
		if (raiseFilterChanged)
		{
			_repository.OnFilterChanged(this);
		}
	}

	public override BaseFilterItemViewModel Copy()
	{
		RadioFilterItemViewModel radioFilterItemViewModel = new RadioFilterItemViewModel(_repository, base.Filter);
		radioFilterItemViewModel.SetSelectedFilter(GetSelectedFilter());
		return radioFilterItemViewModel;
	}

	public override void SetFilter(SearchFilter filter)
	{
		base.SetFilter(filter);
		if (SelectedItem != null && filter.Items.All((SearchFilterMultiItem i) => i.Code != SelectedItem.Code))
		{
			SelectedItem = null;
		}
	}
}
