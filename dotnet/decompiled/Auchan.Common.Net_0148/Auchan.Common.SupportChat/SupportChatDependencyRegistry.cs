using Auchan.Common.Extensions;
using Auchan.Common.Net.SupportChat;
using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.SupportChat;

public static class SupportChatDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.Register<SupportChatMessageRepository>(Reuse.Singleton);
		registrator.RegisterMany<SupportChatMessageManager>(Reuse.Singleton);
		registrator.Register<SupportChatWebsocketClient>();
		registrator.Register<SupportChatWebSocketUrlProvider>();
		registrator.Register<ISupportChatAPIService, SupportChatAPIService>();
		registrator.Register<SupportChatApiUrlProvider>();
		registrator.RegisterMany<ChatSettingsUrlProvider>();
		registrator.Register<BeesenderFileServiseUrlProvider>();
		registrator.Register<IBeesenderFileUploader, BeesenderFileUploader>(Reuse.Singleton);
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<ISupportChatAPI>(new EnvironmentHttpClient(resolverContext.Resolve<SupportChatApiUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IBeesenderFileServiseAPI>(new EnvironmentHttpClient(resolverContext.Resolve<BeesenderFileServiseUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.AddRefitClient<IChatSettingsApi>();
		registrator.Register<ISupportChatMessageService, SupportChatMessageService>(Reuse.Singleton);
	}
}
