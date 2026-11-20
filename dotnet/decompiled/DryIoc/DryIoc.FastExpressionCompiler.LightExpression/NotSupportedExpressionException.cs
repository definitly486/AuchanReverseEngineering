using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class NotSupportedExpressionException : InvalidOperationException
{
	public readonly NotSupported Reason;

	public NotSupportedExpressionException(NotSupported reason)
		: base(reason.ToString())
	{
		Reason = reason;
	}

	public NotSupportedExpressionException(NotSupported reason, string message)
		: base(reason.ToString() + ": " + message)
	{
		Reason = reason;
	}
}
