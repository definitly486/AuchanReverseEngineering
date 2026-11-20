using System;

namespace Splat.ApplicationPerformanceMonitoring;

public class FuncFeatureUsageTrackingManager : IFeatureUsageTrackingManager
{
	private readonly Func<string, IFeatureUsageTrackingSession> _featureUsageTrackingSessionFunc = featureUsageTrackingSessionFunc ?? throw new ArgumentNullException("featureUsageTrackingSessionFunc");

	public FuncFeatureUsageTrackingManager(Func<string, IFeatureUsageTrackingSession> featureUsageTrackingSessionFunc)
	{
	}

	public IFeatureUsageTrackingSession GetFeatureUsageTrackingSession(string featureName)
	{
		return _featureUsageTrackingSessionFunc(featureName);
	}
}
