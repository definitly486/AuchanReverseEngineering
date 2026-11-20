using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Search.Infrastructure;
using Auchan.Common.Ecom.Search.Models;

namespace Auchan.Common.Ecom.Search.FilterViewModels;

public class MultiCheckFilterItemViewModel : BaseFilterItemViewModel
{
	[CompilerGenerated]
	private string _003CTitle_003Ek__BackingField;

	[CompilerGenerated]
	private List<SearchFilterMultiItem> _003CSelectedItems_003Ek__BackingField;

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

	public List<SearchFilterMultiItem> SelectedItems
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedItems_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CSelectedItems_003Ek__BackingField, value))
			{
				_003CSelectedItems_003Ek__BackingField = value;
				RaisePropertyChanged("SelectedItems");
			}
		}
	}

	public UICommand<MultiCheckFilterItemViewModel> OpenMulticheckCommand { get; } = new UICommand<MultiCheckFilterItemViewModel>();

	public MultiCheckFilterItemViewModel(SearchProductsRepository repository, SearchFilter filter)
		: base(repository, filter)
	{
		Title = base.Filter.Name;
		SelectedItems = new List<SearchFilterMultiItem>();
	}

	public override Tuple<string, object>? GetSelectedFilter()
	{
		if (!SelectedItems.Any())
		{
			return null;
		}
		return new Tuple<string, object>(base.Filter.Code, SelectedItems.Select((SearchFilterMultiItem i) => i.Code).ToArray());
	}

	public override Tuple<string, string> GetSelectedFilterText()
	{
		if (SelectedItems.Count < 3)
		{
			string text = string.Join(", ", SelectedItems.Select((SearchFilterMultiItem x) => x.Name));
			return Tuple.Create(base.Filter.Name + ": " + text, text ?? "");
		}
		return Tuple.Create($"{base.Filter.Name}: ({SelectedItems.Count})", $"({SelectedItems.Count})");
	}

	public override void SetSelectedFilter(Tuple<string, object>? selectedValues)
	{
		if (selectedValues == null)
		{
			return;
		}
		object item = selectedValues.Item2;
		string[] array = item as string[];
		if (array == null)
		{
			return;
		}
		SelectedItems.Clear();
		SelectedItems.AddRange(base.Filter.Items.Where((SearchFilterMultiItem searchFilterMultiItem) => array.Any((string sel) => sel == searchFilterMultiItem.Code)));
	}

	public void SetSelectedCodes(IEnumerable<string> selectedCodes)
	{
		SelectedItems.Clear();
		SelectedItems.AddRange(base.Filter.Items.Where((SearchFilterMultiItem i) => selectedCodes.Contains(i.Code)));
		_repository.OnFilterChanged(this);
	}

	public void ToggleOption(SearchFilterMultiItem option)
	{
		if (SelectedItems.Contains(option))
		{
			SelectedItems.Remove(option);
		}
		else
		{
			SelectedItems.Add(option);
		}
		_repository.OnFilterChanged(this);
	}

	public override void ResetFilter(bool raiseFilterChanged = false)
	{
		SelectedItems.Clear();
		if (raiseFilterChanged)
		{
			_repository.OnFilterChanged(this);
		}
	}

	public override BaseFilterItemViewModel Copy()
	{
		MultiCheckFilterItemViewModel multiCheckFilterItemViewModel = new MultiCheckFilterItemViewModel(_repository, base.Filter);
		multiCheckFilterItemViewModel.SetSelectedFilter(GetSelectedFilter());
		return multiCheckFilterItemViewModel;
	}

	public override void SetFilter(SearchFilter filter)
	{
		base.SetFilter(filter);
		SelectedItems.RemoveAll((SearchFilterMultiItem f) => filter.Items.All((SearchFilterMultiItem i) => i.Code != f.Code));
	}
}
