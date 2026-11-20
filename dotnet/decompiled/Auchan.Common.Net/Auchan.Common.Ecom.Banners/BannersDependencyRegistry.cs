using Auchan.Common.Ecom.Banners.Models;
using Auchan.Common.Extensions;
using DryIoc;

namespace Auchan.Common.Ecom.Banners;

internal static class BannersDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.AddRefitClient<IBannersApi>();
		registrator.Register<IBannersApiService, BannersApiService>(Reuse.Singleton);
		registrator.Register<IBannersRepository, BannersRepository>(Reuse.Singleton);
		registrator.Register<BannersNavigateToUrl>();
		registrator.Register<BannerNavigateToNative>();
		registrator.Register<BannerNavigateToCategory>();
		registrator.Register<BannerNavigateToProduct>();
		registrator.Register<BannerNoNavigation>(Reuse.Singleton);
	}
}
