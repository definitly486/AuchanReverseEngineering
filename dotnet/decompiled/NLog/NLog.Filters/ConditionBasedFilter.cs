using NLog.Conditions;

namespace NLog.Filters;

[Filter("when")]
public class ConditionBasedFilter : Filter
{
	internal static readonly ConditionBasedFilter Empty = new ConditionBasedFilter();

	public ConditionExpression Condition { get; set; } = ConditionLiteralExpression.Null;

	internal FilterResult FilterDefaultAction { get; set; }

	protected override FilterResult Check(LogEventInfo logEvent)
	{
		object obj = Condition?.Evaluate(logEvent);
		if (!ConditionExpression.BoxedTrue.Equals(obj))
		{
			return FilterDefaultAction;
		}
		return base.Action;
	}
}
