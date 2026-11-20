using Splat.ApplicationPerformanceMonitoring;

namespace Splat;

public static class ServiceLocationInitialization
{
	public static void InitializeSplat(this IMutableDependencyResolver resolver)
	{
		resolver.ThrowArgumentNullExceptionIfNull("resolver");
		RegisterDefaultLogManager(resolver);
		RegisterLogger(resolver);
		RegisterApplicationPerformanceMonitoring(resolver);
	}

	private static void RegisterApplicationPerformanceMonitoring(IMutableDependencyResolver resolver)
	{
		if (!resolver.HasRegistration(typeof(IFeatureUsageTrackingManager)))
		{
			resolver.RegisterConstant((IFeatureUsageTrackingManager?)new DefaultFeatureUsageTrackingManager(), (string?)null);
		}
	}

	private static void RegisterDefaultLogManager(IMutableDependencyResolver resolver)
	{
		if (!resolver.HasRegistration(typeof(ILogManager)))
		{
			resolver.Register(() => new DefaultLogManager(), typeof(ILogManager));
		}
	}

	private static void RegisterLogger(IMutableDependencyResolver resolver)
	{
		if (!resolver.HasRegistration(typeof(ILogger)))
		{
			resolver.RegisterConstant((ILogger?)new DebugLogger(), (string?)null);
		}
	}
}
