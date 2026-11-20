namespace NLog.Conditions;

internal sealed class ConditionNotExpression : ConditionExpression
{
	public ConditionExpression Expression { get; }

	public ConditionNotExpression(ConditionExpression expression)
	{
		Expression = expression;
	}

	public override string ToString()
	{
		return $"(not {Expression})";
	}

	protected override object EvaluateNode(LogEventInfo context)
	{
		if (!(bool)(Expression.Evaluate(context) ?? ConditionExpression.BoxedFalse))
		{
			return ConditionExpression.BoxedTrue;
		}
		return ConditionExpression.BoxedFalse;
	}
}
