using System.Collections.Generic;
using System.ComponentModel;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Products.ViewModels.Filters;

namespace Auchan.Common.Ecom.Products;

public interface IProductFilterObserver : INotifyPropertyChanged, IScreenViewModel, IBindable
{
	bool IsWaitingForResponse { get; }

	UICommand<ProductMultiCheckFilterItemViewModel> OpenMultiCheckCommand { get; }

	UICommand<ProductRadioFilterItemViewModel> OpenRadioCheckCommand { get; }

	IReadOnlyList<BaseProductFilterItemViewModel> Filters { get; }

	void OnFilterChanged(BaseProductFilterItemViewModel filter);
}
