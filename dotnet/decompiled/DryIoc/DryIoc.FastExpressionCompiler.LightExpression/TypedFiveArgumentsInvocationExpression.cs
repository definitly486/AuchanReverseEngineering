using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedFiveArgumentsInvocationExpression : FiveArgumentsInvocationExpression
{
	public override Type Type { get; }

	internal TypedFiveArgumentsInvocationExpression(Expression expression, Type type, Expression a0, Expression a1, Expression a2, Expression a3, Expression a4)
		: base(expression, a0, a1, a2, a3, a4)
	{
		Type = type;
	}
}
