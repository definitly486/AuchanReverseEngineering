using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Products.ViewModels;

namespace Auchan.Common.Ecom.Banners;

public interface IBannerNavigationSupport
{
	UICommand<BrokerToken> OpenCategoryCommand { get; }

	UICommand<ProductDetailsViewModel.Parameter> OpenProductDetailsCommand { get; }

	UICommand<WebViewModel.Parameter> OpenWebViewCommand { get; }
}
