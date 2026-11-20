using System;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Search.Infrastructure;
using Auchan.Common.Ecom.Search.Models;

namespace Auchan.Common.Ecom.Search.FilterViewModels;

public abstract class BaseFilterItemViewModel : ElementViewModel
{
	protected readonly SearchProductsRepository _repository;

	[CompilerGenerated]
	private SearchFilter _003CFilter_003Ek__BackingField;

	public SearchFilter Filter
	{
		[CompilerGenerated]
		get
		{
			return _003CFilter_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CFilter_003Ek__BackingField, value))
			{
				_003CFilter_003Ek__BackingField = value;
				RaisePropertyChanged("Code");
				RaisePropertyChanged("Disabled");
				RaisePropertyChanged("IsHaveInformer");
				RaisePropertyChanged("Filter");
			}
		}
	}

	public string Code => Filter.Code;

	public bool Disabled => Filter.Disabled == true;

	public bool IsHaveInformer => !string.IsNullOrEmpty(Filter.Informer);

	public BaseFilterItemViewModel(SearchProductsRepository repository, SearchFilter filter)
	{
		_repository = repository;
		Filter = filter;
	}

	public abstract Tuple<string, string> GetSelectedFilterText();

	public abstract Tuple<string, object>? GetSelectedFilter();

	public abstract void SetSelectedFilter(Tuple<string, object>? selectedValues);

	public abstract void ResetFilter(bool raiseFilterChanged = false);

	public abstract BaseFilterItemViewModel Copy();

	public virtual void SetFilter(SearchFilter filter)
	{
		Filter = filter;
	}
}
