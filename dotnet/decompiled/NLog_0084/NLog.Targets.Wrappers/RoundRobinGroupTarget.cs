using System.Threading;
using NLog.Common;
using NLog.Internal;

namespace NLog.Targets.Wrappers;

[Target("RoundRobinGroup", IsCompound = true)]
public class RoundRobinGroupTarget : CompoundTargetBase
{
	private int _currentTarget = -1;

	public RoundRobinGroupTarget()
		: this(ArrayHelper.Empty<Target>())
	{
	}

	public RoundRobinGroupTarget(string name, params Target[] targets)
		: this(targets)
	{
		base.Name = name;
	}

	public RoundRobinGroupTarget(params Target[] targets)
		: base(targets)
	{
	}

	protected override void WriteAsyncThreadSafe(AsyncLogEventInfo logEvent)
	{
		Write(logEvent);
	}

	protected override void Write(AsyncLogEventInfo logEvent)
	{
		if (base.Targets.Count == 0)
		{
			logEvent.Continuation(null);
			return;
		}
		int index = (int)((uint)Interlocked.Increment(ref _currentTarget) % base.Targets.Count);
		base.Targets[index].WriteAsyncLogEvent(logEvent);
	}
}
