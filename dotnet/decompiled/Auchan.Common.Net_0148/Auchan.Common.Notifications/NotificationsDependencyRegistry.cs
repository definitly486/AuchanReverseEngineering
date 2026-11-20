using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.Notifications;

public static class NotificationsDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<INotificationsApi>(new EnvironmentHttpClient(new NotificationsBaseUrlProvider(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<NotificationsService>(Reuse.Singleton);
		registrator.Register<NotificationsCounterService>(Reuse.Singleton);
		registrator.RegisterMany<NotificationsApplicationStateObserver>(Reuse.Singleton);
	}
}
