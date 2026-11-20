using System;
using System.Collections.Generic;
using System.Text;
using NLog.Common;

namespace NLog.Targets.Wrappers;

public abstract class CompoundTargetBase : Target
{
	public IList<Target> Targets { get; }

	protected CompoundTargetBase(params Target[] targets)
	{
		Targets = new List<Target>(targets);
	}

	public override string ToString()
	{
		return _tostring ?? (_tostring = GenerateTargetToString());
	}

	private string GenerateTargetToString()
	{
		if (string.IsNullOrEmpty(base.Name))
		{
			IList<Target> targets = Targets;
			if (targets != null && targets.Count > 0)
			{
				string value = string.Empty;
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(GenerateTargetToString(targetWrapper: true));
				stringBuilder.Append('[');
				foreach (Target target in Targets)
				{
					stringBuilder.Append(value);
					stringBuilder.Append(target.ToString());
					value = ", ";
				}
				stringBuilder.Append(']');
				return stringBuilder.ToString();
			}
		}
		return GenerateTargetToString(targetWrapper: true);
	}

	protected override void Write(LogEventInfo logEvent)
	{
		throw new NotSupportedException("This target must not be invoked in a synchronous way.");
	}

	protected override void FlushAsync(AsyncContinuation asyncContinuation)
	{
		AsyncHelpers.ForEachItemInParallel(Targets, asyncContinuation, delegate(Target t, AsyncContinuation c)
		{
			t.Flush(c);
		});
	}
}
