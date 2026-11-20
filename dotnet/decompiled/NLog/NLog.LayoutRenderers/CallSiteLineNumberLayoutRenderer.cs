using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("callsite-linenumber")]
[ThreadAgnostic]
public class CallSiteLineNumberLayoutRenderer : LayoutRenderer, IUsesStackTrace, IRawValue
{
	public int SkipFrames { get; set; }

	public bool CaptureStackTrace { get; set; } = true;

	StackTraceUsage IUsesStackTrace.StackTraceUsage => StackTraceUsageUtils.GetStackTraceUsage(includeFileName: true, SkipFrames, CaptureStackTrace);

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		int? lineNumber = GetLineNumber(logEvent);
		if (lineNumber.HasValue)
		{
			builder.AppendInvariant(lineNumber.Value);
		}
	}

	bool IRawValue.TryGetRawValue(LogEventInfo logEvent, out object? value)
	{
		value = GetLineNumber(logEvent);
		return true;
	}

	private int? GetLineNumber(LogEventInfo logEvent)
	{
		if (logEvent.CallSiteInformation == null)
		{
			return null;
		}
		return logEvent.CallSiteInformation.GetCallerLineNumber(SkipFrames);
	}
}
