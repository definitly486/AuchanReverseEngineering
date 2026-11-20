using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Products.ViewModels;

namespace Auchan.Common.Ecom.Banners;

public sealed class BannerNavigationSupport : IBannerNavigationSupport
{
	public UICommand<BrokerToken> OpenCategoryCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<ProductDetailsViewModel.Parameter> OpenProductDetailsCommand { get; } = new UICommand<ProductDetailsViewModel.Parameter>();

	public UICommand<WebViewModel.Parameter> OpenWebViewCommand { get; } = new UICommand<WebViewModel.Parameter>();
}
