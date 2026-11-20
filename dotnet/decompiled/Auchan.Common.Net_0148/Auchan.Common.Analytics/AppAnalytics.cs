using Auchan.Common.Analytics.Digenetica;
using Auchan.Common.Analytics.Loymax;
using Auchan.Common.Analytics.RocketRetail;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.DependencyInjection;
using DryIoc;

namespace Auchan.Common.Analytics;

public static class AppAnalytics
{
	public static ILoymaxAnalyticsService Loymax => DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<ILoymaxAnalyticsService>();

	public static IMetricaPlatformSdk YandexMetricaSdk => DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<IMetricaPlatformSdk>();

	public static IRocketRetailAnalytics RocketRetail => DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<IRocketRetailAnalytics>();

	public static IDigeneticaAnalytics Digenetica => DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<IDigeneticaAnalytics>();

	public static AppMetrica AppMetrica => DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<AppMetrica>();

	public static IEcomTracker Ecom => DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<IEcomTracker>();
}
