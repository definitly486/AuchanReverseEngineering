using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedOneArgumentInvocationExpression : OneArgumentInvocationExpression
{
	public override Type Type { get; }

	internal TypedOneArgumentInvocationExpression(Expression expression, Type type, Expression argument)
		: base(expression, argument)
	{
		Type = type;
	}
}
