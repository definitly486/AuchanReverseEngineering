using System;

namespace DryIoc.FastExpressionCompiler.LightExpression;

public sealed class TypedInvocationExpression : NotNullExpressionInvocationExpression
{
	public override Type Type { get; }

	internal TypedInvocationExpression(Expression expression, Type type)
		: base(expression)
	{
		Type = type;
	}
}
