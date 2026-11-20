using System;

namespace Splat.ApplicationPerformanceMonitoring;

public static class EnableFeatureUsageTrackingExtensions
{
	public static IFeatureUsageTrackingSession FeatureUsageTrackingSession(this IEnableFeatureUsageTracking instance, string featureName)
	{
		IFeatureUsageTrackingManager service = Locator.Current.GetService<IFeatureUsageTrackingManager>();
		if (service == null)
		{
			throw new InvalidOperationException("Feature Usage Tracking Manager is null. This should never happen, your dependency resolver is broken");
		}
		return service.GetFeatureUsageTrackingSession(featureName);
	}

	public static void WithFeatureUsageTrackingSession(this IEnableFeatureUsageTracking instance, string featureName, Action<IFeatureUsageTrackingSession> action)
	{
		action.ThrowArgumentNullExceptionIfNull("action");
		using IFeatureUsageTrackingSession featureUsageTrackingSession = instance.FeatureUsageTrackingSession(featureName);
		try
		{
			action(featureUsageTrackingSession);
		}
		catch (Exception exception)
		{
			featureUsageTrackingSession.OnException(exception);
			throw;
		}
	}

	public static void WithSubFeatureUsageTrackingSession(this IFeatureUsageTrackingSession instance, string featureName, Action<IFeatureUsageTrackingSession> action)
	{
		instance.ThrowArgumentNullExceptionIfNull("instance");
		action.ThrowArgumentNullExceptionIfNull("action");
		using IFeatureUsageTrackingSession featureUsageTrackingSession = instance.SubFeature(featureName);
		try
		{
			action(featureUsageTrackingSession);
		}
		catch (Exception exception)
		{
			featureUsageTrackingSession.OnException(exception);
			throw;
		}
	}
}
