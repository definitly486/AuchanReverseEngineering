using System;
using NLog.Common;
using NLog.Internal;

namespace NLog.Targets.Wrappers;

[Target("RandomizeGroup", IsCompound = true)]
public class RandomizeGroupTarget : CompoundTargetBase
{
	private readonly Random _random = new Random();

	public RandomizeGroupTarget()
		: this(ArrayHelper.Empty<Target>())
	{
	}

	public RandomizeGroupTarget(string name, params Target[] targets)
		: this(targets)
	{
		base.Name = name;
	}

	public RandomizeGroupTarget(params Target[] targets)
		: base(targets)
	{
	}

	protected override void Write(AsyncLogEventInfo logEvent)
	{
		if (base.Targets.Count == 0)
		{
			logEvent.Continuation(null);
			return;
		}
		int index;
		lock (_random)
		{
			index = _random.Next(base.Targets.Count);
		}
		base.Targets[index].WriteAsyncLogEvent(logEvent);
	}
}
