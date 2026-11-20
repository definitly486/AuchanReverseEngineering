using System;
using System.Globalization;

namespace NLog.Conditions;

internal sealed class ConditionLiteralExpression : ConditionExpression
{
	public static readonly ConditionLiteralExpression Null = new ConditionLiteralExpression(null);

	public static readonly ConditionLiteralExpression True = new ConditionLiteralExpression(ConditionExpression.BoxedTrue);

	public static readonly ConditionLiteralExpression False = new ConditionLiteralExpression(ConditionExpression.BoxedFalse);

	public object? LiteralValue { get; }

	public ConditionLiteralExpression(object? literalValue)
	{
		LiteralValue = literalValue;
	}

	public override string ToString()
	{
		if (LiteralValue == null)
		{
			return "null";
		}
		if (LiteralValue is string text)
		{
			return "'" + text + "'";
		}
		if (LiteralValue is char c)
		{
			return $"'{c}'";
		}
		return Convert.ToString(LiteralValue, CultureInfo.InvariantCulture);
	}

	protected override object? EvaluateNode(LogEventInfo context)
	{
		return LiteralValue;
	}
}
