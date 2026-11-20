using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedSixArgumentsInvocationExpression : SixArgumentsInvocationExpression
{
	public override Type Type { get; }

	internal TypedSixArgumentsInvocationExpression(Expression expression, Type type, Expression a0, Expression a1, Expression a2, Expression a3, Expression a4, Expression a5)
		: base(expression, a0, a1, a2, a3, a4, a5)
	{
		Type = type;
	}
}
