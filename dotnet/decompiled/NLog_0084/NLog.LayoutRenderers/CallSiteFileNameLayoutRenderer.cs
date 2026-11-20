using System.IO;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("callsite-filename")]
[ThreadAgnostic]
public class CallSiteFileNameLayoutRenderer : LayoutRenderer, IUsesStackTrace, IStringValueRenderer
{
	public bool IncludeSourcePath { get; set; } = true;

	public int SkipFrames { get; set; }

	public bool CaptureStackTrace { get; set; } = true;

	StackTraceUsage IUsesStackTrace.StackTraceUsage => StackTraceUsageUtils.GetStackTraceUsage(includeFileName: true, SkipFrames, CaptureStackTrace);

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		builder.Append(GetStringValue(logEvent));
	}

	string IStringValueRenderer.GetFormattedString(LogEventInfo logEvent)
	{
		return GetStringValue(logEvent);
	}

	private string GetStringValue(LogEventInfo logEvent)
	{
		if (logEvent.CallSiteInformation != null)
		{
			string callerFilePath = logEvent.CallSiteInformation.GetCallerFilePath(SkipFrames);
			if (!string.IsNullOrEmpty(callerFilePath))
			{
				if (!IncludeSourcePath)
				{
					return Path.GetFileName(callerFilePath);
				}
				return callerFilePath;
			}
		}
		return string.Empty;
	}
}
