using AndroidX.Lifecycle;
using Auchan.Common.Ecom.Banners;

namespace Auchan.Android.Ecom.Banners;

internal static class IBannersFragmentSupportExtensions
{
	public static void SetupBannersNavigation(this IBannerNavigationSupport @this, Auchan.Common.Ecom.Banners.IBannerNavigationSupport viewModel, ILifecycleOwner lifecycleOwner)
	{
		@this.Setup(viewModel, lifecycleOwner);
	}
}
