using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedTwoArgumentsInvocationExpression : TwoArgumentsInvocationExpression
{
	public override Type Type { get; }

	internal TypedTwoArgumentsInvocationExpression(Expression expression, Type type, Expression a0, Expression a1)
		: base(expression, a0, a1)
	{
		Type = type;
	}
}
