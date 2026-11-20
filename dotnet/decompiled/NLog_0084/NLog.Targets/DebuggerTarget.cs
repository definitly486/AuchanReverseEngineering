using System;
using System.Diagnostics;
using NLog.Common;
using NLog.Internal;

namespace NLog.Targets;

[Target("Debugger")]
public sealed class DebuggerTarget : TargetWithLayoutHeaderAndFooter
{
	public DebuggerTarget()
	{
	}

	public DebuggerTarget(string name)
		: this()
	{
		base.Name = name;
	}

	protected override void InitializeTarget()
	{
		base.InitializeTarget();
		if (!Debugger.IsLogging())
		{
			InternalLogger.Debug("{0}: System.Diagnostics.Debugger.IsLogging()==false. Output has been disabled.", this);
		}
		if (base.Header != null)
		{
			Debugger.Log(LogLevel.Off.Ordinal, string.Empty, RenderLogEvent(base.Header, LogEventInfo.CreateNullEvent()) + "\n");
		}
	}

	protected override void CloseTarget()
	{
		if (base.Footer != null)
		{
			Debugger.Log(LogLevel.Off.Ordinal, string.Empty, RenderLogEvent(base.Footer, LogEventInfo.CreateNullEvent()) + "\n");
		}
		base.CloseTarget();
	}

	protected override void Write(LogEventInfo logEvent)
	{
		if (Debugger.IsLogging())
		{
			ReusableObjectCreator<System.Text.StringBuilder>.LockOject lockOject = ReusableLayoutBuilder.Allocate();
			string message;
			try
			{
				Layout.Render(logEvent, lockOject.Result);
				lockOject.Result.Append('\n');
				message = lockOject.Result.ToString();
			}
			finally
			{
				((IDisposable)lockOject/*cast due to .constrained prefix*/).Dispose();
			}
			Debugger.Log(logEvent.Level.Ordinal, logEvent.LoggerName, message);
		}
	}
}
