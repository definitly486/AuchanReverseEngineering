using System;
using System.Runtime.CompilerServices;
using Auchan.Common.Ecom.Search.Infrastructure;
using Auchan.Common.Ecom.Search.Models;
using Auchan.Common.Extensions;

namespace Auchan.Common.Ecom.Search.FilterViewModels;

public class RangeFilterItemViewModel : BaseFilterItemViewModel
{
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

	public RangeFilterItemViewModel(SearchProductsRepository repository, SearchFilter filter)
		: base(repository, filter)
	{
		_selectedMin = Min;
		_selectedMax = Max;
		SelectedMinText = Min.ToString();
		SelectedMaxText = Max.ToString();
	}

	public override Tuple<string, object>? GetSelectedFilter()
	{
		if (SelectedMin == Min && SelectedMax == Max)
		{
			return null;
		}
		return new Tuple<string, object>(base.Filter.Code, new int[2] { SelectedMin, SelectedMax });
	}

	public override Tuple<string, string> GetSelectedFilterText()
	{
		string text = string.Empty;
		if (base.Filter.Code == "price")
		{
			if (SelectedMin != Min || SelectedMax != Max)
			{
				text = ((SelectedMax == Max) ? ("От " + SelectedMin.ToString().InsertMultiple(3, " ") + " ₽") : ((SelectedMin != Min) ? (SelectedMin.ToString().InsertMultiple(3, " ") + " - " + SelectedMax.ToString().InsertMultiple(3, " ") + " ₽") : ("До " + SelectedMax.ToString().InsertMultiple(3, " ") + " ₽")));
			}
		}
		else if (SelectedMin != Min || SelectedMax != Max)
		{
			text = ((SelectedMax != Max) ? (base.Filter.Name + " до " + SelectedMax.ToString().InsertMultiple(3, " ")) : ((SelectedMin == Min) ? $"{base.Filter.Name} {SelectedMin.ToString().InsertMultiple(3, " ")} - {SelectedMax.ToString().InsertMultiple(3, " ")}" : (base.Filter.Name + " от " + SelectedMin.ToString().InsertMultiple(3, " "))));
		}
		return Tuple.Create(text, text);
	}

	public override void SetSelectedFilter(Tuple<string, object>? selectedValues)
	{
		if (selectedValues != null && selectedValues.Item2 is int[] array && array.Length == 2)
		{
			SelectedMin = array[0];
			SelectedMax = array[1];
			SelectedMinText = $"{Math.Min(Max, Math.Max(Min, SelectedMin))}{""}";
			SelectedMaxText = $"{Math.Max(Min, Math.Min(Max, SelectedMax))}{""}";
		}
	}

	public override void ResetFilter(bool raiseFilterChanged = false)
	{
		SelectedMin = Min;
		SelectedMax = Max;
		SelectedMinText = $"{SelectedMin}{""}";
		SelectedMaxText = $"{SelectedMax}{""}";
		if (raiseFilterChanged)
		{
			RaiseFilterChanged();
		}
	}

	public override BaseFilterItemViewModel Copy()
	{
		RangeFilterItemViewModel rangeFilterItemViewModel = new RangeFilterItemViewModel(_repository, base.Filter);
		rangeFilterItemViewModel.SetSelectedFilter(GetSelectedFilter());
		return rangeFilterItemViewModel;
	}

	public void ApplyMinTextValue(bool clampValues = true, bool raiseFilterChanged = true)
	{
		bool flag = false;
		int result;
		if (string.IsNullOrWhiteSpace(SelectedMinText))
		{
			SelectedMin = Min;
			SelectedMinText = $"{SelectedMin}{""}";
			flag = true;
		}
		else if (SelectedMinText.Length > 9)
		{
			SelectedMin = SelectedMax;
			SelectedMinText = $"{SelectedMin}{""}";
			flag = true;
		}
		else if (int.TryParse(SelectedMinText, out result) && result != SelectedMin)
		{
			if (clampValues)
			{
				SelectedMin = result.Clamp(Min, Math.Min(SelectedMax, Max));
			}
			else
			{
				SelectedMin = result;
			}
			SelectedMinText = $"{SelectedMin}{""}";
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
			SelectedMaxText = $"{SelectedMax}{""}";
			flag = true;
		}
		else if (SelectedMaxText.Length > 9)
		{
			SelectedMax = Max;
			SelectedMaxText = $"{SelectedMax}{""}";
			flag = true;
		}
		else if (int.TryParse(SelectedMaxText, out result) && result != SelectedMax)
		{
			if (clampValues)
			{
				SelectedMax = result.Clamp(Math.Max(SelectedMin, Min), Max);
			}
			else
			{
				SelectedMax = result;
			}
			SelectedMaxText = $"{SelectedMax}{""}";
			flag = true;
		}
		if (raiseFilterChanged && flag)
		{
			RaiseFilterChanged();
		}
	}

	public void RaiseFilterChanged()
	{
		_repository.OnFilterChanged(this);
	}

	public override void SetFilter(SearchFilter filter)
	{
		bool num = SelectedMin != base.Filter.Min;
		bool flag = SelectedMax != base.Filter.Max;
		base.SetFilter(filter);
		if (!num)
		{
			SelectedMin = Min;
			SelectedMinText = $"{Min}{""}";
		}
		if (!flag)
		{
			SelectedMax = Max;
			SelectedMaxText = $"{Max}{""}";
		}
	}
}
