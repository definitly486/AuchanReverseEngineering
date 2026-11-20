using System.Collections.Generic;
using NLog.Common;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.Targets.Wrappers;

[Target("GroupByWrapper", IsWrapper = true)]
public class GroupByTargetWrapper : WrapperTargetBase
{
	private readonly SortHelpers.KeySelector<AsyncLogEventInfo, string> _buildKeyStringDelegate;

	public Layout Key { get; set; } = Layout.Empty;

	public GroupByTargetWrapper()
	{
		_buildKeyStringDelegate = (AsyncLogEventInfo logEvent) => RenderLogEvent(Key, logEvent.LogEvent);
	}

	public GroupByTargetWrapper(Target wrappedTarget)
		: this(string.Empty, wrappedTarget)
	{
	}

	public GroupByTargetWrapper(string name, Target wrappedTarget)
		: this(name, wrappedTarget, Layout.Empty)
	{
	}

	public GroupByTargetWrapper(string name, Target wrappedTarget, Layout key)
		: this()
	{
		base.Name = ((!string.IsNullOrEmpty(name) || wrappedTarget == null || string.IsNullOrEmpty(wrappedTarget.Name)) ? name : (wrappedTarget.Name + "_wrapper"));
		base.WrappedTarget = wrappedTarget;
		Key = key;
	}

	protected override void InitializeTarget()
	{
		if (Key == null || Key == Layout.Empty)
		{
			throw new NLogConfigurationException("GroupByTargetWrapper Key-property must be assigned. Group LogEvents using blank Key not supported.");
		}
		base.InitializeTarget();
	}

	protected override void Write(AsyncLogEventInfo logEvent)
	{
		base.WrappedTarget?.WriteAsyncLogEvent(logEvent);
	}

	protected override void Write(IList<AsyncLogEventInfo> logEvents)
	{
		foreach (KeyValuePair<string, IList<AsyncLogEventInfo>> item in logEvents.BucketSort(_buildKeyStringDelegate))
		{
			base.WrappedTarget?.WriteAsyncLogEvents(item.Value);
		}
	}
}
