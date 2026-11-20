using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Common;
using Auchan.Android.Extensions;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Banners;
using Auchan.Common.Ecom.Products.ViewModels;

namespace Auchan.Android.Ecom.Banners;

internal interface IBannerNavigationSupport : IFragmentNavigation
{
	sealed void Setup(Auchan.Common.Ecom.Banners.IBannerNavigationSupport viewModel, ILifecycleOwner lifecycleOwner)
	{
		viewModel.OpenProductDetailsCommand.SafeSubscribe(delegate(ProductDetailsViewModel.Parameter p)
		{
			NavigateTo<ProductDetailsFragment, ProductDetailsViewModel.Parameter>(p, null, add: true);
		}, lifecycleOwner);
		viewModel.OpenCategoryCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			NavigateTo<CatalogProductsFragment, BrokerToken>(p, null, add: true);
		}, lifecycleOwner);
		viewModel.OpenWebViewCommand.SafeSubscribe(delegate(WebViewModel.Parameter p)
		{
			NavigateTo<WebFragment, WebViewModel.Parameter>(p, null, add: true);
		}, lifecycleOwner);
	}
}
