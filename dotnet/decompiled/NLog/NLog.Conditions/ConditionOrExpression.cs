namespace NLog.Conditions;

internal sealed class ConditionOrExpression : ConditionExpression
{
	public ConditionExpression LeftExpression { get; }

	public ConditionExpression RightExpression { get; }

	public ConditionOrExpression(ConditionExpression left, ConditionExpression right)
	{
		LeftExpression = left;
		RightExpression = right;
	}

	public override string ToString()
	{
		return $"({LeftExpression} or {RightExpression})";
	}

	protected override object EvaluateNode(LogEventInfo context)
	{
		if ((bool)(LeftExpression.Evaluate(context) ?? ConditionExpression.BoxedFalse))
		{
			return ConditionExpression.BoxedTrue;
		}
		if ((bool)(RightExpression.Evaluate(context) ?? ConditionExpression.BoxedFalse))
		{
			return ConditionExpression.BoxedTrue;
		}
		return ConditionExpression.BoxedFalse;
	}
}
