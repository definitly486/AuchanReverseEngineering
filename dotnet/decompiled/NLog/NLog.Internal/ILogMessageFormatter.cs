using System.Text;

namespace NLog.Internal;

internal interface ILogMessageFormatter
{
	bool? EnableMessageTemplateParser { get; }

	string FormatMessage(LogEventInfo logEvent);

	bool HasProperties(LogEventInfo logEvent);

	void AppendFormattedMessage(LogEventInfo logEvent, StringBuilder builder);
}
