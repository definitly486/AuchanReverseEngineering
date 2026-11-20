using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Auchan.Common.Ecom.ProducModels.Filters;

namespace Auchan.Common.Ecom.Products.ViewModels.Filters;

public class ProductCheckFilterItemViewModel : BaseProductFilterItemViewModel
{
	private const string PROMO_ONLY_CODE = "promo_only";

	private const string PROMO_ONLY_TEXT = "Только со скидкой";

	private const string HIGH_RATING_CODE = "high_rating";

	private const string HIGH_RATING_TEXT = "Только с высоким рейтингом";

	private const string TEXT_PREFIX = "Только ";

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
				RaiseFilterChanged();
			}
		}
	}

	public ProductCheckFilterItemViewModel(IProductFilterObserver observer, ProductFilter filter)
		: base(observer, filter)
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
		string code = base.Filter.Code;
		if (!(code == "promo_only"))
		{
			if (code == "high_rating")
			{
				return Tuple.Create("Только с высоким рейтингом", "Только с высоким рейтингом");
			}
			string text = "Только " + base.Filter.Name;
			return Tuple.Create(text, text);
		}
		return Tuple.Create("Только со скидкой", "Только со скидкой");
	}

	public override void SetSelectedFilter(Tuple<string, object>? selectedValues)
	{
		if (selectedValues != null && selectedValues.Item2 is bool isChecked)
		{
			IsChecked = isChecked;
		}
	}

	public override void Restore(KeyValuePair<string, object> selectedFilter)
	{
		SetSelectedFilter(Tuple.Create(selectedFilter.Key, selectedFilter.Value));
	}

	public override void ResetFilter(bool raiseFilterChanged = false)
	{
		_isChecked = false;
		RaisePropertyChanged("IsChecked");
		if (raiseFilterChanged)
		{
			RaiseFilterChanged();
		}
	}

	public override BaseProductFilterItemViewModel Copy()
	{
		ProductCheckFilterItemViewModel productCheckFilterItemViewModel = new ProductCheckFilterItemViewModel(_observer, base.Filter);
		productCheckFilterItemViewModel.SetSelectedFilter(GetSelectedFilter());
		return productCheckFilterItemViewModel;
	}
}
