using System;

namespace Splat.ApplicationPerformanceMonitoring;

public sealed class DefaultFeatureUsageTrackingSession : IFeatureUsageTrackingSession<Guid>, IFeatureUsageTrackingSession, IDisposable, IEnableLogger
{
	public Guid ParentReference { get; }

	public Guid FeatureReference { get; }

	public string FeatureName { get; }

	public DefaultFeatureUsageTrackingSession(string featureName)
		: this(featureName, Guid.Empty)
	{
	}

	internal DefaultFeatureUsageTrackingSession(string featureName, Guid parentReference)
	{
		if (string.IsNullOrWhiteSpace(featureName))
		{
			throw new ArgumentNullException("featureName");
		}
		ParentReference = parentReference;
		FeatureName = featureName;
		FeatureReference = Guid.NewGuid();
		this.Log().Info<Func<string>>(GetSessionStartLogMessage);
	}

	public IFeatureUsageTrackingSession SubFeature(string description)
	{
		return new DefaultFeatureUsageTrackingSession(description, FeatureReference);
	}

	public void OnException(Exception exception)
	{
		this.Log().InfoException(() => "Feature Usage Tracking Exception", exception);
	}

	public void Dispose()
	{
		this.Log().Info<Func<string>>(() => $"Feature Finish: {FeatureReference}");
	}

	private string GetSessionStartLogMessage()
	{
		string text = $"Feature Start. Reference={FeatureReference}{((ParentReference != Guid.Empty) ? $", Parent Reference={ParentReference}" : null)}";
		if (ParentReference != Guid.Empty)
		{
			text += $", Parent Reference={ParentReference}";
		}
		return text;
	}
}
