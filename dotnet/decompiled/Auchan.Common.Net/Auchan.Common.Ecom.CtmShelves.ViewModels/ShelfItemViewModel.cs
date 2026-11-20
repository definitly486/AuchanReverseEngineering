using System;
using System.Collections.Generic;
using System.Linq;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.CtmShelves.Models;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Ecom.Products.ViewModels;
using Auchan.Common.Recommendations.Models;
using Auchan.Common.Recommendations.ViewModels;

namespace Auchan.Common.Ecom.CtmShelves.ViewModels;

public sealed class ShelfItemViewModel : BaseItemViewModel
{
	private readonly IProductCellSupport _productCellSupport;

	public Shelf Shelf { get; }

	public bool IsSubtitleVisible => !string.IsNullOrEmpty(Shelf.Subtitle);

	public string AllButtonText => "Все";

	public bool IsAllButtonVisible => Shelf.SeeAllLink.IsValid;

	public IReadOnlyList<BaseItemViewModel> Items { get; }

	public UICommand<ProductItemViewModel> ShowQtyDialogCommand => _productCellSupport.ShowQtyDialogCommand;

	public UICommand<ProductDetailsViewModel.Parameter> OpenProductDetailsCommand => _productCellSupport.OpenProductDetailsCommand;

	public ShelfItemViewModel(Shelf shelf, IProductCellSupport productCellSupport, Func<ProductWithAnalyticsInfo, ICollection<IDisposable>, RecomProductItemViewModel> viewModelFactory)
	{
		ShelfItemViewModel shelfItemViewModel = this;
		Shelf = shelf;
		_productCellSupport = productCellSupport;
		IReadOnlyList<BaseItemViewModel> collection = Array.Empty<BaseItemViewModel>();
		if (shelf.Banner != null)
		{
			collection = new global::_003C_003Ez__ReadOnlySingleElementList<BaseItemViewModel>(new CtmBannerItemViewModel(shelf));
		}
		List<BaseItemViewModel> list = new List<BaseItemViewModel>();
		list.AddRange(collection);
		list.AddRange(shelf.Products.Select((ProductWithAnalyticsInfo i) => viewModelFactory(i, shelfItemViewModel.Disposables)));
		Items = new _003C_003Ez__ReadOnlyList<BaseItemViewModel>(list);
	}

	public void NavigateToProduct(ProductItemViewModel product)
	{
		product.RecomAnalyticActions.OnNavigateToProductDetails(product);
		_productCellSupport.OpenProductDetailsCommand.Trigger(new ProductDetailsViewModel.Parameter(product.Product)
		{
			CtmShelfBlockId = product.RecomAnalytics.BlockId
		});
	}

	public void OnAllButtonClick()
	{
		Shelf.SeeAllLink.Activate(Shelf);
	}
}
