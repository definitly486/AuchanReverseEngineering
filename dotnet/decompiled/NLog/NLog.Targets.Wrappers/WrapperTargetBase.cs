using System;
using NLog.Common;

namespace NLog.Targets.Wrappers;

public abstract class WrapperTargetBase : Target
{
	private Target? _wrappedTarget;

	public Target? WrappedTarget
	{
		get
		{
			return _wrappedTarget;
		}
		set
		{
			_wrappedTarget = value;
			_tostring = null;
		}
	}

	public override string ToString()
	{
		return _tostring ?? (_tostring = GenerateTargetToString());
	}

	private string GenerateTargetToString()
	{
		if (WrappedTarget == null)
		{
			return GenerateTargetToString(targetWrapper: true);
		}
		if (string.IsNullOrEmpty(base.Name))
		{
			return $"{GenerateTargetToString(targetWrapper: true, string.Empty)}_{WrappedTarget}";
		}
		return GenerateTargetToString(targetWrapper: true, string.Empty) + "_" + WrappedTarget.GenerateTargetToString(targetWrapper: false, base.Name);
	}

	protected override void FlushAsync(AsyncContinuation asyncContinuation)
	{
		if (WrappedTarget == null)
		{
			asyncContinuation(null);
		}
		else
		{
			WrappedTarget.Flush(asyncContinuation);
		}
	}

	protected override void InitializeTarget()
	{
		if (WrappedTarget == null)
		{
			throw new NLogConfigurationException(GetType().Name + "(Name=" + base.Name + "): No wrapped Target configured.");
		}
		base.InitializeTarget();
	}

	protected sealed override void Write(LogEventInfo logEvent)
	{
		throw new NotSupportedException("This target must not be invoked in a synchronous way.");
	}
}
