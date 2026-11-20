namespace NLog.Targets;

[Target("Null")]
public sealed class NullTarget : TargetWithLayout
{
	public bool FormatMessage { get; set; }

	public NullTarget()
	{
	}

	public NullTarget(string name)
		: this()
	{
		base.Name = name;
	}

	protected override void Write(LogEventInfo logEvent)
	{
		if (FormatMessage)
		{
			RenderLogEvent(Layout, logEvent);
		}
	}
}
