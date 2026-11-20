using NLog.Conditions;
using NLog.Config;

namespace NLog.Targets;

[NLogConfigurationItem]
public class ConsoleRowHighlightingRule
{
	public static ConsoleRowHighlightingRule Default { get; } = new ConsoleRowHighlightingRule(null, ConsoleOutputColor.NoChange, ConsoleOutputColor.NoChange);

	public ConditionExpression? Condition { get; set; }

	public ConsoleOutputColor ForegroundColor { get; set; } = ConsoleOutputColor.NoChange;

	public ConsoleOutputColor BackgroundColor { get; set; } = ConsoleOutputColor.NoChange;

	public ConsoleRowHighlightingRule()
	{
	}

	public ConsoleRowHighlightingRule(ConditionExpression? condition, ConsoleOutputColor foregroundColor, ConsoleOutputColor backgroundColor)
	{
		Condition = condition;
		ForegroundColor = foregroundColor;
		BackgroundColor = backgroundColor;
	}

	public bool CheckCondition(LogEventInfo logEvent)
	{
		if (Condition != null)
		{
			return true.Equals(Condition.Evaluate(logEvent));
		}
		return true;
	}
}
