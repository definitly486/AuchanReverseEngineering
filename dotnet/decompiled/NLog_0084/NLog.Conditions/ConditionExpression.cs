using System;
using NLog.Common;
using NLog.Config;
using NLog.Internal;

namespace NLog.Conditions;

[NLogConfigurationItem]
public abstract class ConditionExpression
{
	internal static readonly object BoxedTrue = true;

	internal static readonly object BoxedFalse = false;

	public static implicit operator ConditionExpression?(string? conditionExpressionText)
	{
		if (conditionExpressionText == null)
		{
			return null;
		}
		return ConditionParser.ParseExpression(conditionExpressionText);
	}

	public object? Evaluate(LogEventInfo context)
	{
		try
		{
			return EvaluateNode(context);
		}
		catch (Exception ex)
		{
			InternalLogger.Warn(ex, "Exception occurred when evaluating condition");
			if (ex.MustBeRethrownImmediately())
			{
				throw;
			}
			throw new ConditionEvaluationException("Exception occurred when evaluating condition", ex);
		}
	}

	public abstract override string ToString();

	protected abstract object? EvaluateNode(LogEventInfo context);
}
