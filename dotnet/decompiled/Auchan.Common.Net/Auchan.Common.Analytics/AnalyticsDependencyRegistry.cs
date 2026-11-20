using Auchan.Common.Analytics.Digenetica;
using Auchan.Common.Analytics.Loymax;
using Auchan.Common.Analytics.RocketRetail;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.LoyaltyProgram;
using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.Analytics;

internal static class AnalyticsDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.Register<IMetricaService, MetricaService>();
		registrator.Register<MetricaCsvRepository>(Reuse.Singleton);
		registrator.Register<IAppMetricaKeyProvider, AppMetricaKeyProvider>(Reuse.Singleton);
		registrator.RegisterMany<AppMetrica>(Reuse.Singleton);
		registrator.Register<EventLimiter>(Reuse.Singleton);
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IMetricaApi>(new EnvironmentHttpClient(new MetricaBaseUrlProvider(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<IEcomTracker, EcomTracker>(Reuse.Singleton);
		registrator.Register<IRocketRetailAnalytics, RocketRetailAnalytics>(Reuse.Singleton);
		registrator.Register<IDigeneticaAnalytics, DigeneticaAnalytics>(Reuse.Singleton);
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IDigeneticaApi>(new EnvironmentHttpClient(new DigeneticaBaseUrlProvider(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<LoymaxPushTokenService>(Reuse.Singleton);
		registrator.Register<LoymaxService>(Reuse.Singleton);
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<ILoymaxApi>(new EnvironmentHttpClient(resolverContext.Resolve<LoymaxLoyaltyProgramUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<LastFirebasePushTokenContainer>(Reuse.Singleton);
		registrator.RegisterMany<LoymaxAnalyticsService>(Reuse.Singleton);
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<ILoymaxAnalyticsApi>(new EnvironmentHttpClient(resolverContext.Resolve<LoymaxLoyaltyProgramUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
	}
}
