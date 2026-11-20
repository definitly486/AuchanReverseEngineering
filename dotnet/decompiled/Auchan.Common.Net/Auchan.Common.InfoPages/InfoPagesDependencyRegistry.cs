using Auchan.Common.AdminTool;
using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.InfoPages;

internal static class InfoPagesDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IInfoPagesApi>(new EnvironmentHttpClient(resolverContext.Resolve<AdminToolBaseUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), new HttpMessageAuthSchemaHandler("Token", resolverContext.Resolve<CoreHttpMessageHandler>())), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<IInfoPagesRepository, InfoPagesRepository>(Reuse.Singleton);
	}
}
