using Auchan.Common.DynamicFeedback.Services;
using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.DynamicFeedback;

internal static class DynamicFeedbackDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IDynamicFeedbackApi>(new EnvironmentHttpClient(resolverContext.Resolve<DymanicFeedbackBaseUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), new HttpMessageAuthSchemaHandler("Token", resolverContext.Resolve<CoreHttpMessageHandler>())), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<DymanicFeedbackBaseUrlProvider>();
		registrator.Register<DynamicFeedbackService>();
	}
}
