namespace NLog.Targets;

[Target("Debug")]
public sealed class DebugTarget : TargetWithLayout
{
	public int Counter { get; private set; }

	public string LastMessage { get; private set; }

	public DebugTarget()
	{
		LastMessage = string.Empty;
		Counter = 0;
	}

	public DebugTarget(string name)
		: this()
	{
		base.Name = name;
	}

	protected override void Write(LogEventInfo logEvent)
	{
		Counter++;
		LastMessage = RenderLogEvent(Layout, logEvent);
	}
}
