using Auchan.Common.AdminTool;
using Auchan.Common.Feedback;
using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.Logs;

internal static class LogMenuDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IFeedbackApi>(new EnvironmentHttpClient(resolverContext.Resolve<AdminToolBaseUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), new HttpMessageAuthSchemaHandler("Token", resolverContext.Resolve<CoreHttpMessageHandler>())), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<ILogService, LogService>(Reuse.Singleton);
	}
}
