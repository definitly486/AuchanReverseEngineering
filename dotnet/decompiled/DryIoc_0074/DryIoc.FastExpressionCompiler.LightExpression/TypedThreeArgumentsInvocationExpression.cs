using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedThreeArgumentsInvocationExpression : ThreeArgumentsInvocationExpression
{
	public override Type Type { get; }

	internal TypedThreeArgumentsInvocationExpression(Expression expression, Type type, Expression a0, Expression a1, Expression a2)
		: base(expression, a0, a1, a2)
	{
		Type = type;
	}
}
