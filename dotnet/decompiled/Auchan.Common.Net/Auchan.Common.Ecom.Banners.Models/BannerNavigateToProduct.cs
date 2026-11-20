using Auchan.Common.Ecom.Products.ViewModels;

namespace Auchan.Common.Ecom.Banners.Models;

internal sealed class BannerNavigateToProduct : IBannerNavigateTo
{
	private readonly string _productCode;

	public BannerNavigateToProduct(string productCode)
	{
		_productCode = productCode;
	}

	public void Activate(IBannerNavigationSupport viewModel)
	{
		ProductDetailsViewModel.Parameter subject = new ProductDetailsViewModel.Parameter(_productCode);
		viewModel.OpenProductDetailsCommand.Trigger(subject);
	}
}
