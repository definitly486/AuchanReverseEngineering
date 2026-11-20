using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers;

[LayoutRenderer("loggername")]
[LayoutRenderer("logger")]
[ThreadAgnostic]
public class LoggerNameLayoutRenderer : LayoutRenderer, IStringValueRenderer
{
	public bool ShortName { get; set; }

	public bool PrefixName { get; set; }

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		if (ShortName)
		{
			int num = TryGetLastDotForShortName(logEvent);
			if (num >= 0)
			{
				builder.Append(logEvent.LoggerName, num + 1, logEvent.LoggerName.Length - num - 1);
				return;
			}
		}
		else if (PrefixName)
		{
			int num2 = TryGetLastDotForShortName(logEvent);
			if (num2 > 0)
			{
				builder.Append(logEvent.LoggerName, 0, num2);
				return;
			}
		}
		builder.Append(logEvent.LoggerName);
	}

	string IStringValueRenderer.GetFormattedString(LogEventInfo logEvent)
	{
		if (ShortName)
		{
			int num = TryGetLastDotForShortName(logEvent);
			if (num >= 0)
			{
				return logEvent.LoggerName.Substring(num + 1);
			}
		}
		else if (PrefixName)
		{
			int num2 = TryGetLastDotForShortName(logEvent);
			if (num2 > 0)
			{
				return logEvent.LoggerName.Substring(0, num2);
			}
		}
		return logEvent.LoggerName ?? string.Empty;
	}

	private static int TryGetLastDotForShortName(LogEventInfo logEvent)
	{
		return logEvent.LoggerName?.LastIndexOf('.') ?? (-1);
	}
}
