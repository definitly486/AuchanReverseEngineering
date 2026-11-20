using Auchan.Common.AdminTool;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.Ecom.Onboardings.Infrastructure;

public static class OnboardingsDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IOnboardingsAPI>(new EnvironmentHttpClient(resolverContext.Resolve<AdminToolBaseUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), new HttpMessageAuthSchemaHandler("Token", resolverContext.Resolve<CoreHttpMessageHandler>())), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.AddRefitClient<IOnbardingsApi>();
		registrator.Register<IOnboardingsService, OnboardingsService>(Reuse.Singleton);
		registrator.Register<IOnboardingsRepository, OnboardingsRepository>(Reuse.Singleton);
		registrator.Register<IOnboardingsManager, OnboardingsManager>(Reuse.Singleton);
	}
}
