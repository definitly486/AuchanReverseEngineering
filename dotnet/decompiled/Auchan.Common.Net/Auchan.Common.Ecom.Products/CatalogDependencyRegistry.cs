using Auchan.Common.Ecom.Products.Modifications;
using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.Ecom.Products;

public class CatalogDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IProductsApi>(new EnvironmentHttpClient(resolverContext.Resolve<EcomBaseUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<IProductsRepository, ProductsRepository>(Reuse.Singleton);
		registrator.Register<ProductModificationItemViewModel>();
		registrator.Register<IProductsManager, ProductsManager>(Reuse.Singleton);
	}
}
