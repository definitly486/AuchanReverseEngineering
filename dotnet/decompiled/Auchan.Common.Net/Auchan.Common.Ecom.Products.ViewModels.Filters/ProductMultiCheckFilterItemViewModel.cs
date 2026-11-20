using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Ecom.ProducModels.Filters;
using Newtonsoft.Json.Linq;

namespace Auchan.Common.Ecom.Products.ViewModels.Filters;

public class ProductMultiCheckFilterItemViewModel : BaseProductFilterItemViewModel
{
	[CompilerGenerated]
	private string _003CTitle_003Ek__BackingField;

	[CompilerGenerated]
	private List<ProductFilterMultiItem> _003CSelectedItems_003Ek__BackingField;

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

	public List<ProductFilterMultiItem> SelectedItems
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

	public ProductMultiCheckFilterItemViewModel(IProductFilterObserver observer, ProductFilter filter)
		: base(observer, filter)
	{
		Title = base.Filter.Name;
		SelectedItems = new List<ProductFilterMultiItem>();
	}

	public override Tuple<string, object>? GetSelectedFilter()
	{
		if (!SelectedItems.Any())
		{
			return null;
		}
		return new Tuple<string, object>(base.Filter.Code, SelectedItems.Select((ProductFilterMultiItem i) => i.Code).ToArray());
	}

	public override Tuple<string, string> GetSelectedFilterText()
	{
		if (SelectedItems.Count < 3)
		{
			string text = string.Join(", ", SelectedItems.Select((ProductFilterMultiItem x) => x.Name));
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
		SelectedItems.AddRange(base.Filter.Items.Where((ProductFilterMultiItem productFilterMultiItem) => array.Any((string sel) => sel == productFilterMultiItem.Code)));
		RaiseFilterChanged();
	}

	public void SetSelectedCodes(IEnumerable<string> selectedCodes)
	{
		SelectedItems.Clear();
		SelectedItems.AddRange(base.Filter.Items.Where((ProductFilterMultiItem i) => selectedCodes.Contains(i.Code)));
		RaiseFilterChanged();
	}

	public override void Restore(KeyValuePair<string, object> selectedFilter)
	{
		object value = selectedFilter.Value;
		if (!(value is JArray jArray))
		{
			if (value is string text)
			{
				SetSelectedFilter(Tuple.Create(selectedFilter.Key, (object)new string[1] { text }));
			}
		}
		else
		{
			object item = jArray.ToObject<string[]>();
			SetSelectedFilter(Tuple.Create(selectedFilter.Key, item));
		}
	}

	public void ToggleOption(ProductFilterMultiItem option)
	{
		if (SelectedItems.Contains(option))
		{
			SelectedItems.Remove(option);
		}
		else
		{
			SelectedItems.Add(option);
		}
		RaiseFilterChanged();
	}

	public override void ResetFilter(bool raiseFilterChanged = false)
	{
		SelectedItems.Clear();
		if (raiseFilterChanged)
		{
			RaiseFilterChanged();
		}
	}

	public override BaseProductFilterItemViewModel Copy()
	{
		ProductMultiCheckFilterItemViewModel productMultiCheckFilterItemViewModel = new ProductMultiCheckFilterItemViewModel(_observer, base.Filter);
		productMultiCheckFilterItemViewModel.SetSelectedFilter(GetSelectedFilter());
		return productMultiCheckFilterItemViewModel;
	}

	public override void SetFilter(ProductFilter filter)
	{
		base.SetFilter(filter);
		SelectedItems.RemoveAll((ProductFilterMultiItem f) => filter.Items.All((ProductFilterMultiItem i) => i.Code != f.Code));
	}
}
