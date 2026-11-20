namespace NLog.Conditions;

internal sealed class ConditionExceptionExpression : ConditionExpression
{
	public override string ToString()
	{
		return "exception";
	}

	protected override object? EvaluateNode(LogEventInfo context)
	{
		return context.Exception;
	}
}
