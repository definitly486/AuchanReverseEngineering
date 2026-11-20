using System;
using System.Collections.Generic;
using Auchan.Common.DependencyInjection;
using DryIoc;

namespace Auchan.Common.Analytics.YandexAppMetrica;

public static class DevAnalytics
{
	private static IMetricaPlatformSdk Sdk => DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<IMetricaPlatformSdk>();

	public static void Report(string message, IReadOnlyDictionary<string, string>? parameters = null)
	{
		CreationStackTraceException error = new CreationStackTraceException(message);
		Sdk.ReportError(error, message, parameters);
	}

	public static void Report(string message, Exception ex, IReadOnlyDictionary<string, string>? parameters = null)
	{
		Sdk.ReportError(ex, message, parameters);
	}
}
