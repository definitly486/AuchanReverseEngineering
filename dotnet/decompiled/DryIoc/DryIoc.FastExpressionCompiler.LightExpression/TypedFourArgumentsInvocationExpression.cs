using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedFourArgumentsInvocationExpression : FourArgumentsInvocationExpression
{
	public override Type Type { get; }

	internal TypedFourArgumentsInvocationExpression(Expression expression, Type type, Expression a0, Expression a1, Expression a2, Expression a3)
		: base(expression, a0, a1, a2, a3)
	{
		Type = type;
	}
}
