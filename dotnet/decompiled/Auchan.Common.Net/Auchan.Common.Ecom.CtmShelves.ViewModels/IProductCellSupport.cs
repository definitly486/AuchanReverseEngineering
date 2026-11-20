using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;

namespace Auchan.Common.Ecom.CtmShelves.ViewModels;

public interface IProductCellSupport
{
	UICommand<ProductItemViewModel> ShowQtyDialogCommand { get; }

	UICommand<ProductDetailsViewModel.Parameter> OpenProductDetailsCommand { get; }
}
