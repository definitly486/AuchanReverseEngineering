using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.Streams;

public static class StreamsDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IStreamApi>(new EnvironmentHttpClient(new StreamBaseUrlProvider(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<StreamsService>();
	}
}
