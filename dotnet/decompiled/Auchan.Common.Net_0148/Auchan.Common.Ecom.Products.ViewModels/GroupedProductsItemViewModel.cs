using System.Collections.ObjectModel;
using Auchan.Common.Base;
using Auchan.Common.Ecom.ProducModels.ViewModels;

namespace Auchan.Common.Ecom.Products.ViewModels;

public class GroupedProductsItemViewModel : BaseItemViewModel
{
	public string Title { get; }

	public ObservableRangeCollection<ProductItemViewModel> Products { get; }

	public GroupedProductsItemViewModel(string title, ObservableRangeCollection<ProductItemViewModel> products)
	{
		Title = title;
		Products = products;
	}
}
