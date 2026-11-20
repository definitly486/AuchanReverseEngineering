using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Ecom.ProducModels.Filters;
using Newtonsoft.Json.Linq;

namespace Auchan.Common.Ecom.Products.ViewModels.Filters;

public class ProductRadioFilterItemViewModel : BaseProductFilterItemViewModel
{
	[CompilerGenerated]
	private string _003CTitle_003Ek__BackingField;

	private ProductFilterMultiItem? _selectedItem;

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

	public ProductFilterMultiItem? SelectedItem
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
				RaiseFilterChanged();
			}
		}
	}

	public ProductRadioFilterItemViewModel(IProductFilterObserver observer, ProductFilter filter)
		: base(observer, filter)
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
			SelectedItem = base.Filter.Items.FirstOrDefault((ProductFilterMultiItem productFilterMultiItem) => productFilterMultiItem.Code == code);
		}
	}

	public override void Restore(KeyValuePair<string, object> selectedFilter)
	{
		object item = (selectedFilter.Value as JArray)?.ToObject<string[]>();
		SetSelectedFilter(Tuple.Create(selectedFilter.Key, item));
	}

	public override void ResetFilter(bool raiseFilterChanged = false)
	{
		SelectedItem = null;
		if (raiseFilterChanged)
		{
			RaiseFilterChanged();
		}
	}

	public override BaseProductFilterItemViewModel Copy()
	{
		ProductRadioFilterItemViewModel productRadioFilterItemViewModel = new ProductRadioFilterItemViewModel(_observer, base.Filter);
		productRadioFilterItemViewModel.SetSelectedFilter(GetSelectedFilter());
		return productRadioFilterItemViewModel;
	}

	public override void SetFilter(ProductFilter filter)
	{
		base.SetFilter(filter);
		if (SelectedItem != null && filter.Items.All((ProductFilterMultiItem i) => i.Code != SelectedItem.Code))
		{
			SelectedItem = null;
		}
	}
}
