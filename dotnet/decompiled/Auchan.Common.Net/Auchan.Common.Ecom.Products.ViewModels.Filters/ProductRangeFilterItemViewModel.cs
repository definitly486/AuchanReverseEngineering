using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Ecom.ProducModels.Filters;
using Auchan.Common.Extensions;
using Newtonsoft.Json.Linq;

namespace Auchan.Common.Ecom.Products.ViewModels.Filters;

public class ProductRangeFilterItemViewModel : BaseProductFilterItemViewModel
{
	private sealed class RangeUsage : Usage
	{
		public bool IsMinChanged { get; set; }

		public bool IsMaxChanged { get; set; }

		public int SelectedMin { get; set; }

		public int SelectedMax { get; set; }

		public RangeUsage(string filterCode)
			: base(filterCode)
		{
		}
	}

	private bool _isMinChanged;

	private bool _isMaxChanged;

	private int _selectedMin;

	private int _selectedMax;

	[CompilerGenerated]
	private string _003CSelectedMinText_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CSelectedMaxText_003Ek__BackingField;

	private const string Suffix = "";

	public string Title => base.Filter.Name;

	public int Min => base.Filter.Min.GetValueOrDefault();

	public int Max => base.Filter.Max ?? 100;

	public int SelectedMin
	{
		get
		{
			return _selectedMin;
		}
		set
		{
			if (_selectedMin != value)
			{
				_selectedMin = value;
				RaisePropertyChanged("SelectedMin");
				_isMinChanged = Min < SelectedMin;
				SelectedMinText = $"{SelectedMin}{""}";
			}
		}
	}

	public int SelectedMax
	{
		get
		{
			return _selectedMax;
		}
		set
		{
			if (_selectedMax != value)
			{
				_selectedMax = value;
				RaisePropertyChanged("SelectedMax");
				_isMaxChanged = SelectedMax < Max;
				SelectedMaxText = $"{SelectedMax}{""}";
			}
		}
	}

