#define DEBUG
using System.Diagnostics;

namespace NLog.Targets;

[Target("DebugSystem")]
public sealed class DebugSystemTarget : TargetWithLayoutHeaderAndFooter
{
	public DebugSystemTarget()
	{
	}

	public DebugSystemTarget(string name)
		: this()
	{
		base.Name = name;
	}

	protected override void InitializeTarget()
	{
		base.InitializeTarget();
		if (base.Header != null)
		{
			DebugWriteLine(RenderLogEvent(base.Header, LogEventInfo.CreateNullEvent()));
		}
	}

	protected override void CloseTarget()
	{
		if (base.Footer != null)
		{
			DebugWriteLine(RenderLogEvent(base.Footer, LogEventInfo.CreateNullEvent()));
		}
		base.CloseTarget();
	}

	protected override void Write(LogEventInfo logEvent)
	{
		DebugWriteLine(RenderLogEvent(Layout, logEvent));
	}

	private static void DebugWriteLine(string message)
	{
		Debug.WriteLine(message);
	}
}
