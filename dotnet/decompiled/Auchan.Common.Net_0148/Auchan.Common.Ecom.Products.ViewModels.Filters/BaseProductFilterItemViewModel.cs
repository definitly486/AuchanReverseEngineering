using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.ProducModels.Filters;

namespace Auchan.Common.Ecom.Products.ViewModels.Filters;

public abstract class BaseProductFilterItemViewModel : ElementViewModel
{
	public abstract class Usage
	{
		public string FilterCode { get; }

		protected Usage(string filterCode)
		{
			FilterCode = filterCode;
		}
	}

	private sealed class NoUsage : Usage
	{
		public NoUsage(string filterCode)
			: base(filterCode)
		{
		}
	}

	protected readonly IProductFilterObserver _observer;

	[CompilerGenerated]
	private ProductFilter _003CFilter_003Ek__BackingField;

	public ProductFilter Filter
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

	public UICommand<ProductMultiCheckFilterItemViewModel> OpenMultiCheckCommand => _observer.OpenMultiCheckCommand;

	public UICommand<ProductRadioFilterItemViewModel> OpenRadioCheckCommand => _observer.OpenRadioCheckCommand;

	public string Code => Filter.Code;

	public bool Disabled => Filter.Disabled == true;

	public bool IsHaveInformer => !string.IsNullOrEmpty(Filter.Informer);

	public BaseProductFilterItemViewModel(IProductFilterObserver observer, ProductFilter filter)
	{
		_observer = observer;
		Filter = filter;
	}

	public abstract Tuple<string, string> GetSelectedFilterText();

	public abstract Tuple<string, object>? GetSelectedFilter();

	public abstract void SetSelectedFilter(Tuple<string, object>? selectedValues);

	public abstract void ResetFilter(bool raiseFilterChanged = false);

	public abstract BaseProductFilterItemViewModel Copy();

	public abstract void Restore(KeyValuePair<string, object> selectedFilter);

	public virtual void SetFilter(ProductFilter filter)
	{
		Filter = filter;
	}

	public void RaiseFilterChanged()
	{
		_observer.OnFilterChanged(this);
	}

	public virtual Usage GetUsage()
	{
		return new NoUsage(Filter.Code);
	}

	public virtual void SetUsage(Usage usage)
	{
	}
}
