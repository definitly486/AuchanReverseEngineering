namespace NLog.Conditions;

internal sealed class ConditionAndExpression : ConditionExpression
{
	public ConditionExpression Left { get; }

	public ConditionExpression Right { get; }

	public ConditionAndExpression(ConditionExpression left, ConditionExpression right)
	{
		Left = left;
		Right = right;
	}

	public override string ToString()
	{
		return $"({Left} and {Right})";
	}

	protected override object EvaluateNode(LogEventInfo context)
	{
		if (!(bool)(Left.Evaluate(context) ?? ConditionExpression.BoxedFalse))
		{
			return ConditionExpression.BoxedFalse;
		}
		if (!(bool)(Right.Evaluate(context) ?? ConditionExpression.BoxedFalse))
		{
			return ConditionExpression.BoxedFalse;
		}
		return ConditionExpression.BoxedTrue;
	}
}