	public string SelectedMinText
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedMinText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CSelectedMinText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CSelectedMinText_003Ek__BackingField = value;
				RaisePropertyChanged("SelectedMinText");
			}
		}
	}

	public string SelectedMaxText
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedMaxText_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CSelectedMaxText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CSelectedMaxText_003Ek__BackingField = value;
				RaisePropertyChanged("SelectedMaxText");
			}
		}
	}

	public ProductRangeFilterItemViewModel(IProductFilterObserver observer, ProductFilter filter)
		: base(observer, filter)
	{
		_selectedMin = Min;
		_selectedMax = Max;
		SelectedMinText = Min.ToString();
		SelectedMaxText = Max.ToString();
	}

	public override Tuple<string, object>? GetSelectedFilter()
	{
		ApplyMinMaxTextValues(raiseFilterChanged: false);
		if (!_isMinChanged && !_isMaxChanged)
		{
			return null;
		}
		return new Tuple<string, object>(base.Filter.Code, new int[2] { SelectedMin, SelectedMax });
	}

	public override Tuple<string, string> GetSelectedFilterText()
	{
		string obj = ((base.Filter.Code == "price") ? GetHighlighted("", "От ", "До ", " ₽") : GetHighlighted(base.Filter.Name + " ", "от ", "до ", ""));
		return Tuple.Create(obj, obj);
		string GetHighlighted(string prefix, string fromText, string toText, string suffix)
		{
			int num = Math.Max(SelectedMin, Min);
			int num2 = Math.Min(SelectedMax, Max);
			if (!_isMaxChanged)
			{
				return prefix + fromText + num.ToString().InsertMultiple(3, " ") + suffix;
			}
			if (_isMinChanged)
			{
				return $"{prefix}{num.ToString().InsertMultiple(3, " ")} - {num2.ToString().InsertMultiple(3, " ")}{suffix}";
			}
			return prefix + toText + num2.ToString().InsertMultiple(3, " ") + suffix;
		}
	}

	public override void SetSelectedFilter(Tuple<string, object>? selectedValues)
	{
		if (selectedValues != null && selectedValues.Item2 is int[] array && array.Length == 2)
		{
			if (_isMinChanged)
			{
				SelectedMin = array[0];
			}
			if (_isMaxChanged)
			{
				SelectedMax = array[1];
			}
			SelectedMinText = $"{Math.Max(Min, SelectedMin)}{""}";
			SelectedMaxText = $"{Math.Min(Max, SelectedMax)}{""}";
		}
	}

	public override void Restore(KeyValuePair<string, object> selectedFilter)
	{
		string? s = (selectedFilter.Value as JArray)?.FirstOrDefault()?.ToObject<string>();
		string s2 = (selectedFilter.Value as JArray)?.LastOrDefault()?.ToObject<string>();
		if (int.TryParse(s, out var result) && int.TryParse(s2, out var result2))
		{
			SetSelectedFilter(Tuple.Create(selectedFilter.Key, (object)new int[2] { result, result2 }));
			RaiseFilterChanged();
		}
	}

	public override void ResetFilter(bool raiseFilterChanged = false)
	{
		SelectedMin = Min;
		SelectedMax = Max;
		_isMinChanged = false;
		_isMaxChanged = false;
		SelectedMinText = $"{SelectedMin}{""}";
		SelectedMaxText = $"{SelectedMax}{""}";
		if (raiseFilterChanged)
		{
			RaiseFilterChanged();
		}
	}

	public override BaseProductFilterItemViewModel Copy()
	{
		ProductRangeFilterItemViewModel productRangeFilterItemViewModel = new ProductRangeFilterItemViewModel(_observer, base.Filter);
		productRangeFilterItemViewModel.SetSelectedFilter(GetSelectedFilter());
		return productRangeFilterItemViewModel;
	}

	public void ApplyMinTextValue(bool clampValues = true, bool raiseFilterChanged = true)
	{
		bool flag = false;
		int result;
		if (string.IsNullOrWhiteSpace(SelectedMinText))
		{
			SelectedMin = Min;
			flag = true;
		}
		else if (SelectedMinText.Length > 9)
		{
			SelectedMin = SelectedMax;
			flag = true;
		}
		else if (int.TryParse(SelectedMinText, out result) && result != SelectedMin)
		{
			SelectedMin = (clampValues ? result.Clamp(Min, Math.Min(SelectedMax, Max)) : result);
			flag = true;
		}
		if (raiseFilterChanged && flag)
		{
			RaiseFilterChanged();
		}
	}

	public void ApplyMaxTextValue(bool clampValues = true, bool raiseFilterChanged = true)
	{
		bool flag = false;
		int result;
		if (string.IsNullOrWhiteSpace(SelectedMaxText))
		{
			SelectedMax = SelectedMin;
			flag = true;
		}
		else if (SelectedMaxText.Length > 9)
		{
			SelectedMax = Max;
			flag = true;
		}
		else if (int.TryParse(SelectedMaxText, out result) && result != SelectedMax)
		{
			SelectedMax = (clampValues ? result.Clamp(Math.Max(SelectedMin, Min), Max) : result);
			flag = true;
		}
		if (raiseFilterChanged && flag)
		{
			RaiseFilterChanged();
		}
	}

	public void ApplyMinMaxTextValues(bool raiseFilterChanged = true)
	{
		int result;
		int num = (string.IsNullOrWhiteSpace(SelectedMinText) ? Min : ((SelectedMinText.Length > 9) ? Max : (int.TryParse(SelectedMinText, out result) ? Math.Max(result, Min) : Min)));
		int result2;
		int num2 = (string.IsNullOrWhiteSpace(SelectedMaxText) ? Min : ((SelectedMaxText.Length > 9) ? Max : (int.TryParse(SelectedMaxText, out result2) ? Math.Min(result2, Max) : Min)));
		SelectedMin = Math.Min(num, num2);
		SelectedMax = Math.Max(num2, num);
		bool flag = SelectedMin != num || SelectedMax != num2;
		if (raiseFilterChanged && flag)
		{
			RaiseFilterChanged();
		}
	}

	public override void SetFilter(ProductFilter filter)
	{
		base.SetFilter(filter);
		if (!_isMinChanged)
		{
			SelectedMin = Min;
		}
		if (!_isMaxChanged)
		{
			SelectedMax = Max;
		}
	}

	public override Usage GetUsage()
	{
		return new RangeUsage(base.Filter.Code)
		{
			IsMinChanged = _isMinChanged,
			IsMaxChanged = _isMaxChanged,
			SelectedMin = SelectedMin,
			SelectedMax = SelectedMax
		};
	}

	public override void SetUsage(Usage usage)
	{
		base.SetUsage(usage);
		if (usage is RangeUsage rangeUsage && rangeUsage.FilterCode == base.Filter.Code)
		{
			SelectedMin = rangeUsage.SelectedMin;
			SelectedMax = rangeUsage.SelectedMax;
			RaiseFilterChanged();
		}
	}
}
