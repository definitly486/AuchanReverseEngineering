namespace Splat.ApplicationPerformanceMonitoring;

public sealed class DefaultFeatureUsageTrackingManager : FuncFeatureUsageTrackingManager
{
	public DefaultFeatureUsageTrackingManager()
		: base((string featureName) => new DefaultFeatureUsageTrackingSession(featureName))
	{
	}
}
