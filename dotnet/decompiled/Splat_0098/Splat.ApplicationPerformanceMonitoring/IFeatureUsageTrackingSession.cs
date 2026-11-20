using System;

namespace Splat.ApplicationPerformanceMonitoring;

public interface IFeatureUsageTrackingSession : IDisposable
{
	string FeatureName { get; }

	IFeatureUsageTrackingSession SubFeature(string description);

	void OnException(Exception exception);
}
public interface IFeatureUsageTrackingSession<out TReferenceType> : IFeatureUsageTrackingSession, IDisposable
{
	TReferenceType FeatureReference { get; }

	TReferenceType ParentReference { get; }
}
