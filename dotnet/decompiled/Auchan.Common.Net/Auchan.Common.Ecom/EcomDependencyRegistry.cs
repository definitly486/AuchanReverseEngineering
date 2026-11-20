using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.Banners;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Ecom.Drive;
using Auchan.Common.Ecom.ProducModels.ViewModels;
using Auchan.Common.Extensions;
using Auchan.Common.Navigation;
using DryIoc;

namespace Auchan.Common.Ecom;

public static class EcomDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.AddRefitClient<IEcomApi>();
		registrator.AddRefitClient<IStoreApi>();
		registrator.AddRefitClient<ICarsApi>();
		registrator.AddRefitClient<IAddressApi>();
		registrator.Register<ICategoryRepository, CategoryRepository>(Reuse.Singleton);
		registrator.RegisterMany<EcomBaseUrlProvider>();
		registrator.RegisterMany<EcomContentBaseUrlProvider>();
		registrator.RegisterMany<ApiV2Provider>();
		registrator.Register<YandexMapUrlProvider>();
		registrator.Register<CheckoutPaymentSuccessUrlProvider>();
		registrator.Register<IEcomContext, EcomContext>(Reuse.Singleton);
		registrator.Register<IUserAddressService, UserAddressService>(Reuse.Singleton);
		registrator.Register<IStoreService, StoreService>(Reuse.Singleton);
		registrator.Register<StoreRepository>(Reuse.Singleton);
		registrator.Register<ICarsRepository, CarsRepository>(Reuse.Singleton);
		registrator.Register<ICarsService, CarsService>(Reuse.Singleton);
		registrator.Register<CheckProductUseCase>(Reuse.Singleton);
		registrator.Register<IPromoDiscountUsecase, PromoDiscountUsecase>(Reuse.Transient);
		registrator.Register<ProductItemViewModel>();
		registrator.Register<CartItemViewModel>();
		registrator.Register<SharedCartProductItemViewModel>();
		registrator.Register<AddressChanger>(Reuse.Singleton);
		registrator.Register<ICategoryManager, CategoryManager>(Reuse.Singleton);
		registrator.Register<NotAuthReopenScreenService>(Reuse.Singleton);
		BannersDependencyRegistry.Register(registrator);
	}
}
