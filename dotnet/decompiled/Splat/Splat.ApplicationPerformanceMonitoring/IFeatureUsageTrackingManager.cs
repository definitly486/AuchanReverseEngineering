namespace Splat.ApplicationPerformanceMonitoring;

public interface IFeatureUsageTrackingManager
{
	IFeatureUsageTrackingSession GetFeatureUsageTrackingSession(string featureName);
}
