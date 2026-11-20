using System;
using System.Runtime.CompilerServices;
using Auchan.Common.Ecom.Search.Infrastructure;
using Auchan.Common.Ecom.Search.Models;

namespace Auchan.Common.Ecom.Search.FilterViewModels;

public class CheckFilterItemViewModel : BaseFilterItemViewModel
{
	[CompilerGenerated]
	private string _003CTitle_003Ek__BackingField;

	private bool _isChecked;

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

	public bool IsChecked
	{
		get
		{
			return _isChecked;
		}
		set
		{
			if (_isChecked != value)
			{
				_isChecked = value;
				RaisePropertyChanged("IsChecked");
				_repository.OnFilterChanged(this);
			}
		}
	}

	public CheckFilterItemViewModel(SearchProductsRepository repository, SearchFilter filter)
		: base(repository, filter)
	{
		Title = base.Filter.Name;
		_isChecked = false;
	}

	public override Tuple<string, object>? GetSelectedFilter()
	{
		if (!IsChecked)
		{
			return null;
		}
		return new Tuple<string, object>(base.Filter.Code, IsChecked);
	}

	public override Tuple<string, string> GetSelectedFilterText()
	{
		return Tuple.Create(base.Filter.Name, base.Filter.Name);
	}

	public override void SetSelectedFilter(Tuple<string, object>? selectedValues)
	{
		if (selectedValues != null && selectedValues.Item2 is bool isChecked)
		{
			IsChecked = isChecked;
		}
	}

	public override void ResetFilter(bool raiseFilterChanged = false)
	{
		_isChecked = false;
		RaisePropertyChanged("IsChecked");
		if (raiseFilterChanged)
		{
			_repository.OnFilterChanged(this);
		}
	}

	public override BaseFilterItemViewModel Copy()
	{
		CheckFilterItemViewModel checkFilterItemViewModel = new CheckFilterItemViewModel(_repository, base.Filter);
		checkFilterItemViewModel.SetSelectedFilter(GetSelectedFilter());
		return checkFilterItemViewModel;
	}
}
